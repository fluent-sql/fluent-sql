using System;
using System.Linq.Expressions;

namespace WeelinkIT.FluentSQL.Querying.Statements.Extensions
{
    public static class FromExtensions
    {
        public static From<TParameters, TQueryResult, TTable> From<TParameters, TQueryResult, TTable>(
            this QueryContext<TParameters, TQueryResult> queryContext, Expression<Func<TTable>> table) where TParameters : new()
        {
            return new From<TParameters, TQueryResult, TTable>(queryContext, table);
        }
    }
}
