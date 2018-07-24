using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectToString
{
    public class Customer : IFormattable
    {
        public string Name { get; set; }

        public decimal Revenue { get; set; }

        public string Phone { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (formatProvider != null)
            {
                ICustomFormatter formatter = formatProvider.GetFormat(this.GetType()) as ICustomFormatter;
                if (formatter != null)
                {
                    return formatter.Format(format, this, formatProvider);
                }
            }

            switch (format)
            {
                case "r":
                    return Revenue.ToString();
                case "p":
                    return Phone;
                case "nr":
                    return string.Format("{0,20}, {1,10:C}", Name, Revenue);
                case "np":
                    return string.Format("{0,20}, {1,15}", Name, Phone);
                case "pr":
                    return string.Format("{0,15}, {1,10:C}", Phone, Revenue);
                case "pn":
                    return string.Format("{0,15}, {1,20}", Phone, Name);
                case "rn":
                    return string.Format("{0,10:C}, {1,20}", Revenue, Name);
                case "rp":
                    return string.Format("{0,10:C}, {1,20}", Revenue, Phone);
                case "nrp":
                    return string.Format("{0,20}, {1,10:C}, {2,15}", Name, Revenue, Phone);
                case "npr":
                    return string.Format("{0,20}, {1,15}, {2, 10:C}", Name, Phone, Revenue);
                case "pnr":
                    return string.Format("{0,15}, {1,20}, {2, 10:C}", Phone, Name, Revenue);
                case "n":
                case "G":
                default:
                    return Name;
            }
        }
    }
}
