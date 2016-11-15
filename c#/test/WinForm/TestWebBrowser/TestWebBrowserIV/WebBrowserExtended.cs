using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Windows.Forms;

namespace TestWebBrowserIV
{
    [ComImport, SuppressUnmanagedCodeSecurity, InterfaceType(ComInterfaceType.InterfaceIsIDispatch), TypeLibType(TypeLibTypeFlags.FHidden), Guid("34A715A0-6587-11D0-924A-0020AFC7AC4D")]
    public interface DWebBrowserEvents2
    {
        [DispId(0x103)]
        void DocumentComplete([MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In] ref object url);

        [DispId(0x107)]
        void WindowClosing([MarshalAs(UnmanagedType.VariantBool)] bool isChildWindow, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool cancel);

        [DispId(0x10f)]
        void NavigateError([In, MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In] ref object url, [In] ref object frame, [In] ref object statusCode, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool cancel);
    }

    public delegate void WebBrowserDocumentCompleteEventHandler(object sender, WebBrowserDocumentCompleteEventArgs e);

    public class WebBrowserDocumentCompleteEventArgs : EventArgs
    {
        private object _ppDisp;
        private object _url;

        public object PPDisp
        {
            get { return _ppDisp; }
            set { _ppDisp = value; }
        }

        public object Url
        {
            get { return _url; }
            set { _url = value; }
        }

        public WebBrowserDocumentCompleteEventArgs(object ppDisp, object url)
        {
            _ppDisp = ppDisp;
            _url = url;

        }
    }

    public delegate void WebBrowserWindowClosingEventHandler(object sender, WebBrowserWindowClosingEventArgs e);

    public class WebBrowserWindowClosingEventArgs : CancelEventArgs
    {
        private bool _isChildWindow;

        public WebBrowserWindowClosingEventArgs(bool isChildWindow, ref bool cancel) : base(cancel)
        {
            _isChildWindow = isChildWindow;
        }

        public bool IsChildWindow
        {
            get { return _isChildWindow; }
            set { _isChildWindow = value; }
        }
    }

    public delegate void WebBrowserNavigateErrorEventHandler(object sender, WebBrowserNavigateErrorEventArgs e);

    public class WebBrowserNavigateErrorEventArgs : EventArgs
    {
        private String urlValue;
        private String frameValue;
        private Int32 statusCodeValue;
        private Boolean cancelValue;

        public WebBrowserNavigateErrorEventArgs(
            String url, String frame, Int32 statusCode, Boolean cancel)
        {
            urlValue = url;
            frameValue = frame;
            statusCodeValue = statusCode;
            cancelValue = cancel;
        }

        public String Url
        {
            get { return urlValue; }
            set { urlValue = value; }
        }

        public String Frame
        {
            get { return frameValue; }
            set { frameValue = value; }
        }

        public Int32 StatusCode
        {
            get { return statusCodeValue; }
            set { statusCodeValue = value; }
        }

        public Boolean Cancel
        {
            get { return cancelValue; }
            set { cancelValue = value; }
        }
    }

    internal class WebBrowserExtended : WebBrowser
    {
        private AxHost.ConnectionPointCookie _cookie;
        private WebBrowserExtendedEventHelper _helper;

        [PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
        protected override void DestroyHandle()
        {
            base.DestroyHandle();
        }

        [PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
        protected override void OnDocumentCompleted(WebBrowserDocumentCompletedEventArgs e)
        {
            base.OnDocumentCompleted(e);
        }

        [PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
        protected override void CreateSink()
        {
            base.CreateSink();

            // Create an instance of the client that will handle the event 
            // and associate it with the underlying ActiveX control.
            _helper = new WebBrowserExtendedEventHelper(this);
            _cookie = new AxHost.ConnectionPointCookie(ActiveXInstance, _helper, typeof (DWebBrowserEvents2));
        }

        [PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
        protected override void DetachSink()
        {
            // Disconnect the client that handles the event 
            // from the underlying ActiveX control. 
            if (_cookie != null)
            {
                _cookie.Disconnect();
                _cookie = null;
            }
            base.DetachSink();
        }

        public event WebBrowserDocumentCompleteEventHandler Document_Complete;
        public event WebBrowserWindowClosingEventHandler Window_Closing;
        public event WebBrowserNavigateErrorEventHandler Navigate_Error;

        protected virtual void On_DocumentComplete(WebBrowserDocumentCompleteEventArgs e)
        {
            if (Document_Complete != null)
            {
                Document_Complete(this, e);
            }
        }

        protected virtual void On_WindowClosing(WebBrowserWindowClosingEventArgs e)
        {
            if (Window_Closing != null)
            {
                Window_Closing(this, e);
            }
        }
        
        protected virtual void On_NavigateError(WebBrowserNavigateErrorEventArgs e)
        {
            if (Navigate_Error != null)
            {
                Navigate_Error(this, e);
            }
        }

        private class WebBrowserExtendedEventHelper : StandardOleMarshalObject, DWebBrowserEvents2
        {
            private readonly WebBrowserExtended _parent;

            public WebBrowserExtendedEventHelper(WebBrowserExtended parent)
            {
                _parent = parent;
            }

            public void DocumentComplete(object pDisp, ref object url)
            {
                _parent.On_DocumentComplete(new WebBrowserDocumentCompleteEventArgs(pDisp, url));
            }

            public void WindowClosing(bool isChildWindow, ref bool cancel)
            {
                _parent.On_WindowClosing(new WebBrowserWindowClosingEventArgs(isChildWindow, ref cancel));
            }

            public void NavigateError(object pDisp, ref object url, ref object frame, ref object statusCode, ref bool cancel)
            {
                _parent.On_NavigateError(new WebBrowserNavigateErrorEventArgs((String)url, (String)frame, (Int32)statusCode, cancel));
            }
        }
    }
}
