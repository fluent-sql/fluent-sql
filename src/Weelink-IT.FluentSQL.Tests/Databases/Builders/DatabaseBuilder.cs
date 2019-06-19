using WeelinkIT.FluentSQL.Compilation;
using WeelinkIT.FluentSQL.Databases;
using WeelinkIT.FluentSQL.Tests.Compilation.Builders;

namespace WeelinkIT.FluentSQL.Tests.Databases.Builders
{
    public class DatabaseBuilder : TestDataBuilder<Database>
    {
        protected override void OnPreBuild()
        {
            if (QueryCompiler == null)
            {
                Using(new QueryCompilerBuilder().Build());
            }
        }

        protected override Database OnBuild()
        {
            return new DatabaseStub(this);
        }

        public DatabaseBuilder Using(QueryCompiler queryCompiler)
        {
            QueryCompiler = queryCompiler;
            return this;
        }

        private QueryCompiler QueryCompiler { get; set; }

        private class DatabaseStub : Database
        {
            public DatabaseStub(DatabaseBuilder builder)
                : base(builder.QueryCompiler)
            {
            }
        }
    }
}
