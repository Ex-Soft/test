using System.Diagnostics;
using System.Reflection;

namespace ClassLibrary1
{
    public static class IInterfaceWithMethodsExtensions
    {
        public static void ExtVoidVoid(this IInterfaceWithMethods instance)
        {
            Debug.WriteLine($"{instance.GetType().Name}.{MethodBase.GetCurrentMethod().Name}");
        }

        public static int ExtIntIntInt(this IInterfaceWithMethods instance, int a, int b)
        {
            Debug.WriteLine($"{instance.GetType().Name}.{MethodBase.GetCurrentMethod().Name}");

            return a + b;
        }
    }
}
