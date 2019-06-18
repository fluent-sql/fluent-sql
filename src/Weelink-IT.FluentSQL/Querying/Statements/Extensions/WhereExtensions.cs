using System;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Querying.Extensions;

namespace WeelinkIT.FluentSQL.Querying.Statements.Extensions
{
    /// <summary>
    ///     Allows the construction of <see cref="WeelinkIT.FluentSQL.Querying.Statements.Where{TParameters, TResult}" />s.
    /// </summary>
    public static class WhereExtensions
    {
        /// <summary>
        ///     Add a new <c>WHERE</c> to the <see cref="Query{TParameters, TQueryResult}" />.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this <see cref="Query{TParameters, TQueryResult}" />.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the <see cref="Query{TParameters, TQueryResult}" />.</typeparam>
        /// <param name="queryComponent">The <see cref="QueryComponent{TParameters, TQueryResult}" />.</param>
        /// <param name="expression">
        ///     The <see cref="Expression{TDelegate}">Expression&lt;Func&lt;TTable, bool&gt;&gt;</see> that indicates on
        ///     which columns to join.
        /// </param>
        /// <returns>The <see cref="WeelinkIT.FluentSQL.Querying.Statements.Where{TParameters, TResult}" />.</returns>
        public static Where<TParameters, TQueryResult> Where<TParameters, TQueryResult>(
            this QueryComponent<TParameters, TQueryResult> queryComponent,
            Expression<Func<TParameters, bool>> expression)
            where TParameters : new()
        {
            return new Where<TParameters, TQueryResult>(queryComponent.QueryContext, expression);
        }

        /// <summary>
        ///     Add a new <c>WHERE</c> to the <see cref="Query{TParameters, TQueryResult}" />.
        /// </summary>
        /// <typeparam name="TQueryResult">The result type of the <see cref="Query{TParameters, TQueryResult}" />.</typeparam>
        /// <param name="queryComponent">The <see cref="QueryComponent{TParameters, TQueryResult}" />.</param>
        /// <param name="expression">
        ///     The <see cref="Expression{TDelegate}">Expression&lt;Func&lt;bool&gt;&gt;</see> that indicates on
        ///     which columns to join.
        /// </param>
        /// <returns>The <see cref="WeelinkIT.FluentSQL.Querying.Statements.Where{TParameters, TResult}" />.</returns>
        public static Where<NoParameters, TQueryResult> Where<TQueryResult>(
            this QueryComponent<NoParameters, TQueryResult> queryComponent,
            Expression<Func<bool>> expression)
        {
            return queryComponent.Where(expression.AddNoParameters());
        }
    }
}
