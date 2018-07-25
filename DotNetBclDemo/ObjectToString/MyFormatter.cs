using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectToString
{
    public class MyFormatter : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg == null)
                return string.Empty;

            var customer = arg as Customer;
            if (customer == null)
            {
                return arg.ToString();
            }

            return string.Format("{0,50}, {1,15}, {2,10:C}", customer.Name, customer.Phone, customer.Revenue);

        }


    }
}
