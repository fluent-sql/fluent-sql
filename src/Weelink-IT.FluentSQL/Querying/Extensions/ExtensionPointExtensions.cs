using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.Extensions
{
    internal static class ExtensionPointExtensions
    {
        internal static QueryContext<TModel, TResult> GetQueryContext<TModel, TResult>(
            this ExtensionPoint<TModel, TResult> extensionPoint) where TModel : PersistenceModel
        {
            var component = (QueryComponent<TModel, TResult>)extensionPoint;
            return component.QueryContext;
        }

        internal static QueryContext<TModel, TResult> GetQueryContext<TModel, TResult, T>(
            this ExtensionPoint<TModel, TResult, T> extensionPoint) where TModel : PersistenceModel
        {
            var component = (QueryComponent<TModel, TResult>)extensionPoint;
            return component.QueryContext;
        }
    }
}
