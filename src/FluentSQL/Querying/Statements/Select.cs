using System;
using System.Linq.Expressions;

using FluentSQL.Compilation.Parser;

namespace FluentSQL.Querying.Statements
{
    /// <summary>
    ///     The <c>SELECT</c>-statement of a <see cref="Query{TParameters, TQueryResult}" />.
    /// </summary>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing this query.
    /// </typeparam>
    /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
    /// <typeparam name="TSqlExpression">The expression to select.</typeparam>
    public class Select<TParameters, TQueryResult, TSqlExpression> :
        QueryComponent<TParameters, TQueryResult>
        where TParameters : new()
    {
        /// <summary>
        ///     Create a new <c>SELECT</c>-statement.
        /// </summary>
        /// <param name="queryContext">The <see cref="QueryContext{TParameters, TResult}" />.</param>
        /// <param name="expression">
        ///     The <see cref="Expression{TDelegate}">Expression&lt;Func&lt;TSqlExpression&gt;&gt;</see> to select.
        /// </param>
        internal Select(QueryContext<TParameters, TQueryResult> queryContext, Expression<Func<TSqlExpression>> expression)
            : base(queryContext)
        {
            Expression = expression;

            QueryContext.Components.Add(this);
        }

        /// <summary>
        ///     Sets the alias under which this expression will be known.
        /// </summary>
        /// <param name="alias">The alias.</param>
        /// <returns><c>this</c> for method chaining.</returns>
        public Select<TParameters, TQueryResult, TSqlExpression> As(string alias)
        {
            Alias = new Alias(alias);
            return this;
        }
  
        /// <summary>
        ///     Sets the alias under which this expression will be known
        ///     where the name is derived from a property in the class <typeparamref name="TQueryResult"/>.
        /// </summary>
        /// <param name="alias">The alias.</param>
        /// <returns><c>this</c> for method chaining.</returns>
        public Select<TParameters, TQueryResult, TSqlExpression> As(Expression<Func<TQueryResult, object>> alias)
        {
            Alias = new Alias("TODO");
            return this;
        }

        internal override void Parse(QueryParser parser)
        {
            if (Alias != null)
            {
                parser.Select(Expression, Alias);
            }
            else
            {
                parser.Select(Expression);
            }
        }

        private Expression<Func<TSqlExpression>> Expression { get; }
        private Alias Alias { get; set; }
    }
}
