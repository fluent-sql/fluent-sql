using System;
using System.Linq.Expressions;

using FluentSQL.Compilation.Parser;

namespace FluentSQL.Querying.Statements
{
    /// <summary>
    ///     A <c>JOIN</c>-statement of a query.
    /// </summary>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing this query.
    /// </typeparam>
    /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
    /// <typeparam name="TTable">The child table.</typeparam>
    public abstract class Join<TParameters, TQueryResult, TTable> : QueryComponent<TParameters, TQueryResult>
    {
        /// <summary>
        ///     Create a new <c>JOIN</c>-statement.
        /// </summary>
        /// <param name="queryContext">The <see cref="QueryContext{TParameters, TResult}" />.</param>
        /// <param name="child">
        ///     The <see cref="Expression{TDelegate}">Expression&lt;Func&lt;TTable&gt;&gt;</see> that selects the child to join with.
        /// </param>
        protected Join(QueryContext<TParameters, TQueryResult> queryContext, Expression<Func<TTable>> child)
            : base(queryContext)
        {
            Child = child;

            QueryContext.Components.Add(this);
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

        internal sealed override void Parse(QueryParser parser)
        {
            if (ImplicitTableExpression != null)
            {
                Parse(parser, Child, ImplicitTableExpression);
            }
            else
            {
                Parse(parser, Child, ExplicitTableExpression);
            }
        }

        /// <summary>
        ///     Parse this join.
        /// </summary>
        /// <param name="parser"></param>
        /// <param name="child">The expression to select the child.</param>
        /// <param name="expression">The join expression where the parent table is implied.</param>
        protected abstract void Parse(QueryParser parser, Expression<Func<TTable>> child,
            Expression<Func<bool>> expression);

        /// <summary>
        ///     Parse the compiler for processing this join.
        /// </summary>
        /// <param name="parser"></param>
        /// <param name="child">The expression to select the child.</param>
        /// <param name="expression">The join expression where the parent table is explicitly given.</param>
        protected abstract void Parse(QueryParser parser, Expression<Func<TTable>> child,
            Expression<Func<TTable, bool>> expression);

        private Expression<Func<TTable>> Child { get; }
        private Expression<Func<bool>> ImplicitTableExpression { get; set; }
        private Expression<Func<TTable, bool>> ExplicitTableExpression { get; set; }
    }
}
