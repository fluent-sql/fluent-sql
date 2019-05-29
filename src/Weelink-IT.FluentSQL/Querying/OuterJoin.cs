using System;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying
{
    public sealed class OuterJoin<TModel, TResult, TChild, TParent> : QueryComponent<TModel, TResult>
        where TModel : PersistenceModel
        where TParent : Table
        where TChild : Table
    {
        public OuterJoin(QueryContext<TModel, TResult> queryContext, Expression<Func<TModel, TChild>> expression)
        {
            Expression = expression;
            QueryContext = queryContext;
        }
        
        public OuterJoin<TModel, TResult, TChild, TParent> As(string alias)
        {
            Alias = new Alias(alias);
            return this;
        }

        private QueryContext<TModel, TResult> QueryContext { get; }
        private Expression<Func<TChild, TParent, bool>> Condition { get; set; }
        private Expression<Func<TModel, TChild>> Expression { get; }
        private Alias Alias { get; set; }

        public From<TModel, TResult, TChild> On(Expression<Func<TChild, TParent, bool>> expression)
        {
            Condition = expression;
            var from = new From<TModel, TResult, TChild>(QueryContext, Expression);

            return from;
        }

        QueryContext<TModel, TResult> QueryComponent<TModel, TResult>.QueryContext
        {
            get { return QueryContext; }
        }
    }
}
