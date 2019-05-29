using System;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Modelling;
using WeelinkIT.FluentSQL.Querying.Extensions;

namespace WeelinkIT.FluentSQL.Querying
{
    /// <summary>
    ///     The <c>SELECT</c>-statement of a <see cref="Query{TResult}" />.
    /// </summary>
    /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
    /// <typeparam name="TResult">The result type of the <see cref="Query{TResult}" />.</typeparam>
    /// <typeparam name="TTable">The <see cref="Table" /> where to select <see cref="SqlExpression{TType}" />s from.</typeparam>
    /// <typeparam name="TType">The <see cref="SqlExpression{TType}" /> type.</typeparam>
    public sealed class Select<TModel, TResult, TTable, TType> : QueryComponent<TModel, TResult>,
        ExtensionPoint<TModel, TResult, TTable>
        where TTable : Table
        where TModel : PersistenceModel
    {
        /// <summary>
        ///     Create a new <c>SELECT</c>-statement.
        /// </summary>
        /// <param name="queryContext">The <see cref="QueryContext{TModel, TResult}" />.</param>
        /// <param name="expression">The expression for selecting the <see cref="SqlExpression{TType}" />.</param>
        public Select(QueryContext<TModel, TResult> queryContext, Expression<Func<TTable, TType>> expression)
        {
            QueryContext = queryContext;
            Expression = expression;
        }

        /// <summary>
        ///     Add an alias to <see cref="SqlExpression{TType}" />.
        /// </summary>
        /// <param name="alias">The alias to use.</param>
        /// <returns><c>this</c> for method chaining.</returns>
        public Select<TModel, TResult, TTable, TType> As(string alias)
        {
            Alias = new Alias(alias);
            return this;
        }

        private QueryContext<TModel, TResult> QueryContext { get; }
        private Expression<Func<TTable, TType>> Expression { get; }
        private Alias Alias { get; set; }

        /// <inheritdoc />
        QueryContext<TModel, TResult> QueryComponent<TModel, TResult>.QueryContext
        {
            get { return QueryContext; }
        }
    }
}
