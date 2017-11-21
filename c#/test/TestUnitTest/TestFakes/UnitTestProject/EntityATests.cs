using ClassLibrary2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace UnitTestProject
{
    [TestClass]
    public class EntityATests
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            Debug.WriteLine("ClassInitialize()");
        }

        [TestInitialize]
        public void TestInitialize()
        {
            Debug.WriteLine("TestInitialize()");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Debug.WriteLine("TestCleanup()");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            Debug.WriteLine("ClassCleanup()");
        }

        [TestMethod]
        public void Foo1Test()
        {
            Assert.AreEqual("123", EntityA.Foo1("123"));
        }

        [TestMethod]
        public void Foo2Test()
        {
            Assert.AreEqual("123", EntityA.Foo2("123"));
        }
    }
}
