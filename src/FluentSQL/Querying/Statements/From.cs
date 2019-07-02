using System;
using System.Linq.Expressions;

using FluentSQL.Compilation;
using FluentSQL.Modelling;

namespace FluentSQL.Querying.Statements
{
    /// <summary>
    ///     The <c>FROM</c>-statement of a query.
    /// </summary>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing this query.
    /// </typeparam>
    /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
    /// <typeparam name="TTable">
    ///     The table where to select <see cref="SqlExpression{TExpressionType}" />s from.
    /// </typeparam>
    public class From<TParameters, TQueryResult, TTable> : QueryComponent<TParameters, TQueryResult>
        where TParameters : new()
        where TTable : Table
    {
        /// <summary>
        ///     Create a new <c>FROM</c>-statement.
        /// </summary>
        /// <param name="queryContext">The <see cref="QueryContext{TParameters, TResult}" />.</param>
        /// <param name="expression">The expression for selecting <typeparamref name="TTable" />.</param>
        internal From(QueryContext<TParameters, TQueryResult> queryContext, Expression<Func<TTable>> expression)
            : base(queryContext)
        {
            Expression = expression;

            QueryContext.Components.Add(this);
        }

        internal override void Parse(QueryParser<TParameters, TQueryResult> parser)
        {
            parser.From(Expression);
        }

        private Expression<Func<TTable>> Expression { get; }
    }
}