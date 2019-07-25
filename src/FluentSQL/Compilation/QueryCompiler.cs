using FluentSQL.Compilation.Parser;
using FluentSQL.Querying;

namespace FluentSQL.Compilation
{
    /// <summary>
    ///     Compiles a <see cref="QueryContext{TParameters,TQueryResult}" /> to a query.
    /// </summary>
    public abstract class QueryCompiler
    {
        /// <summary>
        ///     Compile <paramref name="node" /> and return the result.
        /// </summary>
        /// <param name="node">The node to compile.</param>
        /// <returns>The result of the compilation.</returns>
        public abstract CompilationResult Compile(AstNode node);
    }
}
