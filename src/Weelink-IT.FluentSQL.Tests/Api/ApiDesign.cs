using System;
using System.Threading.Tasks;

using WeelinkIT.FluentSQL.Databases;
using WeelinkIT.FluentSQL.Modelling;
using WeelinkIT.FluentSQL.Querying.Extensions;
using WeelinkIT.FluentSQL.Querying.Functions.Extensions;
using WeelinkIT.FluentSQL.Querying.Statements.Extensions;

using Xunit;

namespace WeelinkIT.FluentSQL.Tests.Api
{
    public class Invoices : Table
    {
        public readonly Column<int> Id = new Column<int>();
        public readonly Column<string> InvoiceNumber = new Column<string>();
        public readonly Column<DateTimeOffset> InvoiceDate = new Column<DateTimeOffset>();
        public readonly Column<int> CustomerId = new Column<int>();
    }

    public class InvoiceLines : Table
    {
        public readonly Column<Guid> Id = new Column<Guid>();
        public readonly Column<decimal> Price = new Column<decimal>();
        public readonly Column<int> InvoiceId = new Column<int>();
    }

    public class Customers : Table
    {
        public readonly Column<int> Id = new Column<int>();
        public readonly Column<string> Name = new Column<string>();
    }

    public class ExampleModel : PersistenceModel<ExampleModel>
    {
        public ExampleModel(Database database)
            : base(database)
        {
        }

        public readonly Invoices Invoices = new Invoices();
        public readonly InvoiceLines InvoiceLines = new InvoiceLines();
        public readonly Customers Customers = new Customers();
    }

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

            int parameterizedResult = await parameterized.ExecuteAsync(p =>
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

            UnionResult unionResult = await unionQuery.ExecuteAsync(p =>
            {
                p.Limit = 122;
            });
        }
    }
}
