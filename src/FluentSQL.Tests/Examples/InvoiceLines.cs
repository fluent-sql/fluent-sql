using System;

using FluentSQL.Modelling;

namespace FluentSQL.Tests.Examples
{
    public class InvoiceLines : Table
    {
        public readonly Column<Guid> Id = new Column<Guid>("id");
        public readonly Column<int> InvoiceId = new Column<int>("invoice_id");
        public readonly Column<decimal> Price = new Column<decimal>("price");

        public InvoiceLines()
            : base("dbo", "invoice_lines")
        {
        }
    }
}
