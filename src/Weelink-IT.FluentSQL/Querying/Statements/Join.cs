using System;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Querying.Extensions;

namespace WeelinkIT.FluentSQL.Querying.Statements
{
    public abstract class Join<TParameters, TQueryResult, TTable> :
        QueryComponent<TParameters, TQueryResult>,
        ExtensionPoint<TParameters, TQueryResult, TTable>
        where TParameters : new()
    {
        protected Join(QueryContext<TParameters, TQueryResult> queryContext, Expression<Func<TTable>> child)
        {
            QueryContext = queryContext;
            Child = child;

            queryContext.JoinComponents.Add(this);
        }
        
        public Join<TParameters, TQueryResult, TTable> On(Expression<Func<bool>> expression)
        {
            ImplicitTableExpression = expression;
            return this;
        }

        public Join<TParameters, TQueryResult, TTable> On(Expression<Func<TTable, bool>> expression)
        {
            ExplicitTableExpression = expression;
            return this;
        }

        QueryContext<TParameters, TQueryResult> QueryComponent<TParameters, TQueryResult>.QueryContext
        {
            get { return QueryContext; }
        }

        private QueryContext<TParameters, TQueryResult> QueryContext { get; }
        private Expression<Func<TTable>> Child { get; }
        private Expression<Func<bool>> ImplicitTableExpression { get; set; }
        private Expression<Func<TTable, bool>> ExplicitTableExpression { get; set; }
    }
}
