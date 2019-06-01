using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.Extensions
{
    /// <summary>
    ///     Extends <see cref="QueryContext{TModel, TParameters, TResult}" />.
    /// </summary>
    public static class QueryContextExtensions
    {
        /// <summary>
        ///     Compile this <see cref="QueryContext{TModel, TParameters, TResult}" /> to a <see cref="Query{TParameters, TResult}" />.
        /// </summary>
        /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this <see cref="Query{TParameters, TResult}" />.
        /// </typeparam>
        /// <typeparam name="TResult">The result type of the <see cref="Query{TParameters, TResult}" />.</typeparam>
        /// <param name="context">The <see cref="QueryComponent{TModel, TParameters, TResult}" /> to compile.</param>
        /// <returns>A compiled <see cref="Query{TParameters, TResult}" />.</returns>
        public static Query<TParameters, TResult> Compile<TModel, TParameters, TResult>(
            this QueryContext<TModel, TParameters, TResult> context)
            where TModel : PersistenceModel
            where TParameters : new()
        {
            return context.Database.Compile(context);
        }

        /// <summary>
        ///     Compile this <see cref="QueryContext{TModel, TParameters, TResult}">QueryContext&lt;Model, TResult&gt;</see>
        ///     to a <see cref="Query{TResult}" />.
        /// </summary>
        /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
        /// <typeparam name="TResult">The result type of the <see cref="Query{TResult}" />.</typeparam>
        /// <param name="context">The  <see cref="QueryContext{TModel, TParameters, TResult}">QueryContext&lt;Model, TResult&gt;</see> to compile.</param>
        /// <returns>A compiled <see cref="Query{TResult}" />.</returns>
        public static Query<TResult> Compile<TModel, TResult>(
            this QueryContext<TModel, NoParameters, TResult> context)
            where TModel : PersistenceModel
        {
            return context.Database.Compile(context);
        }
    }
}
