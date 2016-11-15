using System;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace TestValidation
{
    public partial class MainForm : XtraForm, INotifyPropertyChanged
    {
        DateTime _testDateTime;

        public DateTime TestDateTime
        {
            get { return _testDateTime; }
            set
            {
                if (_testDateTime != value)
                {
                    _testDateTime = value;
                    if (PropertyChanged != null)
                    {
                        AddToLog("Firing OnPropertyChanged");
                        PropertyChanged(this, new PropertyChangedEventArgs("TestDateTime"));
                    }
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainForm()
        {
            InitializeComponent();

            dateEdit.Properties.NullDate = default(DateTime);
            dateEdit.ErrorText = "Empty!!! (ctor)";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            dateEdit.DataBindings.Add(new Binding("EditValue", this, "TestDateTime", false, DataSourceUpdateMode.OnPropertyChanged));
        }

        private void dateEdit_Validating(object sender, CancelEventArgs e)
        {
            var editor = sender as DateEdit;

            if (editor == null)
                return;

            AddToLog("Validating: " + editor.DateTime.ToShortDateString());

            string errorMessage;

            if (!ValidDate(editor.DateTime, out errorMessage))
            {
                editor.ErrorText = errorMessage;
                e.Cancel = false;
            }
        }

        public bool ValidDate(DateTime date, out string errorMessage)
        {
            errorMessage = string.Empty;

            bool isValid;

            if (!(isValid = date != default(DateTime)))
                errorMessage = "Empty!!!";

            return isValid;
        }

        private void dateEdit_EditValueChanged(object sender, EventArgs e)
        {
            var editor = sender as DateEdit;

            if (editor == null)
                return;

            AddToLog("EditValueChanged: " +editor.DateTime.ToShortDateString());
        }

        private void dateEdit_EditValueChanging(object sender, ChangingEventArgs e)
        {
            var editor = sender as DateEdit;

            if (editor == null)
                return;

            AddToLog("EditValueChanging: " + string.Format("{0} {1} -> {2}", editor.DateTime.Date.ToShortDateString(), e.OldValue != null ? ((DateTime)e.OldValue).Date.ToShortDateString() : "null", e.NewValue != null ? ((DateTime)e.NewValue).Date.ToShortDateString() : "null"));
        }

        private void dateEdit_DateTimeChanged(object sender, EventArgs e)
        {
            var editor = sender as DateEdit;

            if (editor == null)
                return;

            AddToLog("DateTimeChanged: " + editor.DateTime.ToShortDateString());
        }

        private void dateEdit_Modified(object sender, EventArgs e)
        {
            var editor = sender as DateEdit;

            if (editor == null)
                return;

            AddToLog("Modified: " + editor.DateTime.ToShortDateString());
        }

        private void dateEdit_Closed(object sender, ClosedEventArgs e)
        {
            var editor = sender as DateEdit;

            if (editor == null)
                return;

            AddToLog("Closed");
        }

        private void dateEdit_CloseUp(object sender, CloseUpEventArgs e)
        {
            var editor = sender as DateEdit;

            if (editor == null)
                return;

            AddToLog("CloseUp");
        }

        private void checkEditBuffered_CheckedChanged(object sender, EventArgs e)
        {
            var editor = sender as CheckEdit;

            if (editor == null)
                return;

            dateEdit.Properties.EditValueChangedFiringMode = editor.Checked ? DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered : DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            simpleButtonClearLog_Click(simpleButtonClearLog, EventArgs.Empty);
        }

        private void simpleButtonClearLog_Click(object sender, EventArgs e)
        {
            listBoxControlLog.Items.Clear();
        }

        void AddToLog(string message)
        {
            message = DateTime.Now.ToString("HH:mm:ss.fffffff tt") + " " + message;

            if (listBoxControlLog.InvokeRequired)
                listBoxControlLog.Invoke(new MethodInvoker(() => listBoxControlLog.Items.Add(message + " (InvokeRequired)")));
            else
                listBoxControlLog.Items.Add(message + " (!InvokeRequired)");
        }

        private void dateEdit_Validated(object sender, EventArgs e)
        {
            var editor = sender as DateEdit;

            if (editor == null)
                return;

            AddToLog("Validated: " + editor.DateTime.ToShortDateString());
        }
    }
}
