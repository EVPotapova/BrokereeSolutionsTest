using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrokereeSolutions.Services.Extensions
{
    public static class IEnumerableExtension
    {
        public static IEnumerable<IEnumerable<T>> Split<T>(
this IEnumerable<T> source,
int count)
        {
            var sourceCount = source.Count();
            return source
              .Select((x, y) => new { Index = y, Value = x })
              .GroupBy(x => (x.Index * count) / sourceCount)
              .Select(x => x.Select(y => y.Value).ToList())
              .ToList();
        }

        public static IEnumerable<TSource> FromHierarchy<TSource>(
    this TSource source,
    Func<TSource, TSource> nextItem,
    Func<TSource, bool> canContinue)
        {
            for (var current = source; canContinue(current); current = nextItem(current))
            {
                yield return current;
            }
        }

        public static IEnumerable<TSource> FromHierarchy<TSource>(
            this TSource source,
            Func<TSource, TSource> nextItem)
            where TSource : class
        {
            return FromHierarchy(source, nextItem, s => s != null);
        }
    }
}
