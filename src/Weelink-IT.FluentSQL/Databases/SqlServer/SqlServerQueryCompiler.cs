using WeelinkIT.FluentSQL.Querying;

namespace WeelinkIT.FluentSQL.Databases.SqlServer
{
    /// <summary>
    ///     Compiles a <see cref="QueryContext{TParameters, TQueryResult}" /> to a
    ///     <see cref="Query{TParameters, TQueryResult}" /> for SQL Server.
    /// </summary>
    public class SqlServerQueryCompiler : QueryCompiler
    {
        /// <inheritdoc />
        public CompilationResult Compile<TParameters, TQueryResult>(QueryContext<TParameters, TQueryResult> context)
            where TParameters : new()
        {
            return default(CompilationResult);
        }
    }
}
