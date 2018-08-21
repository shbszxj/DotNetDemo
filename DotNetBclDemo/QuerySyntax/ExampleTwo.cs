using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuerySyntax
{
    public class ExampleTwo
    {
        public static IEnumerable<Tuple<int, int>> ProduceIndices()
        {
            for (int x = 0; x < 100; x++)
            {
                for (int y = 0; y < 100; y++)
                {
                    if (x + y < 100)
                        yield return Tuple.Create(x, y);
                }
            }
        }

        public static IEnumerable<Tuple<int, int>> QueryIndices()
        {
            return from x in Enumerable.Range(0, 100)
                from y in Enumerable.Range(0, 100)
                where x + y < 100
                select Tuple.Create(x, y);
        }
    }
}
