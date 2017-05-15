using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFTest.Models;

namespace WCFTest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductService1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductService1.svc or ProductService1.svc.cs at the Solution Explorer and start debugging.
    public class ProductService1 : IProductService
    {
        public Product GetProduct(Input i)
        {
            var ProductId = i.ProductId;

            if (ProductId == 1)
            {
                return (new Product() { ProductId = 1, ProductName = "IPhone", Category = "Electronics", Price = 350 });
            }
            else
            {
                return (new Product() { ProductId = 1, ProductName = "Hammer", Category = "Hardware", Price = 20 });
            }

        }

        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json,ResponseFormat = WebMessageFormat.Json,UriTemplate = "players")]
        public List<Person> GetPlayers()
        {
            List<Person> players = new List<Person>();
            players.Add(new Person { FirstName = "Peyton", LastName = "Manning", Age = 35 });
            players.Add(new Person { FirstName = "Drew", LastName = "Brees", Age = 31 });
            players.Add(new Person { FirstName = "Brett", LastName = "Favre", Age = 58 });

            return players;
        }
    }
}
