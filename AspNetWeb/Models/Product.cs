using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetWeb.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
    }
}