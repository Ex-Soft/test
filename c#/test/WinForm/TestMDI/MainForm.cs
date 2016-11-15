#define WITH_DIRECT_DISPOSE
#define WITH_SET_NULL

using System.Diagnostics;
using System.Windows.Forms;

namespace TestMDI
{
    public partial class MainForm : Form
    {
        Form _childForm;

        public MainForm()
        {
            InitializeComponent();
        }

        private void ButtonClick(object sender, System.EventArgs e)
        {
            if (_childForm != null)
            {
                _childForm.Visible = true;
                _childForm.Activate();
                return;
            }

            _childForm = new ChildForm();
            if(_childForm == null)
                return;

            _childForm.FormClosed += ChildFormOnFormClosed;

            _childForm.MdiParent = this;
            _childForm.Show();
        }

        private void ChildFormOnFormClosed(object sender, FormClosedEventArgs formClosedEventArgs)
        {
            Debug.WriteLine("ChildFormOnFormClosed starting...");

            var childForm = sender as Form;
            if (childForm == null)
                return;

            Debug.WriteLine("b4 FormClosed -=");
            _childForm.FormClosed -= ChildFormOnFormClosed;
            Debug.WriteLine("after FormClosed -=");

            #if WITH_DIRECT_DISPOSE
                Debug.WriteLine("b4 _childForm.Dispose()");
                _childForm.Dispose();
                Debug.WriteLine("after _childForm.Dispose()");
            #endif

            #if WITH_SET_NULL
                Debug.WriteLine("b4 _childForm = null");
                _childForm = null;
                Debug.WriteLine("after _childForm = null");
            #endif

            Debug.WriteLine("ChildFormOnFormClosed finished");
        }
    }
}
