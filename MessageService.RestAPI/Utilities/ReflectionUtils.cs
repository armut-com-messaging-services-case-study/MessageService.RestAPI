using System;

namespace MessageService.RestAPI.Utilities
{
    public class ReflectionUtils
    {
        public static bool IsNullable(Type t)
        {
            if (t == null)
            {
                throw new ArgumentNullException("t");
            }

            return (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }
    }
}
