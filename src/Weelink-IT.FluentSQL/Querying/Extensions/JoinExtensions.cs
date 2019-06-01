using System;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.Extensions
{
    /// <summary>
    ///     Allows the construction of <see cref="WeelinkIT.FluentSQL.Querying.Join{TModel, TParameters, TResult, TTable, TType, TJoin}" />s on
    ///     <see cref="ExtensionPoint{TModel, TParameters, TResult, TTable}" />s.
    /// </summary>
    public static class JoinExtensions
    {
        /// <summary>
        ///     Applies an <c>INNER JOIN</c> between two <see cref="Table" />s.
        /// </summary>
        /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this <see cref="Query{TParameters, TResult}" />.
        /// </typeparam>
        /// <typeparam name="TResult">The result type of the <see cref="Query{TParameters, TResult}" />.</typeparam>
        /// <typeparam name="TChild">The new <see cref="Table" /> to add to this <see cref="Query{TParameters, TResult}" />.</typeparam>
        /// <typeparam name="TParent">
        ///     The parent <see cref="Table" /> where <typeparamref name="TChild" /> should be joined with.
        /// </typeparam>
        /// <param name="subject">The <see cref="ExtensionPoint{TModel, TParameters, TResult, TTable}" />.</param>
        /// <param name="expression">The expression for selecting <typeparamref name="TChild"/> <see cref="Table" />.</param>
        /// <returns>The <see cref="WeelinkIT.FluentSQL.Querying.InnerJoin{TModel, TParameters, TResult, TTable, TType}" />.</returns>
        public static InnerJoin<TModel, TParameters, TResult, TChild, TParent>
            InnerJoin<TModel, TParameters, TResult, TChild, TParent>(this ExtensionPoint<TModel, TParameters, TResult, TParent> subject,
            Expression<Func<TModel, TChild>> expression)
            where TChild : Table
            where TModel : PersistenceModel
            where TParent : Table
            where TParameters : new()
        {
            QueryContext<TModel, TParameters, TResult> queryContext = subject.GetQueryContext();
            var innerJoin = new InnerJoin<TModel, TParameters, TResult, TChild, TParent>(queryContext, expression);

            queryContext.JoinComponents.Add(innerJoin);

            return innerJoin;
        }

        /// <summary>
        ///     Applies an <c>OUTER JOIN</c> between two <see cref="Table" />s.
        /// </summary>
        /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this <see cref="Query{TParameters, TResult}" />.
        /// </typeparam>
        /// <typeparam name="TResult">The result type of the <see cref="Query{TParameters, TResult}" />.</typeparam>
        /// <typeparam name="TChild">The new <see cref="Table" /> to add to this <see cref="Query{TParameters, TResult}" />.</typeparam>
        /// <typeparam name="TParent">
        ///     The parent <see cref="Table" /> where <typeparamref name="TChild" /> should be joined with.
        /// </typeparam>
        /// <param name="subject">The <see cref="ExtensionPoint{TModel, TParameters, TResult, TTable}" />.</param>
        /// <param name="expression">The expression for selecting <typeparamref name="TChild"/> <see cref="Table" />.</param>
        /// <returns>The <see cref="WeelinkIT.FluentSQL.Querying.OuterJoin{TModel, TParameters, TResult, TTable, TType}" />.</returns>
        public static OuterJoin<TModel, TParameters, TResult, TChild, TParent> OuterJoin<TModel, TParameters, TResult, TChild, TParent>(
            this ExtensionPoint<TModel, TParameters, TResult, TParent> subject,
            Expression<Func<TModel, TChild>> expression)
            where TChild : Table
            where TModel : PersistenceModel
            where TParent : Table
            where TParameters : new()
        {
            QueryContext<TModel, TParameters, TResult> queryContext = subject.GetQueryContext();
            var outerJoin = new OuterJoin<TModel, TParameters, TResult, TChild, TParent>(queryContext, expression);

            queryContext.JoinComponents.Add(outerJoin);

            return outerJoin;
        }

        /// <summary>
        ///     Applies a <c>LEFT JOIN</c> between two <see cref="Table" />s.
        /// </summary>
        /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this <see cref="Query{TParameters, TResult}" />.
        /// </typeparam>
        /// <typeparam name="TResult">The result type of the <see cref="Query{TParameters, TResult}" />.</typeparam>
        /// <typeparam name="TChild">The new <see cref="Table" /> to add to this <see cref="Query{TParameters, TResult}" />.</typeparam>
        /// <typeparam name="TParent">
        ///     The parent <see cref="Table" /> where <typeparamref name="TChild" /> should be joined with.
        /// </typeparam>
        /// <param name="subject">The <see cref="ExtensionPoint{TModel, TParameters, TResult, TTable}" />.</param>
        /// <param name="expression">The expression for selecting <typeparamref name="TChild"/> <see cref="Table" /></param>
        /// <returns>The <see cref="WeelinkIT.FluentSQL.Querying.LeftJoin{TModel, TParameters, TResult, TTable, TType}" />.</returns>
        public static LeftJoin<TModel, TParameters, TResult, TChild, TParent> LeftJoin<TModel, TParameters, TResult, TChild, TParent>(
            this ExtensionPoint<TModel, TParameters, TResult, TParent> subject,
            Expression<Func<TModel, TChild>> expression)
            where TChild : Table
            where TModel : PersistenceModel
            where TParent : Table
            where TParameters : new()
        {
            QueryContext<TModel, TParameters, TResult> queryContext = subject.GetQueryContext();
            var leftJoin = new LeftJoin<TModel, TParameters, TResult, TChild, TParent>(queryContext, expression);

            queryContext.JoinComponents.Add(leftJoin);

            return leftJoin;
        }

        /// <summary>
        ///     Applies a <c>RIGHT JOIN</c> between two <see cref="Table" />s.
        /// </summary>
        /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this <see cref="Query{TParameters, TResult}" />.
        /// </typeparam>
        /// <typeparam name="TResult">The result type of the <see cref="Query{TParameters, TResult}" />.</typeparam>
        /// <typeparam name="TChild">The new <see cref="Table" /> to add to this <see cref="Query{TParameters, TResult}" />.</typeparam>
        /// <typeparam name="TParent">
        ///     The parent <see cref="Table" /> where <typeparamref name="TChild" /> should be joined with.
        /// </typeparam>
        /// <param name="subject">The <see cref="ExtensionPoint{TModel, TParameters, TResult, TTable}" />.</param>
        /// <param name="expression">The expression for selecting <typeparamref name="TChild"/> <see cref="Table" /></param>
        /// <returns>The <see cref="WeelinkIT.FluentSQL.Querying.RightJoin{TModel, TParameters, TResult, TTable, TType}" />.</returns>
        public static RightJoin<TModel, TParameters, TResult, TChild, TParent> RightJoin<TModel, TParameters, TResult, TChild, TParent>(
            this ExtensionPoint<TModel, TParameters, TResult, TParent> subject,
            Expression<Func<TModel, TChild>> expression)
            where TChild : Table
            where TModel : PersistenceModel
            where TParent : Table
            where TParameters : new()
        {
            QueryContext<TModel, TParameters, TResult> queryContext = subject.GetQueryContext();
            var rightJoin = new RightJoin<TModel, TParameters, TResult, TChild, TParent>(queryContext, expression);

            queryContext.JoinComponents.Add(rightJoin);

            return rightJoin;
        }
    }
}
