using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFTest.Models
{
    [DataContract]
    public class Product
    {
        public int ProductId { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public int Price { get; set; }
    }
}