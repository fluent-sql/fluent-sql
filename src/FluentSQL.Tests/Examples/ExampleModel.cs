using FluentSQL.Databases;
using FluentSQL.Modelling;

namespace FluentSQL.Tests.Examples
{
    public class ExampleModel : PersistenceModel
    {
        public readonly Customers Customers = new Customers();
        public readonly InvoiceLines InvoiceLines = new InvoiceLines();

        public readonly Invoices Invoices = new Invoices();

        public ExampleModel(Database database)
            : base(database)
        {
        }
    }
}
