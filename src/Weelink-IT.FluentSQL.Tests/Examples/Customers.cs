using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Tests.Examples
{
    public class Customers : Table
    {
        public readonly Column<int> Id = new Column<int>();
        public readonly Column<string> Name = new Column<string>();
    }
}
