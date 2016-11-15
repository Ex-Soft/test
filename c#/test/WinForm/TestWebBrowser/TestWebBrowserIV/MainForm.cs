using System;
using System.Windows.Forms;

namespace TestWebBrowserIV
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            webBrowser.Document_Complete += WebBrowserDocumentComplete;
            webBrowser.Window_Closing += WebBrowserOnWindowClosing;
            webBrowser.Navigate_Error += WebBrowserNavigateError;
        }

        void WebBrowserNavigateError(object sender, WebBrowserNavigateErrorEventArgs e)
        {
            if (sender != null)
                ;
        }

        void WebBrowserDocumentComplete(object sender, WebBrowserDocumentCompleteEventArgs e)
        {
            if (sender != null)
                ;
        }

        private void WebBrowserOnWindowClosing(object sender, WebBrowserWindowClosingEventArgs windowClosingEventArgs)
        {
            if (sender != null)
                ;
        }

        private void BtnDoItClick(object sender, EventArgs e)
        {
            webBrowser.Navigate(new Uri("https://errors-db.mtproject.ru/LogText.svc/GetLogTextById?error=6da230b2-6b93-45be-bb4d-fe980bb554c2"));
        }
    }
}
