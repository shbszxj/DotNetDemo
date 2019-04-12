using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Demo
{
    public class CashReturn : CashSuper
    {
        public override double AcceptCash()
        {
            return 0;
        }
    }
}
