using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.Extensions
{
    /// <summary>
    ///     Extends <see cref="QueryComponent{TModel, TResult}" />.
    /// </summary>
    public static class QueryComponentExtensions
    {
        /// <summary>
        ///     Compile the <see cref="QueryContext{TModel, TResult}" /> associated with
        ///     this <see cref="QueryComponent{TModel, TResult}" /> into a <see cref="Query{TResult}" />.
        /// </summary>
        /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
        /// <typeparam name="TResult">The result type of the <see cref="Query{TResult}" />.</typeparam>
        /// <param name="component">The <see cref="QueryComponent{TModel, TResult}" /> to compile.</param>
        /// <returns>A compiled <see cref="Query{TResult}" />.</returns>
        public static Query<TResult> Compile<TModel, TResult>(this QueryComponent<TModel, TResult> component)
            where TModel : PersistenceModel
        {
            return component.QueryContext.Compile();
        }
    }
}
