using System;
using System.Threading;
using System.Windows.Forms;

namespace TestRestart
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnExitClick(object sender, EventArgs e)
        {
            CloseApplication();
        }

        private void BtnRestartClick(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ExecutablePath);
            CloseApplication();
        }

        void CloseApplication()
        {
            Thread.Sleep(5000);
            Application.Exit();
        }
    }
}
