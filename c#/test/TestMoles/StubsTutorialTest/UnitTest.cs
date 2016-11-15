using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StubsTutorial.Moles;

namespace StubsTutorial
{
    [TestClass]
    public partial class TestReaderTest
    {
        [TestMethod]
        public void CheckValidFile()
        {
            // arrange
            var fileName = "test.txt";
            var content = "test";
            File.WriteAllText(fileName, content);
            // act
            var test = new TestReader();
            test.LoadFile(fileName);
            // assert
            Assert.AreEqual(content, test.Content);
        }

        [TestMethod]
        public void CheckValidFileWithStubs()
        {
            // arrange
            var fileName = "test.txt";
            var content = "test";
            //File.WriteAllText(fileName, content);
            var fs = new SIFileSystem();
            fs.ReadAllTextString = delegate(string f)
                                       {
                                           Assert.IsTrue(f == fileName);
                                           return content;
                                       };
            // act
            //var test = new TestReader();
            var test = new TestReaderWithStubs(fs);
            test.LoadFile(fileName);
            // assert
            Assert.AreEqual(content, test.Content);
        }

        [TestMethod]
        [HostType("Moles")]
        public void CheckValidFileWithMoles()
        {
            // arrange
            var fileName = "test.txt";
            var content = "test";
            MFileSystem.ReadAllTextString = delegate(string f)
                                                {
                                                    Assert.IsTrue(f == fileName);
                                                    return content;
                                                };
            // act
            var test = new TestReader();
            test.LoadFile(fileName);
            // assert
            Assert.AreEqual(content, test.Content);
        }
    }
}