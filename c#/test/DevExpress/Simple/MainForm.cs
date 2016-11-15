using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Simple
{
    public partial class MainForm : XtraForm
    {
        ClassVictim classVictim;

        public MainForm()
        {
            InitializeComponent();

            classVictim = new ClassVictim();
            classVictim.DecimalVictim = 1.123456789010000m;
            spinEdit1.DataBindings.Add("EditValue", classVictim, "DecimalVictim", true, DataSourceUpdateMode.OnPropertyChanged);
            spinEdit1.EditValueChanged += SpinEditEditValueChanged;
            spinEdit1.CustomDisplayText += SpinEditCustomDisplayText;
        }

        void SpinEditCustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if ((Decimal)e.Value == 0m)
                return;

            SpinEdit spinEdit;

            if ((spinEdit = sender as SpinEdit) == null)
                return;

            var regex = new Regex("0+$");
            var match = regex.Match(e.DisplayText);

            if (match.Success)
                e.DisplayText = regex.Replace(e.DisplayText, string.Empty);
        }

        void SpinEditEditValueChanged(object sender, EventArgs e)
        {
            SpinEdit spinEdit;

            if ((spinEdit = sender as SpinEdit) == null)
                return;
        }
    }

    public class ClassVictim
    {
        public decimal DecimalVictim { get; set; }
    }
}
