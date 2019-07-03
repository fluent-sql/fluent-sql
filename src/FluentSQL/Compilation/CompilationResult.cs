using FluentSQL.Compilation.Parser;

namespace FluentSQL.Compilation
{
    /// <summary>
    ///     The result of the compilation of a query.
    /// </summary>
    public class CompilationResult
    {
        /// <summary>
        ///     Initializes a new <see cref="CompilationResult" />.
        /// </summary>
        /// <param name="astNode">The AST of the parsed query.</param>
        public CompilationResult(AstNode astNode)
        {
            AstNode = astNode;
        }

        /// <summary>
        ///     Gets the abstract syntax tree representing the query.
        /// </summary>
        public AstNode AstNode { get; }
    }
}
