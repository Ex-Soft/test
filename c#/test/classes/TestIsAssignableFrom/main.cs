using System;
using System.Linq;
using System.Reflection;

namespace TestIsAssignableFrom
{
	class A
	{
		public string FieldOfA;
	}

	class AB : A
	{
		public string FieldOfAB;
	}

	class AC : A
	{
		public string FieldOfAC;
	}

	class ABZ : AB
	{
		public string FieldOfABZ;
	}

	class ACZ : AC
	{
		public string FieldOfACZ;
	}

    class Base
    {
        public int FBaseInt { get; set; }
    }

    class Derived : Base
    {
        public int FDerivedInt { get; set; }
    }

    class DerivedII : Derived
    {
        public int FDerivedIIInt { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            A
                a=new A();

            AB
                ab=new AB();

            AC
                ac=new AC();

            ABZ
                abz=new ABZ();

            ACZ
                acz=new ACZ();

            Type
                ta = a.GetType(),
                tab = ab.GetType(),
                tac = ac.GetType(),
                tabz = abz.GetType(),
				tacz = acz.GetType();

			Console.WriteLine("A.IsAssignableFrom(A) (A->A): {0}", ta.IsAssignableFrom(ta)); // true
            Console.WriteLine("A.IsAssignableFrom(AB) (A->AB): {0}", ta.IsAssignableFrom(tab)); // true ab.FieldOfA;
			Console.WriteLine("AB.IsAssignableFrom(A) (AB->A): {0}", tab.IsAssignableFrom(ta)); // false a.FieldOfAB
            Console.WriteLine("AB.IsAssignableFrom(AB) (AB->AB): {0}", tab.IsAssignableFrom(tab)); // true
            Console.WriteLine("A.IsAssignableFrom(AC) (A->AC): {0}", ta.IsAssignableFrom(tac)); // true ac.FieldOfA
			Console.WriteLine("AC.IsAssignableFrom(A) (AC->A): {0}", tac.IsAssignableFrom(ta)); // false a.FieldOfAC
            Console.WriteLine("A.IsAssignableFrom(ABZ) (A->ABZ): {0}", ta.IsAssignableFrom(tabz)); // true abz.FieldOfA
            Console.WriteLine("ABZ.IsAssignableFrom(A) (ABZ->A): {0}", tabz.IsAssignableFrom(ta)); // false a.FieldOfABZ
			Console.WriteLine("A.IsAssignableFrom(ACZ) (A->ACZ): {0}", ta.IsAssignableFrom(tacz)); // true acz.FieldOfA
			Console.WriteLine("ACZ.IsAssignableFrom(A) (ACZ->A): {0}", tacz.IsAssignableFrom(ta)); // false a.FieldOfACZ

            int? nullableInt = 1;
            Console.WriteLine("nullableInt.GetType().IsInstanceOfType(typeof(int)): {0}", nullableInt.GetType().IsInstanceOfType(typeof(int))); // false
            Console.WriteLine("nullableInt.GetType().IsAssignableFrom(typeof(int)): {0}", nullableInt.GetType().IsAssignableFrom(typeof(int))); // true

            DerivedII
                dII = new DerivedII() { FBaseInt = 21, FDerivedInt = 22, FDerivedIIInt = 23 };

            Derived
                d = new Derived() { FBaseInt = 1, FDerivedInt = 2 },
                _d_ = dII;

            Base
                _base_ = d,
                __base__ = dII;

            Console.WriteLine("_base_.GetType().IsAssignableFrom(d.GetType()): {0}", _base_.GetType().IsAssignableFrom(d.GetType())); // true
            Console.WriteLine("d.GetType().IsAssignableFrom(_base_.GetType()): {0}", d.GetType().IsAssignableFrom(_base_.GetType())); // true
            Console.WriteLine("_base_.GetType().IsAssignableFrom(dII.GetType()): {0}", _base_.GetType().IsAssignableFrom(dII.GetType())); // true
            Console.WriteLine("dII.GetType().IsAssignableFrom(_base_.GetType()): {0}", dII.GetType().IsAssignableFrom(_base_.GetType())); // false
            Console.WriteLine("_d_.GetType().IsAssignableFrom(dII.GetType()): {0}", _d_.GetType().IsAssignableFrom(dII.GetType())); // true
            Console.WriteLine("dII.GetType().IsAssignableFrom(_d_.GetType()): {0}", dII.GetType().IsAssignableFrom(_d_.GetType())); // true

            //Derived d2 = _base_; // Error	1	Cannot implicitly convert type 'TestIsAssignableFrom.Base' to 'TestIsAssignableFrom.Derived'. An explicit conversion exists (are you missing a cast?)

	        var assembly = Assembly.GetExecutingAssembly();
	        var type = typeof(A);
	        var typesI = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(p => type.IsAssignableFrom(p)).ToArray();
			var typesII = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(type.IsAssignableFrom).ToArray();

            Console.ReadLine();
        }
    }
}
