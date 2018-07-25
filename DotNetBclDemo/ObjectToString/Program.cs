using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectToString
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer()
            {
                Name = "Jack",
                Phone = "12345678910",
                Revenue = 1000
            };
            Console.WriteLine($"Customer record : {customer.ToString("nrp", null)}");
            Console.WriteLine($"Customer record : {string.Format(new MyFormatter(), "{0}", customer)}");
            Console.Read();
        }
    }
}
