using System;

namespace TestInheritance
{
    class Base<T>
    {
        public T X { get; set; }
        public T Y { get; set; }

        public Base(T x = default(T), T y = default(T))
        {
            Console.WriteLine("Base<T>.Base(T x=default(T), T y=default(T))");

            X = x;
            Y = y;
        }

        public Base(Base<T> obj) : this(obj.X, obj.Y)
        {
            Console.WriteLine("Base<T>.Base(Base<T> obj)");
        }

        public virtual void Test()
        {
            Console.WriteLine("Base<T>.Test()");
        }

        public override string ToString()
        {
            return string.Format("{{ x: {0}, y: {1} }}", X != null ? X.ToString() : "null", Y != null ? Y.ToString() : "null");
        }
    }
}
