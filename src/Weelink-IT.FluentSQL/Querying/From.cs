using System;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Modelling;
using WeelinkIT.FluentSQL.Querying.Extensions;

namespace WeelinkIT.FluentSQL.Querying
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
    public sealed class From<TModel, TParameters, TResult, TTable> : QueryComponent<TModel, TParameters, TResult>,
        ExtensionPoint<TModel, TParameters, TResult>, ExtensionPoint<TModel, TParameters, TResult, TTable>
        where TModel : PersistenceModel
        where TTable : Table
        where TParameters : new()
    {
        /// <summary>
        ///     Create a new <c>FROM</c>-statement.
        /// </summary>
        /// <param name="queryContext">The <see cref="QueryContext{TModel, TParameters, TResult}" />.</param>
        /// <param name="expression">The expression for selecting <typeparamref name="TTable" />.</param>
        public From(QueryContext<TModel, TParameters, TResult> queryContext, Expression<Func<TModel, TTable>> expression)
        {
            QueryContext = queryContext;
            Expression = expression;
        }

        /// <summary>
        ///     Add an alias to <typeparamref name="TTable"/> />.
        /// </summary>
        /// <param name="alias">The alias to use.</param>
        /// <returns><c>this</c> for method chaining.</returns>
        public From<TModel, TParameters, TResult, TTable> As(string alias)
        {
            Alias = new Alias(alias);
            return this;
        }

        private QueryContext<TModel, TParameters, TResult> QueryContext { get; }
        private Expression<Func<TModel, TTable>> Expression { get; }
        private Alias Alias { get; set; }

        /// <inheritdoc />
        QueryContext<TModel, TParameters, TResult> QueryComponent<TModel, TParameters, TResult>.QueryContext
        {
            get { return QueryContext; }
        }
    }
}
