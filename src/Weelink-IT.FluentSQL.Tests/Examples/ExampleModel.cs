using WeelinkIT.FluentSQL.Databases;
using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Tests.Examples
{
    public class ExampleModel : PersistenceModel<ExampleModel>
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
