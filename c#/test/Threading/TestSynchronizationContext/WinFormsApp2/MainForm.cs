//#define THROW_EXCEPTION

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class MainForm : Form
    {
        private readonly List<ListBox> _listBoxs;

        private string Victim { get; } = "blah-blah-blah";

        private ChildForm _childForm;
        private ChildFormModal _childFormModal;

        public MainForm()
        {
            InitializeComponent();

            _listBoxs = new List<ListBox>(GetControl<ListBox>(this));
            _childForm = null;
            _childFormModal = null;
        }

        private void buttonInvoke_Click(object sender, EventArgs e)
        {
            Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}(Thread:{Thread.CurrentThread.ManagedThreadId})");

            try
            {
                Parallel.ForEach(_listBoxs, TestInvoke);
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
        }

        private void TestInvoke(ListBox listBox)
        {
            try
            {
                var msg = $"TestInvoke(Thread:{Thread.CurrentThread.ManagedThreadId}, listBox.Name:\"{listBox.Name}\")";
                Debug.WriteLine(msg);

                if (listBox.InvokeRequired)
                    listBox.Invoke(new MethodInvoker(() => listBox.Items.Add(msg)));
                else
                    listBox.Items.Add(msg);

                Debug.WriteLine(Victim);
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
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}(Thread:{Thread.CurrentThread.ManagedThreadId})");

            SynchronizationContext uiContext = SynchronizationContext.Current;

            try
            {
                Parallel.ForEach(_listBoxs, (listBox, state, arg3) =>
                {
                    var msg = $"Parallel.ForEach(Thread:{Thread.CurrentThread.ManagedThreadId}, listBox.Name:\"{listBox.Name}\")";
                    Debug.WriteLine(msg);

                    try
                    {
                        uiContext.Post(AddToListBoxCallback, new AddToListBoxParam(listBox, msg));
                        Debug.WriteLine(Victim);
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
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}(Thread:{Thread.CurrentThread.ManagedThreadId})");

            SynchronizationContext uiContext = SynchronizationContext.Current;

            try
            {
                Parallel.ForEach(_listBoxs, (listBox, state, arg3) =>
                {
                    var msg = $"Parallel.ForEach(Thread:{Thread.CurrentThread.ManagedThreadId}, listBox.Name:\"{listBox.Name}\")";
                    Debug.WriteLine(msg);

                    try
                    {
                        uiContext.Send(AddToListBoxCallback, new AddToListBoxParam(listBox, msg));
                        Debug.WriteLine(Victim);
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
        }

        private void buttonWithOptions_Click(object sender, EventArgs e)
        {
            Debug.WriteLine($"{MethodBase.GetCurrentMethod().Name}(Thread:{Thread.CurrentThread.ManagedThreadId})");

            try
            {
                var options = new ParallelOptions();
                options.TaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();

                Parallel.ForEach(_listBoxs, options, (listBox, state, arg3) =>
                {
                    var msg = $"Parallel.ForEach(Thread:{Thread.CurrentThread.ManagedThreadId}, listBox.Name:\"{listBox.Name}\")";
                    Debug.WriteLine(msg);

                    try
                    {
                        listBox.Items.Add(msg);
                        AddToListBoxCallback(new AddToListBoxParam(listBox, msg));
                        Debug.WriteLine(Victim);
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
                    catch (Exception eException)
                    {
                        Debug.WriteLine(eException.Message);
                    }
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
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            _childForm = new ChildForm(this);
            _childForm.Show(this);
        }

        private void buttonShowModal_Click(object sender, EventArgs e)
        {
            if (_childFormModal == null)
                _childFormModal = new ChildFormModal(this);

            var result = _childFormModal.ShowDialog(this);
            AddToListBoxCallback(new AddToListBoxParam(listBox11, $"result = {result}"));
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            _listBoxs.ForEach(item => item.Items.Clear());
        }

        public static void AddToListBoxCallback(object state)
        {
            #if THROW_EXCEPTION
                throw new Exception("Boom");
            #else
                AddToListBoxParam param;
                if ((param = state as AddToListBoxParam) == null)
                    return;

                var msg = $"{MethodBase.GetCurrentMethod().Name}({(!string.IsNullOrWhiteSpace(param.Msg) ? param.Msg : "IsNullOrWhiteSpace")}, Thread:{Thread.CurrentThread.ManagedThreadId})";
                Debug.WriteLine(msg);

                param.ListBox?.Items.Add(msg);

                Form form;
                if (param.ListBox == null || (form = param.ListBox.FindForm()) == null)
                    return;

                var listBoxes = new List<ListBox>(GetControl<ListBox>(form));
                param.ListBox?.Items.Add(listBoxes.Aggregate(string.Empty, (str, control) => { if (!string.IsNullOrWhiteSpace(str)) str += ", "; return str + control.Name; }));
            #endif
        }

        public static IEnumerable<T> GetControl<T>(Control control) where T : class
        {
            var list = new List<T>();

            if (control is T)
                list.Add(control as T);
            else
                foreach (Control child in control.Controls)
                    if (child.HasChildren)
                        list.AddRange(GetControl<T>(child));
                    else if (child is T)
                        list.Add(child as T);

            return list;
        }
    }

    public class AddToListBoxParam
    {
        public ListBox ListBox { get; }
        public string Msg { get; }

        public AddToListBoxParam(ListBox listBox = null, string msg = "")
        {
            ListBox = listBox;
            Msg = msg;
        }
    }
}
