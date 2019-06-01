using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Databases;
using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying
{
    /// <summary>
    ///     Used when the <see cref="Query{TParameters, TResult}" /> does not have parameters.
    /// </summary>
    public sealed class NoParameters
    {
    }

    /// <summary>
    ///     The complete context of the final <see cref="Query{TParameters, TResult}" />.
    /// </summary>
    /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
    /// <typeparam name="TResult">The result type of the <see cref="Query{TParameters, TResult}" />.</typeparam>
    public class QueryContext<TModel, TResult> : QueryContext<TModel, NoParameters, TResult> where TModel : PersistenceModel
    {
        /// <summary>
        ///     Create a new <see cref="QueryContext{TModel, TParameters, TResult}" /> that will be executed in <paramref name="database" />.
        /// </summary>
        /// <param name="database">The <see cref="WeelinkIT.FluentSQL.Databases.Database" /> for this query.</param>
        public QueryContext(Database database)
            : base(database)
        {
            Database = database;
        }

        /// <summary>
        ///     Create a parameterized version of this <see cref="QueryContext{TModel, TParameters, TResult}" />.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this <see cref="Query{TParameters, TResult}" />.
        /// </typeparam>
        /// <returns>The parameterized version.</returns>
        public QueryContext<TModel, TParameters, TResult> WithParameters<TParameters>() where TParameters : new()
        {
            return new QueryContext<TModel, TParameters, TResult>(Database);
        }

        private Database Database { get; }
    }

    /// <summary>
    ///     The complete context of the final <see cref="Query{TParameters, TResult}" />.
    /// </summary>
    /// <typeparam name="TModel">The <see cref="PersistenceModel" />.</typeparam>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing this <see cref="Query{TParameters, TResult}" />.
    /// </typeparam>
    /// <typeparam name="TResult">The result type of the <see cref="Query{TParameters, TResult}" />.</typeparam>
    public class QueryContext<TModel, TParameters, TResult> where TModel : PersistenceModel where TParameters : new()
    {
        /// <summary>
        ///     Create a new <see cref="QueryContext{TModel, TParameters, TResult}" /> that will be executed in <paramref name="database" />.
        /// </summary>
        /// <param name="database">The <see cref="WeelinkIT.FluentSQL.Databases.Database" /> for this query.</param>
        public QueryContext(Database database)
        {
            FromComponents = new List<QueryComponent<TModel, TParameters, TResult>>();
            SelectComponents = new List<QueryComponent<TModel, TParameters, TResult>>();
            JoinComponents = new List<QueryComponent<TModel, TParameters, TResult>>();
            WhereComponents = new List<QueryComponent<TModel, TParameters, TResult>>();
            OrderByComponents = new List<QueryComponent<TModel, TParameters, TResult>>();
            GroupByComponents = new List<QueryComponent<TModel, TParameters, TResult>>();

            ResultExpression = () => default(TResult);
            Database = database;
        }

        private Expression<Func<TResult>> ResultExpression { get; }
        private Database Database { get; }

        internal IList<QueryComponent<TModel, TParameters, TResult>> FromComponents { get; }
        internal IList<QueryComponent<TModel, TParameters, TResult>> SelectComponents { get; }
        internal IList<QueryComponent<TModel, TParameters, TResult>> JoinComponents { get; }
        internal IList<QueryComponent<TModel, TParameters, TResult>> WhereComponents { get; }
        internal IList<QueryComponent<TModel, TParameters, TResult>> OrderByComponents { get; }
        internal IList<QueryComponent<TModel, TParameters, TResult>> GroupByComponents { get; }

        /// <summary>
        ///     Compile this <see cref="QueryContext{TModel, TParameters, TResult}" /> to a <see cref="Query{TParameters, TResult}" />.
        /// </summary>
        /// <returns>A <see cref="Query{TParameters, TResult}" /> that can be executed.</returns>
        public Query<TParameters, TResult> Compile()
        {
            return Database.Compile(this);
        }
    }
}
