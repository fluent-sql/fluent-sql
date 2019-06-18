namespace WeelinkIT.FluentSQL.Querying.Statements
{
    public class Union<TParameters1, TParameters2, TQueryResult> : QueryComponent<TParameters1, TQueryResult>
        where TParameters1 : new()
        where TParameters2 : new()
    {
        public Union(QueryComponent<TParameters1, TQueryResult> component, QueryComponent<TParameters2, TQueryResult> other)
        {
            Component = component;
            Other = other;
        }

        QueryContext<TParameters1, TQueryResult> QueryComponent<TParameters1, TQueryResult>.QueryContext
        {
            get { return Component.QueryContext; }
        }

        private QueryComponent<TParameters1, TQueryResult> Component { get; }
        private QueryComponent<TParameters2, TQueryResult> Other { get; }
    }
}
