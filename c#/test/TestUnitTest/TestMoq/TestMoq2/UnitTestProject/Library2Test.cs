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

        [TestMethod]
        public void TestSmthClassWithMultipleInterfaces()
        {
            var i1 = new Mock<I1>();
            i1.Setup(o => o.Foo()).Returns("1");
            var i2 = i1.As<I2>();
            i2.Setup(o => o.Foo()).Returns("2");
            var i3 = i2.As<I3>();
            i3.Setup(o => o.Foo()).Returns("3");

            var smthClassWithMultipleInterfaces = new SmthClassWithMultipleInterfaces();

            var actual = smthClassWithMultipleInterfaces.Run(i1.Object);
            Assert.AreEqual("123", actual);

            actual = smthClassWithMultipleInterfaces.Run(i2.Object);
            Assert.AreEqual("123", actual);

            actual = smthClassWithMultipleInterfaces.Run(i3.Object);
            Assert.AreEqual("123", actual);
        }

        // Moq SetupGet
        [TestMethod]
        public void SetupPropertyWithSetupGet()
        {
            var mock = new Mock<IPropertyManager>();
            var nameUser = new PropertyManagerConsumer(mock.Object);
            mock.SetupGet(m => m.FirstName).Returns("Someone Nice");

            var name = nameUser.GetName();

            Assert.AreEqual("Someone Nice", name);
        }

        // Moq VerifyGet
        [TestMethod]
        public void VerifyPropertyWithVerifyGet()
        {
            var mock = new Mock<IPropertyManager>();
            var nameUser = new PropertyManagerConsumer(mock.Object);

            nameUser.GetName();

            mock.VerifyGet(m => m.FirstName, Times.Once);
        }

        // Moq SetupSet
        [TestMethod]
        public void VerifyPropertyIsSet_WithSpecificValue_WithSetupSet()
        {
            var mock = new Mock<IPropertyManager>();
            var nameUser = new PropertyManagerConsumer(mock.Object);

            mock.SetupSet(m => m.FirstName = "Knights Of Ni!").Verifiable();

            nameUser.ChangeName("Knights Of Ni!");

            mock.Verify();
        }

        // Moq VerifySet
        [TestMethod]
        public void VerifyPropertyIsSet_WithSpecificValue_WithVerifySet()
        {
            var mock = new Mock<IPropertyManager>();
            var nameUser = new PropertyManagerConsumer(mock.Object);

            nameUser.ChangeName("No Shrubbery!");

            mock.VerifySet(m => m.FirstName = "No Shrubbery!");
        }

        // Verifying Method Pass The Correct Argument
        [TestMethod]
        public void Verify()
        {
            var mock = new Mock<IPropertyManager>();
            var nameUser = new PropertyManagerConsumer(mock.Object);

            nameUser.ChangeRemoteName("My dear old wig");

            //we are verifying that ChangeRemoteName sends the correct string to MutateFirstName
            mock.Verify(m => m.MutateFirstName(It.Is<string>(a => a == "My dear old wig")), Times.Once);
        }

        // Moq SetUpProperty
        [TestMethod]
        public void TrackPropertyWithSetUpProperty()
        {
            var mock = new Mock<IPropertyManager>();

            mock.SetupProperty(m => m.FirstName);
            mock.Object.FirstName = "Ni!";

            Assert.AreEqual("Ni!", mock.Object.FirstName);

            mock.Object.FirstName = "der wechselnden";
            Assert.AreEqual("der wechselnden", mock.Object.FirstName);
        }
        [TestMethod]
        public void InitializeTrackPropertyWithSetUpProperty()
        {
            var mock = new Mock<IPropertyManager>();
            var nameUser = new PropertyManagerConsumer(mock.Object);

            mock.SetupProperty(m => m.FirstName, "ManBearPig");

            Assert.AreEqual("ManBearPig", mock.Object.FirstName);
        }

        // Difference Between SetupGet And SetupProperty
        [TestMethod]
        public void InitializeTrackPropertyWithSetUpPropertyDiff()
        {
            //System.Diagnostics.Debugger.Launch();

            var mock = new Mock<IPropertyManager>();
            var nameUser = new PropertyManagerConsumer(mock.Object);

            mock.SetupProperty(m => m.FirstName, "Regina");

            //You can't change the property later with setupGet, but with setupProperty you can.
            //Comment the setup property code and uncomment this to see the difference.
            //mock.SetupGet(m => m.FirstName).Returns("Regina");

            Assert.AreEqual("Regina", mock.Object.FirstName);

            mock.Object.FirstName = "Floyd";
            Assert.AreEqual("Floyd", mock.Object.FirstName);
        }

        // Moq SetupAllProperties
        [TestMethod]
        public void TrackAllPropertiesWithSetupAllProperties()
        {
            //System.Diagnostics.Debugger.Launch();

            var mock = new Mock<IPropertyManager>();

            //mock.SetupProperty(m => m.FirstName);

            //Comment this and uncomment SetupProperty, the assertion fails
            mock.SetupAllProperties();

            mock.Object.FirstName = "Robert";
            mock.Object.LastName = "Paulson";

            Assert.AreEqual("Robert", mock.Object.FirstName);
            Assert.AreEqual("Paulson", mock.Object.LastName);
        }
    }
}
