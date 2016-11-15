using System.Diagnostics;

namespace TestLayout
{
    public partial class MainFormWToolBar : MainForm
    {
        public MainFormWToolBar()
        {
            Debug.WriteLine(string.Format("MainFormWToolBar() ({0})", GetType().Name));
            InitializeComponent();
        }
    }
}
