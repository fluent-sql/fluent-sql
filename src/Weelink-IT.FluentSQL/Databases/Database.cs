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
        ///     Compile <paramref name="context" /> into a <see cref="Query{TResult}" />.
        /// </summary>
        /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
        /// <typeparam name="TResult">The result type of the <see cref="Query{TResult}" />.</typeparam>
        /// <param name="context">The <see cref="QueryContext{TModel, TResult}" /> to compile.</param>
        /// <returns>A compiled <see cref="Query{TResult}" />.</returns>
        public Query<TResult> Compile<TModel, TResult>(QueryContext<TModel, TResult> context) where TModel : PersistenceModel
        {
            return new Query<TResult>(this);
        }
    }
}
