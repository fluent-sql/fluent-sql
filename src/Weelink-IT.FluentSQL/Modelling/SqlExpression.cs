using System;

namespace WeelinkIT.FluentSQL.Modelling
{
    /// <summary>
    ///     Any expression of type <typeparamref name="TExpressionType" /> that can be used in SQL.
    /// </summary>
    /// <typeparam name="TExpressionType">The result type of evaluating this <see cref="SqlExpression{TType}" />.</typeparam>
    public abstract class SqlExpression<TExpressionType>
    {
        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return false;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return new Random().Next();
        }

        /// <summary>
        ///     Implicitly convert <paramref name="expression" /> to <typeparamref name="TExpressionType" />,
        ///     so that it can be used in regular .NET constructs
        /// </summary>
        /// <example>
        ///     <code>
        ///         Query&lt;int&gt; query = 
        ///             new ExampleModel(new SqlServerDatabase())
        ///                 .Query&lt;int&gt;()
        ///                 .From(m =&gt; m.Customers)
        ///                 .Where(c =&gt; string.IsNullOrEmpty(c.Name))
        ///     </code>
        /// </example>
        public static implicit operator TExpressionType(SqlExpression<TExpressionType> expression)
        {
            return default(TExpressionType);
        }

        /// <summary>
        ///     Allows for an <c>equals</c> comparison between a <see cref="SqlExpression{TType}" /> and
        ///     a value of type <typeparamref name="TExpressionType" />.
        /// </summary>
        public static bool operator ==(SqlExpression<TExpressionType> expression, TExpressionType value)
        {
            return false;
        }

        /// <summary>
        ///     Allows for a <c>not equals</c> comparison between a <see cref="SqlExpression{TType}" /> and
        ///     a value of type <typeparamref name="TExpressionType" />.
        /// </summary>
        public static bool operator !=(SqlExpression<TExpressionType> expression, TExpressionType value)
        {
            return false;
        }

        /// <summary>
        ///     Allows for an <c>greater than</c> comparison between a <see cref="SqlExpression{TType}" /> and
        ///     a value of type <typeparamref name="TExpressionType" />.
        /// </summary>
        public static bool operator >(SqlExpression<TExpressionType> expression, TExpressionType value)
        {
            return false;
        }

        /// <summary>
        ///     Allows for an <c>less than</c> comparison between a <see cref="SqlExpression{TType}" /> and
        ///     a value of type <typeparamref name="TExpressionType" />.
        /// </summary>
        public static bool operator <(SqlExpression<TExpressionType> expression, TExpressionType value)
        {
            return false;
        }

        /// <summary>
        ///     Allows for an <c>greater than or equal</c> comparison between a <see cref="SqlExpression{TType}" /> and
        ///     a value of type <typeparamref name="TExpressionType" />.
        /// </summary>
        public static bool operator >=(SqlExpression<TExpressionType> expression, TExpressionType value)
        {
            return false;
        }

        /// <summary>
        ///     Allows for an <c>less than or equal</c> comparison between a <see cref="SqlExpression{TType}" /> and
        ///     a value of type <typeparamref name="TExpressionType" />.
        /// </summary>
        public static bool operator <=(SqlExpression<TExpressionType> expression, TExpressionType value)
        {
            return false;
        }

        /// <summary>
        ///     Allows for an <c>equals</c> comparison between two <see cref="SqlExpression{TType}" />s.
        /// </summary>
        public static bool operator ==(SqlExpression<TExpressionType> expression, SqlExpression<TExpressionType> other)
        {
            return false;
        }


        /// <summary>
        ///     Allows for a <c>not equals</c> comparison between two <see cref="SqlExpression{TType}" />s.
        ///     a value of type <typeparamref name="TExpressionType" />.
        /// </summary>
        public static bool operator !=(SqlExpression<TExpressionType> expression, SqlExpression<TExpressionType> other)
        {
            return false;
        }

        /// <summary>
        ///     Allows for an <c>greater than</c> comparison between two <see cref="SqlExpression{TType}" />s.
        /// </summary>
        public static bool operator >(SqlExpression<TExpressionType> expression, SqlExpression<TExpressionType> other)
        {
            return false;
        }


        /// <summary>
        ///     Allows for an <c>less than</c> comparison between two <see cref="SqlExpression{TType}" />s.
        /// </summary>
        public static bool operator <(SqlExpression<TExpressionType> expression, SqlExpression<TExpressionType> other)
        {
            return false;
        }

        /// <summary>
        ///     Allows for an <c>greater than or equal</c> comparison between two <see cref="SqlExpression{TType}" />s.
        /// </summary>
        public static bool operator >=(SqlExpression<TExpressionType> expression, SqlExpression<TExpressionType> other)
        {
            return false;
        }

        /// <summary>
        ///     Allows for an <c>less than or equal</c> comparison between two <see cref="SqlExpression{TType}" />s.
        /// </summary>
        public static bool operator <=(SqlExpression<TExpressionType> expression, SqlExpression<TExpressionType> other)
        {
            return false;
        }
    }
}
