using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TestComparer
{
    class A
    {
        public int
            X,
            Y;

        public A(int x = default(int), int y = default(int))
        {
            X = x;
            Y = y;
        }

        public A(A obj) : this(obj.X, obj.Y)
        { }

        public override string ToString()
        {
            return $"{{ x: {X}, y: {Y} }}";
        }

        public static IEqualityComparer<A> GetEqualityComparer()
        {
            return new ComparerA();
        }
    }

    class ComparerA : EqualityComparer<A>
    {
        public override bool Equals(A left, A right)
        {
            if (ReferenceEquals(left, right))
                return true;

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                return false;

            return left.X == right.X && left.Y == right.Y;
        }

        public override int GetHashCode(A obj)
        {
            return obj != null ? obj.X.GetHashCode() + obj.Y.GetHashCode() : 0;
        }
    }

    class B : A
    {
        public int
            Z;

        public B(int x = default(int), int y = default(int), int z = default(int)) : base(x, y)
        {
            Z = z;
        }

        public B(B obj) : this(obj.X, obj.Y, obj.Z)
        { }

        public override string ToString()
        {
            return $"{{ x: {X}, y: {Y}, z: {Z} }}";
        }

        public new static IEqualityComparer<B> GetEqualityComparer()
        {
            return new ComparerB();
        }
    }

    class ComparerB : EqualityComparer<B>
    {
        public override bool Equals(B left, B right)
        {
            if (ReferenceEquals(left, right))
                return true;

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                return false;

            return left.X == right.X && left.Y == right.Y && left.Z == right.Z;
        }

        public override int GetHashCode(B obj)
        {
            return obj != null ? obj.X.GetHashCode() + obj.Y.GetHashCode() + obj.Z.GetHashCode() : 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<A>
                listOfAI = new List<A>(new[] { new A(1, 1), new A(2, 2), new A(3, 3), null }),
                listOfAII = new List<A>(new[] { null, new A(4, 4), new A(2, 2), new A(5, 5) }),
                listOfAResult;

            Type
                t = listOfAI.GetType();

            Type[]
                ts;

            MethodInfo
                mi = null;

            if (t.IsGenericType)
            {
                ts = t.GetGenericArguments();
                mi = ts[0].GetMethod("GetEqualityComparer", BindingFlags.Public | BindingFlags.Static);
            }

            if (mi != null)
            {
                IEqualityComparer<A>
                    c = mi.Invoke(null, null) as IEqualityComparer<A>;

                listOfAResult = listOfAI.Intersect(listOfAII, c).ToList();
            }

            List<B>
                listOfBI = new List<B>(new[] { new B(1, 1, 1), new B(2, 2, 2), new B(3, 3, 3), null }),
                listOfBII = new List<B>(new[] { null, new B(4, 4, 4), new B(2, 2, 2), new B(5, 5, 5) }),
                listOfBResult;

            t = listOfBI.GetType();
            if (t.IsGenericType)
            {
                ts = t.GetGenericArguments();
                mi = ts[0].GetMethod("GetEqualityComparer", BindingFlags.Public | BindingFlags.Static);
            }

            if (mi != null)
            {
                IEqualityComparer<B>
                    c = mi.Invoke(null, null) as IEqualityComparer<B>;

                listOfBResult = listOfBI.Intersect(listOfBII, c).ToList();
            }
        }
    }
}
