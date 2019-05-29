using System;

namespace WeelinkIT.FluentSQL.Modelling
{
    /// <summary>
    ///     Represnts a column.
    /// </summary>
    /// <typeparam name="TType">The column type.</typeparam>
    public class Column<TType>
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
        ///     Implicitly convert <paramref name="column" /> to <typeparamref name="TType" />, so that it can be used
        ///     in regular .NET constructs
        /// </summary>
        /// <example>
        ///     <code>
        ///         Column&lt;string&gt; column = ...;
        ///         Query&lt;int&gt; query = 
        ///             new ExampleModel(new SqlServerDatabase())
        ///                 .Query&lt;int&gt;()
        ///                 .From(m =&gt; m.Customers)
        ///                 .Where(c =&gt; string.IsNullOrEmpty(c.Name))
        ///     </code>
        /// </example>
        public static implicit operator TType(Column<TType> column)
        {
            return default(TType);
        }

        /// <summary>
        ///     Allows for an <c>equals</c> comparison between a <see cref="Column{TType}" /> and
        ///     a value of type <typeparamref name="TType" />.
        /// </summary>
        public static bool operator ==(Column<TType> column, TType value)
        {
            return false;
        }

        /// <summary>
        ///     Allows for a <c>not equals</c> comparison between a <see cref="Column{TType}" /> and
        ///     a value of type <typeparamref name="TType" />.
        /// </summary>
        public static bool operator !=(Column<TType> column, TType value)
        {
            return false;
        }

        /// <summary>
        ///     Allows for an <c>greater than</c> comparison between a <see cref="Column{TType}" /> and
        ///     a value of type <typeparamref name="TType" />.
        /// </summary>
        public static bool operator >(Column<TType> column, TType value)
        {
            return false;
        }

        /// <summary>
        ///     Allows for an <c>less than</c> comparison between a <see cref="Column{TType}" /> and
        ///     a value of type <typeparamref name="TType" />.
        /// </summary>
        public static bool operator <(Column<TType> column, TType value)
        {
            return false;
        }

        /// <summary>
        ///     Allows for an <c>greater than or equal</c> comparison between a <see cref="Column{TType}" /> and
        ///     a value of type <typeparamref name="TType" />.
        /// </summary>
        public static bool operator >=(Column<TType> column, TType value)
        {
            return false;
        }

        /// <summary>
        ///     Allows for an <c>less than or equal</c> comparison between a <see cref="Column{TType}" /> and
        ///     a value of type <typeparamref name="TType" />.
        /// </summary>
        public static bool operator <=(Column<TType> column, TType value)
        {
            return false;
        }

        /// <summary>
        ///     Allows for an <c>equals</c> comparison between two <see cref="Column{TType}" />s.
        /// </summary>
        public static bool operator ==(Column<TType> column, Column<TType> other)
        {
            return false;
        }

        
        /// <summary>
        ///     Allows for a <c>not equals</c> comparison between two <see cref="Column{TType}" />s.
        ///     a value of type <typeparamref name="TType" />.
        /// </summary>
        public static bool operator !=(Column<TType> column, Column<TType> other)
        {
            return false;
        }

        /// <summary>
        ///     Allows for an <c>greater than</c> comparison between two <see cref="Column{TType}" />s.
        /// </summary>
        public static bool operator >(Column<TType> column, Column<TType> other)
        {
            return false;
        }

        
        /// <summary>
        ///     Allows for an <c>less than</c> comparison between two <see cref="Column{TType}" />s.
        /// </summary>
        public static bool operator <(Column<TType> column, Column<TType> other)
        {
            return false;
        }

        /// <summary>
        ///     Allows for an <c>greater than or equal</c> comparison between two <see cref="Column{TType}" />s.
        /// </summary>
        public static bool operator >=(Column<TType> column, Column<TType> other)
        {
            return false;
        }

        /// <summary>
        ///     Allows for an <c>less than or equal</c> comparison between two <see cref="Column{TType}" />s.
        /// </summary>
        public static bool operator <=(Column<TType> column, Column<TType> other)
        {
            return false;
        }
    }
}
