using System.Linq;

using FluentAssertions;

using FluentSQL.Compilation.Parser;
using FluentSQL.Querying;
using FluentSQL.Querying.Statements.Extensions;
using FluentSQL.Tests.Builders;
using FluentSQL.Tests.Compilation.Parser.Builders;
using FluentSQL.Tests.Examples;
using FluentSQL.Tests.Examples.Builders;

using Xunit;

namespace FluentSQL.Tests.Compilation.Parser
{
    public class FromQueryParserTests
    {
        public class When_parsing_without_an_alias : Specification<QueryParser>
        {
            protected override QueryParser EstablishContext()
            {
                ExampleModel model = new ExampleModelBuilder().Build();

                QueryContext =
                    model.Query<string>()
                        .From(() => model.Customers)
                        .QueryContext;

                return new QueryParserBuilder().Build();
            }

            protected override void Because(QueryParser sut)
            {
                RootNode = sut.Parse(QueryContext);
            }

            [Fact]
            public void It_should_add_the_from_clause()
            {
                RootNode.ChildNodes.OfType<FromNode>().Should().ContainSingle();
            }

            [Fact]
            public void It_should_have_no_alias()
            {
                RootNode.ChildNodes.OfType<FromNode>().Single().Alias.Should().BeNull();
            }

            private AstNode RootNode { get; set; }
            private QueryContext<NoParameters, string> QueryContext { get; set; }
        }

        public class When_parsing_with_an_alias : Specification<QueryParser>
        {
            protected override QueryParser EstablishContext()
            {
                Alias = new RandomStringBuilder().ThatStartsWithLetter.Build();
                ExampleModel model = new ExampleModelBuilder().Build();

                QueryContext =
                    model.Query<string>()
                        .From(() => model.Customers).As(Alias)
                        .QueryContext;

                return new QueryParserBuilder().Build();
            }

            protected override void Because(QueryParser sut)
            {
                RootNode = sut.Parse(QueryContext);
            }

            [Fact]
            public void It_should_add_the_from_clause()
            {
                RootNode.ChildNodes.OfType<FromNode>().Should().ContainSingle();
            }
            
            [Fact]
            public void It_should_have_the_alias()
            {
                RootNode.ChildNodes.OfType<FromNode>().Single().Alias.Should().Be(Alias);
            }

            private AstNode RootNode { get; set; }

            private string Alias { get; set; }
            private QueryContext<NoParameters, string> QueryContext { get; set; }
        }
    }
}