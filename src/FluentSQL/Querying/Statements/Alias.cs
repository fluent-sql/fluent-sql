namespace FluentSQL.Querying.Statements
{
    /// <summary>
    ///     An alias.
    /// </summary>
    public sealed class Alias
    {
        /// <summary>
        ///     Create a new alias.
        /// </summary>
        /// <param name="name">The alias.</param>
        internal Alias(string name)
        {
            Name = name;
        }

        /// <summary>
        ///     The alias.
        /// </summary>
        public string Name { get; }
    }
}
