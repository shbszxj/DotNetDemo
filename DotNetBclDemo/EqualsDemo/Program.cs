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

            Console.Read();
        }
    }
}
