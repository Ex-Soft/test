using ClassLibrary2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class TestPrivateObject
    {
        [TestMethod]
        public void TestPrivateObject1()
        {
            var o = new ClassWithPrivateMembers(2, 3);

            var privateObject = new PrivateObject(o);

            Assert.AreEqual((int)privateObject.GetFieldOrProperty("_privateFInt"), 2);
            Assert.AreEqual((int)privateObject.GetFieldOrProperty("PrivatePInt"), 3);

            var result = privateObject.Invoke("Mul", new object[] { 5 });
            Assert.AreEqual(result, 150);
        }
    }
}
