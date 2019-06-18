namespace WeelinkIT.FluentSQL.Querying.Extensions
{
    public static class QueryContextExtensions
    {
        public static Query<TQueryResult> Compile<TQueryResult>(this QueryContext<NoParameters, TQueryResult> queryContext)
        {
            return queryContext.Database.Compile(queryContext);
        }

        public static Query<TParameters, TQueryResult> Compile<TParameters, TQueryResult>(this QueryContext<TParameters, TQueryResult> queryContext)
            where TParameters : new()
        {
            return queryContext.Database.Compile(queryContext);
        }

        public static Query<TQueryResult> Compile<TQueryResult>(this QueryComponent<NoParameters, TQueryResult> queryComponent)
        {
            return queryComponent.QueryContext.Compile<TQueryResult>();
        }

        public static Query<TParameters, TQueryResult> Compile<TParameters, TQueryResult>(this QueryComponent<TParameters, TQueryResult> queryComponent)
            where TParameters : new()
        {
            return queryComponent.QueryContext.Compile();
        }
    }
}
