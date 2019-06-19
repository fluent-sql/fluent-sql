namespace WeelinkIT.FluentSQL.Compilation
{
    /// <summary>
    ///     The result of the compilation of a <see cref="Query{TParameters, TQueryResult}" />.
    /// </summary>
    public class CompilationResult
    {
        /// <summary>
        ///     Gets the SQL to execute.
        /// </summary>
        public string CommandText { get; }
    }
}
