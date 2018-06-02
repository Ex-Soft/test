// https://docs.microsoft.com/en-us/dotnet/framework/winforms/order-of-events-in-windows-forms

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

        void MainFormHandleCreated(object sender, EventArgs e)
        {
            WriteToLog("MainForm: HandleCreated");
        }

        void MainFormBindingContextChanged(object sender, EventArgs e)
        {
            WriteToLog("MainForm: BindingContextChanged");
        }

        void MainFormLoad(object sender, EventArgs e)
        {
            WriteToLog("MainForm: Load");
        }

        void MainFormVisibleChanged(object sender, EventArgs e)
        {
            WriteToLog("MainForm: VisibleChanged");
        }

        void MainFormActivated(object sender, EventArgs e)
        {
            WriteToLog("MainForm: Activated");
        }

        void MainFormDeactivate(object sender, EventArgs e)
        {
            WriteToLog("MainForm: Deactivated");
        }

        void MainFormShown(object sender, EventArgs e)
        {
            WriteToLog("MainForm: Shown");
        }

        void MainFormEnter(object sender, EventArgs e)
        {
            WriteToLog("MainForm: Enter");
        }

        void MainFormLeave(object sender, EventArgs e)
        {
            WriteToLog("MainForm: Leave");
        }

        void MainFormGotFocus(object sender, EventArgs e)
        {
            WriteToLog("MainForm: GotFocus");
        }

        void MainFormLostFocus(object sender, EventArgs e)
        {
            WriteToLog("MainForm: LostFocus");
        }

        void MainFormValidating(object sender, CancelEventArgs e)
        {
            WriteToLog("MainForm: Validating");
        }

        void MainFormValidated(object sender, EventArgs e)
        {
            WriteToLog("MainForm: Validated");
        }

        void MainFormHandleDestroyed(object sender, EventArgs e)
        {
            WriteToLog("MainForm: HandleDestroyed", false);
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

        protected override void OnHandleCreated(EventArgs e)
        {
            WriteToLog("MainForm: OnHandleCreated");
            base.OnHandleCreated(e);
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            WriteToLog("MainForm: OnHandleDestroyed", false);
            base.OnHandleDestroyed(e);
        }

        protected override void OnBindingContextChanged(EventArgs e)
        {
            WriteToLog("MainForm: OnBindingContextChanged");
            base.OnBindingContextChanged(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            WriteToLog("MainForm: OnLoad");
            base.OnLoad(e);
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            WriteToLog("MainForm: OnVisibleChanged");
            base.OnVisibleChanged(e);
        }

        protected override void OnActivated(EventArgs e)
        {
            WriteToLog("MainForm: OnActivated");
            base.OnActivated(e);
        }

        protected override void OnDeactivate(EventArgs e)
        {
            WriteToLog("MainForm: OnDeactivated");
            base.OnDeactivate(e);
        }

        protected override void OnShown(EventArgs e)
        {
            WriteToLog("MainForm: OnShown");
            base.OnShown(e);
        }

        protected override void OnEnter(EventArgs e)
        {
            WriteToLog("MainForm: OnEnter");
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            WriteToLog("MainForm: OnLeave");
            base.OnLeave(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            WriteToLog("MainForm: OnGotFocus");
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            WriteToLog("MainForm: OnLostFocus");
            base.OnLostFocus(e);
        }

        protected override void OnValidating(CancelEventArgs e)
        {
            WriteToLog("MainForm: OnValidating");
            base.OnValidating(e);
        }

        protected override void OnValidated(EventArgs e)
        {
            WriteToLog("MainForm: OnValidated");
            base.OnValidated(e);
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
MainForm: OnHandleCreated
MainForm: HandleCreated
MainForm: OnBindingContextChanged
MainForm: BindingContextChanged
MainForm: OnLoad
MainForm: Load
MainForm: OnVisibleChanged
MainForm: VisibleChanged
MainForm: OnActivated
MainForm: Activated
MainForm: OnShown
MainForm: OnClosing
MainForm: Closing
MainForm: OnFormClosing
MainForm: FormClosing
MainForm: OnClosed
MainForm: Closed
MainForm: OnFormClosed
MainForm: FormClosed
MainForm: Dispose(True)
MainForm: OnHandleDestroyed
MainForm: HandleDestroyed
MainForm: IsDisposed = False
MainForm: Disposed
*/
    }
}
