using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace StubsTutorial
{
    public static class FileSystem
    {
        public static string ReadAllText(string fileName)
        {
            return File.ReadAllText(fileName);
        }
    }
}