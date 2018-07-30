using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualsDemo
{
    public class Person : IEquatable<Person>
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{Id} {FirstName} {LastName}";
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public bool Equals(Person other)
        {
            if (other == null)
                return base.Equals(other);

            return Id == other.Id;
        }
    }
}
