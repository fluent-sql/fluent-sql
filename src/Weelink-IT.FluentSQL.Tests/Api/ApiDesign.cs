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
            public int InvoiceId { get; set; }
        }

        [Fact]
        public async Task TestApi()
        {
            var model = new ExampleModel(new SqlServerDatabase());

            Query<int> parameterless =
                model
                    .Query<int>()
                    .From(m => m.Customers)
                    .Where(x => x.Id > 0)
                    .Compile();

            int parameterlessResult = await parameterless.ExecuteAsync();

            Query<ExampleParameters, SubqueryResult> subquery =
                model.Query<SubqueryResult>().WithParameters<ExampleParameters>()
                    .From(m => m.Invoices)
                    .Select(i => i.Id)
                    .Where((i, p) => i.InvoiceNumber.ToType().StartsWith(p.InvoiceNumber))
                    .Compile();

            Query<ExampleParameters, int> parameterized =
               model
                   .Query<int>().WithParameters<ExampleParameters>()
                   .From(m => m.Customers).As("c")
                   .Where((c, p) => string.IsNullOrEmpty(c.Name))
                   .Select(c => c.Name).GroupBy()
                   .InnerJoin(m => m.Invoices).As("i").On((i, c) => i.CustomerId == c.Id)
                   .Select(i => i.InvoiceDate).GroupBy()
                   .Select(i => i.InvoiceNumber).GroupBy()
                   .Where((i, p) => i.InvoiceDate > DateTimeOffset.MaxValue)
                   .OrderBy(i => i.InvoiceNumber).Ascending
                   .InnerJoin(m => m.InvoiceLines).On((l, i) => l.InvoiceId == i.Id)
                   .Select(c => c.Price.Sum()).As("total")
                   .OrderBy(l => l.Price).Descending
                   .Having((l, p) => l.Price.Sum() > p.Limit)
                   .Compile();

            int parameterizedResult = await parameterized.ExecuteAsync(p =>
            {
                p.Limit = 100;
                p.InvoiceNumber = "2019";
            });

            /*
             *      select c.name, i.invoice_date, i.invoice_number, sum(l.price) as total
             *        from dbo.customers c
             *  inner join dbo.invoices i on i.customer_id = c.id
             *  inner join dbo.invoice_lines l on l.invoice_id = i.id
             *       where (c.name IS NOT NULL or c.name <> '')
             *             i.invoice_date > @p0
             *    order by i.invoice_number asc, l.price desc
             *    group by c.Name, i.invoice_date, i.invoice_number
             *      having sum(l.Id) > @p1
             */
        }
    }
}
