namespace FluentSQL.Querying.Functions.Extensions
{
    /// <summary>
    ///     Extends <see cref="object" /> to include the possibility for selecting all properties.
    /// </summary>
    public static class AllExtensions
    {
        /// <summary>
        ///     All the properties of an object.
        /// </summary>
        /// <param name="object">The object to select all properties from.</param>
        /// <returns>A <see cref="All" /> representing all properties.</returns>
        public static All All(this object @object)
        {
            return new All(@object);
        }
    }
}
