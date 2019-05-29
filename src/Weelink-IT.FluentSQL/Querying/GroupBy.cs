using System;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Modelling;
using WeelinkIT.FluentSQL.Querying.Extensions;

namespace WeelinkIT.FluentSQL.Querying
{
    /// <summary>
    ///     The <c>GROUP BY</c>-statement of a <see cref="Query{TResult}" />.
    /// </summary>
    /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
    /// <typeparam name="TResult">The result type of the <see cref="Query{TResult}" />.</typeparam>
    /// <typeparam name="TTable">The <see cref="Table" /> where to select <see cref="Column{TType}" />s from.</typeparam>
    /// <typeparam name="TType">The <see cref="Column{TType}" /> type.</typeparam>
    public sealed class GroupBy<TModel, TResult, TTable, TType> : QueryComponent<TModel, TResult>,
        ExtensionPoint<TModel, TResult, TTable>
        where TTable : Table
        where TModel : PersistenceModel
    {
        /// <summary>
        ///     Create a new <c>ORDER BY</c>-statement.
        /// </summary>
        /// <param name="queryContext">The <see cref="QueryContext{TModel, TResult}" />.</param>
        /// <param name="expression">The expression for selecting the <see cref="Column{TType}" />.</param>
        public GroupBy(QueryContext<TModel, TResult> queryContext, Expression<Func<TTable, Column<TType>>> expression)
        {
            QueryContext = queryContext;
            Expression = expression;
        }

        private QueryContext<TModel, TResult> QueryContext { get; }
        private Expression<Func<TTable, Column<TType>>> Expression { get; }

        /// <inheritdoc />
        QueryContext<TModel, TResult> QueryComponent<TModel, TResult>.QueryContext
        {
            get { return QueryContext; }
        }
    }
}
