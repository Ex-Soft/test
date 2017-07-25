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

        private bool GetArgs(out int taskMaxCount, out int delay, out int semaphoreSlimInitialCount, out int semaphoreSlimMaxCount)
        {
            delay = semaphoreSlimInitialCount = semaphoreSlimMaxCount = 0;

            return int.TryParse(textBoxTaskMaxCount.Text, out taskMaxCount)
                   && int.TryParse(textBoxDelay.Text, out delay)
                   && int.TryParse(textBoxSemaphoreSlimInitialCount.Text, out semaphoreSlimInitialCount)
                   && int.TryParse(textBoxSemaphoreSlimMaxCount.Text, out semaphoreSlimMaxCount);
        }

        private void buttonDoIt_Click(object sender, EventArgs e)
        {
            int taskMaxCount, delay, semaphoreSlimInitialCount, semaphoreSlimMaxCount;
            if (!GetArgs(out taskMaxCount, out delay, out semaphoreSlimInitialCount, out semaphoreSlimMaxCount))
                return;

            AddToListBoxCallback($"{MethodBase.GetCurrentMethod().Name}(Thread:{Thread.CurrentThread.ManagedThreadId}) start...");

            var uiContext = SynchronizationContext.Current;
            var taskList = new List<Task>();
            var slim = semaphoreSlimMaxCount != 0 ? new SemaphoreSlim(semaphoreSlimInitialCount, semaphoreSlimMaxCount) : new SemaphoreSlim(semaphoreSlimInitialCount) /* equ SemaphoreSlim(initialCount, int.MaxValue) */;

            try
            {
                for (var i = 0; i < taskMaxCount; ++i)
                    taskList.Add(Task.Run(() => Foo(delay, uiContext, slim)));

                if (semaphoreSlimInitialCount == 0)
                {
                    Thread.Sleep(5000);
                    slim.Release(semaphoreSlimMaxCount);
                }

                Task.WaitAll(taskList.ToArray());
            }
            finally
            {
                slim.Dispose();
                AddToListBoxCallback($"{MethodBase.GetCurrentMethod().Name}(Thread:{Thread.CurrentThread.ManagedThreadId}) finally -> slim.Dispose()");
            }

            AddToListBoxCallback($"{MethodBase.GetCurrentMethod().Name}(Thread:{Thread.CurrentThread.ManagedThreadId}) finished");
        }

        private void Foo(int delay, SynchronizationContext uiContext, SemaphoreSlim slim)
        {
            var msg = $"Thread {Thread.CurrentThread.ManagedThreadId} Task {Task.CurrentId} begins and waits for the semaphore.";
            uiContext.Post(AddToListBoxCallback, msg);

            slim.Wait();

            msg = $"Thread {Thread.CurrentThread.ManagedThreadId} Task {Task.CurrentId} enters the semaphore.";
            uiContext.Post(AddToListBoxCallback, msg);

            Thread.Sleep(delay);
            //Task.Delay(delay);

            msg = $"Thread {Thread.CurrentThread.ManagedThreadId} Task {Task.CurrentId} releases the semaphore; previous count: {slim.Release()}.";
            uiContext.Post(AddToListBoxCallback, msg);
        }

        private void AddToListBoxCallback(object state)
        {
            var paramMsg = state as string;
            var msg = $"{MethodBase.GetCurrentMethod().Name}({(!string.IsNullOrWhiteSpace(paramMsg) ? paramMsg : "IsNullOrWhiteSpace")}, Thread:{Thread.CurrentThread.ManagedThreadId})";
            Debug.WriteLine(msg);

            listBoxLog.Items.Add(msg);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBoxLog.Items.Clear();
        }
    }
}
