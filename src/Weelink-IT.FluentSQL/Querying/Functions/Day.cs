using System;

using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.Functions
{
    /// <summary>
    ///     Gets the day-component of a <see cref="DateTime" /> or <see cref="DateTimeOffset" />.
    /// </summary>
    public sealed class Day : SqlExpression<int>
    {
        /// <summary>
        ///     Create a new DAY-expression for a <see cref="DateTime" />.
        /// </summary>
        /// <param name="expression">The <see cref="DateTime" /> to get the day-component from.</param>
        public Day(SqlExpression<DateTime> expression)
        {
            DateTimeExpression = expression;
        }

        /// <summary>
        ///     Create a new DAY-expression for a <see cref="DateTimeOffset" />.
        /// </summary>
        /// <param name="expression">The <see cref="DateTimeOffset" /> to get the day-component from.</param>
        public Day(SqlExpression<DateTimeOffset> expression)
        {
            DateTimeOffsetExpression = expression;
        }

        private SqlExpression<DateTime> DateTimeExpression { get; }
        private SqlExpression<DateTimeOffset> DateTimeOffsetExpression { get; }
    }
}
