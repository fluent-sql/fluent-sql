using System;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying
{
    /// <summary>
    ///     Contains the generic logic for all types of <c>JOIN</c>s.
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
    /// <typeparam name="TJoin">The concrete <see cref="Join{TModel, TParameters, TResult, TChild, TParent, TJoin}" /> type.</typeparam>
    public abstract class Join<TModel, TParameters, TResult, TChild, TParent, TJoin>
        : QueryComponent<TModel, TParameters, TResult>
        where TModel : PersistenceModel
        where TParent : Table
        where TChild : Table
        where TJoin : Join<TModel, TParameters, TResult, TChild, TParent, TJoin>
        where TParameters : new()
    {
        /// <summary>
        ///     Create a new <c>INNER JOIN</c> statement.
        /// </summary>
        /// <param name="queryContext">The <see cref="QueryContext{TModel, TParameters, TResult}" />.</param>
        /// <param name="expression">The expression for selecting <typeparamref name="TChild"/> <see cref="Table" /></param>
        protected Join(QueryContext<TModel, TParameters, TResult> queryContext, Expression<Func<TModel, TChild>> expression)
        {
            Expression = expression;
            QueryContext = queryContext;
        }

        /// <summary>
        ///     Add an alias to <typeparamref name="TChild"/> />.
        /// </summary>
        /// <param name="alias">The alias to use.</param>
        /// <returns><c>this</c> for method chaining.</returns>
        public TJoin As(string alias)
        {
            Alias = new Alias(alias);
            return (TJoin)this;
        }

        /// <summary>
        ///     Use <paramref name="expression" /> for joining <typeparamref name="TChild" /> with <typeparamref name="TParent" />.
        /// </summary>
        /// <param name="expression">
        ///     The search condition to use for joining <typeparamref name="TChild" /> with <typeparamref name="TParent" />.
        /// </param>
        /// <returns>A <see cref="From{TModel, TParameters, TResult, TTable}" /> representing <typeparamref name="TChild" />.</returns>
        public From<TModel, TParameters, TResult, TChild> On(Expression<Func<TChild, TParent, bool>> expression)
        {
            Condition = expression;
            var from = new From<TModel, TParameters, TResult, TChild>(QueryContext, Expression);

            return from;
        }

        private QueryContext<TModel, TParameters, TResult> QueryContext { get; }
        private Expression<Func<TChild, TParent, bool>> Condition { get; set; }
        private Expression<Func<TModel, TChild>> Expression { get; }
        private Alias Alias { get; set; }

        /// <inheritdoc />
        QueryContext<TModel, TParameters, TResult> QueryComponent<TModel, TParameters, TResult>.QueryContext
        {
            get { return QueryContext; }
        }
    }
}
