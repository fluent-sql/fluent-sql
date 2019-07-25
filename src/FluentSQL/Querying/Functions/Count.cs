using FluentSQL.Modelling;

namespace FluentSQL.Querying.Functions
{
    /// <summary>
    ///     Counts a <see cref="SqlExpression{TExpressionType}" />.
    /// </summary>
    public sealed class Count<TExpressionType> : SqlExpression<int>
    {
        /// <summary>
        ///     Create a new COUNT-expression.
        /// </summary>
        /// <param name="expression">The actual <see cref="SqlExpression{TExpressionType}" /> that should be counted.</param>
        public Count(SqlExpression<TExpressionType> expression)
        {
            Expression = expression;
        }

        private SqlExpression<TExpressionType> Expression { get; }
    }
}
