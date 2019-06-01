using System;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Modelling;
using WeelinkIT.FluentSQL.Querying.Extensions;

namespace WeelinkIT.FluentSQL.Querying
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
    public sealed class Having<TModel, TParameters, TResult, TTable> :
        QueryComponent<TModel, TParameters, TResult>,
        ExtensionPoint<TModel, TParameters, TResult, TTable>
        where TTable : Table
        where TModel : PersistenceModel
        where TParameters : new()
    {
        /// <summary>
        ///     Create a new <c>HAVING</c>-statement.
        /// </summary>
        /// <param name="queryContext">The <see cref="QueryContext{TModel, TParameters, TResult}" />.</param>
        /// <param name="expression">The expression that represents the condition.</param>
        public Having(QueryContext<TModel, TParameters, TResult> queryContext, Expression<Func<TTable, TParameters, bool>> expression)
        {
            QueryContext = queryContext;
            Expression = expression;
        }

        private QueryContext<TModel, TParameters, TResult> QueryContext { get; }
        private Expression<Func<TTable, TParameters, bool>> Expression { get; }

        /// <inheritdoc />
        QueryContext<TModel, TParameters, TResult> QueryComponent<TModel, TParameters, TResult>.QueryContext
        {
            get { return QueryContext; }
        }
    }
}
