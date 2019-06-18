using System;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.Extensions
{
    /// <summary>
    ///     Allows the construction of <see cref="WeelinkIT.FluentSQL.Querying.Where{TModel, TParameters, TResult, TTable}" />s on
    ///     <see cref="ExtensionPoint{TModel, TParameters, TResult, TTable}" />s.
    /// </summary>
    public static class WhereExtensions
    {
        /// <summary>
        ///     The <c>WHERE</c>-statement of a <see cref="Query{TParameters, TResult}" />.
        /// </summary>
        /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this <see cref="Query{TParameters, TResult}" />.
        /// </typeparam>
        /// <typeparam name="TResult">The result type of the <see cref="Query{TParameters, TResult}" />.</typeparam>
        /// <typeparam name="TTable">The <see cref="Table" /> where to apply the condition to.</typeparam>
        /// <param name="subject">The <see cref="ExtensionPoint{TModel, TParameters, TResult, TTable}" />.</param>
        /// <param name="expression">The expression that represents the condition.</param>
        /// <returns>The <see cref="WeelinkIT.FluentSQL.Querying.Where{TModel, TParameters, TResult, TTable}" />.</returns>
        public static Where<TModel, TParameters, TResult, TTable> Where<TModel, TParameters, TResult, TTable>(
            this ExtensionPoint<TModel, TParameters, TResult, TTable> subject,
            Expression<Func<TTable, TParameters, bool>> expression)
            where TModel : PersistenceModel
            where TTable : Table
            where TParameters : new()
        {
            QueryContext<TModel, TParameters, TResult> queryContext = subject.GetQueryContext();
            var where = new Where<TModel, TParameters, TResult, TTable>(queryContext, expression);

            queryContext.WhereComponents.Add(where);

            return where;
        }

        /// <summary>
        ///     The <c>WHERE</c>-statement of a <see cref="Query{TParameters, TResult}" />.
        /// </summary>
        /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
        /// <typeparam name="TResult">The result type of the <see cref="Query{TParameters, TResult}" />.</typeparam>
        /// <typeparam name="TTable">The <see cref="Table" /> where to apply the condition to.</typeparam>
        /// <param name="subject">The <see cref="ExtensionPoint{TModel, TParameters, TResult, TTable}" />.</param>
        /// <param name="expression">The expression that represents the condition.</param>
        /// <returns>The <see cref="WeelinkIT.FluentSQL.Querying.Where{TModel, TParameters, TResult, TTable}" />.</returns>
        public static Where<TModel, NoParameters, TResult, TTable> Where<TModel, TResult, TTable>(
            this ExtensionPoint<TModel, NoParameters, TResult, TTable> subject,
            Expression<Func<TTable, bool>> expression)
            where TModel : PersistenceModel
            where TTable : Table
        {
            return subject.Where(expression.AddNoParameters());
        }
    }
}
