using System;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Modelling;
using WeelinkIT.FluentSQL.Querying.Extensions;

namespace WeelinkIT.FluentSQL.Querying
{
    /// <summary>
    ///     The <c>FROM</c>-statement of a <see cref="Query{TResult}" />.
    /// </summary>
    /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
    /// <typeparam name="TResult">The result type of the <see cref="Query{TResult}" />.</typeparam>
    /// <typeparam name="TTable">The <see cref="Table" /> where to select <see cref="Column{TType}" />s from.</typeparam>
    public sealed class From<TModel, TResult, TTable> : QueryComponent<TModel, TResult>,
        ExtensionPoint<TModel, TResult>, ExtensionPoint<TModel, TResult, TTable>
        where TModel : PersistenceModel
        where TTable : Table
    {
        /// <summary>
        ///     Create a new <c>FROM</c>-statement.
        /// </summary>
        /// <param name="queryContext">The <see cref="QueryContext{TModel, TResult}" />.</param>
        /// <param name="expression">The expression for selecting <typeparamref name="TTable" />.</param>
        public From(QueryContext<TModel, TResult> queryContext, Expression<Func<TModel, TTable>> expression)
        {
            QueryContext = queryContext;
            Expression = expression;
        }

        private QueryContext<TModel, TResult> QueryContext { get; }
        private Expression<Func<TModel, TTable>> Expression { get; }
        
        /// <inheritdoc />
        QueryContext<TModel, TResult> QueryComponent<TModel, TResult>.QueryContext
        {
            get { return QueryContext; }
        }
    }
}
