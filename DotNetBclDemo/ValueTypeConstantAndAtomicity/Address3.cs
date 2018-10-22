using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueTypeConstantAndAtomicity
{
    public struct Address3
    {
        private readonly string line1;

        public string Line1
        {
            get { return line1; }
        }

        private readonly string line2;

        public string Line2
        {
            get { return line2; }
        }

        private readonly string state;

        public string State
        {
            get { return state; }
        }

        private readonly string city;

        public string City
        {
            get { return city; }
        }

        private readonly int zipCode;

        public int ZipCode
        {
            get { return zipCode; }
        }

        public Address3(string line1, string line2, string city, string state, int zipCode) : this()
        {
            this.line1 = line1;
            this.line2 = line2;
            this.city = city;
            ValidateState(state);
            this.state = state;
            ValidateZip(zipCode);
            this.zipCode = zipCode;
        }

        private void ValidateState(string state)
        {

        }

        private void ValidateZip(int zipCode)
        {

        }
    }
}
