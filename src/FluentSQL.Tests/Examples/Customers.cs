using FluentSQL.Modelling;

namespace FluentSQL.Tests.Examples
{
    public class Customers : Table
    {
        public readonly Column<int> Id = new Column<int>();
        public readonly Column<string> Name = new Column<string>();
    }
}
