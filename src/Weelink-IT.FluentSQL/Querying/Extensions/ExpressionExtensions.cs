using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WeelinkIT.FluentSQL.Querying.Extensions
{
    /// <summary>
    ///     Extends <see cref="Expression" />.
    /// </summary>
    public static class ExpressionExtensions
    {
        /// <summary>
        ///     Convert <paramref name="expression" /> to an <see cref="Expression" /> that contains <see cref="NoParameters" /> as the parameter type.
        /// </summary>
        /// <param name="expression">The expression to convert.</param>
        /// <typeparam name="T">Some extra type.</typeparam>
        /// <returns>
        ///     A new <see cref="Expression{T}">Expression&lt;Func&lt;T, bool&gt;&gt;</see> where the parameter type is <see cref="NoParameters" />.
        /// </returns>
        public static Expression<Func<T, NoParameters, bool>> AddNoParameters<T>(this Expression<Func<T, bool>> expression)
        {
            ParameterExpression noParameterExpression = Expression.Parameter(typeof(NoParameters));
            var newParameters = new List<ParameterExpression>(expression.Parameters)
            {
                noParameterExpression
            };

            Expression<Func<T, NoParameters, bool>> newExpression = Expression.Lambda<Func<T, NoParameters, bool>>(expression.Body, newParameters);
            return newExpression;
        }
    }
}
