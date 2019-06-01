using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.Extensions
{
    /// <summary>
    ///     Allows for adding extensions to this <see cref="QueryComponent{TModel, TParameters, TResult}" />.
    /// </summary>
    /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing this <see cref="Query{TParameters, TResult}" />.
    /// </typeparam>
    /// <typeparam name="TResult">The result type of the <see cref="Query{TParameters, TResult}" />.</typeparam>
    public interface ExtensionPoint<TModel, TParameters, TResult> where TModel : PersistenceModel where TParameters : new()
    {
    }

    /// <summary>
    ///     Allows for adding extensions to this <see cref="QueryComponent{TModel, TParameters, TResult}" />.
    /// </summary>
    /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing this <see cref="Query{TParameters, TResult}" />.
    /// </typeparam>
    /// <typeparam name="TResult">The result type of the <see cref="Query{TParameters, TResult}" />.</typeparam>
    /// <typeparam name="T">Any other type required for this <see cref="QueryContext{TModel, TParameters, TResult}" />.</typeparam>
    public interface ExtensionPoint<TModel, TParameters, TResult, T> where TModel : PersistenceModel where TParameters : new()
    {
    }
}
