using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetWeb.Models
{
    public class Assessment
    {
        public int id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public int Gender { get; set; }
        public string email { get; set; }
        public string country { get; set; }
        public int age { get; set; }
        public string expertise { get; set; }
        public string qualification { get; set; }
    }
}