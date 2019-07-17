using System;
using System.Linq.Expressions;

namespace FluentSQL.Querying.Statements
{
    /// <summary>
    ///     Represents a subquery to use in a different query.
    /// </summary>
    /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
    public class Subquery<TQueryResult>
    {
        /// <summary>
        ///     Create a new subquery.
        /// </summary>
        /// <param name="query">The underlying query.</param>
        internal Subquery(Expression<Func<Query<TQueryResult>>> query)
        {
            Query = query;
        }

        private Expression<Func<Query<TQueryResult>>> Query { get; }

        /// <summary>
        ///     The <typeparamref name="TQueryResult" /> of the underlying query.
        /// </summary>
        internal TQueryResult QueryResult
        {
            get { return default(TQueryResult); }
        }
    }

    /// <summary>
    ///     Represents a subquery to use in a different query.
    /// </summary>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing this query.
    /// </typeparam>
    /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
    public class Subquery<TParameters, TQueryResult>
    {
        /// <summary>
        ///     Create a new subquery.
        /// </summary>
        /// <param name="query">The underlying query.</param>
        internal Subquery(Expression<Func<Query<TParameters, TQueryResult>>> query)
        {
            Query = query;
        }

        private Expression<Func<Query<TParameters, TQueryResult>>> Query { get; }

        /// <summary>
        ///     The <typeparamref name="TQueryResult" /> of the underlying query.
        /// </summary>
        internal TQueryResult QueryResult
        {
            get { return default(TQueryResult); }
        }
    }
}
