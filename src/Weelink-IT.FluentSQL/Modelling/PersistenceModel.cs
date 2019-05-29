using WeelinkIT.FluentSQL.Databases;
using WeelinkIT.FluentSQL.Querying;

namespace WeelinkIT.FluentSQL.Modelling
{
    public abstract class PersistenceModel
    {
    }

    public abstract class PersistenceModel<TModel> : PersistenceModel where TModel : PersistenceModel
    {
        protected PersistenceModel(Database database)
        {
            Database = database;
        }

        public QueryContext<TModel, TResult> Query<TResult>()
        {
            return new QueryContext<TModel, TResult>(Database);
        }

        private Database Database { get; }
    }
}
