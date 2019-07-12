using FluentSQL.Compilation;
using FluentSQL.Compilation.Parser;
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
        /// <param name="queryContext">The <see cref="QueryContext{TParameters,TQueryResult}" /> to compile.</param>
        /// <returns>A compiled query.</returns>
        public Query<TParameters, TQueryResult> Compile<TParameters, TQueryResult>(QueryContext<TParameters, TQueryResult> queryContext)
        {
            CompilationResult result = CompileInternal(queryContext);
            return new Query<TParameters, TQueryResult>(result);
        }

        /// <summary>
        ///     Compile <paramref name="queryContext" /> into a query.
        /// </summary>
        /// <typeparam name="TQueryResult">The result type of the query.</typeparam>
        /// <param name="queryContext">The <see cref="QueryContext{TParameters, TQueryResult}" /> to compile.</param>
        /// <returns>A compiled query.</returns>
        public Query<TQueryResult> Compile<TQueryResult>(QueryContext<NoParameters, TQueryResult> queryContext)
        {
            CompilationResult result = CompileInternal(queryContext);
            return new Query<TQueryResult>(result);
        }

        /// <summary>
        ///     Compile <paramref name="context" /> to an executable query.
        /// </summary>
        /// <typeparam name="TQueryResult">The result type.</typeparam>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this query.
        /// </typeparam>
        /// <param name="context">The <see cref="QueryContext{TParameters, TQueryResult}" /> that contains all query parts.</param>
        /// <returns>The compilation result.</returns>
        internal CompilationResult CompileInternal<TParameters, TQueryResult>(QueryContext<TParameters, TQueryResult> context)
        {
            var parser = new QueryParser();
            AstNode node = parser.Parse(context);

            CompilationResult result = Compiler.Compile(node);

            return result;
        }

        private QueryCompiler Compiler { get; }
    }
}
