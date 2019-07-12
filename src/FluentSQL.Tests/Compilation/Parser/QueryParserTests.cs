using System;
using System.Linq;

using FluentAssertions;

using FluentSQL.Compilation.Parser;
using FluentSQL.Querying;
using FluentSQL.Querying.Statements.Extensions;
using FluentSQL.Tests.Compilation.Parser.Builders;
using FluentSQL.Tests.Compilation.Parser.Extensions;
using FluentSQL.Tests.Examples;
using FluentSQL.Tests.Examples.Builders;

using Xunit;

namespace FluentSQL.Tests.Compilation.Parser
{
    public class QueryParserTests
    {
        public class When_parsing_an_empty_query : Specification<QueryParser>
        {
            protected override QueryParser EstablishContext()
            {
                ExampleModel model = new ExampleModelBuilder().Build();
                QueryContext = model.Query<string>();

                return new QueryParserBuilder().Build();
            }

            protected override void Because(QueryParser sut)
            {
                RootNode = sut.Parse(QueryContext);
            }

            [Fact]
            public void It_should_create_an_empty_node()
            {
                RootNode.Should().BeEmpty();
            }

            private AstNode RootNode { get; set; }
            private QueryContext<NoParameters, string> QueryContext { get; set; }
        }

        public class When_parsing_a_from_statement_without_an_alias : Specification<QueryParser>
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

            private AstNode RootNode { get; set; }
            private QueryContext<NoParameters, string> QueryContext { get; set; }
        }

        public class When_parsing_a_from_statement_with_an_alias : Specification<QueryParser>
        {
            protected override QueryParser EstablishContext()
            {
                Alias = Guid.NewGuid().ToString();
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

            private AstNode RootNode { get; set; }

            private string Alias { get; set; }
            private QueryContext<NoParameters, string> QueryContext { get; set; }
        }
    }
}
