using FluentSQL.Modelling;

namespace FluentSQL.Querying.Functions
{
    /// <summary>
    ///     Gets the minimum of a <see cref="SqlExpression{TExpressionType}" />.
    /// </summary>
    public sealed class Min<TExpressionType> : SqlExpression<TExpressionType>
    {
        /// <summary>
        ///     Create a new MIN-expression.
        /// </summary>
        /// <param name="expression">The actual <see cref="SqlExpression{TExpressionType}" /> where the minimum should be found.</param>
        public Min(SqlExpression<TExpressionType> expression)
        {
            Expression = expression;
        }

        private SqlExpression<TExpressionType> Expression { get; }
    }
}
