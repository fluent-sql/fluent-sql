using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying
{
    public interface QueryComponent<TModel, TResult> where TModel : PersistenceModel
    {
        QueryContext<TModel, TResult> QueryContext { get; }
    }
}
