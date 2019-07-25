using FluentAssertions;

using FluentSQL.Compilation.Parser;
using FluentSQL.Querying;
using FluentSQL.Querying.Statements.Extensions;
using FluentSQL.Tests.Builders;
using FluentSQL.Tests.Compilation.Parser.Builders;
using FluentSQL.Tests.Compilation.Parser.Extensions;
using FluentSQL.Tests.Examples;
using FluentSQL.Tests.Examples.Builders;

using Xunit;

namespace FluentSQL.Tests.Compilation.Parser
{
    public class UnionQueryParserTests
    {
        public class When_parsing : Specification<QueryParser>
        {
            protected override QueryParser EstablishContext()
            {
                ExampleModel model = new ExampleModelBuilder().Build();

                FirstAlias = new RandomStringBuilder().ThatStartsWithLetter.Build();
                SecondAlias = new RandomStringBuilder().ThatStartsWithLetter.Build();

                QueryComponent<NoParameters, string> first =
                    model.Query<string>()
                        .From(() => model.Customers).As(FirstAlias)
                        .Select(() => model.Customers.Name);

                QueryComponent<NoParameters, string> second =
                    model.Query<string>()
                        .From(() => model.Invoices).As(SecondAlias)
                        .Select(() => model.Invoices.InvoiceNumber);

                QueryContext = first.Union(second).QueryContext;

                return new QueryParserBuilder().Build();
            }

            protected override void Because(QueryParser sut)
            {
                RootNode = sut.Parse(QueryContext);
            }

            private AstNode RootNode { get; set; }
            private string FirstAlias { get; set; }
            private string SecondAlias { get; set; }
            private QueryContext<NoParameters, string> QueryContext { get; set; }

            [Fact]
            public void It_should_contain_both_queries()
            {
                RootNode.As<UnionNode>().First.Should().Contain<FromNode>().Which.Should().HaveAlias(FirstAlias);
                RootNode.As<UnionNode>().Second.Should().Contain<FromNode>().Which.Should().HaveAlias(SecondAlias);
            }

            [Fact]
            public void It_should_return_an_union_node()
            {
                RootNode.Should().BeOfType<UnionNode>();
            }
        }
    }
}
