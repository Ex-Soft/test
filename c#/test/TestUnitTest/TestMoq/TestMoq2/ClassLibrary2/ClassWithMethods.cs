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
    }
}
