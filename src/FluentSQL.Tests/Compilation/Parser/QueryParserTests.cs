using FluentAssertions;

using FluentSQL.Compilation.Parser;
using FluentSQL.Querying;
using FluentSQL.Querying.Statements.Extensions;
using FluentSQL.Tests.Compilation.Parser.Builders;
using FluentSQL.Tests.Examples;
using FluentSQL.Tests.Examples.Builders;

using Xunit;

namespace FluentSQL.Tests.Compilation.Parser
{
    public class QueryParserTests
    {
        public class When_parsing_a_simple_query : Specification<QueryParser>
        {
            protected override QueryParser EstablishContext()
            {
                ExampleModel model = new ExampleModelBuilder().Build();
                QueryContext =
                    model.Query<string>()
                        .From(() => model.Customers)
                        .Select(() => model.Customers.Name)
                        .QueryContext;

                return new QueryParserBuilder().Build();
            }

            protected override void Because(QueryParser sut)
            {
                RootNode = sut.Parse(QueryContext);
            }

            [Fact]
            public void It_should_do_it()
            {
                RootNode.Should().NotBeNull();
            }

            private AstNode RootNode { get; set; }
            private QueryContext<NoParameters, string> QueryContext { get; set; }
        }
    }
}
