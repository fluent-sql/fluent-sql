using FluentSQL.Compilation.Parser;

namespace FluentSQL.Tests.Compilation.Parser.Builders
{
    public class QueryParserBuilder : TestDataBuilder<QueryParser>
    {
        protected override QueryParser OnBuild()
        {
            return new QueryParser();
        }
    }
}
