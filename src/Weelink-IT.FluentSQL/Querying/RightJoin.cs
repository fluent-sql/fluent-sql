using System;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying
{
    /// <summary>
    ///     Applies a <c>RIGHT JOIN</c> between two <see cref="Table" />s.
    /// </summary>
    /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
    /// <typeparam name="TResult">The result type of the <see cref="Query{TResult}" />.</typeparam>
    /// <typeparam name="TChild">The new <see cref="Table" /> to add to this <see cref="Query{TResult}" />.</typeparam>
    /// <typeparam name="TParent">
    ///     The parent <see cref="Table" /> where <typeparamref name="TChild" /> should be joined with.
    /// </typeparam>
    public sealed class RightJoin<TModel, TResult, TChild, TParent> 
        : Join<TModel, TResult, TChild, TParent, RightJoin<TModel, TResult, TChild, TParent>>
        where TModel : PersistenceModel
        where TParent : Table
        where TChild : Table
    {
        /// <summary>
        ///     Create a new <c>RIGHT JOIN</c> statement.
        /// </summary>
        /// <param name="queryContext">The <see cref="QueryContext{TModel, TResult}" />.</param>
        /// <param name="expression">The expression for selecting <typeparamref name="TChild"/> <see cref="Table" />.</param>
        public RightJoin(QueryContext<TModel, TResult> queryContext, Expression<Func<TModel, TChild>> expression)
            : base(queryContext, expression)
        {
        }
    }
}
