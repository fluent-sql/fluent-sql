using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying
{
    /// <summary>
    ///     A component in a <see cref="Query{TParameters, TResult}" />.
    /// </summary>
    /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing this <see cref="Query{TParameters, TResult}" />.
    /// </typeparam>
    /// <typeparam name="TResult">The result type of the <see cref="Query{TParameters, TResult}" />.</typeparam>
    public interface QueryComponent<TModel, TParameters, TResult>
        where TModel : PersistenceModel
        where TParameters : new()
    {
        /// <summary>
        ///     Return the underlying <see cref="QueryContext{TModel, TParameters, TResult} " />.
        /// </summary>
        QueryContext<TModel, TParameters, TResult> QueryContext { get; }
    }
}
