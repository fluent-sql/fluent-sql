namespace WeelinkIT.FluentSQL.Querying.Statements.Extensions
{
    /// <summary>
    ///     Allows the construction of <see cref="WeelinkIT.FluentSQL.Querying.Statements.Distinct{TParameters,TQueryResult}" />s.
    /// </summary>
    public static class DistinctExtensions
    {
        /// <summary>
        ///     The <c>DISTINCT</c>-statement that selects unique records.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this <see cref="Query{TParameters, TQueryResult}" />.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the <see cref="Query{TParameters, TQueryResult}" />.</typeparam>
        /// <returns>The <see cref="WeelinkIT.FluentSQL.Querying.Statements.Distinct{TParameters,TQueryResult}" />.</returns>
        public static Distinct<TParameters, TQueryResult> Distinct<TParameters, TQueryResult>(
            this QueryComponent<TParameters, TQueryResult> queryComponent) where TParameters : new()
        {
            return new Distinct<TParameters, TQueryResult>(queryComponent.QueryContext);
        }
    }
}
