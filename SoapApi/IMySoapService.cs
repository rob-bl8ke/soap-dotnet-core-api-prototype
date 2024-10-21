using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;

namespace SoapApi
{
    [ServiceContract(Namespace = "IMySoapService")]
    public interface IMySoapService
    {
        [OperationContract]
        string HelloWorld(string name);
    }

}