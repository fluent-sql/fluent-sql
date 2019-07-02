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
        public static UnionWithSameParameterTypes<TParameters, TQueryResult> Union<TParameters, TQueryResult>(
            this QueryComponent<TParameters, TQueryResult> first, QueryComponent<TParameters, TQueryResult> second)
            where TParameters : new()
        {
            return new UnionWithSameParameterTypes<TParameters, TQueryResult>(first.QueryContext, first, second);
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
        public static UnionParameterWithNoParameter<TParameters, TQueryResult> Union<TParameters, TQueryResult>(
            this QueryComponent<TParameters, TQueryResult> first, QueryComponent<NoParameters, TQueryResult> second)
            where TParameters : new()
        {
            return new UnionParameterWithNoParameter<TParameters, TQueryResult>(first.QueryContext, first, second);
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
        public static UnionNoParametersWithParameter<TParameters, TQueryResult> Union<TParameters, TQueryResult>(
            this QueryComponent<NoParameters, TQueryResult> first, QueryComponent<TParameters, TQueryResult> second)
            where TParameters : new()
        {
            return new UnionNoParametersWithParameter<TParameters, TQueryResult>(second.QueryContext, first, second);
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
        public static UnionAllWithSameParameterTypes<TParameters, TQueryResult> UnionAll<TParameters, TQueryResult>(
            this QueryComponent<TParameters, TQueryResult> first, QueryComponent<TParameters, TQueryResult> second)
            where TParameters : new()
        {
            return new UnionAllWithSameParameterTypes<TParameters, TQueryResult>(first.QueryContext, first, second);
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
        public static UnionAllParameterWithNoParameter<TParameters, TQueryResult> UnionAll<TParameters, TQueryResult>(
            this QueryComponent<TParameters, TQueryResult> first, QueryComponent<NoParameters, TQueryResult> second)
            where TParameters : new()
        {
            return new UnionAllParameterWithNoParameter<TParameters, TQueryResult>(first.QueryContext, first, second);
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
        public static UnionAllNoParametersWithParameter<TParameters, TQueryResult> UnionAll<TParameters, TQueryResult>(
            this QueryComponent<NoParameters, TQueryResult> first, QueryComponent<TParameters, TQueryResult> second)
            where TParameters : new()
        {
            return new UnionAllNoParametersWithParameter<TParameters, TQueryResult>(second.QueryContext, first, second);
        }
    }
}
