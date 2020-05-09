using System;
using System.Diagnostics;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestAsyncAwaitWinApp
{
    public partial class MainForm : Form
    {
        private const string
            Uri = "http://www.google.com.ua",
            DateTimeFormat = "HH:mm:ss.fffffff";

        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnAsyncAwaitDeadLockClick(object sender, EventArgs e)
        {
            var methodName = $"{MethodBase.GetCurrentMethod().Name} (private void BtnAsyncAwaitDeadLockClick(object, EventArgs))";

            WriteToLog($"1. {methodName} ThreadId: {Thread.CurrentThread.ManagedThreadId} started...");

            try
            {
                WriteToLog($"2. Before result = LoadAsync().Result ThreadId: {Thread.CurrentThread.ManagedThreadId}");
                var result = LoadAsync(Uri).Result;
                WriteToLog($"7. After result = LoadAsync().Result ThreadId: {Thread.CurrentThread.ManagedThreadId}");

                WriteToLog($"8. Before Debug.WriteLine(result) ThreadId: {Thread.CurrentThread.ManagedThreadId}");
                Debug.WriteLine(result);
                WriteToLog($"9. After Debug.WriteLine(result) ThreadId: {Thread.CurrentThread.ManagedThreadId}");
            }
            catch (Exception eException)
            {
                Debug.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }

            WriteToLog($"10. {methodName} ThreadId: {Thread.CurrentThread.ManagedThreadId} finished");
        }

        private async void BtnAsyncAwaitClick(object sender, EventArgs e)
        {
            var methodName = $"{MethodBase.GetCurrentMethod().Name} (private async void BtnAsyncAwaitClick(object, EventArgs))";

            WriteToLog($"1. {methodName} ThreadId: {Thread.CurrentThread.ManagedThreadId} started...");

            try
            {
                WriteToLog($"2. Before result = await LoadAsync() ThreadId: {Thread.CurrentThread.ManagedThreadId}");
                var result = await LoadAsync(Uri);
                WriteToLog($"7. After result = await LoadAsync() ThreadId: {Thread.CurrentThread.ManagedThreadId}");

                WriteToLog($"8. Before Debug.WriteLine(result) ThreadId: {Thread.CurrentThread.ManagedThreadId}");
                Debug.WriteLine(result);
                WriteToLog($"9. After Debug.WriteLine(result) ThreadId: {Thread.CurrentThread.ManagedThreadId}");
            }
            catch (Exception eException)
            {
                Debug.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }

            WriteToLog($"10. {methodName} ThreadId: {Thread.CurrentThread.ManagedThreadId} finished");
        }

        // https://stackoverflow.com/questions/9343594/how-to-call-asynchronous-method-from-synchronous-method-in-c
        // http://blog.stephencleary.com/2012/02/async-and-await.html

        private void BtnSyncTaskResultClick(object sender, EventArgs e)
        {
            var methodName = $"{MethodBase.GetCurrentMethod().Name} (private void BtnSyncTaskResultClick(object, EventArgs))";

            var uiContext = SynchronizationContext.Current;

            WriteToLog($"1. {methodName} started...", uiContext);

            try
            {
                WriteToLog("2. Before task = LoadAsyncWithConfigureAwait", uiContext);
                var task = LoadAsyncWithConfigureAwait(Uri, uiContext);
                WriteToLog("7. After task = LoadAsyncWithConfigureAwait", uiContext);

                WriteToLog("8. Before result = task.Result", uiContext);
                var result = task.Result;
                WriteToLog("11. After result = task.Result", uiContext);

                WriteToLog("12. Before Debug.WriteLine(result)", uiContext);
                Debug.WriteLine(result);
                WriteToLog("13. After Debug.WriteLine(result)", uiContext);
            }
            catch (Exception eException)
            {
                Debug.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }

            WriteToLog($"14. {methodName} finished", uiContext);
        }

        private void BtnSyncGetAwaiterGetResultClick(object sender, EventArgs e)
        {
            var methodName = $"{MethodBase.GetCurrentMethod().Name} (private void BtnSyncGetAwaiterGetResultClick(object, EventArgs))";

            var uiContext = SynchronizationContext.Current;

            WriteToLog($"1. {methodName} started...", uiContext);

            try
            {
                WriteToLog("2. Before task = LoadAsyncWithConfigureAwait().GetAwaiter().GetResult()", uiContext);
                var result = LoadAsyncWithConfigureAwait(Uri, uiContext).GetAwaiter().GetResult();
                WriteToLog("11. After task = LoadAsyncWithConfigureAwait().GetAwaiter().GetResult()", uiContext);

                WriteToLog("12. Before Debug.WriteLine(result)", uiContext);
                Debug.WriteLine(result);
                WriteToLog("13. After Debug.WriteLine(result)", uiContext);
            }
            catch (Exception eException)
            {
                Debug.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }

            WriteToLog($"14. {methodName} finished", uiContext);
        }

        private void BtnSyncTaskRunResultClick(object sender, EventArgs e)
        {
            var methodName = $"{MethodBase.GetCurrentMethod().Name} (private void BtnSyncTaskRunResultClick(object, EventArgs))";

            var uiContext = SynchronizationContext.Current;

            WriteToLog($"1. {methodName} started...", uiContext);

            try
            {
                WriteToLog("2. Before task = LoadAsyncWithConfigureAwait", uiContext);
                var task = Task.Run(async () => await LoadAsyncWithConfigureAwait(Uri, uiContext));
                WriteToLog("7. After task = LoadAsyncWithConfigureAwait", uiContext);

                WriteToLog("8. Before result = task.Result", uiContext);
                var result = task.Result;
                WriteToLog("11. After result = task.Result", uiContext);

                WriteToLog("12. Before Debug.WriteLine(result)", uiContext);
                Debug.WriteLine(result);
                WriteToLog("13. After Debug.WriteLine(result)", uiContext);
            }
            catch (Exception eException)
            {
                Debug.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }

            WriteToLog($"14. {methodName} finished", uiContext);
        }

        private void BtnThreadInfoClick(object sender, EventArgs e)
        {
            WriteToLog($"Thread: {Thread.CurrentThread.ManagedThreadId}");
        }

        private void BtnClearLogClick(object sender, EventArgs e)
        {
            listBoxLog.Items.Clear();
        }

        private async Task<int> LoadAsync(string uri)
        {
            var methodName = $"{MethodBase.GetCurrentMethod().Name}() LoadAsync()";

            WriteToLog($"3. {methodName} ThreadId: {Thread.CurrentThread.ManagedThreadId} started...");

            var content = string.Empty;

            try
            {
                var client = new HttpClient();

                WriteToLog($"4. Before client.GetStringAsync(uri) ThreadId: {Thread.CurrentThread.ManagedThreadId}");
                content = await client.GetStringAsync(uri);
                WriteToLog($"5. After client.GetStringAsync(uri) ThreadId: {Thread.CurrentThread.ManagedThreadId}");
            }
            catch (Exception eException)
            {
                Debug.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }

            WriteToLog($"6. {methodName} ThreadId: {Thread.CurrentThread.ManagedThreadId} finished");

            return content.Length;
        }

        async Task<int> LoadAsyncWithConfigureAwait(string uri, SynchronizationContext uiContext)
        {
            WriteToLog("3. LoadAsyncWithConfigureAwait started...", uiContext);

            var content = string.Empty;

            try
            {
                var client = new HttpClient();

                WriteToLog("4. Before client.GetStringAsync(uri)", uiContext);
                var getStringTask = client.GetStringAsync(uri).ConfigureAwait(false); // http://blog.stephencleary.com/2012/07/dont-block-on-async-code.html
                WriteToLog("5. After client.GetStringAsync(uri)", uiContext);

                WriteToLog("6. Before await getStringTask", uiContext);
                content = await getStringTask;
                WriteToLog("9. After await getStringTask", uiContext);
            }
            catch (HttpRequestException eException)
            {
                Debug.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
            catch (Exception eException)
            {
                Debug.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }

            WriteToLog("10. LoadAsyncWithConfigureAwait finished", uiContext);

            return content.Length;
        }

        private void WriteToLog(string message, bool addListItem = true)
        {
            message = $"{DateTime.Now.ToString(DateTimeFormat)} {message} (WriteToLogThread:{Thread.CurrentThread.ManagedThreadId})";

            Debug.WriteLine(message);

            if (!addListItem)
                return;

            listBoxLog.Invoke(new MethodInvoker(() => listBoxLog.Items.Add(message)));
        }

        private void WriteToLog(string message, SynchronizationContext uiContext, bool addListItem = true)
        {
            message = $"{DateTime.Now.ToString(DateTimeFormat)} {message} (WriteToLogThread:{Thread.CurrentThread.ManagedThreadId})";

            Debug.WriteLine(message);

            if (!addListItem)
                return;

            uiContext.Post(WriteToLogCallback, message);
        }

        private void WriteToLogCallback(object state)
        {
            if (!(state is string))
                return;

            var msg = $"{DateTime.Now.ToString(DateTimeFormat)} {(string)state} (WriteToLogCallbackThread:{Thread.CurrentThread.ManagedThreadId})";

            listBoxLog.Items.Add(msg);
        }
    }
}
