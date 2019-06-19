using System;
using System.Linq.Expressions;

namespace WeelinkIT.FluentSQL.Querying.Statements.Extensions
{
    /// <summary>
    ///     Adds <c>ORDER BY</c> to a query.
    /// </summary>
    public static class OrderByExtensions
    {
        /// <summary>
        ///     Add a new <c>ORDER BY</c> to the query.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this query.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <typeparam name="TSqlExpression">The expression to order by.</typeparam>
        /// <param name="queryComponent">The <see cref="QueryComponent{TParameters, TQueryResult}" />.</param>
        /// <param name="expression">
        ///     The <see cref="Expression{TDelegate}">Expression&lt;Func&lt;TSqlExpression&gt;&gt;</see> that indicates on
        ///     which columns to order.
        /// </param>
        /// <returns>
        ///     The <see cref="WeelinkIT.FluentSQL.Querying.Statements.OrderBy{TParameters, TQueryResult, TSqlExpression}" />.
        /// </returns>
        public static OrderBy<TParameters, TQueryResult, TSqlExpression> OrderBy<TParameters, TQueryResult, TSqlExpression>(
            this QueryComponent<TParameters, TQueryResult> queryComponent,
            Expression<Func<TSqlExpression>> expression)
            where TParameters : new()
        {
            return new OrderBy<TParameters, TQueryResult, TSqlExpression>(queryComponent.QueryContext, expression);
        }
    }
}
