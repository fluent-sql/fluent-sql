using System;
using System.Linq.Expressions;

using FluentSQL.Compilation.Parser;

namespace FluentSQL.Querying.Statements
{
    /// <summary>
    ///     The <c>GROUP BY</c>-statement of a query.
    /// </summary>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing this query.
    /// </typeparam>
    /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
    /// <typeparam name="TSqlExpression">The expression to group by.</typeparam>
    public class GroupBy<TParameters, TQueryResult, TSqlExpression> :
        QueryComponent<TParameters, TQueryResult>
        where TParameters : new()
    {
        /// <summary>
        ///     Create a new <c>GROUP BY</c>-statement.
        /// </summary>
        /// <param name="queryContext">The <see cref="QueryContext{TParameters, TResult}" />.</param>
        /// <param name="expression">The <see cref="Expression{TDelegate}" /> to select.</param>
        internal GroupBy(QueryContext<TParameters, TQueryResult> queryContext, Expression<Func<TSqlExpression>> expression)
            : base(queryContext)
        {
            Expression = expression;

            QueryContext.Components.Add(this);
        }

        internal override void Parse(QueryParser parser)
        {
            parser.GroupBy(Expression);
        }

        private Expression<Func<TSqlExpression>> Expression { get; }
    }
}
