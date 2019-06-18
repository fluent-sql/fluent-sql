namespace WeelinkIT.FluentSQL.Querying.Statements.Extensions
{
    /// <summary>
    ///     Allows the construction of
    ///     <see cref="WeelinkIT.FluentSQL.Querying.Statements.Union{TParameters, TParameters, TQueryResult}" />s.
    /// </summary>
    public static class UnionExtensions
    {
        /// <summary>
        ///     UNION a <see cref="Query{TParameters, TQueryResult}" /> with another <see cref="Query{TParameters, TQueryResult}" />.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this <see cref="Query{TParameters, TQueryResult}" />.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the <see cref="Query{TParameters, TQueryResult}" />.</typeparam>
        /// <param name="first">The first <see cref="Query{TParameters, TQueryResult}" />.</param>
        /// <param name="second">The second <see cref="Query{TParameters, TQueryResult}" />.</param>
        /// <returns>The union of <paramref name="first" /> and <paramref name="second" />.</returns>
        public static Union<TParameters, TParameters, TQueryResult> Union<TParameters, TQueryResult>(
            this QueryComponent<TParameters, TQueryResult> first, QueryComponent<TParameters, TQueryResult> second)
            where TParameters : new()
        {
            return new Union<TParameters, TParameters, TQueryResult>(first, second);
        }

        /// <summary>
        ///     UNION a <see cref="Query{TParameters, TQueryResult}" /> with a <see cref="Query{TQueryResult}" />.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this <see cref="Query{TParameters, TQueryResult}" />.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the <see cref="Query{TParameters, TQueryResult}" />.</typeparam>
        /// <param name="first">The first <see cref="Query{TParameters, TQueryResult}" />.</param>
        /// <param name="second">The second <see cref="Query{TParameters, TQueryResult}" />.</param>
        /// <returns>The union of <paramref name="first" /> and <paramref name="second" />.</returns>
        public static Union<TParameters, NoParameters, TQueryResult> Union<TParameters, TQueryResult>(
            this QueryComponent<TParameters, TQueryResult> first, QueryComponent<NoParameters, TQueryResult> second)
            where TParameters : new()
        {
            return new Union<TParameters, NoParameters, TQueryResult>(first, second);
        }

        /// <summary>
        ///     UNION a <see cref="Query{TParameters, TQueryResult}" /> with a <see cref="Query{TQueryResult}" />.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this <see cref="Query{TParameters, TQueryResult}" />.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the <see cref="Query{TParameters, TQueryResult}" />.</typeparam>
        /// <param name="first">The first <see cref="Query{TParameters, TQueryResult}" />.</param>
        /// <param name="second">The second <see cref="Query{TParameters, TQueryResult}" />.</param>
        /// <returns>The union of <paramref name="first" /> and <paramref name="second" />.</returns>
        public static Union<NoParameters, TParameters, TQueryResult> Union<TParameters, TQueryResult>(
            this QueryComponent<NoParameters, TQueryResult> first, QueryComponent<TParameters, TQueryResult> second)
            where TParameters : new()
        {
            return new Union<NoParameters, TParameters, TQueryResult>(first, second);
        }

        /// <summary>
        ///     UNION ALL a <see cref="Query{TParameters, TQueryResult}" /> with another <see cref="Query{TParameters, TQueryResult}" />.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this <see cref="Query{TParameters, TQueryResult}" />.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the <see cref="Query{TParameters, TQueryResult}" />.</typeparam>
        /// <param name="first">The first <see cref="Query{TParameters, TQueryResult}" />.</param>
        /// <param name="second">The second <see cref="Query{TParameters, TQueryResult}" />.</param>
        /// <returns>The union all of <paramref name="first" /> and <paramref name="second" />.</returns>
        public static UnionAll<TParameters, TParameters, TQueryResult> UnionAll<TParameters, TQueryResult>(
            this QueryComponent<TParameters, TQueryResult> first, QueryComponent<TParameters, TQueryResult> second)
            where TParameters : new()
        {
            return new UnionAll<TParameters, TParameters, TQueryResult>(first, second);
        }

        /// <summary>
        ///     UNION ALL a <see cref="Query{TParameters, TQueryResult}" /> with a <see cref="Query{TQueryResult}" />.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this <see cref="Query{TParameters, TQueryResult}" />.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the <see cref="Query{TParameters, TQueryResult}" />.</typeparam>
        /// <param name="first">The first <see cref="Query{TParameters, TQueryResult}" />.</param>
        /// <param name="second">The second <see cref="Query{TParameters, TQueryResult}" />.</param>
        /// <returns>The union al of <paramref name="first" /> and <paramref name="second" />.</returns>
        public static UnionAll<TParameters, NoParameters, TQueryResult> UnionAll<TParameters, TQueryResult>(
            this QueryComponent<TParameters, TQueryResult> first, QueryComponent<NoParameters, TQueryResult> second)
            where TParameters : new()
        {
            return new UnionAll<TParameters, NoParameters, TQueryResult>(first, second);
        }

        /// <summary>
        ///     UNION ALL a <see cref="Query{TParameters, TQueryResult}" /> with a <see cref="Query{TQueryResult}" />.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this <see cref="Query{TParameters, TQueryResult}" />.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the <see cref="Query{TParameters, TQueryResult}" />.</typeparam>
        /// <param name="first">The first <see cref="Query{TParameters, TQueryResult}" />.</param>
        /// <param name="second">The second <see cref="Query{TParameters, TQueryResult}" />.</param>
        /// <returns>The union al of <paramref name="first" /> and <paramref name="second" />.</returns>
        public static UnionAll<NoParameters, TParameters, TQueryResult> UnionAll<TParameters, TQueryResult>(
            this QueryComponent<NoParameters, TQueryResult> first, QueryComponent<TParameters, TQueryResult> second)
            where TParameters : new()
        {
            return new UnionAll<NoParameters, TParameters, TQueryResult>(first, second);
        }
    }
}
