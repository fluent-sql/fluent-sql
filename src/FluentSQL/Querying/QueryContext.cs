using System.Collections.Generic;
using System.Linq;

using FluentSQL.Compilation;
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
    public class QueryContext<TParameters, TQueryResult> where TParameters : new()
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

        /// <summary>
        ///     Create a new <see cref="QueryContext{TParameters, TQueryResult}" />.
        /// </summary>
        /// <param name="other">The <see cref="QueryContext{TParameters, TQueryResult}" /> to copy the components from.</param>
        public QueryContext(QueryContext<TParameters, TQueryResult> other)
        {
            Components = other.Components.ToList();

            Database = other.Database;
        }

        internal void Parse(QueryParser<TParameters, TQueryResult> parser)
        {
            foreach (QueryComponent<TParameters, TQueryResult> component in Components)
            {
                component.Parse(parser);
            }
        }

        internal Database Database { get; }
        internal IList<QueryComponent<TParameters, TQueryResult>> Components { get; }
    }

    /// <summary>
    ///     The context containing all components of a parameterless query.
    /// </summary>
    /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
    public class QueryContext<TQueryResult> : QueryContext<NoParameters, TQueryResult>
    {
        /// <inheritdoc />
        public QueryContext(Database database)
            : base(database)
        {
        }

        /// <inheritdoc />
        public QueryContext(QueryContext<NoParameters, TQueryResult> other)
            : base(other)
        {
        }

        /// <summary>
        ///     Create a parameterized version of this <see cref="QueryContext{TQueryResult}" />.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing the query.
        /// </typeparam>
        /// <returns>The parameterized version.</returns>
        public QueryContext<TParameters, TQueryResult> WithParameters<TParameters>() where TParameters : new()
        {
            return new QueryContext<TParameters, TQueryResult>(Database);
        }
    }
}
