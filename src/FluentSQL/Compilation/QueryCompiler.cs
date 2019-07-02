using FluentSQL.Querying;

namespace FluentSQL.Compilation
{
    /// <summary>
    ///     Compiles a <see cref="QueryContext{TParameters, TQueryResult}" /> to a query.
    /// </summary>
    public abstract class QueryCompiler
    {
        /// <summary>
        ///     Compile <paramref name="context" /> to an executable query.
        /// </summary>
        /// <typeparam name="TQueryResult">The result type.</typeparam>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this query.
        /// </typeparam>
        /// <param name="context">The <see cref="QueryContext{TParameters, TQueryResult}" /> that contains all query parts.</param>
        /// <returns>The compilation result.</returns>
        internal CompilationResult Compile<TParameters, TQueryResult>(QueryContext<TParameters, TQueryResult> context)
            where TParameters : new()
        {
            var parser = new QueryParser<TParameters, TQueryResult>();
            AbstractSyntaxTree ast = parser.Parse(context);

            return new CompilationResult();
        }
    }
}
