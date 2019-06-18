using WeelinkIT.FluentSQL.Databases;
using WeelinkIT.FluentSQL.Querying;

namespace WeelinkIT.FluentSQL.Modelling
{
    /// <summary>
    ///     Represents the model in the <see cref="Database" />.
    /// </summary>
    public abstract class PersistenceModel
    {
    }

    /// <summary>
    ///     Represents the model in the <see cref="WeelinkIT.FluentSQL.Databases.Database" />.
    /// </summary>
    /// <typeparam name="TModel">This <see cref="PersistenceModel{TModel}" />.</typeparam>
    public abstract class PersistenceModel<TModel> : PersistenceModel where TModel : PersistenceModel
    {
        /// <summary>
        ///     Create a new <see cref="PersistenceModel{TModel}" />.
        /// </summary>
        /// <param name="database">
        ///     The <see cref="WeelinkIT.FluentSQL.Databases.Database" /> where
        ///     this <see cref="PersistenceModel{TModel}" /> is located.
        /// </param>
        protected PersistenceModel(Database database)
        {
            Database = database;
        }

        /// <summary>
        ///     <see cref="Query{TParameters, TQueryResult}" /> this <see cref="PersistenceModel{TModel}" />.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this <see cref="Query{TParameters, TQueryResult}" />.
        /// </typeparam>
        /// <typeparam name="TQueryResult"></typeparam>
        /// <returns></returns>
        public QueryContext<TParameters, TQueryResult> Query<TParameters, TQueryResult>() where TParameters : new()
        {
            return new QueryContext<TParameters, TQueryResult>(Database);
        }

        /// <summary>
        ///     <see cref="Query{TParameters, TQueryResult}" /> this <see cref="PersistenceModel{TModel}" />.
        /// </summary>
        /// <typeparam name="TQueryResult"></typeparam>
        /// <returns></returns>
        public QueryContext<TQueryResult> Query<TQueryResult>()
        {
            return new QueryContext<TQueryResult>(Database);
        }

        private Database Database { get; }
    }
}
