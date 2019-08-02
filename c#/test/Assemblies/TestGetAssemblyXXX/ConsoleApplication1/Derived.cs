using System.Diagnostics;
using ClassLibrary1;

namespace ConsoleApplication1
{
    public class Derived : Base
    {
        public override string GetExecutingAssemblyName()
        {
            var assemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName();
            var currentMethod = System.Reflection.MethodBase.GetCurrentMethod();

            Debug.WriteLine($"{assemblyName.Name}.Derived.{currentMethod.Name}()");

            return assemblyName.Name;
        }

        public override string GetCallingAssemblyName()
        {
            var assemblyName = System.Reflection.Assembly.GetCallingAssembly().GetName();
            var currentMethod = System.Reflection.MethodBase.GetCurrentMethod();

            Debug.WriteLine($"{assemblyName.Name}.Derived.{currentMethod.Name}()");

            return assemblyName.Name;
        }

        public override string GetEntryAssemblyName()
        {
            var assemblyName = System.Reflection.Assembly.GetEntryAssembly().GetName();
            var currentMethod = System.Reflection.MethodBase.GetCurrentMethod();

            Debug.WriteLine($"{assemblyName.Name}.Derived.{currentMethod.Name}()");

            return assemblyName.Name;
        }
    }
}
