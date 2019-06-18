using System;
using System.Threading.Tasks;

using WeelinkIT.FluentSQL.Databases;

namespace WeelinkIT.FluentSQL
{
    /// <summary>
    ///     The compiled query to execute.
    /// </summary>
    /// <typeparam name="TQueryResult">The result type.</typeparam>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing this <see cref="Query{TParameters, TQueryResult}" />.
    /// </typeparam>
    public class Query<TParameters, TQueryResult> where TParameters : new()
    {
        /// <summary>
        ///     Create a new query that will be executed in <paramref name="database" />.
        /// </summary>
        /// <param name="database">The <see cref="WeelinkIT.FluentSQL.Databases.Database" /> for this query.</param>
        public Query(Database database)
        {
            Database = database;
        }

        /// <summary>
        ///     Execute this query and return the result.
        /// </summary>
        /// <returns>The result of the query.</returns>
        public Task<TQueryResult> ExecuteAsync(Action<TParameters> parameters)
        {
            var p = new TParameters();
            parameters(p);

            return Task.FromResult(default(TQueryResult));
        }

        private Database Database { get; }
    }

    /// <summary>
    ///     The compiled query to execute.
    /// </summary>
    /// <typeparam name="TQueryResult">The result type.</typeparam>
    public class Query<TQueryResult>
    {
        /// <summary>
        ///     Create a new query that will be executed in <paramref name="database" />.
        /// </summary>
        /// <param name="database">The <see cref="WeelinkIT.FluentSQL.Databases.Database" /> for this query.</param>
        public Query(Database database)
        {
            Database = database;
        }

        /// <summary>
        ///     Execute this query and return the result.
        /// </summary>
        /// <returns>The result of the query.</returns>
        public Task<TQueryResult> ExecuteAsync()
        {
            return Task.FromResult(default(TQueryResult));
        }

        private Database Database { get; }
    }
}
