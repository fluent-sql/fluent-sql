using FluentSQL.Modelling;

namespace FluentSQL.Querying.Functions
{
    /// <summary>
    ///     Gets the maximum of a <see cref="SqlExpression{TType}" />.
    /// </summary>
    public sealed class Max<TType> : SqlExpression<TType>
    {
        /// <summary>
        ///     Create a new MAX-expression.
        /// </summary>
        /// <param name="expression">The actual <see cref="SqlExpression{TType}" /> where the maximum should be found.</param>
        public Max(SqlExpression<TType> expression)
        {
            Expression = expression;
        }

        private SqlExpression<TType> Expression { get; }
    }
}
