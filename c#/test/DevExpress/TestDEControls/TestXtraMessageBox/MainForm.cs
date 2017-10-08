using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace TestXtraMessageBox
{
    public class ShowMessageParams
    {
        public DialogResult Result { get; set; }
    }

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void SimpleButtonShowClick(object sender, EventArgs e)
        {
            var result = XtraMessageBox.Show(this, "Text", "Caption", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
        }

        private void SimpleButtonTaskShowClick(object sender, EventArgs e)
        {
            try
            {
                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        var result = XtraMessageBox.Show(this, "Text", "Caption", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
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

        private void SimpleButtonTaskSendShowClick(object sender, EventArgs e)
        {
            try
            {
                SynchronizationContext uiContext = SynchronizationContext.Current;

                Task.Factory.StartNew(() =>
                {
                    try
                    {
                        var showMessageParams = new ShowMessageParams();
                        uiContext.Send(ShowCallback, showMessageParams);
                        Debug.WriteLine(showMessageParams.Result);
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

        private void ShowCallback(object state)
        {
            var showMessageParams = state as ShowMessageParams;
            if (showMessageParams == null)
                return;

            try
            {
                showMessageParams.Result = XtraMessageBox.Show(this, "Text", "Caption", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
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
    }
}
