using FluentSQL.Compilation.Parser;

namespace FluentSQL.Querying.Statements
{
    /// <summary>
    ///     The <c>DISTINCT</c>-statement that selects unique records.
    /// </summary>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing this query.
    /// </typeparam>
    /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
    public class Distinct<TParameters, TQueryResult> : QueryComponent<TParameters, TQueryResult>
    {
        /// <summary>
        ///     Create a new <c>DISTINCT</c>-statement.
        /// </summary>
        /// <param name="queryContext">The <see cref="QueryContext{TParameters, TResult}" />.</param>
        internal Distinct(QueryContext<TParameters, TQueryResult> queryContext)
            : base(queryContext)
        {
            QueryContext.Components.Add(this);
        }

        internal override void Parse(QueryParser parser)
        {
            parser.Distinct();
        }
    }
}
