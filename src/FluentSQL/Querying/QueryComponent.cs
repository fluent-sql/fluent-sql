using FluentSQL.Compilation.Parser;
using FluentSQL.Modelling;

namespace FluentSQL.Querying
{
    /// <summary>
    ///     A component of a query.
    /// </summary>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing the query.
    /// </typeparam>
    /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
    public abstract class QueryComponent<TParameters, TQueryResult> : SqlExpression<TQueryResult> where TParameters : new()
    {
        /// <summary>
        ///     Create a new <see cref="QueryComponent{TParameters, TQueryResult}" />.
        /// </summary>
        /// <param name="queryContext">The underlying <see cref="QueryContext{TParameters, TQueryResult}" />.</param>
        protected QueryComponent(QueryContext<TParameters, TQueryResult> queryContext)
        {
            QueryContext = queryContext;
        }

        internal abstract void Parse(QueryParser parser);

        /// <summary>
        ///     Gets the underlying <see cref="QueryContext{TParameters, TQueryResult}" />.
        /// </summary>
        internal QueryContext<TParameters, TQueryResult> QueryContext { get; }
    }
}
