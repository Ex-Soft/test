using System;

namespace TestInheritance
{
    class Base<T>
    {
        public T X { get; set; }
        public T Y { get; set; }

        public Base(T x = default, T y = default)
        {
            Console.WriteLine("Base<T>.ctor(T x=default, T y=default)");

            X = x;
            Y = y;
        }

        public Base(Base<T> obj) : this(obj.X, obj.Y)
        {
            Console.WriteLine("Base<T>.ctor(Base<T> obj)");
        }

        public virtual void Test()
        {
            Console.WriteLine("Base<T>.Test()");
        }

        public override string ToString()
        {
            return $"{{ x: {(X != null ? X.ToString() : "null")}, y: {(Y != null ? Y.ToString() : "null")} }}";
        }
    }
}
