using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.Functions
{
    /// <summary>
    ///     Gets a substring of a string.
    /// </summary>
    public sealed class Substring : SqlExpression<string>
    {
        /// <summary>
        ///     Create a new SUBSTRING-expression.
        /// </summary>
        /// <param name="expression">The string to apply this expression to.</param>
        public Substring(SqlExpression<string> expression)
        {
            Expression = expression;
        }

        private SqlExpression<string> Expression { get; }
    }
}
