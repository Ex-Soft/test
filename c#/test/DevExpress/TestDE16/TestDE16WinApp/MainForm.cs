using DevExpress.Xpo;
using DevExpress.XtraEditors;

namespace TestDE16WinApp
{
    public partial class MainForm : XtraForm
    {
        public MainForm()
        {
            InitializeComponent();

            XpoDefault.ConnectionString = Utils.GetConnectionString();
        }

        private void SimpleButtonGridInWindow_Click(object sender, System.EventArgs e)
        {
            using (var form = new GridFormI())
            {
                form.ShowDialog(this);
            }
        }
    }
}
