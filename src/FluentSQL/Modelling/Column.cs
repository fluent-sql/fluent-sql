namespace FluentSQL.Modelling
{
    /// <summary>
    ///     Represents a column.
    /// </summary>
    /// <typeparam name="TType">The column type.</typeparam>
    public class Column<TType> : SqlExpression<TType>
    {
        /// <summary>
        ///     Create a new column.
        /// </summary>
        /// <param name="name">The name of the column.</param>
        public Column(string name)
        {
            Name = name;
        }

        private string Name { get; }
    }
}
