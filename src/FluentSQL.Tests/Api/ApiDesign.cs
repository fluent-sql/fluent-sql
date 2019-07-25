using System.Data;
using System.Threading.Tasks;

using FluentSQL.Databases;
using FluentSQL.Extensions;
using FluentSQL.Querying.Extensions;
using FluentSQL.Querying.Functions.Extensions;
using FluentSQL.Querying.Statements.Extensions;
using FluentSQL.Tests.Databases.Builders;
using FluentSQL.Tests.Examples;

namespace FluentSQL.Tests.Api
{
    public sealed class ApiDesign
    {
        private IDbConnection SomeConnection { get; }

        public async Task TestApi()
        {
            Database database = new DatabaseBuilder().Build();
            var c = new Customer();
            var i = new Invoice();
            var l = new InvoiceLine();

            Invoice i2 = i;

            /*
             * SELECT customers.*
             *   FROM dbo.customers c
             *  WHERE dbo.customers.id > 0
             */
            Query<int> parameterless =
                database
                    .Query<int>()
                    .From(() => c)
                    .Where(() => c.Id > 0)
                    .Select(() => c.All())
                    .Compile();

            int parameterlessResult = await SomeConnection.ExecuteAsync(parameterless);

            /*
             * SELECT i2.invoice_number AS InvoiceIdFromSubquery
             *   FROM dbo.invoices i2
             *  WHERE i2.invoice_number = i.invoice_number
             */
            Query<ExampleParameters, SubqueryResult> subquery =
                database
                    .Query<SubqueryResult>().WithParameters<ExampleParameters>()
                    .From(() => i2)
                    .Where(p => i2.InvoiceNumber == i.InvoiceNumber)
                    .Select(() => i2.InvoiceNumber).As(r => r.InvoiceIdFromSubquery)
                    .Compile();

            /*
             *      SELECT DISTINCT TOP 100 c.name, i.invoice_date, SUM(l.price) AS total
             *        FROM dbo.customers c
             *  INNER JOIN dbo.invoices i ON i.customer_id = c.id
             *   LEFT JOIN (SELECT i2.invoice_number AS InvoiceIdFromSubquery
             *                FROM dbo.invoices i2
             *               WHERE i2.invoice_number = i.invoice_number) subquery ON subquery.InvoiceIdFromSubquery = i.invoice_number
             *  RIGHT JOIN (SELECT customers.id
             *                FROM dbo.customers
             *               WHERE dbo.customers.id > 0) parameterless ON parameterless.id = i.customer_id
             *   FULL JOIN dbo.invoice_lines l ON l.invoice_id = i.id
             *       WHERE i.invoice_number = @invoiceNumber
             *         AND EXISTS (SELECT i2.invoice_number AS InvoiceIdFromSubquery
             *                       FROM dbo.invoices i2
             *                      WHERE i2.invoice_number = i.invoice_number)
             *         AND EXISTS (SELECT customers.id
             *                       FROM dbo.customers
             *                      WHERE dbo.customers.id > 0)
             *    GROUP BY c.name, i.invoice_date
             *      HAVING SUM(l.price) > @limit
             *    ORDER BY c.name DESC
             */
            Query<ExampleParameters, int> parameterized =
                database
                    .Query<int>().WithParameters<ExampleParameters>()
                    .From(() => c)
                    .InnerJoin(() => i).On(() => i.CustomerId == c.Id)
                    .LeftJoin(() => subquery).On(x => x.InvoiceIdFromSubquery == i.Id)
                    .RightJoin(() => parameterless).On(x => x == i.CustomerId)
                    .OuterJoin(() => l).On(() => l.InvoiceId == i.Id)
                    .Where(p => i.InvoiceNumber == p.InvoiceNumber)
                    .Where(p => subquery.Exists())
                    .Where(p => parameterless.Exists())
                    .Select(() => c.Name)
                    .Select(() => i.InvoiceDate)
                    .Select(() => l.Price).As("total")
                    .OrderBy(() => c.Name).Descending
                    .GroupBy(() => c.Name)
                    .GroupBy(() => i.InvoiceDate)
                    .Where(p => l.Price.Sum() > p.Limit)
                    .Distinct()
                    .Limit(100)
                    .Compile();

            int parameterizedResult = await SomeConnection.ExecuteAsync(parameterized, new ExampleParameters
            {
                Limit = 100,
                InvoiceNumber = "2019"
            });

            /**
             *      SELECT c.name AS CustomerName, SUM(l.price) AS TotalAmount
             *        FROM dbo.customers c
             *  INNER JOIN dbo.invoices i ON i.customer_id = c.id
             *  INNER JOIN dbo.invoice_lines l ON l.invoice_id = i.id
             *       WHERE c.id > @limit
             *
             * UNION ALL
             *
             *      SELECT c.Name as CustomerName, 1 AS TotalAmount
             *        FROM dbo.customers c
             *
             * UNION
             *
             *      SELECT "dummy", 1
             *        FROM dbo.customers
             *
             * UNION
             *
             *      SELECT "other_dummy" AS CustomerName, id
             *        FROM dbo.customers
             */
            Query<ExampleParameters, UnionResult> unionQuery =
                database
                    .Query<UnionResult>().WithParameters<ExampleParameters>()
                    .From(() => c)
                    .InnerJoin(() => i).On(() => i.CustomerId == c.Id)
                    .InnerJoin(() => l).On(() => l.InvoiceId == i.Id)
                    .Select(() => c.Name).As(result => result.CustomerName)
                    .Select(() => l.Price.Sum()).As(result => result.TotalAmount)
                    .Where(p => c.Id > p.Limit)
                    .UnionAll(database.Query<UnionResult>()
                        .From(() => c)
                        .Select(() => c.Name).As(result => result.CustomerName)
                        .Select(() => 1).As(result => result.TotalAmount)
                    )
                    .Union(database.Query<UnionResult>()
                        .WithParameters<ExampleParameters>()
                        .From(() => c)
                        .Select(() => "dummy")
                        .Select(() => 1)
                    )
                    .Union(database.Query<UnionResult>()
                        .From(() => c)
                        .Select(() => "other_dummy").As(result => result.CustomerName)
                        .Select(() => c.Id)
                    )
                    .Compile();

            UnionResult unionResult = await SomeConnection.ExecuteAsync(unionQuery, p => p.Limit = 122);
        }
    }
}
