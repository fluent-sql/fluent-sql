using FluentAssertions;

using FluentSQL.Databases;
using FluentSQL.Querying;
using FluentSQL.Querying.Extensions;
using FluentSQL.Querying.Statements.Extensions;
using FluentSQL.Tests.Databases.Builders;
using FluentSQL.Tests.Examples;
using FluentSQL.Tests.Examples.Builders;

using Xunit;

namespace FluentSQL.Tests.Querying
{
    public class QueryComponentTests
    {
        public class When_compiling_a_query : Specification<QueryComponent<NoParameters, string>>
        {
            protected override QueryComponent<NoParameters, string> EstablishContext()
            {
                Database database = new DatabaseBuilder().Build();
                ExampleModel model = new ExampleModelBuilder().Build();

                QueryComponent<NoParameters, string> queryComponent =
                    database.Query<string>()
                        .From(() => model.Customers)
                        .Select(() => model.Customers.Name);

                return queryComponent;
            }

            protected override void Because(QueryComponent<NoParameters, string> sut)
            {
                Query = sut.Compile();
            }

            private Query<string> Query { get; set; }

            [Fact]
            public void It_should_create_the_query()
            {
                Query.Should().NotBeNull();
            }
        }
    }
}
