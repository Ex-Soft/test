//#define TEST_ALLOCATION
//#define TEST_SINGLETON
//#define TEST_SINGLETON_WITH_CTOR

using System;
using System.Runtime.InteropServices;

using static System.Console;

namespace TestStatic
{
    #if TEST_ALLOCATION
        internal delegate void DelegateFoo();

        public class Victim
        {
            public void PrintMethodAddress()
            {
                Action action = Foo;
                action();

                DelegateFoo delegateFoo = Foo;
                IntPtr p = Marshal.GetFunctionPointerForDelegate(delegateFoo);
                Console.WriteLine(p.ToString("x"));
                delegateFoo();

                delegateFoo = Marshal.GetDelegateForFunctionPointer<DelegateFoo>(p);
                delegateFoo();
            }
            
            public void PrintStaticMethodAddress()
            {
                Action action = StaticFoo;
                action();

                DelegateFoo delegateFoo = StaticFoo;
                IntPtr p = Marshal.GetFunctionPointerForDelegate(delegateFoo);
                Console.WriteLine(p.ToString("x"));
                delegateFoo();

                delegateFoo = Marshal.GetDelegateForFunctionPointer<DelegateFoo>(p);
                delegateFoo();
            }

            public void Foo()
            {
                unsafe
                {
                    int i;
                    int* ptr = &i;
                    Console.WriteLine(((int)ptr).ToString("x"));
                }
            }

            public static void StaticFoo()
            {
                unsafe
                {
                    int i;
                    int* ptr = &i;
                    Console.WriteLine(((int)ptr).ToString("x"));
                }
            }
        }
    #endif

    public class Singleton
    {
        private static Singleton instance;

        private string FString;

        private Singleton()
        {
            Console.WriteLine("Singleton.cctor()");
        }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }

        public void SetFString(string val)
        {
            Console.WriteLine("Singleton.SetFString(\"{0}\")", val);
            instance.FString = val;
        }

        public string GetFString()
        {
            Console.WriteLine("Singleton.GetFString()");
            return instance.FString;
        }
    }

    #if TEST_SINGLETON
        public class Singleton
        {
            #if TEST_SINGLETON_WITH_CTOR
                static Singleton()
                {
                    Console.WriteLine(".cctor");
                }
            #endif

            public static string
                S = Echo("Field initializer");

            public static string Echo(string s)
            {
                Console.WriteLine(s);
                return s;
            }

        }
    #endif

	public class ClassWithStaticConstructorAndStaticMethod
	{
		public static int
			SInt = 99;

		static ClassWithStaticConstructorAndStaticMethod()
		{
			WriteLine("static ClassWithStaticConstructorAndStaticMethod()");
            WriteLine($"SInt={SInt}"); // 99
        }

        public ClassWithStaticConstructorAndStaticMethod()
		{
            WriteLine("public ClassWithStaticConstructorAndStaticMethod()");
        }

		public static void StaticMethod()
		{
			Console.WriteLine("public StaticMethod");
		}
	}

    public static class StaticClassWithStaticConstructorAndStaticMethod
    {
        public static readonly int
            SROInt;

        public static int
            SInt = 99;

        static StaticClassWithStaticConstructorAndStaticMethod()
        {
            WriteLine("static StaticClassWithStaticConstructorAndStaticMethod()");
            WriteLine($"SInt={SInt}"); // 99
            WriteLine($"SROInt={SROInt}"); // 0
            SROInt = 99;
        }

        public static void StaticMethod()
        {
            WriteLine("public StaticMethod");
        }
    }

	class Program
	{
		static void Main(string[] args)
		{
            Console.WriteLine("Starting Main...");

            #if TEST_ALLOCATION
                Victim
                    victim1 = new Victim(),
                    victim2 = new Victim();

                victim1.PrintMethodAddress();
                victim2.PrintMethodAddress();
                Console.WriteLine();

                victim1.PrintStaticMethodAddress();
                victim2.PrintStaticMethodAddress();
                Console.WriteLine();
            #endif

            Singleton.Instance.SetFString("blah-blah-blah");
            Console.WriteLine(Singleton.Instance.GetFString());
            Singleton.Instance.SetFString("halb-halb-halb");
            Console.WriteLine(Singleton.Instance.GetFString());

            #if TEST_SINGLETON
                if (args.Length == 1)
                {
                    Console.WriteLine(Singleton.S);
                }
            #endif

            WriteLine(ClassWithStaticConstructorAndStaticMethod.SInt);
            //ClassWithStaticConstructorAndStaticMethod.StaticMethod();
            //Console.WriteLine();

		    //Console.WriteLine(StaticClassWithStaticConstructorAndStaticMethod.SInt);
            WriteLine(StaticClassWithStaticConstructorAndStaticMethod.SROInt);
            //StaticClassWithStaticConstructorAndStaticMethod.StaticMethod();
		}
	}
}
