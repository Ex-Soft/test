using System;
using System.Globalization;
using System.Threading;

namespace TestCulture
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Thread.CurrentThread.CurrentCulture: \"{Thread.CurrentThread.CurrentCulture}\"");
            Console.WriteLine($"Thread.CurrentThread.CurrentUICulture: \"{Thread.CurrentThread.CurrentUICulture}\"");
            Console.WriteLine($"CultureInfo.CurrentCulture: \"{CultureInfo.CurrentCulture}\"");
            Console.WriteLine($"CultureInfo.CurrentUICulture: \"{CultureInfo.CurrentUICulture}\"");
            Console.WriteLine($"CultureInfo.DefaultThreadCurrentCulture: \"{CultureInfo.DefaultThreadCurrentCulture}\"");
            Console.WriteLine($"CultureInfo.DefaultThreadCurrentUICulture: \"{CultureInfo.DefaultThreadCurrentUICulture}\"");
            Console.WriteLine($"CultureInfo.InstalledUICulture: \"{CultureInfo.InstalledUICulture}\"");
            Console.WriteLine($"CultureInfo.InvariantCulture: \"{CultureInfo.InvariantCulture}\"");

            Console.WriteLine($"Thread.CurrentThread.CurrentUICulture.DateTimeFormat.AbbreviatedDayNames[0]: \"{Thread.CurrentThread.CurrentUICulture.DateTimeFormat.AbbreviatedDayNames[0]}\"");

            var cultureName = "fr-FR";
            var culture = CultureInfo.CreateSpecificCulture(cultureName);
            var culture = CultureInfo.GetCultureInfo(cultureName);

            Console.WriteLine($"culture.NumberFormat.NumberGroupSeparator: \"{culture.NumberFormat.NumberGroupSeparator}\"");
            Console.WriteLine($"culture.NumberFormat.NumberDecimalSeparator: \"{culture.NumberFormat.NumberDecimalSeparator}\"");
            Console.WriteLine($"culture.DateTimeFormat.ShortTimePattern: \"{culture.DateTimeFormat.ShortTimePattern}\"");

            if (CultureInfo.DefaultThreadCurrentCulture == null || CultureInfo.DefaultThreadCurrentCulture.Name != culture.Name)
                CultureInfo.DefaultThreadCurrentCulture = culture;
            if (CultureInfo.DefaultThreadCurrentUICulture == null || CultureInfo.DefaultThreadCurrentUICulture.Name != culture.Name)
                CultureInfo.DefaultThreadCurrentUICulture = culture;

            DisplayRandomNumbers();
            Thread.Sleep(1000);

            Thread workerThread = new Thread(DisplayRandomNumbers);
            workerThread.Start();
        }

        private static void DisplayRandomNumbers()
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
