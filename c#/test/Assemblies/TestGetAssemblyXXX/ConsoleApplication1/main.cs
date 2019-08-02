using System.Diagnostics;
using static System.Console;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string msg;
            var libraryBase = new ClassLibrary1.Base();

            WriteLine(msg = $"GetExecutingAssemblyName(): \"{libraryBase.GetExecutingAssemblyName()}\"");
            Debug.WriteLine(msg);
            WriteLine(msg = $"GetCallingAssemblyName(): \"{libraryBase.GetCallingAssemblyName()}\"");
            Debug.WriteLine(msg);
            WriteLine(msg = $"GetEntryAssemblyName(): \"{libraryBase.GetEntryAssemblyName()}\"");
            Debug.WriteLine(msg);
            WriteLine();

            WriteLine(msg = $"GetExecutingAssemblyName(): \"{libraryBase.Library2GetExecutingAssemblyName()}\"");
            Debug.WriteLine(msg);
            WriteLine(msg = $"GetCallingAssemblyName(): \"{libraryBase.Library2GetCallingAssemblyName()}\"");
            Debug.WriteLine(msg);
            WriteLine(msg = $"GetEntryAssemblyName(): \"{libraryBase.Library2GetEntryAssemblyName()}\"");
            Debug.WriteLine(msg);
            WriteLine();

            var libraryDerived = new ClassLibrary1.Derived();
            WriteLine(msg = $"GetExecutingAssemblyName(): \"{libraryDerived.GetExecutingAssemblyName()}\"");
            Debug.WriteLine(msg);
            WriteLine(msg = $"GetCallingAssemblyName(): \"{libraryDerived.GetCallingAssemblyName()}\"");
            Debug.WriteLine(msg);
            WriteLine(msg = $"GetEntryAssemblyName(): \"{libraryDerived.GetEntryAssemblyName()}\"");
            Debug.WriteLine(msg);
            WriteLine();

            var derived = new Derived();
            WriteLine(msg = $"GetExecutingAssemblyName(): \"{derived.GetExecutingAssemblyName()}\"");
            Debug.WriteLine(msg);
            WriteLine(msg = $"GetCallingAssemblyName(): \"{derived.GetCallingAssemblyName()}\"");
            Debug.WriteLine(msg);
            WriteLine(msg = $"GetEntryAssemblyName(): \"{derived.GetEntryAssemblyName()}\"");
            Debug.WriteLine(msg);
            WriteLine();

            ReadKey();
        }
    }
}
