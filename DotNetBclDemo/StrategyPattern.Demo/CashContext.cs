using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Demo
{
    public class CashContext
    {
        private CashSuper _strategy;

        public CashContext(CashStrategy strategy)
        {
            switch (strategy)
            {
                case CashStrategy.Normal:
                    _strategy = new CashNormal();
                    break;
                case CashStrategy.Return:
                    _strategy = new CashReturn();
                    break;
                case CashStrategy.Rebate:
                    _strategy = new CashRebate();
                    break;
            }
        }

        public double GetResult()
        {
            return _strategy.AcceptCash();
        }
    }

    public enum CashStrategy
    {
        Normal,
        Return,
        Rebate
    }
}
