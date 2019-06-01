using System;
using FluentAssertions;
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
        }

        [Fact]
        public void TestApi()
        {
            var query2 =
                new ExampleModel(new SqlServerDatabase())
                    .Query<int>()
                    .From(m => m.Customers)
                    .Where(x => x.Id > 0)
                    .Compile();

            var query =
               new ExampleModel(new SqlServerDatabase())
                   .Query<int>().WithParameters<ExampleParameters>()
                   .From(m => m.Customers)
                   .Where((c, p) => string.IsNullOrEmpty(c.Name))
                   .Select(c => c.Name)
                   .Select(c => c.Id.Sum())
                   .GroupBy(c => c.Id)
                   .Having((c, p) => string.IsNullOrEmpty(c.Name))
                   .Having((c, p) => c.Id.Sum() > p.Limit)
                   .InnerJoin(m => m.Invoices).On((i, c) => i.CustomerId == c.Id)
                   .Select(i => i.InvoiceDate)
                   .Select(i => i.InvoiceNumber)
                   .Where((i, p) => i.InvoiceDate > DateTimeOffset.MaxValue)
                   .OrderBy(i => i.InvoiceNumber).Ascending
                   .InnerJoin(m => m.InvoiceLines).On((l, i) => l.InvoiceId == i.Id)
                   .Select(l => l.Price)
                   .OrderBy(l => l.Price).Descending
                   .Where((l, p) => l.Price > p.Limit)
                   .Compile();

            /*
             *      select c.name, i.invoice_date, i.invoice_number, l.price
             *        from dbo.customers
             *  inner join dbo.invoices i on i.customer_id = c.id
             *  inner join dbo.invoice_lines l on l.invoice_id = i.id
             *       where i.invoice_date > @p0
             *         and l.price > 100
             *    order by i.invoice_number asc, l.price desc
             */
        }
    }
}
