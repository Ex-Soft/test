using System;

namespace TestFuncIL
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> funcIntInt;

            funcIntInt = Foo;

            funcIntInt(1);

            funcIntInt = null;
        }

        static int Foo(int p)
        {
            return p * 2;
        }
    }
}
