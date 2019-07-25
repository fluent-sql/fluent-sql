using FluentSQL.Compilation;
using FluentSQL.Databases;
using FluentSQL.Tests.Compilation.Builders;

namespace FluentSQL.Tests.Databases.Builders
{
    public class DatabaseBuilder : TestDataBuilder<Database>
    {
        private QueryCompiler QueryCompiler { get; set; }

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

        private class DatabaseStub : Database
        {
            public DatabaseStub(DatabaseBuilder builder)
                : base(builder.QueryCompiler)
            {
            }
        }
    }
}
