using System;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.Extensions
{
    public static class HavingExtensions
    {
        public static Having<TModel, TResult, TTable> Having<TModel, TResult, TTable, TType>(
            this GroupBy<TModel, TResult, TTable, TType> subject,
            Expression<Func<TTable, bool>> expression) where TModel : PersistenceModel where TTable : Table
        {
            QueryContext<TModel, TResult> queryContext = subject.GetQueryContext();
            var having = new Having<TModel, TResult, TTable>(queryContext, expression);

            queryContext.GroupByComponents.Add(having);

            return having;
        }

        public static Having<TModel, TResult, TTable> Having<TModel, TResult, TTable>(
            this Having<TModel, TResult, TTable> subject,
            Expression<Func<TTable, bool>> expression) where TModel : PersistenceModel where TTable : Table
        {
            QueryContext<TModel, TResult> queryContext = subject.GetQueryContext();
            var having = new Having<TModel, TResult, TTable>(queryContext, expression);

            queryContext.GroupByComponents.Add(having);

            return having;
        }
    }
}
