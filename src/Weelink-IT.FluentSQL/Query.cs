using System;
using System.Data;
using System.Threading.Tasks;

using WeelinkIT.FluentSQL.Databases;

namespace WeelinkIT.FluentSQL
{
    /// <summary>
    ///     The compiled query to execute.
    /// </summary>
    /// <typeparam name="TQueryResult">The result type.</typeparam>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing this query.
    /// </typeparam>
    public class Query<TParameters, TQueryResult> where TParameters : new()
    {
        /// <summary>
        ///     Create a new query that will be executed in <paramref name="database" />.
        /// </summary>
        /// <param name="database">The database for this query.</param>
        /// <param name="commandText">The SQL to execute.</param>
        public Query(Database database, string commandText)
        {
            Database = database;
            CommandText = commandText;
        }

        /// <summary>
        ///     Execute this query and return the result.
        /// </summary>
        /// <param name="parameters">Configures the parameters.</param>
        /// <param name="transaction">The optional transaction.</param>
        /// <returns>The result of the query.</returns>
        public Task<TQueryResult> ExecuteAsync(Action<TParameters> parameters, IDbTransaction transaction = null)
        {
            var p = new TParameters();
            parameters(p);

            return Database.QueryAsync<TQueryResult>(transaction, CommandText, p);
        }

        private Database Database { get; }
        private string CommandText { get; }
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
        /// <param name="database">The database for this query.</param>
        /// <param name="commandText">The SQL to execute.</param>
        public Query(Database database, string commandText)
        {
            Database = database;
            CommandText = commandText;
        }

        /// <summary>
        ///     Execute this query and return the result.
        /// </summary>
        /// <param name="transaction">The optional transaction.</param>
        /// <returns>The result of the query.</returns>
        public Task<TQueryResult> ExecuteAsync(IDbTransaction transaction = null)
        {
            return Database.QueryAsync<TQueryResult>(transaction, CommandText);
        }

        private Database Database { get; }
        private string CommandText { get; }
    }
}
