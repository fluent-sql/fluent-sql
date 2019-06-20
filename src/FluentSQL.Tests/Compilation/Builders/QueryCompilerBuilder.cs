using FluentSQL.Compilation;

namespace FluentSQL.Tests.Compilation.Builders
{
    public class QueryCompilerBuilder : TestDataBuilder<QueryCompiler>
    {
        protected override QueryCompiler OnBuild()
        {
            return new QueryCompilerStub();
        }

        private class QueryCompilerStub : QueryCompiler
        {
        }
    }
}
