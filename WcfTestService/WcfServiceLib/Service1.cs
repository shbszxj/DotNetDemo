using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace WcfServiceLib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class Service1 : IHelloWorld
    {
        private int messageCount;
        private Dictionary<int, string> dic = new Dictionary<int, string>();

        public void HelloWorld()
        {
            dic.Add(messageCount, "Hello,World");

            Console.WriteLine("序列号{0},线程号{1}", messageCount, Thread.CurrentThread.ManagedThreadId);
            messageCount++;

            Thread.Sleep(50);
        }
    }
}
