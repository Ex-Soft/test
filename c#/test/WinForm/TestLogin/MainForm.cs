using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace TestLogin
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainFormLoad(object sender, System.EventArgs e)
        {
            DialogResult result = DialogResult.None;

            using (var loginForm = new LoginForm())
            {
                result = loginForm.ShowDialog();
            }

            if (result != DialogResult.OK)
                Close();
        }

        void MainFormHandleDestroyed(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("MainForm: HandleDestroyed");
        }

        void MainFormFormClosed(object sender, FormClosedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("MainForm: FormClosed");
        }

        void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("MainForm: FormClosing");
        }

        void MainFormClosing(object sender, CancelEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("MainForm: Closing");
        }

        void MainFormClosed(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("MainForm: Closed");
        }

        void MainFormDisposed(object sender, EventArgs e)
        {
            Form form;

            if ((form = sender as Form) != null)
                System.Diagnostics.Debug.WriteLine(string.Format("MainForm: IsDisposed = {0}", form.IsDisposed));

            System.Diagnostics.Debug.WriteLine("MainForm: Disposed");
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("MainForm: OnClosing");
            base.OnClosing(e);
        }

        protected override void OnClosed(EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("MainForm: OnClosed");
            base.OnClosed(e);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("MainForm: OnFormClosing");
            base.OnFormClosing(e);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("MainForm: OnFormClosed");
            base.OnFormClosed(e);
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("MainForm: OnHandleDestroyed");
            base.OnHandleDestroyed(e);
        }
    }
}
