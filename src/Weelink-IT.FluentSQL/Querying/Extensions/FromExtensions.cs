using System;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.Extensions
{
    public static class FromExtensions
    {
        public static From<TModel, TResult, TTable> From<TModel, TResult, TTable>(this QueryContext<TModel, TResult> subject,
            Expression<Func<TModel, TTable>> expression) where TTable : Table where TModel : PersistenceModel
        {
            var from = new From<TModel, TResult, TTable>(subject, expression);

            subject.FromComponents.Add(from);

            return from;
        }
    }
}
