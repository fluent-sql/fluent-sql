using FluentSQL.Modelling;

namespace FluentSQL.Querying.Functions
{
    /// <summary>
    ///     Gets the maximum of a <see cref="SqlExpression{TExpressionType}" />.
    /// </summary>
    public sealed class Max<TExpressionType> : SqlExpression<TExpressionType>
    {
        /// <summary>
        ///     Create a new MAX-expression.
        /// </summary>
        /// <param name="expression">The actual <see cref="SqlExpression{TExpressionType}" /> where the maximum should be found.</param>
        public Max(SqlExpression<TExpressionType> expression)
        {
            Expression = expression;
        }

        private SqlExpression<TExpressionType> Expression { get; }
    }
}
