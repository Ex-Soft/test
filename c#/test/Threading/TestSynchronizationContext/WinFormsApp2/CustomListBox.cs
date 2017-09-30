using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public class CustomListBox : ListBox
    {
        public void DoIt()
        {
            Debug.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.fffffff")}\tCustomListBox.{MethodBase.GetCurrentMethod().Name}(\"{Name}\" Thread:{Thread.CurrentThread.ManagedThreadId}) starting...");

            var rnd = new Random(Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(100 * rnd.Next(10));

            Debug.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.fffffff")}\tCustomListBox.{MethodBase.GetCurrentMethod().Name}(\"{Name}\" Thread:{Thread.CurrentThread.ManagedThreadId}) finished");
        }
    }
}
