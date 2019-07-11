using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MessageInspector
{
    public class Service : ITest
    {
        public string Echo(string text)
        {
            return text;
        }

        public string LongEcho(string text, int delay)
        {
            Thread.Sleep(delay);
            return text;
        }

        public int Add(int x, int y)
        {
            Thread.Sleep(500);
            return x + y;
        }
    }
}
