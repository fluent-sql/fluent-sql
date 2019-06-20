namespace FluentSQL.Querying.Statements.Extensions
{
    /// <summary>
    ///     Adds <c>DISTINCT</c> to the <c>SELECT</c> of a query.
    /// </summary>
    public static class DistinctExtensions
    {
        /// <summary>
        ///     The <c>DISTINCT</c>-statement that selects unique records.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this query.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <returns>The <see cref="Statements.Distinct{TParameters,TQueryResult}" />.</returns>
        public static Distinct<TParameters, TQueryResult> Distinct<TParameters, TQueryResult>(
            this QueryComponent<TParameters, TQueryResult> queryComponent) where TParameters : new()
        {
            return new Distinct<TParameters, TQueryResult>(queryComponent.QueryContext);
        }
    }
}
