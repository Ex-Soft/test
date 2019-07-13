using System.Diagnostics;
using System.Reflection;
using System.Threading;

using static System.Console;

namespace TestDotTrace
{
    class Program
    {
        private const int Max = 5;

        static void Main(string[] args)
        {
            double coeff = 1;

            if (args.Length > 0)
                double.TryParse(args[0], out coeff);

            for (var i = 0; i < Max; ++i)
                Foo((int)(i * coeff));
        }

        private static void Foo(int sleep)
        {
            string msg;
            WriteLine(msg = $"{MethodBase.GetCurrentMethod().Name}({sleep}) start....");
            Debug.WriteLine(msg);
            Thread.Sleep(sleep * 1000);
            WriteLine(msg = $"{MethodBase.GetCurrentMethod().Name}({sleep}) finished");
            Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}({sleep}) finished");
        }
    }
}
