using System;
using System.Linq.Expressions;

namespace FluentSQL.Querying.Statements
{
    /// <summary>
    ///     The <c>WHERE</c>-statement of a query.
    /// </summary>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing this query.
    /// </typeparam>
    /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
    public class Where<TParameters, TQueryResult> : QueryComponent<TParameters, TQueryResult> where TParameters : new()
    {
        /// <summary>
        ///     Create a new <c>WHERE</c>-statement.
        /// </summary>
        /// <param name="queryContext">The <see cref="QueryContext{TParameters, TResult}" />.</param>
        /// <param name="expression">The expression that represents the condition.</param>
        internal Where(QueryContext<TParameters, TQueryResult> queryContext, Expression<Func<TParameters, bool>> expression)
        {
            QueryContext = queryContext;
            Expression = expression;

            queryContext.WhereComponents.Add(this);
        }

        /// <inheritdoc />
        QueryContext<TParameters, TQueryResult> QueryComponent<TParameters, TQueryResult>.QueryContext
        {
            get { return QueryContext; }
        }

        private QueryContext<TParameters, TQueryResult> QueryContext { get; }
        private Expression<Func<TParameters, bool>> Expression { get; }
    }
}
