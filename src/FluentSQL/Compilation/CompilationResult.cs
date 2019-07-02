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
        /// <param name="queryNode">The AST of the parsed query.</param>
        public CompilationResult(Node queryNode)
        {
            QueryNode = queryNode;
        }

        /// <summary>
        ///     Gets the abstract syntax tree representing the query.
        /// </summary>
        public Node QueryNode { get; }
    }
}
