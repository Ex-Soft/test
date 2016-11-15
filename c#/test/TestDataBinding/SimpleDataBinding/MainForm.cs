// http://www.codeproject.com/Articles/24656/A-Detailed-Data-Binding-Tutorial
// http://www.akadia.com/services/dotnet_databinding.html

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SimpleDataBinding
{
    public partial class MainForm : Form
    {
        BindingSource
            bs = new BindingSource();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            bs.AddingNew += (s, ev) => { if (listBoxLog.InvokeRequired) listBoxLog.Invoke(new MethodInvoker(() => listBoxLog.Items.Add("AddingNew (InvokeRequired)"))); else listBoxLog.Items.Add("AddingNew (!InvokeRequired)"); };
            bs.BindingComplete += (s, ev) => { if (listBoxLog.InvokeRequired) listBoxLog.Invoke(new MethodInvoker(() => listBoxLog.Items.Add("BindingComplete (InvokeRequired)"))); else listBoxLog.Items.Add("BindingComplete (!InvokeRequired)"); };
            bs.CurrentChanged += (s, ev) => { if (listBoxLog.InvokeRequired) listBoxLog.Invoke(new MethodInvoker(() => listBoxLog.Items.Add("CurrentChanged (InvokeRequired)"))); else listBoxLog.Items.Add("CurrentChanged (!InvokeRequired)"); };
            bs.CurrentItemChanged += (s, ev) => { if (listBoxLog.InvokeRequired) listBoxLog.Invoke(new MethodInvoker(() => listBoxLog.Items.Add("CurrentItemChanged (InvokeRequired)"))); else listBoxLog.Items.Add("CurrentItemChanged (!InvokeRequired)"); };
            bs.DataError += (s, ev) => { if (listBoxLog.InvokeRequired) listBoxLog.Invoke(new MethodInvoker(() => listBoxLog.Items.Add("DataError (InvokeRequired)"))); else listBoxLog.Items.Add("DataError (!InvokeRequired)"); };
            bs.DataMemberChanged += (s, ev) => { if (listBoxLog.InvokeRequired) listBoxLog.Invoke(new MethodInvoker(() => listBoxLog.Items.Add("DataMemberChanged (InvokeRequired)"))); else listBoxLog.Items.Add("DataMemberChanged (!InvokeRequired)"); };
            bs.DataSourceChanged += (s, ev) => { if (listBoxLog.InvokeRequired) listBoxLog.Invoke(new MethodInvoker(() => listBoxLog.Items.Add("DataSourceChanged (InvokeRequired)"))); else listBoxLog.Items.Add("DataSourceChanged (!InvokeRequired)"); };
            bs.ListChanged += (s, ev) => { if (listBoxLog.InvokeRequired) listBoxLog.Invoke(new MethodInvoker(() => listBoxLog.Items.Add("ListChanged (InvokeRequired)"))); else listBoxLog.Items.Add("ListChanged (!InvokeRequired)"); };
            bs.PositionChanged += (s, ev) => { if (listBoxLog.InvokeRequired) listBoxLog.Invoke(new MethodInvoker(() => listBoxLog.Items.Add("PositionChanged (InvokeRequired)"))); else listBoxLog.Items.Add("PositionChanged (!InvokeRequired)"); };

            bs.DataSource = typeof(Airplane);
            bs.Add(new Airplane("Boeing 747", 800));
            bs.Add(new Airplane("Airbus A380", 1023));
            bs.Add(new Airplane("Cessna 162", 67));

            grid.DataSource = bs;
            grid.AutoGenerateColumns = true;
            txtModel.DataBindings.Add("Text", bs, "Model", false, DataSourceUpdateMode.OnValidation);
        }

        private void txtModel_Validating(object sender, CancelEventArgs e)
        {
            if (listBoxLog.InvokeRequired)
                listBoxLog.Invoke(new MethodInvoker(() => listBoxLog.Items.Add("txtModel_Validating (InvokeRequired)")));
            else
                listBoxLog.Items.Add("txtModel_Validating (!InvokeRequired)");

            string errorMsg;

            if (!ValidModel(txtModel.Text, out errorMsg))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                txtModel.Select(0, txtModel.Text.Length);

                // Set the ErrorProvider error with the text to display.  
                errorProvider.SetError(txtModel, errorMsg);
            }
        }

        private void txtModel_Validated(object sender, EventArgs e)
        {
            if (listBoxLog.InvokeRequired)
                listBoxLog.Invoke(new MethodInvoker(() => listBoxLog.Items.Add("txtModel_Validated (InvokeRequired)")));
            else
                listBoxLog.Items.Add("txtModel_Validated (!InvokeRequired)");

            errorProvider.SetError(txtModel, "");
        }

        public bool ValidModel(string model, out string errorMessage)
        {
            Regex
                r=new Regex(@"\d+");

            Match
                match = r.Match(model);

            errorMessage = match.Success ? r.ToString() : string.Empty;

            return !match.Success;
        }
    }
}
