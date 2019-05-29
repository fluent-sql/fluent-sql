using System;

using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.Functions
{
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
}
