using System;

namespace WeelinkIT.FluentSQL.Modelling
{
    /// <summary>
    ///     Reduces the result of a database expression to <typeparamref name="TType" />.
    /// </summary>
    /// <typeparam name="TType">The result type of evaluating this <see cref="SqlExpression{TType}" />.</typeparam>
    public abstract class SqlExpression<TType>
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
        ///     Implicitly convert <paramref name="expression" /> to <typeparamref name="TType" />, so that it can be used
        ///     in regular .NET constructs
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
        public static implicit operator TType(SqlExpression<TType> expression)
        {
            return default(TType);
        }

        /// <summary>
        ///     Allows for an <c>equals</c> comparison between a <see cref="SqlExpression{TType}" /> and
        ///     a value of type <typeparamref name="TType" />.
        /// </summary>
        public static bool operator ==(SqlExpression<TType> expression, TType value)
        {
            return false;
        }

        /// <summary>
        ///     Allows for a <c>not equals</c> comparison between a <see cref="SqlExpression{TType}" /> and
        ///     a value of type <typeparamref name="TType" />.
        /// </summary>
        public static bool operator !=(SqlExpression<TType> expression, TType value)
        {
            return false;
        }

        /// <summary>
        ///     Allows for an <c>greater than</c> comparison between a <see cref="SqlExpression{TType}" /> and
        ///     a value of type <typeparamref name="TType" />.
        /// </summary>
        public static bool operator >(SqlExpression<TType> expression, TType value)
        {
            return false;
        }

        /// <summary>
        ///     Allows for an <c>less than</c> comparison between a <see cref="SqlExpression{TType}" /> and
        ///     a value of type <typeparamref name="TType" />.
        /// </summary>
        public static bool operator <(SqlExpression<TType> expression, TType value)
        {
            return false;
        }

        /// <summary>
        ///     Allows for an <c>greater than or equal</c> comparison between a <see cref="SqlExpression{TType}" /> and
        ///     a value of type <typeparamref name="TType" />.
        /// </summary>
        public static bool operator >=(SqlExpression<TType> expression, TType value)
        {
            return false;
        }

        /// <summary>
        ///     Allows for an <c>less than or equal</c> comparison between a <see cref="SqlExpression{TType}" /> and
        ///     a value of type <typeparamref name="TType" />.
        /// </summary>
        public static bool operator <=(SqlExpression<TType> expression, TType value)
        {
            return false;
        }

        /// <summary>
        ///     Allows for an <c>equals</c> comparison between two <see cref="SqlExpression{TType}" />s.
        /// </summary>
        public static bool operator ==(SqlExpression<TType> expression, SqlExpression<TType> other)
        {
            return false;
        }

        
        /// <summary>
        ///     Allows for a <c>not equals</c> comparison between two <see cref="SqlExpression{TType}" />s.
        ///     a value of type <typeparamref name="TType" />.
        /// </summary>
        public static bool operator !=(SqlExpression<TType> expression, SqlExpression<TType> other)
        {
            return false;
        }

        /// <summary>
        ///     Allows for an <c>greater than</c> comparison between two <see cref="SqlExpression{TType}" />s.
        /// </summary>
        public static bool operator >(SqlExpression<TType> expression, SqlExpression<TType> other)
        {
            return false;
        }

        
        /// <summary>
        ///     Allows for an <c>less than</c> comparison between two <see cref="SqlExpression{TType}" />s.
        /// </summary>
        public static bool operator <(SqlExpression<TType> expression, SqlExpression<TType> other)
        {
            return false;
        }

        /// <summary>
        ///     Allows for an <c>greater than or equal</c> comparison between two <see cref="SqlExpression{TType}" />s.
        /// </summary>
        public static bool operator >=(SqlExpression<TType> expression, SqlExpression<TType> other)
        {
            return false;
        }

        /// <summary>
        ///     Allows for an <c>less than or equal</c> comparison between two <see cref="SqlExpression{TType}" />s.
        /// </summary>
        public static bool operator <=(SqlExpression<TType> expression, SqlExpression<TType> other)
        {
            return false;
        }
    }
}
