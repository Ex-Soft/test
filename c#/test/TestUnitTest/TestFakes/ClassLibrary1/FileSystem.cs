// http://blog.nwcadence.com/shims-and-stubs-and-the-microsoft-fakes-framework/

using System.IO;

namespace FileSystem
{
    public interface IFileSystem
    {
        string ReadAllText(string fileName);
    }

    public class FileSystem : IFileSystem
    {
        public string ReadAllText(string fileName)
        {
            return File.ReadAllText(fileName);
        }
    }

    public static class FileHelper
    {
        public static bool IsEmpty(IFileSystem fs, string f)
        {
            var content = fs.ReadAllText(f);
            return string.IsNullOrEmpty(content);
        }
    }
}
