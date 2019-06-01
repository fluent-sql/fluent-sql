using WeelinkIT.FluentSQL.Modelling;
using WeelinkIT.FluentSQL.Querying;

namespace WeelinkIT.FluentSQL.Databases
{
    /// <summary>
    ///     Represents the database.
    /// </summary>
    public abstract class Database
    {
        /// <summary>
        ///     Compile <paramref name="context" /> into a <see cref="Query{TParameters, TResult}" />.
        /// </summary>
        /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this <see cref="Query{TParameters, TResult}" />.
        /// </typeparam>
        /// <typeparam name="TResult">The result type of the <see cref="Query{TParameters, TResult}" />.</typeparam>
        /// <param name="context">The <see cref="QueryContext{TModel, TParameters, TResult}" /> to compile.</param>
        /// <returns>A compiled <see cref="Query{TParameters, TResult}" />.</returns>
        public Query<TParameters, TResult> Compile<TModel, TParameters, TResult>(
            QueryContext<TModel, TParameters, TResult> context)
            where TModel : PersistenceModel
            where TParameters : new()
        {
            return new Query<TParameters, TResult>(this);
        }
    }
}
