using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WeelinkIT.FluentSQL.Querying.Extensions
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<NoParameters, T>> AddNoParameters<T>(this Expression<Func<T>> expression)
        {
            ParameterExpression noParameterExpression = Expression.Parameter(typeof(NoParameters));
            var newParameters = new List<ParameterExpression>(expression.Parameters)
            {
                noParameterExpression
            };

            Expression<Func<NoParameters, T>> newExpression =
                Expression.Lambda<Func<NoParameters, T>>(expression.Body, newParameters);
            return newExpression;
        }
    }
}
