using System;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Querying.Statements;

namespace WeelinkIT.FluentSQL.Querying.Extensions
{
    public static class GroupByExtensions
    {
        public static GroupBy<TParameters, TQueryResult, TSqlExpression> GroupBy<TParameters, TQueryResult, TSqlExpression>(
            this QueryComponent<TParameters, TQueryResult> queryComponent,
            Expression<Func<TSqlExpression>> expression)
            where TParameters : new()
        {
            return new GroupBy<TParameters, TQueryResult, TSqlExpression>(queryComponent.QueryContext, expression);
        }
    }
}
