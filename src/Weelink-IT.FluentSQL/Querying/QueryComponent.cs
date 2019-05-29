using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying
{
    /// <summary>
    ///     A component in a <see cref="Query{TResult}" />.
    /// </summary>
    /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
    /// <typeparam name="TResult">The result type of the <see cref="Query{TResult}" />.</typeparam>
    public interface QueryComponent<TModel, TResult> where TModel : PersistenceModel
    {
        /// <summary>
        ///     Return the underlying <see cref="QueryContext{TModel, TResult} " />.
        /// </summary>
        QueryContext<TModel, TResult> QueryContext { get; }
    }
}
