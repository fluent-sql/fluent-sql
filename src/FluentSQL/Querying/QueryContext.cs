using System.Collections.Generic;

using FluentSQL.Compilation.Parser;
using FluentSQL.Databases;

namespace FluentSQL.Querying
{
    /// <summary>
    ///     The context containing all components of the query.
    /// </summary>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing this query.
    /// </typeparam>
    /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
    public class QueryContext<TParameters, TQueryResult>
    {
        /// <summary>
        ///     Create a new <see cref="QueryContext{TParameters, TQueryResult}" />.
        /// </summary>
        /// <param name="database">The <see cref="Databases.Database" /> for this query.</param>
        internal QueryContext(Database database)
        {
            Components = new List<QueryComponent<TParameters, TQueryResult>>();
            Database = database;
        }

        internal Database Database { get; }
        internal IList<QueryComponent<TParameters, TQueryResult>> Components { get; }

        internal void Parse(QueryParser parser)
        {
            foreach (QueryComponent<TParameters, TQueryResult> component in Components)
            {
                component.Parse(parser);
            }
        }
    }

    /// <summary>
    ///     The context containing all components of a parameterless query.
    /// </summary>
    /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
    public sealed class QueryContext<TQueryResult> : QueryContext<NoParameters, TQueryResult>
    {
        internal QueryContext(Database database)
            : base(database)
        {
        }

        /// <summary>
        ///     Create a parameterized version of this <see cref="QueryContext{TQueryResult}" />.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing the query.
        /// </typeparam>
        /// <returns>The parameterized version.</returns>
        public QueryContext<TParameters, TQueryResult> WithParameters<TParameters>()
        {
            return new QueryContext<TParameters, TQueryResult>(Database);
        }
    }
}
