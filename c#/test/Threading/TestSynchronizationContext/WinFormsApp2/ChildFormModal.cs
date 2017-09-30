//#define WRITE_TO_LOG_ON_MAIN_FORM

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class ChildFormModal : Form
    {
        private readonly MainForm _mainForm;
        private readonly List<CustomListBox> _listBoxs;

        private string Victim { get; } = "blah-blah-blah";

        public ChildFormModal(MainForm mainForm)
        {
            _mainForm = mainForm;

            InitializeComponent();

            _listBoxs = new List<CustomListBox>(MainForm.GetControl<CustomListBox>(this));
        }

        private static void ListBoxDoIt(object state)
        {
            CustomListBox listBox;
            if ((listBox = state as CustomListBox) == null)
                return;

            listBox.DoIt();
        }

        private void DoIt()
        {
            var msg = $"{DateTime.Now.ToString("HH:mm:ss.fffffff")}\t{MethodBase.GetCurrentMethod().Name}(Thread:{Thread.CurrentThread.ManagedThreadId}) starting...";
            Debug.WriteLine(msg);
            #if WRITE_TO_LOG_ON_MAIN_FORM
                MainForm.AddToListBoxCallback(new AddToListBoxParam(_mainForm.listBox11, msg));
            #endif

            SynchronizationContext uiContext = SynchronizationContext.Current;

            try
            {
                Parallel.ForEach(_listBoxs, (listBox, state, arg3) =>
                {
                    var _msg_ = $"{DateTime.Now.ToString("HH:mm:ss.fffffff")}\tParallel.ForEach(Thread:{Thread.CurrentThread.ManagedThreadId}, listBox.Name:\"{listBox.Name}\") starting...";
                    Debug.WriteLine(_msg_);
                    #if WRITE_TO_LOG_ON_MAIN_FORM
                        uiContext.Post(MainForm.AddToListBoxCallback, new AddToListBoxParam(_mainForm.listBox11, _msg_));
                    #endif

                    if (radioButtonPost.Checked)
                        uiContext.Post(ListBoxDoIt, listBox);
                    else
                        uiContext.Send(ListBoxDoIt, listBox);

                    _msg_ = $"{DateTime.Now.ToString("HH:mm:ss.fffffff")}\tParallel.ForEach(Thread:{Thread.CurrentThread.ManagedThreadId}, listBox.Name:\"{listBox.Name}\") finished";
                    Debug.WriteLine(_msg_);
                    #if WRITE_TO_LOG_ON_MAIN_FORM
                        uiContext.Post(MainForm.AddToListBoxCallback, new AddToListBoxParam(_mainForm.listBox11, _msg_));
                    #endif
                });
            }
            catch (AggregateException eAggregateException)
            {
                Debug.WriteLine("AggregateException");
                for (var j = 0; j < eAggregateException.InnerExceptions.Count; j++)
                    Debug.WriteLine($"\t{eAggregateException.InnerExceptions[j]}");
            }
            catch (TargetInvocationException eTargetInvocationException)
            {
                Debug.WriteLine($"TargetInvocationException: \"{eTargetInvocationException.Message}\"");
            }
            catch (InvalidAsynchronousStateException eInvalidAsynchronousStateException)
            {
                Debug.WriteLine($"InvalidAsynchronousStateException: \"{eInvalidAsynchronousStateException.Message}\"");
            }
            catch (InvalidOperationException eInvalidOperationException)
            {
                Debug.WriteLine($"InvalidOperationException: \"{eInvalidOperationException.Message}\"");
            }
            catch (Exception eException)
            {
                Debug.WriteLine(eException.Message);
            }

            msg = $"{DateTime.Now.ToString("HH:mm:ss.fffffff")}\t{MethodBase.GetCurrentMethod().Name}(Thread:{Thread.CurrentThread.ManagedThreadId}) finished";
            Debug.WriteLine(msg);
            #if WRITE_TO_LOG_ON_MAIN_FORM
                MainForm.AddToListBoxCallback(new AddToListBoxParam(_mainForm.listBox11, msg));
            #endif
        }

        private void DoItWithOptions()
        {
            var msg = $"{DateTime.Now.ToString("HH:mm:ss.fffffff")}\t{MethodBase.GetCurrentMethod().Name}(Thread:{Thread.CurrentThread.ManagedThreadId}) starting...";
            Debug.WriteLine(msg);
            #if WRITE_TO_LOG_ON_MAIN_FORM
                MainForm.AddToListBoxCallback(new AddToListBoxParam(_mainForm.listBox11, msg));
            #endif

            SynchronizationContext uiContext = SynchronizationContext.Current;

            try
            {
                var options = new ParallelOptions();
                options.TaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();

                Parallel.ForEach(_listBoxs, options, (listBox, state, arg3) =>
                {
                    var _msg_ = $"{DateTime.Now.ToString("HH:mm:ss.fffffff")}\tParallel.ForEach(Thread:{Thread.CurrentThread.ManagedThreadId}, listBox.Name:\"{listBox.Name}\") starting...";
                    Debug.WriteLine(_msg_);
                    #if WRITE_TO_LOG_ON_MAIN_FORM
                        uiContext.Post(MainForm.AddToListBoxCallback, new AddToListBoxParam(_mainForm.listBox11, _msg_));
                    #endif

                    listBox.DoIt();

                    _msg_ = $"{DateTime.Now.ToString("HH:mm:ss.fffffff")}\tParallel.ForEach(Thread:{Thread.CurrentThread.ManagedThreadId}, listBox.Name:\"{listBox.Name}\") finished";
                    Debug.WriteLine(_msg_);
                    #if WRITE_TO_LOG_ON_MAIN_FORM
                        uiContext.Post(MainForm.AddToListBoxCallback, new AddToListBoxParam(_mainForm.listBox11, _msg_));
                    #endif
                });
            }
            catch (AggregateException eAggregateException)
            {
                Debug.WriteLine("AggregateException");
                for (var j = 0; j < eAggregateException.InnerExceptions.Count; j++)
                    Debug.WriteLine($"\t{eAggregateException.InnerExceptions[j]}");
            }
            catch (TargetInvocationException eTargetInvocationException)
            {
                Debug.WriteLine($"TargetInvocationException: \"{eTargetInvocationException.Message}\"");
            }
            catch (InvalidAsynchronousStateException eInvalidAsynchronousStateException)
            {
                Debug.WriteLine($"InvalidAsynchronousStateException: \"{eInvalidAsynchronousStateException.Message}\"");
            }
            catch (InvalidOperationException eInvalidOperationException)
            {
                Debug.WriteLine($"InvalidOperationException: \"{eInvalidOperationException.Message}\"");
            }
            catch (Exception eException)
            {
                Debug.WriteLine(eException.Message);
            }

            msg = $"{DateTime.Now.ToString("HH:mm:ss.fffffff")}\t{MethodBase.GetCurrentMethod().Name}(Thread:{Thread.CurrentThread.ManagedThreadId}) finished";
            Debug.WriteLine(msg);
            #if WRITE_TO_LOG_ON_MAIN_FORM
                MainForm.AddToListBoxCallback(new AddToListBoxParam(_mainForm.listBox11, msg));
            #endif
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            var msg = $"{DateTime.Now.ToString("HH:mm:ss.fffffff")}\t{MethodBase.GetCurrentMethod().Name}(Thread:{Thread.CurrentThread.ManagedThreadId})";
            Debug.WriteLine(msg);
            MainForm.AddToListBoxCallback(new AddToListBoxParam(_mainForm.listBox11, msg));

            base.OnClosing(e);

            if (radioButtonWithOptions.Checked)
                DoItWithOptions();
            else
                DoIt();
        }

        private void ChildFormModal_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var msg = $"{DateTime.Now.ToString("HH:mm:ss.fffffff")}\t{MethodBase.GetCurrentMethod().Name}(Thread:{Thread.CurrentThread.ManagedThreadId})";
            Debug.WriteLine(msg);
            MainForm.AddToListBoxCallback(new AddToListBoxParam(_mainForm.listBox11, msg));
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            var msg = $"{DateTime.Now.ToString("HH:mm:ss.fffffff")}\t{MethodBase.GetCurrentMethod().Name}(Thread:{Thread.CurrentThread.ManagedThreadId})";
            Debug.WriteLine(msg);
            MainForm.AddToListBoxCallback(new AddToListBoxParam(_mainForm.listBox11, msg));

            base.OnFormClosing(e);
        }

        private void ChildFormModal_FormClosing(object sender, FormClosingEventArgs e)
        {
            var msg = $"{DateTime.Now.ToString("HH:mm:ss.fffffff")}\t{MethodBase.GetCurrentMethod().Name}(Thread:{Thread.CurrentThread.ManagedThreadId})";
            Debug.WriteLine(msg);
            MainForm.AddToListBoxCallback(new AddToListBoxParam(_mainForm.listBox11, msg));
        }

        protected override void OnClosed(EventArgs e)
        {
            var msg = $"{DateTime.Now.ToString("HH:mm:ss.fffffff")}\t{MethodBase.GetCurrentMethod().Name}(Thread:{Thread.CurrentThread.ManagedThreadId})";
            Debug.WriteLine(msg);
            MainForm.AddToListBoxCallback(new AddToListBoxParam(_mainForm.listBox11, msg));

            base.OnClosed(e);
        }

        private void ChildFormModal_Closed(object sender, System.EventArgs e)
        {
            var msg = $"{DateTime.Now.ToString("HH:mm:ss.fffffff")}\t{MethodBase.GetCurrentMethod().Name}(Thread:{Thread.CurrentThread.ManagedThreadId})";
            Debug.WriteLine(msg);
            MainForm.AddToListBoxCallback(new AddToListBoxParam(_mainForm.listBox11, msg));
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            var msg = $"{DateTime.Now.ToString("HH:mm:ss.fffffff")}\t{MethodBase.GetCurrentMethod().Name}(Thread:{Thread.CurrentThread.ManagedThreadId})";
            Debug.WriteLine(msg);
            MainForm.AddToListBoxCallback(new AddToListBoxParam(_mainForm.listBox11, msg));

            base.OnFormClosed(e);
        }

        private void ChildFormModal_FormClosed(object sender, FormClosedEventArgs e)
        {
            var msg = $"{DateTime.Now.ToString("HH:mm:ss.fffffff")}\t{MethodBase.GetCurrentMethod().Name}(Thread:{Thread.CurrentThread.ManagedThreadId})";
            Debug.WriteLine(msg);
            MainForm.AddToListBoxCallback(new AddToListBoxParam(_mainForm.listBox11, msg));
        }

        private void ChildFormModal_Disposed(object sender, EventArgs e)
        {
            Form form;
            var msg = $"{DateTime.Now.ToString("HH:mm:ss.fffffff")}\t{MethodBase.GetCurrentMethod().Name}{((form = sender as Form) != null ? $" IsDisposed = {form.IsDisposed} " : string.Empty)}(Thread:{Thread.CurrentThread.ManagedThreadId})";
            Debug.WriteLine(msg);
            MainForm.AddToListBoxCallback(new AddToListBoxParam(_mainForm.listBox11, msg));
        }
    }
}

/*
OnClosing
Closing
OnFormClosing
FormClosing
OnClosed
Closed
OnFormClosed
FormClosed
Dispose(True)
Disposed IsDisposed = False
*/
