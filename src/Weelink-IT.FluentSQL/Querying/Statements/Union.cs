namespace WeelinkIT.FluentSQL.Querying.Statements
{
    /// <summary>
    ///     The <c>UNION ALL</c>-statement for combining two <see cref="Query{TParameters, TQueryResult}" />s, filtering out duplicates.
    /// </summary>
    /// <typeparam name="TParameters1">The parameter type for the first <see cref="Query{TParameters, TQueryResult}" /></typeparam>
    /// <typeparam name="TParameters2">The parameter type for the second <see cref="Query{TParameters, TQueryResult}" /></typeparam>
    /// <typeparam name="TQueryResult">The result type of the <see cref="Query{TParameters, TQueryResult}" />.</typeparam>
    /// <remarks>
    ///     Even though this class makes it possible to union queries with two different parameter types, the extension methods
    ///     don't support this. It is added because it should be possible to union a query with parameters with a query
    ///     without parameters.
    /// </remarks>
    public class Union<TParameters1, TParameters2, TQueryResult> : QueryComponent<TParameters1, TQueryResult>
        where TParameters1 : new()
        where TParameters2 : new()
    {
        /// <summary>
        ///     Create a new <c>UNION</c>-statement.
        /// </summary>
        /// <param name="first">The first <see cref="Query{TParameters, TQueryResult}" />.</param>
        /// <param name="second">The second <see cref="Query{TParameters, TQueryResult}" />.</param>
        internal Union(QueryComponent<TParameters1, TQueryResult> first, QueryComponent<TParameters2, TQueryResult> second)
        {
            First = first;
            Second = second;
        }

        /// <inheritdoc />
        QueryContext<TParameters1, TQueryResult> QueryComponent<TParameters1, TQueryResult>.QueryContext
        {
            get { return First.QueryContext; }
        }

        private QueryComponent<TParameters1, TQueryResult> First { get; }
        private QueryComponent<TParameters2, TQueryResult> Second { get; }
    }
}
