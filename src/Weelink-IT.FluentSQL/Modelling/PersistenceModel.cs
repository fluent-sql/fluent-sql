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
        ///     <see cref="Query{TParameters, TResult}" /> this <see cref="PersistenceModel{TModel}" />.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this <see cref="Query{TParameters, TResult}" />.
        /// </typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public QueryContext<TModel, TParameters, TResult> Query<TParameters, TResult>() where TParameters : new()
        {
            return new QueryContext<TModel, TParameters, TResult>(Database);
        }

        /// <summary>
        ///     <see cref="Query{TParameters, TResult}" /> this <see cref="PersistenceModel{TModel}" />.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public QueryContext<TModel, TResult> Query<TResult>()
        {
            return new QueryContext<TModel, TResult>(Database);
        }

        private Database Database { get; }
    }
}
