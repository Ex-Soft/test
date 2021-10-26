using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AllWinApp
{
    public partial class MainForm : Form
    {
        private const int MSec = 100;

        private readonly SynchronizationContext _uiContext;

        private bool _manualResetEventLoop;
        private readonly ManualResetEvent _manualResetEvent = new(false);

        private bool _manualResetEventSlimLoop;
        private readonly ManualResetEventSlim _manualResetEventSlim = new(false);

        private readonly ManualResetEventSlim _manualResetEventSlimForTask = new(false);
        private readonly CancellationTokenSource _cancellationTokenSourceForTask = new();

        public MainForm()
        {
            InitializeComponent();

            _uiContext = SynchronizationContext.Current;
        }

        private void BtnManualResetEventStartClick(object sender, EventArgs e)
        {
            _manualResetEventLoop = true;
            Task.Factory.StartNew(ManualResetEventTask);
        }

        private void BtnManualResetEventStopClick(object sender, EventArgs e)
        {
            _manualResetEventLoop = false;
        }

        private void ManualResetEventTask()
        {
            var message = $"ManualResetEvent.WaitOne({Thread.CurrentThread.ManagedThreadId})";
            var rnd = new Random(Thread.CurrentThread.ManagedThreadId);

            WriteToLog(lbManualResetEventLog, $"{MethodBase.GetCurrentMethod().Name}({Thread.CurrentThread.ManagedThreadId}) starting...");
            while (_manualResetEventLoop)
            {
                WriteToLog(lbManualResetEventLog, $"{message} before");
                var result = _manualResetEvent.WaitOne();
                Thread.Sleep(MSec * rnd.Next(10));
                WriteToLog(lbManualResetEventLog, $"{message} after (result={result})");
            }
            WriteToLog(lbManualResetEventLog, $"{MethodBase.GetCurrentMethod().Name}({Thread.CurrentThread.ManagedThreadId}) finished");
        }

        private void BtnManualResetEventSetClick(object sender, EventArgs e)
        {
            const string message = "ManualResetEvent.Set()";
            WriteToLog(lbManualResetEventLog, $"{message} before");
            var result = _manualResetEvent.Set();
            WriteToLog(lbManualResetEventLog, $"{message} after (result={result})");
        }

        private void BtnManualResetEventResetClick(object sender, EventArgs e)
        {
            const string message = "ManualResetEvent.Reset()";
            WriteToLog(lbManualResetEventLog, $"{message} before");
            var result = _manualResetEvent.Reset();
            WriteToLog(lbManualResetEventLog, $"{message} after (result={result})");
        }

        private void BtnManualResetEventSlimStartClick(object sender, EventArgs e)
        {
            _manualResetEventSlimLoop = true;
            Task.Factory.StartNew(ManualResetEventSlimTask);
        }

        private void BtnManualResetEventSlimStopClick(object sender, EventArgs e)
        {
            _manualResetEventSlimLoop = false;
        }

        private void ManualResetEventSlimTask()
        {
            var message = $"ManualResetEventSlim.Wait({Thread.CurrentThread.ManagedThreadId})";
            var rnd = new Random(Thread.CurrentThread.ManagedThreadId);
            ListBox listBoxLog;

            WriteToLog(listBoxLog = lbManualResetEventSlimLog, $"{MethodBase.GetCurrentMethod().Name}({Thread.CurrentThread.ManagedThreadId}) starting...");
            while (_manualResetEventSlimLoop)
            {
                WriteToLog(listBoxLog, $"{message} before");
                _manualResetEventSlim.Wait();
                Thread.Sleep(MSec * rnd.Next(10));
                WriteToLog(listBoxLog, $"{message} after");
            }
            WriteToLog(listBoxLog, $"{MethodBase.GetCurrentMethod().Name}({Thread.CurrentThread.ManagedThreadId}) finished");
        }

        private void BtnManualResetEventSlimSetClick(object sender, EventArgs e)
        {
            const string message = "ManualResetEventSlim.Set()";
            ListBox listBoxLog;
            WriteToLog(listBoxLog = lbManualResetEventSlimLog, $"{message} before");
            _manualResetEventSlim.Set();
            WriteToLog(listBoxLog, $"{message} after");
        }

        private void BtnManualResetEventSlimResetClick(object sender, EventArgs e)
        {
            const string message = "ManualResetEventSlim.Reset()";
            ListBox listBoxLog;
            WriteToLog(listBoxLog = lbManualResetEventSlimLog, $"{message} before");
            _manualResetEventSlim.Reset();
            WriteToLog(listBoxLog, $"{message} after");
        }

        private async void BtnWaitHandleToTaskClick(object sender, EventArgs e)
        {
            const string message = "WaitOneAsync()";
            ListBox listBoxLog;
            WriteToLog(listBoxLog = lbTaskLog, $"{message} before");
            await WaitOneAsync(_cancellationTokenSourceForTask.Token);
            WriteToLog(listBoxLog, $"{message} after");
        }

        public async Task WaitOneAsync(CancellationToken cancellationToken)
        {
            const string message = "WaitHandle.WaitOneAsync()";
            ListBox listBoxLog;
            WriteToLog(listBoxLog = lbTaskLog, $"{message} before");
            try
            {
                await _manualResetEventSlimForTask.WaitHandle.WaitOneAsync(cancellationToken);
            }
            catch (TaskCanceledException e)
            {
                WriteToLog(listBoxLog, $"{e.GetType().Name} {e.Message}");
            }
            catch (OperationCanceledException e)
            {
                WriteToLog(listBoxLog, $"{e.GetType().Name} {e.Message}");
            }
            catch (Exception e)
            {
                WriteToLog(listBoxLog, $"{e.GetType().Name} {e.Message}");
            }
            WriteToLog(listBoxLog, $"{message} after");
        }

        private void BtnManualResetEventSlimForTaskSetClick(object sender, EventArgs e)
        {
            const string message = "ManualResetEventSlim.Set()";
            ListBox listBoxLog;
            WriteToLog(listBoxLog = lbTaskLog, $"{message} before");
            _manualResetEventSlimForTask.Set();
            WriteToLog(listBoxLog, $"{message} after");
        }

        private void BtnCancellationTokenSourceForTaskCancelClick(object sender, EventArgs e)
        {
            const string message = "CancellationTokenSource.Cancel()";
            ListBox listBoxLog;
            WriteToLog(listBoxLog = lbTaskLog, $"{message} before");
            _cancellationTokenSourceForTask.Cancel();
            WriteToLog(listBoxLog, $"{message} after");
        }

        private void BtnTaskToWaitHandleClick(object sender, EventArgs e)
        {
            Task.Factory.StartNew(TaskRun);
        }

        private void TaskRun()
        {
            ListBox listBoxLog;

            WriteToLog(listBoxLog = lbTaskLog, $"{DateTime.Now:hh:mm:ss.fffffff} Task.Factory.StartNew() before ({Thread.CurrentThread.ManagedThreadId})");
            //Task task = Task.Factory.StartNew(TaskDelay);
            Task task = Task.Factory.StartNew(ThreadSleep);
            WriteToLog(listBoxLog, $"{DateTime.Now:hh:mm:ss.fffffff} Task.Factory.StartNew() after ({Thread.CurrentThread.ManagedThreadId})");

            WriteToLog(listBoxLog, $"{DateTime.Now:hh:mm:ss.fffffff} ((IAsyncResult)task).AsyncWaitHandle before ({Thread.CurrentThread.ManagedThreadId})");
            WaitHandle waitHandle = ((IAsyncResult)task).AsyncWaitHandle;
            WriteToLog(listBoxLog, $"{DateTime.Now:hh:mm:ss.fffffff} ((IAsyncResult)task).AsyncWaitHandle after ({Thread.CurrentThread.ManagedThreadId})");

            WriteToLog(listBoxLog, $"{DateTime.Now:hh:mm:ss.fffffff} WaitHandle.WaitAny() before ({Thread.CurrentThread.ManagedThreadId})");
            waitHandle.WaitOne();
            //WaitHandle.WaitAny(new[] {waitHandle});
            WriteToLog(listBoxLog, $"{DateTime.Now:hh:mm:ss.fffffff} WaitHandle.WaitAny() after ({Thread.CurrentThread.ManagedThreadId})");
        }

        private async Task TaskDelay()
        {
            const string message = "Task.Delay()";
            ListBox listBoxLog;
            WriteToLog(listBoxLog = lbTaskLog, $"{DateTime.Now:hh:mm:ss.fffffff} {message} before ({Thread.CurrentThread.ManagedThreadId})");
            await Task.Delay(5000);
            WriteToLog(listBoxLog, $"{DateTime.Now:hh:mm:ss.fffffff} {message} after ({Thread.CurrentThread.ManagedThreadId})");
        }

        private void ThreadSleep()
        {
            const string message = "Thread.Sleep()";
            ListBox listBoxLog;
            WriteToLog(listBoxLog = lbTaskLog, $"{DateTime.Now:hh:mm:ss.fffffff} {message} before ({Thread.CurrentThread.ManagedThreadId})");
            Thread.Sleep(5000);
            WriteToLog(listBoxLog, $"{DateTime.Now:hh:mm:ss.fffffff} {message} after ({Thread.CurrentThread.ManagedThreadId})");
        }

        public void WriteToLog(ListBox listBoxLog, string message)
        {
            Debug.WriteLine(message);
            _uiContext.Post(AddToListBoxCallback, new AddToListBoxParam(listBoxLog, message));
        }

        private static void AddToListBoxCallback(object state)
        {
            ListBox listBox;
            if (state is not AddToListBoxParam param || (listBox = param.ListBox) == null)
                return;

            listBox.Items.Insert(0, param.Message);
        }
    }

    public class AddToListBoxParam
    {
        public ListBox ListBox { get; }
        public string Message { get; }

        public AddToListBoxParam(ListBox listBox = null, string message = "")
        {
            ListBox = listBox;
            Message = message;
        }
    }
}
