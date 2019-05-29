using System.Threading.Tasks;

using WeelinkIT.FluentSQL.Databases;

namespace WeelinkIT.FluentSQL
{
    /// <summary>
    ///     The compiled query to execute.
    /// </summary>
    /// <typeparam name="TResult">The result type.</typeparam>
    public sealed class Query<TResult>
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
        public Task<TResult> ExecuteAsync()
        {
            return Task.FromResult(default(TResult));
        }

        private Database Database { get; }
    }
}
