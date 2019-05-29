using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.Extensions
{
    public interface ExtensionPoint<TModel, TResult> where TModel : PersistenceModel
    {
    }

    public interface ExtensionPoint<TModel, TResult, T> where TModel : PersistenceModel
    {
    }
}
