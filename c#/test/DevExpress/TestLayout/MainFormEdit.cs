using System.Diagnostics;

namespace TestLayout
{
    public partial class MainFormEdit : MainForm
    {
        public MainFormEdit()
        {
            Debug.WriteLine(string.Format("MainFormEdit() ({0})", GetType().Name));
            InitializeComponent();
        }
    }
}
