using WeelinkIT.FluentSQL.Querying;

namespace WeelinkIT.FluentSQL.Databases
{
    /// <summary>
    ///     Represents the database.
    /// </summary>
    public abstract class Database
    {
        /// <summary>
        ///     Construct a new database.
        /// </summary>
        /// <param name="compiler">The <see cref="QueryCompiler" /> to use for compiling
        ///     <see cref="QueryContext{TParameters, TQueryResult}"/> to <see cref="Query{TParameters, TQueryResult}" />.
        /// </param>
        protected Database(QueryCompiler compiler)
        {
            Compiler = compiler;
        }

        /// <summary>
        ///     Compile <paramref name="queryContext" /> into a <see cref="Query{TParameters, TQueryResult}" />.
        /// </summary>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this <see cref="Query{TParameters, TQueryResult}" />.
        /// </typeparam>
        /// <typeparam name="TQueryResult">The result type of the <see cref="Query{TParameters, TQueryResult}" />.</typeparam>
        /// <param name="queryContext">The <see cref="QueryContext{TParameters, TQueryResult}" /> to compile.</param>
        /// <returns>A compiled <see cref="Query{TParameters, TQueryResult}" />.</returns>
        public Query<TParameters, TQueryResult> Compile<TParameters, TQueryResult>(QueryContext<TParameters, TQueryResult> queryContext)
            where TParameters : new()
        {
            return Compiler.Compile(queryContext);
        }

        /// <summary>
        ///     Compile <paramref name="queryContext" /> into a <see cref="Query{TParameters, TQueryResult}" />.
        /// </summary>
        /// <typeparam name="TQueryResult">The result type of the <see cref="Query{TParameters, TQueryResult}" />.</typeparam>
        /// <param name="queryContext">The <see cref="QueryContext{TParameters, TQueryResult}" /> to compile.</param>
        /// <returns>A compiled <see cref="Query{TQueryResult}" />.</returns>
        public Query<TQueryResult> Compile<TQueryResult>(QueryContext<NoParameters, TQueryResult> queryContext)
        {
            return Compiler.Compile(queryContext);
        }

        private QueryCompiler Compiler { get; }
    }
}
