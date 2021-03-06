﻿using FluentAssertions;

using FluentSQL.Compilation.Parser;
using FluentSQL.Compilation.Parser.Nodes;
using FluentSQL.Databases;
using FluentSQL.Querying;
using FluentSQL.Querying.Statements.Extensions;
using FluentSQL.Tests.Builders;
using FluentSQL.Tests.Compilation.Parser.Extensions;
using FluentSQL.Tests.Databases.Builders;
using FluentSQL.Tests.Examples;

using Xunit;

namespace FluentSQL.Tests.Compilation.Parser
{
    public class UnionQueryParserTests
    {
        public class When_parsing : Specification<QueryParser>
        {
            protected override QueryParser EstablishContext()
            {
                Database database = new DatabaseBuilder().Build();
                var customer = new Customer();
                var invoice = new Invoice();

                FirstAlias = new RandomStringBuilder().ThatStartsWithLetter.Build();
                SecondAlias = new RandomStringBuilder().ThatStartsWithLetter.Build();

                QueryComponent<NoParameters, string> first =
                    database.Query<string>()
                        .From(() => customer).As(FirstAlias)
                        .Select(() => customer.Name);

                QueryComponent<NoParameters, string> second =
                    database.Query<string>()
                        .From(() => invoice).As(SecondAlias)
                        .Select(() => invoice.InvoiceNumber);

                QueryContext = first.Union(second).QueryContext;

                return new QueryParser();
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
                RootNode.Should().Contain<FromNode>().Which.Should().ContainSingle(x => x.Alias == FirstAlias);
                RootNode.Should().Contain<FromNode>().Which.Should().ContainSingle(x => x.Alias == SecondAlias);
            }

            [Fact]
            public void It_should_return_an_union_node()
            {
                RootNode.Should().BeOfType<UnionNode>();
            }
        }
    }
}
