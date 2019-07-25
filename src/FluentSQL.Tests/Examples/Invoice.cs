using System;

namespace FluentSQL.Tests.Examples
{
    public class Invoice
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTimeOffset InvoiceDate { get; set; }
        public string InvoiceNumber { get; set; }
    }
}
