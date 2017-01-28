using System.Diagnostics;

namespace ClassLibrary
{
    public class Base
    {
        public virtual string GetExecutingAssemblyName()
        {
            var assemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName();
            var currentMethod = System.Reflection.MethodBase.GetCurrentMethod();

            Debug.WriteLine($"{assemblyName.Name}.Base.{currentMethod.Name}()");

            return assemblyName.Name;
        }

        public virtual string GetCallingAssemblyName()
        {
            var assemblyName = System.Reflection.Assembly.GetCallingAssembly().GetName();
            var currentMethod = System.Reflection.MethodBase.GetCurrentMethod();

            Debug.WriteLine($"{assemblyName.Name}.Base.{currentMethod.Name}()");

            return assemblyName.Name;
        }

        public virtual string GetEntryAssemblyName()
        {
            var assemblyName = System.Reflection.Assembly.GetEntryAssembly().GetName();
            var currentMethod = System.Reflection.MethodBase.GetCurrentMethod();

            Debug.WriteLine($"{assemblyName.Name}.Base.{currentMethod.Name}()");

            return assemblyName.Name;
        }
    }
}
