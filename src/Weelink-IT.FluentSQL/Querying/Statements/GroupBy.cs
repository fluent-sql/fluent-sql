using System;
using System.Linq.Expressions;

namespace WeelinkIT.FluentSQL.Querying.Statements
{
    /// <summary>
    ///     The <c>GROUP BY</c>-statement of a <see cref="Query{TParameters, TQueryResult}" />.
    /// </summary>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing this <see cref="Query{TParameters, TQueryResult}" />.
    /// </typeparam>
    /// <typeparam name="TQueryResult">The result type of the <see cref="Query{TParameters, TQueryResult}" />.</typeparam>
    /// <typeparam name="TSqlExpression">The expression to group by.</typeparam>
    public class GroupBy<TParameters, TQueryResult, TSqlExpression> :
        QueryComponent<TParameters, TQueryResult>
        where TParameters : new()
    {
        /// <summary>
        ///     Create a new <c>GROUP BY</c>-statement.
        /// </summary>
        /// <param name="queryContext">The <see cref="QueryContext{TParameters, TResult}" />.</param>
        /// <param name="expression">The <see cref="Expression{TDelegate}" /> to select.</param>
        public GroupBy(QueryContext<TParameters, TQueryResult> queryContext, Expression<Func<TSqlExpression>> expression)
        {
            QueryContext = queryContext;
            Expression = expression;

            queryContext.GroupByComponents.Add(this);
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
