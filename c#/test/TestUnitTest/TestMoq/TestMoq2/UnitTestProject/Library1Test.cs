// https://andrewlock.net/creating-parameterised-tests-in-xunit-with-inlinedata-classdata-and-memberdata/

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ClassLibrary1;
using FluentAssertions;

namespace UnitTestProject
{
    [TestClass]
    public class Library1TestW
    {
        public interface ITest : IInterfaceWithMethods
        {
            //public void ExtVoidVoid();
            //public int ExtIntIntInt(int a, int b);
        }

        [TestMethod]
        public void TestIfMethodWasCalled()
        {
            //System.Diagnostics.Debugger.Launch();

            var mock = new Mock<IInterfaceWithMethods>();
            mock.Setup(o => o.FooVoidVoid());
            mock.Setup(o => o.FooIntIntInt(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((a, b) => a + b);

            var smthClass = new SmthClass(mock.Object);

            smthClass.FooVoidVoid();
            mock.Verify(o => o.FooVoidVoid(), Times.Once);

            var actual = smthClass.FooIntIntInt(2, 3);
            actual.Should().Be(5);
            mock.Verify(o => o.FooIntIntInt(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        public void TestIfMethodThrewException()
        {
            //System.Diagnostics.Debugger.Launch();

            var mock = new Mock<IInterfaceWithMethods>();
            mock.Setup(o => o.FooVoidVoidException()).Throws<NullReferenceException>();
            mock.Setup(o => o.FooIntIntIntException(It.IsAny<int>(), It.IsAny<int>())).Throws<ArgumentNullException>();

            var smthClass = new SmthClass(mock.Object);

            Action act = () => smthClass.FooVoidVoidException();
            act.Should().Throw<NullReferenceException>();
            mock.Verify(o => o.FooVoidVoidException(), Times.Once);

            act = () => smthClass.FooIntIntIntException(2, 3);
            act.Should().Throw<ArgumentNullException>();
            mock.Verify(o => o.FooIntIntIntException(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        // https://codethug.com/2017/09/09/Mocking-Extension-Methods/
        // http://adventuresdotnet.blogspot.com/2011/03/mocking-static-methods-for-unit-testing.html
        [TestMethod]
        public void TestExtensionMethod()
        {
            //System.Diagnostics.Debugger.Launch();

            var mockTest = new Mock<ITest>();
            mockTest.Setup(o => o.ExtVoidVoid());
            mockTest.Setup(o => o.ExtIntIntInt(It.IsAny<int>(), It.IsAny<int>())).Returns<int, int>((a, b) => a + b);

            var mockReal = mockTest.As<IInterfaceWithMethods>();
            mockReal.Setup(o => o.FooVoidVoid());

            var smthClass = new SmthClass(mockTest.Object);

            smthClass.FooVoidVoid();
            mockTest.Verify(o => o.FooVoidVoid(), Times.Once);

            smthClass.ExtVoidVoid();
            mockTest.Verify(o => o.ExtVoidVoid(), Times.Once);

            /*var actual = smthClass.ExtIntIntInt(2, 3);
            actual.Should().Be(5);
            mock.Verify(o => o.ExtIntIntInt(It.IsAny<int>(), It.IsAny<int>()), Times.Once);*/
        }
    }
}
