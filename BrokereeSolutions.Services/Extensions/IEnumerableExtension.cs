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
    }
}
