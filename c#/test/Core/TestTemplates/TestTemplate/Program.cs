using static System.Console;

namespace TestTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine(new Test { Id = 1,
#if (EnableType)
                Type = TestType.Unknown,
#endif
                Name = "Name #1" });
        }
    }
}
