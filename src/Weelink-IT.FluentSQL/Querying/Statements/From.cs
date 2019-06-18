using System;
using System.Linq.Expressions;

namespace WeelinkIT.FluentSQL.Querying.Statements
{
    /// <summary>
    ///     The <c>FROM</c>-statement of a <see cref="Query{TParameters, TResult}" />.
    /// </summary>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing this <see cref="Query{TParameters, TResult}" />.
    /// </typeparam>
    /// <typeparam name="TQueryResult">The result type of the <see cref="Query{TParameters, TResult}" />.</typeparam>
    /// <typeparam name="TTable">
    ///     The <see cref="Expression" /> where to select <see cref="WeelinkIT.FluentSQL.Modelling.SqlExpression{TExpressionType}" />s from.
    /// </typeparam>
    public class From<TParameters, TQueryResult, TTable> : QueryComponent<TParameters, TQueryResult> where TParameters : new()
    {
        /// <summary>
        ///     Create a new <c>FROM</c>-statement.
        /// </summary>
        /// <param name="queryContext">The <see cref="QueryContext{TParameters, TResult}" />.</param>
        /// <param name="expression">The expression for selecting <typeparamref name="TTable" />.</param>
        public From(QueryContext<TParameters, TQueryResult> queryContext, Expression<Func<TTable>> expression)
        {
            QueryContext = queryContext;
            Expression = expression;

            QueryContext.FromComponents.Add(this);
        }

        /// <inheritdoc />
        QueryContext<TParameters, TQueryResult> QueryComponent<TParameters, TQueryResult>.QueryContext
        {
            get { return QueryContext; }
        }

        private QueryContext<TParameters, TQueryResult> QueryContext { get; }
        private Expression<Func<TTable>> Expression { get; }
    }
}