using System.Collections;

namespace GataryLabs.SwfBox.Domain.Extensions
{
    internal static class EnumerableExtensions
    {
        internal static int Count(this IEnumerable enumerable)
        {
            int count = 0;

            foreach (object _ in enumerable)
                count++;

            return count;
        }
    }
}
