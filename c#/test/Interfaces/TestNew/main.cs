using System;
using System.Reflection;

namespace TestNew
{
    interface IA
    {
        int FInt { get; set; }
    }

    interface IB : IA
    {
         new int FInt { get; set; }
    }

    class C : IA, IB
    {
        int IA.FInt { get; set; }
        int IB.FInt { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var c = new C();

            ((IB)c).FInt = 1;

            Foo<IB>(c);
        }

        static void Foo<T>(Object obj) where T : IA
        {
            T tObj = (T)obj;

            /*var t = typeof(T);

            var pis = tObj.GetType().GetProperties(BindingFlags.Instance|BindingFlags.NonPublic|BindingFlags.Public);
            var pi = tObj.GetType().GetProperty(t.FullName+".FInt", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            if (pi != null)
                Console.WriteLine(pi.GetValue(tObj, null));*/

            Console.WriteLine(tObj.FInt);
        }
    }
}
