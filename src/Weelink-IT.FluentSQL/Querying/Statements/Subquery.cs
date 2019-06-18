using System;
using System.Linq.Expressions;

namespace WeelinkIT.FluentSQL.Querying.Statements
{
    /// <summary>
    ///     Represents a subquery to use in a different <see cref="Query{TQueryResult}" />.
    /// </summary>
    /// <typeparam name="TQueryResult">The result type of the <see cref="Query{TQueryResult}" />.</typeparam>
    public class Subquery<TQueryResult>
    {
        /// <summary>
        ///     Create a new subquery.
        /// </summary>
        /// <param name="query">The underlying <see cref="Query{TQueryResult}" />.</param>
        internal Subquery(Expression<Func<Query<TQueryResult>>> query)
        {
            Query = query;
        }

        private Expression<Func<Query<TQueryResult>>> Query { get; }

        /// <summary>
        ///     The <typeparamref name="TQueryResult" /> of the underlying <see cref="Query{TQueryResult}" />.
        /// </summary>
        internal TQueryResult QueryResult
        {
            get { return default(TQueryResult); }
        }
    }

    /// <summary>
    ///     Represents a subquery to use in a different <see cref="Query{TParameters, TQueryResult}" />.
    /// </summary>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing this <see cref="Query{TParameters, TQueryResult}" />.
    /// </typeparam>
    /// <typeparam name="TQueryResult">The result type of the <see cref="Query{TParameters, TQueryResult}" />.</typeparam>
    public class Subquery<TParameters, TQueryResult> where TParameters : new()
    {
        /// <summary>
        ///     Create a new subquery.
        /// </summary>
        /// <param name="query">The underlying <see cref="Query{TParameters, TQueryResult}" />.</param>
        public Subquery(Expression<Func<Query<TParameters, TQueryResult>>> query)
        {
            Query = query;
        }

        private Expression<Func<Query<TParameters, TQueryResult>>> Query { get; }

        
        /// <summary>
        ///     The <typeparamref name="TQueryResult" /> of the underlying <see cref="Query{TQueryResult}" />.
        /// </summary>
        internal TQueryResult QueryResult
        {
            get { return default(TQueryResult); }
        }
    }
}
