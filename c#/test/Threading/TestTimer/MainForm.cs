using System;
using System.Windows.Forms;

namespace TestTimer
{
    public partial class MainForm : Form
    {
        readonly object _locker = new object();
        System.Threading.Timer _timer;

        public MainForm()
        {
            InitializeComponent();

            _timer = null;
        }

        void BtnStartClick(object sender, EventArgs e)
        {
            lock (_locker)
            {
                if (_timer != null)
                    return;

                Button btn;

                if ((btn = sender as Button) != null)
                    btn.Enabled = !btn.Enabled;

                btnStop.Enabled = true;

                _timer = new System.Threading.Timer(TimerCallback, null, 0, System.Threading.Timeout.Infinite);
            }
        }

        void BtnStopClick(object sender, EventArgs e)
        {
            lock (_locker)
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
        }

        void TimerCallback(object state)
        {
            lock (_locker)
            {
                if (_timer == null)
                    return;

                var msg = string.Format("CurrentThread.ManagedThreadId: {0} ({1}InvokeRequired)", System.Threading.Thread.CurrentThread.ManagedThreadId, !InvokeRequired ? "!" : string.Empty);

                if (InvokeRequired)
                    Invoke(new System.Threading.TimerCallback(WriteToLog), msg);
                else
                    WriteToLog(msg);

                _timer.Change(500, System.Threading.Timeout.Infinite);
            }
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
