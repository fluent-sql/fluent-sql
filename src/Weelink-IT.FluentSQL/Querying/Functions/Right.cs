using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.Functions
{
    /// <summary>
    ///     Gets the right part of a string.
    /// </summary>
    public sealed class Right : SqlExpression<string>
    {
        /// <summary>
        ///     Create a new LEFT-expression.
        /// </summary>
        /// <param name="expression">The string to apply this expression to.</param>
        public Right(SqlExpression<string> expression)
        {
            Expression = expression;
        }

        private SqlExpression<string> Expression { get; }
    }
}
