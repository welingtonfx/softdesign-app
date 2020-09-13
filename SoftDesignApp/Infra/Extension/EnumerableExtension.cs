using System.Collections.Generic;
using System.Linq;

namespace Infra.Extension
{
    public static class EnumerableExtension
    {
        public static bool NotNullAndAny<T>(this IEnumerable<T> source)
        {
            return source != null && source.Any();
        }
    }
}
