using System;
using System.Collections.Generic;

namespace YieldDemo
{
    class Program
    {
        static void Main()
        {
            // Display powers of 2 up to the exponent of 8:
            Console.WriteLine("======Powers of 2======");
            foreach (int i in Power(2, 8))
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();
            Console.WriteLine("======Galaxies======");
            ShowGalaxies();
            Console.Read();
        }

        // Output: 2 4 8 16 32 64 128 256
        public static IEnumerable<int> Power(int number, int exponent)
        {
            int result = 1;

            for (int i = 0; i < exponent; i++)
            {
                result = result * number;
                yield return result;
            }
        }

        private static void ShowGalaxies()
        {
            var theGalaxies = new Galaxies();
            foreach (Galaxy theGalaxy in theGalaxies.NextGalaxy)
            {
                Console.WriteLine(theGalaxy.Name + " " + theGalaxy.MegaLightYears.ToString());
            }
        }
    }
}
