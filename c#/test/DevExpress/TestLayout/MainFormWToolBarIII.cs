using System.Diagnostics;

namespace TestLayout
{
    public partial class MainFormWToolBarIII : MainForm
    {
        public MainFormWToolBarIII()
        {
            Debug.WriteLine(string.Format("MainFormWToolBarIII() ({0})", GetType().Name));
            InitializeComponent();
        }
    }
}
