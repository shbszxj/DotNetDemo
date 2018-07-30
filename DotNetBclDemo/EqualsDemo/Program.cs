using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // value type reference euqals example
            new ValueTypeReferenceEqualsExample().Example();
            Console.WriteLine("==========================================");

            // IEquatable example
            var janet = new Person { Id = 1, FirstName = "Janet", LastName = "Jackson" };
            var michael = new Person{ Id = 2, FirstName = "Michael", LastName = "Jackson" };
            var tom = new Person() {Id = 1, FirstName = "Tom", LastName = "Stephen"};
            Console.WriteLine($"Janet equals Michael {janet.Equals(michael)}");
            Console.WriteLine($"Janet equals Tom {janet.Equals(tom)}");
            Console.WriteLine("==========================================");


            var t1 = Tuple.Create<int, string>(1, "Stephanie");
            var t2 = Tuple.Create<int, string>(1, "Stephanie");
            if (t1 != t2)
                Console.WriteLine("not the same reference to the tuple.");
            if (t1.Equals(t2))
                Console.WriteLine("the same content.");

            Console.Read();
        }
    }
}
