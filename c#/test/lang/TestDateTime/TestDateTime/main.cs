using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading;

using static System.Console;

namespace TestDateTime
{
    class Program
    {
        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        static extern ushort GetSystemDefaultUILanguage();

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        static extern ushort GetUserDefaultUILanguage();

        static void Main(string[] args)
        {
            var appointment = new
            {
                Id = Guid.NewGuid(),
                Description = "Take dog to veterinarian.",
                Date = new DateOnly(2002, 1, 13),
                StartTime = new TimeOnly(5, 15),
                EndTime = new TimeOnly(5, 45)
            };

            var serialized = JsonSerializer.Serialize(appointment);

            WriteLine($"Resulting JSON: {serialized}");

            WriteLine($"GetSystemDefaultUILanguage(): 0x{GetSystemDefaultUILanguage():x4}");
            WriteLine($"GetUserDefaultUILanguage(): 0x{GetUserDefaultUILanguage():x4}");

            WriteLine();

            WriteLine($"Thread.CurrentThread.CurrentCulture: \"{Thread.CurrentThread.CurrentCulture}\" DateFormat: \"{Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern}\"");
            WriteLine($"Thread.CurrentThread.CurrentUICulture: \"{Thread.CurrentThread.CurrentUICulture}\" DateFormat: \"{Thread.CurrentThread.CurrentUICulture.DateTimeFormat.ShortDatePattern}\"");
            WriteLine($"CultureInfo.CurrentCulture: \"{CultureInfo.CurrentCulture}\" DateFormat: \"{CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern}\"");
            WriteLine($"CultureInfo.CurrentUICulture: \"{CultureInfo.CurrentUICulture}\" DateFormat: \"{CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern}\"");
            WriteLine($"CultureInfo.DefaultThreadCurrentCulture: \"{CultureInfo.DefaultThreadCurrentCulture}\" DateFormat: \"{(CultureInfo.DefaultThreadCurrentCulture != null ? CultureInfo.DefaultThreadCurrentCulture.DateTimeFormat.ShortDatePattern : "")}\"");
            WriteLine($"CultureInfo.DefaultThreadCurrentUICulture: \"{CultureInfo.DefaultThreadCurrentUICulture}\" DateFormat: \"{(CultureInfo.DefaultThreadCurrentUICulture != null ? CultureInfo.DefaultThreadCurrentUICulture.DateTimeFormat.ShortDatePattern : "")}\"");
            WriteLine($"CultureInfo.InstalledUICulture: \"{CultureInfo.InstalledUICulture}\" DateFormat: \"{CultureInfo.InvariantCulture.DateTimeFormat.ShortDatePattern}\"");
            WriteLine($"CultureInfo.InvariantCulture: \"{CultureInfo.InvariantCulture}\" DateFormat: \"{CultureInfo.InvariantCulture.DateTimeFormat.ShortDatePattern}\"");

            string
                strDDMMYY = "31/12/2019",
                strMMDDYY = "12/31/2019";

            CultureInfo cultureInfo = CultureInfo.CurrentCulture;
            DateTime dt;

            WriteLine(DateTime.TryParse(strDDMMYY, cultureInfo,
                DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.NoCurrentDateDefault, out dt)
                ? dt.ToShortDateString()
                : $"!\"{strDDMMYY}\"");

            WriteLine(DateTime.TryParse(strMMDDYY, cultureInfo,
                DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.NoCurrentDateDefault, out dt)
                ? dt.ToShortDateString()
                : $"!\"{strMMDDYY}\"");

            WriteLine();

            cultureInfo = new CultureInfo("en-US", false);

            WriteLine($"cultureInfo: \"{cultureInfo}\" DateFormat: \"{cultureInfo.DateTimeFormat.ShortDatePattern}\"");

            WriteLine(DateTime.TryParse(strDDMMYY, cultureInfo,
                DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.NoCurrentDateDefault, out dt)
                ? dt.ToShortDateString()
                : $"!\"{strDDMMYY}\"");

            WriteLine(DateTime.TryParse(strMMDDYY, cultureInfo,
                DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.NoCurrentDateDefault, out dt)
                ? dt.ToShortDateString()
                : $"!\"{strMMDDYY}\"");

            ReadKey();
        }
    }
}
