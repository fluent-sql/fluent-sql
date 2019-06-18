namespace WeelinkIT.FluentSQL.Querying.SqlExpressions.Extensions
{
    public static class ConstantSqlExpressionExtensions
    {
        public static ConstantSqlExpression<TType> Constant<TType>(this TType value)
        {
            return new ConstantSqlExpression<TType>(value);
        }
    }
}
