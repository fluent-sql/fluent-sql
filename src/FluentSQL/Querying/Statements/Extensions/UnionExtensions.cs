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
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this query.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <param name="first">The first query.</param>
        /// <param name="second">The second query.</param>
        /// <returns>The union of <paramref name="first" /> and <paramref name="second" />.</returns>
        public static Union<TParameters, TParameters, TQueryResult> Union<TParameters, TQueryResult>(
            this QueryComponent<TParameters, TQueryResult> first, QueryComponent<TParameters, TQueryResult> second)
            where TParameters : new()
        {
            return new Union<TParameters, TParameters, TQueryResult>(first, second);
        }

        /// <summary>
        ///     <c>UNION</c> a query with an other query.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this query.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <param name="first">The first query.</param>
        /// <param name="second">The second query.</param>
        /// <returns>The union of <paramref name="first" /> and <paramref name="second" />.</returns>
        public static Union<TParameters, NoParameters, TQueryResult> Union<TParameters, TQueryResult>(
            this QueryComponent<TParameters, TQueryResult> first, QueryComponent<NoParameters, TQueryResult> second)
            where TParameters : new()
        {
            return new Union<TParameters, NoParameters, TQueryResult>(first, second);
        }

        /// <summary>
        ///     <c>UNION</c> a query with an other query.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this query.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <param name="first">The first query.</param>
        /// <param name="second">The second query.</param>
        /// <returns>The union of <paramref name="first" /> and <paramref name="second" />.</returns>
        public static Union<NoParameters, TParameters, TQueryResult> Union<TParameters, TQueryResult>(
            this QueryComponent<NoParameters, TQueryResult> first, QueryComponent<TParameters, TQueryResult> second)
            where TParameters : new()
        {
            return new Union<NoParameters, TParameters, TQueryResult>(first, second);
        }

        /// <summary>
        ///     <c>UNION ALL</c> a query with an other query.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this query.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <param name="first">The first query.</param>
        /// <param name="second">The second query.</param>
        /// <returns>The union all of <paramref name="first" /> and <paramref name="second" />.</returns>
        public static UnionAll<TParameters, TParameters, TQueryResult> UnionAll<TParameters, TQueryResult>(
            this QueryComponent<TParameters, TQueryResult> first, QueryComponent<TParameters, TQueryResult> second)
            where TParameters : new()
        {
            return new UnionAll<TParameters, TParameters, TQueryResult>(first, second);
        }

        /// <summary>
        ///     <c>UNION ALL</c> a query with an other query.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this query.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <param name="first">The first query.</param>
        /// <param name="second">The second query.</param>
        /// <returns>The union al of <paramref name="first" /> and <paramref name="second" />.</returns>
        public static UnionAll<TParameters, NoParameters, TQueryResult> UnionAll<TParameters, TQueryResult>(
            this QueryComponent<TParameters, TQueryResult> first, QueryComponent<NoParameters, TQueryResult> second)
            where TParameters : new()
        {
            return new UnionAll<TParameters, NoParameters, TQueryResult>(first, second);
        }

        /// <summary>
        ///     <c>UNION ALL</c> a query with an other query.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this query.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <param name="first">The first query.</param>
        /// <param name="second">The second query.</param>
        /// <returns>The union al of <paramref name="first" /> and <paramref name="second" />.</returns>
        public static UnionAll<NoParameters, TParameters, TQueryResult> UnionAll<TParameters, TQueryResult>(
            this QueryComponent<NoParameters, TQueryResult> first, QueryComponent<TParameters, TQueryResult> second)
            where TParameters : new()
        {
            return new UnionAll<NoParameters, TParameters, TQueryResult>(first, second);
        }
    }
}
