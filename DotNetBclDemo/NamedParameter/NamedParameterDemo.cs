using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamedParameter
{
    public class NamedParameterDemo
    {
        public static void SetName(string lastName, string firstName)
        {
            Console.WriteLine($"LastName : {lastName}, FirstName : {firstName}");
        }
    }
}
