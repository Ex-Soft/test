using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StubsTutorial
{
    public class TestReader
    {
        public string Content { get; private set; }
        public void LoadFile(string fileName)
        {
            var content = FileSystem.ReadAllText(fileName);
            if (!content.StartsWith("test"))
                throw new ArgumentException("invalid file");
            this.Content = content;
        }
    }

    public class TestReaderWithStubs
    {
        IFileSystem fs;

        //constructor
        public TestReaderWithStubs(IFileSystem fs)
        {
            this.fs = fs;
        }

        public void LoadFile(string fileName)
        {
            var content = this.fs.ReadAllText(fileName);
            if (!content.StartsWith("test"))
                throw new ArgumentException("invalid file");
            this.Content = content;
        }

        public string Content { get; private set; }
    }
}
