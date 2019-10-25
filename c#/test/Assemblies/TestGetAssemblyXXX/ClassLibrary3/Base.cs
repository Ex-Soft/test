using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ClassLibrary3
{
    public class Base
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public virtual string GetExecutingAssemblyName()
        {
            var assemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName();
            var currentMethod = System.Reflection.MethodBase.GetCurrentMethod();

            Debug.WriteLine($"{assemblyName.Name}.Base.{currentMethod.Name}()");

            return assemblyName.Name;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public virtual string GetCallingAssemblyName()
        {
            var assemblyName = System.Reflection.Assembly.GetCallingAssembly().GetName();
            var currentMethod = System.Reflection.MethodBase.GetCurrentMethod();

            Debug.WriteLine($"{assemblyName.Name}.Base.{currentMethod.Name}()");

            return assemblyName.Name;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public virtual string GetEntryAssemblyName()
        {
            var assemblyName = System.Reflection.Assembly.GetEntryAssembly().GetName();
            var currentMethod = System.Reflection.MethodBase.GetCurrentMethod();

            Debug.WriteLine($"{assemblyName.Name}.Base.{currentMethod.Name}()");

            return assemblyName.Name;
        }
    }
}
