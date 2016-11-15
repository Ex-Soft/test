using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StubsTutorial
{
    public interface IFileSystem
    {
        string ReadAllText(string fileName);
    }
}