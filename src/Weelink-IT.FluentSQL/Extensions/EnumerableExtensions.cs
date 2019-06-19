using System.Collections.Generic;

namespace WeelinkIT.FluentSQL.Extensions
{
    /// <summary>
    ///     Extends <see cref="IEnumerable{T}" />.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        ///     Copies all elements from <paramref name="source" /> to <paramref name="destination" />.
        /// </summary>
        /// <param name="source">The <see cref="IEnumerable{T}" /> containing elements to copy.</param>
        /// <param name="destination">The destination where the elements should be copied to.</param>
        public static void CopyTo<T>(this IList<T> source, IList<T> destination)
        {
            foreach (T item in source)
            {
                destination.Add(item);
            }
        }
    }
}
