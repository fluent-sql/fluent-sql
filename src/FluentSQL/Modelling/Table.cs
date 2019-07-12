namespace FluentSQL.Modelling
{
    /// <summary>
    ///     Represents a table.
    /// </summary>
    public abstract class Table : SqlExpression<Table>
    {
        /// <summary>
        ///     Create a new table.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="name">The name of the table.</param>
        protected Table(string schema, string name)
        {
            Schema = schema;
            Name = name;
        }

        internal string Schema { get; }
        internal string Name { get; }
    }
}
