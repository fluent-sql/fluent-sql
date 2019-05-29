using System;

namespace WeelinkIT.FluentSQL.Modelling
{
    public class Column<TType>
    {
        public override bool Equals(object obj)
        {
            return false;
        }

        public override int GetHashCode()
        {
            return new Random().Next();
        }

        public static implicit operator TType(Column<TType> column)
        {
            return default(TType);
        }

        public static bool operator ==(Column<TType> column, TType value)
        {
            return false;
        }

        public static bool operator !=(Column<TType> column, TType value)
        {
            return false;
        }

        public static bool operator >(Column<TType> column, TType value)
        {
            return false;
        }

        public static bool operator <(Column<TType> column, TType value)
        {
            return false;
        }

        public static bool operator >=(Column<TType> column, TType value)
        {
            return false;
        }

        public static bool operator <=(Column<TType> column, TType value)
        {
            return false;
        }

        public static bool operator ==(Column<TType> column, Column<TType> other)
        {
            return false;
        }

        public static bool operator !=(Column<TType> column, Column<TType> other)
        {
            return false;
        }

        public static bool operator >(Column<TType> column, Column<TType> other)
        {
            return false;
        }

        public static bool operator <(Column<TType> column, Column<TType> other)
        {
            return false;
        }

        public static bool operator >=(Column<TType> column, Column<TType> other)
        {
            return false;
        }

        public static bool operator <=(Column<TType> column, Column<TType> other)
        {
            return false;
        }
    }
}
