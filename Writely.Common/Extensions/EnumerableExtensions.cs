using System.Diagnostics;

namespace Writely.Common.Extensions
{
    public static class EnumerableExtensions
    {
        [DebuggerStepThrough]
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var local in enumerable)
                action(local);
        }
    }
}
