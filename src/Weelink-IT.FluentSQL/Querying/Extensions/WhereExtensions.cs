using System;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.Extensions
{
    /// <summary>
    ///     Allows the construction of <see cref="WeelinkIT.FluentSQL.Querying.Where{TModel, TResult, TTable}" />s on
    ///     <see cref="ExtensionPoint{TModel, TResult, TTable}" />s.
    /// </summary>
    public static class WhereExtensions
    {
        /// <summary>
        ///     The <c>WHERE</c>-statement of a <see cref="Query{TResult}" />.
        /// </summary>
        /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
        /// <typeparam name="TResult">The result type of the <see cref="Query{TResult}" />.</typeparam>
        /// <typeparam name="TTable">The <see cref="Table" /> where to apply the condition to.</typeparam>
        /// <param name="subject">The <see cref="ExtensionPoint{TModel, TResult, TTable}" />.</param>
        /// <param name="expression">The expression that represents the condition.</param>
        /// <returns>The <see cref="WeelinkIT.FluentSQL.Querying.Where{TModel, TResult, TTable}" />.</returns>
        public static Where<TModel, TResult, TTable> Where<TModel, TResult, TTable>(
            this ExtensionPoint<TModel, TResult, TTable> subject,
            Expression<Func<TTable, bool>> expression)
            where TModel : PersistenceModel where TTable : Table
        {
            QueryContext<TModel, TResult> queryContext = subject.GetQueryContext();
            var where = new Where<TModel, TResult, TTable>(queryContext, expression);

            queryContext.WhereComponents.Add(where);

            return where;
        }
    }
}
