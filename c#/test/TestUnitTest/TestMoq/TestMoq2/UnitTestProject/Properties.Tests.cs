// https://hamidmosalla.com/2017/08/03/moq-working-with-setupget-verifyget-setupset-verifyset-setupproperty/

using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestProject
{
    [TestClass]
    public class Properties
    {
        [TestMethod]
        public void TestProperty()
        {
            // Arrange
            var mock = new Mock<IInterfaceWithProperties>();
            _ = mock.Setup(x => x.Name).Returns("NameValue");

            // Act
            var actual = mock.Object.Name;

            // Assert
            Assert.AreEqual("NameValue", actual);
        }

        [TestMethod]
        public void TestHierarchicalProperty()
        {
            // Arrange
            var mock = new Mock<IInterfaceWithProperties>();
            _ = mock.Setup(x => x.Bar.Baz.Name).Returns("BazNameValue");

            // Act
            var actual = mock.Object.Bar.Baz.Name;

            // Assert
            Assert.AreEqual("BazNameValue", actual);
        }

        [TestMethod]
        public void TestPropertyGet()
        {
            // Arrange
            var mock = new Mock<IInterfaceWithProperties>();
            _ = mock.SetupGet(x => x.Name).Returns("TestPropertyGet");

            // Act
            var actual = mock.Object.Name;

            // Assert
            Assert.AreEqual("TestPropertyGet", actual);
            mock.VerifyGet(x => x.Name, Times.Once);
        }

        [TestMethod]
        public void TestPropertySet()
        {
            // Arrange
            var mock = new Mock<IInterfaceWithProperties>();
            mock.SetupSet(x => x.Name = "TestPropertySet").Verifiable();

            // Act
            mock.Object.Name = "TestPropertySet";

            // Assert
            mock.VerifySet(x => x.Name = "TestPropertySet");
            mock.Verify();
        }

        [TestMethod]
        public void TestSetupProperty()
        {
            // Arrange
            var mock = new Mock<IInterfaceWithProperties>();
            _ = mock.SetupProperty(x => x.Name);

            // Act
            mock.Object.Name = "TestSetupProperty";

            // Assert
            Assert.AreEqual("TestSetupProperty", mock.Object.Name);
        }

        [TestMethod]
        public void TestSetupPropertyWithInitialization()
        {
            // Arrange
            var mock = new Mock<IInterfaceWithProperties>();
            _ = mock.SetupProperty(x => x.Name, "TestSetupProperty");

            // Assert
            Assert.AreEqual("TestSetupProperty", mock.Object.Name);
        }

        [TestMethod]
        public void TestDifferenceBetweenSetupGetAndSetupProperty()
        {
            var mock = new Mock<IInterfaceWithProperties>();

            _ = mock.SetupProperty(x => x.Name, "TestSetupProperty");
            //_ = mock.SetupGet(x => x.Name).Returns("TestSetupProperty");

            Assert.AreEqual("TestSetupProperty", mock.Object.Name);

            mock.Object.Name = "You can't change the property later with setupGet, but with setupProperty you can.";
            Assert.AreEqual("You can't change the property later with setupGet, but with setupProperty you can.", mock.Object.Name);
        }

        [TestMethod]
        public void TestSetupAllProperties()
        {
            var mock = new Mock<IInterfaceWithProperties>();

            _ = mock.SetupAllProperties();
            //_ = mock.SetupProperty(x => x.Name);

            mock.Object.Name = "TestSetupAllProperties";
            mock.Object.Value = 13;

            Assert.AreEqual("TestSetupAllProperties", mock.Object.Name);
            Assert.AreEqual(13, mock.Object.Value);
        }
    }
}
