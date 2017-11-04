using System;

namespace TestInheritance
{
    class A
    {
        public int X { get; set; }
        public int Y { get; set; }

        public A(int x = 0, int y = 0)
        {
            Console.WriteLine("A.A(int x=0, int y=0)");

            X = x;
            Y = y;
        }

        public A(A obj) : this(obj.X, obj.Y)
        {
            Console.WriteLine("A.A(A obj)");
        }

        public override string ToString()
        {
            return string.Format("{{ x: {0}, y: {1} }}", X, Y);
        }

        public static bool operator ==(A aL, A aR)
        {
            return aL.X == aR.X && aL.Y == aR.Y;
        }

        public static bool operator !=(A aL, A aR)
        {
            return !(aL == aR);
        }

        public override bool Equals(object obj)
        {
            return this == (A)obj;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
