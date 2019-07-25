using System;

namespace FluentSQL.Tests.Examples
{
    public class InvoiceLine
    {
        public Guid Id { get; set; }
        public int InvoiceId { get; set; }
        public decimal Price { get; set; }
    }
}
