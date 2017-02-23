using System;
using System.Globalization;
using System.Threading;

namespace TestCulture
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Thread.CurrentThread.CurrentCulture: \"{Thread.CurrentThread.CurrentCulture}\"");
            Console.WriteLine($"Thread.CurrentThread.CurrentUICulture: \"{Thread.CurrentThread.CurrentUICulture}\"");
            Console.WriteLine($"CultureInfo.CurrentCulture: \"{CultureInfo.CurrentCulture}\"");
            Console.WriteLine($"CultureInfo.CurrentUICulture: \"{CultureInfo.CurrentUICulture}\"");
            Console.WriteLine($"CultureInfo.DefaultThreadCurrentCulture: \"{CultureInfo.DefaultThreadCurrentCulture}\"");
            Console.WriteLine($"CultureInfo.DefaultThreadCurrentUICulture: \"{CultureInfo.DefaultThreadCurrentUICulture}\"");
            Console.WriteLine($"CultureInfo.InstalledUICulture: \"{CultureInfo.InstalledUICulture}\"");
            Console.WriteLine($"CultureInfo.InvariantCulture: \"{CultureInfo.InvariantCulture}\"");
        }
    }
}
