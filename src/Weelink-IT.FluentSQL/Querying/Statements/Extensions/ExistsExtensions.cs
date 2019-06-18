namespace WeelinkIT.FluentSQL.Querying.Statements.Extensions
{
    public static class ExistsExtensions
    {
        public static Exists<TParameters, TQueryResult> Exists<TParameters, TQueryResult>(
            this Query<TParameters, TQueryResult> query)
            where TParameters : new()
        {
            return new Exists<TParameters, TQueryResult>(query);
        }

        public static Exists<TQueryResult> Exists<TQueryResult>(this Query<TQueryResult> query)
        {
            return new Exists<TQueryResult>(query);
        }
    }
}
