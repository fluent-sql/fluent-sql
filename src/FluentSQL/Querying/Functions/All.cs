using System.Collections.Generic;

using FluentSQL.Modelling;

namespace FluentSQL.Querying.Functions
{
    /// <summary>
    ///     Represents all columns in a table.
    /// </summary>
    public sealed class All : SqlExpression<IEnumerable<object>>
    {
        /// <summary>
        ///     Create a new <c>*</c> expression.
        /// </summary>
        /// <param name="table">The table to get all columns from.</param>
        public All(Table table)
        {
            Table = table;
        }

        private Table Table { get; }
    }
}
