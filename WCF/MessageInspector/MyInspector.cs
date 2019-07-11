using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace MessageInspector
{
    public class MyInspector : IEndpointBehavior, IDispatchMessageInspector
    {
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(this);
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }

        Dictionary<Guid, KeyValuePair<string, DateTime>> callTimes = new Dictionary<Guid, KeyValuePair<string, DateTime>>();
        static object syncRoot = new object();
        Guid StartCallingMethod(string action)
        {
            lock (syncRoot)
            {
                Guid correlation = Guid.NewGuid();
                callTimes.Add(correlation, new KeyValuePair<string, DateTime>(action, DateTime.Now));
                return correlation;
            }
        }
        void EndCallingMethod(Guid correlation)
        {
            DateTime now = DateTime.Now;
            KeyValuePair<string, DateTime> beginData;
            lock (syncRoot)
            {
                beginData = callTimes[correlation];
                callTimes.Remove(correlation);
            }
            Console.WriteLine("Request to {0} took {1}", beginData.Key, now.Subtract(beginData.Value));
        }
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            return StartCallingMethod(WebOperationContext.Current.IncomingRequest.UriTemplateMatch.RequestUri.ToString());
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            EndCallingMethod((Guid)correlationState);
        }

    }
}
