using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuerySyntax
{
    public class ExampleThree
    {
        public static IEnumerable<Tuple<int, int>> ProduceIndices()
        {
            var storage = new List<Tuple<int, int>>();

            for (int x = 0; x < 100; x++)
            {
                for (int y = 0; y < 100; y++)
                {
                    if (x + y < 100)
                    {
                        storage.Add(Tuple.Create(x, y));
                    }
                }
            }

            storage.Sort((point1, point2) =>
                (point2.Item1 * point2.Item1 + point2.Item2 * point2.Item2)
                    .CompareTo(point1.Item1 * point1.Item1 + point1.Item2 * point1.Item2));

            return storage;
        }

        public static IEnumerable<Tuple<int, int>> QueryIndices()
        {
            return from x in Enumerable.Range(0, 100)
                   from y in Enumerable.Range(0, 100)
                   where x + y < 100
                   orderby (x * x + y * y) descending
                   select Tuple.Create(x, y);
        }
    }
}
