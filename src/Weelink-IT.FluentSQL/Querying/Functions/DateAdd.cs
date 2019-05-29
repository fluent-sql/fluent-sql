using System;

using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.Functions
{
    /// <summary>
    ///     Adds a date part to a <see cref="DateTime" /> or <see cref="DateTimeOffset" />.
    /// </summary>
    public sealed class DateAdd : SqlExpression<DateTime>
    {
        /// <summary>
        ///     Create a new DATEADD-expression.
        /// </summary>
        /// <param name="expression">The <see cref="DateTime" /> to add <paramref name="interval" /> to.</param>
        /// <param name="interval">The interval to add.</param>
        public DateAdd(SqlExpression<DateTime> expression, TimeSpan interval)
        {
            DateTimeExpression = expression;
            Interval = interval;
        }

        /// <summary>
        ///     Create a new DATEADD-expression.
        /// </summary>
        /// <param name="expression">The <see cref="DateTimeOffset" /> to add <paramref name="interval" /> to.</param>
        /// <param name="interval">The interval to add.</param>
        public DateAdd(SqlExpression<DateTimeOffset> expression, TimeSpan interval)
        {
            DateTimeOffsetExpression = expression;
            Interval = interval;
        }

        private SqlExpression<DateTime> DateTimeExpression { get; }
        private SqlExpression<DateTimeOffset> DateTimeOffsetExpression { get; }
        private TimeSpan Interval { get; }
    }
}
