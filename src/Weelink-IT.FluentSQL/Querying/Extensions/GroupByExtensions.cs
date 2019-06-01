using System;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.Extensions
{
    /// <summary>
    ///     Allows the construction of <see cref="WeelinkIT.FluentSQL.Querying.GroupBy{TModel, TParameters, TResult, TTable, TType}" />s on
    ///     <see cref="ExtensionPoint{TModel, TParameters, TResult, TTable}" />s.
    /// </summary>
    public static class GroupByExtensions
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
        /// <param name="subject">The <see cref="ExtensionPoint{TModel, TParameters, TResult, TTable}" />.</param>
        /// <param name="expression">The expression for selecting the <see cref="SqlExpression{TType}" />.</param>
        /// <returns>The <see cref="WeelinkIT.FluentSQL.Querying.OrderBy{TModel, TParameters, TResult, TTable, TType}" />.</returns>
        public static GroupBy<TModel, TParameters, TResult, TTable, TType> GroupBy<TModel, TParameters, TResult, TTable, TType>(
            this ExtensionPoint<TModel, TParameters, TResult, TTable> subject,
            Expression<Func<TTable, SqlExpression<TType>>> expression)
            where TModel : PersistenceModel
            where TTable : Table
            where TParameters : new()
        {
            QueryContext<TModel, TParameters, TResult> queryContext = subject.GetQueryContext();
            var groupBy = new GroupBy<TModel, TParameters, TResult, TTable, TType>(queryContext, expression);

            queryContext.GroupByComponents.Add(groupBy);

            return groupBy;
        }
    }
}
