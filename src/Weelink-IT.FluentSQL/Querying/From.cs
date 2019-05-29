using System;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Modelling;
using WeelinkIT.FluentSQL.Querying.Extensions;

namespace WeelinkIT.FluentSQL.Querying
{
    public sealed class From<TModel, TResult, TTable> : QueryComponent<TModel, TResult>,
        ExtensionPoint<TModel, TResult>, ExtensionPoint<TModel, TResult, TTable>
        where TModel : PersistenceModel
        where TTable : Table
    {
        public From(QueryContext<TModel, TResult> queryContext, Expression<Func<TModel, TTable>> expression)
        {
            QueryContext = queryContext;
            Expression = expression;
        }

        private QueryContext<TModel, TResult> QueryContext { get; }
        private Expression<Func<TModel, TTable>> Expression { get; }
        
        QueryContext<TModel, TResult> QueryComponent<TModel, TResult>.QueryContext
        {
            get { return QueryContext; }
        }
    }
}
