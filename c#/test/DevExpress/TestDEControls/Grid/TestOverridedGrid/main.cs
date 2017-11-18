using System;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.Utils.About;

namespace TestOverridedGrid
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            ParseCmdLine(args);

            #region DevExpress License

            var utilityType = typeof(Utility);
            var fieldInfo = utilityType.GetField("staticAboutShown", BindingFlags.Static | BindingFlags.NonPublic);
            if (fieldInfo != null)
                fieldInfo.SetValue(null, true);

            #endregion

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
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

        private static void SetCulture(string value)
        {
            CultureInfo culture;

            try
            {
                culture = CultureInfo.CreateSpecificCulture(value);
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
