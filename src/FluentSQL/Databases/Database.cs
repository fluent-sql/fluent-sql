using FluentSQL.Compilation;
using FluentSQL.Querying;

namespace FluentSQL.Databases
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
        internal Query<TParameters, TQueryResult> Compile<TParameters, TQueryResult>(QueryContext<TParameters, TQueryResult> queryContext)
            where TParameters : new()
        {
            CompilationResult result = Compiler.Compile(queryContext);
            return new Query<TParameters, TQueryResult>(result);
        }

        /// <summary>
        ///     Compile <paramref name="queryContext" /> into a query.
        /// </summary>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <param name="queryContext">The <see cref="QueryContext{TParameters, TQueryResult}" /> to compile.</param>
        /// <returns>A compiled query.</returns>
        internal Query<TQueryResult> Compile<TQueryResult>(QueryContext<NoParameters, TQueryResult> queryContext)
        {
            var contextWithoutParameters = new QueryContext<NoParameters, TQueryResult>(queryContext);

            CompilationResult result = Compiler.Compile(contextWithoutParameters);
            return new Query<TQueryResult>(result);
        }

        private QueryCompiler Compiler { get; }
    }
}
