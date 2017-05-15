using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFTest.Models;

namespace WCFTest
{
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        Product GetProduct(Input i);
        [OperationContract]
        List<Person> GetPlayers();
    }
}
