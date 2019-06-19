﻿using WeelinkIT.FluentSQL.Querying;

namespace WeelinkIT.FluentSQL.Databases
{
    /// <summary>
    ///     Compiles a <see cref="QueryContext{TParameters, TQueryResult}" /> to a <see cref="Query{TParameters, TQueryResult}" />.
    /// </summary>
    public interface QueryCompiler
    {
        /// <summary>
        ///     Compile <paramref name="context" /> to an executable <see cref="Query{TParameters, TQueryResult}" />.
        /// </summary>
        /// <typeparam name="TQueryResult">The result type.</typeparam>
        /// <typeparam name="TParameters">
        ///     The parameters required for executing this <see cref="Query{TParameters, TQueryResult}" />.
        /// </typeparam>
        /// <param name="context">The <see cref="QueryContext{TParameters, TQueryResult}" /> that contains all query parts.</param>
        /// <returns>The compilation result.</returns>
        CompilationResult Compile<TParameters, TQueryResult>(QueryContext<TParameters, TQueryResult> context)
            where TParameters : new();
    }
}
