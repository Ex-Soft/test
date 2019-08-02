using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ClassLibrary2
{
    public class Base
    {
        readonly ClassLibrary3.Base _classLibrary3Base;

        public Base()
        {
            _classLibrary3Base = new ClassLibrary3.Base();
        }

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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public virtual string Library3GetExecutingAssemblyName()
        {
            return _classLibrary3Base.GetExecutingAssemblyName();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public virtual string Library3GetCallingAssemblyName()
        {
            return _classLibrary3Base.GetCallingAssemblyName();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public virtual string Library3GetEntryAssemblyName()
        {
            return _classLibrary3Base.GetEntryAssemblyName();
        }
    }
}
