using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TestWindow
{
    public partial class MainForm : Form
    {
        Form _smthWindow;

        public MainForm()
        {
            InitializeComponent();
            _smthWindow = null;
        }

        public void WriteToLog(string message, bool addListItem = true)
        {
            System.Diagnostics.Debug.WriteLine(message);

            if (!addListItem)
                return;

            message = string.Format("{0} ({1}InvokeRequired)", message, !listBoxLog.InvokeRequired ? "!" : string.Empty);

            if (listBoxLog.InvokeRequired)
                listBoxLog.Invoke(new MethodInvoker(() => listBoxLog.Items.Add(message)));
            else
                listBoxLog.Items.Add(message);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            WriteToLog(string.Format("ProcessCmdKey ({0}InvokeRequired): {1}", InvokeRequired ? string.Empty : "!", msg));
            
            return base.ProcessCmdKey(ref msg, keyData);
        }

        void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            WriteToLog(string.Format("OnKeyPress ({0}InvokeRequired)", InvokeRequired ? string.Empty : "!"));
        }

        void OnKeyUp(object sender, KeyEventArgs e)
        {
            WriteToLog(string.Format("OnKeyUp ({0}InvokeRequired)", InvokeRequired ? string.Empty : "!"));
        }

        void OnKeyDown(object sender, KeyEventArgs e)
        {
            WriteToLog(string.Format("OnKeyDown ({0}InvokeRequired)", InvokeRequired ? string.Empty : "!"));
        }

        void ButtonShowModalClick(object sender, EventArgs e)
        {
            if (_smthWindow == null)
            {
                _smthWindow = new SmthForm();
                //smthWindow.MinimumSize = new Size(500, 500);
                _smthWindow.Size = new Size(400, 400);
            }
            else
            {
                WriteToLog(string.Format("SmthForm: Handle {0}= IntPtr.Zero", _smthWindow.Handle != IntPtr.Zero ? "!" : string.Empty));
            }
            
            WriteToLog(string.Format("SmthForm: Modal = {0}", _smthWindow.Modal));

            //Dispose();

            if (checkBoxModal.Checked)
                _smthWindow.ShowDialog(this);
            else
                _smthWindow.Show();

            WriteToLog(string.Format("SmthForm: Modal = {0}", _smthWindow.Modal));
        }

        void ButtonFocusClick(object sender, EventArgs e)
        {
            if (_smthWindow != null)
                _smthWindow.Focus();
        }

        void CheckBoxEnabledCheckedChanged(object sender, EventArgs e)
        {
            if (_smthWindow != null)
                _smthWindow.Enabled = checkBoxEnabled.Checked;
        }

        void MainFormResizeEnd(object sender, EventArgs e)
        {
            Form form;

            if ((form=sender as Form) == null)
                return;

            WriteToLog(string.Format("Size: {0}, ClientSize: {1}, MinimumSize: {2}", form.Size, form.ClientSize, form.MinimumSize));
        }

        void MainFormFormClosed(object sender, FormClosedEventArgs e)
        {
            WriteToLog("MainForm: FormClosed", false);
        }

        void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            WriteToLog("MainForm: FormClosing", false);
        }

        void MainFormClosing(object sender, CancelEventArgs e)
        {
            WriteToLog("MainForm: Closing", false);
        }

        void MainFormClosed(object sender, EventArgs e)
        {
            WriteToLog("MainForm: Closed", false);
        }

        void MainFormDisposed(object sender, EventArgs e)
        {
            Form form;

            if ((form = sender as Form) != null)
                WriteToLog(string.Format("MainForm: IsDisposed = {0}", form.IsDisposed), false);

            WriteToLog("MainForm: Disposed", false);
        }

        private void ButtonDoItClick(object sender, EventArgs e)
        {
        }

        private void ButtonTestModalClick(object sender, EventArgs e)
        {
            DialogResult result;

            using (var modalForm = new ModalForm())
            {
                result = modalForm.ShowDialog(this);
            }

            WriteToLog(result.ToString());
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            WriteToLog("MainForm: OnClosing");
            base.OnClosing(e);
        }

        protected override void OnClosed(EventArgs e)
        {
            WriteToLog("MainForm: OnClosed");
            base.OnClosed(e);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            WriteToLog("MainForm: OnFormClosing");
            base.OnFormClosing(e);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            WriteToLog("MainForm: OnFormClosed");
            base.OnFormClosed(e);
        }
        /*
MainForm: OnClosing
MainForm: Closing
MainForm: OnFormClosing
MainForm: FormClosing
MainForm: OnClosed
MainForm: Closed
MainForm: OnFormClosed
MainForm: FormClosed
MainForm: Dispose(True)
MainForm: IsDisposed = False
MainForm: Disposed
        */
    }
}
