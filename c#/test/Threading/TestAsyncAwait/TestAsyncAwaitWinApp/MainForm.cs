﻿using System;
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
        private const string Uri = "http://www.google.com.ua";

        public MainForm()
        {
            InitializeComponent();
        }

        private async void BtnAsyncAwaitClick(object sender, EventArgs e)
        {
            var methodName = $"{MethodBase.GetCurrentMethod().Name} (private async void BtnAsyncAwaitClick(object, EventArgs))";

            WriteToLog($"1. {methodName} started...");

            try
            {
                WriteToLog("2. Before result = await LoadAsync()");
                var result = await LoadAsync(Uri);
                WriteToLog("9. After result = await LoadAsync()");

                WriteToLog("10. Before Debug.WriteLine(result)");
                Debug.WriteLine(result);
                WriteToLog("11. After Debug.WriteLine(result)");
            }
            catch (Exception eException)
            {
                Debug.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }

            WriteToLog($"12. {methodName} finished");
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
            WriteToLog("3. LoadAsync started...");

            var content = string.Empty;

            try
            {
                var client = new HttpClient();

                WriteToLog("4. Before client.GetStringAsync(uri)");
                var getStringTask = client.GetStringAsync(uri);
                WriteToLog("5. After client.GetStringAsync(uri)");

                WriteToLog("6. Before await getStringTask");
                content = await getStringTask;
                WriteToLog("7. After await getStringTask");
            }
            catch (Exception eException)
            {
                Debug.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }

            WriteToLog("8. LoadAsync finished");

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
            catch (Exception eException)
            {
                Debug.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }

            WriteToLog("10. LoadAsyncWithConfigureAwait finished", uiContext);

            return content.Length;
        }

        private void WriteToLog(string message, bool addListItem = true)
        {
            message = $"{message} (WriteToLogThread:{Thread.CurrentThread.ManagedThreadId})";

            Debug.WriteLine(message);

            if (!addListItem)
                return;

            listBoxLog.Invoke(new MethodInvoker(() => listBoxLog.Items.Add(message)));
        }

        private void WriteToLog(string message, SynchronizationContext uiContext, bool addListItem = true)
        {
            message = $"{message} (WriteToLogThread:{Thread.CurrentThread.ManagedThreadId})";

            Debug.WriteLine(message);

            if (!addListItem)
                return;

            uiContext.Post(WriteToLogCallback, message);
        }

        private void WriteToLogCallback(object state)
        {
            if (!(state is string))
                return;

            var msg = $"{(string)state} (WriteToLogCallbackThread:{Thread.CurrentThread.ManagedThreadId})";

            listBoxLog.Items.Add(msg);
        }
    }
}