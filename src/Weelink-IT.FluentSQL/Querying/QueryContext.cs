using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Databases;
using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying
{
    public sealed class QueryContext<TModel, TResult> where TModel : PersistenceModel
    {
        public QueryContext(Database database)
        {
            FromComponents = new List<QueryComponent<TModel, TResult>>();
            SelectComponents = new List<QueryComponent<TModel, TResult>>();
            JoinComponents = new List<QueryComponent<TModel, TResult>>();
            WhereComponents = new List<QueryComponent<TModel, TResult>>();
            OrderByComponents = new List<QueryComponent<TModel, TResult>>();

            ResultExpression = () => default(TResult);
            Database = database;
        }

        private Expression<Func<TResult>> ResultExpression { get; }
        private Database Database { get; }

        internal IList<QueryComponent<TModel, TResult>> FromComponents { get; }
        internal IList<QueryComponent<TModel, TResult>> SelectComponents { get; }
        internal IList<QueryComponent<TModel, TResult>> JoinComponents { get; }
        internal IList<QueryComponent<TModel, TResult>> WhereComponents { get; }
        internal IList<QueryComponent<TModel, TResult>> OrderByComponents { get; }
        internal IList<QueryComponent<TModel, TResult>> GroupByComponents { get; }

        public Query<TResult> Compile()
        {
            return Database.Compile(this);
        }
    }
}
