using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new CashContext(CashStrategy.Return).GetResult());
            Console.Read();
        }
    }
}
