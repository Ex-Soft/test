using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // let's check the context here
            var context = SynchronizationContext.Current;

            Debug.WriteLine(context == null ? "No context for this thread" : "We got a context");

            // create a form
            var mainForm = new MainForm();

            // let's check it again after creating a form
            context = SynchronizationContext.Current;

            Debug.WriteLine(context == null ? "No context for this thread" : "We got a context");

            if (context == null)
                Debug.WriteLine("No context for this thread");

            Application.Run(mainForm);
        }
    }
}
