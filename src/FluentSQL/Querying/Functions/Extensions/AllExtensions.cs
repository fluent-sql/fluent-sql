using FluentSQL.Modelling;

namespace FluentSQL.Querying.Functions.Extensions
{
    /// <summary>
    ///     Extends <see cref="Table" />.
    /// </summary>
    public static class AllExtensions
    {
        /// <summary>
        ///     All the columns in a table.
        /// </summary>
        /// <param name="table">The table to select all columns from.</param>
        /// <returns>A <see cref="All" /> representing all columns.</returns>
        public static All All(this Table table)
        {
            return new All(table);
        }
    }
}
