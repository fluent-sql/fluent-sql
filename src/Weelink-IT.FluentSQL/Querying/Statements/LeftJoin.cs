using System;
using System.Linq.Expressions;

namespace WeelinkIT.FluentSQL.Querying.Statements
{
    /// <summary>
    ///     The <c>LEFT JOIN</c>-statement of a <see cref="Query{TParameters, TQueryResult}" />.
    /// </summary>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing this <see cref="Query{TParameters, TQueryResult}" />.
    /// </typeparam>
    /// <typeparam name="TQueryResult">The result type of the <see cref="Query{TParameters, TQueryResult}" />.</typeparam>
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
        public LeftJoin(QueryContext<TParameters, TQueryResult> queryContext, Expression<Func<TTable>> child)
            : base(queryContext, child)
        {
        }
    }
}
