namespace WeelinkIT.FluentSQL.Querying.Extensions
{
    public static class DistinctExtensions
    {
        public static Distinct<TParameters, TQueryResult> Distinct<TParameters, TQueryResult>(
            this QueryComponent<TParameters, TQueryResult> queryComponent) where TParameters : new()
        {
            return new Distinct<TParameters, TQueryResult>(queryComponent.QueryContext);
        }
    }
}
