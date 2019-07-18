using System.Reflection;

namespace TestSimple
{
    public class SmthInnerClass : ISmthInnerInterface
    {
        readonly IConsoleWriter _consoleWriter;

        public SmthInnerClass(IConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter;
        }

        public void Foo1()
        {
            _consoleWriter.LogMessage($"{GetType().Name}.{MethodBase.GetCurrentMethod().Name}()");
        }
    }
}
