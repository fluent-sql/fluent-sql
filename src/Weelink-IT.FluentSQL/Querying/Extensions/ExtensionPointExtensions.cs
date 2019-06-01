using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.Extensions
{
    /// <summary>
    ///     Extends <see cref="ExtensionPoint{TModel, TParameters, TResult}" />.
    /// </summary>
    internal static class ExtensionPointExtensions
    {
        /// <summary>
        ///     Get the underlying <see cref="QueryContext{TModel, TParameters, TResult}" /> of
        ///     this <see cref="ExtensionPoint{TModel, TParameters, TResult}" />.
        /// </summary>
        /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this <see cref="Query{TParameters, TResult}" />.
        /// </typeparam>
        /// <typeparam name="TResult">The result type of the <see cref="Query{TParameters, TResult}" />.</typeparam>
        /// <typeparam name="T">Any other type required for this <see cref="QueryContext{TModel, TParameters, TResult}" />.</typeparam>
        /// <param name="extensionPoint">The <see cref="ExtensionPoint{TModel, TParameters, TResult, T}" />.</param>
        /// <returns>The underlying <see cref="QueryContext{TModel, TParameters, TResult}" />.</returns>
        internal static QueryContext<TModel, TParameters, TResult> GetQueryContext<TModel, TParameters, TResult, T>(
            this ExtensionPoint<TModel, TParameters, TResult, T> extensionPoint) where TModel : PersistenceModel where TParameters : new()
        {
            var component = (QueryComponent<TModel, TParameters, TResult>)extensionPoint;
            return component.QueryContext;
        }
    }
}
