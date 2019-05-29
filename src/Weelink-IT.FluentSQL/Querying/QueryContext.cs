using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Databases;
using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying
{
    /// <summary>
    ///     The complete context of the final <see cref="Query{TResult}" />.
    /// </summary>
    /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
    /// <typeparam name="TResult">The result type of the <see cref="Query{TResult}" />.</typeparam>
    public sealed class QueryContext<TModel, TResult> where TModel : PersistenceModel
    {
        /// <summary>
        ///     Create a new <see cref="QueryContext{TModel, TResult}" /> that will be executed in <paramref name="database" />.
        /// </summary>
        /// <param name="database">The <see cref="WeelinkIT.FluentSQL.Databases.Database" /> for this query.</param>
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

        /// <summary>
        ///     Compile this <see cref="QueryContext{TModel, TResult}" /> to a <see cref="Query{TResult}" />.
        /// </summary>
        /// <returns>A <see cref="Query{TResult}" /> that can be executed.</returns>
        public Query<TResult> Compile()
        {
            return Database.Compile(this);
        }
    }
}
