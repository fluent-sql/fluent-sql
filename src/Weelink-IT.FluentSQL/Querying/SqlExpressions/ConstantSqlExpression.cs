using WeelinkIT.FluentSQL.Modelling;

namespace WeelinkIT.FluentSQL.Querying.SqlExpressions
{
    public class ConstantSqlExpression<TType> : SqlExpression<TType>
    {
        public ConstantSqlExpression(TType value)
        {
            Value = value;
        }

        private TType Value { get; }
    }
}
