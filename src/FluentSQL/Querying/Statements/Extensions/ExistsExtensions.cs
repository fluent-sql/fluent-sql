namespace FluentSQL.Querying.Statements.Extensions
{
    /// <summary>
    ///     Adds <c>EXISTS</c> to a query.
    /// </summary>
    public static class ExistsExtensions
    {
        /// <summary>
        ///     The <c>EXISTS</c>-statement.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this query.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <param name="query">The <see cref="Query{TParameters,TQueryResult}" /> that tests for the existence of a record.</param>
        /// <returns>The <see cref="Statements.Exists{TQueryResult}"/>.</returns>
        public static Exists<TParameters, TQueryResult> Exists<TParameters, TQueryResult>(
            this Query<TParameters, TQueryResult> query)
        {
            return new Exists<TParameters, TQueryResult>(query);
        }

        /// <summary>
        ///     The <c>EXISTS</c>-statement.
        /// </summary>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <param name="query">The <see cref="Query{TParameters,TQueryResult}" /> that tests for the existence of a record.</param>
        /// <returns>The <see cref="Statements.Exists{TQueryResult}"/>.</returns>
        public static Exists<TQueryResult> Exists<TQueryResult>(this Query<TQueryResult> query)
        {
            return new Exists<TQueryResult>(query);
        }
    }
}
