using System;
using System.Linq.Expressions;

namespace WeelinkIT.FluentSQL.Querying.Statements
{
    /// <summary>
    ///     The <c>ORDER BY</c>-statement of a <see cref="Query{TParameters, TQueryResult}" />.
    /// </summary>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing this <see cref="Query{TParameters, TQueryResult}" />.
    /// </typeparam>
    /// <typeparam name="TQueryResult">The result type of the <see cref="Query{TParameters, TQueryResult}" />.</typeparam>
    /// <typeparam name="TSqlExpression">The expression to order by.</typeparam>
    public class OrderBy<TParameters, TQueryResult, TSqlExpression> :
        QueryComponent<TParameters, TQueryResult>
        where TParameters : new()
    {
        /// <summary>
        ///     Create a new <c>ORDER BY</c>-statement.
        /// </summary>
        /// <param name="queryContext">The <see cref="QueryContext{TParameters, TResult}" />.</param>
        /// <param name="expression">The <see cref="Expression{TDelegate}" /> to select.</param>
        internal OrderBy(QueryContext<TParameters, TQueryResult> queryContext, Expression<Func<TSqlExpression>> expression)
        {
            QueryContext = queryContext;
            Expression = expression;

            queryContext.OrderByComponents.Add(this);
        }

        /// <summary>
        ///     Apply the ordering ascending.
        /// </summary>
        public OrderBy<TParameters, TQueryResult, TSqlExpression> Ascending
        {
            get { return this; }
        }

        /// <summary>
        ///     Apply the ordering descending.
        /// </summary>
        public OrderBy<TParameters, TQueryResult, TSqlExpression> Descending
        {
            get { return this; }
        }

        /// <inheritdoc />
        QueryContext<TParameters, TQueryResult> QueryComponent<TParameters, TQueryResult>.QueryContext
        {
            get { return QueryContext; }
        }

        private QueryContext<TParameters, TQueryResult> QueryContext { get; }
        private Expression<Func<TSqlExpression>> Expression { get; }
    }
}
