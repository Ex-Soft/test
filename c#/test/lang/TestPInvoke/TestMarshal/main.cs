using System;
using System.Runtime.InteropServices;

namespace TestMarshal
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Data
    {
        public int fInt1;
        public int fInt2;
    }

    class Program
    {
        [DllImport("TestDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern void TestData(IntPtr ptr);

        [DllImport("TestDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
        public static extern void TestArrayOfData(IntPtr ptr, int size);

        static void Main(string[] args)
        {
            var data = new Data
            {
                fInt1 = 1,
                fInt2 = 2
            };

            IntPtr ptr = IntPtr.Zero;

            try
            {
                ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Data)));
                Marshal.StructureToPtr(data, ptr, false);
                TestData(ptr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }

            var arrayOfData = new[]
            {
                new Data { fInt1 = 1, fInt2 = 2 },
                new Data { fInt1 = 3, fInt2 = 4 },
                new Data { fInt1 = 5, fInt2 = 6 }
            };
            try
            {
                ptr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Data)) * arrayOfData.Length);

                for (int i = 0; i < arrayOfData.Length; ++i)
                    Marshal.StructureToPtr(arrayOfData[i], ptr + i * Marshal.SizeOf(typeof(Data)), true);

                TestArrayOfData(ptr, arrayOfData.Length);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }
    }
}
