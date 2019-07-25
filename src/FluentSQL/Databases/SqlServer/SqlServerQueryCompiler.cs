using FluentSQL.Compilation;
using FluentSQL.Compilation.Parser.Nodes;
using FluentSQL.Querying;

namespace FluentSQL.Databases.SqlServer
{
    /// <summary>
    ///     Compiles a <see cref="QueryContext{TParameters,TQueryResult}" /> to a query for SQL Server.
    /// </summary>
    public sealed class SqlServerQueryCompiler : QueryCompiler
    {
        public override CompilationResult Compile(AstNode node)
        {
            return new CompilationResult("");
        }
    }
}
