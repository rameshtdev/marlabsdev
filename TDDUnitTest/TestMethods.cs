using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CalculatorMethods;
using NSubstitute;
using NUnit.Mocks;

namespace TDDUnitTest
{
    [TestFixture]
    public class TestMethods
    {
        int a = 0; int b = 0;
        ICalcDataAccess DBObj;
        [SetUp]
        public void intitalize()
        {
            a = 5;
            b = 4;
            DBObj = new DataAccess();
        }

        //[Ignore("Function depreciated")]
        [Test]
        public void TestTheInstance()
        {
            var businessObj = new CalcOperationBusiness(DBObj);
            Assert.IsInstanceOf(typeof(CalcOperationBusiness), businessObj);
        }

        [Test]
        [TestCase(2,4,6)]
        [TestCase(3, 3, 6)]
        [TestCase(0, 1, 1)]
        [TestCase(5, 2, 7)]
        public void TestAddOperation(int x, int y, int expectedTotal)
        {
            var businessObj = new CalcOperationBusiness(DBObj);
            var returnValue = businessObj.AddNumbers(x, y);
            Assert.AreEqual(expectedTotal, returnValue);
        }

        [Test]
        public void MockExample()
        {
            var DBMock = Substitute.For<ICalcDataAccess>();
            DBMock.DBConnectAndAdd(1, 3).Returns(4);
            DBMock.DBConnectAndAdd(5, 1).Returns(6);
            DBMock.DBConnectAndAdd(3, 5).Returns(8);

            var businessObj = new CalcOperationBusiness(DBMock);
            var returnValue = businessObj.AddNumbers(5, 1);
            Assert.AreEqual(6, returnValue);
        }

        [Test]
        [TestCase(-1, 3, 6)]
        public void TestException(int x, int y, int expectedTotal)
        {
            var businessObj = new CalcOperationBusiness(DBObj);            
            Assert.Throws(typeof(IndexOutOfRangeException),()=> { businessObj.AddNumbers(x, y); });
        }

        [TearDown]
        public void dispose()
        {
            a = 0;
            b = 0;
        }
    }
}
