using FluentSQL.Modelling;

namespace FluentSQL.Querying.Functions
{
    /// <summary>
    ///     Gets the minimum of a <see cref="SqlExpression{TType}" />.
    /// </summary>
    public sealed class Min<TType> : SqlExpression<TType>
    {
        /// <summary>
        ///     Create a new MIN-expression.
        /// </summary>
        /// <param name="expression">The actual <see cref="SqlExpression{TType}" /> where the minimum should be found.</param>
        public Min(SqlExpression<TType> expression)
        {
            Expression = expression;
        }

        private SqlExpression<TType> Expression { get; }
    }
}
