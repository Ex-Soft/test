//#define TEST_SINGLETON
//#define TEST_SINGLETON_WITH_CTOR
using System;

namespace TestStatic
{
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
			SInt=99;

		static ClassWithStaticConstructorAndStaticMethod()
		{
			Console.WriteLine("static ClassWithStaticConstructorAndStaticMethod()");
		}

        public ClassWithStaticConstructorAndStaticMethod()
		{
            Console.WriteLine("public ClassWithStaticConstructorAndStaticMethod()");
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
            Console.WriteLine("static StaticClassWithStaticConstructorAndStaticMethod()");

            SROInt = 99;
        }

        public static void StaticMethod()
        {
            Console.WriteLine("public StaticMethod");
        }
    }

	class Program
	{
		static void Main(string[] args)
		{
            Console.WriteLine("Starting Main...");

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

            //Console.WriteLine(ClassWithStaticConstructorAndStaticMethod.SInt);
            //ClassWithStaticConstructorAndStaticMethod.StaticMethod();
            //Console.WriteLine();

		    //Console.WriteLine(StaticClassWithStaticConstructorAndStaticMethod.SInt);
            Console.WriteLine(StaticClassWithStaticConstructorAndStaticMethod.SROInt);
            //StaticClassWithStaticConstructorAndStaticMethod.StaticMethod();
		}
	}
}
