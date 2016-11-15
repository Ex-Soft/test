using System.Windows.Forms;

namespace TestLockForm
{
    public partial class SlaveForm : Form
    {
        public SlaveForm()
        {
            InitializeComponent();
        }

        void SlaveFormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Closing (CurrentThread.ManagedThreadId: {0}, CurrentContext.ContextID: {1})", System.Threading.Thread.CurrentThread.ManagedThreadId, System.Threading.Thread.CurrentContext.ContextID);
        }

        private void SlaveFormFormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("FormClosing (CurrentThread.ManagedThreadId: {0}, CurrentContext.ContextID: {1})", System.Threading.Thread.CurrentThread.ManagedThreadId, System.Threading.Thread.CurrentContext.ContextID);
        }

        void SlaveFormClosed(object sender, System.EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Closed (CurrentThread.ManagedThreadId: {0}, CurrentContext.ContextID: {1})", System.Threading.Thread.CurrentThread.ManagedThreadId, System.Threading.Thread.CurrentContext.ContextID);
        }

        private void SlaveFormFormClosed(object sender, FormClosedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("FormClosed (CurrentThread.ManagedThreadId: {0}, CurrentContext.ContextID: {1})", System.Threading.Thread.CurrentThread.ManagedThreadId, System.Threading.Thread.CurrentContext.ContextID);
        }

        void SlaveFormDisposed(object sender, System.EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Disposed (CurrentThread.ManagedThreadId: {0}, CurrentContext.ContextID: {1})", System.Threading.Thread.CurrentThread.ManagedThreadId, System.Threading.Thread.CurrentContext.ContextID);
        }
    }
}
