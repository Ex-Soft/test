// http://www.richonsoftware.com/post/2012/04/05/using-stubs-and-shim-to-test-with-microsoft-fakes-in-visual-studio-11.aspx
// https://msdn.microsoft.com/en-us/library/hh549175(v=vs.110).aspx

using ClassLibrary2;
using ClassLibrary2.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class Library2Test
    {
        [TestMethod]
        public void SmthClassTest()
        {
            var stubWorker = new StubISmthInterface
            {
                MulInt32Int32 = (left, right) => left + right,
                DivInt32Int32 = (left, right) => left - right
            };

            var realWorker = new SmthClassWithInterface();
            var smthClass = new SmthClass();

            Assert.AreEqual(smthClass.Mul(stubWorker, 2, 3), 5);
            Assert.AreEqual(smthClass.Mul(realWorker, 2, 3), 6);
            Assert.AreEqual(smthClass.Div(stubWorker, 16, 2), 14);
            Assert.AreEqual(smthClass.Div(realWorker, 16, 2), 8);
        }

        [TestMethod]
        public void ISmthInterfaceTest()
        {
            var stub = new StubISmthInterface
            {
                MulInt32Int32 = (left, right) => left + right,
                DivInt32Int32 = (left, right) => left - right
            };

            Assert.AreEqual(stub.MulInt32Int32(2, 3), 5);
            Assert.AreEqual(stub.DivInt32Int32(16, 2), 14);
        }
    }
}
