namespace FluentSQL.Compilation
{
    /// <summary>
    ///     The result of the compilation of a query.
    /// </summary>
    public sealed class CompilationResult
    {
        /// <summary>
        ///     Initializes a new <see cref="CompilationResult" />.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        public CompilationResult(string sql)
        {
            Sql = sql;
        }

        /// <summary>
        ///     Gets the abstract syntax tree representing the query.
        /// </summary>
        public string Sql { get; }
    }
}
