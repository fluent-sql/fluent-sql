using System;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Modelling;
using WeelinkIT.FluentSQL.Querying.Extensions;

namespace WeelinkIT.FluentSQL.Querying
{
    /// <summary>
    ///     The <c>ORDER BY</c>-statement of a <see cref="Query{TResult}" />.
    /// </summary>
    /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
    /// <typeparam name="TResult">The result type of the <see cref="Query{TResult}" />.</typeparam>
    /// <typeparam name="TTable">The <see cref="Table" /> where to select <see cref="Column{TType}" />s from.</typeparam>
    /// <typeparam name="TType">The <see cref="Column{TType}" /> type.</typeparam>
    public sealed class OrderBy<TModel, TResult, TTable, TType> : QueryComponent<TModel, TResult>
        where TTable : Table
        where TModel : PersistenceModel
    {
        /// <summary>
        ///     Create a new <c>ORDER BY</c>-statement.
        /// </summary>
        /// <param name="queryContext">The <see cref="QueryContext{TModel, TResult}" />.</param>
        /// <param name="expression">The expression for selecting the <see cref="Column{TType}" />.</param>
        /// <param name="previous">The previous <see cref="ExtensionPoint{TModel, TResult}" />, for method chaining.</param>
        public OrderBy(QueryContext<TModel, TResult> queryContext, Expression<Func<TTable, Column<TType>>> expression,
            ExtensionPoint<TModel, TResult, TTable> previous)
        {
            QueryContext = queryContext;
            Expression = expression;
            Previous = previous;
        }

        /// <summary>
        ///     Order by the <see cref="Column{TType}" /> ascending.
        /// </summary>
        public ExtensionPoint<TModel, TResult, TTable> Ascending
        {
            get { return Previous; }
        }

        /// <summary>
        ///     Order by the <see cref="Column{TType}" /> descending.
        /// </summary>
        public ExtensionPoint<TModel, TResult, TTable> Descending
        {
            get { return Previous; }
        }

        private QueryContext<TModel, TResult> QueryContext { get; }
        private Expression<Func<TTable, Column<TType>>> Expression { get; }
        private ExtensionPoint<TModel, TResult, TTable> Previous { get; }
        
        /// <inheritdoc />
        QueryContext<TModel, TResult> QueryComponent<TModel, TResult>.QueryContext
        {
            get { return QueryContext; }
        }
    }
}
