using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ClassLibrary1
{
    public class Base
    {
        readonly ClassLibrary2.Base _classLibrary2Base;

        public Base()
        {
            _classLibrary2Base = new ClassLibrary2.Base();
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
        public virtual string Library2GetExecutingAssemblyName()
        {
            return _classLibrary2Base.Library3GetExecutingAssemblyName();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public virtual string Library2GetCallingAssemblyName()
        {
            return _classLibrary2Base.Library3GetCallingAssemblyName();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public virtual string Library2GetEntryAssemblyName()
        {
            return _classLibrary2Base.Library3GetEntryAssemblyName();
        }
    }
}
