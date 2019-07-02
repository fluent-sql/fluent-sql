using FluentSQL.Modelling;

namespace FluentSQL.Tests.Examples
{
    public class Customers : Table
    {
        public Customers()
            : base("dbo", "customers")
        {
        }

        public readonly Column<int> Id = new Column<int>("id");
        public readonly Column<string> Name = new Column<string>("name");
    }
}
