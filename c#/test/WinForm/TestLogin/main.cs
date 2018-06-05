using System;
using System.Windows.Forms;

namespace TestLogin
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DialogResult result = DialogResult.None;

            using (var loginForm = new LoginForm())
            {
                result = loginForm.ShowDialog();
            }

            if (result == DialogResult.OK)
                Application.Run(new MainForm());
        }
    }
}
