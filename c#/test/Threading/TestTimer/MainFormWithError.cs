using System;
using System.Windows.Forms;

namespace TestTimer
{
    public partial class MainFormWithError : Form
    {
        System.Threading.Timer _timer;

        public MainFormWithError()
        {
            InitializeComponent();

            _timer = null;
        }

        private void BtnStartClick(object sender, EventArgs e)
        {
            if (_timer != null)
                return;

            Button btn;

            if ((btn = sender as Button) != null)
                btn.Enabled = !btn.Enabled;

            btnStop.Enabled = true;

            _timer = new System.Threading.Timer(TimerCallback, null, 0, 500);
        }

        private void BtnStopClick(object sender, EventArgs e)
        {
            if (_timer == null)
                return;

            Button btn;

            if ((btn = sender as Button) != null)
                btn.Enabled = !btn.Enabled;

            btnStart.Enabled = true;

            WriteToLog("BtnStopClick");

            _timer.Dispose();
            _timer = null;
        }

        void TimerCallback(object state)
        {
            if (_timer == null)
                return;

            var msg = string.Format("CurrentThread.ManagedThreadId: {0} ({1}InvokeRequired)", System.Threading.Thread.CurrentThread.ManagedThreadId, !InvokeRequired ? "!" : string.Empty);

            if (InvokeRequired)
                Invoke(new System.Threading.TimerCallback(WriteToLog), msg);
            else
                WriteToLog(msg);
        }

        void WriteToLog(object state)
        {
            var msg = string.Format("{0:HH:mm:ss.fffffff} {1} CurrentThread.ManagedThreadId: {2} ({3}InvokeRequired) (_timer {4}= null)", DateTime.Now, state, System.Threading.Thread.CurrentThread.ManagedThreadId, !InvokeRequired ? "!" : string.Empty, _timer == null ? "=" : "!");

            if (listBoxLog.InvokeRequired)
                listBoxLog.Invoke(new MethodInvoker(() => listBoxLog.Items.Add(msg)));
            else
                listBoxLog.Items.Add(msg);

            System.Threading.Thread.Sleep(350);
        }
    }
}
