using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamedParameter
{
    class Program
    {
        static void Main(string[] args)
        {
            NamedParameterDemo.SetName(firstName: "Jack", lastName: "Zhou");
            OptionalParameterDemo.SetName("Zhou", "Jack", true);
            Console.Read();
        }
    }
}
