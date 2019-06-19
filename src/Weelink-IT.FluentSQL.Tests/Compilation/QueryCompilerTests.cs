using FluentAssertions;

using WeelinkIT.FluentSQL.Compilation;
using WeelinkIT.FluentSQL.Databases;
using WeelinkIT.FluentSQL.Querying;
using WeelinkIT.FluentSQL.Querying.Extensions;
using WeelinkIT.FluentSQL.Querying.Statements.Extensions;
using WeelinkIT.FluentSQL.Tests.Compilation.Builders;
using WeelinkIT.FluentSQL.Tests.Databases.Builders;
using WeelinkIT.FluentSQL.Tests.Examples;

using Xunit;

namespace WeelinkIT.FluentSQL.Tests.Compilation
{
    public class QueryCompilerTests
    {
        public class When_compiling_a_query : Specification<QueryCompiler>
        {
            protected override QueryCompiler EstablishContext()
            {
                QueryCompiler compiler = new QueryCompilerBuilder().Build();

                Database database = new DatabaseBuilder().Using(compiler).Build();

                var model = new ExampleModel(database);
                QueryComponent = model.Query<string>()
                    .From(() => model.Customers)
                    .Select(() => model.Customers.Name);

                return compiler;
            }

            protected override void Because(QueryCompiler sut)
            {
                Query = QueryComponent.Compile();
            }

            [Fact]
            public void It_should_create_the_query()
            {
                Query.Should().NotBeNull();
            }

            private Query<string> Query { get; set; }
            private QueryComponent<NoParameters, string> QueryComponent { get; set; }
        }
    }
}
