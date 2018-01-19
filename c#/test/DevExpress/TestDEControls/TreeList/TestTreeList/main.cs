#define USE_SKIN

using System;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.Utils.About;

namespace TestTreeList
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            #region DevExpress License

            var utilityType = typeof(Utility);
            var fieldInfo = utilityType.GetField("staticAboutShown", BindingFlags.Static | BindingFlags.NonPublic);
            if (fieldInfo != null)
                fieldInfo.SetValue(null, true);

            #endregion

            #if USE_SKIN
                DevExpress.UserSkins.BonusSkins.Register();
                SkinManager.EnableFormSkins();
                SkinManager.EnableMdiFormSkins();
            #endif

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            #if USE_SKIN
                UserLookAndFeel.Default.SkinName = "Office 2016 Colorful";
            #endif

            //Application.Run(new MainForm());
            Application.Run(new Form1());
            //Application.Run(new FormWithOriginalTreeList());
        }
    }
}
