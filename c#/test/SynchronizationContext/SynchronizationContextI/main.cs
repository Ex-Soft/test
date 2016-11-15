// http://www.codeproject.com/Articles/31971/Understanding-SynchronizationContext-Part-I
// http://www.codeproject.com/Articles/32113/Understanding-SynchronizationContext-Part-II
// http://www.codeproject.com/Articles/32119/Understanding-SynchronizationContext-Part-III
// http://msdn.microsoft.com/en-us/magazine/gg598924.aspx
// http://www.ikriv.com/dev/dotnet/MysteriousHang.html

//#define TEST_CONTEXT

using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace SynchronizationContextI
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

            #if TEST_CONTEXT

                // let's check the context here
                var context = SynchronizationContext.Current;
                Debug.WriteLine(context == null ? "No context for this thread" : "We got a context");

                // create a form
                MainForm form = new MainForm();

                // let's check it again after creating a form
                context = SynchronizationContext.Current;
                Debug.WriteLine(context == null ? "No context for this thread" : "We got a context");

                if (context == null)
                    Debug.WriteLine("No context for this thread");

            #endif

            Application.Run(new MainForm());
        }
    }
}
