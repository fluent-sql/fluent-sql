namespace WeelinkIT.FluentSQL.Querying
{
    public class Limit<TParameters, TQueryResult> : QueryComponent<TParameters, TQueryResult> where TParameters : new()
    {
        public Limit(QueryContext<TParameters, TQueryResult> queryContext, int count)
        {
            QueryContext = queryContext;
            Count = count;

            QueryContext.Modifiers.Add(this);
        }

        QueryContext<TParameters, TQueryResult> QueryComponent<TParameters, TQueryResult>.QueryContext
        {
            get { return QueryContext; }
        }

        private QueryContext<TParameters, TQueryResult> QueryContext { get; }
        private int Count { get; }
    }
}
