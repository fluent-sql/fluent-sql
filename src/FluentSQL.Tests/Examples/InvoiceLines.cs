using System;

using FluentSQL.Modelling;

namespace FluentSQL.Tests.Examples
{
    public class InvoiceLines : Table
    {
        public InvoiceLines()
            : base("dbo", "invoice_lines")
        {
        }

        public readonly Column<Guid> Id = new Column<Guid>("id");
        public readonly Column<decimal> Price = new Column<decimal>("price");
        public readonly Column<int> InvoiceId = new Column<int>("invoice_id");
    }
}
