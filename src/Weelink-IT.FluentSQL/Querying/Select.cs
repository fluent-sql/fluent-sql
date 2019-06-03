using System;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Modelling;
using WeelinkIT.FluentSQL.Querying.Extensions;

namespace WeelinkIT.FluentSQL.Querying
{
    /// <summary>
    ///     The <c>SELECT</c>-statement of a <see cref="Query{TParameters, TResult}" />.
    /// </summary>
    /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing this <see cref="Query{TParameters, TResult}" />.
    /// </typeparam>
    /// <typeparam name="TResult">The result type of the <see cref="Query{TParameters, TResult}" />.</typeparam>
    /// <typeparam name="TTable">The <see cref="Table" /> where to select <see cref="SqlExpression{TType}" />s from.</typeparam>
    /// <typeparam name="TType">The <see cref="SqlExpression{TType}" /> type.</typeparam>
    public sealed class Select<TModel, TParameters, TResult, TTable, TType> :
        QueryComponent<TModel, TParameters, TResult>,
        ExtensionPoint<TModel, TParameters, TResult, TTable, TType>
        where TTable : Table
        where TModel : PersistenceModel
        where TParameters : new()
    {
        /// <summary>
        ///     Create a new <c>SELECT</c>-statement.
        /// </summary>
        /// <param name="queryContext">The <see cref="QueryContext{TModel, TParameters, TResult}" />.</param>
        /// <param name="expression">The expression for selecting the <see cref="SqlExpression{TType}" />.</param>
        public Select(QueryContext<TModel, TParameters, TResult> queryContext, Expression<Func<TTable, TType>> expression)
        {
            QueryContext = queryContext;
            Expression = expression;
        }

        /// <summary>
        ///     Add an alias to <see cref="SqlExpression{TType}" />.
        /// </summary>
        /// <param name="alias">The alias to use.</param>
        /// <returns><c>this</c> for method chaining.</returns>
        public Select<TModel, TParameters, TResult, TTable, TType> As(string alias)
        {
            Alias = new Alias(alias);
            return this;
        }

        private QueryContext<TModel, TParameters, TResult> QueryContext { get; }
        private Expression<Func<TTable, TType>> Expression { get; }
        private Alias Alias { get; set; }

        /// <inheritdoc />
        QueryContext<TModel, TParameters, TResult> QueryComponent<TModel, TParameters, TResult>.QueryContext
        {
            get { return QueryContext; }
        }
    }
}
