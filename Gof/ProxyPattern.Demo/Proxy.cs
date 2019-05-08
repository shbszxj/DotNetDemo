using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.Demo
{
    class Proxy : Subject
    {
        private Subject _subject;
        public void Request()
        {
            if(_subject == null)
            {
                _subject = new RealSubject();
            }
            _subject.Request();
        }
    }
}
