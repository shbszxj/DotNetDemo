using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueTypeConstantAndAtomicity
{
    public struct Address
    {
        private string state;
        private int zipCode;

        public string Line1 { get; set; }

        public string Line2 { get; set; }

        public string City { get; set; }

        public string State
        {
            get { return state; }
            set
            {
                ValidateState(value);
                state = value;
            }
        }

        public int ZipCode
        {
            get { return zipCode; }
            set
            {
                ValidateZip(value);
                zipCode = value;
            }
        }

        private void ValidateState(string state)
        {
            
        }

        private void ValidateZip(int zipCode)
        {
            
        }
    }
}
