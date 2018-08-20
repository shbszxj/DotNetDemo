using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuerySyntax
{
    public static class Extensions
    {
        public static void ForAll<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            foreach (T item in sequence)
            {
                action(item);
            }
        }
    }
}
