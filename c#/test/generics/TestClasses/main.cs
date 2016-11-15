using System;
using System.Collections.Generic;

namespace TestClasses
{
    class A
    { }

    class BA : A
    { }

    class CA : A
    { }

    class D
    { }

    class Container<T>
    {
        List<T> container;

        public Container()
        {
            container = new List<T>();
        }

        public Container(T obj) : this()
        {
            container.Add(obj);
        }
    }


    class ContainerWithConstraints<T> where T : A
    {
        List<T> container;

        public ContainerWithConstraints()
        {
            container = new List<T>(); 
        }

        public ContainerWithConstraints(T obj) : this()
        {
            container.Add(obj);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            A
                a = new A();

            Container<A>
                cA1 = new Container<A>(),
                cA2 = new Container<A>(a);

            Container<BA>
                cBA = new Container<BA>();

            Container<CA>
                cCA = new Container<CA>();

            Container<D>
                d = new Container<D>();

            /*
            ContainerWithConstraints<D>
                dWithError = new ContainerWithConstraints<D>();
            
            // The type 'TestClasses.D' cannot be used as type parameter 'T' in the generic type or method 'TestClasses.ContainerWithConstraints<T>'. There is no implicit reference conversion from 'TestClasses.D' to 'TestClasses.A'.
            */
        }
    }
}
