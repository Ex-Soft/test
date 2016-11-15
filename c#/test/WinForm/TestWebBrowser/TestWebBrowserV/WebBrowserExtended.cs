using System;
using System.Windows.Forms;

namespace TestWebBrowserV
{
    internal class WebBrowserExtended : WebBrowser
    {
        private const int WM_PARENTNOTIFY = 0x0210;
        private const int WM_DESTROY = 0x0002;

        public event EventHandler Destroy;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_PARENTNOTIFY:
                    if (!DesignMode)
                    {
                        if (m.WParam.ToInt32() == WM_DESTROY)
                        {
                            if (Destroy != null)
                                Destroy(this, EventArgs.Empty);
                        }
                    }
                    DefWndProc(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
    }
}
