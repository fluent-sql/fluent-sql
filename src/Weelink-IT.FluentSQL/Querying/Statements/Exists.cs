namespace WeelinkIT.FluentSQL.Querying.Statements
{
    /// <summary>
    ///     The <c>EXISTS</c>-statement that tests for the existence of a record.
    /// </summary>
    /// <typeparam name="TQueryResult">The result type of the <see cref="Query{TParameters, TQueryResult}" />.</typeparam>
    public class Exists<TQueryResult>
    {
        /// <summary>
        ///     Create a new <c>EXISTS</c>-statement.
        /// </summary>
        /// <param name="subquery">The <see cref="Query{TQueryResult}" /> that will check the existence of records.</param>
        public Exists(Query<TQueryResult> subquery)
        {
            Subquery = subquery;
        }

        private Query<TQueryResult> Subquery { get; }

        /// <summary>
        ///     Convert this <see cref="Exists{TQueryResult}" /> to a <c>bool</c>,
        ///     so that it can be used in a <see cref="Where{TParameters,TQueryResult}" />.
        /// </summary>
        /// <param name="exists">The <see cref="Exists{TQueryResult}" /> to convert.</param>
        public static implicit operator bool(Exists<TQueryResult> exists)
        {
            return true;
        }
    }

    /// <summary>
    ///     The <c>EXISTS</c>-statement that tests for the existence of a record.
    /// </summary>
    /// <typeparam name="TParameters">
    ///     The parameters required for executing this <see cref="Query{TParameters, TQueryResult}" />.
    /// </typeparam>
    /// <typeparam name="TQueryResult">The result type of the <see cref="Query{TParameters, TQueryResult}" />.</typeparam>
    public class Exists<TParameters, TQueryResult> where TParameters : new()
    {
        /// <summary>
        ///     Create a new <c>EXISTS</c>-statement.
        /// </summary>
        /// <param name="subquery">The <see cref="Query{TParameters, TQueryResult}" /> that will check the existence of records.</param>
        public Exists(Query<TParameters, TQueryResult> subquery)
        {
            Subquery = subquery;
        }

        private Query<TParameters, TQueryResult> Subquery { get; }

        /// <summary>
        ///     Convert this <see cref="Exists{TParameters, TQueryResult}" /> to a <c>bool</c>,
        ///     so that it can be used in a <see cref="Where{TParameters,TQueryResult}" />.
        /// </summary>
        /// <param name="exists">The <see cref="Exists{TParameters, TQueryResult}" /> to convert.</param>
        public static implicit operator bool(Exists<TParameters, TQueryResult> exists)
        {
            return true;
        }
    }
}
