using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorMethods
{
    public class DataAccess: ICalcDataAccess
    {
        public int DBConnectAndAdd(int x, int y)
        {
            //Does some DB activities
            return (x + y);
        }
    }
}
