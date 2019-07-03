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
        ///     Compile <paramref name="context" /> to an executable query.
        /// </summary>
        /// <typeparam name="TQueryResult">The result type.</typeparam>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this query.
        /// </typeparam>
        /// <param name="context">The <see cref="QueryContext{TParameters, TQueryResult}" /> that contains all query parts.</param>
        /// <returns>The compilation result.</returns>
        internal CompilationResult CompileInternal<TParameters, TQueryResult>(QueryContext<TParameters, TQueryResult> context)
            where TParameters : new()
        {
            var parser = new QueryParser<TParameters, TQueryResult>();
            AstNode result = parser.Parse(context);
            result.Compile(Compiler);

            return new CompilationResult(result);
        }

        private QueryCompiler Compiler { get; }
    }
}
