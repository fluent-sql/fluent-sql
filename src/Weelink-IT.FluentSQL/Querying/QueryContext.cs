using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using WeelinkIT.FluentSQL.Databases;

namespace WeelinkIT.FluentSQL.Querying
{
    /// <summary>
    ///     The complete context of the final <see cref="Query{TParameters, TQueryResult}" />.
    /// </summary>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing this <see cref="Query{TParameters, TQueryResult}" />.
    /// </typeparam>
    /// <typeparam name="TQueryResult">The result type of the <see cref="Query{TParameters, TQueryResult}" />.</typeparam>
    public class QueryContext<TParameters, TQueryResult> where TParameters : new()
    {
        /// <summary>
        ///     Create a new <see cref="QueryContext{TParameters,TQueryResult}" /> that will be executed in <paramref name="database" />.
        /// </summary>
        /// <param name="database">The <see cref="WeelinkIT.FluentSQL.Databases.Database" /> for this query.</param>
        public QueryContext(Database database)
        {
            FromComponents = new List<QueryComponent<TParameters, TQueryResult>>();
            SelectComponents = new List<QueryComponent<TParameters, TQueryResult>>();
            JoinComponents = new List<QueryComponent<TParameters, TQueryResult>>();
            WhereComponents = new List<QueryComponent<TParameters, TQueryResult>>();
            OrderByComponents = new List<QueryComponent<TParameters, TQueryResult>>();
            GroupByComponents = new List<QueryComponent<TParameters, TQueryResult>>();

            ResultExpression = () => default(TQueryResult);
            Database = database;
        }

        private Expression<Func<TQueryResult>> ResultExpression { get; }
        internal Database Database { get; }

        internal IList<QueryComponent<TParameters, TQueryResult>> FromComponents { get; }
        internal IList<QueryComponent<TParameters, TQueryResult>> SelectComponents { get; }
        internal IList<QueryComponent<TParameters, TQueryResult>> JoinComponents { get; }
        internal IList<QueryComponent<TParameters, TQueryResult>> WhereComponents { get; }
        internal IList<QueryComponent<TParameters, TQueryResult>> OrderByComponents { get; }
        internal IList<QueryComponent<TParameters, TQueryResult>> GroupByComponents { get; }
    }

    /// <summary>
    ///     The complete context of the final <see cref="Query{TParameters, TQueryResult}" />.
    /// </summary>
    /// <typeparam name="TQueryResult">The result type of the <see cref="Query{TParameters, TQueryResult}" />.</typeparam>
    public class QueryContext<TQueryResult> : QueryContext<NoParameters, TQueryResult>
    {
        /// <summary>
        ///     Create a new <see cref="QueryContext{TParameters,TQueryResult}" /> that will be executed in <paramref name="database" />.
        /// </summary>
        /// <param name="database">The <see cref="WeelinkIT.FluentSQL.Databases.Database" /> for this query.</param>
        public QueryContext(Database database)
            : base(database)
        {
        }

        /// <summary>
        ///     Create a parameterized version of this <see cref="QueryContext{TParameters,TQueryResult}" />.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this <see cref="Query{TParameters, TQueryResult}" />.
        /// </typeparam>
        /// <returns>The parameterized version.</returns>
        public QueryContext<TParameters, TQueryResult> WithParameters<TParameters>() where TParameters : new()
        {
            return new QueryContext<TParameters, TQueryResult>(Database);
        }
    }
}
