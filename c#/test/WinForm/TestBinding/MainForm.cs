using System.Windows.Forms;

namespace TestBinding
{
    public partial class MainForm : Form
    {
        TestClass instance = new TestClass { FString1 = "FString1", FString2 = "FString2"};

        public MainForm()
        {
            InitializeComponent();

            tbFString1.DataBindings.Add("Text", instance, "FString1");
            tbFString2.DataBindings.Add("Text", instance, "FString2");
        }

        private void tbFString1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string error = null;
            if (string.IsNullOrWhiteSpace(tbFString1.Text))
            {
                error = "tbFString1";
                e.Cancel = true;
            }
            errorProvider1.SetError((Control)sender, error);
        }
    }
}
