using System;
using System.Linq.Expressions;

namespace WeelinkIT.FluentSQL.Querying.Statements.Extensions
{
    /// <summary>
    ///     Allows the construction of <see cref="WeelinkIT.FluentSQL.Querying.Statements.From{TParameters, TResult, TTable}" />s.
    /// </summary>
    public static class FromExtensions
    {
        /// <summary>
        ///     Add a new <c>FROM</c> to the <see cref="Query{TParameters, TQueryResult}" />.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this <see cref="Query{TParameters, TQueryResult}" />.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the <see cref="Query{TParameters, TQueryResult}" />.</typeparam>
        /// <typeparam name="TTable">
        ///     The <see cref="Expression" /> where to select
        ///     <see cref="WeelinkIT.FluentSQL.Modelling.SqlExpression{TExpressionType}" />s from.
        /// </typeparam>
        /// <param name="queryContext">The <see cref="QueryContext{TParameters, TQueryResult}" />.</param>
        /// <param name="table">The expression for selecting <typeparamref name="TTable" />.</param>
        /// <returns>The <see cref="From{TParameters, TQueryResult, TTable}" />.</returns>
        public static From<TParameters, TQueryResult, TTable> From<TParameters, TQueryResult, TTable>(
            this QueryContext<TParameters, TQueryResult> queryContext, Expression<Func<TTable>> table) where TParameters : new()
        {
            return new From<TParameters, TQueryResult, TTable>(queryContext, table);
        }
    }
}
