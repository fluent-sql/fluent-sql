using System;
using System.Linq.Expressions;

namespace FluentSQL.Querying.Statements
{
    /// <summary>
    ///     The <c>LEFT JOIN</c>-statement of a query.
    /// </summary>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing this query.
    /// </typeparam>
    /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
    /// <typeparam name="TTable">The child table.</typeparam>
    public class LeftJoin<TParameters, TQueryResult, TTable> : Join<TParameters, TQueryResult, TTable> where TParameters : new()
    {
        /// <summary>
        ///     Create a new <c>LEFT JOIN</c>-statement.
        /// </summary>
        /// <param name="queryContext">The <see cref="QueryContext{TParameters, TResult}" />.</param>
        /// <param name="child">
        ///     The <see cref="Expression{TDelegate}">Expression&lt;Func&lt;TTable&gt;&gt;</see> that selects the child to join with.
        /// </param>
        internal LeftJoin(QueryContext<TParameters, TQueryResult> queryContext, Expression<Func<TTable>> child)
            : base(queryContext, child)
        {
        }
    }
}
