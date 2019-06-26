using FluentSQL.Compilation;
using FluentSQL.Modelling;

namespace FluentSQL
{
    /// <summary>
    ///     The compiled query to execute.
    /// </summary>
    /// <typeparam name="TQueryResult">The result type.</typeparam>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing this query.
    /// </typeparam>
    public class Query<TParameters, TQueryResult> : SqlExpression<TQueryResult> where TParameters : new()
    {
        /// <summary>
        ///     Create a new query.
        /// </summary>
        /// <param name="compilationResult">The result of the compilation.</param>
        internal Query(CompilationResult compilationResult)
        {
            CompilationResult = compilationResult;
        }

        private CompilationResult CompilationResult { get; }
    }

    /// <summary>
    ///     The compiled query to execute.
    /// </summary>
    /// <typeparam name="TQueryResult">The result type.</typeparam>
    public class Query<TQueryResult> : SqlExpression<TQueryResult>
    {
        /// <summary>
        ///     Create a new query.
        /// </summary>
        /// <param name="compilationResult">The result of the compilation.</param>
        public Query(CompilationResult compilationResult)
        {
            CompilationResult = compilationResult;
        }

        private CompilationResult CompilationResult { get; }
    }
}
