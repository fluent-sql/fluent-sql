using System;
using System.Linq.Expressions;

using FluentSQL.Modelling;

namespace FluentSQL.Querying.Statements.Extensions
{
    /// <summary>
    ///     Adds <c>JOIN</c> to a query.
    /// </summary>
    public static class JoinExtensions
    {
        /// <summary>
        ///     Add a new <c>LEFT JOIN</c> to the query.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this query.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <typeparam name="TTable">The child table.</typeparam>
        /// <param name="queryComponent">The <see cref="QueryComponent{TParameters, TQueryResult}" />.</param>
        /// <param name="child">
        ///     The <see cref="Expression{TDelegate}">Expression&lt;Func&lt;TTable&gt;&gt;</see> that selects the child to join with.
        /// </param>
        /// <returns>The <see cref="Statements.LeftJoin{TParameters,TQueryResult,TTable}" />.</returns>
        public static LeftJoin<TParameters, TQueryResult, TTable> LeftJoin<TParameters, TQueryResult, TTable>(
            this QueryComponent<TParameters, TQueryResult> queryComponent,
            Expression<Func<TTable>> child)
        {
            return new LeftJoin<TParameters, TQueryResult, TTable>(queryComponent.QueryContext, child);
        }

        /// <summary>
        ///     Add a new <c>LEFT JOIN</c> with a subquery to the query.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this query.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <typeparam name="TSubqueryResult">The result type of the <paramref name="child" />.</typeparam>
        /// <param name="queryComponent">The <see cref="QueryComponent{TParameters, TQueryResult}" />.</param>
        /// <param name="child">
        ///     The <see cref="Expression{TDelegate}">Expression&lt;Func&lt;Query&lt;TParameters, TSubqueryResult&gt;&gt;&gt;</see>
        ///     that selects the child to join with.
        /// </param>
        /// <returns>The <see cref="Statements.LeftJoin{TParameters,TQueryResult,TTable}" />.</returns>
        public static LeftJoin<TParameters, TQueryResult, TSubqueryResult> LeftJoin<TParameters, TQueryResult, TSubqueryResult>(
            this QueryComponent<TParameters, TQueryResult> queryComponent,
            Expression<Func<Query<TParameters, TSubqueryResult>>> child)
        {
            var subquery = new Subquery<TParameters, TSubqueryResult>(child);

            return new LeftJoin<TParameters, TQueryResult, TSubqueryResult>(queryComponent.QueryContext, () => subquery.QueryResult);
        }

        /// <summary>
        ///     Add a new <c>LEFT JOIN</c> with a subquery to the query.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this query.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <typeparam name="TSubqueryResult">The result type of the <paramref name="child" />.</typeparam>
        /// <param name="queryComponent">The <see cref="QueryComponent{TParameters, TQueryResult}" />.</param>
        /// <param name="child">
        ///     The <see cref="Expression{TDelegate}">Expression&lt;Func&lt;Query&lt;TSubqueryResult&gt;&gt;&gt;</see>
        ///     that selects the child to join with.
        /// </param>
        /// <returns>The <see cref="Statements.LeftJoin{TParameters,TQueryResult,TTable}" />.</returns>
        public static LeftJoin<TParameters, TQueryResult, TSubqueryResult> LeftJoin<TParameters, TQueryResult, TSubqueryResult>(
            this QueryComponent<TParameters, TQueryResult> queryComponent,
            Expression<Func<Query<TSubqueryResult>>> child)
        {
            var subquery = new Subquery<TSubqueryResult>(child);

            return new LeftJoin<TParameters, TQueryResult, TSubqueryResult>(queryComponent.QueryContext, () => subquery.QueryResult);
        }

        /// <summary>
        ///     Add a new <c>RIGHT JOIN</c> to the query.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this query.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <typeparam name="TTable">The child table.</typeparam>
        /// <param name="queryComponent">The <see cref="QueryComponent{TParameters, TQueryResult}" />.</param>
        /// <param name="child">
        ///     The <see cref="Expression{TDelegate}">Expression&lt;Func&lt;TTable&gt;&gt;</see> that selects the child to join with.
        /// </param>
        /// <returns>The <see cref="Statements.RightJoin{TParameters,TQueryResult,TTable}" />.</returns>
        public static RightJoin<TParameters, TQueryResult, TTable> RightJoin<TParameters, TQueryResult, TTable>(
            this QueryComponent<TParameters, TQueryResult> queryComponent,
            Expression<Func<TTable>> child)
        {
            return new RightJoin<TParameters, TQueryResult, TTable>(queryComponent.QueryContext, child);
        }

        /// <summary>
        ///     Add a new <c>RIGHT JOIN</c> with a subquery to the query.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this query.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <typeparam name="TSubqueryResult">The result type of the <paramref name="child" />.</typeparam>
        /// <param name="queryComponent">The <see cref="QueryComponent{TParameters, TQueryResult}" />.</param>
        /// <param name="child">
        ///     The <see cref="Expression{TDelegate}">Expression&lt;Func&lt;Query&lt;TParameters, TSubqueryResult&gt;&gt;&gt;</see>
        ///     that selects the child to join with.
        /// </param>
        /// <returns>The <see cref="Statements.RightJoin{TParameters,TQueryResult,TTable}" />.</returns>
        public static RightJoin<TParameters, TQueryResult, TSubqueryResult> RightJoin<TParameters, TQueryResult, TSubqueryResult>(
            this QueryComponent<TParameters, TQueryResult> queryComponent,
            Expression<Func<Query<TParameters, TSubqueryResult>>> child)
        {
            var subquery = new Subquery<TParameters, TSubqueryResult>(child);

            return new RightJoin<TParameters, TQueryResult, TSubqueryResult>(queryComponent.QueryContext, () => subquery.QueryResult);
        }

        /// <summary>
        ///     Add a new <c>RIGHT JOIN</c> with a subquery to the query.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this query.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <typeparam name="TSubqueryResult">The result type of the <paramref name="child" />.</typeparam>
        /// <param name="queryComponent">The <see cref="QueryComponent{TParameters, TQueryResult}" />.</param>
        /// <param name="child">
        ///     The <see cref="Expression{TDelegate}">Expression&lt;Func&lt;Query&lt;TSubqueryResult&gt;&gt;&gt;</see>
        ///     that selects the child to join with.
        /// </param>
        /// <returns>The <see cref="Statements.RightJoin{TParameters,TQueryResult,TTable}" />.</returns>
        public static RightJoin<TParameters, TQueryResult, TSubqueryResult> RightJoin<TParameters, TQueryResult, TSubqueryResult>(
            this QueryComponent<TParameters, TQueryResult> queryComponent,
            Expression<Func<Query<TSubqueryResult>>> child)
        {
            var subquery = new Subquery<TSubqueryResult>(child);

            return new RightJoin<TParameters, TQueryResult, TSubqueryResult>(queryComponent.QueryContext, () => subquery.QueryResult);
        }

        /// <summary>
        ///     Add a new <c>INNER JOIN</c> to the query.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this query.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <typeparam name="TTable">The child table.</typeparam>
        /// <param name="queryComponent">The <see cref="QueryComponent{TParameters, TQueryResult}" />.</param>
        /// <param name="child">
        ///     The <see cref="Expression{TDelegate}">Expression&lt;Func&lt;TTable&gt;&gt;</see> that selects the child to join with.
        /// </param>
        /// <returns>The <see cref="Statements.InnerJoin{TParameters,TQueryResult,TTable}" />.</returns>
        public static InnerJoin<TParameters, TQueryResult, TTable> InnerJoin<TParameters, TQueryResult, TTable>(
            this QueryComponent<TParameters, TQueryResult> queryComponent,
            Expression<Func<TTable>> child)
        {
            return new InnerJoin<TParameters, TQueryResult, TTable>(queryComponent.QueryContext, child);
        }
        
        /// <summary>
        ///     Add a new <c>INNER JOIN</c> with a subquery to the query.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this query.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <typeparam name="TSubqueryResult">The result type of the <paramref name="child" />.</typeparam>
        /// <param name="queryComponent">The <see cref="QueryComponent{TParameters, TQueryResult}" />.</param>
        /// <param name="child">
        ///     The <see cref="Expression{TDelegate}">Expression&lt;Func&lt;Query&lt;TParameters, TSubqueryResult&gt;&gt;&gt;</see>
        ///     that selects the child to join with.
        /// </param>
        /// <returns>The <see cref="Statements.InnerJoin{TParameters,TQueryResult,TTable}" />.</returns>
        public static InnerJoin<TParameters, TQueryResult, TSubqueryResult> InnerJoin<TParameters, TQueryResult, TSubqueryResult>(
            this QueryComponent<TParameters, TQueryResult> queryComponent,
            Expression<Func<Query<TParameters, TSubqueryResult>>> child)
        {
            var subquery = new Subquery<TParameters, TSubqueryResult>(child);

            return new InnerJoin<TParameters, TQueryResult, TSubqueryResult>(queryComponent.QueryContext, () => subquery.QueryResult);
        }

        /// <summary>
        ///     Add a new <c>INNER JOIN</c> with a subquery to the query.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this query.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <typeparam name="TSubqueryResult">The result type of the <paramref name="child" />.</typeparam>
        /// <param name="queryComponent">The <see cref="QueryComponent{TParameters, TQueryResult}" />.</param>
        /// <param name="child">
        ///     The <see cref="Expression{TDelegate}">Expression&lt;Func&lt;Query&lt;TSubqueryResult&gt;&gt;&gt;</see>
        ///     that selects the child to join with.
        /// </param>
        /// <returns>The <see cref="Statements.InnerJoin{TParameters,TQueryResult,TTable}" />.</returns>
        public static InnerJoin<TParameters, TQueryResult, TSubqueryResult> InnerJoin<TParameters, TQueryResult, TSubqueryResult>(
            this QueryComponent<TParameters, TQueryResult> queryComponent,
            Expression<Func<Query<TSubqueryResult>>> child)
        {
            var subquery = new Subquery<TSubqueryResult>(child);

            return new InnerJoin<TParameters, TQueryResult, TSubqueryResult>(queryComponent.QueryContext, () => subquery.QueryResult);
        }

        /// <summary>
        ///     Add a new <c>OUTER JOIN</c> to the query.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this query.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <typeparam name="TTable">The child table.</typeparam>
        /// <param name="queryComponent">The <see cref="QueryComponent{TParameters, TQueryResult}" />.</param>
        /// <param name="child">
        ///     The <see cref="Expression{TDelegate}">Expression&lt;Func&lt;TTable&gt;&gt;</see> that selects the child to join with.
        /// </param>
        /// <returns>The <see cref="Statements.OuterJoin{TParameters,TQueryResult,TTable}" />.</returns>
        public static OuterJoin<TParameters, TQueryResult, TTable> OuterJoin<TParameters, TQueryResult, TTable>(
            this QueryComponent<TParameters, TQueryResult> queryComponent,
            Expression<Func<TTable>> child)
        {
            return new OuterJoin<TParameters, TQueryResult, TTable>(queryComponent.QueryContext, child);
        }

        /// <summary>
        ///     Add a new <c>OUTER JOIN</c> with a subquery to the query.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this query.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <typeparam name="TSubqueryResult">The result type of the <paramref name="child" />.</typeparam>
        /// <param name="queryComponent">The <see cref="QueryComponent{TParameters, TQueryResult}" />.</param>
        /// <param name="child">
        ///     The <see cref="Expression{TDelegate}">Expression&lt;Func&lt;Query&lt;TParameters, TSubqueryResult&gt;&gt;&gt;</see>
        ///     that selects the child to join with.
        /// </param>
        /// <returns>The <see cref="Statements.OuterJoin{TParameters,TQueryResult,TTable}" />.</returns>
        public static OuterJoin<TParameters, TQueryResult, TSubqueryResult> OuterJoin<TParameters, TQueryResult, TSubqueryResult>(
            this QueryComponent<TParameters, TQueryResult> queryComponent,
            Expression<Func<Query<TParameters, TSubqueryResult>>> child)
        {
            var subquery = new Subquery<TParameters, TSubqueryResult>(child);

            return new OuterJoin<TParameters, TQueryResult, TSubqueryResult>(queryComponent.QueryContext, () => subquery.QueryResult);
        }

        /// <summary>
        ///     Add a new <c>OUTER JOIN</c> with a subquery to the query.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this query.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <typeparam name="TSubqueryResult">The result type of the <paramref name="child" />.</typeparam>
        /// <param name="queryComponent">The <see cref="QueryComponent{TParameters, TQueryResult}" />.</param>
        /// <param name="child">
        ///     The <see cref="Expression{TDelegate}">Expression&lt;Func&lt;Query&lt;TSubqueryResult&gt;&gt;&gt;</see>
        ///     that selects the child to join with.
        /// </param>
        /// <returns>The <see cref="Statements.OuterJoin{TParameters,TQueryResult,TTable}" />.</returns>
        public static OuterJoin<TParameters, TQueryResult, TSubqueryResult> OuterJoin<TParameters, TQueryResult, TSubqueryResult>(
            this QueryComponent<TParameters, TQueryResult> queryComponent,
            Expression<Func<Query<TSubqueryResult>>> child)
        {
            var subquery = new Subquery<TSubqueryResult>(child);

            return new OuterJoin<TParameters, TQueryResult, TSubqueryResult>(queryComponent.QueryContext, () => subquery.QueryResult);
        }
    }
}
