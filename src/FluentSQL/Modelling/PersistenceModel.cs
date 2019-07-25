using FluentSQL.Databases;
using FluentSQL.Querying;

namespace FluentSQL.Modelling
{
    /// <summary>
    ///     Represents the model in the database.
    /// </summary>
    public abstract class PersistenceModel
    {
        /// <summary>
        ///     Create a new <see cref="PersistenceModel" />.
        /// </summary>
        /// <param name="database">
        ///     The database where this persistence model is located.
        /// </param>
        protected PersistenceModel(Database database)
        {
            Database = database;
        }

        private Database Database { get; }

        /// <summary>
        ///     Query this persistence model.
        /// </summary>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <returns>A new <see cref="QueryContext{TQueryResult}" />.</returns>
        public QueryContext<TQueryResult> Query<TQueryResult>()
        {
            return new QueryContext<TQueryResult>(Database, this);
        }
    }
}
