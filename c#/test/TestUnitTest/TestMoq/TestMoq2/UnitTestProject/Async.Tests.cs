using System;
using System.Threading.Tasks;
using ClassLibrary2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestProject
{
    [TestClass]
    public class AsyncTests
    {
        [TestMethod]
        public async Task CallReal()
        {
            // Arrange
            var server = new Server();
            var client = new Client(server);

            // Act
            var actual = await client.GetAsync(1000);

            // Assert
            Assert.AreEqual("MoveNext()", actual);
        }

        [TestMethod]
        public async Task CallViaResult()
        {
            // Arrange
            var server = new Mock<IServer>();
            _ = server.Setup(x => x.GetAsync(It.IsAny<int>()).Result).Returns("Result is used");

            var client = new Client(server.Object);

            // Act
            var actual = await client.GetAsync(1000);

            // Assert
            Assert.AreEqual("Result is used", actual);
        }

        [TestMethod]
        public async Task CallViaReturnsAsync()
        {
            // Arrange
            var server = new Mock<IServer>();
            _ = server.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync("ReturnsAsync is used");

            var client = new Client(server.Object);

            // Act
            var actual = await client.GetAsync(1000);

            // Assert
            Assert.AreEqual("ReturnsAsync is used", actual);
        }

        [TestMethod]
        public async Task CallViaReturns()
        {
            // Arrange
            var server = new Mock<IServer>();
            _ = server.Setup(x => x.GetAsync(It.IsAny<int>())).Returns(Task.FromResult("Returns is used"));

            var client = new Client(server.Object);

            // Act
            var actual = await client.GetAsync(1000);

            // Assert
            Assert.AreEqual("Returns is used", actual);
        }

        [TestMethod]
        public void TestThrowsIncorrect()
        {
            // Arrange
            var server = new Mock<IServer>();
            _ = server.Setup(x => x
                .GetAsync(It.IsAny<int>()))
                .Throws(new Exception("ExceptionMessage"));

            var client = new Client(server.Object);

            // Act
            Exception exception = Assert.ThrowsException<Exception>(async () =>
            {
                await client.GetAsync(1000);
            });

            // Assert
            Assert.AreEqual("ExceptionMessage", exception.Message);
        }

        [TestMethod]
        public async Task TestThrows()
        {
            // Arrange
            var server = new Mock<IServer>();
            _ = server.Setup(x => x
                .GetAsync(It.IsAny<int>()))
                .Throws(new Exception("ExceptionMessage"));

            var client = new Client(server.Object);

            // Act
            var exception = await Assert.ThrowsExceptionAsync<Exception>(async () =>
            {
                await client.GetAsync(1000);
            });

            // Assert
            Assert.AreEqual("ExceptionMessage", exception.Message);
        }

        [TestMethod]
        public async Task TestThrowsAsync()
        {
            // Arrange
            var server = new Mock<IServer>();
            _ = server.Setup(x => x
                .GetAsync(It.IsAny<int>()))
                .ThrowsAsync(new Exception("ExceptionMessage"));

            var client = new Client(server.Object);

            // Act
            var exception = await Assert.ThrowsExceptionAsync<Exception>(async () =>
            {
                await client.GetAsync(1000);
            });

            // Assert
            Assert.AreEqual("ExceptionMessage", exception.Message);
        }
    }
}
