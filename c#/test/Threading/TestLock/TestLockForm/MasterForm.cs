#define USE_CLOSING

using System.Windows.Forms;

namespace TestLockForm
{
    public partial class MasterForm : Form
    {
        Form
            _slaveForm;

        public MasterForm()
        {
            InitializeComponent();
        }

        public void SetSlaveForm(Form form)
        {
            _slaveForm = form;

            #if USE_CLOSING
                _slaveForm.Closing += SlaveFormClosing;
            #endif
        }

        #if USE_CLOSING
            void SlaveFormClosing(object sender, System.ComponentModel.CancelEventArgs e)
            {
                DoIt();
            }
        #endif

        void DoIt()
        {
            System.Diagnostics.Debug.WriteLine("MasterForm.DoIt() (CurrentThread.ManagedThreadId: {0}, CurrentContext.ContextID: {1})", System.Threading.Thread.CurrentThread.ManagedThreadId, System.Threading.Thread.CurrentContext.ContextID);

            #if USE_CLOSING
                _slaveForm.Closing -= SlaveFormClosing;
            #endif

            System.Diagnostics.Debug.WriteLine("MasterForm.DoIt() b4 Sleep");

            lock (_slaveForm)
            {
                System.Threading.Thread.Sleep(5000);
            }

            System.Diagnostics.Debug.WriteLine("MasterForm.DoIt() b4 Sleep");
        }
    }
}
