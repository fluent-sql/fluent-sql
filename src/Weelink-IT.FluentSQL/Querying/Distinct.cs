namespace WeelinkIT.FluentSQL.Querying
{
    public class Distinct<TParameters, TQueryResult> : QueryComponent<TParameters, TQueryResult> where TParameters : new()
    {
        public Distinct(QueryContext<TParameters, TQueryResult> queryContext)
        {
            QueryContext = queryContext;

            QueryContext.Modifiers.Add(this);
        }

        QueryContext<TParameters, TQueryResult> QueryComponent<TParameters, TQueryResult>.QueryContext
        {
            get { return QueryContext; }
        }

        private QueryContext<TParameters, TQueryResult> QueryContext { get; }
    }
}
