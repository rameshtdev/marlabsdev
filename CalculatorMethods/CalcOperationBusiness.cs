using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorMethods
{
    public class CalcOperationBusiness
    {
        readonly ICalcDataAccess dataAccessObj;

        public CalcOperationBusiness(ICalcDataAccess obj)
        {
            dataAccessObj = obj;
        }
        public int AddNumbers(int x, int y)
        {
            int returnValue = 0;
            try
            {
                if (x < 0 || y < 0)
                    throw new IndexOutOfRangeException();
                returnValue = dataAccessObj.DBConnectAndAdd(x, y);
            }
            catch(IndexOutOfRangeException ex)
            {
                throw;
            }
            catch(Exception ex)
            {
                throw;
            }
            
            return returnValue;
        }
    }
}
