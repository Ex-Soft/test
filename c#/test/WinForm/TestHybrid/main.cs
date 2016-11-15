//http://stackoverflow.com/questions/5711291/get-the-handle-and-write-to-the-console-that-launched-our-process
//hackalicious http://stackoverflow.com/questions/1305257/using-attachconsole-user-must-hit-enter-to-get-regular-command-line/2463039#2463039
//http://www.csharp411.com/console-output-from-winforms-application/
 
﻿//#define WITH_ATTACH
#define WITH_ATTACH_ADVANCED

using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Win32.SafeHandles;

namespace TestHybrid
{
    static class Program
    {
        static IntPtr _consoleWindow;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            _consoleWindow = GetForegroundWindow();

            int returnValue;

            if (args.Length > 0)
            {
                #if WITH_ATTACH
                    returnValue = AllocateConsole();
                #elif WITH_ATTACH_ADVANCED
                    InitConsoleHandles();
                    Console.WriteLine("blah-blah-blah");
                    returnValue = 0;
                #else
                    if (AllocConsole())
                        {
                            returnValue = Marshal.GetLastWin32Error();
                            Console.WriteLine("TestTestHybrid");
                            Console.ReadLine();
                        }
                        else
                            returnValue = Marshal.GetLastWin32Error();
                #endif
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());

                returnValue = 0;
            }

            return returnValue;
        }

        const uint ATTACH_PARENT_PROCESS = 0x0ffffffff;
        const int ERROR_ACCESS_DENIED = 5;
        const int ERROR_INVALID_HANDLE = 6;
        const int ERROR_GEN_FAILURE = 31;
        const int ERROR_INVALID_PARAMETER = 87;

        [DllImport("kernel32.dll", SetLastError=true)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern bool FreeConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AttachConsole(uint dwProcessId);
        
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        static int AllocateConsole()
        {
            bool result = AttachConsole(ATTACH_PARENT_PROCESS);
            int lastError = Marshal.GetLastWin32Error();

            if (!result)
            {
                if (!AllocConsole())
                {
                    lastError = Marshal.GetLastWin32Error();
                    string msg = string.Format("Console Allocation Failed. A console could not be attached && allocated, sorry! (GetLastWin32Error()={0})", lastError);
                    MessageBox.Show(msg);
                    throw new Exception(msg);
                }
                else
                {
                    Console.WriteLine("!AttachConsole() lastError={0}", lastError);
                    Console.WriteLine("Is Allocated, press a key...");
                    Console.ReadLine();

                    result = FreeConsole();
                    lastError = Marshal.GetLastWin32Error();
                    if (!result)
                        throw new Exception(lastError.ToString());
                }
            }
            else
            {
                Console.WriteLine("AttachConsole()");

                Thread.Sleep(5000);

                SetForegroundWindow(_consoleWindow);
                SendKeys.SendWait("{ENTER}");

                result = FreeConsole();
                lastError = Marshal.GetLastWin32Error();
                
                if (!result)
                   throw new Exception(lastError.ToString());
              }

            return lastError;
        }

        struct BY_HANDLE_FILE_INFORMATION
        {
            public UInt32 FileAttributes;
            public System.Runtime.InteropServices.ComTypes.FILETIME CreationTime;
            public System.Runtime.InteropServices.ComTypes.FILETIME LastAccessTime;
            public System.Runtime.InteropServices.ComTypes.FILETIME LastWriteTime;
            public UInt32 VolumeSerialNumber;
            public UInt32 FileSizeHigh;
            public UInt32 FileSizeLow;
            public UInt32 NumberOfLinks;
            public UInt32 FileIndexHigh;
            public UInt32 FileIndexLow;
        }

        [DllImport("kernel32.dll")]
        static extern bool GetFileInformationByHandle(SafeFileHandle hFile, out BY_HANDLE_FILE_INFORMATION lpFileInformation);

        [DllImport("kernel32.dll")]
        static extern SafeFileHandle GetStdHandle(UInt32 nStdHandle);

        [DllImport("kernel32.dll")]
        static extern bool SetStdHandle(UInt32 nStdHandle, SafeFileHandle hHandle);

        [DllImport("kernel32.dll")]
        static extern bool DuplicateHandle(IntPtr hSourceProcessHandle, SafeFileHandle hSourceHandle, IntPtr hTargetProcessHandle, out SafeFileHandle lpTargetHandle, UInt32 dwDesiredAccess, Boolean bInheritHandle, UInt32 dwOptions);
        
        const UInt32 STD_OUTPUT_HANDLE = 0xFFFFFFF5;
        const UInt32 STD_ERROR_HANDLE = 0xFFFFFFF4;
        const UInt32 DUPLICATE_SAME_ACCESS = 2;

        static void InitConsoleHandles()
        {
            SafeFileHandle hStdOut, hStdErr, hStdOutDup, hStdErrDup;
            BY_HANDLE_FILE_INFORMATION bhfi;

            hStdOut = GetStdHandle(STD_OUTPUT_HANDLE);
            hStdErr = GetStdHandle(STD_ERROR_HANDLE);

            // Get current process handle
            IntPtr hProcess = Process.GetCurrentProcess().Handle;

            // Duplicate Stdout handle to save initial value
            DuplicateHandle(hProcess, hStdOut, hProcess, out hStdOutDup,
            0, true, DUPLICATE_SAME_ACCESS);

            // Duplicate Stderr handle to save initial value
            DuplicateHandle(hProcess, hStdErr, hProcess, out hStdErrDup,
            0, true, DUPLICATE_SAME_ACCESS);

            // Attach to console window – this may modify the standard handles
            AttachConsole(ATTACH_PARENT_PROCESS);

            // Adjust the standard handles
            if (GetFileInformationByHandle(GetStdHandle(STD_OUTPUT_HANDLE), out bhfi))
            {
                SetStdHandle(STD_OUTPUT_HANDLE, hStdOutDup);
            }
            else
            {
                SetStdHandle(STD_OUTPUT_HANDLE, hStdOut);
            }

            if (GetFileInformationByHandle(GetStdHandle(STD_ERROR_HANDLE), out bhfi))
            {
                SetStdHandle(STD_ERROR_HANDLE, hStdErrDup);
            }
            else
            {
                SetStdHandle(STD_ERROR_HANDLE, hStdErr);
            }
        }
    }
}
