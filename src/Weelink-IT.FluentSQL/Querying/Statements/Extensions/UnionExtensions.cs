namespace WeelinkIT.FluentSQL.Querying.Statements.Extensions
{
    public static class UnionExtensions
    {
        public static Union<TParameters, TParameters, TQueryResult> Union<TParameters, TQueryResult>(
            this QueryComponent<TParameters, TQueryResult> component, QueryComponent<TParameters, TQueryResult> other)
            where TParameters : new()
        {
            return new Union<TParameters, TParameters, TQueryResult>(component, other);
        }

        public static Union<TParameters, NoParameters, TQueryResult> Union<TParameters, TQueryResult>(
            this QueryComponent<TParameters, TQueryResult> component, QueryComponent<NoParameters, TQueryResult> other)
            where TParameters : new()
        {
            return new Union<TParameters, NoParameters, TQueryResult>(component, other);
        }

        public static Union<NoParameters, TParameters, TQueryResult> Union<TParameters, TQueryResult>(
            this QueryComponent<NoParameters, TQueryResult> component, QueryComponent<TParameters, TQueryResult> other)
            where TParameters : new()
        {
            return new Union<NoParameters, TParameters, TQueryResult>(component, other);
        }

        public static UnionAll<TParameters, TParameters, TQueryResult> UnionAll<TParameters, TQueryResult>(
            this QueryComponent<TParameters, TQueryResult> component, QueryComponent<TParameters, TQueryResult> other)
            where TParameters : new()
        {
            return new UnionAll<TParameters, TParameters, TQueryResult>(component, other);
        }

        public static UnionAll<TParameters, NoParameters, TQueryResult> UnionAll<TParameters, TQueryResult>(
            this QueryComponent<TParameters, TQueryResult> component, QueryComponent<NoParameters, TQueryResult> other)
            where TParameters : new()
        {
            return new UnionAll<TParameters, NoParameters, TQueryResult>(component, other);
        }

        public static UnionAll<NoParameters, TParameters, TQueryResult> UnionAll<TParameters, TQueryResult>(
            this QueryComponent<NoParameters, TQueryResult> component, QueryComponent<TParameters, TQueryResult> other)
            where TParameters : new()
        {
            return new UnionAll<NoParameters, TParameters, TQueryResult>(component, other);
        }
    }
}
