using FluentSQL.Modelling;

namespace FluentSQL.Querying.Functions
{
    /// <summary>
    ///     Averages a <see cref="SqlExpression{TExpressionType}" />.
    /// </summary>
    public sealed class Average<TExpressionType> : SqlExpression<TExpressionType>
    {
        /// <summary>
        ///     Create a new AVERAGE-expression.
        /// </summary>
        /// <param name="expression">The actual <see cref="SqlExpression{TExpressionType}" /> that should be averaged.</param>
        public Average(SqlExpression<TExpressionType> expression)
        {
            Expression = expression;
        }

        private SqlExpression<TExpressionType> Expression { get; }
    }
}
