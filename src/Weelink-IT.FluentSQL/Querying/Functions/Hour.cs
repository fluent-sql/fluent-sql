using System;

using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.Functions
{
    /// <summary>
    ///     Gets the hour-component of a <see cref="DateTime" /> or <see cref="DateTimeOffset" />.
    /// </summary>
    public sealed class Hour : SqlExpression<int>
    {
        /// <summary>
        ///     Create a new HOUR-expression.
        /// </summary>
        /// <param name="expression">The <see cref="DateTime" /> to get the hour-component from.</param>
        public Hour(SqlExpression<DateTime> expression)
        {
            DateTimeExpression = expression;
        }

        /// <summary>
        ///     Create a new HOUR-expression.
        /// </summary>
        /// <param name="expression">The <see cref="DateTimeOffset" /> to get the hour-component from.</param>
        public Hour(SqlExpression<DateTimeOffset> expression)
        {
            DateTimeOffsetExpression = expression;
        }

        private SqlExpression<DateTime> DateTimeExpression { get; }
        private SqlExpression<DateTimeOffset> DateTimeOffsetExpression { get; }
    }
}
