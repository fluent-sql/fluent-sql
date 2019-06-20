using System.Data;
using System.Threading.Tasks;

using FluentSQL.Databases.SqlServer;
using FluentSQL.Extensions;
using FluentSQL.Querying.Extensions;
using FluentSQL.Querying.Functions.Extensions;
using FluentSQL.Querying.Statements.Extensions;
using FluentSQL.Tests.Examples;

using Xunit;

namespace FluentSQL.Tests.Api
{
    public sealed class ApiDesign
    {
        public class ExampleParameters
        {
            public int Limit { get; set; }
            public string InvoiceNumber { get; set; }
        }
        
        public class UnionResult
        {
            public string CustomerName { get; set; }
            public int TotalAmount { get; set; }
        }

        public class SubqueryResult
        {
            public int InvoiceIdFromSubquery { get; set; }
        }

        private IDbConnection SomeConnection { get; }

        [Fact]
        public async Task TestApi()
        {
            var model = new ExampleModel(new SqlServerDatabase());
            Customers c = model.Customers;
            Invoices i = model.Invoices;
            InvoiceLines l = model.InvoiceLines;

            Invoices i2 = model.Invoices;

            /*
             * SELECT customers.name
             *   FROM dbo.customers
             *  WHERE dbo.customers.id > 0
             */
            Query<int> parameterless =
                model
                    .Query<int>()
                    .From(() => model.Customers)
                    .Where(() => model.Customers.Id > 0)
                    .Select(() => model.Customers.Name)
                    .Compile();

            int parameterlessResult = await SomeConnection.ExecuteAsync(parameterless);

            /*
             * SELECT i2.invoice_number AS InvoiceIdFromSubquery
             *   FROM dbo.invoices i2
             *  WHERE i2.invoice_number = i.invoice_number
             */
            Query<ExampleParameters, SubqueryResult> subquery =
                model.Query<SubqueryResult>().WithParameters<ExampleParameters>()
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
                model.Query<int>().WithParameters<ExampleParameters>()
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
                    .Select(() => l.Price.Sum()).As("total")
                    .OrderBy(() => c.Name).Descending
                    .GroupBy(() => c.Name)
                    .GroupBy(() => i.InvoiceDate)
                    .Where(p => l.Price.Sum() > p.Limit)
                    .Distinct()
                    .Limit(100)
                    .Compile();

            int parameterizedResult = await SomeConnection.ExecuteAsync(parameterized, p =>
            {
                p.Limit = 100;
                p.InvoiceNumber = "2019";
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
             *      SELECT "other_dummy", id
             *        FROM dbo.customers
             */
            Query<ExampleParameters, UnionResult> unionQuery =
                model.Query<UnionResult>().WithParameters<ExampleParameters>()
                    .From(() => c)
                    .InnerJoin(() => i).On(() => i.CustomerId == c.Id)
                    .InnerJoin(() => l).On(() => l.InvoiceId == i.Id)
                    .Select(() => c.Name).As(result => result.CustomerName)
                    .Select(() => l.Price.Sum()).As(result => result.TotalAmount)
                    .Where(p => c.Id > p.Limit)
                    .UnionAll(
                        model.Query<UnionResult>()
                            .From(() => c)
                            .Select(() => c.Name).As(result => result.CustomerName)
                            .Select(() => 1).As(result => result.TotalAmount)
                            .Union(
                                model.Query<UnionResult>()
                                    .WithParameters<ExampleParameters>()
                                    .From(() => model.Customers)
                                    .Select(() => "dummy")
                                    .Select(() => 1)
                                    .Union(
                                        model.Query<UnionResult>()
                                            .From(() => model.Customers)
                                            .Select(() => "other_dummy")
                                            .Select(() => model.Customers.Id))))
                    .Compile();

            UnionResult unionResult = await SomeConnection.ExecuteAsync(unionQuery, p =>
            {
                p.Limit = 122;
            });
        }
    }
}
