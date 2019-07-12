using FluentSQL.Compilation.Parser;

namespace FluentSQL.Querying.Statements
{
    /// <summary>
    ///     Limits the number of results.
    /// </summary>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing this query.
    /// </typeparam>
    /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
    public class Limit<TParameters, TQueryResult> : QueryComponent<TParameters, TQueryResult>
    {
        /// <summary>
        ///     Create a new <c>LIMIT</c>-statement.
        /// </summary>
        /// <param name="queryContext">The <see cref="QueryContext{TParameters, TResult}" />.</param>
        /// <param name="count">The number of rows.</param>
        internal Limit(QueryContext<TParameters, TQueryResult> queryContext, int count)
            : base(queryContext)
        {
            Count = count;

            QueryContext.Components.Add(this);
        }

        internal override void Parse(QueryParser parser)
        {
            parser.Limit(Count);
        }

        private int Count { get; }
    }
}
