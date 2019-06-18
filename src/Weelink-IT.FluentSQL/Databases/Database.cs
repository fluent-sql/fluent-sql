using WeelinkIT.FluentSQL.Querying;

namespace WeelinkIT.FluentSQL.Databases
{
    /// <summary>
    ///     Represents the database.
    /// </summary>
    public abstract class Database
    {
        /// <summary>
        ///     Compile <paramref name="context" /> into a <see cref="Query{TParameters, TQueryResult}" />.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this <see cref="Query{TParameters, TQueryResult}" />.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the <see cref="Query{TParameters, TQueryResult}" />.</typeparam>
        /// <param name="context">The <see cref="QueryContext{TParameters, TQueryResult}" /> to compile.</param>
        /// <returns>A compiled <see cref="Query{TParameters, TQueryResult}" />.</returns>
        public Query<TParameters, TQueryResult> Compile<TParameters, TQueryResult>(QueryContext<TParameters, TQueryResult> context)
            where TParameters : new()
        {
            return new Query<TParameters, TQueryResult>(this);
        }

        /// <summary>
        ///     Compile <paramref name="context" /> into a <see cref="Query{TParameters, TQueryResult}" />.
        /// </summary>
        /// <typeparam name="TQueryResult">The result type of the <see cref="Query{TParameters, TQueryResult}" />.</typeparam>
        /// <param name="context">The <see cref="QueryContext{TParameters, TQueryResult}" /> to compile.</param>
        /// <returns>A compiled <see cref="Query{TQueryResult}" />.</returns>
        public Query<TQueryResult> Compile<TQueryResult>(QueryContext<NoParameters, TQueryResult> context)
        {
            return new Query<TQueryResult>(this);
        }
    }
}
