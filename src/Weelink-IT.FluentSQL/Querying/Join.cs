using System;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying
{
    /// <summary>
    ///     Contains the generic logic for all types of <c>JOIN</c>s.
    /// </summary>
    /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
    /// <typeparam name="TResult">The result type of the <see cref="Query{TResult}" />.</typeparam>
    /// <typeparam name="TChild">The new <see cref="Table" /> to add to this <see cref="Query{TResult}" />.</typeparam>
    /// <typeparam name="TParent">
    ///     The parent <see cref="Table" /> where <typeparamref name="TChild" /> should be joined with.
    /// </typeparam>
    /// <typeparam name="TJoin">The concrete <see cref="Join{TModel, TResult, TChild, TParent, TJoin}" /> type.</typeparam>
    public abstract class Join<TModel, TResult, TChild, TParent, TJoin> : QueryComponent<TModel, TResult>
        where TModel : PersistenceModel
        where TParent : Table
        where TChild : Table
        where TJoin : Join<TModel, TResult, TChild, TParent, TJoin>
    {
        /// <summary>
        ///     Create a new <c>INNER JOIN</c> statement.
        /// </summary>
        /// <param name="queryContext">The <see cref="QueryContext{TModel, TResult}" />.</param>
        /// <param name="expression">The expression for selecting <typeparamref name="TChild"/> <see cref="Table" /></param>
        protected Join(QueryContext<TModel, TResult> queryContext, Expression<Func<TModel, TChild>> expression)
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
        /// <returns>A <see cref="From{TModel, TResult, TTable}" /> representing <typeparamref name="TChild" />.</returns>
        public From<TModel, TResult, TChild> On(Expression<Func<TChild, TParent, bool>> expression)
        {
            Condition = expression;
            var from = new From<TModel, TResult, TChild>(QueryContext, Expression);

            return from;
        }

        private QueryContext<TModel, TResult> QueryContext { get; }
        private Expression<Func<TChild, TParent, bool>> Condition { get; set; }
        private Expression<Func<TModel, TChild>> Expression { get; }
        private Alias Alias { get; set; }

        /// <inheritdoc />
        QueryContext<TModel, TResult> QueryComponent<TModel, TResult>.QueryContext
        {
            get { return QueryContext; }
        }
    }
}
