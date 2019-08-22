using FluentAssertions;

using FluentSQL.Compilation.Parser;
using FluentSQL.Compilation.Parser.Nodes;
using FluentSQL.Databases;
using FluentSQL.Querying;
using FluentSQL.Querying.Statements.Extensions;
using FluentSQL.Tests.Compilation.Parser.Extensions;
using FluentSQL.Tests.Databases.Builders;
using FluentSQL.Tests.Examples;

using Xunit;

namespace FluentSQL.Tests.Compilation.Parser
{
    public class PropertyParserTests
    {
        public class When_parsing_a_property : Specification<QueryParser>
        {
            protected override QueryParser EstablishContext()
            {
                Database database = new DatabaseBuilder().Build();
                Customer customer = null;

                QueryContext =
                    database
                        .Query<string>()
                        .From(() => customer)
                        .Select(() => customer.Id)
                        .QueryContext;

                return new QueryParser();
            }

            protected override void Because(QueryParser sut)
            {
                Node = sut.Parse(QueryContext);
            }

            [Fact]
            public void It_should_have_a_select_node()
            {
                Node.Should().ContainSingle<SelectNode>();
            }

            [Fact]
            public void It_should_have_a_table_node()
            {
                Node.Should().ContainSingle<TableNode>().Which.Name.Should().Be(nameof(Customer));
            }

            [Fact]
            public void It_should_have_a_column_node()
            {
                Node.Should().ContainSingle<ColumnNode>().Which.Name.Should().Be(nameof(Customer.Id));
            }

            private QueryContext<NoParameters, string> QueryContext { get; set; }
            private AstNode Node { get; set; }
        }
    }
}
