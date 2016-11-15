using System.IO;

namespace TestIO
{
    public class MyFileStream : FileStream
    {
        public MyFileStream(string path, FileMode mode, FileAccess access, FileShare share, int bufferSize, FileOptions fileOptions) : base(path, mode,access, share, bufferSize, fileOptions)
        {}

        protected override void Dispose(bool disposing)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("FileStream.Dispose({0})", disposing));

            base.Dispose(disposing);
        }
    }
}
