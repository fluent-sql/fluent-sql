using System;
using System.Threading.Tasks;

using WeelinkIT.FluentSQL.Databases;
using WeelinkIT.FluentSQL.Modelling;
using WeelinkIT.FluentSQL.Querying.Extensions;
using WeelinkIT.FluentSQL.Querying.Functions.Extensions;

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

        public class SubqueryResult
        {
            public int InvoiceIdFromSubquery { get; set; }
        }

        [Fact]
        public async Task TestApi()
        {
            var model = new ExampleModel(new SqlServerDatabase());

            {
                Query<int> parameterless =
                    model
                        .Query<int>()
                        .From(() => model.Customers)
                        .Where(() => model.Customers.Id > 0)
                        .Compile();

                int parameterlessResult = await parameterless.ExecuteAsync();
            }

            {
                Customers c = model.Customers;
                Invoices i = model.Invoices;
                InvoiceLines l = model.InvoiceLines;

                Invoices i2 = model.Invoices;

                Query<int> parameterless =
                    model
                        .Query<int>()
                        .From(() => model.Customers)
                        .Where(() => model.Customers.Id > 0)
                        .Select(() => model.Customers.Id)
                        .Compile();

                /*
                 *      select customers.name
                 *        from dbo.customers
                 *       where dbo.customers.id > 0
                 */

                Query<ExampleParameters, SubqueryResult> subquery =
                    model.Query<SubqueryResult>().WithParameters<ExampleParameters>()
                        .From(() => i2)
                        .Where(p => i2.InvoiceNumber == i.InvoiceNumber)
                        .Select(() => i2.InvoiceNumber).As(r => r.InvoiceIdFromSubquery)
                        .Compile();

                /*
                 *      select i2.invoice_number as InvoiceIdFromSubquery
                 *        from dbo.invoices i2
                 *       where i2.invoice_number = i.invoice_number
                 */

                Query<ExampleParameters, int> parameterized =
                    model.Query<int>().WithParameters<ExampleParameters>()
                        .From(() => c)
                        .InnerJoin(() => i).On(() => i.CustomerId == c.Id)
                        .LeftJoin(() => subquery).On(x => x.InvoiceIdFromSubquery == i.Id)
                        .LeftJoin(() => parameterless).On(x => x == i.CustomerId)
                        .LeftJoin(() => l).On(() => l.InvoiceId == i.Id)
                        .Where(p => i.InvoiceNumber == p.InvoiceNumber)
                        .Select(() => c.Name)
                        .Select(() => i.InvoiceDate)
                        .Select(() => l.Price.Sum()).As("total")
                        .OrderBy(() => c.Name).Descending
                        .GroupBy(() => c.Name)
                        .GroupBy(() => i.InvoiceDate)
                        .Compile();

                int parameterizedResult = await parameterized.ExecuteAsync(p =>
                {
                    p.Limit = 100;
                    p.InvoiceNumber = "2019";
                });

                /*
                 *      select c.name, i.invoice_date, sum(l.price) as total
                 *        from dbo.customers c
                 *  inner join dbo.invoices i on i.customer_id = c.id
                 *   left join (select i2.invoice_number as InvoiceIdFromSubquery
                 *                from dbo.invoices i2
                 *               where i2.invoice_number = i.invoice_number) subquery on subquery.invoice_number = i.invoice_number
                 *   left join (select customers.id
                 *                from dbo.customers
                 *               where dbo.customers.id > 0) parameterless on parameterless.id = i.customer_id
                 *   left join dbo.invoice_lines l on l.invoice_id = i.id
                 *       where i.invoice_number = @invoiceNumber
                 *    order by c.name desc
                 *    group by c.name, i.invoice_date
                 */
            }
        }
    }
}
