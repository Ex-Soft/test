using System;
using System.Windows.Forms;
using CommonServiceLocator;

namespace WinFormsApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            UnityActivator.Start();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(ServiceLocator.Current.GetInstance<MainForm>());
        }
    }
}
