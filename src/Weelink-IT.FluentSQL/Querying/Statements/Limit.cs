﻿namespace WeelinkIT.FluentSQL.Querying.Statements
{
    /// <summary>
    ///     Limits the number of results.
    /// </summary>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing this <see cref="Query{TParameters, TQueryResult}" />.
    /// </typeparam>
    /// <typeparam name="TQueryResult">The result type of the <see cref="Query{TParameters, TQueryResult}" />.</typeparam>
    public class Limit<TParameters, TQueryResult> : QueryComponent<TParameters, TQueryResult> where TParameters : new()
    {
        /// <summary>
        ///     Create a new <c>LIMIT</c>-statement.
        /// </summary>
        /// <param name="queryContext">The <see cref="QueryContext{TParameters, TResult}" />.</param>
        /// <param name="count">The number of rows.</param>
        public Limit(QueryContext<TParameters, TQueryResult> queryContext, int count)
        {
            QueryContext = queryContext;
            Count = count;

            QueryContext.Modifiers.Add(this);
        }

        /// <inheritdoc />
        QueryContext<TParameters, TQueryResult> QueryComponent<TParameters, TQueryResult>.QueryContext
        {
            get { return QueryContext; }
        }

        private QueryContext<TParameters, TQueryResult> QueryContext { get; }
        private int Count { get; }
    }
}