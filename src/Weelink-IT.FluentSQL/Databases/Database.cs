using WeelinkIT.FluentSQL.Modelling;
using WeelinkIT.FluentSQL.Querying;

namespace WeelinkIT.FluentSQL.Databases
{
    public abstract class Database
    {
        public Query<TResult> Compile<TModel, TResult>(QueryContext<TModel, TResult> context) where TModel : PersistenceModel
        {
            return new Query<TResult>();
        }
    }
}
