using System;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.Utils.About;

namespace TestLayout
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

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainFormEdit());
            //Application.Run(new MainFormEditWSplitControl());
            //Application.Run(new TestInheritedForm());
            //Application.Run(new TestInheritedFormFromMainFormWToolBar());
            //Application.Run(new TestInheritedFormWGroupControls());
        }
    }
}
