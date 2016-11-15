using System.Diagnostics;
using DevExpress.XtraEditors;

namespace TestLayout
{
    public partial class MainForm : XtraForm
    {
        public MainForm()
        {
            Debug.WriteLine(string.Format("MainForm() ({0})", GetType().Name));
            InitializeComponent();
        }
    }
}
