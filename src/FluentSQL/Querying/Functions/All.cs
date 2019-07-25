using System.Collections.Generic;

using FluentSQL.Modelling;

namespace FluentSQL.Querying.Functions
{
    /// <summary>
    ///     Represents all columns in a @object.
    /// </summary>
    public sealed class All : SqlExpression<IEnumerable<object>>
    {
        /// <summary>
        ///     Create a new <c>*</c> expression.
        /// </summary>
        /// <param name="object">The object to get all properties from.</param>
        public All(object @object)
        {
            Object = @object;
        }

        private object Object { get; }
    }
}
