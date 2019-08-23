using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cocon.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = "6".CastEnumerationValue(MultiCosMeetingState.Error);
            Console.WriteLine(x);

            Console.WriteLine(GetNumberOfPdfPages.Get("E:\\TELEVIC\\ConvertPdfToImage\\Original file\\Televic Asia Meetup Session 1.pdf"));

            Console.Read();
        }
    }
}
