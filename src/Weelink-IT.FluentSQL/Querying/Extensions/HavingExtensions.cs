using System;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.Extensions
{
    /// <summary>
    ///     Allows the construction of <see cref="WeelinkIT.FluentSQL.Querying.Having{TModel, TParameters, TResult, TTable}" />s on
    ///     <see cref="GroupBy{TModel, TParameters, TResult, TTable, TType}" />s.
    /// </summary>
    public static class HavingExtensions
    {
        /// <summary>
        ///     The <c>HAVING</c>-statement of a <see cref="Query{TParameters, TResult}" />.
        /// </summary>
        /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this <see cref="Query{TParameters, TResult}" />.
        /// </typeparam>
        /// <typeparam name="TResult">The result type of the <see cref="Query{TParameters, TResult}" />.</typeparam>
        /// <typeparam name="TTable">The <see cref="Table" /> where to apply the condition to.</typeparam>
        /// <typeparam name="TType">The <see cref="SqlExpression{TType}" /> type.</typeparam>
        /// <param name="subject">The <see cref="GroupBy{TModel, TParameters, TResult, TTable, TType}" />.</param>
        /// <param name="expression">The expression that represents the condition.</param>
        /// <returns>The <see cref="WeelinkIT.FluentSQL.Querying.Having{TModel, TParameters, TResult, TTable}" />.</returns>
        public static Having<TModel, TParameters, TResult, TTable> Having<TModel, TParameters, TResult, TTable, TType>(
            this GroupBy<TModel, TParameters, TResult, TTable, TType> subject,
            Expression<Func<TTable, TParameters, bool>> expression)
            where TModel : PersistenceModel
            where TTable : Table
            where TParameters : new()
        {
            QueryContext<TModel, TParameters, TResult> queryContext = subject.GetQueryContext();
            var having = new Having<TModel, TParameters, TResult, TTable>(queryContext, expression);

            queryContext.GroupByComponents.Add(having);

            return having;
        }

        /// <summary>
        ///     The <c>HAVING</c>-statement of a <see cref="Query{TParameters, TResult}" />.
        /// </summary>
        /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this <see cref="Query{TParameters, TResult}" />.
        /// </typeparam>
        /// <typeparam name="TResult">The result type of the <see cref="Query{TParameters, TResult}" />.</typeparam>
        /// <typeparam name="TTable">The <see cref="Table" /> where to apply the condition to.</typeparam>
        /// <param name="subject">The <see cref="Having{TModel, TParameters, TResult, TTable}" />.</param>
        /// <param name="expression">The expression that represents the condition.</param>
        /// <returns>The <see cref="WeelinkIT.FluentSQL.Querying.Having{TModel, TParameters, TResult, TTable}" />.</returns>
        public static Having<TModel, TParameters, TResult, TTable> Having<TModel, TParameters, TResult, TTable>(
            this Having<TModel, TParameters, TResult, TTable> subject,
            Expression<Func<TTable, TParameters, bool>> expression)
            where TModel : PersistenceModel
            where TTable : Table
            where TParameters : new()
        {
            QueryContext<TModel, TParameters, TResult> queryContext = subject.GetQueryContext();
            var having = new Having<TModel, TParameters, TResult, TTable>(queryContext, expression);

            queryContext.GroupByComponents.Add(having);

            return having;
        }


        /// <summary>
        ///     The <c>HAVING</c>-statement of a <see cref="Query{TParameters, TResult}" />.
        /// </summary>
        /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
        /// <typeparam name="TResult">The result type of the <see cref="Query{TParameters, TResult}" />.</typeparam>
        /// <typeparam name="TTable">The <see cref="Table" /> where to apply the condition to.</typeparam>
        /// <param name="subject">The <see cref="Having{TModel, TParameters, TResult, TTable}" />.</param>
        /// <param name="expression">The expression that represents the condition.</param>
        /// <returns>The <see cref="WeelinkIT.FluentSQL.Querying.Having{TModel, TParameters, TResult, TTable}" />.</returns>
        public static Having<TModel, NoParameters, TResult, TTable> Having<TModel, TResult, TTable>(
            this Having<TModel, NoParameters, TResult, TTable> subject,
            Expression<Func<TTable, bool>> expression)
            where TModel : PersistenceModel
            where TTable : Table
        {
            return subject.Having(expression.AddNoParameters());
        }
    }
}
