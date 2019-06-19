namespace WeelinkIT.FluentSQL.Querying.Statements.Extensions
{
    /// <summary>
    ///     Adds <c>LIMIT</c> to the <c>SELECT</c> of a query.
    /// </summary>
    public static class LimitExtensions
    {
        /// <summary>
        ///     Limits the number of results.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this query.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <returns>The <see cref="WeelinkIT.FluentSQL.Querying.Statements.Limit{TParameters,TQueryResult}" />.</returns>
        public static Limit<TParameters, TQueryResult> Limit<TParameters, TQueryResult>(
            this QueryComponent<TParameters, TQueryResult> queryComponent, int limit) where TParameters : new()
        {
            return new Limit<TParameters, TQueryResult>(queryComponent.QueryContext, limit);
        }
    }
}
