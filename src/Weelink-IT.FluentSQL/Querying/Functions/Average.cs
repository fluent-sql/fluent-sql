using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.Functions
{
    /// <summary>
    ///     Averages a <see cref="SqlExpression{TType}" />.
    /// </summary>
    public sealed class Average<TType> : SqlExpression<TType>
    {
        /// <summary>
        ///     Create a new AVERAGE-expression.
        /// </summary>
        /// <param name="expression">The actual <see cref="SqlExpression{TType}" /> that should be averaged.</param>
        public Average(SqlExpression<TType> expression)
        {
            Expression = expression;
        }

        private SqlExpression<TType> Expression { get; }
    }
}
