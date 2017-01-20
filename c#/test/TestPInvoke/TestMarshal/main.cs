// https://msdn.microsoft.com/en-us/library/2zhzfk83(v=vs.110).aspx

using System;
using System.Runtime.InteropServices;

namespace TestMarshal
{
    public struct Point
    {
        public int x;
        public int y;

        public Point(Point obj) : this(obj.x, obj.y)
        {}

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a point struct.
            Point p;
            p.x = 0x7fffeeee;
            p.y = 0x7aaabbbb;

            Console.WriteLine("The value of first point is " + p.x + " and " + p.y + ".");

            // Initialize unmanged memory to hold the struct.
            IntPtr pnt = Marshal.AllocHGlobal(Marshal.SizeOf(p));

            try
            {

                // Copy the struct to unmanaged memory.
                Marshal.StructureToPtr(p, pnt, false);

                // Create another point.
                Point anotherP;

                // Set this Point to the value of the 
                // Point in unmanaged memory. 
                anotherP = (Point)Marshal.PtrToStructure(pnt, typeof(Point));

                Console.WriteLine("The value of new point is " + anotherP.x + " and " + anotherP.y + ".");

                int tmpInt = Marshal.ReadInt32(pnt);
                long tmpLong = Marshal.ReadInt64(pnt);
            }
            finally
            {
                // Free the unmanaged memory.
                Marshal.FreeHGlobal(pnt);
            }

            var arrayOfPoint = new[] { new Point(1, 1), new Point(2, 2), new Point(3, 3) };
            IntPtr ptrArrayOfPoint = IntPtr.Zero;

            try
            {
                ptrArrayOfPoint = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Point)) * arrayOfPoint.Length);

                for (var i = 0; i < arrayOfPoint.Length; ++i)
                {
                    Marshal.StructureToPtr(arrayOfPoint[i], ptrArrayOfPoint + i * Marshal.SizeOf(typeof(Point)), false);

                    var tmpPoint = (Point)Marshal.PtrToStructure(ptrArrayOfPoint + i * Marshal.SizeOf(typeof(Point)), typeof(Point));
                    Console.WriteLine("{{x={0},y={1}}}", tmpPoint.x, tmpPoint.y);
                }
            }
            finally
            {
                if (ptrArrayOfPoint != IntPtr.Zero)
                    Marshal.FreeHGlobal(ptrArrayOfPoint);
            }
        }
    }
}
