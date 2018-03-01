// https://www.codeproject.com/Articles/1021335/Top-Underutilized-Features-of-NET

using System;

namespace TestCurrying
{
    public static class CurryMethodExtensions
    {
        public static Func<A, Func<B, Func<C, R>>> Curry<A, B, C, R>(this Func<A, B, C, R> f)
        {
            return a => b => c => f(a, b, c);
        }

        public static Func<C, R> Partial<A, B, C, R>(this Func<A, B, C, R> f, A a, B b)
        {
            return c => f(a, b, c);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int, int> addNumbers = (x, y, z) => x + y + z;
            var f1 = addNumbers.Curry();
            Func<int, Func<int, int>> f2 = f1(3);
            Func<int, int> f3 = f2(4);
            Console.WriteLine(f3(5));

            Func<int, int, int, int> sumNumbers = (x, y, z) => x + y + z;
            Func<int, int> f4 = sumNumbers.Partial(3, 4);
            Console.WriteLine(f4(5));
        }
    }
}
