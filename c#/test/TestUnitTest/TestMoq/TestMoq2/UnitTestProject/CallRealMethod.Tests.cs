using System;
using ClassLibrary2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestProject
{
    [TestClass]
    public class CallRealMethodTests
    {
        [TestMethod]
        public void CallReal()
        {
            // Arrange
            var mock = new Mock<ClassWithMethods2> { CallBase = true };

            // Act
            var actualStr = mock.Object.StringFooString("TestCallBase");
            var actualInt = mock.Object.IntFooInt(13);

            // Assert
            Assert.AreEqual("TestCallBase", actualStr);
            Assert.AreEqual(13, actualInt);
        }
        
        [TestMethod]
        public void CallReal2()
        {
            // Arrange
            var mock = new Mock<ClassWithMethods2>();

            _ = mock.Setup(x => x
                .StringFooString(It.IsAny<string>()))
                .Returns<string>(str => $"{str}-{str}");

            _ = mock.Setup(x => x
                .StringFooString(It.Is<string>(p => string.Equals(p, "testcallbase", StringComparison.InvariantCultureIgnoreCase))))
                .CallBase();

            // Act
            var actualRealStr = mock.Object.StringFooString("TestCallBase");
            var actualMockStr = mock.Object.StringFooString("TestMock");

            // Assert
            Assert.AreEqual("TestCallBase", actualRealStr);
            Assert.AreEqual("TestMock-TestMock", actualMockStr);
        }

        [TestMethod]
        public void CallHalfReal()
        {
            // Arrange
            var mock = new Mock<ClassWithMethods2> { CallBase = true };

            _ = mock.Setup(x => x
                .IntFooInt(It.IsAny<int>()))
                .Returns<int>(i => i * 13);

            // Act
            var actualStr = mock.Object.StringFooString("TestCallBase");
            var actualInt = mock.Object.IntFooInt(13);

            // Assert
            Assert.AreEqual("TestCallBase", actualStr);
            Assert.AreEqual(169, actualInt);
        }
    }
}
