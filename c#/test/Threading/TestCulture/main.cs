//#define dotNET_4_5
// http://msdn.microsoft.com/en-us/library/system.globalization.cultureinfo.defaultthreadcurrentculture%28v=vs.110%29.aspx
// http://msdn.microsoft.com/en-us/goglobal/bb896001.aspx

using System;
using System.Globalization;
using System.Text;
using System.Threading;

namespace TestCulture
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            CultureInfo culture;
            if (Thread.CurrentThread.CurrentCulture.Name == "ru-RU")
                culture = CultureInfo.CreateSpecificCulture("uk-UA");
            else
                culture = CultureInfo.CreateSpecificCulture("ru-RU");

            #if dotNET_4_5
                CultureInfo.DefaultThreadCurrentCulture = culture;
                CultureInfo.DefaultThreadCurrentUICulture = culture;
            #endif

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            DisplayRandomNumbers();
            Thread.Sleep(1000);

            Thread workerThread = new Thread(new ThreadStart(Program.DisplayRandomNumbers));
            workerThread.Start();

            Console.ReadLine();
        }

        static void DisplayRandomNumbers()
        {
            Console.WriteLine();
            Console.WriteLine("Current Culture:    {0}", Thread.CurrentThread.CurrentCulture);
            Console.WriteLine("Current UI Culture: {0}", Thread.CurrentThread.CurrentUICulture);

            Console.Write("Random Values: ");
            Random rand = new Random();
            for (int ctr = 0; ctr <= 2; ctr++)
                Console.Write("     {0:C2}     ", rand.NextDouble());

            Console.WriteLine();
        }
    }
}
