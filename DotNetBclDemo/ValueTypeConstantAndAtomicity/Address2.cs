using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueTypeConstantAndAtomicity
{
    public struct Address2
    {
        public string Line1 { get; private set; }

        public string Line2 { get; private set; }

        public string City { get; private set; }

        public string State { get; private set; }

        public int ZipCode { get; private set; }

        public Address2(string line1, string line2, string city, string state, int zipCode) : this()
        {
            Line1 = line1;
            Line2 = line2;
            City = city;
            ValidateState(state);
            State = state;
            ValidateZip(zipCode);
            ZipCode = zipCode;
        }

        private void ValidateState(string state)
        {

        }

        private void ValidateZip(int zipCode)
        {

        }
    }
}
