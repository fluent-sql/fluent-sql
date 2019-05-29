using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.Extensions
{
    /// <summary>
    ///     Extends <see cref="ExtensionPoint{TModel, TResult}" />.
    /// </summary>
    internal static class ExtensionPointExtensions
    {
        /// <summary>
        ///     Get the underlying <see cref="QueryContext{TModel, TResult}" /> of
        ///     this <see cref="ExtensionPoint{TModel, TResult}" />.
        /// </summary>
        /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
        /// <typeparam name="TResult">The result type of the <see cref="Query{TResult}" />.</typeparam>
        /// <typeparam name="T">Any other type required for this <see cref="QueryContext{TModel, TResult}" />.</typeparam>
        /// <param name="extensionPoint">The <see cref="ExtensionPoint{TModel, TResult, T}" />.</param>
        /// <returns>The underlying <see cref="QueryContext{TModel, TResult}" />.</returns>
        internal static QueryContext<TModel, TResult> GetQueryContext<TModel, TResult, T>(
            this ExtensionPoint<TModel, TResult, T> extensionPoint) where TModel : PersistenceModel
        {
            var component = (QueryComponent<TModel, TResult>)extensionPoint;
            return component.QueryContext;
        }
    }
}
