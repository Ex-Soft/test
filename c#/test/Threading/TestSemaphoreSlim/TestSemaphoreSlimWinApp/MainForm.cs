using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestSemaphoreSlimWinApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private bool GetArgs(out int taskMaxCount, out int taskDelay, out int semaphoreSlimInitialCount, out int semaphoreSlimMaxCount, out int semaphoreSlimDelay)
        {
            taskDelay = semaphoreSlimInitialCount = semaphoreSlimMaxCount = semaphoreSlimDelay = 0;

            return int.TryParse(textBoxTaskMaxCount.Text, out taskMaxCount)
                   && int.TryParse(textBoxTaskDelay.Text, out taskDelay)
                   && int.TryParse(textBoxSemaphoreSlimInitialCount.Text, out semaphoreSlimInitialCount)
                   && int.TryParse(textBoxSemaphoreSlimMaxCount.Text, out semaphoreSlimMaxCount)
                   && int.TryParse(textBoxBoxSemaphoreSlimDelay.Text, out semaphoreSlimDelay);
        }

        private void buttonDoIt_Click(object sender, EventArgs e)
        {
            int taskMaxCount, taslDelay, semaphoreSlimInitialCount, semaphoreSlimMaxCount, semaphoreSlimDelay;
            if (!GetArgs(out taskMaxCount, out taslDelay, out semaphoreSlimInitialCount, out semaphoreSlimMaxCount, out semaphoreSlimDelay))
                return;

            var msg = $"{DateTime.Now.ToString("HH:mm:ss.fffffff")} {MethodBase.GetCurrentMethod().Name}(Thread:{Thread.CurrentThread.ManagedThreadId}) start...";
            Debug.WriteLine(msg);
            AddToListBoxCallback(msg);

            var uiContext = SynchronizationContext.Current;
            var taskList = new List<Task>();
            var slim = semaphoreSlimMaxCount != 0 ? new SemaphoreSlim(semaphoreSlimInitialCount, semaphoreSlimMaxCount) : new SemaphoreSlim(semaphoreSlimInitialCount) /* equ SemaphoreSlim(initialCount, int.MaxValue) */;

            try
            {
                msg = $"{DateTime.Now.ToString("HH:mm:ss.fffffff")} Tasks will be starting...";
                Debug.WriteLine(msg);
                AddToListBoxCallback(msg);

                for (var i = 0; i < taskMaxCount; ++i)
                    taskList.Add(Task.Run(() => Foo(taslDelay, uiContext, slim)));

                if (semaphoreSlimInitialCount == 0)
                {
                    msg = $"{DateTime.Now.ToString("HH:mm:ss.fffffff")} slim.Release() b4";
                    Debug.WriteLine(msg);
                    AddToListBoxCallback(msg);

                    Thread.Sleep(semaphoreSlimDelay);
                    slim.Release(semaphoreSlimMaxCount);

                    msg = $"{DateTime.Now.ToString("HH:mm:ss.fffffff")} slim.Release() after";
                    Debug.WriteLine(msg);
                    AddToListBoxCallback(msg);
                }

                Task.WaitAll(taskList.ToArray());

                msg = $"{DateTime.Now.ToString("HH: mm: ss.fffffff")} All tasks have been finished";
                Debug.WriteLine(msg);
                AddToListBoxCallback(msg);
            }
            finally
            {
                slim.Dispose();
                msg = $"{DateTime.Now.ToString("HH:mm:ss.fffffff")} {MethodBase.GetCurrentMethod().Name}(Thread:{Thread.CurrentThread.ManagedThreadId}) finally -> slim.Dispose()";
                Debug.WriteLine(msg);
                AddToListBoxCallback(msg);
            }

            msg = $"{DateTime.Now.ToString("HH:mm:ss.fffffff")} {MethodBase.GetCurrentMethod().Name}(Thread:{Thread.CurrentThread.ManagedThreadId}) finished";
            Debug.WriteLine(msg);
            AddToListBoxCallback(msg);
        }

        private void Foo(int delay, SynchronizationContext uiContext, SemaphoreSlim slim)
        {
            var msg = $"{DateTime.Now.ToString("HH:mm:ss.fffffff")} Thread {Thread.CurrentThread.ManagedThreadId} Task {Task.CurrentId} begins and waits for the semaphore.";
            Debug.WriteLine(msg);
            uiContext.Post(AddToListBoxCallback, msg);

            slim.Wait();

            msg = $"{DateTime.Now.ToString("HH:mm:ss.fffffff")} Thread {Thread.CurrentThread.ManagedThreadId} Task {Task.CurrentId} enters the semaphore.";
            Debug.WriteLine(msg);
            uiContext.Post(AddToListBoxCallback, msg);

            Thread.Sleep(delay);
            //Task.Delay(delay);

            msg = $"{DateTime.Now.ToString("HH:mm:ss.fffffff")} Thread {Thread.CurrentThread.ManagedThreadId} Task {Task.CurrentId} releases the semaphore; previous count: {slim.Release()}.";
            Debug.WriteLine(msg);
            uiContext.Post(AddToListBoxCallback, msg);
        }

        private void AddToListBoxCallback(object state)
        {
            var paramMsg = state as string;
            var msg = $"{DateTime.Now.ToString("HH:mm:ss.fffffff")} {MethodBase.GetCurrentMethod().Name}({(!string.IsNullOrWhiteSpace(paramMsg) ? paramMsg : "IsNullOrWhiteSpace")}, Thread:{Thread.CurrentThread.ManagedThreadId})";

            listBoxLog.Items.Add(msg);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBoxLog.Items.Clear();
        }
    }
}
