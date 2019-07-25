using FluentSQL.Modelling;

namespace FluentSQL.Querying.Functions.Extensions
{
    /// <summary>
    ///     Allows <see cref="SqlExpression{TExpressionType}" />s to be summed.
    /// </summary>
    public static class SumExtensions
    {
        /// <summary>
        ///     Sums the <paramref name="subject" />.
        /// </summary>
        /// <param name="subject">The <see cref="SqlExpression{TExpressionType}">SqlExpression&lt;int&gt;</see> to sum.</param>
        /// <returns>A <see cref="SqlExpression{Int32}" /> representing the summed total.</returns>
        public static SqlExpression<int> Sum(this SqlExpression<int> subject)
        {
            return new Sum<int>(subject);
        }

        /// <summary>
        ///     Sums the <paramref name="subject" />.
        /// </summary>
        /// <param name="subject">The <see cref="SqlExpression{TExpressionType}">SqlExpression&lt;int?&gt;</see> to sum.</param>
        /// <returns>A <see cref="SqlExpression{Int32}" /> representing the summed total.</returns>
        public static SqlExpression<int?> Sum(this SqlExpression<int?> subject)
        {
            return new Sum<int?>(subject);
        }

        /// <summary>
        ///     Sums the <paramref name="subject" />.
        /// </summary>
        /// <param name="subject">The <see cref="SqlExpression{TExpressionType}">SqlExpression&lt;long&gt;</see> to sum.</param>
        /// <returns>A <see cref="SqlExpression{Int64}" /> representing the summed total.</returns>
        public static SqlExpression<long> Sum(this SqlExpression<long> subject)
        {
            return new Sum<long>(subject);
        }

        /// <summary>
        ///     Sums the <paramref name="subject" />.
        /// </summary>
        /// <param name="subject">The <see cref="SqlExpression{TExpressionType}">SqlExpression&lt;long?&gt;</see> to sum.</param>
        /// <returns>A <see cref="SqlExpression{Int64}" /> representing the summed total.</returns>
        public static SqlExpression<long?> Sum(this SqlExpression<long?> subject)
        {
            return new Sum<long?>(subject);
        }

        /// <summary>
        ///     Sums the <paramref name="subject" />.
        /// </summary>
        /// <param name="subject">The <see cref="SqlExpression{TExpressionType}">SqlExpression&lt;decimal&gt;</see> to sum.</param>
        /// <returns>A <see cref="SqlExpression{Int64}" /> representing the summed total.</returns>
        public static SqlExpression<decimal> Sum(this SqlExpression<decimal> subject)
        {
            return new Sum<decimal>(subject);
        }

        /// <summary>
        ///     Sums the <paramref name="subject" />.
        /// </summary>
        /// <param name="subject">The <see cref="SqlExpression{TExpressionType}">SqlExpression&lt;decimal?&gt;</see> to sum.</param>
        /// <returns>A <see cref="SqlExpression{Int64}" /> representing the summed total.</returns>
        public static SqlExpression<decimal?> Sum(this SqlExpression<decimal?> subject)
        {
            return new Sum<decimal?>(subject);
        }

        /// <summary>
        ///     Sums the <paramref name="subject" />.
        /// </summary>
        /// <param name="subject">The <see cref="SqlExpression{TExpressionType}">SqlExpression&lt;float&gt;</see> to sum.</param>
        /// <returns>A <see cref="SqlExpression{Int64}" /> representing the summed total.</returns>
        public static SqlExpression<float> Sum(this SqlExpression<float> subject)
        {
            return new Sum<float>(subject);
        }

        /// <summary>
        ///     Sums the <paramref name="subject" />.
        /// </summary>
        /// <param name="subject">The <see cref="SqlExpression{TExpressionType}">SqlExpression&lt;float?&gt;</see> to sum.</param>
        /// <returns>A <see cref="SqlExpression{Int64}" /> representing the summed total.</returns>
        public static SqlExpression<float?> Sum(this SqlExpression<float?> subject)
        {
            return new Sum<float?>(subject);
        }
    }
}
