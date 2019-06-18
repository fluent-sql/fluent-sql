using System;
using System.Linq.Expressions;

namespace WeelinkIT.FluentSQL.Querying.Statements
{
    public class Select<TParameters, TQueryResult, TSqlExpression> :
        QueryComponent<TParameters, TQueryResult>
        where TParameters : new()
    {
        public Select(QueryContext<TParameters, TQueryResult> queryContext, Expression<Func<TSqlExpression>> expression)
        {
            QueryContext = queryContext;
            Expression = expression;
        }

        public Select<TParameters, TQueryResult, TSqlExpression> As(string alias)
        {
            Alias = new Alias(alias);
            return this;
        }
  
        public Select<TParameters, TQueryResult, TSqlExpression> As(Expression<Func<TQueryResult, object>> alias)
        {
            Alias = new Alias("TODO");
            return this;
        }
  
        QueryContext<TParameters, TQueryResult> QueryComponent<TParameters, TQueryResult>.QueryContext
        {
            get { return QueryContext; }
        }

        private QueryContext<TParameters, TQueryResult> QueryContext { get; }
        private Expression<Func<TSqlExpression>> Expression { get; }
        private Alias Alias { get; set; }
    }
}
