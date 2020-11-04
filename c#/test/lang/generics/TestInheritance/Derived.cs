using System;

namespace TestInheritance
{
    class Derived<T> : Base<T>
    {
        public T Z { get; set; }

        public Derived(T x = default, T y = default, T z = default) : base(x, y)
        {
            Console.WriteLine("Derived<T>.ctor(T x=default, T y=default, T z=default)");

            Z = z;
        }

        public Derived(Derived<T> obj) : this(obj.X, obj.Y, obj.Z)
        {
            Console.WriteLine("Derived<T>.ctor(Derived<T> obj)");
        }

        public override void Test()
        {
            Console.WriteLine("Derived<T>.Test()");
        }

        public override string ToString()
        {
            return $"{{ x: {(X != null ? X.ToString() : "null")}, y: {(Y != null ? Y.ToString() : "null")}, z: {(Z != null ? Z.ToString() : "null")} }}";
        }
    }
}
