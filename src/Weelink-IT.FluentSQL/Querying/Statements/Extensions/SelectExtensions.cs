using System;
using System.Linq.Expressions;

namespace WeelinkIT.FluentSQL.Querying.Statements.Extensions
{
    /// <summary>
    ///     Adds <c>SELECT</c> to a query.
    /// </summary>
    public static class SelectExtensions
    {
        /// <summary>
        ///     Add a <c>SELECT</c> to this query.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this query.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <typeparam name="TSqlExpression">The </typeparam>
        /// <param name="queryComponent">The <see cref="QueryComponent{TParameters, TQueryResult}" />.</param>
        /// <param name="expression">
        ///     The <see cref="Expression{TDelegate}"> Expression&lt;Func&lt;TSqlExpression&gt;&gt;</see> to select.
        /// </param>
        /// <returns>The <see cref="WeelinkIT.FluentSQL.Querying.Statements.Select{TParameters, TQueryResult, TSqlExpression}" />.</returns>
        public static Select<TParameters, TQueryResult, TSqlExpression> Select<TParameters, TQueryResult, TSqlExpression>(
            this QueryComponent<TParameters, TQueryResult> queryComponent,
            Expression<Func<TSqlExpression>> expression)
            where TParameters : new()
        {
            return new Select<TParameters, TQueryResult, TSqlExpression>(queryComponent.QueryContext, expression);
        }
    }
}
