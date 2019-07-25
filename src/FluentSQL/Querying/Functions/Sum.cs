using FluentSQL.Modelling;

namespace FluentSQL.Querying.Functions
{
    /// <summary>
    ///     Sums a <see cref="SqlExpression{TExpressionType}" />.
    /// </summary>
    public sealed class Sum<TExpressionType> : SqlExpression<TExpressionType>
    {
        /// <summary>
        ///     Create a new SUM-expression.
        /// </summary>
        /// <param name="expression">The actual <see cref="SqlExpression{TExpressionType}" /> that should be summed.</param>
        public Sum(TExpressionType expression)
        {
            Expression = expression;
        }

        private TExpressionType Expression { get; }
    }
}
