using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualsDemo
{
    public class ValueReferenceEqualsExample
    {
        public void Example()
        {
            int i = 5;
            int j = 5;

            if (ReferenceEquals(i, j))
                Console.WriteLine("Never happens.");
            else
                Console.WriteLine("Always happens.");

            if (ReferenceEquals(i, i))
                Console.WriteLine("Never happens.");
            else
                Console.WriteLine("Always happens.");
        }
    }
}
