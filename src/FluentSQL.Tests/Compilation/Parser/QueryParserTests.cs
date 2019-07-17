using System.Linq;

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

            [Fact]
            public void It_should_have_no_alias()
            {
                RootNode.ChildNodes.OfType<FromNode>().Single().Alias.Should().BeNull();
            }

            private AstNode RootNode { get; set; }
            private QueryContext<NoParameters, string> QueryContext { get; set; }
        }

        public class When_parsing_a_from_statement_with_an_alias : Specification<QueryParser>
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
        
        public class When_parsing_an_union : Specification<QueryParser>
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

                QueryComponent<NoParameters, string>  second =
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
            
            [Fact]
            public void It_should_return_an_union_node()
            {
                RootNode.Should().BeOfType<UnionNode>();
            }
            
            [Fact]
            public void It_should_contain_both_queries()
            {
                RootNode.As<UnionNode>().First.ChildNodes.OfType<FromNode>().Single().Alias.Should().Be(FirstAlias);
                RootNode.As<UnionNode>().Second.ChildNodes.OfType<FromNode>().Single().Alias.Should().Be(SecondAlias);
            }

            private AstNode RootNode { get; set; }
            private string FirstAlias { get; set; }
            private string SecondAlias { get; set; }
            private QueryContext<NoParameters, string> QueryContext { get; set; }
        }
        
        public class When_parsing_an_union_all : Specification<QueryParser>
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

                QueryComponent<NoParameters, string>  second =
                    model.Query<string>()
                        .From(() => model.Invoices).As(SecondAlias)
                        .Select(() => model.Invoices.InvoiceNumber);

                QueryContext = first.UnionAll(second).QueryContext;

                return new QueryParserBuilder().Build();
            }

            protected override void Because(QueryParser sut)
            {
                RootNode = sut.Parse(QueryContext);
            }
            
            [Fact]
            public void It_should_return_an_union_node()
            {
                RootNode.Should().BeOfType<UnionAllNode>();
            }
            
            [Fact]
            public void It_should_contain_both_queries()
            {
                RootNode.As<UnionAllNode>().First.ChildNodes.OfType<FromNode>().Single().Alias.Should().Be(FirstAlias);
                RootNode.As<UnionAllNode>().Second.ChildNodes.OfType<FromNode>().Single().Alias.Should().Be(SecondAlias);
            }

            private AstNode RootNode { get; set; }
            private string FirstAlias { get; set; }
            private string SecondAlias { get; set; }
            private QueryContext<NoParameters, string> QueryContext { get; set; }
        }
    }
}
