using System;

namespace TestInheritance
{
    class Derived<T> : Base<T>
    {
        public T Z { get; set; }

        public Derived(T x = default(T), T y = default(T), T z = default(T)) : base(x, y)
        {
            Console.WriteLine("Base<T>.Base(T x=default(T), T y=default(T), T z=default(T))");

            Z = z;
        }

        public Derived(Derived<T> obj) : this(obj.X, obj.Y, obj.Z)
        {
            Console.WriteLine("Base<T>.Base(Base<T> obj)");
        }

        public override void Test()
        {
            Console.WriteLine("Derived<T>.Test()");
        }

        public override string ToString()
        {
            return string.Format("{{ x: {0}, y: {1}, z: {2} }}", X != null ? X.ToString() : "null", Y != null ? Y.ToString() : "null", Z != null ? Z.ToString() : "null");
        }
    }
}
