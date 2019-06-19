using WeelinkIT.FluentSQL.Databases;
using WeelinkIT.FluentSQL.Querying;

namespace WeelinkIT.FluentSQL.Modelling
{
    /// <summary>
    ///     Represents the model in the database.
    /// </summary>
    public abstract class PersistenceModel
    {
    }

    /// <summary>
    ///     Represents the model in the database.
    /// </summary>
    /// <typeparam name="TModel">This <see cref="PersistenceModel{TModel}" />.</typeparam>
    public abstract class PersistenceModel<TModel> : PersistenceModel where TModel : PersistenceModel
    {
        /// <summary>
        ///     Create a new <see cref="PersistenceModel{TModel}" />.
        /// </summary>
        /// <param name="database">
        ///     The database where this persistence model is located.
        /// </param>
        protected PersistenceModel(Database database)
        {
            Database = database;
        }

        /// <summary>
        ///     Query this persistence model.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this query.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <returns>A new <see cref="QueryContext{TParameters, TQueryResult}" />.</returns>
        public QueryContext<TParameters, TQueryResult> Query<TParameters, TQueryResult>() where TParameters : new()
        {
            return new QueryContext<TParameters, TQueryResult>(Database);
        }

        /// <summary>
        ///     Query this persistence model.
        /// </summary>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <returns>A new <see cref="QueryContext{TQueryResult}" />.</returns>
        public QueryContext<TQueryResult> Query<TQueryResult>()
        {
            return new QueryContext<TQueryResult>(Database);
        }

        private Database Database { get; }
    }
}
