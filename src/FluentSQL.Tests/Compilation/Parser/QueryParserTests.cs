using FluentSQL.Compilation.Parser;
using FluentSQL.Compilation.Parser.Nodes;
using FluentSQL.Databases;
using FluentSQL.Querying;
using FluentSQL.Tests.Compilation.Parser.Builders;
using FluentSQL.Tests.Compilation.Parser.Extensions;
using FluentSQL.Tests.Databases.Builders;

using Xunit;

namespace FluentSQL.Tests.Compilation.Parser
{
    public class QueryParserTests
    {
        public class When_parsing_an_empty_query : Specification<QueryParser>
        {
            protected override QueryParser EstablishContext()
            {
                Database database = new DatabaseBuilder().Build();
                QueryContext = database.Query<string>();

                return new QueryParserBuilder().Build();
            }

            protected override void Because(QueryParser sut)
            {
                RootNode = sut.Parse(QueryContext);
            }

            private AstNode RootNode { get; set; }
            private QueryContext<NoParameters, string> QueryContext { get; set; }

            [Fact]
            public void It_should_create_an_empty_node()
            {
                RootNode.Should().BeEmpty();
            }
        }
    }
}
