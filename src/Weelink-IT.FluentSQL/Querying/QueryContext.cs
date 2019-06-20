using System.Collections.Generic;
using System.Linq;

using WeelinkIT.FluentSQL.Databases;

namespace WeelinkIT.FluentSQL.Querying
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
        /// <param name="database">The <see cref="WeelinkIT.FluentSQL.Databases.Database" /> for this query.</param>
        internal QueryContext(Database database)
        {
            FromComponents = new List<QueryComponent<TParameters, TQueryResult>>();
            SelectComponents = new List<QueryComponent<TParameters, TQueryResult>>();
            JoinComponents = new List<QueryComponent<TParameters, TQueryResult>>();
            WhereComponents = new List<QueryComponent<TParameters, TQueryResult>>();
            OrderByComponents = new List<QueryComponent<TParameters, TQueryResult>>();
            GroupByComponents = new List<QueryComponent<TParameters, TQueryResult>>();
            Modifiers = new List<QueryComponent<TParameters, TQueryResult>>();

            Database = database;
        }

        /// <summary>
        ///     Create a new <see cref="QueryContext{TParameters, TQueryResult}" />.
        /// </summary>
        /// <param name="other">The <see cref="QueryContext{TParameters, TQueryResult}" /> to copy the components from.</param>
        public QueryContext(QueryContext<TParameters, TQueryResult> other)
        {
            FromComponents = other.FromComponents.ToList();
            SelectComponents = other.SelectComponents.ToList();
            JoinComponents = other.JoinComponents.ToList();
            WhereComponents = other.WhereComponents.ToList();
            OrderByComponents = other.OrderByComponents.ToList();
            GroupByComponents = other.GroupByComponents.ToList();
            Modifiers = other.Modifiers.ToList();

            Database = other.Database;
        }

        internal Database Database { get; }

        internal IList<QueryComponent<TParameters, TQueryResult>> FromComponents { get; }
        internal IList<QueryComponent<TParameters, TQueryResult>> SelectComponents { get; }
        internal IList<QueryComponent<TParameters, TQueryResult>> JoinComponents { get; }
        internal IList<QueryComponent<TParameters, TQueryResult>> WhereComponents { get; }
        internal IList<QueryComponent<TParameters, TQueryResult>> OrderByComponents { get; }
        internal IList<QueryComponent<TParameters, TQueryResult>> GroupByComponents { get; }
        internal IList<QueryComponent<TParameters, TQueryResult>> Modifiers { get; }
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
