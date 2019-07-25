using FluentSQL.Databases;
using FluentSQL.Tests.Databases.Builders;

namespace FluentSQL.Tests.Examples.Builders
{
    public class ExampleModelBuilder : TestDataBuilder<ExampleModel>
    {
        private Database Database { get; set; }

        protected override void OnPreBuild()
        {
            if (Database == null)
            {
                WithDatabase(new DatabaseBuilder().Build());
            }
        }

        protected override ExampleModel OnBuild()
        {
            return new ExampleModel(Database);
        }

        public ExampleModelBuilder WithDatabase(Database database)
        {
            Database = database;
            return this;
        }
    }
}
