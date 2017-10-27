using System;

namespace InterfaceVI
{
    class A
    {
        public void ToDo()
        {
            Console.WriteLine("A.ToDo()");
        }
    }

    interface II
    {
        void ToDo();
    }

    class B : A, II
    {
    }

    class C : A, II
    {
        public void ToDo()
        {
            Console.WriteLine("C.ToDo()");
        }
    }

    class D : A, II
    {
        public void ToDo()
        {
            base.ToDo();
            Console.WriteLine("D.ToDo()");
        }
    }

    class E : A, II
    {
        public new void ToDo()
        {
            Console.WriteLine("E.ToDo()");
        }
    }

    class F : A, II
    {
        public new void ToDo()
        {
            base.ToDo();
            Console.WriteLine("F.ToDo()");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            C c = new C();
            D d = new D();
            E e = new E();
            F f = new F();

            Console.WriteLine("A.ToDo()");
            a.ToDo();
            Console.WriteLine();

            Console.WriteLine("B.ToDo()");
            b.ToDo();
            Console.WriteLine();

            Console.WriteLine("C.ToDo()");
            c.ToDo();
            Console.WriteLine();

            Console.WriteLine("D.ToDo()");
            d.ToDo();
            Console.WriteLine();

            Console.WriteLine("E.ToDo()");
            e.ToDo();
            Console.WriteLine();

            Console.WriteLine("F.ToDo()");
            f.ToDo();
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
