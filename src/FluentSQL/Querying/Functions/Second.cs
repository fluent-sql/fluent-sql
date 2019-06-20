using System;

using FluentSQL.Modelling;

namespace FluentSQL.Querying.Functions
{
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
}
