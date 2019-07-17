using FluentSQL.Compilation.Parser;

namespace FluentSQL.Querying.Statements
{
    
    /// <summary>
    ///     The <c>UNION</c>-statement for combining two queries, filtering out duplicates.
    /// </summary>
    /// <typeparam name="TFirstParameters">
    ///     The parameters required for executing the first query.
    /// </typeparam>
    /// <typeparam name="TSecondParameters">
    ///     The parameters required for executing the second query.
    /// </typeparam>
    /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
    public class Union<TFirstParameters, TSecondParameters, TQueryResult> : QueryComponent<TFirstParameters, TQueryResult>
    {
        public Union(
            QueryComponent<TFirstParameters, TQueryResult> first,
            QueryComponent<TSecondParameters, TQueryResult> second)
            : base(new QueryContext<TFirstParameters, TQueryResult>(first.QueryContext.Database, first.QueryContext.Model))
        {
            First = first;
            Second = second;
            QueryContext.Components.Add(this);
        }

        internal override void Parse(QueryParser parser)
        {
            parser.Union(First, Second);
        }

        private QueryComponent<TFirstParameters, TQueryResult> First { get; }
        private QueryComponent<TSecondParameters, TQueryResult> Second { get; }
    }
}
