using static System.Console;

namespace TestCSharpSyntaxTree
{
    public static class Runner
    {
        public static void Run(IVictim victim)
        {
            switch (victim)
            {
                case Victim1 victim1:
                {
                    victim1.Foo1();
                    break;
                }
                case Victim2 victim2:
                {
                    victim2.Foo1();
                    break;
                }
                default:
                {
                    WriteLine($"Unknown type: \"{victim.GetType().Name}\"");
                    break;
                }
            }
        }
    }
}
