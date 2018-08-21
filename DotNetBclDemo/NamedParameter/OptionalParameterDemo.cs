using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NamedParameter
{
    public class OptionalParameterDemo
    {
        public static void SetName(string lastName, string firstName, bool isMale = false)
        {
            Console.WriteLine($"LastName : {lastName}, FirstName : {firstName}, IsMale : {isMale}");
        }
    }
}
