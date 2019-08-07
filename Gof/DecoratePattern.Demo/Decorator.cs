using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratePattern.Demo
{
    public class Decorator : Person
    {
        private Person _persion;

        public void SetPerson(Person person)
        {
            _persion = person;
        }

        public override void Show()
        {
            if (_persion != null)
                _persion.Show();
        }
    }
}
