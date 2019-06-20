namespace FluentSQL.Querying.Statements
{
    /// <summary>
    ///     The <c>UNION ALL</c>-statement for combining two queries, allowing duplicates.
    /// </summary>
    /// <typeparam name="TParameters1">The parameter type for the first query.</typeparam>
    /// <typeparam name="TParameters2">The parameter type for the second query.</typeparam>
    /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
    /// <remarks>
    ///     Even though this class makes it possible to union queries with two different parameter types, the extension methods
    ///     don't support this. It is added because it should be possible to union a query with parameters with a query
    ///     without parameters.
    /// </remarks>
    public class UnionAll<TParameters1, TParameters2, TQueryResult> : QueryComponent<TParameters1, TQueryResult>
        where TParameters1 : new()
        where TParameters2 : new()
    {
        /// <summary>
        ///     Create a new <c>UNION ALL</c>-statement.
        /// </summary>
        /// <param name="first">The first query.</param>
        /// <param name="second">The second query.</param>
        internal UnionAll(QueryComponent<TParameters1, TQueryResult> first, QueryComponent<TParameters2, TQueryResult> second)
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
