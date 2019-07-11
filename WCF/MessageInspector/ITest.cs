using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace MessageInspector
{
    [ServiceContract]
    public interface ITest
    {
        [OperationContract]
        string Echo(string text);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        string LongEcho(string text, int delay);

        [OperationContract]
        [WebGet]
        int Add(int x, int y);
    }
}
