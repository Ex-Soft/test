using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Forms;

namespace TestWebBrowserV
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            webBrowser.Disposed += WebBrowserOnDisposed;
            webBrowser.Destroy += WebBrowserOnDestroy;
        }

        private void WebBrowserOnDestroy(object sender, EventArgs eventArgs)
        {
            if (sender != null)
            {
                Control wb;

                if ((wb = sender as Control) != null)
                    pnlFill.Controls.Remove(wb);

                WebBrowserExtended wbe = new WebBrowserExtended();
                wbe.Name = "webBrowser";
                wbe.Dock = DockStyle.Fill;
                wbe.ScriptErrorsSuppressed = true;
                wbe.Url = new Uri("http://google.com.ua/");
                wbe.TabIndex = 0;

                webBrowser = wbe;
                pnlFill.Controls.Add(webBrowser);
            }
        }

        private void WebBrowserOnDisposed(object sender, EventArgs eventArgs)
        {
            if (sender != null)
                ;
        }

        private void BtnSetUrlClick(object sender, EventArgs e)
        {
            webBrowser.Navigate(new Uri("https://errors-db.mtproject.ru/LogText.svc/GetLogTextById?error=6da230b2-6b93-45be-bb4d-fe980bb554c2"));
        }

        private void BtnDisposeClick(object sender, EventArgs e)
        {
            ((IDisposable)webBrowser).Dispose();
        }

        private void BtnTestClick(object sender, EventArgs e)
        {
            Debug.WriteLine(pnlFill.Controls.Count);
            Debug.WriteLine(webBrowser.Disposing);
        }
    }
}
