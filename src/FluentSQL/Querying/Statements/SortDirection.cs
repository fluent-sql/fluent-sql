namespace FluentSQL.Querying.Statements
{
    /// <summary>
    ///     The direction to sort the results.
    /// </summary>
    public class SortDirection
    {
        /// <summary>
        ///     Sort the results in ascending order.
        /// </summary>
        public static readonly SortDirection Ascending = new SortDirection();

        /// <summary>
        ///     Sort the results in descending order.
        /// </summary>
        public static readonly SortDirection Descending = new SortDirection();

        private SortDirection()
        {
        }
    }
}