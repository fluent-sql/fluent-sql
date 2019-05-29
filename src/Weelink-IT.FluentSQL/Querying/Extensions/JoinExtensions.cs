using System;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.Extensions
{
    public static class JoinExtensions
    {
        public static InnerJoin<TModel, TResult, TChild, TTable> InnerJoin<TModel, TResult, TChild, TTable>(
            this ExtensionPoint<TModel, TResult, TTable> subject, Expression<Func<TModel, TChild>> expression)
            where TChild : Table where TModel : PersistenceModel where TTable : Table
        {
            QueryContext<TModel, TResult> queryContext = subject.GetQueryContext();
            var innerJoin = new InnerJoin<TModel, TResult, TChild, TTable>(queryContext, expression);

            queryContext.JoinComponents.Add(innerJoin);

            return innerJoin;
        }

        public static OuterJoin<TModel, TResult, TChild, TTable> OuterJoin<TModel, TResult, TChild, TTable>(
            this ExtensionPoint<TModel, TResult, TTable> subject, Expression<Func<TModel, TChild>> expression)
            where TChild : Table where TModel : PersistenceModel where TTable : Table
        {
            QueryContext<TModel, TResult> queryContext = subject.GetQueryContext();
            var outerJoin = new OuterJoin<TModel, TResult, TChild, TTable>(queryContext, expression);

            queryContext.JoinComponents.Add(outerJoin);

            return outerJoin;
        }

        public static LeftJoin<TModel, TResult, TChild, TTable> LeftJoin<TModel, TResult, TChild, TTable>(
            this ExtensionPoint<TModel, TResult, TTable> subject, Expression<Func<TModel, TChild>> expression)
            where TChild : Table where TModel : PersistenceModel where TTable : Table
        {
            QueryContext<TModel, TResult> queryContext = subject.GetQueryContext();
            var leftJoin = new LeftJoin<TModel, TResult, TChild, TTable>(queryContext, expression);

            queryContext.JoinComponents.Add(leftJoin);

            return leftJoin;
        }
        
        public static RightJoin<TModel, TResult, TChild, TTable> RightJoin<TModel, TResult, TChild, TTable>(
            this ExtensionPoint<TModel, TResult, TTable> subject, Expression<Func<TModel, TChild>> expression)
            where TChild : Table where TModel : PersistenceModel where TTable : Table
        {
            QueryContext<TModel, TResult> queryContext = subject.GetQueryContext();
            var rightJoin = new RightJoin<TModel, TResult, TChild, TTable>(queryContext, expression);

            queryContext.JoinComponents.Add(rightJoin);

            return rightJoin;
        }
    }
}
