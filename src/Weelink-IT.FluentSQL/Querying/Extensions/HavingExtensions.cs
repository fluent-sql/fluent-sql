using System;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.Extensions
{
    /// <summary>
    ///     Allows the construction of <see cref="WeelinkIT.FluentSQL.Querying.Having{TModel, TResult, TTable}" />s on
    ///     <see cref="GroupBy{TModel, TResult, TTable, TType}" />s.
    /// </summary>
    public static class HavingExtensions
    {
        /// <summary>
        ///     The <c>HAVING</c>-statement of a <see cref="Query{TResult}" />.
        /// </summary>
        /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
        /// <typeparam name="TResult">The result type of the <see cref="Query{TResult}" />.</typeparam>
        /// <typeparam name="TTable">The <see cref="Table" /> where to apply the condition to.</typeparam>
        /// <typeparam name="TType">The <see cref="Column{TType}" /> type.</typeparam>
        /// <param name="subject">The <see cref="GroupBy{TModel, TResult, TTable, TType}" />.</param>
        /// <param name="expression">The expression that represents the condition.</param>
        /// <returns>The <see cref="WeelinkIT.FluentSQL.Querying.Having{TModel, TResult, TTable}" />.</returns>
        public static Having<TModel, TResult, TTable> Having<TModel, TResult, TTable, TType>(
            this GroupBy<TModel, TResult, TTable, TType> subject,
            Expression<Func<TTable, bool>> expression)
            where TModel : PersistenceModel
            where TTable : Table
        {
            QueryContext<TModel, TResult> queryContext = subject.GetQueryContext();
            var having = new Having<TModel, TResult, TTable>(queryContext, expression);

            queryContext.GroupByComponents.Add(having);

            return having;
        }

        /// <summary>
        ///     The <c>HAVING</c>-statement of a <see cref="Query{TResult}" />.
        /// </summary>
        /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
        /// <typeparam name="TResult">The result type of the <see cref="Query{TResult}" />.</typeparam>
        /// <typeparam name="TTable">The <see cref="Table" /> where to apply the condition to.</typeparam>
        /// <param name="subject">The <see cref="Having{TModel, TResult, TTable}" />.</param>
        /// <param name="expression">The expression that represents the condition.</param>
        /// <returns>The <see cref="WeelinkIT.FluentSQL.Querying.Having{TModel, TResult, TTable}" />.</returns>
        public static Having<TModel, TResult, TTable> Having<TModel, TResult, TTable>(
            this Having<TModel, TResult, TTable> subject,
            Expression<Func<TTable, bool>> expression)
            where TModel : PersistenceModel
            where TTable : Table
        {
            QueryContext<TModel, TResult> queryContext = subject.GetQueryContext();
            var having = new Having<TModel, TResult, TTable>(queryContext, expression);

            queryContext.GroupByComponents.Add(having);

            return having;
        }
    }
}
