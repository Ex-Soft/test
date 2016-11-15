using System.Diagnostics;

namespace TestLayout
{
    public partial class TestInheritedForm : MainFormEdit
    {
        public TestInheritedForm()
        {
            Debug.WriteLine(string.Format("TestInheritedForm() ({0})", GetType().Name));
            InitializeComponent();
        }
    }
}
