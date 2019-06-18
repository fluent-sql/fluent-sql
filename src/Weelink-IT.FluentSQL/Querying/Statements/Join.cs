using System;
using System.Linq.Expressions;

namespace WeelinkIT.FluentSQL.Querying.Statements
{
    /// <summary>
    ///     A <c>JOIN</c>-statement of a <see cref="Query{TParameters, TQueryResult}" />.
    /// </summary>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing this <see cref="Query{TParameters, TQueryResult}" />.
    /// </typeparam>
    /// <typeparam name="TQueryResult">The result type of the <see cref="Query{TParameters, TQueryResult}" />.</typeparam>
    /// <typeparam name="TTable">The child table.</typeparam>
    public abstract class Join<TParameters, TQueryResult, TTable> : QueryComponent<TParameters, TQueryResult> where TParameters : new()
    {
        /// <summary>
        ///     Create a new <c>JOIN</c>-statement.
        /// </summary>
        /// <param name="queryContext">The <see cref="QueryContext{TParameters, TResult}" />.</param>
        /// <param name="child">
        ///     The <see cref="Expression{TDelegate}">Expression&lt;Func&lt;TTable&gt;&gt;</see> that selects the child to join with.
        /// </param>
        protected Join(QueryContext<TParameters, TQueryResult> queryContext, Expression<Func<TTable>> child)
        {
            QueryContext = queryContext;
            Child = child;

            queryContext.JoinComponents.Add(this);
        }
        
        /// <summary>
        ///     Adds the <c>ON</c> to indicate on which columns to join.
        /// </summary>
        /// <param name="expression">
        ///     The <see cref="Expression{TDelegate}">Expression&lt;Func&lt;bool&gt;&gt;</see> that indicates on
        ///     which columns to join.
        /// </param>
        /// <returns><c>this</c> for method chaining.</returns>
        public Join<TParameters, TQueryResult, TTable> On(Expression<Func<bool>> expression)
        {
            ImplicitTableExpression = expression;
            return this;
        }

        /// <summary>
        ///     Adds the <c>ON</c> to indicate on which columns to join.
        /// </summary>
        /// <param name="expression">
        ///     The <see cref="Expression{TDelegate}">Expression&lt;Func&lt;TTable, bool&gt;&gt;</see> that indicates on
        ///     which columns to join.
        /// </param>
        /// <returns><c>this</c> for method chaining.</returns>
        public Join<TParameters, TQueryResult, TTable> On(Expression<Func<TTable, bool>> expression)
        {
            ExplicitTableExpression = expression;
            return this;
        }

        /// <inheritdoc />
        QueryContext<TParameters, TQueryResult> QueryComponent<TParameters, TQueryResult>.QueryContext
        {
            get { return QueryContext; }
        }

        private QueryContext<TParameters, TQueryResult> QueryContext { get; }
        private Expression<Func<TTable>> Child { get; }
        private Expression<Func<bool>> ImplicitTableExpression { get; set; }
        private Expression<Func<TTable, bool>> ExplicitTableExpression { get; set; }
    }
}
