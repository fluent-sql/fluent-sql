using System;

using FluentSQL.Modelling;

namespace FluentSQL.Querying.Functions
{
    /// <summary>
    ///     Gets the minute-component of a <see cref="DateTime" /> or <see cref="DateTimeOffset" />.
    /// </summary>
    public sealed class Minute : SqlExpression<int>
    {
        /// <summary>
        ///     Create a new MINUTE-expression.
        /// </summary>
        /// <param name="expression">The <see cref="DateTime" /> to get the minute-component from.</param>
        public Minute(SqlExpression<DateTime> expression)
        {
            DateTimeExpression = expression;
        }

        /// <summary>
        ///     Create a new MINUTE-expression.
        /// </summary>
        /// <param name="expression">The <see cref="DateTimeOffset" /> to get the minute-component from.</param>
        public Minute(SqlExpression<DateTimeOffset> expression)
        {
            DateTimeOffsetExpression = expression;
        }

        private SqlExpression<DateTime> DateTimeExpression { get; }
        private SqlExpression<DateTimeOffset> DateTimeOffsetExpression { get; }
    }
}
