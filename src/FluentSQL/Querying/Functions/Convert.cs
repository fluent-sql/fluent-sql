using FluentSQL.Modelling;

namespace FluentSQL.Querying.Functions
{
    /// <summary>
    ///     Convert a <see cref="SqlExpression{TExpressionType}">SqlExpression&lt;TFrom&gt;</see> to
    ///     <see cref="SqlExpression{TExpressionType}">SqlExpression&lt;To&gt;</see>.
    /// </summary>
    public sealed class Convert<TFrom, TTo> : SqlExpression<TTo>
    {
        /// <summary>
        ///     Create a new CONVERT-expression.
        /// </summary>
        /// <param name="expression">
        ///     The <see cref="SqlExpression{TExpressionType}" /> that should be converted to <typeparamref name="TTo" />.
        /// </param>
        public Convert(SqlExpression<TFrom> expression)
        {
            Expression = expression;
        }

        private SqlExpression<TFrom> Expression { get; }
    }
}
