using static System.Console;

namespace TestSimple
{
    public class ConsoleWriter : IConsoleWriter
    {
        readonly ISingletonDemo singletonDemo;

        public ConsoleWriter(ISingletonDemo singletonDemo)
        {
            this.singletonDemo = singletonDemo;
        }

        public void LogMessage(string message)
        {
            WriteLine(message);
            System.Diagnostics.Debug.WriteLine(message);

            WriteLine(message = $"ConsoleWriter.LogMessage: singletonDemo.ObjectId = {singletonDemo.ObjectId}");
            System.Diagnostics.Debug.WriteLine(message);
        }
    }
}
