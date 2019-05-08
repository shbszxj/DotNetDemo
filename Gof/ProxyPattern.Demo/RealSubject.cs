using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.Demo
{
    class RealSubject : Subject
    {
        public void Request()
        {
            Console.WriteLine("This is real subject.");
        }
    }
}
