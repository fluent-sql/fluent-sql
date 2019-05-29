using System;

using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.Functions
{
    /// <summary>
    ///     Gets the difference between two <see cref="DateTime" />s or <see cref="DateTimeOffset" />s.
    /// </summary>
    public sealed class DateDiff : SqlExpression<int>
    {
        /// <summary>
        ///     Create a new DATEDIFF expression.
        /// </summary>
        /// <param name="first">The left hand side of the date diff.</param>
        /// <param name="second">The right hand side of the date diff.</param>
        public DateDiff(SqlExpression<DateTime> first, SqlExpression<DateTime> second)
        {
            DateTimeFirst = first;
            DateTimeSecond = second;
        }

        /// <summary>
        ///     Create a new DATEDIFF expression.
        /// </summary>
        /// <param name="first">The left hand side of the date diff.</param>
        /// <param name="second">The right hand side of the date diff.</param>
        public DateDiff(SqlExpression<DateTimeOffset> first, SqlExpression<DateTimeOffset> second)
        {
            DateTimeOffsetFirst = first;
            DateTimeOffsetSecond = second;
        }

        private SqlExpression<DateTime> DateTimeFirst { get; }
        private SqlExpression<DateTime> DateTimeSecond { get; }
        private SqlExpression<DateTimeOffset> DateTimeOffsetFirst { get; }
        private SqlExpression<DateTimeOffset> DateTimeOffsetSecond { get; }
    }
}
