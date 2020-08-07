#define TEST_A

using System.Reflection;

using static System.Console;

namespace TestVar
{
    public class A
    {
        public void Foo()
        {
            WriteLine($"{GetType().Name}.{MethodBase.GetCurrentMethod().Name}()");
        }
    }

    public class B
    {
        public void Foo()
        {
            WriteLine($"{GetType().Name}.{MethodBase.GetCurrentMethod().Name}()");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var tmp = Create();
            tmp.Foo();
        }

        static
            #if TEST_A
                A
            #else
                B
            #endif
            Create()
        {
            return new
                #if TEST_A
                    A
                #else
                    B
                #endif
                ();
        }
    }
}
