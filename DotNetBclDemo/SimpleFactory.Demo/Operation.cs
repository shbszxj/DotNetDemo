using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory.Demo
{
    public class Operation
    {
        public double NumberA { get; set; }

        public double NumberB { get; set; }

        public virtual double GetResult()
        {
            return 0;
        }
    }
}
