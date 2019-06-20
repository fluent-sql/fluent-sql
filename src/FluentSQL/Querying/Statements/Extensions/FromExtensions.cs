using System;
using System.Linq.Expressions;

using FluentSQL.Modelling;

namespace FluentSQL.Querying.Statements.Extensions
{
    /// <summary>
    ///     Adds <c>FROM</c> to a query.
    /// </summary>
    public static class FromExtensions
    {
        /// <summary>
        ///     Add a new <c>FROM</c> to the query.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this query.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <typeparam name="TTable">
        ///     The <see cref="Expression" /> where to select
        ///     <see cref="SqlExpression{TExpressionType}" />s from.
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
