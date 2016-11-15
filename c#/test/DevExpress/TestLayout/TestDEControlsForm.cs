using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace TestLayout
{
    public partial class TestDEControlsForm : XtraForm
    {
        DateTime
            _dateTime;

        public TestDEControlsForm()
        {
            Debug.WriteLine(string.Format("TestDEControlsForm() ({0})", GetType().Name));

            InitializeComponent();

            checkEdit1.ErrorText = "blah-blah-blah";
            textEdit1.ErrorText = "blah-blah-blah";
            timeEdit.ErrorText = "blah-blah-blah";
            dateEdit.ErrorText = "blah-blah-blah";
        }

        private void ceLblOnOff_CheckedChanged(object sender, System.EventArgs e)
        {
            var ce = sender as CheckEdit;

            if(ce!=null)
                lblUp.Visible = ce.Checked;
        }

        private void TestDEControlsForm_Load(object sender, EventArgs e)
        {
            dateEdit.Properties.NullDate = default(DateTime);
            dateEdit.DataBindings.Add(new Binding("EditValue", _dateTime, "Date", true, DataSourceUpdateMode.OnPropertyChanged));
        }

        bool ValidDate(DateTime dateTime, out string errorMessage)
        {
            errorMessage = string.Empty;

            bool isValid;

            if (!(isValid = dateTime != default(DateTime)))
                errorMessage = "Invalid Date!!!";

            return isValid;
        }

        private void dateEdit_Validating(object sender, CancelEventArgs e)
        {
            var editor = sender as DateEdit;

            if(editor==null)
                return;

            string errorMessage;

            if(!ValidDate((DateTime)editor.EditValue, out errorMessage))
            {
                editor.ErrorText = errorMessage;
                e.Cancel = false;
            }
        }

        private void dateEdit_EditValueChanged(object sender, EventArgs e)
        {
            var editor = sender as DateEdit;

            if (editor == null)
                return;

            var newValue = editor.EditValue;
        }
    }
}
