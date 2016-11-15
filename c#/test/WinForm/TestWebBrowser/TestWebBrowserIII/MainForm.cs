using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace TestWebBrowserIII
{
    public partial class MainForm : Form
    {
        SHDocVw.WebBrowser ax;

        public MainForm()
        {
            InitializeComponent();

            ax = (SHDocVw.WebBrowser) webBrowser.ActiveXInstance;

            ax.DocumentComplete += axDocumentComplete;
            ax.WindowClosing += axWindowClosing;
        }

        void axWindowClosing(bool IsChildWindow, ref bool Cancel)
        {
            Debug.WriteLine("WindowClosing");
        }

        void axDocumentComplete(object pDisp, ref object URL)
        {
            Debug.WriteLine("DocumentComplete");
        }

        private void BtnDoItClick(object sender, EventArgs e)
        {
            webBrowser.Navigate(new Uri("https://errors-db.mtproject.ru/LogText.svc/GetLogTextById?error=6da230b2-6b93-45be-bb4d-fe980bb554c2"));
        }
    }
}
