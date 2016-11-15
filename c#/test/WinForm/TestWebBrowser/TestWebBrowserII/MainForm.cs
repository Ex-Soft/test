// https://social.msdn.microsoft.com/Forums/vstudio/en-US/211058d5-f052-49ef-aab5-38baf5b3703e/windowclosing-event-does-not-fire-with-the-webbrowser-control-in-c-20?forum=csharpgeneral
// http://stackoverflow.com/questions/20205688/web-browser-control-detect-when-js-window-close-is-called
// http://stackoverflow.com/questions/19619657/web-browser-to-handle-pop-ups-within-the-application/19673012#19673012
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace TestWebBrowserII
{
    public partial class MainForm : Form
    {
        SHDocVw.WebBrowser ax;

        public MainForm()
        {
            InitializeComponent();

            if (this.webBrowser.Document == null && this.webBrowser.ActiveXInstance == null)
                throw new ApplicationException("Unable to initialize WebBrowser ActiveX control.");

            var ax = (SHDocVw.WebBrowser)this.webBrowser.ActiveXInstance;
            ax.NewWindow2 += (ref object ppDisp, ref bool Cancel) =>
            {
                var popup = new RawBrowserPopup();
                popup.Visible = true;
                ppDisp = popup.WebBrowser.ActiveXInstance;
            };

            this.Load += (s, e) =>
            {
                this.webBrowser.DocumentText = "<a target=\"_blank\" href=\"javascript:'<button onclick=\\'window.close()\\'>Close</button>'\">Go</a>";
            };
        }

        private void BtnDoItClick(object sender, EventArgs e)
        {
            webBrowser.Navigate(new Uri("https://errors-db.mtproject.ru/LogText.svc/GetLogTextById?error=6da230b2-6b93-45be-bb4d-fe980bb554c2"));
        }
    }

    public class RawWebBrowser : AxHost
    {
        public RawWebBrowser()
            : base("8856f961-340a-11d0-a96b-00c04fd705a2")
        {
        }

        public event EventHandler Initialized;

        protected override void AttachInterfaces()
        {
            if (this.Initialized != null)
                this.Initialized(this, new EventArgs());
        }

        public object ActiveXInstance
        {
            get
            {
                return base.GetOcx();
            }
        }
    }

    public class RawBrowserPopup : Form
    {
        RawWebBrowser webBrowser;

        public RawWebBrowser WebBrowser
        {
            get { return this.webBrowser; }
        }

        public RawBrowserPopup()
        {
            this.webBrowser = new RawWebBrowser();

            this.webBrowser.Initialized += (s, e) =>
            {
                var ax = (SHDocVw.WebBrowser)this.webBrowser.ActiveXInstance;
                ax.NewWindow2 += (ref object ppDisp, ref bool Cancel) =>
                {
                    var popup = new RawBrowserPopup();
                    popup.Visible = true;
                    ppDisp = popup.WebBrowser.ActiveXInstance;
                };

                ax.WindowClosing += (bool IsChildWindow, ref bool Cancel) =>
                {
                    Cancel = true;
                    //Close();
                };
            };

            this.webBrowser.Dock = DockStyle.Fill;
            this.Controls.Add(this.webBrowser);
            this.webBrowser.Visible = true;
        }
    }
}
