using System.Diagnostics;
using System.IO;

namespace TestDebug
{
    class Program
    {
        static void Main(string[] args)
        {
            string
                currentDirectory = Directory.GetCurrentDirectory(),
                logFileName = currentDirectory.Substring(0, currentDirectory.LastIndexOf("bin", currentDirectory.Length - 1)) + "debug.log";

            if(File.Exists(logFileName))
                File.Delete(logFileName);

            StreamWriter
               myOutputWriter = new StreamWriter(logFileName);

            myOutputWriter.AutoFlush = true;

            TextWriterTraceListener
                myDebugWriter = new TextWriterTraceListener(myOutputWriter);

            Debug.Listeners.Add(myDebugWriter);
            Debug.WriteLine("TestDebug");
        }
    }
}
