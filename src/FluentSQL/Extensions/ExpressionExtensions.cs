using System;
using System.Linq.Expressions;

using FluentSQL.Modelling;

namespace FluentSQL.Extensions
{
    public static class ExpressionExtensions
    {
        public static bool IsSqlExpression<TSqlExpression>(this Expression<Func<TSqlExpression>> expression)
        {
            return typeof(TSqlExpression).IsSubclassOfGeneric(typeof(SqlExpression<>));
        }
    }
}
