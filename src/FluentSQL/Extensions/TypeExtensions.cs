using System;

namespace FluentSQL.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsSubclassOfGeneric(this Type type, Type generic)
        {
            while ((type != null) && (type != typeof(object)))
            {
                Type toCheck = type.IsGenericType ? type.GetGenericTypeDefinition() : type;
                if (generic == toCheck)
                {
                    return true;
                }

                type = type.BaseType;
            }

            return false;
        }
    }
}
