using System;
using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying
{
    /// <summary>
    ///     Sums a <see cref="SqlExpression{TType}" />.
    /// </summary>
    public sealed class Sum<TType> : SqlExpression<TType>
    {
        /// <summary>
        ///     Create a new SUM-expression.
        /// </summary>
        /// <param name="expression">The actual <see cref="SqlExpression{TType}" /> that should be summed.</param>
        public Sum(SqlExpression<TType> expression)
        {
            Expression = expression;
        }

        private SqlExpression<TType> Expression { get; }
    }

    /// <summary>
    ///     Casts a <see cref="SqlExpression{TType}">SqlExpression&lt;TFrom&gt;</see> to
    ///     <see cref="SqlExpression{TType}">SqlExpression&lt;To&gt;</see>.
    /// </summary>
    public sealed class Cast<TFrom, TTo> : SqlExpression<TTo>
    {
        /// <summary>
        ///     Create a new CAST-expression.
        /// </summary>
        /// <param name="expression">
        ///     The <see cref="SqlExpression{TType}" /> that should be casted to <typeparamref name="TTo" />.
        /// </param>
        public Cast(SqlExpression<TFrom> expression)
        {
            Expression = expression;
        }

        private SqlExpression<TFrom> Expression { get; }
    }

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

    /// <summary>
    ///     Gets the month-component of a <see cref="DateTime" /> or <see cref="DateTimeOffset" />.
    /// </summary>
    public sealed class Month : SqlExpression<int>
    {
        /// <summary>
        ///     Create a new MONTH-expression.
        /// </summary>
        /// <param name="expression">The <see cref="DateTime" /> to get the month-component from.</param>
        public Month(SqlExpression<DateTime> expression)
        {
            DateTimeExpression = expression;
        }

        /// <summary>
        ///     Create a new MONTH-expression.
        /// </summary>
        /// <param name="expression">The <see cref="DateTimeOffset" /> to get the month-component from.</param>
        public Month(SqlExpression<DateTimeOffset> expression)
        {
            DateTimeOffsetExpression = expression;
        }

        private SqlExpression<DateTime> DateTimeExpression { get; }
        private SqlExpression<DateTimeOffset> DateTimeOffsetExpression { get; }
    }

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

    /// <summary>
    ///     Gets the left part of a string.
    /// </summary>
    public sealed class Left : SqlExpression<string>
    {
        /// <summary>
        ///     Create a new LEFT-expression.
        /// </summary>
        /// <param name="expression">The string to apply this expression to.</param>
        public Left(SqlExpression<string> expression)
        {
            Expression = expression;
        }

        private SqlExpression<string> Expression { get; }
    }

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

    /// <summary>
    ///     Gets the right part of a string.
    /// </summary>
    public sealed class Right : SqlExpression<string>
    {
        /// <summary>
        ///     Create a new LEFT-expression.
        /// </summary>
        /// <param name="expression">The string to apply this expression to.</param>
        public Right(SqlExpression<string> expression)
        {
            Expression = expression;
        }

        private SqlExpression<string> Expression { get; }
    }

    /// <summary>
    ///     Gets the second-component of a <see cref="DateTime" /> or <see cref="DateTimeOffset" />.
    /// </summary>
    public sealed class Second : SqlExpression<int>
    {
        /// <summary>
        ///     Create a new SECOND-expression.
        /// </summary>
        /// <param name="expression">The <see cref="DateTime" /> to get the second-component from.</param>
        public Second(SqlExpression<DateTime> expression)
        {
            DateTimeExpression = expression;
        }

        /// <summary>
        ///     Create a new SECOND-expression.
        /// </summary>
        /// <param name="expression">The <see cref="DateTimeOffset" /> to get the second-component from.</param>
        public Second(SqlExpression<DateTimeOffset> expression)
        {
            DateTimeOffsetExpression = expression;
        }

        private SqlExpression<DateTime> DateTimeExpression { get; }
        private SqlExpression<DateTimeOffset> DateTimeOffsetExpression { get; }
    }

    /// <summary>
    ///     Gets the year-component of a <see cref="DateTime" /> or <see cref="DateTimeOffset" />.
    /// </summary>
    public sealed class Year : SqlExpression<int>
    {
        /// <summary>
        ///     Create a new YEAR-expression.
        /// </summary>
        /// <param name="expression">The <see cref="DateTime" /> to get the year-component from.</param>
        public Year(SqlExpression<DateTime> expression)
        {
            DateTimeExpression = expression;
        }

        /// <summary>
        ///     Create a new YEAR-expression.
        /// </summary>
        /// <param name="expression">The <see cref="DateTimeOffset" /> to get the year-component from.</param>
        public Year(SqlExpression<DateTimeOffset> expression)
        {
            DateTimeOffsetExpression = expression;
        }

        private SqlExpression<DateTime> DateTimeExpression { get; }
        private SqlExpression<DateTimeOffset> DateTimeOffsetExpression { get; }
    }

    /// <summary>
    ///     Averages a <see cref="SqlExpression{TType}" />.
    /// </summary>
    public sealed class Average<TType> : SqlExpression<TType>
    {
        /// <summary>
        ///     Create a new AVERAGE-expression.
        /// </summary>
        /// <param name="expression">The actual <see cref="SqlExpression{TType}" /> that should be averaged.</param>
        public Average(SqlExpression<TType> expression)
        {
            Expression = expression;
        }

        private SqlExpression<TType> Expression { get; }
    }

    /// <summary>
    ///     Counts a <see cref="SqlExpression{TType}" />.
    /// </summary>
    public sealed class Count<TType> : SqlExpression<int>
    {
        /// <summary>
        ///     Create a new COUNT-expression.
        /// </summary>
        /// <param name="expression">The actual <see cref="SqlExpression{TType}" /> that should be counted.</param>
        public Count(SqlExpression<TType> expression)
        {
            Expression = expression;
        }

        private SqlExpression<TType> Expression { get; }
    }

    /// <summary>
    ///     Gets the maximum of a <see cref="SqlExpression{TType}" />.
    /// </summary>
    public sealed class Max<TType> : SqlExpression<TType>
    {
        /// <summary>
        ///     Create a new MAX-expression.
        /// </summary>
        /// <param name="expression">The actual <see cref="SqlExpression{TType}" /> where the maximum should be found.</param>
        public Max(SqlExpression<TType> expression)
        {
            Expression = expression;
        }

        private SqlExpression<TType> Expression { get; }
    }

    /// <summary>
    ///     Gets the minimum of a <see cref="SqlExpression{TType}" />.
    /// </summary>
    public sealed class Min<TType> : SqlExpression<TType>
    {
        /// <summary>
        ///     Create a new MIN-expression.
        /// </summary>
        /// <param name="expression">The actual <see cref="SqlExpression{TType}" /> where the minimum should be found.</param>
        public Min(SqlExpression<TType> expression)
        {
            Expression = expression;
        }

        private SqlExpression<TType> Expression { get; }
    }

    /// <summary>
    ///     Gets a substring of a string.
    /// </summary>
    public sealed class Substring : SqlExpression<string>
    {
        /// <summary>
        ///     Create a new SUBSTRING-expression.
        /// </summary>
        /// <param name="expression">The string to apply this expression to.</param>
        public Substring(SqlExpression<string> expression)
        {
            Expression = expression;
        }

        private SqlExpression<string> Expression { get; }
    }

    /// <summary>
    ///     Trims a string.
    /// </summary>
    public sealed class Trim : SqlExpression<string>
    {
        /// <summary>
        ///     Create a new TRIM-expression.
        /// </summary>
        /// <param name="expression">The string to trim.</param>
        public Trim(SqlExpression<string> expression)
        {
            Expression = expression;
        }

        private SqlExpression<string> Expression { get; }
    }

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
