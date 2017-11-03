// http://www.richonsoftware.com/post/2012/04/05/using-stubs-and-shim-to-test-with-microsoft-fakes-in-visual-studio-11.aspx
// https://msdn.microsoft.com/en-us/library/hh549175(v=vs.110).aspx

using System.Collections.Generic;
using ClassLibrary2;
using ClassLibrary2.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
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

        [TestMethod]
        public void SingletonTest()
        {
            Singleton.Instance.SmthExecutor = new SmthClassWithInterface();

            var listOfA = Singleton.Instance.SmthExecutor.GetList<ClassA>();
            Assert.AreEqual(listOfA.Count, 1);

            var listOfB = Singleton.Instance.SmthExecutor.GetList<ClassB>();
            Assert.AreEqual(listOfB.Count, 1);

            Assert.AreEqual(Singleton.Instance.SmthExecutor.Mul(2, 3), 6);
            Assert.AreEqual(Singleton.Instance.SmthExecutor.Div(16, 2), 8);

            using (ShimsContext.Create())
            {
                var stub = new StubISmthInterface
                {
                    MulInt32Int32 = (left, right) => left + right,
                    DivInt32Int32 = (left, right) => left - right
                };
                stub.GetListOf1(() => new List<ClassA> {new ClassA("ClassA[0] (from StubISmthInterface)"), new ClassA("ClassA[1] (from StubISmthInterface)")});
                stub.GetListOf1(() => new List<ClassB> {new ClassB("ClassB[0] (from StubISmthInterface)"), new ClassB("ClassB[1] (from StubISmthInterface)")});

                ShimSingleton.AllInstances.SmthExecutorGet = f => stub;

                listOfA = Singleton.Instance.SmthExecutor.GetList<ClassA>();
                Assert.AreEqual(listOfA.Count, 2);

                listOfB = Singleton.Instance.SmthExecutor.GetList<ClassB>();
                Assert.AreEqual(listOfB.Count, 2);

                Assert.AreEqual(Singleton.Instance.SmthExecutor.Mul(2, 3), 5);
                Assert.AreEqual(Singleton.Instance.SmthExecutor.Div(16, 2), 14);
            }
        }

        [TestMethod]
        public void DerivedClassTest()
        {
            using (ShimsContext.Create())
            {
                const string
                    basePropertyGetValue = "BasePropertyGet",
                    derivedPropertyGetValue = "DerivedPropertyGet";

                var derivedClass = new ShimDerivedClass
                {
                    DerivedPropertyGet = () => derivedPropertyGetValue
                };

                var baseClass = new ShimBaseClass(derivedClass)
                {
                    BasePropertyGet = () => basePropertyGetValue
                };

                var actual = derivedClass.Instance.BaseProperty;
                Assert.AreEqual(basePropertyGetValue, actual);

                actual = derivedClass.Instance.DerivedProperty;
                Assert.AreEqual(derivedPropertyGetValue, actual);
            }
        }
    }
}
