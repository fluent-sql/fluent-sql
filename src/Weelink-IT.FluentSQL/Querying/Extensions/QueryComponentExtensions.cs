using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.Extensions
{
    public static class QueryComponentExtensions
    {
        public static Query<TResult> Compile<TModel, TResult>(this QueryComponent<TModel, TResult> component)
            where TModel : PersistenceModel
        {
            return component.QueryContext.Compile();
        }
    }
}
