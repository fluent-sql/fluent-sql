using System.Linq;

using FluentAssertions;

using FluentSQL.Compilation.Parser;
using FluentSQL.Compilation.Parser.Nodes;
using FluentSQL.Databases;
using FluentSQL.Querying;
using FluentSQL.Querying.Statements.Extensions;
using FluentSQL.Tests.Builders;
using FluentSQL.Tests.Compilation.Parser.Builders;
using FluentSQL.Tests.Compilation.Parser.Extensions;
using FluentSQL.Tests.Databases.Builders;
using FluentSQL.Tests.Examples;

using Xunit;

namespace FluentSQL.Tests.Compilation.Parser
{
    public class FromQueryParserTests
    {
        public class When_parsing_without_an_alias : Specification<QueryParser>
        {
            protected override QueryParser EstablishContext()
            {
                Database database = new DatabaseBuilder().Build();
                var customer = new Customer();

                QueryContext =
                    database.Query<string>()
                        .From(() => customer)
                        .QueryContext;

                return new QueryParserBuilder().Build();
            }

            protected override void Because(QueryParser sut)
            {
                RootNode = sut.Parse(QueryContext);
            }

            private AstNode RootNode { get; set; }
            private QueryContext<NoParameters, string> QueryContext { get; set; }

            [Fact]
            public void It_should_add_the_from_clause()
            {
                RootNode.ChildNodes.OfType<FromNode>().Should().ContainSingle();
            }

            [Fact]
            public void It_should_have_no_alias()
            {
                RootNode.ChildNodes.OfType<FromNode>().Single().Should().NotHaveAnAlias();
            }
        }

        public class When_parsing_with_an_alias : Specification<QueryParser>
        {
            protected override QueryParser EstablishContext()
            {
                Database database = new DatabaseBuilder().Build();
                var customer = new Customer();
                
                Alias = new RandomStringBuilder().ThatStartsWithLetter.Build();

                QueryContext =
                    database.Query<string>()
                        .From(() => customer).As(Alias)
                        .QueryContext;

                return new QueryParserBuilder().Build();
            }

            protected override void Because(QueryParser sut)
            {
                RootNode = sut.Parse(QueryContext);
            }

            private AstNode RootNode { get; set; }

            private string Alias { get; set; }
            private QueryContext<NoParameters, string> QueryContext { get; set; }

            [Fact]
            public void It_should_add_the_from_clause()
            {
                RootNode.ChildNodes.OfType<FromNode>().Should().ContainSingle();
            }

            [Fact]
            public void It_should_have_the_alias()
            {
                RootNode.ChildNodes.OfType<FromNode>().Single().Should().HaveAlias(Alias);
            }
        }
    }
}
