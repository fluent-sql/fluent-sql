using System;
using System.Linq.Expressions;

namespace WeelinkIT.FluentSQL.Querying.Statements
{
    /// <summary>
    ///     The <c>WHERE</c>-statement of a <see cref="Query{TParameters, TResult}" />.
    /// </summary>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing this <see cref="Query{TParameters, TResult}" />.
    /// </typeparam>
    /// <typeparam name="TQueryResult">The result type of the <see cref="Query{TParameters, TResult}" />.</typeparam>
    public class Where<TParameters, TQueryResult> : QueryComponent<TParameters, TQueryResult> where TParameters : new()
    {
        /// <summary>
        ///     Create a new <c>WHERE</c>-statement.
        /// </summary>
        /// <param name="queryContext">The <see cref="QueryContext{TParameters, TResult}" />.</param>
        /// <param name="expression">The expression that represents the condition.</param>
        public Where(QueryContext<TParameters, TQueryResult> queryContext, Expression<Func<TParameters, bool>> expression)
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
