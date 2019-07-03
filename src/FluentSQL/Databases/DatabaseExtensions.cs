using FluentSQL.Compilation;
using FluentSQL.Querying;

namespace FluentSQL.Databases
{
    public static class DatabaseExtensions
    {
        /// <summary>
        ///     Compile <paramref name="queryContext" /> into a query.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this query.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <param name="database">The database instance that contains the compiler.</param>
        /// <param name="queryContext">The <see cref="QueryContext{TParameters,TQueryResult}" /> to compile.</param>
        /// <returns>A compiled query.</returns>
        public static  Query<TParameters, TQueryResult> Compile<TParameters, TQueryResult>(
            this Database database,
            QueryContext<TParameters, TQueryResult> queryContext)
            where TParameters : new()
        {
            CompilationResult result = database.CompileInternal(queryContext);
            return new Query<TParameters, TQueryResult>(result);
        }

        /// <summary>
        ///     Compile <paramref name="queryContext" /> into a query.
        /// </summary>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <param name="database">The database instance that contains the compiler.</param>
        /// <param name="queryContext">The <see cref="QueryContext{TParameters, TQueryResult}" /> to compile.</param>
        /// <returns>A compiled query.</returns>
        public static Query<TQueryResult> Compile<TQueryResult>(
            this Database database,
            QueryContext<NoParameters, TQueryResult> queryContext)
        {
            var contextWithoutParameters = new QueryContext<NoParameters, TQueryResult>(queryContext);

            CompilationResult result = database.CompileInternal(queryContext);
            return new Query<TQueryResult>(result);
        }
    }
}
