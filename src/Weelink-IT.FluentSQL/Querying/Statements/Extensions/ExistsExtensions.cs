namespace WeelinkIT.FluentSQL.Querying.Statements.Extensions
{
    /// <summary>
    ///     Allows the construction of <see cref="WeelinkIT.FluentSQL.Querying.Statements.Exists{TQueryResult}"/>.
    /// </summary>
    public static class ExistsExtensions
    {
        /// <summary>
        ///     The <c>EXISTS</c>-statement.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this <see cref="Query{TParameters, TQueryResult}" />.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the <see cref="Query{TParameters, TQueryResult}" />.</typeparam>
        /// <param name="query">The <see cref="Query{TParameters,TQueryResult}" /> that tests for the existence of a record.</param>
        /// <returns>The <see cref="WeelinkIT.FluentSQL.Querying.Statements.Exists{TQueryResult}"/>.</returns>
        public static Exists<TParameters, TQueryResult> Exists<TParameters, TQueryResult>(
            this Query<TParameters, TQueryResult> query)
            where TParameters : new()
        {
            return new Exists<TParameters, TQueryResult>(query);
        }

        /// <summary>
        ///     The <c>EXISTS</c>-statement.
        /// </summary>
        /// <typeparam name="TQueryResult">The result type of the <see cref="Query{TParameters, TQueryResult}" />.</typeparam>
        /// <param name="query">The <see cref="Query{TParameters,TQueryResult}" /> that tests for the existence of a record.</param>
        /// <returns>The <see cref="WeelinkIT.FluentSQL.Querying.Statements.Exists{TQueryResult}"/>.</returns>
        public static Exists<TQueryResult> Exists<TQueryResult>(this Query<TQueryResult> query)
        {
            return new Exists<TQueryResult>(query);
        }
    }
}
