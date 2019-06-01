using System;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.Extensions
{
    /// <summary>
    ///     Allows the construction of <see cref="From{TModel, TParameters, TResult, TTable}" />s on a <see cref="QueryContext{TModel, TParameters, TResult}" />.
    /// </summary>
    public static class FromExtensions
    {
        /// <summary>
        ///     The <c>FROM</c>-statement of a <see cref="Query{TParameters, TResult}" />.
        /// </summary>
        /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this <see cref="Query{TParameters, TResult}" />.
        /// </typeparam>
        /// <typeparam name="TResult">The result type of the <see cref="Query{TParameters, TResult}" />.</typeparam>
        /// <typeparam name="TTable">The <see cref="Table" /> where to select <see cref="SqlExpression{TType}" />s from.</typeparam>
        /// <param name="subject">The <see cref="QueryContext{TModel, TParameters, TResult}" />.</param>
        /// <param name="expression">The expression for selecting <typeparamref name="TTable" />.</param>
        /// <returns>The <see cref="WeelinkIT.FluentSQL.Querying.From{TModel, TParameters, TResult, TTable}" />.</returns>
        public static From<TModel, TParameters, TResult, TTable> From<TModel, TParameters, TResult, TTable>(
            this QueryContext<TModel, TParameters, TResult> subject,
            Expression<Func<TModel, TTable>> expression)
            where TTable : Table
            where TModel : PersistenceModel
            where TParameters : new()
        {
            var from = new From<TModel, TParameters, TResult, TTable>(subject, expression);

            subject.FromComponents.Add(from);

            return from;
        }
    }
}
