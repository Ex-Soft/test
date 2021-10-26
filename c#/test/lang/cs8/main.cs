using System;
using System.Reflection;

using static System.Console;

namespace cs8
{
    // https://jeremybytes.blogspot.com/2019/11/c-8-interfaces-public-private-and.html
    public interface IInterfaceWithAccessModifiers
    {
        void FooPublic();
        
        private string StringEmpty
        {
            get
            {
                WriteLine($"{MethodBase.GetCurrentMethod().Name}()");
                return string.Empty;
            }
        }

        string GetStringEmpty
        {
            get
            {
                WriteLine($"{MethodBase.GetCurrentMethod().Name}()");
                return StringEmpty;
            }
        }

        protected string FooProtected1()
        {
            WriteLine($"{MethodBase.GetCurrentMethod().Name}()");
            return StringEmpty;
        }

        protected string FooProtected2();

        string FooProtectedCaller()
        {
            FooProtected1();
            FooProtected2();
            return StringEmpty;
        }
    }

    public class SmthClass1 : IInterfaceWithAccessModifiers
    {
        public void FooPublic()
        {
            WriteLine($"{MethodBase.GetCurrentMethod().Name}()");
            
            //WriteLine($"StringEmpty=\"{StringEmpty}\""); // Error CS0103 The name 'StringEmpty' does not exist in the current context
            //WriteLine($"GetStringEmpty=\"{GetStringEmpty}\""); // Error CS0103 The name 'GetStringEmpty' does not exist in the current context
            
            //WriteLine($"StringEmpty=\"{((IInterfaceWithAccessModifiers)this).StringEmpty}\""); // Error CS0122 'IInterfaceWithAccessModifiers.StringEmpty' is inaccessible due to its protection level
            WriteLine($"GetStringEmpty=\"{((IInterfaceWithAccessModifiers)this).GetStringEmpty}\"");
        }

        string IInterfaceWithAccessModifiers.FooProtected2()
        {
            WriteLine($"{MethodBase.GetCurrentMethod().Name}()");
            return ((IInterfaceWithAccessModifiers)this).GetStringEmpty;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int? tmpInt = null;
            tmpInt ??= 13;
            tmpInt ??= 169;

            var smthClass1 = new SmthClass1();
            smthClass1.FooPublic();
            ((IInterfaceWithAccessModifiers)smthClass1).FooProtectedCaller();
        }
    }
}
