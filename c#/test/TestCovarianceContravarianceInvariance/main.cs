using System;
using System.Collections.Generic;

namespace TestCovarianceContravarianceInvariance
{
    public class Base
    {
        public string FBase { get; set; }

        public Base(Base obj) : this(obj.FBase)
        {}

        public Base(string fBase = "")
        {
            FBase = fBase;
        }

        public override string ToString()
        {
            return string.Format("{{FBase: \"{0}\"}}", FBase);
        }
    }

    public class Derived : Base
    {
        public string FDerived { get; set; }

        public Derived(Derived obj) : this(obj.FBase, obj.FDerived)
        {}

        public Derived(string fBase = "", string fDerived = "") : base(fBase)
        {
            FDerived = fDerived;
        }

        public override string ToString()
        {
            return string.Format("{{FBase: \"{0}\", FDerived: \"{1}\"}}", FBase, FDerived);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Base.IsAssignableFrom(Derived) (Base = Derived): {0}", typeof(Base).IsAssignableFrom(typeof(Derived))); // true
            Derived tmpDerived = new Derived("tmpDerived");
            Base tmpBase = tmpDerived;

            Console.WriteLine("Derived.IsAssignableFrom(Base) (Derived = Base): {0}", typeof(Derived).IsAssignableFrom(typeof(Base))); // false
            tmpBase = new Base("tmpBase");
            //tmpDerived = tmpBase; // Error	1	Cannot implicitly convert type 'TestCovarianceContravarianceInvariance.Base' to 'TestCovarianceContravarianceInvariance.Derived'. An explicit conversion exists (are you missing a cast?)
            Console.WriteLine("{0}(tmpBase is Derived)", tmpBase is Derived ? string.Empty : "!");
            tmpDerived = tmpBase as Derived; // tmpDerived == null

            try
            {
                tmpDerived = (Derived)tmpBase;
            }
            catch (InvalidCastException eException)
            {
                Console.WriteLine("{0}: \"{1}\"", eException.GetType().Name, eException.Message);
            }

            //Covariance
            IEnumerable<Derived> d = new List<Derived> { new Derived("Derived #1", "Derived #1"), new Derived("Derived #2", "Derived #2"), new Derived("Derived #3", "Derived #3") };
            IEnumerable<Base> b = d;

            foreach (var _b_ in b)
                Console.WriteLine(_b_);

            //Contravariance
            b = new List<Base> { new Base("Base #1"), new Base("Base #2"), new Base("Base #3") };
            //d = b; // Error	1	Cannot implicitly convert type 'System.Collections.Generic.IEnumerable<TestCovarianceContravarianceInvariance.Base>' to 'System.Collections.Generic.IEnumerable<TestCovarianceContravarianceInvariance.Derived>'. An explicit conversion exists (are you missing a cast?)

            Type
                tb = b.GetType(),
                td = d.GetType();

            Console.WriteLine("tb.IsAssignableFrom(td) (tb = td): {0}", tb.IsAssignableFrom(td)); // false
            Console.WriteLine("td.IsAssignableFrom(ta) (td = tb): {0}", td.IsAssignableFrom(tb)); // false
        }
    }
}
