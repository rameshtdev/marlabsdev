using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            var query = new LINQQuery();
            //query.LINQtoObject();
            query.LINQtoSQL();
            //query.LINQtoXML();
            //query.LINQtoDataSet();
        }
    }
}
