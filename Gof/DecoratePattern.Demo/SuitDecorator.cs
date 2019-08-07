using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratePattern.Demo
{
    public class SuitDecorator : Decorator
    {
        public override void Show()
        {
            Console.WriteLine("西装");
            base.Show();
        }
    }
}
