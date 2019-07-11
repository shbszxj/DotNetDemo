using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace MessageInspector
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddress));
            ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(ITest), new WebHttpBinding(), "");
            endpoint.Behaviors.Add(new WebHttpBehavior());
            endpoint.Behaviors.Add(new MyInspector());
            host.Open();
            Console.WriteLine("Host opened");

            ChannelFactory<ITest> factory = new ChannelFactory<ITest>(new WebHttpBinding(), new EndpointAddress(baseAddress));
            factory.Endpoint.Behaviors.Add(new WebHttpBehavior());
            ITest proxy = factory.CreateChannel();
            Console.WriteLine(proxy.Echo("Hello"));
            Console.WriteLine(proxy.LongEcho("World", 1234));
            Console.WriteLine(proxy.Add(3, 4));

            ((IClientChannel)proxy).Close();
            factory.Close();

            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
}
