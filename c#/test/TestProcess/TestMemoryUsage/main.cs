using System;
using System.Diagnostics;
using System.IO;

namespace TestMemoryUsage
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = args.Length != 0 && !string.IsNullOrEmpty(args[0])
                ? args[0]
                //: "NotePad.exe";
                : "D:\\WorkSpaces\\CHICAGO\\DEV\\client\\src\\ch2_client\\bin\\Debug\\Client.exe";

            if (!File.Exists(fileName))
            {
                Console.WriteLine("\"{0}\" doesn't exist", fileName);
                return;
            }

            // Define variables to track the peak
            // memory usage of the process.
            long
                peakPagedMem = 0,
                peakWorkingSet = 0,
                peakVirtualMem = 0;

            Process myProcess = null;

            try
            {
                // Start the process.
                myProcess = Process.Start(fileName);

                // Display the process statistics until
                // the user closes the program.
                do
                {
                    if (!myProcess.HasExited)
                    {
                        // Refresh the current process property values.
                        myProcess.Refresh();

                        Console.WriteLine();

                        // Display current process statistics.

                        Console.WriteLine("{0} -", myProcess.ToString());
                        Console.WriteLine("-------------------------------------");

                        Console.WriteLine("  physical memory usage: {0:###,###,###,###} ({1}MB)", myProcess.WorkingSet64, myProcess.WorkingSet64 / (1024 * 1024));
                        Console.WriteLine("  PrivateMemorySize64: {0:###,###,###,###} ({1}MB)", myProcess.PrivateMemorySize64, myProcess.PrivateMemorySize64 / (1024 * 1024));
                        Console.WriteLine("  VirtualMemorySize64: {0:###,###,###,###} ({1}MB)", myProcess.VirtualMemorySize64, myProcess.VirtualMemorySize64 / (1024 * 1024));
                        Console.WriteLine("  base priority: {0}", myProcess.BasePriority);
                        Console.WriteLine("  priority class: {0}", myProcess.PriorityClass);
                        Console.WriteLine("  user processor time: {0}", myProcess.UserProcessorTime);
                        Console.WriteLine("  privileged processor time: {0}", myProcess.PrivilegedProcessorTime);
                        Console.WriteLine("  total processor time: {0}", myProcess.TotalProcessorTime);
                        Console.WriteLine("  PagedSystemMemorySize64: {0:###,###,###,###} ({1}MB)", myProcess.PagedSystemMemorySize64, myProcess.PagedSystemMemorySize64 / (1024 * 1024));
                        Console.WriteLine("  PagedMemorySize64: {0:###,###,###,###} ({1}MB)", myProcess.PagedMemorySize64, myProcess.PagedMemorySize64 / (1024 * 1024));

                        // Update the values for the overall peak memory statistics.
                        peakPagedMem = myProcess.PeakPagedMemorySize64;
                        peakVirtualMem = myProcess.PeakVirtualMemorySize64;
                        peakWorkingSet = myProcess.PeakWorkingSet64;

                        if (myProcess.Responding)
                        {
                            Console.WriteLine("Status = Running");
                        }
                        else
                        {
                            Console.WriteLine("Status = Not Responding");
                        }
                    }
                }
                while (!myProcess.WaitForExit(1000));


                Console.WriteLine();
                Console.WriteLine("Process exit code: {0}", myProcess.ExitCode);

                // Display peak memory statistics for the process.
                Console.WriteLine("Peak physical memory usage of the process: {0:###,###,###,###} ({1}MB)", peakWorkingSet, peakWorkingSet / (1024 * 1024));
                Console.WriteLine("Peak paged memory usage of the process: {0:###,###,###,###} ({1}MB)", peakPagedMem, peakPagedMem / (1024 * 1024));
                Console.WriteLine("Peak virtual memory usage of the process: {0:###,###,###,###} ({1}MB)", peakVirtualMem, peakVirtualMem / (1024 * 1024));

                Console.ReadLine();
            }
            finally
            {
                if (myProcess != null)
                {
                    myProcess.Close();
                }
            }
        }
    }
}
