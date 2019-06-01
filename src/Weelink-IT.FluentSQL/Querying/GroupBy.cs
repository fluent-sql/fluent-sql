using System;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Modelling;
using WeelinkIT.FluentSQL.Querying.Extensions;

namespace WeelinkIT.FluentSQL.Querying
{
    /// <summary>
    ///     The <c>GROUP BY</c>-statement of a <see cref="Query{TParameters, TResult}" />.
    /// </summary>
    /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing this <see cref="Query{TParameters, TResult}" />.
    /// </typeparam>
    /// <typeparam name="TResult">The result type of the <see cref="Query{TParameters, TResult}" />.</typeparam>
    /// <typeparam name="TTable">The <see cref="Table" /> where to select <see cref="SqlExpression{TType}" />s from.</typeparam>
    /// <typeparam name="TType">The <see cref="SqlExpression{TType}" /> type.</typeparam>
    public sealed class GroupBy<TModel, TParameters, TResult, TTable, TType> : QueryComponent<TModel, TParameters, TResult>,
        ExtensionPoint<TModel, TParameters, TResult, TTable>
        where TTable : Table
        where TModel : PersistenceModel
        where TParameters : new()
    {
        /// <summary>
        ///     Create a new <c>GROUP BY</c>-statement.
        /// </summary>
        /// <param name="queryContext">The <see cref="QueryContext{TModel, TParameters, TResult}" />.</param>
        /// <param name="expression">The expression for selecting the <see cref="SqlExpression{TType}" />.</param>
        public GroupBy(QueryContext<TModel, TParameters, TResult> queryContext, Expression<Func<TTable, SqlExpression<TType>>> expression)
        {
            QueryContext = queryContext;
            Expression = expression;
        }

        /// <summary>
        ///     Create a new <c>GROUP BY</c>-statement for a <see cref="Select{TModel, TParameters, TResult, TTable, TType}" />.
        /// </summary>
        /// <param name="queryContext">The <see cref="QueryContext{TModel, TParameters, TResult}" />.</param>
        /// <param name="select">
        ///     The <see cref="Select{TModel, TParameters, TResult, TTable, TType}" /> containing the <see cref="Column{TType}" /> to group by.
        /// </param>
        public GroupBy(QueryContext<TModel, TParameters, TResult> queryContext, Select<TModel, TParameters, TResult, TTable, TType> select)
        {
            QueryContext = queryContext;
            Select = select;
        }

        private QueryContext<TModel, TParameters, TResult> QueryContext { get; }
        private Expression<Func<TTable, SqlExpression<TType>>> Expression { get; }
        private Select<TModel, TParameters, TResult, TTable, TType> Select { get; }

        /// <inheritdoc />
        QueryContext<TModel, TParameters, TResult> QueryComponent<TModel, TParameters, TResult>.QueryContext
        {
            get { return QueryContext; }
        }
    }
}
