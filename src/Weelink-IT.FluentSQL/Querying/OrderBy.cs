using System;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Modelling;
using WeelinkIT.FluentSQL.Querying.Extensions;

namespace WeelinkIT.FluentSQL.Querying
{
    public sealed class OrderBy<TModel, TResult, TTable, TType> : QueryComponent<TModel, TResult>
        where TTable : Table
        where TModel : PersistenceModel
    {
        public OrderBy(QueryContext<TModel, TResult> queryContext, Expression<Func<TTable, Column<TType>>> expression,
            ExtensionPoint<TModel, TResult, TTable> previous)
        {
            QueryContext = queryContext;
            Expression = expression;
            Previous = previous;
        }

        public ExtensionPoint<TModel, TResult, TTable> Ascending
        {
            get { return Previous; }
        }

        public ExtensionPoint<TModel, TResult, TTable> Descending
        {
            get { return Previous; }
        }

        private QueryContext<TModel, TResult> QueryContext { get; }
        private Expression<Func<TTable, Column<TType>>> Expression { get; }
        private ExtensionPoint<TModel, TResult, TTable> Previous { get; }
        
        QueryContext<TModel, TResult> QueryComponent<TModel, TResult>.QueryContext
        {
            get { return QueryContext; }
        }
    }
}
