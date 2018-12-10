using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestTaskWinForm
{
    public partial class MainForm : Form
    {
        private const int
            ChildrenTaskMax = 10,
            MSec = 100;

        private CancellationTokenSource _cts;

        public MainForm()
        {
            InitializeComponent();
            
            _cts = null;

            tbChildrenTaskMax.Text = ChildrenTaskMax.ToString();
            tbmSec.Text = MSec.ToString();
        }

        private static int GetValue(Control tb, int defaultValue)
        {
            int tmpInt;

            int.TryParse(tb.Text, out tmpInt);
            if (tmpInt == default)
                tmpInt = defaultValue;

            return tmpInt;
        }

        private async void BtnStartTaskClick(object sender, EventArgs e)
        {
            _cts = new CancellationTokenSource();

            try
            {
                await Run(new TaskParam(0, GetValue(tbmSec, MSec)), _cts.Token);
            }
            catch (OperationCanceledException)
            {
                WriteToLog("Cancel");
            }
            catch (Exception eException)
            {
                WriteToLog($"{eException.GetType().FullName}: {eException.Message}");
            }

            _cts.Dispose();
            _cts = null;
        }

        private void BtnCancelTaskClick(object sender, EventArgs e)
        {
            _cts?.Cancel();
        }

        private async void BtnStartTaskWithChildrenClick(object sender, EventArgs e)
        {
            _cts = new CancellationTokenSource();

            try
            {
                await RunWithChildren(_cts.Token);
            }
            catch (OperationCanceledException)
            {
                WriteToLog("Cancel");
            }
            catch (Exception eException)
            {
                WriteToLog($"{eException.GetType().FullName}: {eException.Message}");
            }

            _cts.Dispose();
            _cts = null;
        }

        private async Task RunWithChildren(CancellationToken ct)
        {
            var children = new List<Task>();
            var childrenTaskMax = GetValue(tbChildrenTaskMax, ChildrenTaskMax);
            var mSec = GetValue(tbmSec, MSec);

            for (var i = 0; i < childrenTaskMax; ++i)
                children.Add(Run(new TaskParam(i, mSec), ct));

            await Task.WhenAll(children);
        }

        private async Task Run(object param, CancellationToken ct)
        {
            TaskParam taskParam;

            if ((taskParam = param as TaskParam) == null)
                return;

            WriteToLog($"{DateTime.Now.ToString("HH:mm:ss.fffffff")}\t{taskParam.i} started...");

            var rnd = new Random(Thread.CurrentThread.ManagedThreadId);

            for (var i = 0; i < 10; ++i)
            {
                WriteToLog($"{DateTime.Now.ToString("HH:mm:ss.fffffff")}\t{taskParam.i} i={i}");

                await Task.Delay(taskParam.mSec * rnd.Next(10));
                //await Task.Delay(taskParam.mSec * rnd.Next(10), ct);

                if (ct.IsCancellationRequested)
                    WriteToLog($"{DateTime.Now.ToString("HH:mm:ss.fffffff")}\t{taskParam.i} canceled");

                ct.ThrowIfCancellationRequested();
            }

            WriteToLog($"{DateTime.Now.ToString("HH:mm:ss.fffffff")}\t{taskParam.i} finished");
        }

        private void WriteToLog(string message, bool addListItem = true)
        {
            System.Diagnostics.Debug.WriteLine(message);

            if (!addListItem)
                return;

            message = $"{message} ({(!listBoxLog.InvokeRequired ? "!" : string.Empty)}InvokeRequired)";

            if (listBoxLog.InvokeRequired)
                listBoxLog.Invoke(new MethodInvoker(() => listBoxLog.Items.Add(message)));
            else
                listBoxLog.Items.Add(message);
        }

        private void BtnStartTaskNotAsyncClick(object sender, EventArgs e)
        {
            const string methodName = "BtnStartTaskNotAsyncClick()";

            WriteToLog($"{methodName} starting...");

            _cts = new CancellationTokenSource();

            Task t = Task.Factory.StartNew(() => Run(new TaskParam(0, 100), _cts.Token));

            WriteToLog($"{methodName} finished");
        }

        private async void ButtonStartTaskTAPAsyncClick(object sender, EventArgs e)
        {
            const string methodName = "ButtonStartTaskTAPAsyncClick()";

            WriteToLog($"{methodName} starting...");

            int result = await TaskTAPAsync(new TaskParam(0, GetValue(tbmSec, MSec)));

            WriteToLog($"{methodName} finished result = {result}");
        }

        private async Task<int> TaskTAPAsync(object param)
        {
            if (!(param is TaskParam taskParam))
                return 0;

            WriteToLog($"{DateTime.Now.ToString("HH:mm:ss.fffffff")}\t{taskParam.i} started...");

            var rnd = new Random(Thread.CurrentThread.ManagedThreadId);
            var result = taskParam.mSec * rnd.Next(10);

            await Task.Delay(result);

            WriteToLog($"{DateTime.Now.ToString("HH:mm:ss.fffffff")}\t{taskParam.i} finished result = {result}");

            return result;
        }

        private void ButtonStartTaskTAPClick(object sender, EventArgs e)
        {
            //https://msdn.microsoft.com/en-us/library/hh873177(v=vs.110).aspx

            string methodName = $"{MethodBase.GetCurrentMethod().Name}()";

            WriteToLog($"{methodName} starting...");

            Task<int> task = TaskTAP(new TaskParam(0, GetValue(tbmSec, MSec)));

            TaskAwaiter<int> awaiter = task.GetAwaiter();

            awaiter.OnCompleted(() => {
                int result = awaiter.GetResult();
                WriteToLog($"{methodName} result = {result}");
            });

            WriteToLog($"{methodName} finished task.Status = {task.Status}");
        }

        private Task<int> TaskTAP(object param)
        {
            if (!(param is TaskParam taskParam))
                return null;

            WriteToLog($"{DateTime.Now.ToString("HH:mm:ss.fffffff")}\t{taskParam.i} started...");

            var tcs = new TaskCompletionSource<int>();
            var rnd = new Random(Thread.CurrentThread.ManagedThreadId);
            var result = taskParam.mSec * rnd.Next(10);

            Thread.Sleep(result);

            try
            {
                WriteToLog($"{DateTime.Now.ToString("HH:mm:ss.fffffff")}\t{taskParam.i} SetResult({result})");
                tcs.SetResult(result);
            }
            catch (Exception e)
            {
                tcs.SetException(e);
            }

            WriteToLog($"{DateTime.Now.ToString("HH:mm:ss.fffffff")}\t{taskParam.i} finished");

            return tcs.Task;
        }

        private void BtnClearLogClick(object sender, EventArgs e)
        {
            listBoxLog.Items.Clear();
        }
    }
}
