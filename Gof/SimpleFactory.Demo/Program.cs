using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var operation = OperationFactory.CreateOperation("+");
            operation.NumberA = 10;
            operation.NumberB = 2;
            Console.WriteLine(operation.GetResult());
            Console.Read();
        }
    }
}
