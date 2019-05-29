using System;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Modelling;
using WeelinkIT.FluentSQL.Querying.Extensions;

namespace WeelinkIT.FluentSQL.Querying
{
    public sealed class Where<TModel, TResult, TTable> : QueryComponent<TModel, TResult>, ExtensionPoint<TModel, TResult, TTable>
        where TTable : Table
        where TModel : PersistenceModel
    {
        public Where(QueryContext<TModel, TResult> queryContext, Expression<Func<TTable, bool>> expression)
        {
            QueryContext = queryContext;
            Expression = expression;
        }

        private QueryContext<TModel, TResult> QueryContext { get; }
        private Expression<Func<TTable, bool>> Expression { get; }
        
        QueryContext<TModel, TResult> QueryComponent<TModel, TResult>.QueryContext
        {
            get { return QueryContext; }
        }
    }
}
