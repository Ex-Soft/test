using System.Diagnostics;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var libraryBase = new ClassLibrary.Base();

            Debug.WriteLine($"GetExecutingAssemblyName(): \"{libraryBase.GetExecutingAssemblyName()}\"");
            Debug.WriteLine($"GetCallingAssemblyName(): \"{libraryBase.GetCallingAssemblyName()}\"");
            Debug.WriteLine($"GetEntryAssemblyName(): \"{libraryBase.GetEntryAssemblyName()}\"");

            var libraryDerived = new ClassLibrary.Derived();
            Debug.WriteLine($"GetExecutingAssemblyName(): \"{libraryDerived.GetExecutingAssemblyName()}\"");
            Debug.WriteLine($"GetCallingAssemblyName(): \"{libraryDerived.GetCallingAssemblyName()}\"");
            Debug.WriteLine($"GetEntryAssemblyName(): \"{libraryDerived.GetEntryAssemblyName()}\"");

            var derived = new Derived();
            Debug.WriteLine($"GetExecutingAssemblyName(): \"{derived.GetExecutingAssemblyName()}\"");
            Debug.WriteLine($"GetCallingAssemblyName(): \"{derived.GetCallingAssemblyName()}\"");
            Debug.WriteLine($"GetEntryAssemblyName(): \"{derived.GetEntryAssemblyName()}\"");
        }
    }
}
