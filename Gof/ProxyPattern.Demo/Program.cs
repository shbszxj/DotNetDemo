using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            new Proxy().Request();
            Console.Read();
        }
    }
}
