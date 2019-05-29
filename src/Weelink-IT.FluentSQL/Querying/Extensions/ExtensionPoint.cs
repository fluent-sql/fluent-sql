using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.Extensions
{
    /// <summary>
    ///     Allows for adding extensions to this <see cref="QueryComponent{TModel, TResult}" />.
    /// </summary>
    /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
    /// <typeparam name="TResult">The result type of the <see cref="Query{TResult}" />.</typeparam>
    public interface ExtensionPoint<TModel, TResult> where TModel : PersistenceModel
    {
    }

    /// <summary>
    ///     Allows for adding extensions to this <see cref="QueryComponent{TModel, TResult}" />.
    /// </summary>
    /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
    /// <typeparam name="TResult">The result type of the <see cref="Query{TResult}" />.</typeparam>
    /// <typeparam name="T">Any other type required for this <see cref="QueryContext{TModel, TResult}" />.</typeparam>
    public interface ExtensionPoint<TModel, TResult, T> where TModel : PersistenceModel
    {
    }
}
