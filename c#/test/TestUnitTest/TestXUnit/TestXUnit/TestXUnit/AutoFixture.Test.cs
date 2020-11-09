using AutoFixture;
using ClassLibrary;
using TestXUnit.Fixtures.DataAttributes;
using Xunit;

namespace TestXUnit
{
    public class AutoFixtureTest
    {
        [Fact]
        [Trait("ClassLibrary", "AutoFixture")]
        public void ConcatATestByCreate()
        {
            //Arrange
            var a = new Fixture().Create<A>();
            var worker = new Worker();

            // Act
            var result = worker.Concat(a);

            // Assert
            Assert.Contains("AString1", result);
            Assert.Contains("AString2", result);
            Assert.Contains("AString3", result);
        }

        [Fact]
        [Trait("ClassLibrary", "AutoFixture")]
        public void ConcatATestByConfigureAndCreate()
        {
            //Arrange
            var a = new Fixture().Build<A>().With(e => e.AString1, "AString1_AString1").Without(e => e.AString3).Create();
            var worker = new Worker();

            // Act
            var result = worker.Concat(a);

            // Assert
            Assert.Contains("AString1_AString1", result);
            Assert.Contains("AString2", result);
            Assert.Contains("pString3", result);
        }

        [Theory, AutoMoqData]
        [Trait("ClassLibrary", "AutoFixture")]
        public void ConcatATestByAutoMoqData(A a)
        {
            //Arrange
            var worker = new Worker();

            // Act
            var result = worker.Concat(a);

            // Assert
            Assert.Contains("AString1", result);
            Assert.Contains("AString2", result);
            Assert.Contains("AString3", result);
        }

        [Theory, AutoMoqData]
        [Trait("ClassLibrary", "AutoFixture")]
        public void ConcatABTestByAutoMoqData(A a, B b)
        {
            //Arrange
            var worker = new Worker();

            // Act
            var result = worker.Concat(a, b);

            // Assert
            Assert.Contains("AString1", result);
            Assert.Contains("BString1", result);
            Assert.Contains("AString2", result);
            Assert.Contains("BString2", result);
            Assert.Contains("AString3", result);
            Assert.Contains("BString3", result);
        }

        [Theory]
        [InlineAutoMoqData("InlineAutoMoqData1", "InlineAutoMoqData2", "InlineAutoMoqData3")]
        [Trait("ClassLibrary", "AutoFixture")]
        public void ConcatABTestByInlineAutoMoqData(string inlineAutoMoqData1, string inlineAutoMoqData2, string inlineAutoMoqData3, B b)
        {
            //Arrange
            var a = new A(inlineAutoMoqData1, inlineAutoMoqData2, inlineAutoMoqData3);
            var worker = new Worker();

            // Act
            var result = worker.Concat(a, b);

            // Assert
            Assert.Contains(inlineAutoMoqData1, result);
            Assert.Contains("BString1", result);
            Assert.Contains(inlineAutoMoqData2, result);
            Assert.Contains("BString2", result);
            Assert.Contains(inlineAutoMoqData3, result);
            Assert.Contains("BString3", result);
        }
    }
}
