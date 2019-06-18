using System;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Querying.Statements;

namespace WeelinkIT.FluentSQL.Querying.Extensions
{
    public static class WhereExtensions
    {
        public static Where<TParameters, TQueryResult> Where<TParameters, TQueryResult>(
            this QueryComponent<TParameters, TQueryResult> queryComponent,
            Expression<Func<TParameters, bool>> expression)
            where TParameters : new()
        {
            return new Where<TParameters, TQueryResult>(queryComponent.QueryContext, expression);
        }

        public static Where<NoParameters, TQueryResult> Where<TQueryResult>(
            this QueryComponent<NoParameters, TQueryResult> queryComponent,
            Expression<Func<bool>> expression)
        {
            return queryComponent.Where(expression.AddNoParameters());
        }
    }
}
