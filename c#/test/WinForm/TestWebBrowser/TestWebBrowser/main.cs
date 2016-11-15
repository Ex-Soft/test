using System;
using System.Threading;
using System.Windows.Forms;

namespace TestWebBrowser
{
    static class Program
    {
        static MainForm _mainForm;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _mainForm = new MainForm();

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.ThreadException += _mainForm.OnThreadException;
            Application.Run(_mainForm);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            _mainForm.OnThreadException(sender, new ThreadExceptionEventArgs((Exception)e.ExceptionObject));

            if (e.IsTerminating)
                Application.Exit();
        }
    }
}
