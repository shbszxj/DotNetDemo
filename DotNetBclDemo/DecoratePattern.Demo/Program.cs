using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratePattern.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person();
            var tshirtDecorator = new TShirtDecorator();
            var suitDecorator = new SuitDecorator();
            suitDecorator.SetPerson(person);
            tshirtDecorator.SetPerson(suitDecorator);
            tshirtDecorator.Show();
            Console.Read();
        }
    }
}
