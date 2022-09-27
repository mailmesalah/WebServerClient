using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WpfServer
{
  
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        CData DoWork();
        [OperationContract(IsOneWay = true)]
        void Call();
    }
}
