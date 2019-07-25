namespace FluentSQL.Modelling
{
    /// <summary>
    ///     Represents a column.
    /// </summary>
    /// <typeparam name="TExpressionType">The column type.</typeparam>
    public sealed class Column<TExpressionType> : SqlExpression<TExpressionType>
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
