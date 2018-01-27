using System;
using System.Reflection;
using System.Windows.Forms;

namespace TestTimer
{
    public partial class MainForm : Form
    {
        readonly object _locker = new object();
        System.Threading.Timer _systemThreadingTimer;
        System.Timers.Timer _systemTimersTimer;

        public MainForm()
        {
            InitializeComponent();

            _systemThreadingTimer = null;
            _systemTimersTimer = null;
        }

        void BtnStartSystemThreadingTimerClick(object sender, EventArgs e)
        {
            lock (_locker)
            {
                if (_systemThreadingTimer != null)
                    return;

                if (sender is Button btn)
                    btn.Enabled = !btn.Enabled;

                btnStopSystemThreadingTimer.Enabled = true;

                _systemThreadingTimer = new System.Threading.Timer(TimerCallback, null, 0, System.Threading.Timeout.Infinite);
            }
        }

        void BtnStopSystemThreadingTimerClick(object sender, EventArgs e)
        {
            lock (_locker)
            {
                if (_systemThreadingTimer == null)
                    return;

                if (sender is Button btn)
                    btn.Enabled = !btn.Enabled;

                btnStartSystemThreadingTimer.Enabled = true;

                WriteToLog($"{MethodBase.GetCurrentMethod().Name}");

                _systemThreadingTimer.Dispose();
                _systemThreadingTimer = null;
            }
        }

        void TimerCallback(object state)
        {
            lock (_locker)
            {
                if (_systemThreadingTimer == null)
                    return;

                var msg = $"{MethodBase.GetCurrentMethod().Name} CurrentThread.ManagedThreadId: {System.Threading.Thread.CurrentThread.ManagedThreadId} ({(!InvokeRequired ? "!" : string.Empty)}InvokeRequired)";

                if (InvokeRequired)
                    Invoke(new System.Threading.TimerCallback(WriteToLog), msg);
                else
                    WriteToLog(msg);

                _systemThreadingTimer.Change(500, System.Threading.Timeout.Infinite);
            }
        }

        void WriteToLog(object state)
        {
            var msg = $"{DateTime.Now:HH:mm:ss.fffffff} {state} CurrentThread.ManagedThreadId: {System.Threading.Thread.CurrentThread.ManagedThreadId} ({(!InvokeRequired ? "!" : string.Empty)}InvokeRequired) (_systemThreadingTimer {(_systemThreadingTimer == null ? "=" : "!")}= null) (_systemTimersTimer {(_systemTimersTimer == null ? "=" : "!")}= null)";

            if (listBoxLog.InvokeRequired)
                listBoxLog.Invoke(new MethodInvoker(() => listBoxLog.Items.Add(msg)));
            else
                listBoxLog.Items.Add(msg);

            System.Threading.Thread.Sleep(350);
        }

        private void BtnStartSystemTimersTimerClick(object sender, EventArgs e)
        {
            if (_systemTimersTimer != null)
                return;

            if (sender is Button btn)
                btn.Enabled = !btn.Enabled;

            btnStopSystemTimersTimer.Enabled = true;

            _systemTimersTimer = new System.Timers.Timer(1000);
            _systemTimersTimer.AutoReset = checkBoxAutoReset.Checked;
            _systemTimersTimer.Elapsed += SystemTimersTimerElapsed;
            _systemTimersTimer.Start();
        }

        private void SystemTimersTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (_systemTimersTimer == null)
                return;

            var msg = $"{MethodBase.GetCurrentMethod().Name} CurrentThread.ManagedThreadId: {System.Threading.Thread.CurrentThread.ManagedThreadId} ({(!InvokeRequired ? "!" : string.Empty)}InvokeRequired)";

            if (InvokeRequired)
                Invoke(new MethodInvoker(() => WriteToLog(msg)));
            else
                WriteToLog(msg);

            if (_systemTimersTimer.AutoReset)
                return;

            if (InvokeRequired)
                Invoke(new System.EventHandler(BtnStopSystemTimersTimerClick), EventArgs.Empty);
            else
                BtnStopSystemTimersTimerClick(btnStopSystemTimersTimer, EventArgs.Empty);
        }

        private void BtnStopSystemTimersTimerClick(object sender, EventArgs e)
        {
            if (_systemTimersTimer == null)
                return;

            if (sender is Button btn)
                btn.Enabled = !btn.Enabled;

            btnStartSystemTimersTimer.Enabled = true;

            WriteToLog($"{MethodBase.GetCurrentMethod().Name}");

            _systemTimersTimer.Dispose();
            _systemTimersTimer = null;
        }
    }
}
