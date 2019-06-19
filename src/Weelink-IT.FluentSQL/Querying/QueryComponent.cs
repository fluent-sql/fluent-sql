namespace WeelinkIT.FluentSQL.Querying
{
    /// <summary>
    ///     A component of a query.
    /// </summary>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing the query.
    /// </typeparam>
    /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
    public interface QueryComponent<TParameters, TQueryResult> where TParameters : new()
    {
        /// <summary>
        ///     Gets the underlying <see cref="QueryContext{TParameters, TQueryResult} " />.
        /// </summary>
        QueryContext<TParameters, TQueryResult> QueryContext { get; }
    }
}
