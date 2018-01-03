using System;
using System.Diagnostics;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary2;
using ClassLibrary2.Fakes;

namespace UnitTestProject
{
    [TestClass]
    public class TestTestContext
    {
        private IDisposable _context;

        [TestInitialize]
        public void MyTestInitialize()
        {
            Debug.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.fffffff")} {System.Reflection.MethodBase.GetCurrentMethod().Name}");

            _context = ShimsContext.Create();
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            Debug.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.fffffff")} {System.Reflection.MethodBase.GetCurrentMethod().Name}");

            _context.Dispose();
        }

        [TestMethod]
        public void Test1()
        {
            var stub = new StubISmthInterface
            {
                MulInt32Int32 = (left, right) => left + right,
                DivInt32Int32 = (left, right) => left - right
            };

            ShimSingleton.AllInstances.SmthExecutorGet = f => stub;

            Assert.AreEqual(Singleton.Instance.SmthExecutor.Mul(2, 3), 5);
            Assert.AreEqual(Singleton.Instance.SmthExecutor.Div(16, 2), 14);
        }

        [TestMethod]
        public void Test2()
        {
            var stub = new StubISmthInterface
            {
                MulInt32Int32 = (left, right) => left * right,
                DivInt32Int32 = (left, right) => left / right
            };

            ShimSingleton.AllInstances.SmthExecutorGet = f => stub;

            Assert.AreEqual(Singleton.Instance.SmthExecutor.Mul(2, 3), 6);
            Assert.AreEqual(Singleton.Instance.SmthExecutor.Div(16, 2), 8);
        }
    }
}

//System.Diagnostics.Debugger.Launch();
//System.Diagnostics.Debugger.Break();
