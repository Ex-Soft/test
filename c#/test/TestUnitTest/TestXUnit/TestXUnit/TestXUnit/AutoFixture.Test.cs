// https://github.com/AutoFixture/AutoFixture/wiki/Cheat-Sheet
// https://blog.ploeh.dk/2010/10/19/Convention-basedCustomizationswithAutoFixture/
// https://stackoverflow.com/questions/15531321/how-do-i-use-autofixture-v3-with-icustomization-ispecimenbuilder-to-deal-with/15561752
// https://stackoverflow.com/questions/38688932/how-to-use-autofixture-to-build-with-customized-properties-while-keeping-type-cu
// https://stackoverflow.com/questions/36365147/autofixture-create-a-list-of-email-addresses

using System.Linq;
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

        [Theory, CustomerData]
        [Trait("ClassLibrary", "AutoFixture")]
        public void TestComplexObject(string str1, string str2, Customer customer)
        {
            Assert.Contains("str1", str1);
            Assert.Contains("str2", str2);

            Assert.Contains("FirstName", customer.FirstName);
            Assert.Equal("MiddleName_MiddleName", customer.MiddleName);

            Assert.Equal(5, customer.Addresses.Count);
            Assert.Equal("CA", customer.Addresses[0].CountryCode);
            Assert.Contains("PostalCode", customer.Addresses[0].PostalCode);
            Assert.Equal(5, customer.Addresses.Count(item => item.CountryCode == "CA"));
        }

        [Theory, CustomerDataWithRandomCountryCode]
        [Trait("ClassLibrary", "AutoFixture")]
        public void TestComplexObjectWithRandomValues(string str1, string str2, Customer customer)
        {
            Assert.Contains("str1", str1);
            Assert.Contains("str2", str2);

            Assert.Contains("FirstName", customer.FirstName);

            Assert.Equal(5, customer.Addresses.Count);
            Assert.Equal("US", customer.Addresses[0].CountryCode);
            Assert.Equal("CA", customer.Addresses[1].CountryCode);
            Assert.Equal(3, customer.Addresses.Count(item => item.CountryCode == "US"));
            Assert.Equal(2, customer.Addresses.Count(item => item.CountryCode == "CA"));
        }
    }
}
