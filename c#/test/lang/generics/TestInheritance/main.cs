using System;

namespace TestInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Base<int>
                bInt1 = new Base<int>(1),
                bInt2 = new Base<int>(bInt1),
                bInt3=bInt2,
                bInt4,
                bIntO;

            Console.WriteLine(bInt1.ToString());

            bInt3.X = bInt3.Y = 3;
            bInt4 = bInt3;

            Base<A>
                bA1 = new Base<A>(new A(1, 0)),
                bA2 = new Base<A>(bA1),
                bA3 = bA2,
                bA4,
                bAO;

            Console.WriteLine(bA1.ToString());

            bA3.X = bA3.Y = new A(3);
            bA4 = bA3;

            Derived<int>
                dInt1 = new Derived<int>(1),
                dInt2 = new Derived<int>(dInt1),
                dInt3 = dInt2,
                dInt4;

            Console.WriteLine(dInt1.ToString());

            dInt3.X = dInt3.Y = dInt3.Z = 3;
            dInt4 = dInt3;

            Derived<A>
                dA1 = new Derived<A>(new A(1, 0)),
                dA2 = new Derived<A>(dA1),
                dA3 = dA2,
                dA4;

            Console.WriteLine(dA1.ToString());

            dA3.X = dA3.Y = dA3.Z = new A(3);
            dA4 = dA3;

            bIntO = dInt1;
            Console.WriteLine(bIntO.ToString());
            bIntO.Test();

            bAO = dA1;
            Console.WriteLine(bAO.ToString());
            bAO.Test();

            Type
                bInt = bInt1.GetType(),
                bA = bA1.GetType(),
                dInt = dInt1.GetType(),
                dA = dA1.GetType();

            Console.WriteLine("Derived<int> is Base<int>: {0}", dInt1 is Base<int>);
            Console.WriteLine("Derived<A> is Base<A>: {0}", dA1 is Base<A>);

            Console.WriteLine("Base<int>.IsAssignableFrom(Derived<int>) (Base<int>->Derived<int>): {0}", bInt.IsAssignableFrom(dInt));
            Console.WriteLine("Derived<int>.IsAssignableFrom(Base<int>) (Derived<int>->Base<int>): {0}", dInt.IsAssignableFrom(bInt));
            Console.WriteLine("Base<A>.IsAssignableFrom(Derived<A>) (Base<A>->Derived<A>): {0}", bA.IsAssignableFrom(dA));
            Console.WriteLine("Derived<A>.IsAssignableFrom(Base<A>) (Derived<A>->Base<A>): {0}", dA.IsAssignableFrom(bA));

            DerivedConcrete derivedConcrete = new DerivedConcrete(new A(100, 100), new A(200, 200), new A(300, 300));
            Type dConcrete = derivedConcrete.GetType();
            Console.WriteLine("Base<A>.IsAssignableFrom(DerivedConcrete) (Base<A>->DerivedConcrete): {0}", bA.IsAssignableFrom(dConcrete)); // true
            Console.WriteLine("DerivedConcrete.IsAssignableFrom(Base<A>) (DerivedConcrete->Base<A>): {0}", dConcrete.IsAssignableFrom(bA)); // false

            Console.WriteLine($"DerivedConcrete is Base<A> {(derivedConcrete is Base<A>)}"); // true
            Console.WriteLine($"Base<A> is DerivedConcrete {(bA1 is DerivedConcrete)}"); // false
            Console.WriteLine($"DerivedConcrete as Base<A> {((bA2 = derivedConcrete as Base<A>) != null ? "!" : "=")}= null"); // !=
            Console.WriteLine($"Base<A> as DerivedConcrete {((derivedConcrete = bA1 as DerivedConcrete) != null ? "!" : "=")}= null"); // ==

            Console.ReadLine();
        }
    }
}
