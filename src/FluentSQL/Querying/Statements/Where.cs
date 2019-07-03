using System;
using System.Linq.Expressions;

using FluentSQL.Compilation.Parser;

namespace FluentSQL.Querying.Statements
{
    /// <summary>
    ///     The <c>WHERE</c>-statement of a query.
    /// </summary>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing this query.
    /// </typeparam>
    /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
    public class Where<TParameters, TQueryResult> : QueryComponent<TParameters, TQueryResult> where TParameters : new()
    {
        /// <summary>
        ///     Create a new <c>WHERE</c>-statement.
        /// </summary>
        /// <param name="queryContext">The <see cref="QueryContext{TParameters, TResult}" />.</param>
        /// <param name="expression">The expression that represents the condition.</param>
        internal Where(QueryContext<TParameters, TQueryResult> queryContext, Expression<Func<TParameters, bool>> expression)
            : base(queryContext)
        {
            Expression = expression;

            QueryContext.Components.Add(this);
        }

        internal override void Parse(QueryParser<TParameters, TQueryResult> parser)
        {
            parser.Where(Expression);
        }

        private Expression<Func<TParameters, bool>> Expression { get; }
    }
}
