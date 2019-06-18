namespace WeelinkIT.FluentSQL.Querying.Statements
{
    /// <summary>
    ///     The <c>DISTINCT</c>-statement that selects unique records.
    /// </summary>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing this <see cref="Query{TParameters, TQueryResult}" />.
    /// </typeparam>
    /// <typeparam name="TQueryResult">The result type of the <see cref="Query{TParameters, TQueryResult}" />.</typeparam>
    public class Distinct<TParameters, TQueryResult> : QueryComponent<TParameters, TQueryResult> where TParameters : new()
    {
        /// <summary>
        ///     Create a new <c>DISTINCT</c>-statement.
        /// </summary>
        /// <param name="queryContext">The <see cref="QueryContext{TParameters, TResult}" />.</param>
        internal Distinct(QueryContext<TParameters, TQueryResult> queryContext)
        {
            QueryContext = queryContext;

            QueryContext.Modifiers.Add(this);
        }

        /// <inheritdoc />
        QueryContext<TParameters, TQueryResult> QueryComponent<TParameters, TQueryResult>.QueryContext
        {
            get { return QueryContext; }
        }

        private QueryContext<TParameters, TQueryResult> QueryContext { get; }
    }
}
