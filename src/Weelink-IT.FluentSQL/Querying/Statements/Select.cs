using System;
using System.Linq.Expressions;

namespace WeelinkIT.FluentSQL.Querying.Statements
{
    /// <summary>
    ///     The <c>SELECT</c>-statement of a <see cref="Query{TParameters, TQueryResult}" />.
    /// </summary>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing this <see cref="Query{TParameters, TQueryResult}" />.
    /// </typeparam>
    /// <typeparam name="TQueryResult">The result type of the <see cref="Query{TParameters, TQueryResult}" />.</typeparam>
    /// <typeparam name="TSqlExpression">The expression to select.</typeparam>
    public class Select<TParameters, TQueryResult, TSqlExpression> :
        QueryComponent<TParameters, TQueryResult>
        where TParameters : new()
    {
        /// <summary>
        ///     Create a new <c>SELECT</c>-statement.
        /// </summary>
        /// <param name="queryContext">The <see cref="QueryContext{TParameters, TResult}" />.</param>
        /// <param name="expression">The <see cref="Expression{TDelegate}" /> to select.</param>
        internal Select(QueryContext<TParameters, TQueryResult> queryContext, Expression<Func<TSqlExpression>> expression)
        {
            QueryContext = queryContext;
            Expression = expression;

            queryContext.SelectComponents.Add(this);
        }

        /// <summary>
        ///     Sets the <see cref="WeelinkIT.FluentSQL.Querying.Statements.Alias" /> under which this expression will be known.
        /// </summary>
        /// <param name="alias">The alias.</param>
        /// <returns><c>this</c> for method chaining.</returns>
        public Select<TParameters, TQueryResult, TSqlExpression> As(string alias)
        {
            Alias = new Alias(alias);
            return this;
        }
  
        /// <summary>
        ///     Sets the <see cref="WeelinkIT.FluentSQL.Querying.Statements.Alias" /> under which this expression will be known
        ///     where the name is derived from a property in the class <typeparamref name="TQueryResult"/>.
        /// </summary>
        /// <param name="alias">The alias.</param>
        /// <returns><c>this</c> for method chaining.</returns>
        public Select<TParameters, TQueryResult, TSqlExpression> As(Expression<Func<TQueryResult, object>> alias)
        {
            Alias = new Alias("TODO");
            return this;
        }

        /// <inheritdoc />
        QueryContext<TParameters, TQueryResult> QueryComponent<TParameters, TQueryResult>.QueryContext
        {
            get { return QueryContext; }
        }

        private QueryContext<TParameters, TQueryResult> QueryContext { get; }
        private Expression<Func<TSqlExpression>> Expression { get; }
        private Alias Alias { get; set; }
    }
}
