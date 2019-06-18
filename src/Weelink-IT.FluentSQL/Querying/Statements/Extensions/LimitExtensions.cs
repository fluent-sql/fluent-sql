namespace WeelinkIT.FluentSQL.Querying.Statements.Extensions
{
    /// <summary>
    ///     Allows the construction of <see cref="WeelinkIT.FluentSQL.Querying.Statements.Limit{TParameters,TQueryResult}" />s.
    /// </summary>
    public static class LimitExtensions
    {
        /// <summary>
        ///     Limits the number of results.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this <see cref="Query{TParameters, TQueryResult}" />.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the <see cref="Query{TParameters, TQueryResult}" />.</typeparam>
        /// <returns>The <see cref="WeelinkIT.FluentSQL.Querying.Statements.Limit{TParameters,TQueryResult}" />.</returns>
        public static Limit<TParameters, TQueryResult> Limit<TParameters, TQueryResult>(
            this QueryComponent<TParameters, TQueryResult> queryComponent, int limit) where TParameters : new()
        {
            return new Limit<TParameters, TQueryResult>(queryComponent.QueryContext, limit);
        }
    }
}
