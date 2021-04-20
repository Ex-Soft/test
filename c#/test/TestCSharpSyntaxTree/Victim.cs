using System.Reflection;

using static System.Console;

namespace TestCSharpSyntaxTree
{
    public interface IVictim
    {
        public void Foo1();
    }

    public class Victim1 : IVictim
    {
        public void Foo1()
        {
            WriteLine($"{GetType().Name}.{MethodBase.GetCurrentMethod()?.Name}()");
        }
    }
    public class Victim2 : IVictim
    {
        public void Foo1()
        {
            WriteLine($"{GetType().Name}.{MethodBase.GetCurrentMethod()?.Name}()");
        }
    }

    public class Victim3 : IVictim
    {
        public void Foo1()
        {
            WriteLine($"{GetType().Name}.{MethodBase.GetCurrentMethod()?.Name}()");
        }
    }
}
