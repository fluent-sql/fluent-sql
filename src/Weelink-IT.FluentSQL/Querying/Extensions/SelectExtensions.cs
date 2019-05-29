using System;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.Extensions
{
    public static class SelectExtensions
    {
        public static Select<TModel, TResult, TTable, TType> Select<TModel, TResult, TTable, TType>(
            this ExtensionPoint<TModel, TResult, TTable> subject,
            Expression<Func<TTable, Column<TType>>> expression) where TModel : PersistenceModel where TTable : Table
        {
            QueryContext<TModel, TResult> queryContext = subject.GetQueryContext();
            var select = new Select<TModel, TResult, TTable, TType>(queryContext, expression);

            queryContext.SelectComponents.Add(select);

            return select;
        }
    }
}
