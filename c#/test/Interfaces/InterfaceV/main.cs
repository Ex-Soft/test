using System;

namespace InterfaceV
{
    interface ISmthInterface
    {
        void SmthMethod();
    }

    class A : ISmthInterface
    {
        public void SmthMethod()
        {
            Console.WriteLine("A.SmthMethod()");
        }
    }

    class B : A
    {
        public void SmthMethod()
        {
            Console.WriteLine("B.SmthMethod()");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ISmthInterface[] smthInterfaces  = { new A(), new B() };
            foreach (var smthInterface in smthInterfaces)
            {
                smthInterface.SmthMethod();
            }
        }
    }
}
