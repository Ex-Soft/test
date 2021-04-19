using System;
using ClassLibrary;
using Moq;
using TestXUnit.Fixtures.DataAttributes;
using Xunit;
using Xunit.Sdk;

namespace TestXUnit
{
    public class Worker2Test
    {
        [Theory, AutoMoqData]
        [Trait("ClassLibrary", "Worker2")]
        public void DoubleTestExpectedParameter(string autoMoqString)
        {
            //Arrange
            var mockWorker2 = new Mock<IWorker2>();
            _ = mockWorker2.Setup(x => x
                .Double(It.Is<string>(x => x == autoMoqString)))
                .Returns($"{autoMoqString}{autoMoqString}");
            var expected = $"{autoMoqString}{autoMoqString}";

            // Act
            var actual = mockWorker2.Object.Double(autoMoqString);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory, AutoMoqData]
        [Trait("ClassLibrary", "Worker2")]
        public void DoubleTestNotExpectedParameter(string autoMoqString)
        {
            // Arrange
            var mockWorker2 = new Mock<IWorker2>();
            _ = mockWorker2.Setup(x => x
                .Double(It.Is<string>(x => x == autoMoqString)))
                .Returns($"{autoMoqString}{autoMoqString}");

            // Act
            var actual = mockWorker2.Object.Double("blah-blah-blah");

            // Assert
            Assert.Null(actual);
        }

        [Fact]
        [Trait("ClassLibrary", "Worker2")]
        public void DoubleTestException()
        {
            // Arrange
            var mockWorker2 = new Mock<IWorker2>();

            _ = mockWorker2.Setup(x => x
                .Double(It.IsAny<string>()))
                .Returns<string>(str => $"{str}{str}");

            _ = mockWorker2.Setup(x => x
                .Double(It.Is<string>(x => string.Equals(x, "throw", StringComparison.InvariantCultureIgnoreCase))))
                .Throws(new Exception("exception"));

            // Act
            var actual = mockWorker2.Object.Double("string");

            // Assert
            Assert.Equal("stringstring", actual);

            var exception = Assert.Throws<Exception>(() => mockWorker2.Object.Double("tHrOw"));
            Assert.Equal("exception", exception.Message);
        }

        [Fact]
        [Trait("ClassLibrary", "Worker2")]
        public void DoubleTestParameter()
        {
            // Arrange
            var mockWorker2 = new Mock<IWorker2>();

            _ = mockWorker2.Setup(x => x
                .Double(It.IsAny<string>()));

            // Act
            _ = mockWorker2.Object.Double("string");

            // Assert
            mockWorker2.Verify(x => x
                .Double(It.Is<string>(x => x == "string")), Times.Once);
        }
    }
}
