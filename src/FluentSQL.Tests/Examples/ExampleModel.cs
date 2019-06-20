using FluentSQL.Databases;
using FluentSQL.Modelling;

namespace FluentSQL.Tests.Examples
{
    public class ExampleModel : PersistenceModel
    {
        public ExampleModel(Database database)
            : base(database)
        {
        }

        public readonly Invoices Invoices = new Invoices();
        public readonly InvoiceLines InvoiceLines = new InvoiceLines();
        public readonly Customers Customers = new Customers();
    }
}
