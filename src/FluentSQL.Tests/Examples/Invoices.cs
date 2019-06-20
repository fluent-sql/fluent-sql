using System;

using FluentSQL.Modelling;

namespace FluentSQL.Tests.Examples
{
    public class Invoices : Table
    {
        public readonly Column<int> Id = new Column<int>();
        public readonly Column<string> InvoiceNumber = new Column<string>();
        public readonly Column<DateTimeOffset> InvoiceDate = new Column<DateTimeOffset>();
        public readonly Column<int> CustomerId = new Column<int>();
    }
}
