using System.Reflection;

namespace TestSimple
{
    public class SmthOuterClass : ISmthOuterInterface
    {
        readonly ISmthInnerInterface _innerClass;
        readonly IConsoleWriter _consoleWriter;

        public SmthOuterClass(ISmthInnerInterface innerClass, IConsoleWriter consoleWriter)
        {
            _innerClass = innerClass;
            _consoleWriter = consoleWriter;
        }

        public void Foo1()
        {
            _consoleWriter.LogMessage($"{GetType().Name}.{MethodBase.GetCurrentMethod().Name}()");
            _innerClass?.Foo1();
        }
    }
}
