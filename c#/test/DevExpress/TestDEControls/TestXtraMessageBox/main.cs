using System;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.Utils.About;

namespace TestXtraMessageBox
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SetCulture("ru-RU");

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

        private static void SetCulture(string value)
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

            if (culture == null)
                return;

            if (CultureInfo.DefaultThreadCurrentCulture == null || CultureInfo.DefaultThreadCurrentCulture.Name != culture.Name)
                CultureInfo.DefaultThreadCurrentCulture = culture;
            if (CultureInfo.DefaultThreadCurrentUICulture == null || CultureInfo.DefaultThreadCurrentUICulture.Name != culture.Name)
                CultureInfo.DefaultThreadCurrentUICulture = culture;
        }
    }
}
