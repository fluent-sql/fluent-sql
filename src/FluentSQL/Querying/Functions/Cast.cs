using FluentSQL.Modelling;

namespace FluentSQL.Querying.Functions
{
    /// <summary>
    ///     Casts a <see cref="SqlExpression{TExpressionType}">SqlExpression&lt;TFrom&gt;</see> to
    ///     <see cref="SqlExpression{TExpressionType}">SqlExpression&lt;To&gt;</see>.
    /// </summary>
    public sealed class Cast<TFrom, TTo> : SqlExpression<TTo>
    {
        /// <summary>
        ///     Create a new CAST-expression.
        /// </summary>
        /// <param name="expression">
        ///     The <see cref="SqlExpression{TExpressionType}" /> that should be casted to <typeparamref name="TTo" />.
        /// </param>
        public Cast(SqlExpression<TFrom> expression)
        {
            Expression = expression;
        }

        private SqlExpression<TFrom> Expression { get; }
    }
}
