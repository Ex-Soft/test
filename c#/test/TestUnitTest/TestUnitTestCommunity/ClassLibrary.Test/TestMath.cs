using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassLibrary.Test
{
    [TestClass]
    public class TestMath
    {
        [TestMethod]
        public void TestAdd()
        {
            // arrange
            var math = new Math();

            // act
            var result = math.Add(1, 2);

            // assert
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void TestSub()
        {
            // arrange
            var math = new Math();

            // act
            var result = math.Sub(1, 2);

            // assert
            Assert.AreEqual(result, -1);
        }
    }
}
