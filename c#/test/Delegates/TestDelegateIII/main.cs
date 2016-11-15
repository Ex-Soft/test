using System;

namespace TestDelegateIII
{
    delegate void VoidDelegate();

    class TestClassWithDelegate
    {
        public VoidDelegate SmthDelegate;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var a = new TestClassWithDelegate();

            a.SmthDelegate -= Foo1; // Delegate subtraction has unpredictable result.

            a.SmthDelegate += Foo1;
            a.SmthDelegate();
            Console.WriteLine(new string('-', 30));

            a.SmthDelegate += Foo1;
            a.SmthDelegate();
            Console.WriteLine(new string('-', 30));

            a.SmthDelegate += Foo2;
            a.SmthDelegate();
            Console.WriteLine(new string('-', 30));

            a.SmthDelegate += Foo2;
            a.SmthDelegate();
            Console.WriteLine(new string('-', 30));

            Console.ReadLine();
        }

        static void Foo1()
        {
            Console.WriteLine("Foo1()");
        }

        static void Foo2()
        {
            Console.WriteLine("Foo2()");
        }
    }
}
