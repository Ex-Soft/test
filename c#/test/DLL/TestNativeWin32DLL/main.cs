using System;
using System.IO;
using System.Runtime.InteropServices;

namespace TestNativeWin32DLL
{
    class Program
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int Add(int left, int right);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate bool Copy(byte[] to, byte[] from, ulong len);

        static void Main(string[] args)
        {
            string dllFileName;

            if (!File.Exists(dllFileName = Path.Combine(Directory.GetCurrentDirectory(), "TestDLL.dll")))
                return;

            uint lastError;
            int errorCode;
            bool result;

            IntPtr pDll = NativeMethods.LoadLibrary(dllFileName);

            if (pDll == IntPtr.Zero)
            {
                errorCode = Marshal.GetLastWin32Error();
                lastError = NativeMethods.GetLastError();
                return;
            }

            IntPtr pAddressOfFunctionToCall = NativeMethods.GetProcAddress(pDll, "Add");

            if (pAddressOfFunctionToCall == IntPtr.Zero)
            {
                errorCode = Marshal.GetLastWin32Error();
                lastError = NativeMethods.GetLastError();

                if (pDll != IntPtr.Zero)
                    result = NativeMethods.FreeLibrary(pDll);

                return;
            }

            Add add = (Add)Marshal.GetDelegateForFunctionPointer(pAddressOfFunctionToCall, typeof(Add));

            int resultOfAdd = add(1, 2);

            pAddressOfFunctionToCall = NativeMethods.GetProcAddress(pDll, "Copy");

            if (pAddressOfFunctionToCall == IntPtr.Zero)
            {
                errorCode = Marshal.GetLastWin32Error();
                lastError = NativeMethods.GetLastError();

                if (pDll != IntPtr.Zero)
                    result = NativeMethods.FreeLibrary(pDll);

                return;
            }

            byte[]
                from = { 65, 66, 67, 68, 69 },
                to = new byte[5];

            Copy copy = (Copy)Marshal.GetDelegateForFunctionPointer(pAddressOfFunctionToCall, typeof(Copy));

            bool resultOfCopy = copy(from, to, 5L);

            if (pDll != IntPtr.Zero)
                result = NativeMethods.FreeLibrary(pDll);
        }

        static class NativeMethods
        {
            [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Ansi)]
            public static extern IntPtr LoadLibrary([MarshalAs(UnmanagedType.LPStr)]string lpFileName);

            [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
            public static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

            [DllImport("kernel32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)] /* unnecessary, isn't it? */
            public static extern bool FreeLibrary(IntPtr hModule);

            [DllImport("kernel32.dll")]
            public static extern uint GetLastError();
        }
    }
}
