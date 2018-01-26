using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace TestTheadExceptionWinForm
{
    public partial class MainForm : Form
    {
        Thread
            _thread1,
            _thread2;


        bool _shouldStop;

        public MainForm()
        {
            InitializeComponent();

            Debug.WriteLine($"MainForm Thread.CurrentThread.ManagedThreadId: {Thread.CurrentThread.ManagedThreadId}");
        }

        private void BtnThrowClick(object sender, EventArgs e)
        {
            _thread1 = new Thread(RunWithThrow);
            _thread1.Start();
        }

        void RunWithThrow(object state)
        {
            Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name} Thread.CurrentThread.ManagedThreadId: {Thread.CurrentThread.ManagedThreadId} starting...");

            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(10);
            }

            Debug.WriteLine("throw new Exception(\"blah-blah-blah\")");
            throw new Exception("blah-blah-blah");
        }

        private void BtnStopClick(object sender, EventArgs e)
        {
            _shouldStop = false;
            _thread2 = new Thread(RunWithStop) { IsBackground = true };
            _thread2.Start();
        }

        void RunWithStop(object state)
        {
            Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name} Thread.CurrentThread.ManagedThreadId: {Thread.CurrentThread.ManagedThreadId} starting...");

            while (!_shouldStop)
            {
                Thread.Sleep(5000);
                DoSmthWithException();
            }

            Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name} Thread.CurrentThread.ManagedThreadId: {Thread.CurrentThread.ManagedThreadId} finished");
        }

        void DoSmthWithException()
        {
            Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name} Thread.CurrentThread.ManagedThreadId: {Thread.CurrentThread.ManagedThreadId} starting...");

            try
            {
                Debug.WriteLine("throw new Exception(\"blah-blah-blah\")");
                throw new Exception("blah-blah-blah");
            }
            catch
            {
                _shouldStop = true;
            }

            Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name} Thread.CurrentThread.ManagedThreadId: {Thread.CurrentThread.ManagedThreadId} finished");
        }
    }
}
