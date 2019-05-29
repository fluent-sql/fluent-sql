using System;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.Extensions
{
    public static class WhereExtensions
    {
        public static Where<TModel, TResult, TTable> Where<TModel, TResult, TTable>(
            this ExtensionPoint<TModel, TResult, TTable> subject, Expression<Func<TTable, bool>> expression)
            where TModel : PersistenceModel where TTable : Table
        {
            QueryContext<TModel, TResult> queryContext = subject.GetQueryContext();
            var where = new Where<TModel, TResult, TTable>(queryContext, expression);

            queryContext.WhereComponents.Add(where);

            return where;
        }
    }
}
