using System;
using System.Data;
using System.Threading.Tasks;

namespace FluentSQL.Extensions
{
    /// <summary>
    ///     Extends <see cref="IDbConnection" /> for executing queries.
    /// </summary>
    public static class QueryExtensions
    {
        /// <summary>
        ///     Execute this query and return the result.
        /// </summary>
        /// <param name="connection">The <see cref="IDbConnection" />.</param>
        /// <param name="query">The query to execute.</param>
        /// <param name="parameterConfig">Configures the parameters.</param>
        /// <param name="transaction">The optional transaction.</param>
        /// <returns>The result of the query.</returns>
        public static Task<TQueryResult> ExecuteAsync<TParameters, TQueryResult>(
            this IDbConnection connection,
            Query<TParameters, TQueryResult> query,
            Action<TParameters> parameterConfig,
            IDbTransaction transaction = null) where TParameters : new()
        {
            var parameters = new TParameters();
            parameterConfig(parameters);

            return ExecuteAsync(connection, query, parameters, transaction);
        }

        /// <summary>
        ///     Execute this query and return the result.
        /// </summary>
        /// <param name="connection">The <see cref="IDbConnection" />.</param>
        /// <param name="query">The query to execute.</param>
        /// <param name="parameters">The query parameters.</param>
        /// <param name="transaction">The optional transaction.</param>
        /// <returns>The result of the query.</returns>
        public static Task<TQueryResult> ExecuteAsync<TParameters, TQueryResult>(
            this IDbConnection connection,
            Query<TParameters, TQueryResult> query,
            TParameters parameters,
            IDbTransaction transaction = null) where TParameters : new()
        {
            return Task.FromResult(default(TQueryResult));
        }

        /// <summary>
        ///     Execute this query and return the result.
        /// </summary>
        /// <param name="connection">The <see cref="IDbConnection" />.</param>
        /// <param name="query">The query to execute.</param>
        /// <param name="transaction">The optional transaction.</param>
        /// <returns>The result of the query.</returns>
        public static Task<TQueryResult> ExecuteAsync<TQueryResult>(
            this IDbConnection connection,
            Query<TQueryResult> query,
            IDbTransaction transaction = null)
        {
            return Task.FromResult(default(TQueryResult));
        }
    }
}
