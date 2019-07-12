using System;
using System.Linq.Expressions;

using FluentSQL.Compilation.Parser;
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
        
        /// <summary>
        ///     Sets the alias under which this table will be known.
        /// </summary>
        /// <param name="alias">The alias.</param>
        /// <returns><c>this</c> for method chaining.</returns>
        public From<TParameters, TQueryResult, TTable> As(string alias)
        {
            Alias = new Alias(alias);
            return this;
        }

        internal override void Parse(QueryParser parser)
        {
            if (Alias != null)
            {
                parser.From(Expression, Alias);
            }
            else
            {
                parser.From(Expression);
            }
        }

        private Expression<Func<TTable>> Expression { get; }
        private Alias Alias { get; set; }
    }
}