using System;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.Extensions
{
    /// <summary>
    ///     Allows the construction of <see cref="From{TModel, TResult, TTable}" />s on a <see cref="QueryContext{TModel, TResult}" />.
    /// </summary>
    public static class FromExtensions
    {
        /// <summary>
        ///     The <c>FROM</c>-statement of a <see cref="Query{TResult}" />.
        /// </summary>
        /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
        /// <typeparam name="TResult">The result type of the <see cref="Query{TResult}" />.</typeparam>
        /// <typeparam name="TTable">The <see cref="Table" /> where to select <see cref="SqlExpression{TType}" />s from.</typeparam>
        /// <param name="subject">The <see cref="QueryContext{TModel, TResult}" />.</param>
        /// <param name="expression">The expression for selecting <typeparamref name="TTable" />.</param>
        /// <returns>The <see cref="WeelinkIT.FluentSQL.Querying.From{TModel, TResult, TTable}" />.</returns>
        public static From<TModel, TResult, TTable> From<TModel, TResult, TTable>(
            this QueryContext<TModel, TResult> subject,
            Expression<Func<TModel, TTable>> expression)
            where TTable : Table
            where TModel : PersistenceModel
        {
            var from = new From<TModel, TResult, TTable>(subject, expression);

            subject.FromComponents.Add(from);

            return from;
        }
    }
}
