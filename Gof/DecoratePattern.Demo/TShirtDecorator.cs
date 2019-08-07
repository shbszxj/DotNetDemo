using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratePattern.Demo
{
    public class TShirtDecorator : Decorator
    {
        public override void Show()
        {
            Console.WriteLine("T shirt");
            base.Show();
        }
    }
}
