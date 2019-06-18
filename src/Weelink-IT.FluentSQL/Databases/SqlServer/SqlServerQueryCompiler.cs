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
        public Query<TQueryResult> Compile<TQueryResult>(QueryContext<NoParameters, TQueryResult> context)
        {
            return default(Query<TQueryResult>);
        }

        /// <inheritdoc />
        public Query<TParameters, TQueryResult> Compile<TParameters, TQueryResult>(QueryContext<TParameters, TQueryResult> context)
            where TParameters : new()
        {
            return default(Query<TParameters, TQueryResult>);
        }
    }
}
