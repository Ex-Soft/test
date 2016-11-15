using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace TestWebBrowser
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            webBrowser.NewWindow2 += WebBrowserOnNewWindow2;
            webBrowser.HandleDestroyed += WebBrowserHandleDestroyed;
        }

        void WebBrowserHandleDestroyed(object sender, EventArgs e)
        {
            if (sender != null)
                ;
        }

        private void WebBrowserOnNewWindow2(object sender, NewWindow2EventArgs newWindow2EventArgs)
        {
            newWindow2EventArgs.PPDisp = webBrowser.Application;
        }

        private void BtnDoItClick(object sender, EventArgs e)
        {
            try
            {
                webBrowser.Navigate(new Uri("https://errors-db.mtproject.ru/LogText.svc/GetLogTextById?error=6da230b2-6b93-45be-bb4d-fe980bb554c2"));
            }
            catch (COMException eException)
            {
                if (eException != null)
                {

                }
            }
            catch (ThreadInterruptedException eException)
            {
                if (eException != null)
                {

                }
            }
            catch (ThreadAbortException eException)
            {
                if (eException != null)
                {

                }
            }
            catch (AggregateException eException)
            {
                if (eException != null)
                {
                    
                }
            }
            catch (Exception eException)
            {
                Debug.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
            }
        }

        public void OnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            if (sender != null)
            {
                
            }
        }

        private void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }
    }
}
