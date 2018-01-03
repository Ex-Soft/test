using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ClassLibrary2;

namespace UnitTestProject
{
    [TestClass]
    public class Library2Test
    {
        [TestMethod]
        public void TestMulWithSpecificValues()
        {
            //System.Diagnostics.Debugger.Launch();

            var mock = new Mock<ISmthInterface>();
            mock.Setup(o => o.Mul(2, 3)).Returns(5);

            var smthClass = new SmthClass();

            var actual = smthClass.Mul(mock.Object, 3, 3);
            Assert.AreEqual(0, actual);

            actual = smthClass.Mul(mock.Object, 2, 3);
            Assert.AreEqual(5, actual);
        }

        [TestMethod]
        public void TestMulWithUnusedAnyValues()
        {
            //System.Diagnostics.Debugger.Launch();

            var mock = new Mock<ISmthInterface>();
            mock.Setup(o => o.Mul(It.IsAny<int>(), It.IsAny<int>())).Returns(5);

            var smthClass = new SmthClass();

            var actual = smthClass.Mul(mock.Object, 3, 3);
            Assert.AreEqual(5, actual);

            actual = smthClass.Mul(mock.Object, 2, 3);
            Assert.AreEqual(5, actual);
        }

        [TestMethod]
        public void TestMulWithUsedAnyValues()
        {
            //System.Diagnostics.Debugger.Launch();

            var mock = new Mock<ISmthInterface>();
            mock.Setup(o => o.Mul(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((right, left) => right + left);

            var smthClass = new SmthClass();

            var actual = smthClass.Mul(mock.Object, 3, 3);
            Assert.AreEqual(6, actual);

            actual = smthClass.Mul(mock.Object, 2, 3);
            Assert.AreEqual(5, actual);
        }
    }
}
