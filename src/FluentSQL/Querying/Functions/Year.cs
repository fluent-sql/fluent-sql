using System;

using FluentSQL.Modelling;

namespace FluentSQL.Querying.Functions
{
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
}
