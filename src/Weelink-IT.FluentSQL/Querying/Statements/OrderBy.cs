using System;
using System.Linq.Expressions;

namespace WeelinkIT.FluentSQL.Querying.Statements
{
    public class OrderBy<TParameters, TQueryResult, TSqlExpression> :
        QueryComponent<TParameters, TQueryResult>
        where TParameters : new()
    {
        public OrderBy(QueryContext<TParameters, TQueryResult> queryContext, Expression<Func<TSqlExpression>> expression)
        {
            QueryContext = queryContext;
            Expression = expression;
        }

        public OrderBy<TParameters, TQueryResult, TSqlExpression> Ascending
        {
            get { return this; }
        }

        public OrderBy<TParameters, TQueryResult, TSqlExpression> Descending
        {
            get { return this; }
        }

        QueryContext<TParameters, TQueryResult> QueryComponent<TParameters, TQueryResult>.QueryContext
        {
            get { return QueryContext; }
        }

        private QueryContext<TParameters, TQueryResult> QueryContext { get; }
        private Expression<Func<TSqlExpression>> Expression { get; }
    }
}
