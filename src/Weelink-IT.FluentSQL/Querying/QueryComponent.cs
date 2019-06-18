namespace WeelinkIT.FluentSQL.Querying
{
    /// <summary>
    ///     A component in a <see cref="Query{TParameters, TQueryResult}" />.
    /// </summary>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing this <see cref="Query{TParameters, TQueryResult}" />.
    /// </typeparam>
    /// <typeparam name="TQueryResult">The result type of the <see cref="Query{TParameters, TQueryResult}" />.</typeparam>
    public interface QueryComponent<TParameters, TQueryResult> where TParameters : new()
    {
        /// <summary>
        ///     Return the underlying <see cref="QueryContext{TParameters, TQueryResult} " />.
        /// </summary>
        QueryContext<TParameters, TQueryResult> QueryContext { get; }
    }
}
