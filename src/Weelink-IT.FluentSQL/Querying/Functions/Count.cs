using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.Functions
{
    /// <summary>
    ///     Counts a <see cref="SqlExpression{TType}" />.
    /// </summary>
    public sealed class Count<TType> : SqlExpression<int>
    {
        /// <summary>
        ///     Create a new COUNT-expression.
        /// </summary>
        /// <param name="expression">The actual <see cref="SqlExpression{TType}" /> that should be counted.</param>
        public Count(SqlExpression<TType> expression)
        {
            Expression = expression;
        }

        private SqlExpression<TType> Expression { get; }
    }
}
