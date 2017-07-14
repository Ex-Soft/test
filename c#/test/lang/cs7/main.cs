// https://blogs.msdn.microsoft.com/dotnet/2017/03/09/new-features-in-c-7-0/
// https://www.erikheemskerk.nl/csharp-7-0-improvements/

using static System.Console;

namespace cs7
{
    class Program
    {
        static void Main(string[] args)
        {
            MethodWithOutParameters(out int x, out int y);
            WriteLine($"({x}, {y})");
        }

        static void MethodWithOutParameters(out int x, out int y)
        {
            x = 1;
            y = 2;
        }
    }
}
