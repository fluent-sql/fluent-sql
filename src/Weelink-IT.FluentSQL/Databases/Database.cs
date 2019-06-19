using WeelinkIT.FluentSQL.Compilation;
using WeelinkIT.FluentSQL.Extensions;
using WeelinkIT.FluentSQL.Querying;

namespace WeelinkIT.FluentSQL.Databases
{
    /// <summary>
    ///     Represents the database.
    /// </summary>
    public abstract class Database
    {
        /// <summary>
        ///     Construct a new database.
        /// </summary>
        /// <param name="compiler">The <see cref="QueryCompiler" /> to use for compiling queries.</param>
        protected Database(QueryCompiler compiler)
        {
            Compiler = compiler;
        }

        /// <summary>
        ///     Compile <paramref name="queryContext" /> into a query.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this query.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <param name="queryContext">The <see cref="QueryContext{TParameters, TQueryResult}" /> to compile.</param>
        /// <returns>A compiled query.</returns>
        public Query<TParameters, TQueryResult> Compile<TParameters, TQueryResult>(QueryContext<TParameters, TQueryResult> queryContext)
            where TParameters : new()
        {
            CompilationResult result = Compiler.Compile(queryContext);
            return new Query<TParameters, TQueryResult>(this, result.CommandText);
        }

        /// <summary>
        ///     Compile <paramref name="queryContext" /> into a query.
        /// </summary>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <param name="queryContext">The <see cref="QueryContext{TParameters, TQueryResult}" /> to compile.</param>
        /// <returns>A compiled query.</returns>
        public Query<TQueryResult> Compile<TQueryResult>(QueryContext<TQueryResult> queryContext)
        {
            QueryContext<NoParameters, TQueryResult> contextWithoutParameters = queryContext.WithParameters<NoParameters>();

            queryContext.FromComponents.CopyTo(contextWithoutParameters.FromComponents);
            queryContext.SelectComponents.CopyTo(contextWithoutParameters.SelectComponents);
            queryContext.JoinComponents.CopyTo(contextWithoutParameters.JoinComponents);
            queryContext.WhereComponents.CopyTo(contextWithoutParameters.WhereComponents);
            queryContext.OrderByComponents.CopyTo(contextWithoutParameters.OrderByComponents);
            queryContext.GroupByComponents.CopyTo(contextWithoutParameters.GroupByComponents);
            queryContext.Modifiers.CopyTo(contextWithoutParameters.Modifiers);

            CompilationResult result = Compiler.Compile(contextWithoutParameters);

            return new Query<TQueryResult>(this, result.CommandText);
        }

        private QueryCompiler Compiler { get; }
    }
}
