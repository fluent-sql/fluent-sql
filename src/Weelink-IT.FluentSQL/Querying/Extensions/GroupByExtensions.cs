using System;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.Extensions
{
    public static class GroupByExtensions
    {
        public static GroupBy<TModel, TResult, TTable, TType> GroupBy<TModel, TResult, TTable, TType>(
            this ExtensionPoint<TModel, TResult, TTable> subject,
            Expression<Func<TTable, Column<TType>>> expression) where TModel : PersistenceModel where TTable : Table
        {
            QueryContext<TModel, TResult> queryContext = subject.GetQueryContext();
            var groupBy = new GroupBy<TModel, TResult, TTable, TType>(queryContext, expression);

            queryContext.GroupByComponents.Add(groupBy);

            return groupBy;
        }
    }
}
