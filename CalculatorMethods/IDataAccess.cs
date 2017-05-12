using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorMethods
{
    public interface ICalcDataAccess
    {
        int DBConnectAndAdd(int x, int y);
    }
}
