namespace FluentSQL.Querying.Statements.Extensions
{
    /// <summary>
    ///     Adds <c>UNION</c> and <c>UNION ALL</c> to a query.
    /// </summary>
    public static class UnionExtensions
    {
        /// <summary>
        ///     <c>UNION</c> a query with an other query.
        /// </summary>
        /// <typeparam name="TFirstParameters">
        ///     The parameters required for executing the first query.
        /// </typeparam>
        /// <typeparam name="TSecondParameters">
        ///     The parameters required for executing the second query.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <param name="first">The first query.</param>
        /// <param name="second">The second query.</param>
        /// <returns>The union of <paramref name="first" /> and <paramref name="second" />.</returns>
        public static Union<TFirstParameters, TSecondParameters, TQueryResult> Union<TFirstParameters, TSecondParameters, TQueryResult>(
            this QueryComponent<TFirstParameters, TQueryResult> first, QueryComponent<TSecondParameters, TQueryResult> second)
        {
            return new Union<TFirstParameters, TSecondParameters, TQueryResult>(first, second);
        }

        /// <summary>
        ///     <c>UNION ALL</c> a query with an other query.
        /// </summary>
        /// <typeparam name="TFirstParameters">
        ///     The parameters required for executing the first query.
        /// </typeparam>
        /// <typeparam name="TSecondParameters">
        ///     The parameters required for executing the second query.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <param name="first">The first query.</param>
        /// <param name="second">The second query.</param>
        /// <returns>The union al of <paramref name="first" /> and <paramref name="second" />.</returns>
        public static UnionAll<TFirstParameters, TSecondParameters, TQueryResult>
            UnionAll<TFirstParameters, TSecondParameters, TQueryResult>(
                this QueryComponent<TFirstParameters, TQueryResult> first, QueryComponent<TSecondParameters, TQueryResult> second)
        {
            return new UnionAll<TFirstParameters, TSecondParameters, TQueryResult>(first, second);
        }
    }
}
