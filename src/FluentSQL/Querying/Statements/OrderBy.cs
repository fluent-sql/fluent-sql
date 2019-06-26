﻿using System;
using System.Linq.Expressions;

namespace FluentSQL.Querying.Statements
{
    /// <summary>
    ///     The <c>ORDER BY</c>-statement of a query.
    /// </summary>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing this query.
    /// </typeparam>
    /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
    /// <typeparam name="TSqlExpression">The expression to order by.</typeparam>
    public class OrderBy<TParameters, TQueryResult, TSqlExpression> :
        QueryComponent<TParameters, TQueryResult>
        where TParameters : new()
    {
        /// <summary>
        ///     Create a new <c>ORDER BY</c>-statement.
        /// </summary>
        /// <param name="queryContext">The <see cref="QueryContext{TParameters, TResult}" />.</param>
        /// <param name="expression">
        ///     The <see cref="Expression{TDelegate}">Expression&lt;Func&lt;TSqlExpression&gt;&gt;</see> to select.
        /// </param>
        internal OrderBy(QueryContext<TParameters, TQueryResult> queryContext, Expression<Func<TSqlExpression>> expression)
            : base(queryContext)
        {
            Expression = expression;

            QueryContext.OrderByComponents.Add(this);
        }

        /// <summary>
        ///     Apply the ordering ascending.
        /// </summary>
        public OrderBy<TParameters, TQueryResult, TSqlExpression> Ascending
        {
            get { return this; }
        }

        /// <summary>
        ///     Apply the ordering descending.
        /// </summary>
        public OrderBy<TParameters, TQueryResult, TSqlExpression> Descending
        {
            get { return this; }
        }

        private Expression<Func<TSqlExpression>> Expression { get; }
    }
}