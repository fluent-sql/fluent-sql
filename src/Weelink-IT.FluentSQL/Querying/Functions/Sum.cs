using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.Functions
{
    /// <summary>
    ///     Sums a <see cref="SqlExpression{TType}" />.
    /// </summary>
    public sealed class Sum<TType> : SqlExpression<TType>
    {
        /// <summary>
        ///     Create a new SUM-expression.
        /// </summary>
        /// <param name="expression">The actual <see cref="SqlExpression{TType}" /> that should be summed.</param>
        public Sum(SqlExpression<TType> expression)
        {
            Expression = expression;
        }

        private SqlExpression<TType> Expression { get; }
    }
}
