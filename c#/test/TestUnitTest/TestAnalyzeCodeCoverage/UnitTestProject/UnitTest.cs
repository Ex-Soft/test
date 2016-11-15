using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
	[TestClass]
	public class UnitTest
	{
		[TestMethod]
		public void TestAdd()
		{
			// arrange
			var testClass = new TestClass();

			// act
			var result = testClass.Add(1, 2);

			// assert
			Assert.AreEqual(result, 3);
		}

		[TestMethod]
		public void TestSub()
		{
			// arrange
			var testClass = new TestClass();

			// act
			var result = testClass.Sub(1, 2);

			// assert
			Assert.AreEqual(result, -1);
		}
	}
}
