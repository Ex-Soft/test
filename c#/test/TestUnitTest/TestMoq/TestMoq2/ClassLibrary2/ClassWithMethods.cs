using System.Diagnostics;
using System.Reflection;

namespace ClassLibrary2
{
    public class ClassWithMethods : IInterfaceWithMethods
    {
        public void Foo1()
        {
            Debug.WriteLine($"{GetType().Name}.{MethodBase.GetCurrentMethod().Name}");
        }

        public void Foo2(string str)
        {
            Debug.WriteLine($"{GetType().Name}.{MethodBase.GetCurrentMethod().Name}({str})");
        }

        public string Foo3(string str)
        {
            return $"{str} {str}";
        }
    }
}
