// http://blog.nwcadence.com/shims-and-stubs-and-the-microsoft-fakes-framework/

using FileSystem.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileSystem.Test
{
    [TestClass]
    public class FileSystemTest
    {
        [TestMethod]
        public void FileIsNotEmpty()
        {
            var file = "MyFile.txt";
            var content = "hello world";

            var fileSystem = new StubIFileSystem()
            {
                ReadAllTextString = filename => { return content; }
            };

            bool result = FileHelper.IsEmpty(fileSystem, file);

            Assert.IsFalse(result);
        }
    }
}
