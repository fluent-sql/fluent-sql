using System;

using FluentSQL.Modelling;

namespace FluentSQL.Tests.Examples
{
    public class Invoices : Table
    {
        public Invoices()
            : base("dbo", "invoices")
        {
        }

        public readonly Column<int> Id = new Column<int>("id");
        public readonly Column<string> InvoiceNumber = new Column<string>("invoice_number");
        public readonly Column<DateTimeOffset> InvoiceDate = new Column<DateTimeOffset>("invoice_date");
        public readonly Column<int> CustomerId = new Column<int>("customer_id");
    }
}
