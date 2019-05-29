using System;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Modelling;
using WeelinkIT.FluentSQL.Querying.Extensions;

namespace WeelinkIT.FluentSQL.Querying
{
    public sealed class Select<TModel, TResult, TTable, TType> : QueryComponent<TModel, TResult>,
        ExtensionPoint<TModel, TResult, TTable>
        where TTable : Table
        where TModel : PersistenceModel
    {
        public Select(QueryContext<TModel, TResult> queryContext, Expression<Func<TTable, Column<TType>>> expression)
        {
            QueryContext = queryContext;
            Expression = expression;
        }

        public Select<TModel, TResult, TTable, TType> As(string alias)
        {
            Alias = new Alias(alias);
            return this;
        }

        private QueryContext<TModel, TResult> QueryContext { get; }
        private Expression<Func<TTable, Column<TType>>> Expression { get; }
        private Alias Alias { get; set; }

        QueryContext<TModel, TResult> QueryComponent<TModel, TResult>.QueryContext
        {
            get { return QueryContext; }
        }
    }
}
