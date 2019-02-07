using static System.Console;

namespace TestSimple
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void LogMessage(string message)
        {
            WriteLine(message);
            System.Diagnostics.Debug.WriteLine(message);
        }
    }
}
