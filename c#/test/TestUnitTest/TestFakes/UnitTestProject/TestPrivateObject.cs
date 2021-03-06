﻿using System;
using System.Reflection;
using ClassLibrary2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class TestPrivateObject
    {
        [TestMethod]
        public void TestPrivateObject1()
        {
            var o = new ClassWithPrivateMembers(2, 3);

            var privateObject = new PrivateObject(o);

            Assert.AreEqual((int)privateObject.GetFieldOrProperty("_privateFInt"), 2);
            Assert.AreEqual((int)privateObject.GetFieldOrProperty("PrivatePInt"), 3);

            var result = privateObject.Invoke("Mul", new object[] { 5 });
            Assert.AreEqual(result, 150);
        }

        [TestMethod]
        public void TestPrivateObjectCallBasePrivateMethod()
        {
            var o = new DerivedClass("Derived (from Derived)", "Base (from Derived)");
            var privateObject = new PrivateObject(o, new PrivateType(typeof(BaseClass)));

            privateObject.Invoke("BasePrivateMethod");
            privateObject.Invoke("BaseProtectedMethod");
            privateObject.Invoke("BasePublicMethod");

            privateObject.Invoke("BaseProtectedVirtualMethod");
            privateObject.Invoke("BasePublicVirtualMethod");
        }

        [TestMethod]
        public void TestPrivateObjectCallDerivedPrivateMethod()
        {
            var o = new DerivedClass("Derived (from Derived)", "Base (from Derived)");
            var privateObject = new PrivateObject(o);

            privateObject.Invoke("DerivedPrivateMethod");

            var actual = privateObject.Invoke("DerivedProtectedMethod", new object[] { null });
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual is bool);
            Assert.IsFalse((bool)actual);

            actual = privateObject.Invoke("DerivedProtectedMethod", new object());
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual is bool);
            Assert.IsTrue((bool)actual);

            privateObject.Invoke("DerivedPublicMethod");

            actual = privateObject.Invoke("BaseProtectedVirtualMethod", new object[] { null });
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual is bool);
            Assert.IsFalse((bool)actual);

            actual = privateObject.Invoke("BaseProtectedVirtualMethod", new object());
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual is bool);
            Assert.IsTrue((bool)actual);

            privateObject.Invoke("BasePublicVirtualMethod");
        }
    }
}
