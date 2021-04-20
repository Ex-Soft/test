using System;

namespace TestInheritance
{
    class DerivedConcrete : Base<A>
    {
        public A Z { get; set; }

        public DerivedConcrete(A x = default, A y = default, A z = default) : base(x, y)
        {
            Console.WriteLine("DerivedConcrete.ctor(A x=default, A y=default, A z=default)");

            Z = z;
        }

        public DerivedConcrete(DerivedConcrete obj) : this(obj.X, obj.Y, obj.Z)
        {
            Console.WriteLine("DerivedConcrete.ctor(DerivedConcrete obj)");
        }

        public override void Test()
        {
            Console.WriteLine("DerivedConcrete.Test()");
        }

        public override string ToString()
        {
            return $"{{ x: {(X != null ? X.ToString() : "null")}, y: {(Y != null ? Y.ToString() : "null")}, z: {(Z !=null ? Z.ToString() : "null")} }}";
        }
    }
}
