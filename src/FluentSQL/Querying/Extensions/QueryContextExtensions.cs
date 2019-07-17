namespace FluentSQL.Querying.Extensions
{
    /// <summary>
    ///     Extends <see cref="QueryContext{TParameters, TQueryResult}" />s.
    /// </summary>
    public static class QueryContextExtensions
    {
        /// <summary>
        ///     Compile <paramref name="queryContext" /> into a query.
        /// </summary>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <param name="queryContext">The <see cref="QueryContext{TQueryResult}" /> to compile.</param>
        /// <returns>A compiled query.</returns>
        public static Query<TQueryResult> Compile<TQueryResult>(this QueryContext<NoParameters, TQueryResult> queryContext)
        {
            return queryContext.Database.Compile(queryContext);
        }

        /// <summary>
        ///     Compile <paramref name="queryContext" /> into a query.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this query.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <param name="queryContext">The <see cref="QueryContext{TParameters, TQueryResult}" /> to compile.</param>
        /// <returns>A compiled query.</returns>
        public static Query<TParameters, TQueryResult> Compile<TParameters, TQueryResult>(
            this QueryContext<TParameters, TQueryResult> queryContext)
        {
            return queryContext.Database.Compile(queryContext);
        }

        /// <summary>
        ///     Compile <paramref name="queryComponent" /> into a query.
        /// </summary>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <param name="queryComponent">The <see cref="QueryComponent{TParameters, TQueryResult}" /> to compile.</param>
        /// <returns>A compiled query.</returns>
        public static Query<TQueryResult> Compile<TQueryResult>(this QueryComponent<NoParameters, TQueryResult> queryComponent)
        {
            return queryComponent.QueryContext.Compile();
        }

        /// <summary>
        ///     Compile <paramref name="queryComponent" /> into a query.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this query.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <param name="queryComponent">The <see cref="QueryComponent{TParameters, TQueryResult}" /> to compile.</param>
        /// <returns>A compiled query.</returns>
        public static Query<TParameters, TQueryResult> Compile<TParameters, TQueryResult>(
            this QueryComponent<TParameters, TQueryResult> queryComponent)
        {
            return queryComponent.QueryContext.Compile();
        }
    }
}
