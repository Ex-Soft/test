// http://csharpindepth.com/Articles/General/Singleton.aspx

using System;
using System.Diagnostics;
using System.Reflection;

using static System.Console;

namespace Singleton6
{
    // Bad code! Do not use!
    public sealed class Singleton1
    {
        private static Singleton1 instance = null;

        private Singleton1()
        {}

        public static Singleton1 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton1();
                }
                return instance;
            }
        }
    }

    public sealed class Singleton2
    {
        private static Singleton2 instance = null;
        private static readonly object padlock = new object();

        Singleton2()
        {}

        public static Singleton2 Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Singleton2();
                    }
                    return instance;
                }
            }
        }
    }

    // Bad code! Do not use!
    public sealed class Singleton3
    {
        private static Singleton3 instance = null;
        private static readonly object padlock = new object();

        Singleton3()
        {}

        public static Singleton3 Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new Singleton3();
                        }
                    }
                }
                return instance;
            }
        }
    }

    public sealed class Singleton4
    {
        private static readonly Singleton4 instance = new Singleton4();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Singleton4()
        {
            Debug.WriteLine($"static {MethodBase.GetCurrentMethod().Name}");
        }

        private Singleton4()
        {
            Debug.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        public static Singleton4 Instance
        {
            get
            {
                return instance;
            }
        }

        public void Foo()
        {
            var msg = $"Singleton4.{MethodBase.GetCurrentMethod().Name}";
            WriteLine(msg);
            Debug.WriteLine(msg);
        }
    }

    public sealed class Singleton5
    {
        private Singleton5()
        {}

        public static Singleton5 Instance { get { return Nested.instance; } }

        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {}

            internal static readonly Singleton5 instance = new Singleton5();
        }
    }

    public sealed class Singleton6
    {
        private static readonly Lazy<Singleton6> lazy = new Lazy<Singleton6>(() => new Singleton6());

        public static Singleton6 Instance { get { return lazy.Value; } }

        private Singleton6()
        {
            Debug.WriteLine(MethodBase.GetCurrentMethod().Name);
        }

        public void Foo()
        {
            var msg = $"Singleton6.{MethodBase.GetCurrentMethod().Name}";
            WriteLine(msg);
            Debug.WriteLine(msg);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Singleton4.Instance.Foo();

            Singleton6.Instance.Foo();
        }
    }
}
