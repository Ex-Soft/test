using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace TestWindow
{
    public partial class SmthForm : Form
    {
        public SmthForm()
        {
            InitializeComponent();
        }

        void BtnHideClick(object sender, EventArgs e)
        {
            Hide();
        }

        void BtnCloseClick(object sender, EventArgs e)
        {
            Close();
        }

        void WriteToLog(string message)
        {
            MainForm mainForm;
            
            if ((mainForm = Owner as MainForm) != null)
                mainForm.WriteToLog(message);
        }

        void SmthFormEnter(object sender, EventArgs e)
        {
            WriteToLog("SmthForm: Enter");
        }

        void SmthFormGotFocus(object sender, EventArgs e)
        {
            WriteToLog("SmthForm: GotFocus");
        }
        
        void SmthFormLostFocus(object sender, EventArgs e)
        {
            WriteToLog("SmthForm: LostFocus");
        }

        void SmthFormLeave(object sender, EventArgs e)
        {
            WriteToLog("SmthForm: Leave");
        }

        void SmthFormLoad(object sender, EventArgs e)
        {
            WriteToLog("SmthForm: Load");
        }
        
        void SmthFormShown(object sender, EventArgs e)
        {
            WriteToLog("SmthForm: Shown");
        }

        void SmthFormFormClosed(object sender, FormClosedEventArgs e)
        {
            WriteToLog("SmthForm: FormClosed");
        }

        void SmthFormFormClosing(object sender, FormClosingEventArgs e)
        {
            WriteToLog("SmthForm: FormClosing");
        }

        void SmthFormClosing(object sender, CancelEventArgs e)
        {
            WriteToLog("SmthForm: Closing");
        }

        void SmthFormClosed(object sender, EventArgs e)
        {
            WriteToLog("SmthForm: Closed");
        }

        private void SmthFormDisposed(object sender, EventArgs e)
        {
            Form form;

            if ((form = sender as Form) != null)
                WriteToLog(String.Format("SmthForm: IsDisposed = {0}", form.IsDisposed));

            WriteToLog("SmthForm: Disposed");
        }

        void SmthFormHandleDestroyed(object sender, EventArgs e)
        {
            WriteToLog("SmthForm: HandleDestroyed");
        }

        void SmthFormHandleCreated(object sender, EventArgs e)
        {
            WriteToLog("SmthForm: HandleCreated");
        }

        void SmthFormActivated(object sender, EventArgs e)
        {
            WriteToLog("SmthForm: Activated");
        }

        void SmthFormDeactivate(object sender, EventArgs e)
        {
            WriteToLog("SmthForm: Deactivate");
        }
    }
}
