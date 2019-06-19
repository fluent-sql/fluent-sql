using System;
using System.Linq.Expressions;

namespace WeelinkIT.FluentSQL.Querying.Statements.Extensions
{
    /// <summary>
    ///     Adds <c>GROUP BY</c> to a query.
    /// </summary>
    public static class GroupByExtensions
    {
        /// <summary>
        ///     Add a new <c>GROUP BY</c> to the query.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this query.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <typeparam name="TSqlExpression">The expression to group by.</typeparam>
        /// <param name="queryComponent">The <see cref="QueryComponent{TParameters, TQueryResult}" />.</param>
        /// <param name="expression">
        ///     The <see cref="Expression{TDelegate}">Expression&lt;Func&lt;TSqlExpression&gt;&gt;</see> that indicates on
        ///     which columns to group.
        /// </param>
        /// <returns>
        ///     The <see cref="WeelinkIT.FluentSQL.Querying.Statements.GroupBy{TParameters, TQueryResult, TSqlExpression}" />.
        /// </returns>
        public static GroupBy<TParameters, TQueryResult, TSqlExpression> GroupBy<TParameters, TQueryResult, TSqlExpression>(
            this QueryComponent<TParameters, TQueryResult> queryComponent,
            Expression<Func<TSqlExpression>> expression)
            where TParameters : new()
        {
            return new GroupBy<TParameters, TQueryResult, TSqlExpression>(queryComponent.QueryContext, expression);
        }
    }
}
