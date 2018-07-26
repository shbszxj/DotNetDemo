using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualsDemo
{
    public class ValueTypeReferenceEqualsExample
    {
        public void Example()
        {
            int i = 5;
            int j = 5;
            Console.WriteLine($"i = 5, j = 5, ReferenceEquals = {ReferenceEquals(i, j)}");
            Console.WriteLine($"i = 5, i = 5, ReferenceEquals = {ReferenceEquals(i, i)}");
        }
    }
}
