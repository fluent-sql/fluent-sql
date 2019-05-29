using System;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.Extensions
{
    public static class OrderByExtensions
    {
        public static OrderBy<TModel, TResult, TTable, TType> OrderBy<TModel, TResult, TTable, TType>(
            this ExtensionPoint<TModel, TResult, TTable> subject,
            Expression<Func<TTable, Column<TType>>> expression)
            where TModel : PersistenceModel
            where TTable : Table
        {
            QueryContext<TModel, TResult> queryContext = subject.GetQueryContext();
            var orderBy = new OrderBy<TModel, TResult, TTable, TType>(queryContext, expression, subject);

            queryContext.OrderByComponents.Add(orderBy);

            return orderBy;
        }
    }
}
