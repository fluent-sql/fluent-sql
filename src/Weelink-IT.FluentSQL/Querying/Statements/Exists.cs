namespace WeelinkIT.FluentSQL.Querying.Statements
{
    public class Exists<TQueryResult>
    {
        public Exists(Query<TQueryResult> subquery)
        {
            Subquery = subquery;
        }

        private Query<TQueryResult> Subquery { get; }

        public static implicit operator bool(Exists<TQueryResult> exists)
        {
            return true;
        }
    }

    public class Exists<TParameters, TQueryResult> where TParameters : new()
    {
        public Exists(Query<TParameters, TQueryResult> subquery)
        {
            Subquery = subquery;
        }

        private Query<TParameters, TQueryResult> Subquery { get; }

        public static implicit operator bool(Exists<TParameters, TQueryResult> exists)
        {
            return true;
        }
    }
}
