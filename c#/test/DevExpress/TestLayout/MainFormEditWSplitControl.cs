using System.Diagnostics;

namespace TestLayout
{
    public partial class MainFormEditWSplitControl : MainForm
    {
        public MainFormEditWSplitControl()
        {
            Debug.WriteLine(string.Format("MainFormEditWSplitControl() ({0})", GetType().Name));
            InitializeComponent();
        }
    }
}
