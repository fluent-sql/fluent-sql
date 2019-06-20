using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FluentSQL.Querying.Extensions
{
    /// <summary>
    ///     Extends <see cref="Expression{TDelegate}" />.
    /// </summary>
    public static class ExpressionExtensions
    {
        /// <summary>
        ///     Modify <paramref name="expression" /> so that the first parameter is <see cref="NoParameters" />.
        /// </summary>
        /// <typeparam name="T">The other type.</typeparam>
        /// <param name="expression">
        ///     The <see cref="Expression{TDelegate}">Expression&lt;Func&lt;T&gt;&gt;</see> to modify.
        /// </param>
        /// <returns>A new <see cref="Expression{TDelegate}">Expression&lt;Func&lt;NoParameters, T&gt;&gt;</see>.</returns>
        public static Expression<Func<NoParameters, T>> AddNoParameters<T>(this Expression<Func<T>> expression)
        {
            ParameterExpression noParameterExpression = Expression.Parameter(typeof(NoParameters));
            var newParameters = new List<ParameterExpression>(expression.Parameters)
            {
                noParameterExpression
            };

            Expression<Func<NoParameters, T>> newExpression = Expression.Lambda<Func<NoParameters, T>>(expression.Body, newParameters);
            return newExpression;
        }
    }
}
