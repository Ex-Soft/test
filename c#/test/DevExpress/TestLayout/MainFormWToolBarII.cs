using System.Diagnostics;

namespace TestLayout
{
    public partial class MainFormWToolBarII : MainForm
    {
        public MainFormWToolBarII()
        {
            Debug.WriteLine(string.Format("MainFormWToolBarII() ({0})", GetType().Name));
            InitializeComponent();
        }
    }
}
