using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.Functions
{
    /// <summary>
    ///     Convert a <see cref="SqlExpression{TType}">SqlExpression&lt;TFrom&gt;</see> to
    ///     <see cref="SqlExpression{TType}">SqlExpression&lt;To&gt;</see>.
    /// </summary>
    public sealed class Convert<TFrom, TTo> : SqlExpression<TTo>
    {
        /// <summary>
        ///     Create a new CONVERT-expression.
        /// </summary>
        /// <param name="expression">
        ///     The <see cref="SqlExpression{TType}" /> that should be converted to <typeparamref name="TTo" />.
        /// </param>
        public Convert(SqlExpression<TFrom> expression)
        {
            Expression = expression;
        }

        private SqlExpression<TFrom> Expression { get; }
    }
}
