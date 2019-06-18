using System;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Querying.Statements;

namespace WeelinkIT.FluentSQL.Querying.Extensions
{
    public static class OrderByExtensions
    {
        public static OrderBy<TParameters, TQueryResult, TSqlExpression> OrderBy<TParameters, TQueryResult, TSqlExpression>(
            this QueryComponent<TParameters, TQueryResult> queryComponent,
            Expression<Func<TSqlExpression>> expression)
            where TParameters : new()
        {
            return new OrderBy<TParameters, TQueryResult, TSqlExpression>(queryComponent.QueryContext, expression);
        }
    }
}
