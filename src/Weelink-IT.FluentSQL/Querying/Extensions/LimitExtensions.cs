namespace WeelinkIT.FluentSQL.Querying.Extensions
{
    public static class LimitExtensions
    {
        public static Limit<TParameters, TQueryResult> Limit<TParameters, TQueryResult>(
            this QueryComponent<TParameters, TQueryResult> queryComponent, int limit) where TParameters : new()
        {
            return new Limit<TParameters, TQueryResult>(queryComponent.QueryContext, limit);
        }
    }
}
