using System;

using FluentSQL.Modelling;

namespace FluentSQL.Tests.Examples
{
    public class InvoiceLines : Table
    {
        public readonly Column<Guid> Id = new Column<Guid>();
        public readonly Column<decimal> Price = new Column<decimal>();
        public readonly Column<int> InvoiceId = new Column<int>();
    }
}
