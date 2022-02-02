using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TestCultureWinForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ParseCmdLine(args);
            Application.Run(new MainForm());
        }

        static void ParseCmdLine(string[] args)
        {
            if (args == null || args.Length == 0)
                return;

            var regexSwitchWithValue = new Regex("^[\\-/](.+?):(.+)");

            for (var i = 0; i < args.Length; ++i)
            {
                var match = regexSwitchWithValue.Match(args[i]);

                if (!match.Success || match.Groups.Count != 3)
                    continue;

                string
                    @switch = match.Groups[1].Value.ToLower(),
                    value = match.Groups[2].Value;

                switch (@switch)
                {
                    case "c":
                    case "culture":
                    {
                        SetCulture(value);
                        break;
                    }
                }
            }
        }

        static void SetCulture(string value)
        {
            CultureInfo culture;

            try
            {
                culture = new CultureInfo(value, false); // CultureInfo.CreateSpecificCulture(value);
            }
            catch
            {
                culture = null;
            }

            if (culture != null)
            {
                if (CultureInfo.DefaultThreadCurrentCulture == null || CultureInfo.DefaultThreadCurrentCulture.Name != culture.Name)
                    CultureInfo.DefaultThreadCurrentCulture = culture;
                if (CultureInfo.DefaultThreadCurrentUICulture == null || CultureInfo.DefaultThreadCurrentUICulture.Name != culture.Name)
                    CultureInfo.DefaultThreadCurrentUICulture = culture;
            }
        }
    }
}
