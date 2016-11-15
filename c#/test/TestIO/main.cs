using System.Threading;
using System.IO;
using System;

namespace TestIO
{
    class Program
    {
        static void Main(string[] args)
        {
            string
               currentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;

            if (currentDirectory.IndexOf("bin") != -1)
                currentDirectory = currentDirectory.Substring(0, currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1));

            string
                inputFileName = Path.Combine(currentDirectory, "test.txt");

            if (!File.Exists(inputFileName))
                return;

            System.Diagnostics.Debug.WriteLine(string.Format("Main thread ID={0}", Thread.CurrentThread.ManagedThreadId));

            int firstBytesCount = 100;
            byte[] content = new byte[firstBytesCount];

            var fileStream = new MyFileStream(inputFileName, FileMode.Open, FileAccess.Read, FileShare.Read, 1024, FileOptions.Asynchronous);
            //using (var fileStream = new MyFileStream(inputFileName, FileMode.Open, FileAccess.Read, FileShare.Read, 1024, FileOptions.Asynchronous))
            {
                fileStream.BeginRead(content, 0, firstBytesCount, ReadIsDone, new State { FileStream = fileStream, Content = content });
            }

            //Console.ReadLine();
        }

        static void ReadIsDone(IAsyncResult ar)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("ReadIsDone() starting... (thread ID={0})", Thread.CurrentThread.ManagedThreadId));

            State state = (State)ar.AsyncState;

            int bytesRead = state.FileStream.EndRead(ar);

            System.Diagnostics.Debug.WriteLine("ReadIsDone() b4 FileStream.Close()");
            state.FileStream.Close();
            System.Diagnostics.Debug.WriteLine("ReadIsDone() after FileStream.Close()");

            System.Diagnostics.Debug.WriteLine("ReadIsDone() finished");
        }
    }

    public class State
    {
        public FileStream FileStream { get; set; }
        public byte[] Content { get; set; }
    }
}
