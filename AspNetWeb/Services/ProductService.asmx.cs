using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using AspNetWeb.Models;

namespace AspNetWeb.Services
{
    /// <summary>
    /// Summary description for ProductService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ProductService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public Product GetProduct(int ProductId)
        {
            if(ProductId==1)
            {
                return (new Product() { ProductId = 1, ProductName = "IPhone", Category = "Electronics", Price = 350 });
            }
            else
            {
                return (new Product() { ProductId = 1, ProductName = "Hammer", Category = "Hardware", Price = 20 });
            }

        }
    }
}
