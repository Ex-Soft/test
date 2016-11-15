using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace TestTheadExceptionWinForm
{
    public partial class MainForm : Form
    {
        Thread thread;

        public MainForm()
        {
            InitializeComponent();

            int id = Thread.CurrentThread.ManagedThreadId;
            Debug.WriteLine("MainForm thread: " + id);

        }

        private void BtnDoItClick(object sender, EventArgs e)
        {
            thread = new Thread(Run);
            thread.Start();
        }

        void Run(object state)
        {
            int id = Thread.CurrentThread.ManagedThreadId;
            Debug.WriteLine("Run thread: " + id);

            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(10);
            }

            Debug.WriteLine("throw new Exception(\"blah-blah-blah\")");
            throw new Exception("blah-blah-blah");
        }
    }
}
