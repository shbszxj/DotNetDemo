using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuerySyntax
{
    public class ExampleOne
    {
        public static void Output()
        {
            int[] foo = new int[100];
            for (int num = 0; num < foo.Length; num++)
            {
                foo[num] = num * num;
            }

            foreach (var i in foo)
            {
                Console.WriteLine(i.ToString());
            }
        }

        public static void QueryOutput()
        {
            int[] foo = (from n in Enumerable.Range(0, 100)
                         select n * n).ToArray();

            foo.ForAll((n) => Console.WriteLine(n.ToString()));
        }
    }
}
