using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.Functions
{
    /// <summary>
    ///     Trims a string.
    /// </summary>
    public sealed class Trim : SqlExpression<string>
    {
        /// <summary>
        ///     Create a new TRIM-expression.
        /// </summary>
        /// <param name="expression">The string to trim.</param>
        public Trim(SqlExpression<string> expression)
        {
            Expression = expression;
        }

        private SqlExpression<string> Expression { get; }
    }
}
