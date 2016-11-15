using System;
using System.IO;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Xml;
using System.Drawing;

namespace IfacesEnumsStructsClasses
{
    public sealed class Hresults
    {
        public const int NOERROR = 0;
        public const int S_OK = 0;
        public const int S_FALSE = 1;
        public const int E_PENDING = unchecked((int)0x8000000A);
        public const int E_HANDLE = unchecked((int)0x80070006);
        public const int E_NOTIMPL = unchecked((int)0x80004001);
        public const int E_NOINTERFACE = unchecked((int)0x80004002);
        //ArgumentNullException. NullReferenceException uses COR_E_NULLREFERENCE
        public const int E_POINTER = unchecked((int)0x80004003);
        public const int E_ABORT = unchecked((int)0x80004004);
        public const int E_FAIL = unchecked((int)0x80004005);
        public const int E_OUTOFMEMORY = unchecked((int)0x8007000E);
        public const int E_ACCESSDENIED = unchecked((int)0x80070005);
        public const int E_UNEXPECTED = unchecked((int)0x8000FFFF);
        public const int E_FLAGS = unchecked((int)0x1000);
        public const int E_INVALIDARG = unchecked((int)0x80070057);

        //Wininet
        public const int ERROR_SUCCESS = 0;
        public const int ERROR_FILE_NOT_FOUND = 2;
        public const int ERROR_ACCESS_DENIED = 5;
        public const int ERROR_INSUFFICIENT_BUFFER = 122;
        public const int ERROR_NO_MORE_ITEMS = 259;

        //Ole Errors
        public const int OLE_E_FIRST = unchecked((int)0x80040000);
        public const int OLE_E_LAST = unchecked((int)0x800400FF);
        public const int OLE_S_FIRST = unchecked((int)0x00040000);
        public const int OLE_S_LAST = unchecked((int)0x000400FF);
        //OLECMDERR_E_FIRST = 0x80040100
        public const int OLECMDERR_E_FIRST = unchecked((int)(OLE_E_LAST + 1));
        public const int OLECMDERR_E_NOTSUPPORTED = unchecked((int)(OLECMDERR_E_FIRST));
        public const int OLECMDERR_E_DISABLED = unchecked((int)(OLECMDERR_E_FIRST + 1));
        public const int OLECMDERR_E_NOHELP = unchecked((int)(OLECMDERR_E_FIRST + 2));
        public const int OLECMDERR_E_CANCELED = unchecked((int)(OLECMDERR_E_FIRST + 3));
        public const int OLECMDERR_E_UNKNOWNGROUP = unchecked((int)(OLECMDERR_E_FIRST + 4));

        public const int OLEOBJ_E_NOVERBS = unchecked((int)0x80040180);
        public const int OLEOBJ_S_INVALIDVERB = unchecked((int)0x00040180);
        public const int OLEOBJ_S_CANNOT_DOVERB_NOW = unchecked((int)0x00040181);
        public const int OLEOBJ_S_INVALIDHWND = unchecked((int)0x00040182);

        public const int DV_E_LINDEX = unchecked((int)0x80040068);
        public const int OLE_E_OLEVERB = unchecked((int)0x80040000);
        public const int OLE_E_ADVF = unchecked((int)0x80040001);
        public const int OLE_E_ENUM_NOMORE = unchecked((int)0x80040002);
        public const int OLE_E_ADVISENOTSUPPORTED = unchecked((int)0x80040003);
        public const int OLE_E_NOCONNECTION = unchecked((int)0x80040004);
        public const int OLE_E_NOTRUNNING = unchecked((int)0x80040005);
        public const int OLE_E_NOCACHE = unchecked((int)0x80040006);
        public const int OLE_E_BLANK = unchecked((int)0x80040007);
        public const int OLE_E_CLASSDIFF = unchecked((int)0x80040008);
        public const int OLE_E_CANT_GETMONIKER = unchecked((int)0x80040009);
        public const int OLE_E_CANT_BINDTOSOURCE = unchecked((int)0x8004000A);
        public const int OLE_E_STATIC = unchecked((int)0x8004000B);
        public const int OLE_E_PROMPTSAVECANCELLED = unchecked((int)0x8004000C);
        public const int OLE_E_INVALIDRECT = unchecked((int)0x8004000D);
        public const int OLE_E_WRONGCOMPOBJ = unchecked((int)0x8004000E);
        public const int OLE_E_INVALIDHWND = unchecked((int)0x8004000F);
        public const int OLE_E_NOT_INPLACEACTIVE = unchecked((int)0x80040010);
        public const int OLE_E_CANTCONVERT = unchecked((int)0x80040011);
        public const int OLE_E_NOSTORAGE = unchecked((int)0x80040012);
        public const int RPC_E_RETRY = unchecked((int)0x80010109);
    }

    public sealed class Iid_Clsids
    {
        //SID_STopWindow = {49e1b500-4636-11d3-97f7-00c04f45d0b3}
        public static Guid IID_IUnknown = new Guid("00000000-0000-0000-C000-000000000046");
        public static Guid IID_IViewObject = new Guid("0000010d-0000-0000-C000-000000000046");
        public static Guid IID_IAuthenticate = new Guid("79eac9d0-baf9-11ce-8c82-00aa004ba90b");
        public static Guid IID_IWindowForBindingUI = new Guid("79eac9d5-bafa-11ce-8c82-00aa004ba90b");
        public static Guid IID_IHttpSecurity = new Guid("79eac9d7-bafa-11ce-8c82-00aa004ba90b");
        //SID_SNewWindowManager same as IID_INewWindowManager
        public static Guid IID_INewWindowManager = new Guid("D2BC4C84-3F72-4a52-A604-7BCBF3982CBB");
        public static Guid IID_IOleClientSite = new Guid("00000118-0000-0000-C000-000000000046");
        public static Guid IID_IDispatch = new Guid("{00020400-0000-0000-C000-000000000046}");
        public static Guid IID_TopLevelBrowser = new Guid("4C96BE40-915C-11CF-99D3-00AA004AE837");
        public static Guid IID_WebBrowserApp = new Guid("0002DF05-0000-0000-C000-000000000046");
        public static Guid IID_IBinding = new Guid("79EAC9C0-BAF9-11CE-8C82-00AA004BA90B");
        public static Guid IID_IBindStatusCallBack = new Guid("79EAC9C1-BAF9-11CE-8C82-00AA004BA90B");
        public static Guid IID_IOleObject = new Guid("00000112-0000-0000-C000-000000000046");
        public static Guid IID_IOleWindow = new Guid("00000114-0000-0000-C000-000000000046");
        public static Guid IID_IServiceProvider = new Guid("6d5140c1-7436-11ce-8034-00aa006009fa");
        public static Guid IID_IWebBrowser = new Guid("EAB22AC1-30C1-11CF-A7EB-0000C05BAE0B");
        public static Guid IID_IWebBrowser2 = new Guid("D30C1661-CDAF-11d0-8A3E-00C04FC9E26E");
        public static Guid CLSID_WebBrowser = new Guid("8856F961-340A-11D0-A96B-00C04FD705A2");
        public static Guid CLSID_CGI_IWebBrowser = new Guid("ED016940-BD5B-11CF-BA4E-00C04FD70816");
        public static Guid CLSID_CGID_DocHostCommandHandler = new Guid("F38BC242-B950-11D1-8918-00C04FC2C836");
        public static Guid CLSID_ShellUIHelper = new Guid("64AB4BB7-111E-11D1-8F79-00C04FC2FBE1");
        public static Guid CLSID_SecurityManager = new Guid("7b8a2d94-0ac9-11d1-896c-00c04fb6bfc4");
        public static Guid IID_IShellUIHelper = new Guid("729FE2F8-1EA8-11d1-8F85-00C04FC2FBE1");
        public static Guid Guid_MSHTML = new Guid("DE4BA900-59CA-11CF-9592-444553540000");
        public static Guid CLSID_InternetSecurityManager = new Guid("7b8a2d94-0ac9-11d1-896c-00c04fB6bfc4");
        public static Guid IID_IInternetSecurityManager = new Guid("79EAC9EE-BAF9-11CE-8C82-00AA004BA90B");
        public static Guid CLSID_InternetZoneManager = new Guid("7B8A2D95-0AC9-11D1-896C-00C04FB6BFC4");
        public static Guid CGID_ShellDocView = new Guid("000214D1-0000-0000-C000-000000000046");
        //SID_SDownloadManager same as IID
        public static Guid SID_SDownloadManager = new Guid("988934A4-064B-11D3-BB80-00104B35E7F9");
        public static Guid IID_IDownloadManager = new Guid("988934A4-064B-11D3-BB80-00104B35E7F9");
        public static Guid IID_IHttpNegotiate = new Guid("79eac9d2-baf9-11ce-8c82-00aa004ba90b");
        public static Guid IID_IStream = new Guid("0000000c-0000-0000-C000-000000000046");
        public static Guid DIID_HTMLDocumentEvents2 = new Guid("3050f613-98b5-11cf-bb82-00aa00bdce0b");
        public static Guid DIID_HTMLWindowEvents2 = new Guid("3050f625-98b5-11cf-bb82-00aa00bdce0b");
        public static Guid DIID_HTMLElementEvents2 = new Guid("3050f60f-98b5-11cf-bb82-00aa00bdce0b");

        public static Guid IID_IDataObject = new Guid("0000010e-0000-0000-C000-000000000046");

        public static Guid CLSID_InternetShortcut = new Guid("FBF23B40-E3F0-101B-8488-00AA003E56F8");
        public static Guid IID_IUniformResourceLocatorA = new Guid("FBF23B80-E3F0-101B-8488-00AA003E56F8");
        public static Guid IID_IUniformResourceLocatorW = new Guid("CABB0DA0-DA57-11CF-9974-0020AFD79762");
        public static Guid IID_IHTMLBodyElement = new Guid("3050F1D8-98B5-11CF-BB82-00AA00BDCE0B");

        public static Guid CLSID_CUrlHistory = new Guid("3C374A40-BAE4-11CF-BF7D-00AA006946EE");

        public static Guid CLSID_HTMLDocument = new Guid("25336920-03F9-11cf-8FD0-00AA00686F13");
        public static Guid IID_IPropertyNotifySink = new Guid("9BFBBC02-EFF1-101A-84ED-00AA00341D07");

        public static Guid IID_IProtectFocus = new Guid("D81F90A3-8156-44F7-AD28-5ABB87003274");

        public static Guid IID_IHTMLOMWindowServices = new Guid("3050f5fc-98b5-11cf-bb82-00aa00bdce0b");
    }

    public sealed class WinApis
    {
        public const uint MAX_PATH = 512;
        public const uint STGM_READ = 0x00000000;
        public const uint SHDVID_SSLSTATUS = 33;
        public const int GWL_WNDPROC = -4;

        public const short
            //defined inWTypes.h
            // 0 == FALSE, -1 == TRUE
            //typedef short VARIANT_BOOL;
            VAR_TRUE = -1,
            VAR_FALSE = 0;

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr ExtractIcon(IntPtr hInst, string lpszExeFileName, int nIconIndex);

        [DllImport("user32.dll")]
        public static extern bool DestroyIcon(IntPtr hIcon);

        [DllImport("user32", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int CallWindowProc(
            IntPtr lpPrevWndFunc, IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowLong(
            IntPtr hWnd, int nIndex, IntPtr newProc);

        [DllImport("ole32.dll", SetLastError = true,
        ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int RevokeObjectParam(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszKey);

        //[DllImport("urlmon.dll", SetLastError = true)]
        //public static extern int RegisterBindStatusCallback(
        //    [MarshalAs(UnmanagedType.Interface)] IBindCtx pBc,
        //    [MarshalAs(UnmanagedType.Interface)] DownloadManagerImpl.IBindStatusCallback pBSCb,
        //    [Out, MarshalAs(UnmanagedType.Interface)] out IBindStatusCallback ppBSCBPrev,
        //    [In, MarshalAs(UnmanagedType.U4)] UInt32 dwReserved); 

        //[DllImport("user32.dll", SetLastError = true)]
        //public static extern int GetClipboardFormatName(uint format, [Out] StringBuilder
        //   lpszFormatName, int cchMaxCount);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);

        //MSDN
        //This function should no longer be used. Use the CoTaskMemFree and CoTaskMemAlloc functions in its place.
        [DllImport("shell32.dll", SetLastError = true)]
        public static extern int SHGetMalloc(out IMalloc ppMalloc);

        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth,
           int nHeight);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern bool DeleteDC(IntPtr hdc);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern bool DeleteObject(IntPtr hObject);

        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern bool SetStretchBltMode(IntPtr hdc, StretchMode iStretchMode);

        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest,
            int nWidth, int nHeight,
            IntPtr hObjSource, int nXSrc, int nYSrc,
            TernaryRasterOperations dwRop);

        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern bool StretchBlt(IntPtr hdcDest, int nXDest, int nYDest,
            int nWidthDest, int nHeightDest,
            IntPtr hdcSrc, int nXSrc, int nYSrc, int nWidthSrc, int nHeightSrc,
            TernaryRasterOperations dwRop);

        [DllImport("ole32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int CreateBindCtx(
            [MarshalAs(UnmanagedType.U4)] uint dwReserved,
            [Out, MarshalAs(UnmanagedType.Interface)] out IBindCtx ppbc);

        [DllImport("ole32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int CreateAsyncBindCtx(
            [MarshalAs(UnmanagedType.U4)] uint dwReserved,
            [MarshalAs(UnmanagedType.Interface)] IBindStatusCallback pbsc,
            [MarshalAs(UnmanagedType.Interface)] IEnumFORMATETC penumfmtetc,
            [Out, MarshalAs(UnmanagedType.Interface)] out IBindCtx ppbc);

        [DllImport("urlmon.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int CreateURLMoniker(
            [MarshalAs(UnmanagedType.Interface)] IMoniker pmkContext,
            [MarshalAs(UnmanagedType.LPWStr)] string szURL,
            [Out, MarshalAs(UnmanagedType.Interface)] out IMoniker ppmk);

        public const uint URL_MK_LEGACY          = 0;
        public const uint URL_MK_UNIFORM         = 1;
        public const uint URL_MK_NO_CANONICALIZE = 2;
        [DllImport("urlmon.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int CreateURLMonikerEx(
            [MarshalAs(UnmanagedType.Interface)] IMoniker pmkContext,
            [MarshalAs(UnmanagedType.LPWStr)] string szURL,
            [Out, MarshalAs(UnmanagedType.Interface)] out IMoniker ppmk,
            uint URL_MK_XXX); //Flags, one of 

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, uint Msg,
            IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, uint Msg,
            IntPtr wParam, ref StringBuilder lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void SendMessage(HandleRef hWnd, uint msg,
            IntPtr wParam, ref tagRECT lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, uint msg,
            IntPtr wParam, ref tagPOINT lParam);

        [DllImport("ole32.dll", CharSet = CharSet.Auto)]
        public static extern int CreateStreamOnHGlobal(IntPtr hGlobal, bool fDeleteOnRelease,
          [MarshalAs(UnmanagedType.Interface)] out IStream ppstm);

        [DllImport("user32.dll")]
        public static extern short GetKeyState(int nVirtKey);

        [DllImport("ole32.dll", ExactSpelling = true, PreserveSig = false)]
        [return: MarshalAs(UnmanagedType.Interface)]
        public static extern object CoCreateInstance(
           [In, MarshalAs(UnmanagedType.LPStruct)] Guid rclsid,
           [MarshalAs(UnmanagedType.IUnknown)] object pUnkOuter,
           CLSCTX dwClsContext,
           [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);

        //MessageBox(new IntPtr(0), "Text", "Caption", 0 );
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern uint MessageBox(
            IntPtr hWnd, String text, String caption, uint type);

        [DllImport("user32.dll")]
        public static extern bool GetClientRect(IntPtr hWnd, out tagRECT lpRect);

        [DllImport("user32.dll")]
        public static extern bool IsWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool BringWindowToTop(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindow(IntPtr hWnd, uint uCmd);

        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder title, int size);
        
        [DllImport("user32.dll")]
        public static extern uint RealGetWindowClass(IntPtr hWnd, StringBuilder pszType, uint cchType);

        public static string GetWindowName(IntPtr Hwnd)
        {
            if (Hwnd == IntPtr.Zero)
                return string.Empty;
            // This function gets the name of a window from its handle
            StringBuilder Title = new StringBuilder((int)WinApis.MAX_PATH);
            WinApis.GetWindowText(Hwnd, Title, (int)WinApis.MAX_PATH);

            return Title.ToString().Trim();
        }

        public static string GetWindowClass(IntPtr Hwnd)
        {
            if (Hwnd == IntPtr.Zero)
                return string.Empty;
            // This function gets the name of a window class from a window handle
            StringBuilder Title = new StringBuilder((int)WinApis.MAX_PATH);
            WinApis.RealGetWindowClass(Hwnd, Title, (int)WinApis.MAX_PATH);

            return Title.ToString().Trim();
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SetFocus(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool CopyRect(
            [In, Out, MarshalAs(UnmanagedType.Struct)] ref tagRECT lprcDst,
            [In, MarshalAs(UnmanagedType.Struct)] ref tagRECT lprcSrc);

        //[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        //public static extern uint RegisterClipboardFormat(string lpszFormat);

        [DllImport("ole32.dll")]
        public static extern void ReleaseStgMedium(
            [In, MarshalAs(UnmanagedType.Struct)]
            ref System.Runtime.InteropServices.ComTypes.STGMEDIUM pmedium);

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        public static extern uint DragQueryFile(IntPtr hDrop, uint iFile,
           [Out] StringBuilder lpszFile, uint cch);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GlobalLock(IntPtr hMem);

        [DllImport("kernel32.dll")]
        public static extern bool GlobalUnlock(IntPtr hMem);

        [DllImport("kernel32.dll")]
        public static extern UIntPtr GlobalSize(IntPtr hMem);

        [DllImport("Kernel32.dll", SetLastError = true)]
        public static extern long FileTimeToSystemTime(ref FILETIME FileTime, 
            ref SYSTEMTIME SystemTime);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern long SystemTimeToTzSpecificLocalTime(
            IntPtr lpTimeZoneInformation, ref SYSTEMTIME lpUniversalTime, 
            out SYSTEMTIME lpLocalTime);

        [DllImport("wininet.dll", SetLastError = true)]
        public static extern long FindCloseUrlCache(IntPtr hEnumHandle);

        [DllImport("wininet.dll", SetLastError = true)]
        public static extern IntPtr FindFirstUrlCacheEntry(string lpszUrlSearchPattern, IntPtr lpFirstCacheEntryInfo, out UInt32 lpdwFirstCacheEntryInfoBufferSize);

        [DllImport("wininet.dll", SetLastError = true)]
        public static extern long FindNextUrlCacheEntry(IntPtr hEnumHandle, IntPtr lpNextCacheEntryInfo, out UInt32 lpdwNextCacheEntryInfoBufferSize);

        [DllImport("wininet.dll", SetLastError = true)]
        public static extern bool GetUrlCacheEntryInfo(string lpszUrlName, IntPtr lpCacheEntryInfo, out UInt32 lpdwCacheEntryInfoBufferSize);

        [DllImport("wininet.dll", SetLastError = true)]
        public static extern long DeleteUrlCacheEntry(string lpszUrlName);

        [DllImport("wininet.dll", SetLastError = true)]
        public static extern IntPtr RetrieveUrlCacheEntryStream(string lpszUrlName, IntPtr lpCacheEntryInfo, out UInt32 lpdwCacheEntryInfoBufferSize, long fRandomRead, UInt32 dwReserved);

        [DllImport("wininet.dll", SetLastError = true)]
        public static extern IntPtr ReadUrlCacheEntryStream(IntPtr hUrlCacheStream, UInt32 dwLocation, IntPtr lpBuffer, out UInt32 lpdwLen, UInt32 dwReserved);

        [DllImport("wininet.dll", SetLastError = true)]
        public static extern long UnlockUrlCacheEntryStream(IntPtr hUrlCacheStream, UInt32 dwReserved);

        public static FILETIME DateTimeToFiletime(DateTime time)
        {
            FILETIME ft;
            long hFT1 = time.ToFileTimeUtc();
            ft.dwLowDateTime = (uint)(hFT1 & 0xFFFFFFFF);
            ft.dwHighDateTime = (uint)(hFT1 >> 32);
            return ft;
        }

        public static DateTime FiletimeToDateTime(FILETIME fileTime)
        {
            if ((fileTime.dwHighDateTime == Int32.MaxValue) ||
                (fileTime.dwHighDateTime == 0 && fileTime.dwLowDateTime == 0))
            {
                // Not going to fit in the DateTime.  In the WinInet APIs, this is
                // what happens when there is no FILETIME attached to the cache entry.
                // We're going to use DateTime.MinValue as a marker for this case.
                return DateTime.MaxValue;
            }
            //long hFT2 = (((long)fileTime.dwHighDateTime) << 32) + fileTime.dwLowDateTime;
            //return DateTime.FromFileTimeUtc(hFT2);

            SYSTEMTIME syst = new SYSTEMTIME();
            SYSTEMTIME systLocal = new SYSTEMTIME();
            if (0 == FileTimeToSystemTime(ref fileTime, ref syst))
            {
                throw new ApplicationException("Error calling FileTimeToSystemTime: " + Marshal.GetLastWin32Error().ToString());
            }
            if (0 == SystemTimeToTzSpecificLocalTime(IntPtr.Zero, ref syst, out systLocal))
            {
                throw new ApplicationException("Error calling SystemTimeToTzSpecificLocalTime: " + Marshal.GetLastWin32Error().ToString());
            }
            return new DateTime(systLocal.Year, systLocal.Month, systLocal.Day, systLocal.Hour, systLocal.Minute, systLocal.Second);
        }

        public static string ToStringFromFileTime(FILETIME ft)
        {
            DateTime dt = FiletimeToDateTime(ft);
            if (dt == DateTime.MinValue)
            {
                return string.Empty;
            }

            return dt.ToString();
        }

        /// <summary>
        /// UrlCache functionality is taken from:
        /// Scott McMaster (smcmaste@hotmail.com)
        /// CodeProject article
        /// 
        /// There were some issues with preparing URLs
        /// for RegExp to work properly. This is
        /// demonstrated in AllForms.SetupCookieCachePattern method
        /// 
        /// urlPattern:
        /// . Dump the entire contents of the cache.
        /// Cookie: Lists all cookies on the system.
        /// Visited: Lists all of the history items.
        /// Cookie:.*\.example\.com Lists cookies from the example.com domain.
        /// http://www.example.com/example.html$: Lists the specific named file if present
        /// \.example\.com: Lists any and all entries from *.example.com.
        /// \.example\.com.*\.gif$: Lists the .gif files from *.example.com.
        /// \.js$: Lists the .js files in the cache.
        /// </summary>
        /// <param name="urlPattern"></param>
        /// <returns></returns>
        public static ArrayList FindUrlCacheEntries(string urlPattern)
        {            
            ArrayList results = new ArrayList();

            IntPtr buffer = IntPtr.Zero;
            UInt32 structSize;

            //This call will fail but returns the size required in structSize
            //to allocate necessary buffer
            IntPtr hEnum = FindFirstUrlCacheEntry(null, buffer, out structSize);
            try
            {
                if (hEnum == IntPtr.Zero)
                {
                    int lastError = Marshal.GetLastWin32Error();
                    if (lastError == Hresults.ERROR_INSUFFICIENT_BUFFER)
                    {
                        //Allocate buffer
                        buffer = Marshal.AllocHGlobal((int)structSize);
                        //Call again, this time it should succeed
                        hEnum = FindFirstUrlCacheEntry(urlPattern, buffer, out structSize);
                    }
                    else if (lastError == Hresults.ERROR_NO_MORE_ITEMS)
                    {
                        return results;
                    }
                }

                INTERNET_CACHE_ENTRY_INFO result = (INTERNET_CACHE_ENTRY_INFO)Marshal.PtrToStructure(buffer, typeof(INTERNET_CACHE_ENTRY_INFO));
                try
                {
                    if (Regex.IsMatch(result.lpszSourceUrlName, urlPattern, RegexOptions.IgnoreCase))
                    {
                        results.Add(result);
                    }
                }
                catch (ArgumentException ae)
                {
                    throw new ApplicationException("Invalid regular expression, details=" + ae.Message);
                }

                if (buffer != IntPtr.Zero)
                {
                    try { Marshal.FreeHGlobal(buffer); }
                    catch { }
                    buffer = IntPtr.Zero;
                    structSize = 0;
                }

                //Loop through all entries, attempt to find matches
                while (true)
                {
                    long nextResult = FindNextUrlCacheEntry(hEnum, buffer, out structSize);
                    if (nextResult != 1) //TRUE
                    {
                        int lastError = Marshal.GetLastWin32Error();
                        if (lastError == Hresults.ERROR_INSUFFICIENT_BUFFER)
                        {
                            buffer = Marshal.AllocHGlobal((int)structSize);
                            nextResult = FindNextUrlCacheEntry(hEnum, buffer, out structSize);
                        }
                        else if (lastError == Hresults.ERROR_NO_MORE_ITEMS)
                        {
                            break;
                        }
                    }

                    result = (INTERNET_CACHE_ENTRY_INFO)Marshal.PtrToStructure(buffer, typeof(INTERNET_CACHE_ENTRY_INFO));
                    if (Regex.IsMatch(result.lpszSourceUrlName, urlPattern, RegexOptions.IgnoreCase))
                    {
                        results.Add(result);
                    }

                    if (buffer != IntPtr.Zero)
                    {
                        try { Marshal.FreeHGlobal(buffer); }
                        catch { }
                        buffer = IntPtr.Zero;
                        structSize = 0;
                    }
                }
            }
            finally
            {
                if (hEnum != IntPtr.Zero)
                {
                    FindCloseUrlCache(hEnum);
                }
                if (buffer != IntPtr.Zero)
                {
                    try { Marshal.FreeHGlobal(buffer); }
                    catch { }
                }
            }

            return results;
        }

        /// <summary>
        /// Attempts to delete a cookie or cache entry
        /// </summary>
        /// <param name="url">INTERNET_CACHE_ENTRY_INFO.lpszSourceUrlName</param>
        public static void DeleteFromUrlCache(string url)
        {
            long apiResult = DeleteUrlCacheEntry(url);
            if (apiResult != 0)
            {
                return;
            }

            int lastError = Marshal.GetLastWin32Error();
            if (lastError == Hresults.ERROR_ACCESS_DENIED)
            {
                throw new ApplicationException("Access denied: " + url);
            }
            else
            {
                throw new ApplicationException("Insufficient buffer: " + url);
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, 
            IntPtr pvParam, uint fWinIni);

        private const uint SPIF_UPDATEINIFILE = 0x0001;
        private const uint SPIF_SENDWININICHANGE = 0x0002;
        //SPIF_SENDCHANGE       SPIF_SENDWININICHANGE
        private const uint SPI_SETBEEP = 0x0002;

        public static bool SetSystemBeep(bool bEnable)
        {
            if (bEnable)
                return SystemParametersInfo(SPI_SETBEEP, 1, IntPtr.Zero, (SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE));
            else
                return SystemParametersInfo(SPI_SETBEEP, 0, IntPtr.Zero, (SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE));
        }

    }

    /// <summary>
    /// For loading html into document while having the ability to set the baseUrl
    /// Only two methods of IMoniker are called BindToStorage and GetDisplayName
    /// In BindToStorage, we pass a ref to our stream object to be used for loading page
    /// data. In GetDisplayName, we pass our baseUrl to MSHTML to be used.
    /// </summary>
    class LoadHTMLMoniker : IMoniker
    {
        private IStream m_stream = null;
        private string m_sBaseName = string.Empty;

        public void InitLoader(string sContent, string sBaseUrl)
        {
            m_sBaseName = sBaseUrl;
            int hr = WinApis.CreateStreamOnHGlobal(Marshal.StringToHGlobalAuto(sContent), true, out m_stream);
            if ((hr != 0) || (m_stream == null))
                return;
        }

        #region IMoniker Members

        void IMoniker.BindToObject(IBindCtx pbc, IMoniker pmkToLeft, ref Guid riidResult, out object ppvResult)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IMoniker.BindToStorage(IBindCtx pbc, IMoniker pmkToLeft, ref Guid riid, out object ppvObj)
        {
            ppvObj = null;
            if (riid.Equals(Iid_Clsids.IID_IStream))
                ppvObj = (IStream)m_stream;
        }

        void IMoniker.CommonPrefixWith(IMoniker pmkOther, out IMoniker ppmkPrefix)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IMoniker.ComposeWith(IMoniker pmkRight, bool fOnlyIfNotGeneric, out IMoniker ppmkComposite)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IMoniker.Enum(bool fForward, out IEnumMoniker ppenumMoniker)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IMoniker.GetClassID(out Guid pClassID)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IMoniker.GetDisplayName(IBindCtx pbc, IMoniker pmkToLeft, out string ppszDisplayName)
        {
            ppszDisplayName = m_sBaseName;
        }

        void IMoniker.GetSizeMax(out long pcbSize)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IMoniker.GetTimeOfLastChange(IBindCtx pbc, IMoniker pmkToLeft, out System.Runtime.InteropServices.ComTypes.FILETIME pFileTime)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IMoniker.Hash(out int pdwHash)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IMoniker.Inverse(out IMoniker ppmk)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        int IMoniker.IsDirty()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        int IMoniker.IsEqual(IMoniker pmkOtherMoniker)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        int IMoniker.IsRunning(IBindCtx pbc, IMoniker pmkToLeft, IMoniker pmkNewlyRunning)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        int IMoniker.IsSystemMoniker(out int pdwMksys)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IMoniker.Load(IStream pStm)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IMoniker.ParseDisplayName(IBindCtx pbc, IMoniker pmkToLeft, string pszDisplayName, out int pchEaten, out IMoniker ppmkOut)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IMoniker.Reduce(IBindCtx pbc, int dwReduceHowFar, ref IMoniker ppmkToLeft, out IMoniker ppmkReduced)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IMoniker.RelativePathTo(IMoniker pmkOther, out IMoniker ppmkRelPath)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IMoniker.Save(IStream pStm, bool fClearDirty)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }

    public sealed class WindowsMessages
    {
        public const int WM_NULL = 0x0000;
        public const int WM_CREATE = 0x0001;
        public const int WM_DESTROY = 0x0002;
        public const int WM_MOVE = 0x0003;
        public const int WM_SIZE = 0x0005;
        public const int WM_ACTIVATE = 0x0006;
        public const int WM_SETFOCUS = 0x0007;
        public const int WM_KILLFOCUS = 0x0008;
        public const int WM_ENABLE = 0x000A;
        public const int WM_SETREDRAW = 0x000B;
        public const int WM_SETTEXT = 0x000C;
        public const int WM_GETTEXT = 0x000D;
        public const int WM_GETTEXTLENGTH = 0x000E;
        public const int WM_PAINT = 0x000F;
        public const int WM_CLOSE = 0x0010;
        public const int WM_QUERYENDSESSION = 0x0011;
        public const int WM_QUERYOPEN = 0x0013;
        public const int WM_ENDSESSION = 0x0016;
        public const int WM_QUIT = 0x0012;
        public const int WM_ERASEBKGND = 0x0014;
        public const int WM_SYSCOLORCHANGE = 0x0015;
        public const int WM_SHOWWINDOW = 0x0018;
        public const int WM_WININICHANGE = 0x001A;
        public const int WM_SETTINGCHANGE = 0x001A;
        public const int WM_DEVMODECHANGE = 0x001B;
        public const int WM_ACTIVATEAPP = 0x001C;
        public const int WM_FONTCHANGE = 0x001D;
        public const int WM_TIMECHANGE = 0x001E;
        public const int WM_CANCELMODE = 0x001F;
        public const int WM_SETCURSOR = 0x0020;
        public const int WM_MOUSEACTIVATE = 0x0021;
        public const int WM_CHILDACTIVATE = 0x0022;
        public const int WM_QUEUESYNC = 0x0023;
        public const int WM_GETMINMAXINFO = 0x0024;
        public const int WM_PAINTICON = 0x0026;
        public const int WM_ICONERASEBKGND = 0x0027;
        public const int WM_NEXTDLGCTL = 0x0028;
        public const int WM_SPOOLERSTATUS = 0x002A;
        public const int WM_DRAWITEM = 0x002B;
        public const int WM_MEASUREITEM = 0x002C;
        public const int WM_DELETEITEM = 0x002D;
        public const int WM_VKEYTOITEM = 0x002E;
        public const int WM_CHARTOITEM = 0x002F;
        public const int WM_SETFONT = 0x0030;
        public const int WM_GETFONT = 0x0031;
        public const int WM_SETHOTKEY = 0x0032;
        public const int WM_GETHOTKEY = 0x0033;
        public const int WM_QUERYDRAGICON = 0x0037;
        public const int WM_COMPAREITEM = 0x0039;
        public const int WM_GETOBJECT = 0x003D;
        public const int WM_COMPACTING = 0x0041;
        public const int WM_COMMNOTIFY = 0x0044;
        public const int WM_WINDOWPOSCHANGING = 0x0046;
        public const int WM_WINDOWPOSCHANGED = 0x0047;
        public const int WM_POWER = 0x0048;
        public const int WM_COPYDATA = 0x004A;
        public const int WM_CANCELJOURNAL = 0x004B;
        public const int WM_NOTIFY = 0x004E;
        public const int WM_INPUTLANGCHANGEREQUEST = 0x0050;
        public const int WM_INPUTLANGCHANGE = 0x0051;
        public const int WM_TCARD = 0x0052;
        public const int WM_HELP = 0x0053;
        public const int WM_USERCHANGED = 0x0054;
        public const int WM_NOTIFYFORMAT = 0x0055;
        public const int WM_CONTEXTMENU = 0x007B;
        public const int WM_STYLECHANGING = 0x007C;
        public const int WM_STYLECHANGED = 0x007D;
        public const int WM_DISPLAYCHANGE = 0x007E;
        public const int WM_GETICON = 0x007F;
        public const int WM_SETICON = 0x0080;
        public const int WM_NCCREATE = 0x0081;
        public const int WM_NCDESTROY = 0x0082;
        public const int WM_NCCALCSIZE = 0x0083;
        public const int WM_NCHITTEST = 0x0084;
        public const int WM_NCPAINT = 0x0085;
        public const int WM_NCACTIVATE = 0x0086;
        public const int WM_GETDLGCODE = 0x0087;
        public const int WM_SYNCPAINT = 0x0088;
        public const int WM_NCMOUSEMOVE = 0x00A0;
        public const int WM_NCLBUTTONDOWN = 0x00A1;
        public const int WM_NCLBUTTONUP = 0x00A2;
        public const int WM_NCLBUTTONDBLCLK = 0x00A3;
        public const int WM_NCRBUTTONDOWN = 0x00A4;
        public const int WM_NCRBUTTONUP = 0x00A5;
        public const int WM_NCRBUTTONDBLCLK = 0x00A6;
        public const int WM_NCMBUTTONDOWN = 0x00A7;
        public const int WM_NCMBUTTONUP = 0x00A8;
        public const int WM_NCMBUTTONDBLCLK = 0x00A9;
        public const int WM_NCXBUTTONDOWN = 0x00AB;
        public const int WM_NCXBUTTONUP = 0x00AC;
        public const int WM_NCXBUTTONDBLCLK = 0x00AD;
        public const int WM_INPUT = 0x00FF;
        public const int WM_KEYFIRST = 0x0100;
        public const int WM_KEYDOWN = 0x0100;
        public const int WM_KEYUP = 0x0101;
        public const int WM_CHAR = 0x0102;
        public const int WM_DEADCHAR = 0x0103;
        public const int WM_SYSKEYDOWN = 0x0104;
        public const int WM_SYSKEYUP = 0x0105;
        public const int WM_SYSCHAR = 0x0106;
        public const int WM_SYSDEADCHAR = 0x0107;
        public const int WM_UNICHAR = 0x0109;
        public const int WM_KEYLAST_NT501 = 0x0109;
        public const int UNICODE_NOCHAR = 0xFFFF;
        public const int WM_KEYLAST_PRE501 = 0x0108;
        public const int WM_IME_STARTCOMPOSITION = 0x010D;
        public const int WM_IME_ENDCOMPOSITION = 0x010E;
        public const int WM_IME_COMPOSITION = 0x010F;
        public const int WM_IME_KEYLAST = 0x010F;
        public const int WM_INITDIALOG = 0x0110;
        public const int WM_COMMAND = 0x0111;
        public const int WM_SYSCOMMAND = 0x0112;
        public const int WM_TIMER = 0x0113;
        public const int WM_HSCROLL = 0x0114;
        public const int WM_VSCROLL = 0x0115;
        public const int WM_INITMENU = 0x0116;
        public const int WM_INITMENUPOPUP = 0x0117;
        public const int WM_MENUSELECT = 0x011F;
        public const int WM_MENUCHAR = 0x0120;
        public const int WM_ENTERIDLE = 0x0121;
        public const int WM_MENURBUTTONUP = 0x0122;
        public const int WM_MENUDRAG = 0x0123;
        public const int WM_MENUGETOBJECT = 0x0124;
        public const int WM_UNINITMENUPOPUP = 0x0125;
        public const int WM_MENUCOMMAND = 0x0126;
        public const int WM_CHANGEUISTATE = 0x0127;
        public const int WM_UPDATEUISTATE = 0x0128;
        public const int WM_QUERYUISTATE = 0x0129;
        public const int WM_CTLCOLORMSGBOX = 0x0132;
        public const int WM_CTLCOLOREDIT = 0x0133;
        public const int WM_CTLCOLORLISTBOX = 0x0134;
        public const int WM_CTLCOLORBTN = 0x0135;
        public const int WM_CTLCOLORDLG = 0x0136;
        public const int WM_CTLCOLORSCROLLBAR = 0x0137;
        public const int WM_CTLCOLORSTATIC = 0x0138;
        public const int WM_MOUSEFIRST = 0x0200;
        public const int WM_MOUSEMOVE = 0x0200;
        public const int WM_LBUTTONDOWN = 0x0201;
        public const int WM_LBUTTONUP = 0x0202;
        public const int WM_LBUTTONDBLCLK = 0x0203;
        public const int WM_RBUTTONDOWN = 0x0204;
        public const int WM_RBUTTONUP = 0x0205;
        public const int WM_RBUTTONDBLCLK = 0x0206;
        public const int WM_MBUTTONDOWN = 0x0207;
        public const int WM_MBUTTONUP = 0x0208;
        public const int WM_MBUTTONDBLCLK = 0x0209;
        public const int WM_MOUSEWHEEL = 0x020A;
        public const int WM_XBUTTONDOWN = 0x020B;
        public const int WM_XBUTTONUP = 0x020C;
        public const int WM_XBUTTONDBLCLK = 0x020D;
        public const int WM_MOUSELAST_5 = 0x020D;
        public const int WM_MOUSELAST_4 = 0x020A;
        public const int WM_MOUSELAST_PRE_4 = 0x0209;
        public const int WM_PARENTNOTIFY = 0x0210;
        public const int WM_ENTERMENULOOP = 0x0211;
        public const int WM_EXITMENULOOP = 0x0212;
        public const int WM_NEXTMENU = 0x0213;
        public const int WM_SIZING = 0x0214;
        public const int WM_CAPTURECHANGED = 0x0215;
        public const int WM_MOVING = 0x0216;
        public const int WM_POWERBROADCAST = 0x0218;
        public const int WM_DEVICECHANGE = 0x0219;
        public const int WM_MDICREATE = 0x0220;
        public const int WM_MDIDESTROY = 0x0221;
        public const int WM_MDIACTIVATE = 0x0222;
        public const int WM_MDIRESTORE = 0x0223;
        public const int WM_MDINEXT = 0x0224;
        public const int WM_MDIMAXIMIZE = 0x0225;
        public const int WM_MDITILE = 0x0226;
        public const int WM_MDICASCADE = 0x0227;
        public const int WM_MDIICONARRANGE = 0x0228;
        public const int WM_MDIGETACTIVE = 0x0229;
        public const int WM_MDISETMENU = 0x0230;
        public const int WM_ENTERSIZEMOVE = 0x0231;
        public const int WM_EXITSIZEMOVE = 0x0232;
        public const int WM_DROPFILES = 0x0233;
        public const int WM_MDIREFRESHMENU = 0x0234;
        public const int WM_IME_SETCONTEXT = 0x0281;
        public const int WM_IME_NOTIFY = 0x0282;
        public const int WM_IME_CONTROL = 0x0283;
        public const int WM_IME_COMPOSITIONFULL = 0x0284;
        public const int WM_IME_SELECT = 0x0285;
        public const int WM_IME_CHAR = 0x0286;
        public const int WM_IME_REQUEST = 0x0288;
        public const int WM_IME_KEYDOWN = 0x0290;
        public const int WM_IME_KEYUP = 0x0291;
        public const int WM_MOUSEHOVER = 0x02A1;
        public const int WM_MOUSELEAVE = 0x02A3;
        public const int WM_NCMOUSEHOVER = 0x02A0;
        public const int WM_NCMOUSELEAVE = 0x02A2;
        public const int WM_WTSSESSION_CHANGE = 0x02B1;
        public const int WM_TABLET_FIRST = 0x02c0;
        public const int WM_TABLET_LAST = 0x02df;
        public const int WM_CUT = 0x0300;
        public const int WM_COPY = 0x0301;
        public const int WM_PASTE = 0x0302;
        public const int WM_CLEAR = 0x0303;
        public const int WM_UNDO = 0x0304;
        public const int WM_RENDERFORMAT = 0x0305;
        public const int WM_RENDERALLFORMATS = 0x0306;
        public const int WM_DESTROYCLIPBOARD = 0x0307;
        public const int WM_DRAWCLIPBOARD = 0x0308;
        public const int WM_PAINTCLIPBOARD = 0x0309;
        public const int WM_VSCROLLCLIPBOARD = 0x030A;
        public const int WM_SIZECLIPBOARD = 0x030B;
        public const int WM_ASKCBFORMATNAME = 0x030C;
        public const int WM_CHANGECBCHAIN = 0x030D;
        public const int WM_HSCROLLCLIPBOARD = 0x030E;
        public const int WM_QUERYNEWPALETTE = 0x030F;
        public const int WM_PALETTEISCHANGING = 0x0310;
        public const int WM_PALETTECHANGED = 0x0311;
        public const int WM_HOTKEY = 0x0312;
        public const int WM_PRINT = 0x0317;
        public const int WM_PRINTCLIENT = 0x0318;
        public const int WM_APPCOMMAND = 0x0319;
        public const int WM_THEMECHANGED = 0x031A;
        public const int WM_HANDHELDFIRST = 0x0358;
        public const int WM_HANDHELDLAST = 0x035F;
        public const int WM_AFXFIRST = 0x0360;
        public const int WM_AFXLAST = 0x037F;
        public const int WM_PENWINFIRST = 0x0380;
        public const int WM_PENWINLAST = 0x038F;
        public const int WM_APP = 0x8000;
        public const int WM_USER = 0x0400;
        public const int EM_GETSEL = 0x00B0;
        public const int EM_SETSEL = 0x00B1;
        public const int EM_GETRECT = 0x00B2;
        public const int EM_SETRECT = 0x00B3;
        public const int EM_SETRECTNP = 0x00B4;
        public const int EM_SCROLL = 0x00B5;
        public const int EM_LINESCROLL = 0x00B6;
        public const int EM_SCROLLCARET = 0x00B7;
        public const int EM_GETMODIFY = 0x00B8;
        public const int EM_SETMODIFY = 0x00B9;
        public const int EM_GETLINECOUNT = 0x00BA;
        public const int EM_LINEINDEX = 0x00BB;
        public const int EM_SETHANDLE = 0x00BC;
        public const int EM_GETHANDLE = 0x00BD;
        public const int EM_GETTHUMB = 0x00BE;
        public const int EM_LINELENGTH = 0x00C1;
        public const int EM_REPLACESEL = 0x00C2;
        public const int EM_GETLINE = 0x00C4;
        public const int EM_LIMITTEXT = 0x00C5;
        public const int EM_CANUNDO = 0x00C6;
        public const int EM_UNDO = 0x00C7;
        public const int EM_FMTLINES = 0x00C8;
        public const int EM_LINEFROMCHAR = 0x00C9;
        public const int EM_SETTABSTOPS = 0x00CB;
        public const int EM_SETPASSWORDCHAR = 0x00CC;
        public const int EM_EMPTYUNDOBUFFER = 0x00CD;
        public const int EM_GETFIRSTVISIBLELINE = 0x00CE;
        public const int EM_SETREADONLY = 0x00CF;
        public const int EM_SETWORDBREAKPROC = 0x00D0;
        public const int EM_GETWORDBREAKPROC = 0x00D1;
        public const int EM_GETPASSWORDCHAR = 0x00D2;
        public const int EM_SETMARGINS = 0x00D3;
        public const int EM_GETMARGINS = 0x00D4;
        public const int EM_SETLIMITTEXT = EM_LIMITTEXT;
        public const int EM_GETLIMITTEXT = 0x00D5;
        public const int EM_POSFROMCHAR = 0x00D6;
        public const int EM_CHARFROMPOS = 0x00D7;
        public const int EM_SETIMESTATUS = 0x00D8;
        public const int EM_GETIMESTATUS = 0x00D9;
        public const int BM_GETCHECK = 0x00F0;
        public const int BM_SETCHECK = 0x00F1;
        public const int BM_GETSTATE = 0x00F2;
        public const int BM_SETSTATE = 0x00F3;
        public const int BM_SETSTYLE = 0x00F4;
        public const int BM_CLICK = 0x00F5;
        public const int BM_GETIMAGE = 0x00F6;
        public const int BM_SETIMAGE = 0x00F7;
        public const int STM_SETICON = 0x0170;
        public const int STM_GETICON = 0x0171;
        public const int STM_SETIMAGE = 0x0172;
        public const int STM_GETIMAGE = 0x0173;
        public const int STM_MSGMAX = 0x0174;
        public const int DM_GETDEFID = (WM_USER + 0);
        public const int DM_SETDEFID = (WM_USER + 1);
        public const int DM_REPOSITION = (WM_USER + 2);
        public const int LB_ADDSTRING = 0x0180;
        public const int LB_INSERTSTRING = 0x0181;
        public const int LB_DELETESTRING = 0x0182;
        public const int LB_SELITEMRANGEEX = 0x0183;
        public const int LB_RESETCONTENT = 0x0184;
        public const int LB_SETSEL = 0x0185;
        public const int LB_SETCURSEL = 0x0186;
        public const int LB_GETSEL = 0x0187;
        public const int LB_GETCURSEL = 0x0188;
        public const int LB_GETTEXT = 0x0189;
        public const int LB_GETTEXTLEN = 0x018A;
        public const int LB_GETCOUNT = 0x018B;
        public const int LB_SELECTSTRING = 0x018C;
        public const int LB_DIR = 0x018D;
        public const int LB_GETTOPINDEX = 0x018E;
        public const int LB_FINDSTRING = 0x018F;
        public const int LB_GETSELCOUNT = 0x0190;
        public const int LB_GETSELITEMS = 0x0191;
        public const int LB_SETTABSTOPS = 0x0192;
        public const int LB_GETHORIZONTALEXTENT = 0x0193;
        public const int LB_SETHORIZONTALEXTENT = 0x0194;
        public const int LB_SETCOLUMNWIDTH = 0x0195;
        public const int LB_ADDFILE = 0x0196;
        public const int LB_SETTOPINDEX = 0x0197;
        public const int LB_GETITEMRECT = 0x0198;
        public const int LB_GETITEMDATA = 0x0199;
        public const int LB_SETITEMDATA = 0x019A;
        public const int LB_SELITEMRANGE = 0x019B;
        public const int LB_SETANCHORINDEX = 0x019C;
        public const int LB_GETANCHORINDEX = 0x019D;
        public const int LB_SETCARETINDEX = 0x019E;
        public const int LB_GETCARETINDEX = 0x019F;
        public const int LB_SETITEMHEIGHT = 0x01A0;
        public const int LB_GETITEMHEIGHT = 0x01A1;
        public const int LB_FINDSTRINGEXACT = 0x01A2;
        public const int LB_SETLOCALE = 0x01A5;
        public const int LB_GETLOCALE = 0x01A6;
        public const int LB_SETCOUNT = 0x01A7;
        public const int LB_INITSTORAGE = 0x01A8;
        public const int LB_ITEMFROMPOINT = 0x01A9;
        public const int LB_MULTIPLEADDSTRING = 0x01B1;
        public const int LB_GETLISTBOXINFO = 0x01B2;
        public const int LB_MSGMAX_501 = 0x01B3;
        public const int LB_MSGMAX_WCE4 = 0x01B1;
        public const int LB_MSGMAX_4 = 0x01B0;
        public const int LB_MSGMAX_PRE4 = 0x01A8;
        public const int CB_GETEDITSEL = 0x0140;
        public const int CB_LIMITTEXT = 0x0141;
        public const int CB_SETEDITSEL = 0x0142;
        public const int CB_ADDSTRING = 0x0143;
        public const int CB_DELETESTRING = 0x0144;
        public const int CB_DIR = 0x0145;
        public const int CB_GETCOUNT = 0x0146;
        public const int CB_GETCURSEL = 0x0147;
        public const int CB_GETLBTEXT = 0x0148;
        public const int CB_GETLBTEXTLEN = 0x0149;
        public const int CB_INSERTSTRING = 0x014A;
        public const int CB_RESETCONTENT = 0x014B;
        public const int CB_FINDSTRING = 0x014C;
        public const int CB_SELECTSTRING = 0x014D;
        public const int CB_SETCURSEL = 0x014E;
        public const int CB_SHOWDROPDOWN = 0x014F;
        public const int CB_GETITEMDATA = 0x0150;
        public const int CB_SETITEMDATA = 0x0151;
        public const int CB_GETDROPPEDCONTROLRECT = 0x0152;
        public const int CB_SETITEMHEIGHT = 0x0153;
        public const int CB_GETITEMHEIGHT = 0x0154;
        public const int CB_SETEXTENDEDUI = 0x0155;
        public const int CB_GETEXTENDEDUI = 0x0156;
        public const int CB_GETDROPPEDSTATE = 0x0157;
        public const int CB_FINDSTRINGEXACT = 0x0158;
        public const int CB_SETLOCALE = 0x0159;
        public const int CB_GETLOCALE = 0x015A;
        public const int CB_GETTOPINDEX = 0x015B;
        public const int CB_SETTOPINDEX = 0x015C;
        public const int CB_GETHORIZONTALEXTENT = 0x015d;
        public const int CB_SETHORIZONTALEXTENT = 0x015e;
        public const int CB_GETDROPPEDWIDTH = 0x015f;
        public const int CB_SETDROPPEDWIDTH = 0x0160;
        public const int CB_INITSTORAGE = 0x0161;
        public const int CB_MULTIPLEADDSTRING = 0x0163;
        public const int CB_GETCOMBOBOXINFO = 0x0164;
        public const int CB_MSGMAX_501 = 0x0165;
        public const int CB_MSGMAX_WCE400 = 0x0163;
        public const int CB_MSGMAX_400 = 0x0162;
        public const int CB_MSGMAX_PRE400 = 0x015B;
        public const int SBM_SETPOS = 0x00E0;
        public const int SBM_GETPOS = 0x00E1;
        public const int SBM_SETRANGE = 0x00E2;
        public const int SBM_SETRANGEREDRAW = 0x00E6;
        public const int SBM_GETRANGE = 0x00E3;
        public const int SBM_ENABLE_ARROWS = 0x00E4;
        public const int SBM_SETSCROLLINFO = 0x00E9;
        public const int SBM_GETSCROLLINFO = 0x00EA;
        public const int SBM_GETSCROLLBARINFO = 0x00EB;
        public const int LVM_FIRST = 0x1000;// ListView messages
        public const int TV_FIRST = 0x1100;// TreeView messages
        public const int HDM_FIRST = 0x1200;// Header messages
        public const int TCM_FIRST = 0x1300;// Tab control messages
        public const int PGM_FIRST = 0x1400;// Pager control messages
        public const int ECM_FIRST = 0x1500;// Edit control messages
        public const int BCM_FIRST = 0x1600;// Button control messages
        public const int CBM_FIRST = 0x1700;// Combobox control messages
        public const int CCM_FIRST = 0x2000;// Common control shared messages
        public const int CCM_LAST = (CCM_FIRST + 0x200);
        public const int CCM_SETBKCOLOR = (CCM_FIRST + 1);
        public const int CCM_SETCOLORSCHEME = (CCM_FIRST + 2);
        public const int CCM_GETCOLORSCHEME = (CCM_FIRST + 3);
        public const int CCM_GETDROPTARGET = (CCM_FIRST + 4);
        public const int CCM_SETUNICODEFORMAT = (CCM_FIRST + 5);
        public const int CCM_GETUNICODEFORMAT = (CCM_FIRST + 6);
        public const int CCM_SETVERSION = (CCM_FIRST + 0x7);
        public const int CCM_GETVERSION = (CCM_FIRST + 0x8);
        public const int CCM_SETNOTIFYWINDOW = (CCM_FIRST + 0x9);
        public const int CCM_SETWINDOWTHEME = (CCM_FIRST + 0xb);
        public const int CCM_DPISCALE = (CCM_FIRST + 0xc);
        public const int HDM_GETITEMCOUNT = (HDM_FIRST + 0);
        public const int HDM_INSERTITEMA = (HDM_FIRST + 1);
        public const int HDM_INSERTITEMW = (HDM_FIRST + 10);
        public const int HDM_DELETEITEM = (HDM_FIRST + 2);
        public const int HDM_GETITEMA = (HDM_FIRST + 3);
        public const int HDM_GETITEMW = (HDM_FIRST + 11);
        public const int HDM_SETITEMA = (HDM_FIRST + 4);
        public const int HDM_SETITEMW = (HDM_FIRST + 12);
        public const int HDM_LAYOUT = (HDM_FIRST + 5);
        public const int HDM_HITTEST = (HDM_FIRST + 6);
        public const int HDM_GETITEMRECT = (HDM_FIRST + 7);
        public const int HDM_SETIMAGELIST = (HDM_FIRST + 8);
        public const int HDM_GETIMAGELIST = (HDM_FIRST + 9);
        public const int HDM_ORDERTOINDEX = (HDM_FIRST + 15);
        public const int HDM_CREATEDRAGIMAGE = (HDM_FIRST + 16);
        public const int HDM_GETORDERARRAY = (HDM_FIRST + 17);
        public const int HDM_SETORDERARRAY = (HDM_FIRST + 18);
        public const int HDM_SETHOTDIVIDER = (HDM_FIRST + 19);
        public const int HDM_SETBITMAPMARGIN = (HDM_FIRST + 20);
        public const int HDM_GETBITMAPMARGIN = (HDM_FIRST + 21);
        public const int HDM_SETUNICODEFORMAT = CCM_SETUNICODEFORMAT;
        public const int HDM_GETUNICODEFORMAT = CCM_GETUNICODEFORMAT;
        public const int HDM_SETFILTERCHANGETIMEOUT = (HDM_FIRST + 22);
        public const int HDM_EDITFILTER = (HDM_FIRST + 23);
        public const int HDM_CLEARFILTER = (HDM_FIRST + 24);
        public const int TB_ENABLEBUTTON = (WM_USER + 1);
        public const int TB_CHECKBUTTON = (WM_USER + 2);
        public const int TB_PRESSBUTTON = (WM_USER + 3);
        public const int TB_HIDEBUTTON = (WM_USER + 4);
        public const int TB_INDETERMINATE = (WM_USER + 5);
        public const int TB_MARKBUTTON = (WM_USER + 6);
        public const int TB_ISBUTTONENABLED = (WM_USER + 9);
        public const int TB_ISBUTTONCHECKED = (WM_USER + 10);
        public const int TB_ISBUTTONPRESSED = (WM_USER + 11);
        public const int TB_ISBUTTONHIDDEN = (WM_USER + 12);
        public const int TB_ISBUTTONINDETERMINATE = (WM_USER + 13);
        public const int TB_ISBUTTONHIGHLIGHTED = (WM_USER + 14);
        public const int TB_SETSTATE = (WM_USER + 17);
        public const int TB_GETSTATE = (WM_USER + 18);
        public const int TB_ADDBITMAP = (WM_USER + 19);
        public const int TB_ADDBUTTONSA = (WM_USER + 20);
        public const int TB_INSERTBUTTONA = (WM_USER + 21);
        public const int TB_ADDBUTTONS = (WM_USER + 20);
        public const int TB_INSERTBUTTON = (WM_USER + 21);
        public const int TB_DELETEBUTTON = (WM_USER + 22);
        public const int TB_GETBUTTON = (WM_USER + 23);
        public const int TB_BUTTONCOUNT = (WM_USER + 24);
        public const int TB_COMMANDTOINDEX = (WM_USER + 25);
        public const int TB_SAVERESTOREA = (WM_USER + 26);
        public const int TB_SAVERESTOREW = (WM_USER + 76);
        public const int TB_CUSTOMIZE = (WM_USER + 27);
        public const int TB_ADDSTRINGA = (WM_USER + 28);
        public const int TB_ADDSTRINGW = (WM_USER + 77);
        public const int TB_GETITEMRECT = (WM_USER + 29);
        public const int TB_BUTTONSTRUCTSIZE = (WM_USER + 30);
        public const int TB_SETBUTTONSIZE = (WM_USER + 31);
        public const int TB_SETBITMAPSIZE = (WM_USER + 32);
        public const int TB_AUTOSIZE = (WM_USER + 33);
        public const int TB_GETTOOLTIPS = (WM_USER + 35);
        public const int TB_SETTOOLTIPS = (WM_USER + 36);
        public const int TB_SETPARENT = (WM_USER + 37);
        public const int TB_SETROWS = (WM_USER + 39);
        public const int TB_GETROWS = (WM_USER + 40);
        public const int TB_SETCMDID = (WM_USER + 42);
        public const int TB_CHANGEBITMAP = (WM_USER + 43);
        public const int TB_GETBITMAP = (WM_USER + 44);
        public const int TB_GETBUTTONTEXTA = (WM_USER + 45);
        public const int TB_GETBUTTONTEXTW = (WM_USER + 75);
        public const int TB_REPLACEBITMAP = (WM_USER + 46);
        public const int TB_SETINDENT = (WM_USER + 47);
        public const int TB_SETIMAGELIST = (WM_USER + 48);
        public const int TB_GETIMAGELIST = (WM_USER + 49);
        public const int TB_LOADIMAGES = (WM_USER + 50);
        public const int TB_GETRECT = (WM_USER + 51);
        public const int TB_SETHOTIMAGELIST = (WM_USER + 52);
        public const int TB_GETHOTIMAGELIST = (WM_USER + 53);
        public const int TB_SETDISABLEDIMAGELIST = (WM_USER + 54);
        public const int TB_GETDISABLEDIMAGELIST = (WM_USER + 55);
        public const int TB_SETSTYLE = (WM_USER + 56);
        public const int TB_GETSTYLE = (WM_USER + 57);
        public const int TB_GETBUTTONSIZE = (WM_USER + 58);
        public const int TB_SETBUTTONWIDTH = (WM_USER + 59);
        public const int TB_SETMAXTEXTROWS = (WM_USER + 60);
        public const int TB_GETTEXTROWS = (WM_USER + 61);
        public const int TB_GETOBJECT = (WM_USER + 62);
        public const int TB_GETHOTITEM = (WM_USER + 71);
        public const int TB_SETHOTITEM = (WM_USER + 72);
        public const int TB_SETANCHORHIGHLIGHT = (WM_USER + 73);
        public const int TB_GETANCHORHIGHLIGHT = (WM_USER + 74);
        public const int TB_MAPACCELERATORA = (WM_USER + 78);
        public const int TB_GETINSERTMARK = (WM_USER + 79);
        public const int TB_SETINSERTMARK = (WM_USER + 80);
        public const int TB_INSERTMARKHITTEST = (WM_USER + 81);
        public const int TB_MOVEBUTTON = (WM_USER + 82);
        public const int TB_GETMAXSIZE = (WM_USER + 83);
        public const int TB_SETEXTENDEDSTYLE = (WM_USER + 84);
        public const int TB_GETEXTENDEDSTYLE = (WM_USER + 85);
        public const int TB_GETPADDING = (WM_USER + 86);
        public const int TB_SETPADDING = (WM_USER + 87);
        public const int TB_SETINSERTMARKCOLOR = (WM_USER + 88);
        public const int TB_GETINSERTMARKCOLOR = (WM_USER + 89);
        public const int TB_SETCOLORSCHEME = CCM_SETCOLORSCHEME;
        public const int TB_GETCOLORSCHEME = CCM_GETCOLORSCHEME;
        public const int TB_SETUNICODEFORMAT = CCM_SETUNICODEFORMAT;
        public const int TB_GETUNICODEFORMAT = CCM_GETUNICODEFORMAT;
        public const int TB_MAPACCELERATORW = (WM_USER + 90);
        public const int TB_GETBITMAPFLAGS = (WM_USER + 41);
        public const int TB_GETBUTTONINFOW = (WM_USER + 63);
        public const int TB_SETBUTTONINFOW = (WM_USER + 64);
        public const int TB_GETBUTTONINFOA = (WM_USER + 65);
        public const int TB_SETBUTTONINFOA = (WM_USER + 66);
        public const int TB_INSERTBUTTONW = (WM_USER + 67);
        public const int TB_ADDBUTTONSW = (WM_USER + 68);
        public const int TB_HITTEST = (WM_USER + 69);
        public const int TB_SETDRAWTEXTFLAGS = (WM_USER + 70);
        public const int TB_GETSTRINGW = (WM_USER + 91);
        public const int TB_GETSTRINGA = (WM_USER + 92);
        public const int TB_GETMETRICS = (WM_USER + 101);
        public const int TB_SETMETRICS = (WM_USER + 102);
        public const int TB_SETWINDOWTHEME = CCM_SETWINDOWTHEME;
        public const int RB_INSERTBANDA = (WM_USER + 1);
        public const int RB_DELETEBAND = (WM_USER + 2);
        public const int RB_GETBARINFO = (WM_USER + 3);
        public const int RB_SETBARINFO = (WM_USER + 4);
        public const int RB_GETBANDINFO = (WM_USER + 5);
        public const int RB_SETBANDINFOA = (WM_USER + 6);
        public const int RB_SETPARENT = (WM_USER + 7);
        public const int RB_HITTEST = (WM_USER + 8);
        public const int RB_GETRECT = (WM_USER + 9);
        public const int RB_INSERTBANDW = (WM_USER + 10);
        public const int RB_SETBANDINFOW = (WM_USER + 11);
        public const int RB_GETBANDCOUNT = (WM_USER + 12);
        public const int RB_GETROWCOUNT = (WM_USER + 13);
        public const int RB_GETROWHEIGHT = (WM_USER + 14);
        public const int RB_IDTOINDEX = (WM_USER + 16);
        public const int RB_GETTOOLTIPS = (WM_USER + 17);
        public const int RB_SETTOOLTIPS = (WM_USER + 18);
        public const int RB_SETBKCOLOR = (WM_USER + 19);
        public const int RB_GETBKCOLOR = (WM_USER + 20);
        public const int RB_SETTEXTCOLOR = (WM_USER + 21);
        public const int RB_GETTEXTCOLOR = (WM_USER + 22);
        public const int RB_SIZETORECT = (WM_USER + 23);
        public const int RB_SETCOLORSCHEME = CCM_SETCOLORSCHEME;
        public const int RB_GETCOLORSCHEME = CCM_GETCOLORSCHEME;
        public const int RB_BEGINDRAG = (WM_USER + 24);
        public const int RB_ENDDRAG = (WM_USER + 25);
        public const int RB_DRAGMOVE = (WM_USER + 26);
        public const int RB_GETBARHEIGHT = (WM_USER + 27);
        public const int RB_GETBANDINFOW = (WM_USER + 28);
        public const int RB_GETBANDINFOA = (WM_USER + 29);
        public const int RB_MINIMIZEBAND = (WM_USER + 30);
        public const int RB_MAXIMIZEBAND = (WM_USER + 31);
        public const int RB_GETDROPTARGET = (CCM_GETDROPTARGET);
        public const int RB_GETBANDBORDERS = (WM_USER + 34);
        public const int RB_SHOWBAND = (WM_USER + 35);
        public const int RB_SETPALETTE = (WM_USER + 37);
        public const int RB_GETPALETTE = (WM_USER + 38);
        public const int RB_MOVEBAND = (WM_USER + 39);
        public const int RB_SETUNICODEFORMAT = CCM_SETUNICODEFORMAT;
        public const int RB_GETUNICODEFORMAT = CCM_GETUNICODEFORMAT;
        public const int RB_GETBANDMARGINS = (WM_USER + 40);
        public const int RB_SETWINDOWTHEME = CCM_SETWINDOWTHEME;
        public const int RB_PUSHCHEVRON = (WM_USER + 43);
        public const int TTM_ACTIVATE = (WM_USER + 1);
        public const int TTM_SETDELAYTIME = (WM_USER + 3);
        public const int TTM_ADDTOOLA = (WM_USER + 4);
        public const int TTM_ADDTOOLW = (WM_USER + 50);
        public const int TTM_DELTOOLA = (WM_USER + 5);
        public const int TTM_DELTOOLW = (WM_USER + 51);
        public const int TTM_NEWTOOLRECTA = (WM_USER + 6);
        public const int TTM_NEWTOOLRECTW = (WM_USER + 52);
        public const int TTM_RELAYEVENT = (WM_USER + 7);
        public const int TTM_GETTOOLINFOA = (WM_USER + 8);
        public const int TTM_GETTOOLINFOW = (WM_USER + 53);
        public const int TTM_SETTOOLINFOA = (WM_USER + 9);
        public const int TTM_SETTOOLINFOW = (WM_USER + 54);
        public const int TTM_HITTESTA = (WM_USER + 10);
        public const int TTM_HITTESTW = (WM_USER + 55);
        public const int TTM_GETTEXTA = (WM_USER + 11);
        public const int TTM_GETTEXTW = (WM_USER + 56);
        public const int TTM_UPDATETIPTEXTA = (WM_USER + 12);
        public const int TTM_UPDATETIPTEXTW = (WM_USER + 57);
        public const int TTM_GETTOOLCOUNT = (WM_USER + 13);
        public const int TTM_ENUMTOOLSA = (WM_USER + 14);
        public const int TTM_ENUMTOOLSW = (WM_USER + 58);
        public const int TTM_GETCURRENTTOOLA = (WM_USER + 15);
        public const int TTM_GETCURRENTTOOLW = (WM_USER + 59);
        public const int TTM_WINDOWFROMPOINT = (WM_USER + 16);
        public const int TTM_TRACKACTIVATE = (WM_USER + 17);
        public const int TTM_TRACKPOSITION = (WM_USER + 18);
        public const int TTM_SETTIPBKCOLOR = (WM_USER + 19);
        public const int TTM_SETTIPTEXTCOLOR = (WM_USER + 20);
        public const int TTM_GETDELAYTIME = (WM_USER + 21);
        public const int TTM_GETTIPBKCOLOR = (WM_USER + 22);
        public const int TTM_GETTIPTEXTCOLOR = (WM_USER + 23);
        public const int TTM_SETMAXTIPWIDTH = (WM_USER + 24);
        public const int TTM_GETMAXTIPWIDTH = (WM_USER + 25);
        public const int TTM_SETMARGIN = (WM_USER + 26);
        public const int TTM_GETMARGIN = (WM_USER + 27);
        public const int TTM_POP = (WM_USER + 28);
        public const int TTM_UPDATE = (WM_USER + 29);
        public const int TTM_GETBUBBLESIZE = (WM_USER + 30);
        public const int TTM_ADJUSTRECT = (WM_USER + 31);
        public const int TTM_SETTITLEA = (WM_USER + 32);
        public const int TTM_SETTITLEW = (WM_USER + 33);
        public const int TTM_POPUP = (WM_USER + 34);
        public const int TTM_GETTITLE = (WM_USER + 35);
        public const int TTM_SETWINDOWTHEME = CCM_SETWINDOWTHEME;
        public const int SB_SETTEXTA = (WM_USER + 1);
        public const int SB_SETTEXTW = (WM_USER + 11);
        public const int SB_GETTEXTA = (WM_USER + 2);
        public const int SB_GETTEXTW = (WM_USER + 13);
        public const int SB_GETTEXTLENGTHA = (WM_USER + 3);
        public const int SB_GETTEXTLENGTHW = (WM_USER + 12);
        public const int SB_SETPARTS = (WM_USER + 4);
        public const int SB_GETPARTS = (WM_USER + 6);
        public const int SB_GETBORDERS = (WM_USER + 7);
        public const int SB_SETMINHEIGHT = (WM_USER + 8);
        public const int SB_SIMPLE = (WM_USER + 9);
        public const int SB_GETRECT = (WM_USER + 10);
        public const int SB_ISSIMPLE = (WM_USER + 14);
        public const int SB_SETICON = (WM_USER + 15);
        public const int SB_SETTIPTEXTA = (WM_USER + 16);
        public const int SB_SETTIPTEXTW = (WM_USER + 17);
        public const int SB_GETTIPTEXTA = (WM_USER + 18);
        public const int SB_GETTIPTEXTW = (WM_USER + 19);
        public const int SB_GETICON = (WM_USER + 20);
        public const int SB_SETUNICODEFORMAT = CCM_SETUNICODEFORMAT;
        public const int SB_GETUNICODEFORMAT = CCM_GETUNICODEFORMAT;
        public const int SB_SETBKCOLOR = CCM_SETBKCOLOR;
        public const int SB_SIMPLEID = 0x00ff;
        public const int TBM_GETPOS = (WM_USER);
        public const int TBM_GETRANGEMIN = (WM_USER + 1);
        public const int TBM_GETRANGEMAX = (WM_USER + 2);
        public const int TBM_GETTIC = (WM_USER + 3);
        public const int TBM_SETTIC = (WM_USER + 4);
        public const int TBM_SETPOS = (WM_USER + 5);
        public const int TBM_SETRANGE = (WM_USER + 6);
        public const int TBM_SETRANGEMIN = (WM_USER + 7);
        public const int TBM_SETRANGEMAX = (WM_USER + 8);
        public const int TBM_CLEARTICS = (WM_USER + 9);
        public const int TBM_SETSEL = (WM_USER + 10);
        public const int TBM_SETSELSTART = (WM_USER + 11);
        public const int TBM_SETSELEND = (WM_USER + 12);
        public const int TBM_GETPTICS = (WM_USER + 14);
        public const int TBM_GETTICPOS = (WM_USER + 15);
        public const int TBM_GETNUMTICS = (WM_USER + 16);
        public const int TBM_GETSELSTART = (WM_USER + 17);
        public const int TBM_GETSELEND = (WM_USER + 18);
        public const int TBM_CLEARSEL = (WM_USER + 19);
        public const int TBM_SETTICFREQ = (WM_USER + 20);
        public const int TBM_SETPAGESIZE = (WM_USER + 21);
        public const int TBM_GETPAGESIZE = (WM_USER + 22);
        public const int TBM_SETLINESIZE = (WM_USER + 23);
        public const int TBM_GETLINESIZE = (WM_USER + 24);
        public const int TBM_GETTHUMBRECT = (WM_USER + 25);
        public const int TBM_GETCHANNELRECT = (WM_USER + 26);
        public const int TBM_SETTHUMBLENGTH = (WM_USER + 27);
        public const int TBM_GETTHUMBLENGTH = (WM_USER + 28);
        public const int TBM_SETTOOLTIPS = (WM_USER + 29);
        public const int TBM_GETTOOLTIPS = (WM_USER + 30);
        public const int TBM_SETTIPSIDE = (WM_USER + 31);
        public const int TBM_SETBUDDY = (WM_USER + 32);
        public const int TBM_GETBUDDY = (WM_USER + 33);
        public const int TBM_SETUNICODEFORMAT = CCM_SETUNICODEFORMAT;
        public const int TBM_GETUNICODEFORMAT = CCM_GETUNICODEFORMAT;
        public const int DL_BEGINDRAG = (WM_USER + 133);
        public const int DL_DRAGGING = (WM_USER + 134);
        public const int DL_DROPPED = (WM_USER + 135);
        public const int DL_CANCELDRAG = (WM_USER + 136);
        public const int UDM_SETRANGE = (WM_USER + 101);
        public const int UDM_GETRANGE = (WM_USER + 102);
        public const int UDM_SETPOS = (WM_USER + 103);
        public const int UDM_GETPOS = (WM_USER + 104);
        public const int UDM_SETBUDDY = (WM_USER + 105);
        public const int UDM_GETBUDDY = (WM_USER + 106);
        public const int UDM_SETACCEL = (WM_USER + 107);
        public const int UDM_GETACCEL = (WM_USER + 108);
        public const int UDM_SETBASE = (WM_USER + 109);
        public const int UDM_GETBASE = (WM_USER + 110);
        public const int UDM_SETRANGE32 = (WM_USER + 111);
        public const int UDM_GETRANGE32 = (WM_USER + 112);
        public const int UDM_SETUNICODEFORMAT = CCM_SETUNICODEFORMAT;
        public const int UDM_GETUNICODEFORMAT = CCM_GETUNICODEFORMAT;
        public const int UDM_SETPOS32 = (WM_USER + 113);
        public const int UDM_GETPOS32 = (WM_USER + 114);
        public const int PBM_SETRANGE = (WM_USER + 1);
        public const int PBM_SETPOS = (WM_USER + 2);
        public const int PBM_DELTAPOS = (WM_USER + 3);
        public const int PBM_SETSTEP = (WM_USER + 4);
        public const int PBM_STEPIT = (WM_USER + 5);
        public const int PBM_SETRANGE32 = (WM_USER + 6);
        public const int PBM_GETRANGE = (WM_USER + 7);
        public const int PBM_GETPOS = (WM_USER + 8);
        public const int PBM_SETBARCOLOR = (WM_USER + 9);
        public const int PBM_SETBKCOLOR = CCM_SETBKCOLOR;
        public const int HKM_SETHOTKEY = (WM_USER + 1);
        public const int HKM_GETHOTKEY = (WM_USER + 2);
        public const int HKM_SETRULES = (WM_USER + 3);
        public const int LVM_SETUNICODEFORMAT = CCM_SETUNICODEFORMAT;
        public const int LVM_GETUNICODEFORMAT = CCM_GETUNICODEFORMAT;
        public const int LVM_GETBKCOLOR = (LVM_FIRST + 0);
        public const int LVM_SETBKCOLOR = (LVM_FIRST + 1);
        public const int LVM_GETIMAGELIST = (LVM_FIRST + 2);
        public const int LVM_SETIMAGELIST = (LVM_FIRST + 3);
        public const int LVM_GETITEMCOUNT = (LVM_FIRST + 4);
        public const int LVM_GETITEMA = (LVM_FIRST + 5);
        public const int LVM_GETITEMW = (LVM_FIRST + 75);
        public const int LVM_SETITEMA = (LVM_FIRST + 6);
        public const int LVM_SETITEMW = (LVM_FIRST + 76);
        public const int LVM_INSERTITEMA = (LVM_FIRST + 7);
        public const int LVM_INSERTITEMW = (LVM_FIRST + 77);
        public const int LVM_DELETEITEM = (LVM_FIRST + 8);
        public const int LVM_DELETEALLITEMS = (LVM_FIRST + 9);
        public const int LVM_GETCALLBACKMASK = (LVM_FIRST + 10);
        public const int LVM_SETCALLBACKMASK = (LVM_FIRST + 11);
        public const int LVM_FINDITEMA = (LVM_FIRST + 13);
        public const int LVM_FINDITEMW = (LVM_FIRST + 83);
        public const int LVM_GETITEMRECT = (LVM_FIRST + 14);
        public const int LVM_SETITEMPOSITION = (LVM_FIRST + 15);
        public const int LVM_GETITEMPOSITION = (LVM_FIRST + 16);
        public const int LVM_GETSTRINGWIDTHA = (LVM_FIRST + 17);
        public const int LVM_GETSTRINGWIDTHW = (LVM_FIRST + 87);
        public const int LVM_HITTEST = (LVM_FIRST + 18);
        public const int LVM_ENSUREVISIBLE = (LVM_FIRST + 19);
        public const int LVM_SCROLL = (LVM_FIRST + 20);
        public const int LVM_REDRAWITEMS = (LVM_FIRST + 21);
        public const int LVM_ARRANGE = (LVM_FIRST + 22);
        public const int LVM_EDITLABELA = (LVM_FIRST + 23);
        public const int LVM_EDITLABELW = (LVM_FIRST + 118);
        public const int LVM_GETEDITCONTROL = (LVM_FIRST + 24);
        public const int LVM_GETCOLUMNA = (LVM_FIRST + 25);
        public const int LVM_GETCOLUMNW = (LVM_FIRST + 95);
        public const int LVM_SETCOLUMNA = (LVM_FIRST + 26);
        public const int LVM_SETCOLUMNW = (LVM_FIRST + 96);
        public const int LVM_INSERTCOLUMNA = (LVM_FIRST + 27);
        public const int LVM_INSERTCOLUMNW = (LVM_FIRST + 97);
        public const int LVM_DELETECOLUMN = (LVM_FIRST + 28);
        public const int LVM_GETCOLUMNWIDTH = (LVM_FIRST + 29);
        public const int LVM_SETCOLUMNWIDTH = (LVM_FIRST + 30);
        public const int LVM_CREATEDRAGIMAGE = (LVM_FIRST + 33);
        public const int LVM_GETVIEWRECT = (LVM_FIRST + 34);
        public const int LVM_GETTEXTCOLOR = (LVM_FIRST + 35);
        public const int LVM_SETTEXTCOLOR = (LVM_FIRST + 36);
        public const int LVM_GETTEXTBKCOLOR = (LVM_FIRST + 37);
        public const int LVM_SETTEXTBKCOLOR = (LVM_FIRST + 38);
        public const int LVM_GETTOPINDEX = (LVM_FIRST + 39);
        public const int LVM_GETCOUNTPERPAGE = (LVM_FIRST + 40);
        public const int LVM_GETORIGIN = (LVM_FIRST + 41);
        public const int LVM_UPDATE = (LVM_FIRST + 42);
        public const int LVM_SETITEMSTATE = (LVM_FIRST + 43);
        public const int LVM_GETITEMSTATE = (LVM_FIRST + 44);
        public const int LVM_GETITEMTEXTA = (LVM_FIRST + 45);
        public const int LVM_GETITEMTEXTW = (LVM_FIRST + 115);
        public const int LVM_SETITEMTEXTA = (LVM_FIRST + 46);
        public const int LVM_SETITEMTEXTW = (LVM_FIRST + 116);
        public const int LVM_SETITEMCOUNT = (LVM_FIRST + 47);
        public const int LVM_SORTITEMS = (LVM_FIRST + 48);
        public const int LVM_SETITEMPOSITION32 = (LVM_FIRST + 49);
        public const int LVM_GETSELECTEDCOUNT = (LVM_FIRST + 50);
        public const int LVM_GETITEMSPACING = (LVM_FIRST + 51);
        public const int LVM_GETISEARCHSTRINGA = (LVM_FIRST + 52);
        public const int LVM_GETISEARCHSTRINGW = (LVM_FIRST + 117);
        public const int LVM_SETICONSPACING = (LVM_FIRST + 53);
        public const int LVM_SETEXTENDEDLISTVIEWSTYLE = (LVM_FIRST + 54);
        public const int LVM_GETEXTENDEDLISTVIEWSTYLE = (LVM_FIRST + 55);
        public const int LVM_GETSUBITEMRECT = (LVM_FIRST + 56);
        public const int LVM_SUBITEMHITTEST = (LVM_FIRST + 57);
        public const int LVM_SETCOLUMNORDERARRAY = (LVM_FIRST + 58);
        public const int LVM_GETCOLUMNORDERARRAY = (LVM_FIRST + 59);
        public const int LVM_SETHOTITEM = (LVM_FIRST + 60);
        public const int LVM_GETHOTITEM = (LVM_FIRST + 61);
        public const int LVM_SETHOTCURSOR = (LVM_FIRST + 62);
        public const int LVM_GETHOTCURSOR = (LVM_FIRST + 63);
        public const int LVM_APPROXIMATEVIEWRECT = (LVM_FIRST + 64);
        public const int LVM_SETWORKAREAS = (LVM_FIRST + 65);
        public const int LVM_GETWORKAREAS = (LVM_FIRST + 70);
        public const int LVM_GETNUMBEROFWORKAREAS = (LVM_FIRST + 73);
        public const int LVM_GETSELECTIONMARK = (LVM_FIRST + 66);
        public const int LVM_SETSELECTIONMARK = (LVM_FIRST + 67);
        public const int LVM_SETHOVERTIME = (LVM_FIRST + 71);
        public const int LVM_GETHOVERTIME = (LVM_FIRST + 72);
        public const int LVM_SETTOOLTIPS = (LVM_FIRST + 74);
        public const int LVM_GETTOOLTIPS = (LVM_FIRST + 78);
        public const int LVM_SORTITEMSEX = (LVM_FIRST + 81);
        public const int LVM_SETBKIMAGEA = (LVM_FIRST + 68);
        public const int LVM_SETBKIMAGEW = (LVM_FIRST + 138);
        public const int LVM_GETBKIMAGEA = (LVM_FIRST + 69);
        public const int LVM_GETBKIMAGEW = (LVM_FIRST + 139);
        public const int LVM_SETSELECTEDCOLUMN = (LVM_FIRST + 140);
        public const int LVM_SETTILEWIDTH = (LVM_FIRST + 141);
        public const int LVM_SETVIEW = (LVM_FIRST + 142);
        public const int LVM_GETVIEW = (LVM_FIRST + 143);
        public const int LVM_INSERTGROUP = (LVM_FIRST + 145);
        public const int LVM_SETGROUPINFO = (LVM_FIRST + 147);
        public const int LVM_GETGROUPINFO = (LVM_FIRST + 149);
        public const int LVM_REMOVEGROUP = (LVM_FIRST + 150);
        public const int LVM_MOVEGROUP = (LVM_FIRST + 151);
        public const int LVM_MOVEITEMTOGROUP = (LVM_FIRST + 154);
        public const int LVM_SETGROUPMETRICS = (LVM_FIRST + 155);
        public const int LVM_GETGROUPMETRICS = (LVM_FIRST + 156);
        public const int LVM_ENABLEGROUPVIEW = (LVM_FIRST + 157);
        public const int LVM_SORTGROUPS = (LVM_FIRST + 158);
        public const int LVM_INSERTGROUPSORTED = (LVM_FIRST + 159);
        public const int LVM_REMOVEALLGROUPS = (LVM_FIRST + 160);
        public const int LVM_HASGROUP = (LVM_FIRST + 161);
        public const int LVM_SETTILEVIEWINFO = (LVM_FIRST + 162);
        public const int LVM_GETTILEVIEWINFO = (LVM_FIRST + 163);
        public const int LVM_SETTILEINFO = (LVM_FIRST + 164);
        public const int LVM_GETTILEINFO = (LVM_FIRST + 165);
        public const int LVM_SETINSERTMARK = (LVM_FIRST + 166);
        public const int LVM_GETINSERTMARK = (LVM_FIRST + 167);
        public const int LVM_INSERTMARKHITTEST = (LVM_FIRST + 168);
        public const int LVM_GETINSERTMARKRECT = (LVM_FIRST + 169);
        public const int LVM_SETINSERTMARKCOLOR = (LVM_FIRST + 170);
        public const int LVM_GETINSERTMARKCOLOR = (LVM_FIRST + 171);
        public const int LVM_SETINFOTIP = (LVM_FIRST + 173);
        public const int LVM_GETSELECTEDCOLUMN = (LVM_FIRST + 174);
        public const int LVM_ISGROUPVIEWENABLED = (LVM_FIRST + 175);
        public const int LVM_GETOUTLINECOLOR = (LVM_FIRST + 176);
        public const int LVM_SETOUTLINECOLOR = (LVM_FIRST + 177);
        public const int LVM_CANCELEDITLABEL = (LVM_FIRST + 179);
        public const int LVM_MAPINDEXTOID = (LVM_FIRST + 180);
        public const int LVM_MAPIDTOINDEX = (LVM_FIRST + 181);
        public const int TVM_INSERTITEMA = (TV_FIRST + 0);
        public const int TVM_INSERTITEMW = (TV_FIRST + 50);
        public const int TVM_DELETEITEM = (TV_FIRST + 1);
        public const int TVM_EXPAND = (TV_FIRST + 2);
        public const int TVM_GETITEMRECT = (TV_FIRST + 4);
        public const int TVM_GETCOUNT = (TV_FIRST + 5);
        public const int TVM_GETINDENT = (TV_FIRST + 6);
        public const int TVM_SETINDENT = (TV_FIRST + 7);
        public const int TVM_GETIMAGELIST = (TV_FIRST + 8);
        public const int TVM_SETIMAGELIST = (TV_FIRST + 9);
        public const int TVM_GETNEXTITEM = (TV_FIRST + 10);
        public const int TVM_SELECTITEM = (TV_FIRST + 11);
        public const int TVM_GETITEMA = (TV_FIRST + 12);
        public const int TVM_GETITEMW = (TV_FIRST + 62);
        public const int TVM_SETITEMA = (TV_FIRST + 13);
        public const int TVM_SETITEMW = (TV_FIRST + 63);
        public const int TVM_EDITLABELA = (TV_FIRST + 14);
        public const int TVM_EDITLABELW = (TV_FIRST + 65);
        public const int TVM_GETEDITCONTROL = (TV_FIRST + 15);
        public const int TVM_GETVISIBLECOUNT = (TV_FIRST + 16);
        public const int TVM_HITTEST = (TV_FIRST + 17);
        public const int TVM_CREATEDRAGIMAGE = (TV_FIRST + 18);
        public const int TVM_SORTCHILDREN = (TV_FIRST + 19);
        public const int TVM_ENSUREVISIBLE = (TV_FIRST + 20);
        public const int TVM_SORTCHILDRENCB = (TV_FIRST + 21);
        public const int TVM_ENDEDITLABELNOW = (TV_FIRST + 22);
        public const int TVM_GETISEARCHSTRINGA = (TV_FIRST + 23);
        public const int TVM_GETISEARCHSTRINGW = (TV_FIRST + 64);
        public const int TVM_SETTOOLTIPS = (TV_FIRST + 24);
        public const int TVM_GETTOOLTIPS = (TV_FIRST + 25);
        public const int TVM_SETINSERTMARK = (TV_FIRST + 26);
        public const int TVM_SETUNICODEFORMAT = CCM_SETUNICODEFORMAT;
        public const int TVM_GETUNICODEFORMAT = CCM_GETUNICODEFORMAT;
        public const int TVM_SETITEMHEIGHT = (TV_FIRST + 27);
        public const int TVM_GETITEMHEIGHT = (TV_FIRST + 28);
        public const int TVM_SETBKCOLOR = (TV_FIRST + 29);
        public const int TVM_SETTEXTCOLOR = (TV_FIRST + 30);
        public const int TVM_GETBKCOLOR = (TV_FIRST + 31);
        public const int TVM_GETTEXTCOLOR = (TV_FIRST + 32);
        public const int TVM_SETSCROLLTIME = (TV_FIRST + 33);
        public const int TVM_GETSCROLLTIME = (TV_FIRST + 34);
        public const int TVM_SETINSERTMARKCOLOR = (TV_FIRST + 37);
        public const int TVM_GETINSERTMARKCOLOR = (TV_FIRST + 38);
        public const int TVM_GETITEMSTATE = (TV_FIRST + 39);
        public const int TVM_SETLINECOLOR = (TV_FIRST + 40);
        public const int TVM_GETLINECOLOR = (TV_FIRST + 41);
        public const int TVM_MAPACCIDTOHTREEITEM = (TV_FIRST + 42);
        public const int TVM_MAPHTREEITEMTOACCID = (TV_FIRST + 43);
        public const int CBEM_INSERTITEMA = (WM_USER + 1);
        public const int CBEM_SETIMAGELIST = (WM_USER + 2);
        public const int CBEM_GETIMAGELIST = (WM_USER + 3);
        public const int CBEM_GETITEMA = (WM_USER + 4);
        public const int CBEM_SETITEMA = (WM_USER + 5);
        public const int CBEM_DELETEITEM = CB_DELETESTRING;
        public const int CBEM_GETCOMBOCONTROL = (WM_USER + 6);
        public const int CBEM_GETEDITCONTROL = (WM_USER + 7);
        public const int CBEM_SETEXTENDEDSTYLE = (WM_USER + 14);
        public const int CBEM_GETEXTENDEDSTYLE = (WM_USER + 9);
        public const int CBEM_SETUNICODEFORMAT = CCM_SETUNICODEFORMAT;
        public const int CBEM_GETUNICODEFORMAT = CCM_GETUNICODEFORMAT;
        public const int CBEM_SETEXSTYLE = (WM_USER + 8);
        public const int CBEM_GETEXSTYLE = (WM_USER + 9);
        public const int CBEM_HASEDITCHANGED = (WM_USER + 10);
        public const int CBEM_INSERTITEMW = (WM_USER + 11);
        public const int CBEM_SETITEMW = (WM_USER + 12);
        public const int CBEM_GETITEMW = (WM_USER + 13);
        public const int TCM_GETIMAGELIST = (TCM_FIRST + 2);
        public const int TCM_SETIMAGELIST = (TCM_FIRST + 3);
        public const int TCM_GETITEMCOUNT = (TCM_FIRST + 4);
        public const int TCM_GETITEMA = (TCM_FIRST + 5);
        public const int TCM_GETITEMW = (TCM_FIRST + 60);
        public const int TCM_SETITEMA = (TCM_FIRST + 6);
        public const int TCM_SETITEMW = (TCM_FIRST + 61);
        public const int TCM_INSERTITEMA = (TCM_FIRST + 7);
        public const int TCM_INSERTITEMW = (TCM_FIRST + 62);
        public const int TCM_DELETEITEM = (TCM_FIRST + 8);
        public const int TCM_DELETEALLITEMS = (TCM_FIRST + 9);
        public const int TCM_GETITEMRECT = (TCM_FIRST + 10);
        public const int TCM_GETCURSEL = (TCM_FIRST + 11);
        public const int TCM_SETCURSEL = (TCM_FIRST + 12);
        public const int TCM_HITTEST = (TCM_FIRST + 13);
        public const int TCM_SETITEMEXTRA = (TCM_FIRST + 14);
        public const int TCM_ADJUSTRECT = (TCM_FIRST + 40);
        public const int TCM_SETITEMSIZE = (TCM_FIRST + 41);
        public const int TCM_REMOVEIMAGE = (TCM_FIRST + 42);
        public const int TCM_SETPADDING = (TCM_FIRST + 43);
        public const int TCM_GETROWCOUNT = (TCM_FIRST + 44);
        public const int TCM_GETTOOLTIPS = (TCM_FIRST + 45);
        public const int TCM_SETTOOLTIPS = (TCM_FIRST + 46);
        public const int TCM_GETCURFOCUS = (TCM_FIRST + 47);
        public const int TCM_SETCURFOCUS = (TCM_FIRST + 48);
        public const int TCM_SETMINTABWIDTH = (TCM_FIRST + 49);
        public const int TCM_DESELECTALL = (TCM_FIRST + 50);
        public const int TCM_HIGHLIGHTITEM = (TCM_FIRST + 51);
        public const int TCM_SETEXTENDEDSTYLE = (TCM_FIRST + 52);
        public const int TCM_GETEXTENDEDSTYLE = (TCM_FIRST + 53);
        public const int TCM_SETUNICODEFORMAT = CCM_SETUNICODEFORMAT;
        public const int TCM_GETUNICODEFORMAT = CCM_GETUNICODEFORMAT;
        public const int ACM_OPENA = (WM_USER + 100);
        public const int ACM_OPENW = (WM_USER + 103);
        public const int ACM_PLAY = (WM_USER + 101);
        public const int ACM_STOP = (WM_USER + 102);
        public const int MCM_FIRST = 0x1000;
        public const int MCM_GETCURSEL = (MCM_FIRST + 1);
        public const int MCM_SETCURSEL = (MCM_FIRST + 2);
        public const int MCM_GETMAXSELCOUNT = (MCM_FIRST + 3);
        public const int MCM_SETMAXSELCOUNT = (MCM_FIRST + 4);
        public const int MCM_GETSELRANGE = (MCM_FIRST + 5);
        public const int MCM_SETSELRANGE = (MCM_FIRST + 6);
        public const int MCM_GETMONTHRANGE = (MCM_FIRST + 7);
        public const int MCM_SETDAYSTATE = (MCM_FIRST + 8);
        public const int MCM_GETMINREQRECT = (MCM_FIRST + 9);
        public const int MCM_SETCOLOR = (MCM_FIRST + 10);
        public const int MCM_GETCOLOR = (MCM_FIRST + 11);
        public const int MCM_SETTODAY = (MCM_FIRST + 12);
        public const int MCM_GETTODAY = (MCM_FIRST + 13);
        public const int MCM_HITTEST = (MCM_FIRST + 14);
        public const int MCM_SETFIRSTDAYOFWEEK = (MCM_FIRST + 15);
        public const int MCM_GETFIRSTDAYOFWEEK = (MCM_FIRST + 16);
        public const int MCM_GETRANGE = (MCM_FIRST + 17);
        public const int MCM_SETRANGE = (MCM_FIRST + 18);
        public const int MCM_GETMONTHDELTA = (MCM_FIRST + 19);
        public const int MCM_SETMONTHDELTA = (MCM_FIRST + 20);
        public const int MCM_GETMAXTODAYWIDTH = (MCM_FIRST + 21);
        public const int MCM_SETUNICODEFORMAT = CCM_SETUNICODEFORMAT;
        public const int MCM_GETUNICODEFORMAT = CCM_GETUNICODEFORMAT;
        public const int DTM_FIRST = 0x1000;
        public const int DTM_GETSYSTEMTIME = (DTM_FIRST + 1);
        public const int DTM_SETSYSTEMTIME = (DTM_FIRST + 2);
        public const int DTM_GETRANGE = (DTM_FIRST + 3);
        public const int DTM_SETRANGE = (DTM_FIRST + 4);
        public const int DTM_SETFORMATA = (DTM_FIRST + 5);
        public const int DTM_SETFORMATW = (DTM_FIRST + 50);
        public const int DTM_SETMCCOLOR = (DTM_FIRST + 6);
        public const int DTM_GETMCCOLOR = (DTM_FIRST + 7);
        public const int DTM_GETMONTHCAL = (DTM_FIRST + 8);
        public const int DTM_SETMCFONT = (DTM_FIRST + 9);
        public const int DTM_GETMCFONT = (DTM_FIRST + 10);
        public const int PGM_SETCHILD = (PGM_FIRST + 1);
        public const int PGM_RECALCSIZE = (PGM_FIRST + 2);
        public const int PGM_FORWARDMOUSE = (PGM_FIRST + 3);
        public const int PGM_SETBKCOLOR = (PGM_FIRST + 4);
        public const int PGM_GETBKCOLOR = (PGM_FIRST + 5);
        public const int PGM_SETBORDER = (PGM_FIRST + 6);
        public const int PGM_GETBORDER = (PGM_FIRST + 7);
        public const int PGM_SETPOS = (PGM_FIRST + 8);
        public const int PGM_GETPOS = (PGM_FIRST + 9);
        public const int PGM_SETBUTTONSIZE = (PGM_FIRST + 10);
        public const int PGM_GETBUTTONSIZE = (PGM_FIRST + 11);
        public const int PGM_GETBUTTONSTATE = (PGM_FIRST + 12);
        public const int PGM_GETDROPTARGET = CCM_GETDROPTARGET;
        public const int BCM_GETIDEALSIZE = (BCM_FIRST + 0x0001);
        public const int BCM_SETIMAGELIST = (BCM_FIRST + 0x0002);
        public const int BCM_GETIMAGELIST = (BCM_FIRST + 0x0003);
        public const int BCM_SETTEXTMARGIN = (BCM_FIRST + 0x0004);
        public const int BCM_GETTEXTMARGIN = (BCM_FIRST + 0x0005);
        public const int EM_SETCUEBANNER = (ECM_FIRST + 1);
        public const int EM_GETCUEBANNER = (ECM_FIRST + 2);
        public const int EM_SHOWBALLOONTIP = (ECM_FIRST + 3);
        public const int EM_HIDEBALLOONTIP = (ECM_FIRST + 4);
        public const int CB_SETMINVISIBLE = (CBM_FIRST + 1);
        public const int CB_GETMINVISIBLE = (CBM_FIRST + 2);
        public const int LM_HITTEST = (WM_USER + 0x300);
        public const int LM_GETIDEALHEIGHT = (WM_USER + 0x301);
        public const int LM_SETITEM = (WM_USER + 0x302);
        public const int LM_GETITEM = (WM_USER + 0x303);
    }

    /// <summary>
    /// Dispids taken from MsHtmdid.h
    /// </summary>
    public sealed class HTMLDispIDs
    {
        //useful DISPIDs
        public const int DISPID_UNKNOWN = -1;

        //The original value -2147418111 was incorrect
        //0x80010000 = -2147418112 = &H80010000
        public const int DISPID_XOBJ_MIN = -2147418112;

        //0x8001FFFF
        public const int DISPID_XOBJ_MAX = -2147352577;
        public const int DISPID_XOBJ_BASE = DISPID_XOBJ_MIN;
        public const int DISPID_HTMLOBJECT = (DISPID_XOBJ_BASE + 500);
        public const int DISPID_ELEMENT = (DISPID_HTMLOBJECT + 500);
        public const int DISPID_SITE = (DISPID_ELEMENT + 1000);
        public const int DISPID_OBJECT = (DISPID_SITE + 1000);
        public const int DISPID_STYLE = (DISPID_OBJECT + 1000);
        public const int DISPID_ATTRS = (DISPID_STYLE + 1000);
        public const int DISPID_EVENTS = (DISPID_ATTRS + 1000);
        public const int DISPID_XOBJ_EXPANDO = (DISPID_EVENTS + 1000);
        public const int DISPID_XOBJ_ORDINAL = (DISPID_XOBJ_EXPANDO + 1000);

        public const int DISPID_AMBIENT_DLCONTROL = -5512;

        public const int STDDISPID_XOBJ_ONBLUR = (DISPID_XOBJ_BASE);
        public const int STDDISPID_XOBJ_ONFOCUS = (DISPID_XOBJ_BASE + 1);
        public const int STDDISPID_XOBJ_BEFOREUPDATE = (DISPID_XOBJ_BASE + 4);
        public const int STDDISPID_XOBJ_AFTERUPDATE = (DISPID_XOBJ_BASE + 5);
        public const int STDDISPID_XOBJ_ONROWEXIT = (DISPID_XOBJ_BASE + 6);
        public const int STDDISPID_XOBJ_ONROWENTER = (DISPID_XOBJ_BASE + 7);
        public const int STDDISPID_XOBJ_ONMOUSEOVER = (DISPID_XOBJ_BASE + 8);
        public const int STDDISPID_XOBJ_ONMOUSEOUT = (DISPID_XOBJ_BASE + 9);
        public const int STDDISPID_XOBJ_ONHELP = (DISPID_XOBJ_BASE + 10);
        public const int STDDISPID_XOBJ_ONDRAGSTART = (DISPID_XOBJ_BASE + 11);
        public const int STDDISPID_XOBJ_ONSELECTSTART = (DISPID_XOBJ_BASE + 12);
        public const int STDDISPID_XOBJ_ERRORUPDATE = (DISPID_XOBJ_BASE + 13);
        public const int STDDISPID_XOBJ_ONDATASETCHANGED = (DISPID_XOBJ_BASE + 14);
        public const int STDDISPID_XOBJ_ONDATAAVAILABLE = (DISPID_XOBJ_BASE + 15);
        public const int STDDISPID_XOBJ_ONDATASETCOMPLETE = (DISPID_XOBJ_BASE + 16);
        public const int STDDISPID_XOBJ_ONFILTER = (DISPID_XOBJ_BASE + 17);
        public const int STDDISPID_XOBJ_ONLOSECAPTURE = (DISPID_XOBJ_BASE + 18);
        public const int STDDISPID_XOBJ_ONPROPERTYCHANGE = (DISPID_XOBJ_BASE + 19);
        public const int STDDISPID_XOBJ_ONDRAG = (DISPID_XOBJ_BASE + 20);
        public const int STDDISPID_XOBJ_ONDRAGEND = (DISPID_XOBJ_BASE + 21);
        public const int STDDISPID_XOBJ_ONDRAGENTER = (DISPID_XOBJ_BASE + 22);
        public const int STDDISPID_XOBJ_ONDRAGOVER = (DISPID_XOBJ_BASE + 23);
        public const int STDDISPID_XOBJ_ONDRAGLEAVE = (DISPID_XOBJ_BASE + 24);
        public const int STDDISPID_XOBJ_ONDROP = (DISPID_XOBJ_BASE + 25);
        public const int STDDISPID_XOBJ_ONCUT = (DISPID_XOBJ_BASE + 26);
        public const int STDDISPID_XOBJ_ONCOPY = (DISPID_XOBJ_BASE + 27);
        public const int STDDISPID_XOBJ_ONPASTE = (DISPID_XOBJ_BASE + 28);
        public const int STDDISPID_XOBJ_ONBEFORECUT = (DISPID_XOBJ_BASE + 29);
        public const int STDDISPID_XOBJ_ONBEFORECOPY = (DISPID_XOBJ_BASE + 30);
        public const int STDDISPID_XOBJ_ONBEFOREPASTE = (DISPID_XOBJ_BASE + 31);
        public const int STDDISPID_XOBJ_ONROWSDELETE = (DISPID_XOBJ_BASE + 32);
        public const int STDDISPID_XOBJ_ONROWSINSERTED = (DISPID_XOBJ_BASE + 33);
        public const int STDDISPID_XOBJ_ONCELLCHANGE = (DISPID_XOBJ_BASE + 34);
        public const int STDPROPID_XOBJ_DISABLED = (DISPID_XOBJ_BASE + 0x4C); //+76
        public const int DISPID_DEFAULTVALUE = (DISPID_A_FIRST + 83);

        public const int DISPID_CLICK = (-600);
        public const int DISPID_DBLCLICK = (-601);
        public const int DISPID_KEYDOWN = (-602);
        public const int DISPID_KEYPRESS = (-603);
        public const int DISPID_KEYUP = (-604);
        public const int DISPID_MOUSEDOWN = (-605);
        public const int DISPID_MOUSEMOVE = (-606);
        public const int DISPID_MOUSEUP = (-607);
        public const int DISPID_ERROREVENT = (-608);
        public const int DISPID_READYSTATECHANGE = (-609);
        public const int DISPID_CLICK_VALUE = (-610);
        public const int DISPID_RIGHTTOLEFT = (-611);
        public const int DISPID_TOPTOBOTTOM = (-612);
        public const int DISPID_THIS = (-613);

        //  Standard dispatch ID constants

        public const int DISPID_AUTOSIZE = (-500);
        public const int DISPID_BACKCOLOR = (-501);
        public const int DISPID_BACKSTYLE = (-502);
        public const int DISPID_BORDERCOLOR = (-503);
        public const int DISPID_BORDERSTYLE = (-504);
        public const int DISPID_BORDERWIDTH = (-505);
        public const int DISPID_DRAWMODE = (-507);
        public const int DISPID_DRAWSTYLE = (-508);
        public const int DISPID_DRAWWIDTH = (-509);
        public const int DISPID_FILLCOLOR = (-510);
        public const int DISPID_FILLSTYLE = (-511);
        public const int DISPID_FONT = (-512);
        public const int DISPID_FORECOLOR = (-513);
        public const int DISPID_ENABLED = (-514);
        public const int DISPID_HWND = (-515);
        public const int DISPID_TABSTOP = (-516);
        public const int DISPID_TEXT = (-517);
        public const int DISPID_CAPTION = (-518);
        public const int DISPID_BORDERVISIBLE = (-519);
        public const int DISPID_APPEARANCE = (-520);
        public const int DISPID_MOUSEPOINTER = (-521);
        public const int DISPID_MOUSEICON = (-522);
        public const int DISPID_PICTURE = (-523);
        public const int DISPID_VALID = (-524);
        public const int DISPID_READYSTATE = (-525);
        public const int DISPID_LISTINDEX = (-526);
        public const int DISPID_SELECTED = (-527);
        public const int DISPID_LIST = (-528);
        public const int DISPID_COLUMN = (-529);
        public const int DISPID_LISTCOUNT = (-531);
        public const int DISPID_MULTISELECT = (-532);
        public const int DISPID_MAXLENGTH = (-533);
        public const int DISPID_PASSWORDCHAR = (-534);
        public const int DISPID_SCROLLBARS = (-535);
        public const int DISPID_WORDWRAP = (-536);
        public const int DISPID_MULTILINE = (-537);
        public const int DISPID_NUMBEROFROWS = (-538);
        public const int DISPID_NUMBEROFCOLUMNS = (-539);
        public const int DISPID_DISPLAYSTYLE = (-540);
        public const int DISPID_GROUPNAME = (-541);
        public const int DISPID_IMEMODE = (-542);
        public const int DISPID_ACCELERATOR = (-543);
        public const int DISPID_ENTERKEYBEHAVIOR = (-544);
        public const int DISPID_TABKEYBEHAVIOR = (-545);
        public const int DISPID_SELTEXT = (-546);
        public const int DISPID_SELSTART = (-547);
        public const int DISPID_SELLENGTH = (-548);

        public const int DISPID_REFRESH = (-550);
        public const int DISPID_DOCLICK = (-551);
        public const int DISPID_ABOUTBOX = (-552);
        public const int DISPID_ADDITEM = (-553);
        public const int DISPID_CLEAR = (-554);
        public const int DISPID_REMOVEITEM = (-555);
        public const int DISPID_NORMAL_FIRST = 1000;

        public const int DISPID_ONABORT = (DISPID_NORMAL_FIRST);
        public const int DISPID_ONCHANGE = (DISPID_NORMAL_FIRST + 1);
        public const int DISPID_ONERROR = (DISPID_NORMAL_FIRST + 2);
        public const int DISPID_ONLOAD = (DISPID_NORMAL_FIRST + 3);
        public const int DISPID_ONSELECT = (DISPID_NORMAL_FIRST + 6);
        public const int DISPID_ONSUBMIT = (DISPID_NORMAL_FIRST + 7);
        public const int DISPID_ONUNLOAD = (DISPID_NORMAL_FIRST + 8);
        public const int DISPID_ONBOUNCE = (DISPID_NORMAL_FIRST + 9);
        public const int DISPID_ONFINISH = (DISPID_NORMAL_FIRST + 10);
        public const int DISPID_ONSTART = (DISPID_NORMAL_FIRST + 11);
        public const int DISPID_ONLAYOUT = (DISPID_NORMAL_FIRST + 13);
        public const int DISPID_ONSCROLL = (DISPID_NORMAL_FIRST + 14);
        public const int DISPID_ONRESET = (DISPID_NORMAL_FIRST + 15);
        public const int DISPID_ONRESIZE = (DISPID_NORMAL_FIRST + 16);
        public const int DISPID_ONBEFOREUNLOAD = (DISPID_NORMAL_FIRST + 17);
        public const int DISPID_ONCHANGEFOCUS = (DISPID_NORMAL_FIRST + 18);
        public const int DISPID_ONCHANGEBLUR = (DISPID_NORMAL_FIRST + 19);
        public const int DISPID_ONPERSIST = (DISPID_NORMAL_FIRST + 20);
        public const int DISPID_ONPERSISTSAVE = (DISPID_NORMAL_FIRST + 21);
        public const int DISPID_ONPERSISTLOAD = (DISPID_NORMAL_FIRST + 22);
        public const int DISPID_ONCONTEXTMENU = (DISPID_NORMAL_FIRST + 23);
        public const int DISPID_ONBEFOREPRINT = (DISPID_NORMAL_FIRST + 24);
        public const int DISPID_ONAFTERPRINT = (DISPID_NORMAL_FIRST + 25);
        public const int DISPID_ONSTOP = (DISPID_NORMAL_FIRST + 26);
        public const int DISPID_ONBEFOREEDITFOCUS = (DISPID_NORMAL_FIRST + 27);
        public const int DISPID_ONMOUSEHOVER = (DISPID_NORMAL_FIRST + 28);
        public const int DISPID_ONCONTENTREADY = (DISPID_NORMAL_FIRST + 29);
        public const int DISPID_ONLAYOUTCOMPLETE = (DISPID_NORMAL_FIRST + 30);
        public const int DISPID_ONPAGE = (DISPID_NORMAL_FIRST + 31);
        public const int DISPID_ONLINKEDOVERFLOW = (DISPID_NORMAL_FIRST + 32);
        public const int DISPID_ONMOUSEWHEEL = (DISPID_NORMAL_FIRST + 33);
        public const int DISPID_ONBEFOREDEACTIVATE = (DISPID_NORMAL_FIRST + 34);
        public const int DISPID_ONMOVE = (DISPID_NORMAL_FIRST + 35);
        public const int DISPID_ONCONTROLSELECT = (DISPID_NORMAL_FIRST + 36);
        public const int DISPID_ONSELECTIONCHANGE = (DISPID_NORMAL_FIRST + 37);
        public const int DISPID_ONMOVESTART = (DISPID_NORMAL_FIRST + 38);
        public const int DISPID_ONMOVEEND = (DISPID_NORMAL_FIRST + 39);
        public const int DISPID_ONRESIZESTART = (DISPID_NORMAL_FIRST + 40);
        public const int DISPID_ONRESIZEEND = (DISPID_NORMAL_FIRST + 41);
        public const int DISPID_ONMOUSEENTER = (DISPID_NORMAL_FIRST + 42);
        public const int DISPID_ONMOUSELEAVE = (DISPID_NORMAL_FIRST + 43);
        public const int DISPID_ONACTIVATE = (DISPID_NORMAL_FIRST + 44);
        public const int DISPID_ONDEACTIVATE = (DISPID_NORMAL_FIRST + 45);
        public const int DISPID_ONMULTILAYOUTCLEANUP = (DISPID_NORMAL_FIRST + 46);
        public const int DISPID_ONBEFOREACTIVATE = (DISPID_NORMAL_FIRST + 47);
        public const int DISPID_ONFOCUSIN = (DISPID_NORMAL_FIRST + 48);
        public const int DISPID_ONFOCUSOUT = (DISPID_NORMAL_FIRST + 49);

        public const int DISPID_A_UNICODEBIDI = (DISPID_A_FIRST + 118); // Complex Text support for CSS2 unicode-bidi
        public const int DISPID_A_DIRECTION = (DISPID_A_FIRST + 119); // Complex Text support for CSS2 direction

        public const int DISPID_EVPROP_ONMOUSEOVER = (DISPID_EVENTS + 0);
        public const int DISPID_EVMETH_ONMOUSEOVER = STDDISPID_XOBJ_ONMOUSEOVER;
        public const int DISPID_EVPROP_ONMOUSEOUT = (DISPID_EVENTS + 1);
        public const int DISPID_EVMETH_ONMOUSEOUT = STDDISPID_XOBJ_ONMOUSEOUT;
        public const int DISPID_EVPROP_ONMOUSEDOWN = (DISPID_EVENTS + 2);
        public const int DISPID_EVMETH_ONMOUSEDOWN = DISPID_MOUSEDOWN;
        public const int DISPID_EVPROP_ONMOUSEUP = (DISPID_EVENTS + 3);
        public const int DISPID_EVMETH_ONMOUSEUP = DISPID_MOUSEUP;
        public const int DISPID_EVPROP_ONMOUSEMOVE = (DISPID_EVENTS + 4);
        public const int DISPID_EVMETH_ONMOUSEMOVE = DISPID_MOUSEMOVE;
        public const int DISPID_EVPROP_ONKEYDOWN = (DISPID_EVENTS + 5);
        public const int DISPID_EVMETH_ONKEYDOWN = DISPID_KEYDOWN;
        public const int DISPID_EVPROP_ONKEYUP = (DISPID_EVENTS + 6);
        public const int DISPID_EVMETH_ONKEYUP = DISPID_KEYUP;
        public const int DISPID_EVPROP_ONKEYPRESS = (DISPID_EVENTS + 7);
        public const int DISPID_EVMETH_ONKEYPRESS = DISPID_KEYPRESS;
        public const int DISPID_EVPROP_ONCLICK = (DISPID_EVENTS + 8);
        public const int DISPID_EVMETH_ONCLICK = DISPID_CLICK;
        public const int DISPID_EVPROP_ONDBLCLICK = (DISPID_EVENTS + 9);
        public const int DISPID_EVMETH_ONDBLCLICK = DISPID_DBLCLICK;
        public const int DISPID_EVPROP_ONSELECT = (DISPID_EVENTS + 10);
        public const int DISPID_EVMETH_ONSELECT = DISPID_ONSELECT;
        public const int DISPID_EVPROP_ONSUBMIT = (DISPID_EVENTS + 11);
        public const int DISPID_EVMETH_ONSUBMIT = DISPID_ONSUBMIT;
        public const int DISPID_EVPROP_ONRESET = (DISPID_EVENTS + 12);
        public const int DISPID_EVMETH_ONRESET = DISPID_ONRESET;
        public const int DISPID_EVPROP_ONHELP = (DISPID_EVENTS + 13);
        public const int DISPID_EVMETH_ONHELP = STDDISPID_XOBJ_ONHELP;
        public const int DISPID_EVPROP_ONFOCUS = (DISPID_EVENTS + 14);
        public const int DISPID_EVMETH_ONFOCUS = STDDISPID_XOBJ_ONFOCUS;
        public const int DISPID_EVPROP_ONBLUR = (DISPID_EVENTS + 15);
        public const int DISPID_EVMETH_ONBLUR = STDDISPID_XOBJ_ONBLUR;
        public const int DISPID_EVPROP_ONROWEXIT = (DISPID_EVENTS + 18);
        public const int DISPID_EVMETH_ONROWEXIT = STDDISPID_XOBJ_ONROWEXIT;
        public const int DISPID_EVPROP_ONROWENTER = (DISPID_EVENTS + 19);
        public const int DISPID_EVMETH_ONROWENTER = STDDISPID_XOBJ_ONROWENTER;
        public const int DISPID_EVPROP_ONBOUNCE = (DISPID_EVENTS + 20);
        public const int DISPID_EVMETH_ONBOUNCE = DISPID_ONBOUNCE;
        public const int DISPID_EVPROP_ONBEFOREUPDATE = (DISPID_EVENTS + 21);
        public const int DISPID_EVMETH_ONBEFOREUPDATE = STDDISPID_XOBJ_BEFOREUPDATE;
        public const int DISPID_EVPROP_ONAFTERUPDATE = (DISPID_EVENTS + 22);
        public const int DISPID_EVMETH_ONAFTERUPDATE = STDDISPID_XOBJ_AFTERUPDATE;
        public const int DISPID_EVPROP_ONBEFOREDRAGOVER = (DISPID_EVENTS + 23);
        //public const int  DISPID_EVMETH_ONBEFOREDRAGOVER =  EVENTID_CommonCtrlEvent_BeforeDragOver;
        public const int DISPID_EVPROP_ONBEFOREDROPORPASTE = (DISPID_EVENTS + 24);
        //public const int  DISPID_EVMETH_ONBEFOREDROPORPASTE = EVENTID_CommonCtrlEvent_BeforeDropOrPaste;
        public const int DISPID_EVPROP_ONREADYSTATECHANGE = (DISPID_EVENTS + 25);
        public const int DISPID_EVMETH_ONREADYSTATECHANGE = DISPID_READYSTATECHANGE;
        public const int DISPID_EVPROP_ONFINISH = (DISPID_EVENTS + 26);
        public const int DISPID_EVMETH_ONFINISH = DISPID_ONFINISH;
        public const int DISPID_EVPROP_ONSTART = (DISPID_EVENTS + 27);
        public const int DISPID_EVMETH_ONSTART = DISPID_ONSTART;
        public const int DISPID_EVPROP_ONABORT = (DISPID_EVENTS + 28);
        public const int DISPID_EVMETH_ONABORT = DISPID_ONABORT;
        public const int DISPID_EVPROP_ONERROR = (DISPID_EVENTS + 29);
        public const int DISPID_EVMETH_ONERROR = DISPID_ONERROR;
        public const int DISPID_EVPROP_ONCHANGE = (DISPID_EVENTS + 30);
        public const int DISPID_EVMETH_ONCHANGE = DISPID_ONCHANGE;
        public const int DISPID_EVPROP_ONSCROLL = (DISPID_EVENTS + 31);
        public const int DISPID_EVMETH_ONSCROLL = DISPID_ONSCROLL;
        public const int DISPID_EVPROP_ONLOAD = (DISPID_EVENTS + 32);
        public const int DISPID_EVMETH_ONLOAD = DISPID_ONLOAD;
        public const int DISPID_EVPROP_ONUNLOAD = (DISPID_EVENTS + 33);
        public const int DISPID_EVMETH_ONUNLOAD = DISPID_ONUNLOAD;
        public const int DISPID_EVPROP_ONLAYOUT = (DISPID_EVENTS + 34);
        public const int DISPID_EVMETH_ONLAYOUT = DISPID_ONLAYOUT;
        public const int DISPID_EVPROP_ONDRAGSTART = (DISPID_EVENTS + 35);
        public const int DISPID_EVMETH_ONDRAGSTART = STDDISPID_XOBJ_ONDRAGSTART;
        public const int DISPID_EVPROP_ONRESIZE = (DISPID_EVENTS + 36);
        public const int DISPID_EVMETH_ONRESIZE = DISPID_ONRESIZE;
        public const int DISPID_EVPROP_ONSELECTSTART = (DISPID_EVENTS + 37);
        public const int DISPID_EVMETH_ONSELECTSTART = STDDISPID_XOBJ_ONSELECTSTART;
        public const int DISPID_EVPROP_ONERRORUPDATE = (DISPID_EVENTS + 38);
        public const int DISPID_EVMETH_ONERRORUPDATE = STDDISPID_XOBJ_ERRORUPDATE;
        public const int DISPID_EVPROP_ONBEFOREUNLOAD = (DISPID_EVENTS + 39);
        // <summary>
        /// 
        /// </summary>
        //public const int  DISPID_EVMETH_ONBEFOREUNLOAD  = DISPID_ONBEFOREUNLOAD;
        public const int DISPID_EVPROP_ONDATASETCHANGED = (DISPID_EVENTS + 40);
        public const int DISPID_EVMETH_ONDATASETCHANGED = STDDISPID_XOBJ_ONDATASETCHANGED;
        public const int DISPID_EVPROP_ONDATAAVAILABLE = (DISPID_EVENTS + 41);
        public const int DISPID_EVMETH_ONDATAAVAILABLE = STDDISPID_XOBJ_ONDATAAVAILABLE;
        public const int DISPID_EVPROP_ONDATASETCOMPLETE = (DISPID_EVENTS + 42);
        public const int DISPID_EVMETH_ONDATASETCOMPLETE = STDDISPID_XOBJ_ONDATASETCOMPLETE;
        public const int DISPID_EVPROP_ONFILTER = (DISPID_EVENTS + 43);
        public const int DISPID_EVMETH_ONFILTER = STDDISPID_XOBJ_ONFILTER;
        public const int DISPID_EVPROP_ONCHANGEFOCUS = (DISPID_EVENTS + 44);
        public const int DISPID_EVMETH_ONCHANGEFOCUS = DISPID_ONCHANGEFOCUS;
        public const int DISPID_EVPROP_ONCHANGEBLUR = (DISPID_EVENTS + 45);
        public const int DISPID_EVMETH_ONCHANGEBLUR = DISPID_ONCHANGEBLUR;
        public const int DISPID_EVPROP_ONLOSECAPTURE = (DISPID_EVENTS + 46);
        public const int DISPID_EVMETH_ONLOSECAPTURE = STDDISPID_XOBJ_ONLOSECAPTURE;
        public const int DISPID_EVPROP_ONPROPERTYCHANGE = (DISPID_EVENTS + 47);
        public const int DISPID_EVMETH_ONPROPERTYCHANGE = STDDISPID_XOBJ_ONPROPERTYCHANGE;
        public const int DISPID_EVPROP_ONPERSISTSAVE = (DISPID_EVENTS + 48);
        public const int DISPID_EVMETH_ONPERSISTSAVE = DISPID_ONPERSISTSAVE;
        public const int DISPID_EVPROP_ONDRAG = (DISPID_EVENTS + 49);
        public const int DISPID_EVMETH_ONDRAG = STDDISPID_XOBJ_ONDRAG;
        public const int DISPID_EVPROP_ONDRAGEND = (DISPID_EVENTS + 50);
        public const int DISPID_EVMETH_ONDRAGEND = STDDISPID_XOBJ_ONDRAGEND;
        public const int DISPID_EVPROP_ONDRAGENTER = (DISPID_EVENTS + 51);
        public const int DISPID_EVMETH_ONDRAGENTER = STDDISPID_XOBJ_ONDRAGENTER;
        public const int DISPID_EVPROP_ONDRAGOVER = (DISPID_EVENTS + 52);
        public const int DISPID_EVMETH_ONDRAGOVER = STDDISPID_XOBJ_ONDRAGOVER;
        public const int DISPID_EVPROP_ONDRAGLEAVE = (DISPID_EVENTS + 53);
        public const int DISPID_EVMETH_ONDRAGLEAVE = STDDISPID_XOBJ_ONDRAGLEAVE;
        public const int DISPID_EVPROP_ONDROP = (DISPID_EVENTS + 54);
        public const int DISPID_EVMETH_ONDROP = STDDISPID_XOBJ_ONDROP;
        public const int DISPID_EVPROP_ONCUT = (DISPID_EVENTS + 55);
        public const int DISPID_EVMETH_ONCUT = STDDISPID_XOBJ_ONCUT;
        public const int DISPID_EVPROP_ONCOPY = (DISPID_EVENTS + 56);
        public const int DISPID_EVMETH_ONCOPY = STDDISPID_XOBJ_ONCOPY;
        public const int DISPID_EVPROP_ONPASTE = (DISPID_EVENTS + 57);
        public const int DISPID_EVMETH_ONPASTE = STDDISPID_XOBJ_ONPASTE;
        public const int DISPID_EVPROP_ONBEFORECUT = (DISPID_EVENTS + 58);
        public const int DISPID_EVMETH_ONBEFORECUT = STDDISPID_XOBJ_ONBEFORECUT;
        public const int DISPID_EVPROP_ONBEFORECOPY = (DISPID_EVENTS + 59);
        public const int DISPID_EVMETH_ONBEFORECOPY = STDDISPID_XOBJ_ONBEFORECOPY;
        public const int DISPID_EVPROP_ONBEFOREPASTE = (DISPID_EVENTS + 60);
        public const int DISPID_EVMETH_ONBEFOREPASTE = STDDISPID_XOBJ_ONBEFOREPASTE;
        public const int DISPID_EVPROP_ONPERSISTLOAD = (DISPID_EVENTS + 61);
        public const int DISPID_EVMETH_ONPERSISTLOAD = DISPID_ONPERSISTLOAD;
        public const int DISPID_EVPROP_ONROWSDELETE = (DISPID_EVENTS + 62);
        public const int DISPID_EVMETH_ONROWSDELETE = STDDISPID_XOBJ_ONROWSDELETE;
        public const int DISPID_EVPROP_ONROWSINSERTED = (DISPID_EVENTS + 63);
        public const int DISPID_EVMETH_ONROWSINSERTED = STDDISPID_XOBJ_ONROWSINSERTED;
        public const int DISPID_EVPROP_ONCELLCHANGE = (DISPID_EVENTS + 64);
        public const int DISPID_EVMETH_ONCELLCHANGE = STDDISPID_XOBJ_ONCELLCHANGE;
        public const int DISPID_EVPROP_ONCONTEXTMENU = (DISPID_EVENTS + 65);
        public const int DISPID_EVMETH_ONCONTEXTMENU = DISPID_ONCONTEXTMENU;
        public const int DISPID_EVPROP_ONBEFOREPRINT = (DISPID_EVENTS + 66);
        public const int DISPID_EVMETH_ONBEFOREPRINT = DISPID_ONBEFOREPRINT;
        public const int DISPID_EVPROP_ONAFTERPRINT = (DISPID_EVENTS + 67);
        public const int DISPID_EVMETH_ONAFTERPRINT = DISPID_ONAFTERPRINT;
        public const int DISPID_EVPROP_ONSTOP = (DISPID_EVENTS + 68);
        public const int DISPID_EVMETH_ONSTOP = DISPID_ONSTOP;
        public const int DISPID_EVPROP_ONBEFOREEDITFOCUS = (DISPID_EVENTS + 69);
        public const int DISPID_EVMETH_ONBEFOREEDITFOCUS = DISPID_ONBEFOREEDITFOCUS;
        public const int DISPID_EVPROP_ONATTACHEVENT = (DISPID_EVENTS + 70);
        public const int DISPID_EVPROP_ONMOUSEHOVER = (DISPID_EVENTS + 71);
        public const int DISPID_EVMETH_ONMOUSEHOVER = DISPID_ONMOUSEHOVER;
        public const int DISPID_EVPROP_ONCONTENTREADY = (DISPID_EVENTS + 72);
        public const int DISPID_EVMETH_ONCONTENTREADY = DISPID_ONCONTENTREADY;
        public const int DISPID_EVPROP_ONLAYOUTCOMPLETE = (DISPID_EVENTS + 73);
        public const int DISPID_EVMETH_ONLAYOUTCOMPLETE = DISPID_ONLAYOUTCOMPLETE;
        public const int DISPID_EVPROP_ONPAGE = (DISPID_EVENTS + 74);
        public const int DISPID_EVMETH_ONPAGE = DISPID_ONPAGE;
        public const int DISPID_EVPROP_ONLINKEDOVERFLOW = (DISPID_EVENTS + 75);
        public const int DISPID_EVMETH_ONLINKEDOVERFLOW = DISPID_ONLINKEDOVERFLOW;
        public const int DISPID_EVPROP_ONMOUSEWHEEL = (DISPID_EVENTS + 76);
        public const int DISPID_EVMETH_ONMOUSEWHEEL = DISPID_ONMOUSEWHEEL;
        public const int DISPID_EVPROP_ONBEFOREDEACTIVATE = (DISPID_EVENTS + 77);
        public const int DISPID_EVMETH_ONBEFOREDEACTIVATE = DISPID_ONBEFOREDEACTIVATE;
        public const int DISPID_EVPROP_ONMOVE = (DISPID_EVENTS + 78);
        public const int DISPID_EVMETH_ONMOVE = DISPID_ONMOVE;
        public const int DISPID_EVPROP_ONCONTROLSELECT = (DISPID_EVENTS + 79);
        public const int DISPID_EVMETH_ONCONTROLSELECT = DISPID_ONCONTROLSELECT;
        public const int DISPID_EVPROP_ONSELECTIONCHANGE = (DISPID_EVENTS + 80);
        public const int DISPID_EVMETH_ONSELECTIONCHANGE = DISPID_ONSELECTIONCHANGE;
        public const int DISPID_EVPROP_ONMOVESTART = (DISPID_EVENTS + 81);
        public const int DISPID_EVMETH_ONMOVESTART = DISPID_ONMOVESTART;
        public const int DISPID_EVPROP_ONMOVEEND = (DISPID_EVENTS + 82);
        public const int DISPID_EVMETH_ONMOVEEND = DISPID_ONMOVEEND;
        public const int DISPID_EVPROP_ONRESIZESTART = (DISPID_EVENTS + 83);
        public const int DISPID_EVMETH_ONRESIZESTART = DISPID_ONRESIZESTART;
        public const int DISPID_EVPROP_ONRESIZEEND = (DISPID_EVENTS + 84);
        public const int DISPID_EVMETH_ONRESIZEEND = DISPID_ONRESIZEEND;
        public const int DISPID_EVPROP_ONMOUSEENTER = (DISPID_EVENTS + 85);
        public const int DISPID_EVMETH_ONMOUSEENTER = DISPID_ONMOUSEENTER;
        public const int DISPID_EVPROP_ONMOUSELEAVE = (DISPID_EVENTS + 86);
        public const int DISPID_EVMETH_ONMOUSELEAVE = DISPID_ONMOUSELEAVE;
        public const int DISPID_EVPROP_ONACTIVATE = (DISPID_EVENTS + 87);
        public const int DISPID_EVMETH_ONACTIVATE = DISPID_ONACTIVATE;
        public const int DISPID_EVPROP_ONDEACTIVATE = (DISPID_EVENTS + 88);
        public const int DISPID_EVMETH_ONDEACTIVATE = DISPID_ONDEACTIVATE;
        public const int DISPID_EVPROP_ONMULTILAYOUTCLEANUP = (DISPID_EVENTS + 89);
        public const int DISPID_EVMETH_ONMULTILAYOUTCLEANUP = DISPID_ONMULTILAYOUTCLEANUP;
        public const int DISPID_EVPROP_ONBEFOREACTIVATE = (DISPID_EVENTS + 90);
        public const int DISPID_EVMETH_ONBEFOREACTIVATE = DISPID_ONBEFOREACTIVATE;
        public const int DISPID_EVPROP_ONFOCUSIN = (DISPID_EVENTS + 91);
        public const int DISPID_EVMETH_ONFOCUSIN = DISPID_ONFOCUSIN;
        public const int DISPID_EVPROP_ONFOCUSOUT = (DISPID_EVENTS + 92);
        public const int DISPID_EVMETH_ONFOCUSOUT = DISPID_ONFOCUSOUT;

        public const int DISPID_EVMETH_ONBEFOREUNLOAD = DISPID_ONBEFOREUNLOAD;

        public const int STDPROPID_XOBJ_CONTROLTIPTEXT = (DISPID_XOBJ_BASE + 0x45);

        public const int DISPID_A_LANGUAGE = (DISPID_A_FIRST + 100);
        public const int DISPID_A_LANG = (DISPID_A_FIRST + 9);
        public const int STDPROPID_XOBJ_PARENT = (DISPID_XOBJ_BASE + 0x8);
        public const int STDPROPID_XOBJ_STYLE = (DISPID_XOBJ_BASE + 0x4A);

        //    DISPIDs for interface IHTMLEventObj4
        public const int DISPID_IHTMLEVENTOBJ4_WHEELDELTA = DISPID_EVENTOBJ + 51;

        public const int DISPID_IHTMLELEMENT_SETATTRIBUTE = DISPID_HTMLOBJECT + 1;
        public const int DISPID_IHTMLELEMENT_GETATTRIBUTE = DISPID_HTMLOBJECT + 2;
        public const int DISPID_IHTMLELEMENT_REMOVEATTRIBUTE = DISPID_HTMLOBJECT + 3;
        public const int DISPID_IHTMLELEMENT_CLASSNAME = DISPID_ELEMENT + 1;
        public const int DISPID_IHTMLELEMENT_ID = DISPID_ELEMENT + 2;
        public const int DISPID_IHTMLELEMENT_TAGNAME = DISPID_ELEMENT + 4;
        public const int DISPID_IHTMLELEMENT_PARENTELEMENT = STDPROPID_XOBJ_PARENT;
        public const int DISPID_IHTMLELEMENT_STYLE = STDPROPID_XOBJ_STYLE;
        public const int DISPID_IHTMLELEMENT_ONHELP = DISPID_EVPROP_ONHELP; //-2147412098
        public const int DISPID_IHTMLELEMENT_ONCLICK = DISPID_EVPROP_ONCLICK; //-2147412103
        public const int DISPID_IHTMLELEMENT_ONDBLCLICK = DISPID_EVPROP_ONDBLCLICK;//-2147412102
        public const int DISPID_IHTMLELEMENT_ONKEYDOWN = DISPID_EVPROP_ONKEYDOWN; //-2147412106
        public const int DISPID_IHTMLELEMENT_ONKEYUP = DISPID_EVPROP_ONKEYUP;
        public const int DISPID_IHTMLELEMENT_ONKEYPRESS = DISPID_EVPROP_ONKEYPRESS; //-2147412104
        public const int DISPID_IHTMLELEMENT_ONMOUSEOUT = DISPID_EVPROP_ONMOUSEOUT; //-2147412110
        public const int DISPID_IHTMLELEMENT_ONMOUSEOVER = DISPID_EVPROP_ONMOUSEOVER; //-2147412111
        public const int DISPID_IHTMLELEMENT_ONMOUSEMOVE = DISPID_EVPROP_ONMOUSEMOVE; // -2147412107
        public const int DISPID_IHTMLELEMENT_ONMOUSEDOWN = DISPID_EVPROP_ONMOUSEDOWN;
        public const int DISPID_IHTMLELEMENT_ONMOUSEUP = DISPID_EVPROP_ONMOUSEUP;
        public const int DISPID_IHTMLELEMENT_DOCUMENT = DISPID_ELEMENT + 18;
        public const int DISPID_IHTMLELEMENT_TITLE = STDPROPID_XOBJ_CONTROLTIPTEXT;
        public const int DISPID_IHTMLELEMENT_LANGUAGE = DISPID_A_LANGUAGE;
        public const int DISPID_IHTMLELEMENT_ONSELECTSTART = DISPID_EVPROP_ONSELECTSTART;
        public const int DISPID_IHTMLELEMENT_SCROLLINTOVIEW = DISPID_ELEMENT + 19;
        public const int DISPID_IHTMLELEMENT_CONTAINS = DISPID_ELEMENT + 20;
        public const int DISPID_IHTMLELEMENT_SOURCEINDEX = DISPID_ELEMENT + 24;
        public const int DISPID_IHTMLELEMENT_RECORDNUMBER = DISPID_ELEMENT + 25;
        public const int DISPID_IHTMLELEMENT_LANG = DISPID_A_LANG;
        public const int DISPID_IHTMLELEMENT_OFFSETLEFT = DISPID_ELEMENT + 8;
        public const int DISPID_IHTMLELEMENT_OFFSETTOP = DISPID_ELEMENT + 9;
        public const int DISPID_IHTMLELEMENT_OFFSETWIDTH = DISPID_ELEMENT + 10;
        public const int DISPID_IHTMLELEMENT_OFFSETHEIGHT = DISPID_ELEMENT + 11;
        public const int DISPID_IHTMLELEMENT_OFFSETPARENT = DISPID_ELEMENT + 12;
        public const int DISPID_IHTMLELEMENT_INNERHTML = DISPID_ELEMENT + 26;
        public const int DISPID_IHTMLELEMENT_INNERTEXT = DISPID_ELEMENT + 27;
        public const int DISPID_IHTMLELEMENT_OUTERHTML = DISPID_ELEMENT + 28;
        public const int DISPID_IHTMLELEMENT_OUTERTEXT = DISPID_ELEMENT + 29;
        public const int DISPID_IHTMLELEMENT_INSERTADJACENTHTML = DISPID_ELEMENT + 30;
        public const int DISPID_IHTMLELEMENT_INSERTADJACENTTEXT = DISPID_ELEMENT + 31;
        public const int DISPID_IHTMLELEMENT_PARENTTEXTEDIT = DISPID_ELEMENT + 32;
        public const int DISPID_IHTMLELEMENT_ISTEXTEDIT = DISPID_ELEMENT + 34;
        public const int DISPID_IHTMLELEMENT_CLICK = DISPID_ELEMENT + 33;
        public const int DISPID_IHTMLELEMENT_FILTERS = DISPID_ELEMENT + 35;
        public const int DISPID_IHTMLELEMENT_ONDRAGSTART = DISPID_EVPROP_ONDRAGSTART;
        public const int DISPID_IHTMLELEMENT_TOSTRING = DISPID_ELEMENT + 36;
        public const int DISPID_IHTMLELEMENT_ONBEFOREUPDATE = DISPID_EVPROP_ONBEFOREUPDATE;
        public const int DISPID_IHTMLELEMENT_ONAFTERUPDATE = DISPID_EVPROP_ONAFTERUPDATE;
        public const int DISPID_IHTMLELEMENT_ONERRORUPDATE = DISPID_EVPROP_ONERRORUPDATE;
        public const int DISPID_IHTMLELEMENT_ONROWEXIT = DISPID_EVPROP_ONROWEXIT;
        public const int DISPID_IHTMLELEMENT_ONROWENTER = DISPID_EVPROP_ONROWENTER;
        public const int DISPID_IHTMLELEMENT_ONDATASETCHANGED = DISPID_EVPROP_ONDATASETCHANGED;
        public const int DISPID_IHTMLELEMENT_ONDATAAVAILABLE = DISPID_EVPROP_ONDATAAVAILABLE;
        public const int DISPID_IHTMLELEMENT_ONDATASETCOMPLETE = DISPID_EVPROP_ONDATASETCOMPLETE;
        public const int DISPID_IHTMLELEMENT_ONFILTERCHANGE = DISPID_EVPROP_ONFILTER;
        public const int DISPID_IHTMLELEMENT_CHILDREN = DISPID_ELEMENT + 37;
        public const int DISPID_IHTMLELEMENT_ALL = DISPID_ELEMENT + 38;

        //  DISPIDs for interface IHTMLElement2

        public const int DISPID_IHTMLELEMENT2_SCOPENAME = DISPID_ELEMENT + 39;
        public const int DISPID_IHTMLELEMENT2_SETCAPTURE = DISPID_ELEMENT + 40;
        public const int DISPID_IHTMLELEMENT2_RELEASECAPTURE = DISPID_ELEMENT + 41;
        public const int DISPID_IHTMLELEMENT2_ONLOSECAPTURE = DISPID_EVPROP_ONLOSECAPTURE;
        public const int DISPID_IHTMLELEMENT2_COMPONENTFROMPOINT = DISPID_ELEMENT + 42;
        public const int DISPID_IHTMLELEMENT2_DOSCROLL = DISPID_ELEMENT + 43;
        public const int DISPID_IHTMLELEMENT2_ONSCROLL = DISPID_EVPROP_ONSCROLL;
        public const int DISPID_IHTMLELEMENT2_ONDRAG = DISPID_EVPROP_ONDRAG;
        public const int DISPID_IHTMLELEMENT2_ONDRAGEND = DISPID_EVPROP_ONDRAGEND;
        public const int DISPID_IHTMLELEMENT2_ONDRAGENTER = DISPID_EVPROP_ONDRAGENTER;
        public const int DISPID_IHTMLELEMENT2_ONDRAGOVER = DISPID_EVPROP_ONDRAGOVER;
        public const int DISPID_IHTMLELEMENT2_ONDRAGLEAVE = DISPID_EVPROP_ONDRAGLEAVE;
        public const int DISPID_IHTMLELEMENT2_ONDROP = DISPID_EVPROP_ONDROP;
        public const int DISPID_IHTMLELEMENT2_ONBEFORECUT = DISPID_EVPROP_ONBEFORECUT;
        public const int DISPID_IHTMLELEMENT2_ONCUT = DISPID_EVPROP_ONCUT;
        public const int DISPID_IHTMLELEMENT2_ONBEFORECOPY = DISPID_EVPROP_ONBEFORECOPY;
        public const int DISPID_IHTMLELEMENT2_ONCOPY = DISPID_EVPROP_ONCOPY;
        public const int DISPID_IHTMLELEMENT2_ONBEFOREPASTE = DISPID_EVPROP_ONBEFOREPASTE;
        public const int DISPID_IHTMLELEMENT2_ONPASTE = DISPID_EVPROP_ONPASTE;
        public const int DISPID_IHTMLELEMENT2_CURRENTSTYLE = DISPID_ELEMENT + 7;
        public const int DISPID_IHTMLELEMENT2_ONPROPERTYCHANGE = DISPID_EVPROP_ONPROPERTYCHANGE;
        public const int DISPID_IHTMLELEMENT2_GETCLIENTRECTS = DISPID_ELEMENT + 44;
        public const int DISPID_IHTMLELEMENT2_GETBOUNDINGCLIENTRECT = DISPID_ELEMENT + 45;
        public const int DISPID_IHTMLELEMENT2_SETEXPRESSION = DISPID_HTMLOBJECT + 4;
        public const int DISPID_IHTMLELEMENT2_GETEXPRESSION = DISPID_HTMLOBJECT + 5;
        public const int DISPID_IHTMLELEMENT2_REMOVEEXPRESSION = DISPID_HTMLOBJECT + 6;
        //public const int  DISPID_IHTMLELEMENT2_TABINDEX  = STDPROPID_XOBJ_TABINDEX;
        public const int DISPID_IHTMLELEMENT2_FOCUS = DISPID_SITE + 0;
        public const int DISPID_IHTMLELEMENT2_ACCESSKEY = DISPID_SITE + 5;
        public const int DISPID_IHTMLELEMENT2_ONBLUR = DISPID_EVPROP_ONBLUR;
        public const int DISPID_IHTMLELEMENT2_ONFOCUS = DISPID_EVPROP_ONFOCUS;
        public const int DISPID_IHTMLELEMENT2_ONRESIZE = DISPID_EVPROP_ONRESIZE;
        public const int DISPID_IHTMLELEMENT2_BLUR = DISPID_SITE + 2;
        public const int DISPID_IHTMLELEMENT2_ADDFILTER = DISPID_SITE + 17;
        public const int DISPID_IHTMLELEMENT2_REMOVEFILTER = DISPID_SITE + 18;
        public const int DISPID_IHTMLELEMENT2_CLIENTHEIGHT = DISPID_SITE + 19;
        public const int DISPID_IHTMLELEMENT2_CLIENTWIDTH = DISPID_SITE + 20;
        public const int DISPID_IHTMLELEMENT2_CLIENTTOP = DISPID_SITE + 21;
        public const int DISPID_IHTMLELEMENT2_CLIENTLEFT = DISPID_SITE + 22;
        public const int DISPID_IHTMLELEMENT2_ATTACHEVENT = DISPID_HTMLOBJECT + 7;
        public const int DISPID_IHTMLELEMENT2_DETACHEVENT = DISPID_HTMLOBJECT + 8;
        //public const int  DISPID_IHTMLELEMENT2_READYSTATE  = DISPID_A_READYSTATE;
        public const int DISPID_IHTMLELEMENT2_ONREADYSTATECHANGE = DISPID_EVPROP_ONREADYSTATECHANGE;
        public const int DISPID_IHTMLELEMENT2_ONROWSDELETE = DISPID_EVPROP_ONROWSDELETE;
        public const int DISPID_IHTMLELEMENT2_ONROWSINSERTED = DISPID_EVPROP_ONROWSINSERTED;
        public const int DISPID_IHTMLELEMENT2_ONCELLCHANGE = DISPID_EVPROP_ONCELLCHANGE;
        //public const int  DISPID_IHTMLELEMENT2_DIR = DISPID_A_DIR;
        public const int DISPID_IHTMLELEMENT2_CREATECONTROLRANGE = DISPID_ELEMENT + 56;
        public const int DISPID_IHTMLELEMENT2_SCROLLHEIGHT = DISPID_ELEMENT + 57;
        public const int DISPID_IHTMLELEMENT2_SCROLLWIDTH = DISPID_ELEMENT + 58;
        public const int DISPID_IHTMLELEMENT2_SCROLLTOP = DISPID_ELEMENT + 59;
        public const int DISPID_IHTMLELEMENT2_SCROLLLEFT = DISPID_ELEMENT + 60;
        public const int DISPID_IHTMLELEMENT2_CLEARATTRIBUTES = DISPID_ELEMENT + 62;
        public const int DISPID_IHTMLELEMENT2_MERGEATTRIBUTES = DISPID_ELEMENT + 63;
        public const int DISPID_IHTMLELEMENT2_ONCONTEXTMENU = DISPID_EVPROP_ONCONTEXTMENU;
        public const int DISPID_IHTMLELEMENT2_INSERTADJACENTELEMENT = DISPID_ELEMENT + 69;
        public const int DISPID_IHTMLELEMENT2_APPLYELEMENT = DISPID_ELEMENT + 65;
        public const int DISPID_IHTMLELEMENT2_GETADJACENTTEXT = DISPID_ELEMENT + 70;
        public const int DISPID_IHTMLELEMENT2_REPLACEADJACENTTEXT = DISPID_ELEMENT + 71;
        public const int DISPID_IHTMLELEMENT2_CANHAVECHILDREN = DISPID_ELEMENT + 72;
        public const int DISPID_IHTMLELEMENT2_ADDBEHAVIOR = DISPID_ELEMENT + 80;
        public const int DISPID_IHTMLELEMENT2_REMOVEBEHAVIOR = DISPID_ELEMENT + 81;
        public const int DISPID_IHTMLELEMENT2_RUNTIMESTYLE = DISPID_ELEMENT + 64;
        public const int DISPID_IHTMLELEMENT2_BEHAVIORURNS = DISPID_ELEMENT + 82;
        public const int DISPID_IHTMLELEMENT2_TAGURN = DISPID_ELEMENT + 83;
        public const int DISPID_IHTMLELEMENT2_ONBEFOREEDITFOCUS = DISPID_EVPROP_ONBEFOREEDITFOCUS;
        public const int DISPID_IHTMLELEMENT2_READYSTATEVALUE = DISPID_ELEMENT + 84;
        public const int DISPID_IHTMLELEMENT2_GETELEMENTSBYTAGNAME = DISPID_ELEMENT + 85;

        //    DISPIDs for interface IHTMLElementCollection

        public const int DISPID_IHTMLELEMENTCOLLECTION_TOSTRING = DISPID_COLLECTION + 1;
        public const int DISPID_IHTMLELEMENTCOLLECTION_LENGTH = DISPID_COLLECTION;
        public const int DISPID_IHTMLELEMENTCOLLECTION__NEWENUM = DISPID_NEWENUM;
        public const int DISPID_IHTMLELEMENTCOLLECTION_ITEM = DISPID_VALUE;
        public const int DISPID_IHTMLELEMENTCOLLECTION_TAGS = DISPID_COLLECTION + 2;


        //    DISPIDs for interface IHTMLEventObj

        public const int DISPID_EVENTOBJ = DISPID_NORMAL_FIRST;

        public const int DISPID_IHTMLEVENTOBJ_SRCELEMENT = DISPID_EVENTOBJ + 1;
        public const int DISPID_IHTMLEVENTOBJ_ALTKEY = DISPID_EVENTOBJ + 2;
        public const int DISPID_IHTMLEVENTOBJ_CTRLKEY = DISPID_EVENTOBJ + 3;
        public const int DISPID_IHTMLEVENTOBJ_SHIFTKEY = DISPID_EVENTOBJ + 4;
        public const int DISPID_IHTMLEVENTOBJ_RETURNVALUE = DISPID_EVENTOBJ + 7;
        public const int DISPID_IHTMLEVENTOBJ_CANCELBUBBLE = DISPID_EVENTOBJ + 8;
        public const int DISPID_IHTMLEVENTOBJ_FROMELEMENT = DISPID_EVENTOBJ + 9;
        public const int DISPID_IHTMLEVENTOBJ_TOELEMENT = DISPID_EVENTOBJ + 10;
        public const int DISPID_IHTMLEVENTOBJ_KEYCODE = DISPID_EVENTOBJ + 11;
        public const int DISPID_IHTMLEVENTOBJ_BUTTON = DISPID_EVENTOBJ + 12;
        public const int DISPID_IHTMLEVENTOBJ_TYPE = DISPID_EVENTOBJ + 13;
        public const int DISPID_IHTMLEVENTOBJ_QUALIFIER = DISPID_EVENTOBJ + 14;
        public const int DISPID_IHTMLEVENTOBJ_REASON = DISPID_EVENTOBJ + 15;
        public const int DISPID_IHTMLEVENTOBJ_X = DISPID_EVENTOBJ + 5;
        public const int DISPID_IHTMLEVENTOBJ_Y = DISPID_EVENTOBJ + 6;
        public const int DISPID_IHTMLEVENTOBJ_CLIENTX = DISPID_EVENTOBJ + 20;
        public const int DISPID_IHTMLEVENTOBJ_CLIENTY = DISPID_EVENTOBJ + 21;
        public const int DISPID_IHTMLEVENTOBJ_OFFSETX = DISPID_EVENTOBJ + 22;
        public const int DISPID_IHTMLEVENTOBJ_OFFSETY = DISPID_EVENTOBJ + 23;
        public const int DISPID_IHTMLEVENTOBJ_SCREENX = DISPID_EVENTOBJ + 24;
        public const int DISPID_IHTMLEVENTOBJ_SCREENY = DISPID_EVENTOBJ + 25;
        public const int DISPID_IHTMLEVENTOBJ_SRCFILTER = DISPID_EVENTOBJ + 26;

        //    DISPIDs for interface IHTMLEventObj2

        public const int DISPID_IHTMLEVENTOBJ2_SETATTRIBUTE = DISPID_HTMLOBJECT + 1;
        public const int DISPID_IHTMLEVENTOBJ2_GETATTRIBUTE = DISPID_HTMLOBJECT + 2;
        public const int DISPID_IHTMLEVENTOBJ2_REMOVEATTRIBUTE = DISPID_HTMLOBJECT + 3;
        public const int DISPID_IHTMLEVENTOBJ2_PROPERTYNAME = DISPID_EVENTOBJ + 27;
        public const int DISPID_IHTMLEVENTOBJ2_BOOKMARKS = DISPID_EVENTOBJ + 31;
        public const int DISPID_IHTMLEVENTOBJ2_RECORDSET = DISPID_EVENTOBJ + 32;
        public const int DISPID_IHTMLEVENTOBJ2_DATAFLD = DISPID_EVENTOBJ + 33;
        public const int DISPID_IHTMLEVENTOBJ2_BOUNDELEMENTS = DISPID_EVENTOBJ + 34;
        public const int DISPID_IHTMLEVENTOBJ2_REPEAT = DISPID_EVENTOBJ + 35;
        public const int DISPID_IHTMLEVENTOBJ2_SRCURN = DISPID_EVENTOBJ + 36;
        public const int DISPID_IHTMLEVENTOBJ2_SRCELEMENT = DISPID_EVENTOBJ + 1;
        public const int DISPID_IHTMLEVENTOBJ2_ALTKEY = DISPID_EVENTOBJ + 2;
        public const int DISPID_IHTMLEVENTOBJ2_CTRLKEY = DISPID_EVENTOBJ + 3;
        public const int DISPID_IHTMLEVENTOBJ2_SHIFTKEY = DISPID_EVENTOBJ + 4;
        public const int DISPID_IHTMLEVENTOBJ2_FROMELEMENT = DISPID_EVENTOBJ + 9;
        public const int DISPID_IHTMLEVENTOBJ2_TOELEMENT = DISPID_EVENTOBJ + 10;
        public const int DISPID_IHTMLEVENTOBJ2_BUTTON = DISPID_EVENTOBJ + 12;
        public const int DISPID_IHTMLEVENTOBJ2_TYPE = DISPID_EVENTOBJ + 13;
        public const int DISPID_IHTMLEVENTOBJ2_QUALIFIER = DISPID_EVENTOBJ + 14;
        public const int DISPID_IHTMLEVENTOBJ2_REASON = DISPID_EVENTOBJ + 15;
        public const int DISPID_IHTMLEVENTOBJ2_X = DISPID_EVENTOBJ + 5;
        public const int DISPID_IHTMLEVENTOBJ2_Y = DISPID_EVENTOBJ + 6;
        public const int DISPID_IHTMLEVENTOBJ2_CLIENTX = DISPID_EVENTOBJ + 20;
        public const int DISPID_IHTMLEVENTOBJ2_CLIENTY = DISPID_EVENTOBJ + 21;
        public const int DISPID_IHTMLEVENTOBJ2_OFFSETX = DISPID_EVENTOBJ + 22;
        public const int DISPID_IHTMLEVENTOBJ2_OFFSETY = DISPID_EVENTOBJ + 23;
        public const int DISPID_IHTMLEVENTOBJ2_SCREENX = DISPID_EVENTOBJ + 24;
        public const int DISPID_IHTMLEVENTOBJ2_SCREENY = DISPID_EVENTOBJ + 25;
        public const int DISPID_IHTMLEVENTOBJ2_SRCFILTER = DISPID_EVENTOBJ + 26;
        public const int DISPID_IHTMLEVENTOBJ2_DATATRANSFER = DISPID_EVENTOBJ + 37;

        //    DISPIDs for interface IHTMLEventObj3

        public const int DISPID_IHTMLEVENTOBJ3_CONTENTOVERFLOW = DISPID_EVENTOBJ + 38;
        public const int DISPID_IHTMLEVENTOBJ3_SHIFTLEFT = DISPID_EVENTOBJ + 39;
        public const int DISPID_IHTMLEVENTOBJ3_ALTLEFT = DISPID_EVENTOBJ + 40;
        public const int DISPID_IHTMLEVENTOBJ3_CTRLLEFT = DISPID_EVENTOBJ + 41;
        public const int DISPID_IHTMLEVENTOBJ3_IMECOMPOSITIONCHANGE = DISPID_EVENTOBJ + 42;
        public const int DISPID_IHTMLEVENTOBJ3_IMENOTIFYCOMMAND = DISPID_EVENTOBJ + 43;
        public const int DISPID_IHTMLEVENTOBJ3_IMENOTIFYDATA = DISPID_EVENTOBJ + 44;
        public const int DISPID_IHTMLEVENTOBJ3_IMEREQUEST = DISPID_EVENTOBJ + 46;
        public const int DISPID_IHTMLEVENTOBJ3_IMEREQUESTDATA = DISPID_EVENTOBJ + 47;
        public const int DISPID_IHTMLEVENTOBJ3_KEYBOARDLAYOUT = DISPID_EVENTOBJ + 45;
        public const int DISPID_IHTMLEVENTOBJ3_BEHAVIORCOOKIE = DISPID_EVENTOBJ + 48;
        public const int DISPID_IHTMLEVENTOBJ3_BEHAVIORPART = DISPID_EVENTOBJ + 49;
        public const int DISPID_IHTMLEVENTOBJ3_NEXTPAGE = DISPID_EVENTOBJ + 50;


        public const int DISPID_A_FIRST = DISPID_ATTRS;
        public const int DISPID_A_DIR = DISPID_A_FIRST + 117;

        // DISPIDs for interface IHTMLDocument3
        public const int DISPID_IHTMLDOCUMENT3_RELEASECAPTURE = DISPID_OMDOCUMENT + 72;
        public const int DISPID_IHTMLDOCUMENT3_RECALC = DISPID_OMDOCUMENT + 73;
        public const int DISPID_IHTMLDOCUMENT3_CREATETEXTNODE = DISPID_OMDOCUMENT + 74;
        public const int DISPID_IHTMLDOCUMENT3_DOCUMENTELEMENT = DISPID_OMDOCUMENT + 75;
        public const int DISPID_IHTMLDOCUMENT3_UNIQUEID = DISPID_OMDOCUMENT + 77;
        public const int DISPID_IHTMLDOCUMENT3_ATTACHEVENT = DISPID_HTMLOBJECT + 7;
        public const int DISPID_IHTMLDOCUMENT3_DETACHEVENT = DISPID_HTMLOBJECT + 8;
        public const int DISPID_IHTMLDOCUMENT3_ONROWSDELETE = DISPID_EVPROP_ONROWSDELETE;
        public const int DISPID_IHTMLDOCUMENT3_ONROWSINSERTED = DISPID_EVPROP_ONROWSINSERTED;
        public const int DISPID_IHTMLDOCUMENT3_ONCELLCHANGE = DISPID_EVPROP_ONCELLCHANGE;
        public const int DISPID_IHTMLDOCUMENT3_ONDATASETCHANGED = DISPID_EVPROP_ONDATASETCHANGED;
        public const int DISPID_IHTMLDOCUMENT3_ONDATAAVAILABLE = DISPID_EVPROP_ONDATAAVAILABLE;
        public const int DISPID_IHTMLDOCUMENT3_ONDATASETCOMPLETE = DISPID_EVPROP_ONDATASETCOMPLETE;
        public const int DISPID_IHTMLDOCUMENT3_ONPROPERTYCHANGE = DISPID_EVPROP_ONPROPERTYCHANGE;
        public const int DISPID_IHTMLDOCUMENT3_DIR = DISPID_A_DIR;
        public const int DISPID_IHTMLDOCUMENT3_ONCONTEXTMENU = DISPID_EVPROP_ONCONTEXTMENU;
        public const int DISPID_IHTMLDOCUMENT3_ONSTOP = DISPID_EVPROP_ONSTOP;
        public const int DISPID_IHTMLDOCUMENT3_CREATEDOCUMENTFRAGMENT = DISPID_OMDOCUMENT + 76;
        public const int DISPID_IHTMLDOCUMENT3_PARENTDOCUMENT = DISPID_OMDOCUMENT + 78;
        public const int DISPID_IHTMLDOCUMENT3_ENABLEDOWNLOAD = DISPID_OMDOCUMENT + 79;
        public const int DISPID_IHTMLDOCUMENT3_BASEURL = DISPID_OMDOCUMENT + 80;
        public const int DISPID_IHTMLDOCUMENT3_CHILDNODES = DISPID_ELEMENT + 49;
        public const int DISPID_IHTMLDOCUMENT3_INHERITSTYLESHEETS = DISPID_OMDOCUMENT + 82;
        public const int DISPID_IHTMLDOCUMENT3_ONBEFOREEDITFOCUS = DISPID_EVPROP_ONBEFOREEDITFOCUS;
        public const int DISPID_IHTMLDOCUMENT3_GETELEMENTSBYNAME = DISPID_OMDOCUMENT + 86;
        public const int DISPID_IHTMLDOCUMENT3_GETELEMENTBYID = DISPID_OMDOCUMENT + 88;
        public const int DISPID_IHTMLDOCUMENT3_GETELEMENTSBYTAGNAME = DISPID_OMDOCUMENT + 87;

        //    DISPIDs for interface IHTMLDocument4
        public const int DISPID_OMDOCUMENT = DISPID_NORMAL_FIRST;

        public const int DISPID_IHTMLDOCUMENT4_FOCUS = DISPID_OMDOCUMENT + 89;
        public const int DISPID_IHTMLDOCUMENT4_HASFOCUS = DISPID_OMDOCUMENT + 90;
        public const int DISPID_IHTMLDOCUMENT4_ONSELECTIONCHANGE = DISPID_EVPROP_ONSELECTIONCHANGE;
        public const int DISPID_IHTMLDOCUMENT4_NAMESPACES = DISPID_OMDOCUMENT + 91;
        public const int DISPID_IHTMLDOCUMENT4_CREATEDOCUMENTFROMURL = DISPID_OMDOCUMENT + 92;
        public const int DISPID_IHTMLDOCUMENT4_MEDIA = DISPID_OMDOCUMENT + 93;
        public const int DISPID_IHTMLDOCUMENT4_CREATEEVENTOBJECT = DISPID_OMDOCUMENT + 94;
        public const int DISPID_IHTMLDOCUMENT4_FIREEVENT = DISPID_OMDOCUMENT + 95;
        public const int DISPID_IHTMLDOCUMENT4_CREATERENDERSTYLE = DISPID_OMDOCUMENT + 96;
        public const int DISPID_IHTMLDOCUMENT4_ONCONTROLSELECT = DISPID_EVPROP_ONCONTROLSELECT;
        public const int DISPID_IHTMLDOCUMENT4_URLUNENCODED = DISPID_OMDOCUMENT + 97;

        //    DISPIDs for interface IHTMLDocument5

        public const int DISPID_IHTMLDOCUMENT5_ONMOUSEWHEEL = DISPID_EVPROP_ONMOUSEWHEEL;
        public const int DISPID_IHTMLDOCUMENT5_DOCTYPE = DISPID_OMDOCUMENT + 98;
        public const int DISPID_IHTMLDOCUMENT5_IMPLEMENTATION = DISPID_OMDOCUMENT + 99;
        public const int DISPID_IHTMLDOCUMENT5_CREATEATTRIBUTE = DISPID_OMDOCUMENT + 100;
        public const int DISPID_IHTMLDOCUMENT5_CREATECOMMENT = DISPID_OMDOCUMENT + 101;
        public const int DISPID_IHTMLDOCUMENT5_ONFOCUSIN = DISPID_EVPROP_ONFOCUSIN;
        public const int DISPID_IHTMLDOCUMENT5_ONFOCUSOUT = DISPID_EVPROP_ONFOCUSOUT;
        public const int DISPID_IHTMLDOCUMENT5_ONACTIVATE = DISPID_EVPROP_ONACTIVATE;
        public const int DISPID_IHTMLDOCUMENT5_ONDEACTIVATE = DISPID_EVPROP_ONDEACTIVATE;
        public const int DISPID_IHTMLDOCUMENT5_ONBEFOREACTIVATE = DISPID_EVPROP_ONBEFOREACTIVATE;
        public const int DISPID_IHTMLDOCUMENT5_ONBEFOREDEACTIVATE = DISPID_EVPROP_ONBEFOREDEACTIVATE;
        public const int DISPID_IHTMLDOCUMENT5_COMPATMODE = DISPID_OMDOCUMENT + 102;


        //DISPIDS for interface IHTMLDocumentEvents2
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONHELP = DISPID_EVMETH_ONHELP;
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONCLICK = DISPID_EVMETH_ONCLICK;
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONDBLCLICK = DISPID_EVMETH_ONDBLCLICK;
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONKEYDOWN = DISPID_EVMETH_ONKEYDOWN;
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONKEYUP = DISPID_EVMETH_ONKEYUP;
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONKEYPRESS = DISPID_EVMETH_ONKEYPRESS;
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONMOUSEDOWN = DISPID_EVMETH_ONMOUSEDOWN;
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONMOUSEMOVE = DISPID_EVMETH_ONMOUSEMOVE;
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONMOUSEUP = DISPID_EVMETH_ONMOUSEUP;
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONMOUSEOUT = DISPID_EVMETH_ONMOUSEOUT;
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONMOUSEOVER = DISPID_EVMETH_ONMOUSEOVER;
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONREADYSTATECHANGE = DISPID_EVMETH_ONREADYSTATECHANGE;
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONBEFOREUPDATE = DISPID_EVMETH_ONBEFOREUPDATE;
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONAFTERUPDATE = DISPID_EVMETH_ONAFTERUPDATE;
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONROWEXIT = DISPID_EVMETH_ONROWEXIT;
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONROWENTER = DISPID_EVMETH_ONROWENTER;
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONDRAGSTART = DISPID_EVMETH_ONDRAGSTART;
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONSELECTSTART = DISPID_EVMETH_ONSELECTSTART;
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONERRORUPDATE = DISPID_EVMETH_ONERRORUPDATE;
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONCONTEXTMENU = DISPID_EVMETH_ONCONTEXTMENU;
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONSTOP = DISPID_EVMETH_ONSTOP;
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONROWSDELETE = DISPID_EVMETH_ONROWSDELETE;
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONROWSINSERTED = DISPID_EVMETH_ONROWSINSERTED;
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONCELLCHANGE = DISPID_EVMETH_ONCELLCHANGE;
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONPROPERTYCHANGE = DISPID_EVMETH_ONPROPERTYCHANGE;
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONDATASETCHANGED = DISPID_EVMETH_ONDATASETCHANGED;
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONDATAAVAILABLE = DISPID_EVMETH_ONDATAAVAILABLE;
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONDATASETCOMPLETE = DISPID_EVMETH_ONDATASETCOMPLETE;
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONBEFOREEDITFOCUS = DISPID_EVMETH_ONBEFOREEDITFOCUS;
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONSELECTIONCHANGE = DISPID_EVMETH_ONSELECTIONCHANGE;
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONCONTROLSELECT = DISPID_EVMETH_ONCONTROLSELECT;
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONMOUSEWHEEL = DISPID_EVMETH_ONMOUSEWHEEL;
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONFOCUSIN = DISPID_EVMETH_ONFOCUSIN;
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONFOCUSOUT = DISPID_EVMETH_ONFOCUSOUT;
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONACTIVATE = DISPID_EVMETH_ONACTIVATE;
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONDEACTIVATE = DISPID_EVMETH_ONDEACTIVATE;
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONBEFOREACTIVATE = DISPID_EVMETH_ONBEFOREACTIVATE;
        public const int DISPID_HTMLDOCUMENTEVENTS2_ONBEFOREDEACTIVATE = DISPID_EVMETH_ONBEFOREDEACTIVATE;

        //    DISPIDs for event set HTMLWindowEvents2

        public const int DISPID_HTMLWINDOWEVENTS2_ONLOAD = DISPID_EVMETH_ONLOAD;
        public const int DISPID_HTMLWINDOWEVENTS2_ONUNLOAD = DISPID_EVMETH_ONUNLOAD;
        public const int DISPID_HTMLWINDOWEVENTS2_ONHELP = DISPID_EVMETH_ONHELP;
        public const int DISPID_HTMLWINDOWEVENTS2_ONFOCUS = DISPID_EVMETH_ONFOCUS;
        public const int DISPID_HTMLWINDOWEVENTS2_ONBLUR = DISPID_EVMETH_ONBLUR;
        public const int DISPID_HTMLWINDOWEVENTS2_ONERROR = DISPID_EVMETH_ONERROR;
        public const int DISPID_HTMLWINDOWEVENTS2_ONRESIZE = DISPID_EVMETH_ONRESIZE;
        public const int DISPID_HTMLWINDOWEVENTS2_ONSCROLL = DISPID_EVMETH_ONSCROLL;
        public const int DISPID_HTMLWINDOWEVENTS2_ONBEFOREUNLOAD = DISPID_EVMETH_ONBEFOREUNLOAD;
        public const int DISPID_HTMLWINDOWEVENTS2_ONBEFOREPRINT = DISPID_EVMETH_ONBEFOREPRINT;
        public const int DISPID_HTMLWINDOWEVENTS2_ONAFTERPRINT = DISPID_EVMETH_ONAFTERPRINT;

        //    DISPIDs for interface IHTMLDOMNode

        public const int DISPID_IHTMLDOMNODE_NODETYPE = DISPID_ELEMENT + 46;
        public const int DISPID_IHTMLDOMNODE_PARENTNODE = DISPID_ELEMENT + 47;
        public const int DISPID_IHTMLDOMNODE_HASCHILDNODES = DISPID_ELEMENT + 48;
        public const int DISPID_IHTMLDOMNODE_CHILDNODES = DISPID_ELEMENT + 49;
        public const int DISPID_IHTMLDOMNODE_ATTRIBUTES = DISPID_ELEMENT + 50;
        public const int DISPID_IHTMLDOMNODE_INSERTBEFORE = DISPID_ELEMENT + 51;
        public const int DISPID_IHTMLDOMNODE_REMOVECHILD = DISPID_ELEMENT + 52;
        public const int DISPID_IHTMLDOMNODE_REPLACECHILD = DISPID_ELEMENT + 53;
        public const int DISPID_IHTMLDOMNODE_CLONENODE = DISPID_ELEMENT + 61;
        public const int DISPID_IHTMLDOMNODE_REMOVENODE = DISPID_ELEMENT + 66;
        public const int DISPID_IHTMLDOMNODE_SWAPNODE = DISPID_ELEMENT + 68;
        public const int DISPID_IHTMLDOMNODE_REPLACENODE = DISPID_ELEMENT + 67;
        public const int DISPID_IHTMLDOMNODE_APPENDCHILD = DISPID_ELEMENT + 73;
        public const int DISPID_IHTMLDOMNODE_NODENAME = DISPID_ELEMENT + 74;
        public const int DISPID_IHTMLDOMNODE_NODEVALUE = DISPID_ELEMENT + 75;
        public const int DISPID_IHTMLDOMNODE_FIRSTCHILD = DISPID_ELEMENT + 76;
        public const int DISPID_IHTMLDOMNODE_LASTCHILD = DISPID_ELEMENT + 77;
        public const int DISPID_IHTMLDOMNODE_PREVIOUSSIBLING = DISPID_ELEMENT + 78;
        public const int DISPID_IHTMLDOMNODE_NEXTSIBLING = DISPID_ELEMENT + 79;

        public const int DISPID_COLLECTION_MIN = 1000000;
        public const int DISPID_COLLECTION_MAX = 2999999;
        public const int DISPID_COLLECTION = (DISPID_NORMAL_FIRST + 500);
        public const int DISPID_VALUE = 0;

        /* The following DISPID is reserved to indicate the param
         * that is the right-hand-side (or "put" value) of a PropertyPut
         */
        public const int DISPID_PROPERTYPUT = -3;

        /* DISPID reserved for the standard "NewEnum" method */
        public const int DISPID_NEWENUM = -4;

        //    DISPIDs for interface IHTMLDOMChildrenCollection

        public const int DISPID_IHTMLDOMCHILDRENCOLLECTION_LENGTH = DISPID_COLLECTION;
        public const int DISPID_IHTMLDOMCHILDRENCOLLECTION__NEWENUM = DISPID_NEWENUM;
        public const int DISPID_IHTMLDOMCHILDRENCOLLECTION_ITEM = DISPID_VALUE;

        //    DISPIDs for interface IHTMLFramesCollection2

        public const int DISPID_IHTMLFRAMESCOLLECTION2_ITEM = 0;
        public const int DISPID_IHTMLFRAMESCOLLECTION2_LENGTH = 1001;

        //    DISPIDs for interface IHTMLWindow2

        public const int DISPID_IHTMLWINDOW2_FRAMES = 1100;
        public const int DISPID_IHTMLWINDOW2_DEFAULTSTATUS = 1101;
        public const int DISPID_IHTMLWINDOW2_STATUS = 1102;
        public const int DISPID_IHTMLWINDOW2_SETTIMEOUT = 1172;
        public const int DISPID_IHTMLWINDOW2_CLEARTIMEOUT = 1104;
        public const int DISPID_IHTMLWINDOW2_ALERT = 1105;
        public const int DISPID_IHTMLWINDOW2_CONFIRM = 1110;
        public const int DISPID_IHTMLWINDOW2_PROMPT = 1111;
        public const int DISPID_IHTMLWINDOW2_IMAGE = 1125;
        public const int DISPID_IHTMLWINDOW2_LOCATION = 14;
        public const int DISPID_IHTMLWINDOW2_HISTORY = 2;
        public const int DISPID_IHTMLWINDOW2_CLOSE = 3;
        public const int DISPID_IHTMLWINDOW2_OPENER = 4;
        public const int DISPID_IHTMLWINDOW2_NAVIGATOR = 5;
        public const int DISPID_IHTMLWINDOW2_NAME = 11;
        public const int DISPID_IHTMLWINDOW2_PARENT = 12;
        public const int DISPID_IHTMLWINDOW2_OPEN = 13;
        public const int DISPID_IHTMLWINDOW2_SELF = 20;
        public const int DISPID_IHTMLWINDOW2_TOP = 21;
        public const int DISPID_IHTMLWINDOW2_WINDOW = 22;
        public const int DISPID_IHTMLWINDOW2_NAVIGATE = 25;
        public const int DISPID_IHTMLWINDOW2_ONFOCUS = DISPID_EVPROP_ONFOCUS;
        public const int DISPID_IHTMLWINDOW2_ONBLUR = DISPID_EVPROP_ONBLUR;
        public const int DISPID_IHTMLWINDOW2_ONLOAD = DISPID_EVPROP_ONLOAD;
        public const int DISPID_IHTMLWINDOW2_ONBEFOREUNLOAD = DISPID_EVPROP_ONBEFOREUNLOAD;
        public const int DISPID_IHTMLWINDOW2_ONUNLOAD = DISPID_EVPROP_ONUNLOAD;
        public const int DISPID_IHTMLWINDOW2_ONHELP = DISPID_EVPROP_ONHELP;
        public const int DISPID_IHTMLWINDOW2_ONERROR = DISPID_EVPROP_ONERROR;
        public const int DISPID_IHTMLWINDOW2_ONRESIZE = DISPID_EVPROP_ONRESIZE;
        public const int DISPID_IHTMLWINDOW2_ONSCROLL = DISPID_EVPROP_ONSCROLL;
        public const int DISPID_IHTMLWINDOW2_DOCUMENT = 1151;
        public const int DISPID_IHTMLWINDOW2_EVENT = 1152;
        public const int DISPID_IHTMLWINDOW2__NEWENUM = 1153;
        public const int DISPID_IHTMLWINDOW2_SHOWMODALDIALOG = 1154;
        public const int DISPID_IHTMLWINDOW2_SHOWHELP = 1155;
        public const int DISPID_IHTMLWINDOW2_SCREEN = 1156;
        public const int DISPID_IHTMLWINDOW2_OPTION = 1157;
        public const int DISPID_IHTMLWINDOW2_FOCUS = 1158;
        public const int DISPID_IHTMLWINDOW2_CLOSED = 23;
        public const int DISPID_IHTMLWINDOW2_BLUR = 1159;
        public const int DISPID_IHTMLWINDOW2_SCROLL = 1160;
        public const int DISPID_IHTMLWINDOW2_CLIENTINFORMATION = 1161;
        public const int DISPID_IHTMLWINDOW2_SETINTERVAL = 1173;
        public const int DISPID_IHTMLWINDOW2_CLEARINTERVAL = 1163;
        public const int DISPID_IHTMLWINDOW2_OFFSCREENBUFFERING = 1164;
        public const int DISPID_IHTMLWINDOW2_EXECSCRIPT = 1165;
        public const int DISPID_IHTMLWINDOW2_TOSTRING = 1166;
        public const int DISPID_IHTMLWINDOW2_SCROLLBY = 1167;
        public const int DISPID_IHTMLWINDOW2_SCROLLTO = 1168;
        public const int DISPID_IHTMLWINDOW2_MOVETO = 6;
        public const int DISPID_IHTMLWINDOW2_MOVEBY = 7;
        public const int DISPID_IHTMLWINDOW2_RESIZETO = 9;
        public const int DISPID_IHTMLWINDOW2_RESIZEBY = 8;
        public const int DISPID_IHTMLWINDOW2_EXTERNAL = 1169;

        //    DISPIDS for interface IHtmlAncher
        public const int DISPID_ANCHOR = DISPID_NORMAL_FIRST;
        public const int STDPROPID_XOBJ_TABINDEX = DISPID_XOBJ_BASE + 0xF;

        public const int DISPID_IHTMLANCHORELEMENT_HREF = DISPID_VALUE;
        public const int DISPID_IHTMLANCHORELEMENT_TARGET = DISPID_ANCHOR + 3;
        public const int DISPID_IHTMLANCHORELEMENT_REL = DISPID_ANCHOR + 5;
        public const int DISPID_IHTMLANCHORELEMENT_REV = DISPID_ANCHOR + 6;
        public const int DISPID_IHTMLANCHORELEMENT_URN = DISPID_ANCHOR + 7;
        public const int DISPID_IHTMLANCHORELEMENT_METHODS = DISPID_ANCHOR + 8;
        public const int DISPID_IHTMLANCHORELEMENT_NAME = STDPROPID_XOBJ_NAME;
        public const int DISPID_IHTMLANCHORELEMENT_HOST = DISPID_ANCHOR + 12;
        public const int DISPID_IHTMLANCHORELEMENT_HOSTNAME = DISPID_ANCHOR + 13;
        public const int DISPID_IHTMLANCHORELEMENT_PATHNAME = DISPID_ANCHOR + 14;
        public const int DISPID_IHTMLANCHORELEMENT_PORT = DISPID_ANCHOR + 15;
        public const int DISPID_IHTMLANCHORELEMENT_PROTOCOL = DISPID_ANCHOR + 16;
        public const int DISPID_IHTMLANCHORELEMENT_SEARCH = DISPID_ANCHOR + 17;
        public const int DISPID_IHTMLANCHORELEMENT_HASH = DISPID_ANCHOR + 18;
        public const int DISPID_IHTMLANCHORELEMENT_ONBLUR = DISPID_EVPROP_ONBLUR;
        public const int DISPID_IHTMLANCHORELEMENT_ONFOCUS = DISPID_EVPROP_ONFOCUS;
        public const int DISPID_IHTMLANCHORELEMENT_ACCESSKEY = DISPID_SITE + 5;
        public const int DISPID_IHTMLANCHORELEMENT_PROTOCOLLONG = DISPID_ANCHOR + 31;
        public const int DISPID_IHTMLANCHORELEMENT_MIMETYPE = DISPID_ANCHOR + 30;
        public const int DISPID_IHTMLANCHORELEMENT_NAMEPROP = DISPID_ANCHOR + 32;
        public const int DISPID_IHTMLANCHORELEMENT_TABINDEX = STDPROPID_XOBJ_TABINDEX;
        public const int DISPID_IHTMLANCHORELEMENT_FOCUS = DISPID_SITE + 0;
        public const int DISPID_IHTMLANCHORELEMENT_BLUR = DISPID_SITE + 2;

        //    DISPIDs for interface IHTMLImgElement

        public const int DISPID_IMGBASE = DISPID_NORMAL_FIRST;
        public const int DISPID_IMG = (DISPID_IMGBASE + 1000);
        public const int DISPID_INPUTIMAGE = (DISPID_IMGBASE + 1000);
        public const int DISPID_INPUT = (DISPID_TEXTSITE + 1000);
        public const int DISPID_INPUTTEXTBASE = (DISPID_INPUT + 1000);
        public const int DISPID_INPUTTEXT = (DISPID_INPUTTEXTBASE + 1000);
        public const int DISPID_SELECT = DISPID_NORMAL_FIRST;

        public const int DISPID_A_READYSTATE = (DISPID_A_FIRST + 116); // ready state
        public const int STDPROPID_XOBJ_CONTROLALIGN = (DISPID_XOBJ_BASE + 0x49);
        public const int STDPROPID_XOBJ_NAME = (DISPID_XOBJ_BASE + 0x0);
        public const int STDPROPID_XOBJ_WIDTH = (DISPID_XOBJ_BASE + 0x5);
        public const int STDPROPID_XOBJ_HEIGHT = (DISPID_XOBJ_BASE + 0x6);

        public const int DISPID_IHTMLIMGELEMENT_ISMAP = DISPID_IMG + 2;
        public const int DISPID_IHTMLIMGELEMENT_USEMAP = DISPID_IMG + 8;
        public const int DISPID_IHTMLIMGELEMENT_MIMETYPE = DISPID_IMG + 10;
        public const int DISPID_IHTMLIMGELEMENT_FILESIZE = DISPID_IMG + 11;
        public const int DISPID_IHTMLIMGELEMENT_FILECREATEDDATE = DISPID_IMG + 12;
        public const int DISPID_IHTMLIMGELEMENT_FILEMODIFIEDDATE = DISPID_IMG + 13;
        public const int DISPID_IHTMLIMGELEMENT_FILEUPDATEDDATE = DISPID_IMG + 14;
        public const int DISPID_IHTMLIMGELEMENT_PROTOCOL = DISPID_IMG + 15;
        public const int DISPID_IHTMLIMGELEMENT_HREF = DISPID_IMG + 16;
        public const int DISPID_IHTMLIMGELEMENT_NAMEPROP = DISPID_IMG + 17;
        public const int DISPID_IHTMLIMGELEMENT_BORDER = DISPID_IMGBASE + 4;
        public const int DISPID_IHTMLIMGELEMENT_VSPACE = DISPID_IMGBASE + 5;
        public const int DISPID_IHTMLIMGELEMENT_HSPACE = DISPID_IMGBASE + 6;
        public const int DISPID_IHTMLIMGELEMENT_ALT = DISPID_IMGBASE + 2;
        public const int DISPID_IHTMLIMGELEMENT_SRC = DISPID_IMGBASE + 3;
        public const int DISPID_IHTMLIMGELEMENT_LOWSRC = DISPID_IMGBASE + 7;
        public const int DISPID_IHTMLIMGELEMENT_VRML = DISPID_IMGBASE + 8;
        public const int DISPID_IHTMLIMGELEMENT_DYNSRC = DISPID_IMGBASE + 9;
        public const int DISPID_IHTMLIMGELEMENT_READYSTATE = DISPID_A_READYSTATE;
        public const int DISPID_IHTMLIMGELEMENT_COMPLETE = DISPID_IMGBASE + 10;
        public const int DISPID_IHTMLIMGELEMENT_LOOP = DISPID_IMGBASE + 11;
        public const int DISPID_IHTMLIMGELEMENT_ALIGN = STDPROPID_XOBJ_CONTROLALIGN;
        public const int DISPID_IHTMLIMGELEMENT_ONLOAD = DISPID_EVPROP_ONLOAD;
        public const int DISPID_IHTMLIMGELEMENT_ONERROR = DISPID_EVPROP_ONERROR;
        public const int DISPID_IHTMLIMGELEMENT_ONABORT = DISPID_EVPROP_ONABORT;
        public const int DISPID_IHTMLIMGELEMENT_NAME = STDPROPID_XOBJ_NAME;
        public const int DISPID_IHTMLIMGELEMENT_WIDTH = STDPROPID_XOBJ_WIDTH;
        public const int DISPID_IHTMLIMGELEMENT_HEIGHT = STDPROPID_XOBJ_HEIGHT;
        public const int DISPID_IHTMLIMGELEMENT_START = DISPID_IMGBASE + 13;

        //    DISPIDs for interface IHTMLTxtRange
        public const int DISPID_RANGE = DISPID_NORMAL_FIRST;

        public const int DISPID_IHTMLTXTRANGE_HTMLTEXT = DISPID_RANGE + 3;
        public const int DISPID_IHTMLTXTRANGE_TEXT = DISPID_RANGE + 4;
        public const int DISPID_IHTMLTXTRANGE_PARENTELEMENT = DISPID_RANGE + 6;
        public const int DISPID_IHTMLTXTRANGE_DUPLICATE = DISPID_RANGE + 8;
        public const int DISPID_IHTMLTXTRANGE_INRANGE = DISPID_RANGE + 10;
        public const int DISPID_IHTMLTXTRANGE_ISEQUAL = DISPID_RANGE + 11;
        public const int DISPID_IHTMLTXTRANGE_SCROLLINTOVIEW = DISPID_RANGE + 12;
        public const int DISPID_IHTMLTXTRANGE_COLLAPSE = DISPID_RANGE + 13;
        public const int DISPID_IHTMLTXTRANGE_EXPAND = DISPID_RANGE + 14;
        public const int DISPID_IHTMLTXTRANGE_MOVE = DISPID_RANGE + 15;
        public const int DISPID_IHTMLTXTRANGE_MOVESTART = DISPID_RANGE + 16;
        public const int DISPID_IHTMLTXTRANGE_MOVEEND = DISPID_RANGE + 17;
        public const int DISPID_IHTMLTXTRANGE_SELECT = DISPID_RANGE + 24;
        public const int DISPID_IHTMLTXTRANGE_PASTEHTML = DISPID_RANGE + 26;
        public const int DISPID_IHTMLTXTRANGE_MOVETOELEMENTTEXT = DISPID_RANGE + 1;
        public const int DISPID_IHTMLTXTRANGE_SETENDPOINT = DISPID_RANGE + 25;
        public const int DISPID_IHTMLTXTRANGE_COMPAREENDPOINTS = DISPID_RANGE + 18;
        public const int DISPID_IHTMLTXTRANGE_FINDTEXT = DISPID_RANGE + 19;
        public const int DISPID_IHTMLTXTRANGE_MOVETOPOINT = DISPID_RANGE + 20;
        public const int DISPID_IHTMLTXTRANGE_GETBOOKMARK = DISPID_RANGE + 21;
        public const int DISPID_IHTMLTXTRANGE_MOVETOBOOKMARK = DISPID_RANGE + 9;
        public const int DISPID_IHTMLTXTRANGE_QUERYCOMMANDSUPPORTED = DISPID_RANGE + 27;
        public const int DISPID_IHTMLTXTRANGE_QUERYCOMMANDENABLED = DISPID_RANGE + 28;
        public const int DISPID_IHTMLTXTRANGE_QUERYCOMMANDSTATE = DISPID_RANGE + 29;
        public const int DISPID_IHTMLTXTRANGE_QUERYCOMMANDINDETERM = DISPID_RANGE + 30;
        public const int DISPID_IHTMLTXTRANGE_QUERYCOMMANDTEXT = DISPID_RANGE + 31;
        public const int DISPID_IHTMLTXTRANGE_QUERYCOMMANDVALUE = DISPID_RANGE + 32;
        public const int DISPID_IHTMLTXTRANGE_EXECCOMMAND = DISPID_RANGE + 33;
        public const int DISPID_IHTMLTXTRANGE_EXECCOMMANDSHOWHELP = DISPID_RANGE + 34;

        //    DISPIDs for interface IHTMLDOMAttribute

        public const int DISPID_DOMATTRIBUTE = DISPID_NORMAL_FIRST;

        public const int DISPID_IHTMLDOMATTRIBUTE_NODENAME = DISPID_DOMATTRIBUTE;
        public const int DISPID_IHTMLDOMATTRIBUTE_NODEVALUE = DISPID_DOMATTRIBUTE + 2;
        public const int DISPID_IHTMLDOMATTRIBUTE_SPECIFIED = DISPID_DOMATTRIBUTE + 1;

        //    DISPIDs for interface IHTMLAttributeCollection

        public const int DISPID_IHTMLATTRIBUTECOLLECTION_LENGTH = DISPID_COLLECTION;
        public const int DISPID_IHTMLATTRIBUTECOLLECTION__NEWENUM = DISPID_NEWENUM;
        public const int DISPID_IHTMLATTRIBUTECOLLECTION_ITEM = DISPID_VALUE;

        //    DISPIDs for interface IHTMLStyleSheetsCollection

        public const int DISPID_STYLESHEETS_COL = DISPID_NORMAL_FIRST;

        public const int DISPID_IHTMLSTYLESHEETSCOLLECTION_LENGTH = DISPID_STYLESHEETS_COL + 1;
        public const int DISPID_IHTMLSTYLESHEETSCOLLECTION__NEWENUM = DISPID_NEWENUM;
        public const int DISPID_IHTMLSTYLESHEETSCOLLECTION_ITEM = DISPID_VALUE;

        //    DISPIDs for interface IHTMLSelectionObject

        public const int DISPID_SELECTOBJ = DISPID_NORMAL_FIRST;

        public const int DISPID_IHTMLSELECTIONOBJECT_CREATERANGE = DISPID_SELECTOBJ + 1;
        public const int DISPID_IHTMLSELECTIONOBJECT_EMPTY = DISPID_SELECTOBJ + 2;
        public const int DISPID_IHTMLSELECTIONOBJECT_CLEAR = DISPID_SELECTOBJ + 3;
        public const int DISPID_IHTMLSELECTIONOBJECT_TYPE = DISPID_SELECTOBJ + 4;

        // DISPIDS for interface IHTMLBodyElement
        public const int DISPID_TEXTSITE = DISPID_NORMAL_FIRST;
        public const int DISPID_BODY = (DISPID_TEXTSITE + 1000);
        public const int DISPID_IHTMLBODYELEMENT_CREATETEXTRANGE = DISPID_BODY + 13;

        //    DISPIDs for interface IHTMLDOMTextNode
        public const int DISPID_DOMTEXTNODE = DISPID_NORMAL_FIRST;

        public const int DISPID_IHTMLDOMTEXTNODE_DATA       = DISPID_DOMTEXTNODE;
        public const int DISPID_IHTMLDOMTEXTNODE_TOSTRING   = DISPID_DOMTEXTNODE+1;
        public const int DISPID_IHTMLDOMTEXTNODE_LENGTH     = DISPID_DOMTEXTNODE+2;
        public const int DISPID_IHTMLDOMTEXTNODE_SPLITTEXT  = DISPID_DOMTEXTNODE+3;

        //    DISPIDs for interface IHTMLDOMTextNode2
        public const int DISPID_IHTMLDOMTEXTNODE2_SUBSTRINGDATA = DISPID_DOMTEXTNODE+4;
        public const int DISPID_IHTMLDOMTEXTNODE2_APPENDDATA    = DISPID_DOMTEXTNODE+5;
        public const int DISPID_IHTMLDOMTEXTNODE2_INSERTDATA    = DISPID_DOMTEXTNODE+6;
        public const int DISPID_IHTMLDOMTEXTNODE2_DELETEDATA    = DISPID_DOMTEXTNODE+7;
        public const int DISPID_IHTMLDOMTEXTNODE2_REPLACEDATA   = DISPID_DOMTEXTNODE + 8;

        //    DISPIDs for interface IHTMLDOMAttribute2
        public const int DISPID_IHTMLDOMATTRIBUTE2_NAME             =DISPID_DOMATTRIBUTE+3;
        public const int DISPID_IHTMLDOMATTRIBUTE2_VALUE            =DISPID_DOMATTRIBUTE+4;
        public const int DISPID_IHTMLDOMATTRIBUTE2_EXPANDO          =DISPID_DOMATTRIBUTE+5;
        public const int DISPID_IHTMLDOMATTRIBUTE2_NODETYPE         =DISPID_DOMATTRIBUTE+6;
        public const int DISPID_IHTMLDOMATTRIBUTE2_PARENTNODE       =DISPID_DOMATTRIBUTE+7;
        public const int DISPID_IHTMLDOMATTRIBUTE2_CHILDNODES       =DISPID_DOMATTRIBUTE+8;
        public const int DISPID_IHTMLDOMATTRIBUTE2_FIRSTCHILD       =DISPID_DOMATTRIBUTE+9;
        public const int DISPID_IHTMLDOMATTRIBUTE2_LASTCHILD        =DISPID_DOMATTRIBUTE+10;
        public const int DISPID_IHTMLDOMATTRIBUTE2_PREVIOUSSIBLING  =DISPID_DOMATTRIBUTE+11;
        public const int DISPID_IHTMLDOMATTRIBUTE2_NEXTSIBLING      =DISPID_DOMATTRIBUTE+12;
        public const int DISPID_IHTMLDOMATTRIBUTE2_ATTRIBUTES       =DISPID_DOMATTRIBUTE+13;
        public const int DISPID_IHTMLDOMATTRIBUTE2_OWNERDOCUMENT    =DISPID_DOMATTRIBUTE+14;
        public const int DISPID_IHTMLDOMATTRIBUTE2_INSERTBEFORE     =DISPID_DOMATTRIBUTE+15;
        public const int DISPID_IHTMLDOMATTRIBUTE2_REPLACECHILD     =DISPID_DOMATTRIBUTE+16;
        public const int DISPID_IHTMLDOMATTRIBUTE2_REMOVECHILD      =DISPID_DOMATTRIBUTE+17;
        public const int DISPID_IHTMLDOMATTRIBUTE2_APPENDCHILD      =DISPID_DOMATTRIBUTE+18;
        public const int DISPID_IHTMLDOMATTRIBUTE2_HASCHILDNODES    =DISPID_DOMATTRIBUTE+19;
        public const int DISPID_IHTMLDOMATTRIBUTE2_CLONENODE = DISPID_DOMATTRIBUTE + 20;

        public const int DISPID_HEDELEMS = DISPID_NORMAL_FIRST;

        //    DISPIDs for interface IHTMLHeadElement
        public const int DISPID_IHTMLHEADELEMENT_PROFILE = DISPID_HEDELEMS + 1;

        public const int DISPID_A_VALUE = DISPID_A_FIRST+101;
        //    DISPIDs for interface IHTMLTitleElement
        public const int DISPID_IHTMLTITLEELEMENT_TEXT = DISPID_A_VALUE;

        //    DISPIDs for interface IHTMLMetaElement
        public const int DISPID_IHTMLMETAELEMENT_HTTPEQUIV = DISPID_HEDELEMS + 1;
        public const int DISPID_IHTMLMETAELEMENT_CONTENT = DISPID_HEDELEMS + 2;
        public const int DISPID_IHTMLMETAELEMENT_NAME = STDPROPID_XOBJ_NAME;
        public const int DISPID_IHTMLMETAELEMENT_URL = DISPID_HEDELEMS + 3;
        public const int DISPID_IHTMLMETAELEMENT_CHARSET = DISPID_HEDELEMS + 13;

        //    DISPIDs for interface IHTMLMetaElement2
        public const int DISPID_IHTMLMETAELEMENT2_SCHEME = DISPID_HEDELEMS + 20;

        //    DISPIDs for interface IHTMLBaseElement
        public const int DISPID_IHTMLBASEELEMENT_HREF = DISPID_HEDELEMS + 3;
        public const int DISPID_IHTMLBASEELEMENT_TARGET = DISPID_HEDELEMS + 4;

        //    DISPIDs for interface IHTMLNextIdElement
        public const int DISPID_IHTMLNEXTIDELEMENT_N = DISPID_HEDELEMS+12;

        public const int DISPID_A_COLOR = DISPID_A_FIRST + 2;
        public const int DISPID_A_FONTFACE = DISPID_A_FIRST+18;
        public const int DISPID_A_FONTSIZE = DISPID_A_FIRST+19;
        public const int DISPID_A_FONTSTYLE = DISPID_A_FIRST+24;
        public const int DISPID_A_FONTVARIANT  = DISPID_A_FIRST+25;
        public const int DISPID_A_BASEFONT   = DISPID_A_FIRST+26;
        public const int DISPID_A_FONTWEIGHT = DISPID_A_FIRST+27;

        //    DISPIDs for interface IHTMLBaseFontElement
        public const int DISPID_IHTMLBASEFONTELEMENT_COLOR = DISPID_A_COLOR;
        public const int DISPID_IHTMLBASEFONTELEMENT_FACE  = DISPID_A_FONTFACE;
        public const int DISPID_IHTMLBASEFONTELEMENT_SIZE = DISPID_A_BASEFONT;

        public const int DISPID_SCRIPT = DISPID_NORMAL_FIRST;
        //    DISPIDs for interface IHTMLScriptElement
        public const int DISPID_IHTMLSCRIPTELEMENT_SRC         = DISPID_SCRIPT+1;
        public const int DISPID_IHTMLSCRIPTELEMENT_HTMLFOR     = DISPID_SCRIPT+4;
        public const int DISPID_IHTMLSCRIPTELEMENT_EVENT       = DISPID_SCRIPT+5;
        public const int DISPID_IHTMLSCRIPTELEMENT_TEXT        = DISPID_SCRIPT+6;
        public const int DISPID_IHTMLSCRIPTELEMENT_DEFER       = DISPID_SCRIPT+7;
        public const int DISPID_IHTMLSCRIPTELEMENT_READYSTATE  = DISPID_A_READYSTATE;
        public const int DISPID_IHTMLSCRIPTELEMENT_ONERROR     = DISPID_EVPROP_ONERROR;
        public const int DISPID_IHTMLSCRIPTELEMENT_TYPE = DISPID_SCRIPT + 9;

        private const int DISPID_COMMENTPDL = DISPID_NORMAL_FIRST;
        //    DISPIDs for interface IHTMLCommentElement
        public const int DISPID_IHTMLCOMMENTELEMENT_TEXT    = DISPID_COMMENTPDL+1;
        public const int DISPID_IHTMLCOMMENTELEMENT_ATOMIC = DISPID_COMMENTPDL + 2;

        public const int DISPID_TABLE = DISPID_NORMAL_FIRST;
        public const int DISPID_TABLESECTION = DISPID_NORMAL_FIRST;
        public const int DISPID_TABLEROW     = DISPID_NORMAL_FIRST;
        public const int DISPID_TABLECOL = DISPID_NORMAL_FIRST;
        public const int DISPID_A_BACKGROUNDIMAGE  = DISPID_A_FIRST+1;
        public const int DISPID_A_TABLEBORDERCOLOR = DISPID_A_FIRST + 28;
        public const int DISPID_A_TABLEBORDERCOLORLIGHT = DISPID_A_FIRST + 29;
        public const int DISPID_A_TABLEBORDERCOLORDARK = DISPID_A_FIRST + 30;
        public const int DISPID_A_TABLEVALIGN = DISPID_A_FIRST + 31;
        //unchecked((int)0x48)
        public const int STDPROPID_XOBJ_BLOCKALIGN = DISPID_XOBJ_BASE + 0x48;
        public const int DISPID_TABLECELL = DISPID_TEXTSITE + 1000;
        public const int DISPID_A_NOWRAP  = DISPID_A_FIRST+5;

        //    DISPIDs for interface IHTMLTable
        public const int DISPID_IHTMLTABLE_COLS = DISPID_TABLE + 1;
        public const int DISPID_IHTMLTABLE_BORDER = DISPID_TABLE + 2;
        public const int DISPID_IHTMLTABLE_FRAME = DISPID_TABLE + 4;
        public const int DISPID_IHTMLTABLE_RULES = DISPID_TABLE + 3;
        public const int DISPID_IHTMLTABLE_CELLSPACING = DISPID_TABLE + 5;
        public const int DISPID_IHTMLTABLE_CELLPADDING = DISPID_TABLE + 6;
        public const int DISPID_IHTMLTABLE_BACKGROUND = DISPID_A_BACKGROUNDIMAGE;
        public const int DISPID_IHTMLTABLE_BGCOLOR = DISPID_BACKCOLOR;
        public const int DISPID_IHTMLTABLE_BORDERCOLOR = DISPID_A_TABLEBORDERCOLOR;
        public const int DISPID_IHTMLTABLE_BORDERCOLORLIGHT = DISPID_A_TABLEBORDERCOLORLIGHT;
        public const int DISPID_IHTMLTABLE_BORDERCOLORDARK = DISPID_A_TABLEBORDERCOLORDARK;
        public const int DISPID_IHTMLTABLE_ALIGN = STDPROPID_XOBJ_CONTROLALIGN;
        public const int DISPID_IHTMLTABLE_REFRESH = DISPID_TABLE + 15;
        public const int DISPID_IHTMLTABLE_ROWS = DISPID_TABLE + 16;
        public const int DISPID_IHTMLTABLE_WIDTH = STDPROPID_XOBJ_WIDTH;
        public const int DISPID_IHTMLTABLE_HEIGHT = STDPROPID_XOBJ_HEIGHT;
        public const int DISPID_IHTMLTABLE_DATAPAGESIZE = DISPID_TABLE + 17;
        public const int DISPID_IHTMLTABLE_NEXTPAGE = DISPID_TABLE + 18;
        public const int DISPID_IHTMLTABLE_PREVIOUSPAGE = DISPID_TABLE + 19;
        public const int DISPID_IHTMLTABLE_THEAD = DISPID_TABLE + 20;
        public const int DISPID_IHTMLTABLE_TFOOT = DISPID_TABLE + 21;
        public const int DISPID_IHTMLTABLE_TBODIES = DISPID_TABLE + 24;
        public const int DISPID_IHTMLTABLE_CAPTION = DISPID_TABLE + 25;
        public const int DISPID_IHTMLTABLE_CREATETHEAD = DISPID_TABLE + 26;
        public const int DISPID_IHTMLTABLE_DELETETHEAD = DISPID_TABLE + 27;
        public const int DISPID_IHTMLTABLE_CREATETFOOT = DISPID_TABLE + 28;
        public const int DISPID_IHTMLTABLE_DELETETFOOT = DISPID_TABLE + 29;
        public const int DISPID_IHTMLTABLE_CREATECAPTION = DISPID_TABLE + 30;
        public const int DISPID_IHTMLTABLE_DELETECAPTION = DISPID_TABLE + 31;
        public const int DISPID_IHTMLTABLE_INSERTROW = DISPID_TABLE + 32;
        public const int DISPID_IHTMLTABLE_DELETEROW = DISPID_TABLE + 33;
        public const int DISPID_IHTMLTABLE_READYSTATE = DISPID_A_READYSTATE;
        public const int DISPID_IHTMLTABLE_ONREADYSTATECHANGE = DISPID_EVPROP_ONREADYSTATECHANGE;

        //    DISPIDs for interface IHTMLTable2
        public const int DISPID_IHTMLTABLE2_FIRSTPAGE = DISPID_TABLE + 35;
        public const int DISPID_IHTMLTABLE2_LASTPAGE = DISPID_TABLE + 36;
        public const int DISPID_IHTMLTABLE2_CELLS = DISPID_TABLE + 37;
        public const int DISPID_IHTMLTABLE2_MOVEROW = DISPID_TABLE + 38;

        //    DISPIDs for interface IHTMLTable3
        public const int DISPID_IHTMLTABLE3_SUMMARY = DISPID_TABLE + 39;

        //    DISPIDs for interface IHTMLTableCol
        public const int DISPID_IHTMLTABLECOL_SPAN = DISPID_TABLECOL + 1;
        public const int DISPID_IHTMLTABLECOL_WIDTH = STDPROPID_XOBJ_WIDTH;
        public const int DISPID_IHTMLTABLECOL_ALIGN = STDPROPID_XOBJ_BLOCKALIGN;
        public const int DISPID_IHTMLTABLECOL_VALIGN = DISPID_A_TABLEVALIGN;

        //    DISPIDs for interface IHTMLTableCol2
        public const int DISPID_IHTMLTABLECOL2_CH = DISPID_TABLECOL + 2;
        public const int DISPID_IHTMLTABLECOL2_CHOFF = DISPID_TABLECOL + 3;

        //    DISPIDs for interface IHTMLTableSection
        public const int DISPID_IHTMLTABLESECTION_ALIGN = STDPROPID_XOBJ_BLOCKALIGN;
        public const int DISPID_IHTMLTABLESECTION_VALIGN = DISPID_A_TABLEVALIGN;
        public const int DISPID_IHTMLTABLESECTION_BGCOLOR = DISPID_BACKCOLOR;
        public const int DISPID_IHTMLTABLESECTION_ROWS = DISPID_TABLESECTION;
        public const int DISPID_IHTMLTABLESECTION_INSERTROW = DISPID_TABLESECTION + 1;
        public const int DISPID_IHTMLTABLESECTION_DELETEROW = DISPID_TABLESECTION + 2;

        //    DISPIDs for interface IHTMLTableSection2
        public const int DISPID_IHTMLTABLESECTION2_MOVEROW = DISPID_TABLESECTION + 3;

        //    DISPIDs for interface IHTMLTableSection3
        public const int DISPID_IHTMLTABLESECTION3_CH = DISPID_TABLESECTION + 4;
        public const int DISPID_IHTMLTABLESECTION3_CHOFF = DISPID_TABLESECTION + 5;

        //    DISPIDs for interface IHTMLTableRow
        public const int DISPID_IHTMLTABLEROW_ALIGN = STDPROPID_XOBJ_BLOCKALIGN;
        public const int DISPID_IHTMLTABLEROW_VALIGN = DISPID_A_TABLEVALIGN;
        public const int DISPID_IHTMLTABLEROW_BGCOLOR = DISPID_BACKCOLOR;
        public const int DISPID_IHTMLTABLEROW_BORDERCOLOR = DISPID_A_TABLEBORDERCOLOR;
        public const int DISPID_IHTMLTABLEROW_BORDERCOLORLIGHT = DISPID_A_TABLEBORDERCOLORLIGHT;
        public const int DISPID_IHTMLTABLEROW_BORDERCOLORDARK = DISPID_A_TABLEBORDERCOLORDARK;
        public const int DISPID_IHTMLTABLEROW_ROWINDEX = DISPID_TABLEROW;
        public const int DISPID_IHTMLTABLEROW_SECTIONROWINDEX = DISPID_TABLEROW + 1;
        public const int DISPID_IHTMLTABLEROW_CELLS = DISPID_TABLEROW + 2;
        public const int DISPID_IHTMLTABLEROW_INSERTCELL = DISPID_TABLEROW + 3;
        public const int DISPID_IHTMLTABLEROW_DELETECELL = DISPID_TABLEROW + 4;

        //    DISPIDs for interface IHTMLTableRow2
        public const int DISPID_IHTMLTABLEROW2_HEIGHT = STDPROPID_XOBJ_HEIGHT;

        //    DISPIDs for interface IHTMLTableRow3
        public const int DISPID_IHTMLTABLEROW3_CH = DISPID_TABLEROW + 9;
        public const int DISPID_IHTMLTABLEROW3_CHOFF = DISPID_TABLEROW + 10;

        //    DISPIDs for interface IHTMLTableRowMetrics
        public const int DISPID_IHTMLTABLEROWMETRICS_CLIENTHEIGHT = DISPID_SITE + 19;
        public const int DISPID_IHTMLTABLEROWMETRICS_CLIENTWIDTH = DISPID_SITE + 20;
        public const int DISPID_IHTMLTABLEROWMETRICS_CLIENTTOP = DISPID_SITE + 21;
        public const int DISPID_IHTMLTABLEROWMETRICS_CLIENTLEFT = DISPID_SITE + 22;

        //    DISPIDs for interface IHTMLTableCell
        public const int DISPID_IHTMLTABLECELL_ROWSPAN = DISPID_TABLECELL + 1;
        public const int DISPID_IHTMLTABLECELL_COLSPAN = DISPID_TABLECELL + 2;
        public const int DISPID_IHTMLTABLECELL_ALIGN = STDPROPID_XOBJ_BLOCKALIGN;
        public const int DISPID_IHTMLTABLECELL_VALIGN = DISPID_A_TABLEVALIGN;
        public const int DISPID_IHTMLTABLECELL_BGCOLOR = DISPID_BACKCOLOR;
        public const int DISPID_IHTMLTABLECELL_NOWRAP = DISPID_A_NOWRAP;
        public const int DISPID_IHTMLTABLECELL_BACKGROUND = DISPID_A_BACKGROUNDIMAGE;
        public const int DISPID_IHTMLTABLECELL_BORDERCOLOR = DISPID_A_TABLEBORDERCOLOR;
        public const int DISPID_IHTMLTABLECELL_BORDERCOLORLIGHT = DISPID_A_TABLEBORDERCOLORLIGHT;
        public const int DISPID_IHTMLTABLECELL_BORDERCOLORDARK = DISPID_A_TABLEBORDERCOLORDARK;
        public const int DISPID_IHTMLTABLECELL_WIDTH = STDPROPID_XOBJ_WIDTH;
        public const int DISPID_IHTMLTABLECELL_HEIGHT = STDPROPID_XOBJ_HEIGHT;
        public const int DISPID_IHTMLTABLECELL_CELLINDEX = DISPID_TABLECELL + 3;

        //    DISPIDs for interface IHTMLTableCell
        public const int DISPID_IHTMLTABLECELL2_ABBR = DISPID_TABLECELL + 4;
        public const int DISPID_IHTMLTABLECELL2_AXIS = DISPID_TABLECELL + 5;
        public const int DISPID_IHTMLTABLECELL2_CH = DISPID_TABLECELL + 6;
        public const int DISPID_IHTMLTABLECELL2_CHOFF = DISPID_TABLECELL + 7;
        public const int DISPID_IHTMLTABLECELL2_HEADERS = DISPID_TABLECELL + 8;
        public const int DISPID_IHTMLTABLECELL2_SCOPE = DISPID_TABLECELL + 9;

        //    DISPIDs for event set HTMLElementEvents2

        public const int DISPID_HTMLELEMENTEVENTS2_ONHELP = DISPID_EVMETH_ONHELP;
        public const int DISPID_HTMLELEMENTEVENTS2_ONCLICK = DISPID_EVMETH_ONCLICK;
        public const int DISPID_HTMLELEMENTEVENTS2_ONDBLCLICK = DISPID_EVMETH_ONDBLCLICK;
        public const int DISPID_HTMLELEMENTEVENTS2_ONKEYPRESS = DISPID_EVMETH_ONKEYPRESS;
        public const int DISPID_HTMLELEMENTEVENTS2_ONKEYDOWN = DISPID_EVMETH_ONKEYDOWN;
        public const int DISPID_HTMLELEMENTEVENTS2_ONKEYUP = DISPID_EVMETH_ONKEYUP;
        public const int DISPID_HTMLELEMENTEVENTS2_ONMOUSEOUT = DISPID_EVMETH_ONMOUSEOUT;
        public const int DISPID_HTMLELEMENTEVENTS2_ONMOUSEOVER = DISPID_EVMETH_ONMOUSEOVER;
        public const int DISPID_HTMLELEMENTEVENTS2_ONMOUSEMOVE = DISPID_EVMETH_ONMOUSEMOVE;
        public const int DISPID_HTMLELEMENTEVENTS2_ONMOUSEDOWN = DISPID_EVMETH_ONMOUSEDOWN;
        public const int DISPID_HTMLELEMENTEVENTS2_ONMOUSEUP = DISPID_EVMETH_ONMOUSEUP;
        public const int DISPID_HTMLELEMENTEVENTS2_ONSELECTSTART = DISPID_EVMETH_ONSELECTSTART;
        public const int DISPID_HTMLELEMENTEVENTS2_ONFILTERCHANGE = DISPID_EVMETH_ONFILTER;
        public const int DISPID_HTMLELEMENTEVENTS2_ONDRAGSTART = DISPID_EVMETH_ONDRAGSTART;
        public const int DISPID_HTMLELEMENTEVENTS2_ONBEFOREUPDATE = DISPID_EVMETH_ONBEFOREUPDATE;
        public const int DISPID_HTMLELEMENTEVENTS2_ONAFTERUPDATE = DISPID_EVMETH_ONAFTERUPDATE;
        public const int DISPID_HTMLELEMENTEVENTS2_ONERRORUPDATE = DISPID_EVMETH_ONERRORUPDATE;
        public const int DISPID_HTMLELEMENTEVENTS2_ONROWEXIT = DISPID_EVMETH_ONROWEXIT;
        public const int DISPID_HTMLELEMENTEVENTS2_ONROWENTER = DISPID_EVMETH_ONROWENTER;
        public const int DISPID_HTMLELEMENTEVENTS2_ONDATASETCHANGED = DISPID_EVMETH_ONDATASETCHANGED;
        public const int DISPID_HTMLELEMENTEVENTS2_ONDATAAVAILABLE = DISPID_EVMETH_ONDATAAVAILABLE;
        public const int DISPID_HTMLELEMENTEVENTS2_ONDATASETCOMPLETE = DISPID_EVMETH_ONDATASETCOMPLETE;
        public const int DISPID_HTMLELEMENTEVENTS2_ONLOSECAPTURE = DISPID_EVMETH_ONLOSECAPTURE;
        public const int DISPID_HTMLELEMENTEVENTS2_ONPROPERTYCHANGE = DISPID_EVMETH_ONPROPERTYCHANGE;
        public const int DISPID_HTMLELEMENTEVENTS2_ONSCROLL = DISPID_EVMETH_ONSCROLL;
        public const int DISPID_HTMLELEMENTEVENTS2_ONFOCUS = DISPID_EVMETH_ONFOCUS;
        public const int DISPID_HTMLELEMENTEVENTS2_ONBLUR = DISPID_EVMETH_ONBLUR;
        public const int DISPID_HTMLELEMENTEVENTS2_ONRESIZE = DISPID_EVMETH_ONRESIZE;
        public const int DISPID_HTMLELEMENTEVENTS2_ONDRAG = DISPID_EVMETH_ONDRAG;
        public const int DISPID_HTMLELEMENTEVENTS2_ONDRAGEND = DISPID_EVMETH_ONDRAGEND;
        public const int DISPID_HTMLELEMENTEVENTS2_ONDRAGENTER = DISPID_EVMETH_ONDRAGENTER;
        public const int DISPID_HTMLELEMENTEVENTS2_ONDRAGOVER = DISPID_EVMETH_ONDRAGOVER;
        public const int DISPID_HTMLELEMENTEVENTS2_ONDRAGLEAVE = DISPID_EVMETH_ONDRAGLEAVE;
        public const int DISPID_HTMLELEMENTEVENTS2_ONDROP = DISPID_EVMETH_ONDROP;
        public const int DISPID_HTMLELEMENTEVENTS2_ONBEFORECUT = DISPID_EVMETH_ONBEFORECUT;
        public const int DISPID_HTMLELEMENTEVENTS2_ONCUT = DISPID_EVMETH_ONCUT;
        public const int DISPID_HTMLELEMENTEVENTS2_ONBEFORECOPY = DISPID_EVMETH_ONBEFORECOPY;
        public const int DISPID_HTMLELEMENTEVENTS2_ONCOPY = DISPID_EVMETH_ONCOPY;
        public const int DISPID_HTMLELEMENTEVENTS2_ONBEFOREPASTE = DISPID_EVMETH_ONBEFOREPASTE;
        public const int DISPID_HTMLELEMENTEVENTS2_ONPASTE = DISPID_EVMETH_ONPASTE;
        public const int DISPID_HTMLELEMENTEVENTS2_ONCONTEXTMENU = DISPID_EVMETH_ONCONTEXTMENU;
        public const int DISPID_HTMLELEMENTEVENTS2_ONROWSDELETE = DISPID_EVMETH_ONROWSDELETE;
        public const int DISPID_HTMLELEMENTEVENTS2_ONROWSINSERTED = DISPID_EVMETH_ONROWSINSERTED;
        public const int DISPID_HTMLELEMENTEVENTS2_ONCELLCHANGE = DISPID_EVMETH_ONCELLCHANGE;
        public const int DISPID_HTMLELEMENTEVENTS2_ONREADYSTATECHANGE = DISPID_EVMETH_ONREADYSTATECHANGE;
        public const int DISPID_HTMLELEMENTEVENTS2_ONLAYOUTCOMPLETE = DISPID_EVMETH_ONLAYOUTCOMPLETE;
        public const int DISPID_HTMLELEMENTEVENTS2_ONPAGE = DISPID_EVMETH_ONPAGE;
        public const int DISPID_HTMLELEMENTEVENTS2_ONMOUSEENTER = DISPID_EVMETH_ONMOUSEENTER;
        public const int DISPID_HTMLELEMENTEVENTS2_ONMOUSELEAVE = DISPID_EVMETH_ONMOUSELEAVE;
        public const int DISPID_HTMLELEMENTEVENTS2_ONACTIVATE = DISPID_EVMETH_ONACTIVATE;
        public const int DISPID_HTMLELEMENTEVENTS2_ONDEACTIVATE = DISPID_EVMETH_ONDEACTIVATE;
        public const int DISPID_HTMLELEMENTEVENTS2_ONBEFOREDEACTIVATE = DISPID_EVMETH_ONBEFOREDEACTIVATE;
        public const int DISPID_HTMLELEMENTEVENTS2_ONBEFOREACTIVATE = DISPID_EVMETH_ONBEFOREACTIVATE;
        public const int DISPID_HTMLELEMENTEVENTS2_ONFOCUSIN = DISPID_EVMETH_ONFOCUSIN;
        public const int DISPID_HTMLELEMENTEVENTS2_ONFOCUSOUT = DISPID_EVMETH_ONFOCUSOUT;
        public const int DISPID_HTMLELEMENTEVENTS2_ONMOVE = DISPID_EVMETH_ONMOVE;
        public const int DISPID_HTMLELEMENTEVENTS2_ONCONTROLSELECT = DISPID_EVMETH_ONCONTROLSELECT;
        public const int DISPID_HTMLELEMENTEVENTS2_ONMOVESTART = DISPID_EVMETH_ONMOVESTART;
        public const int DISPID_HTMLELEMENTEVENTS2_ONMOVEEND = DISPID_EVMETH_ONMOVEEND;
        public const int DISPID_HTMLELEMENTEVENTS2_ONRESIZESTART = DISPID_EVMETH_ONRESIZESTART;
        public const int DISPID_HTMLELEMENTEVENTS2_ONRESIZEEND = DISPID_EVMETH_ONRESIZEEND;
        public const int DISPID_HTMLELEMENTEVENTS2_ONMOUSEWHEEL = DISPID_EVMETH_ONMOUSEWHEEL;

        public const int DISPID_HR = DISPID_NORMAL_FIRST;
        public const int DISPID_IHTMLHRELEMENT_ALIGN = STDPROPID_XOBJ_BLOCKALIGN;
        public const int DISPID_IHTMLHRELEMENT_COLOR = DISPID_A_COLOR;
        public const int DISPID_IHTMLHRELEMENT_NOSHADE = DISPID_HR + 1;
        public const int DISPID_IHTMLHRELEMENT_WIDTH = STDPROPID_XOBJ_WIDTH;
        public const int DISPID_IHTMLHRELEMENT_SIZE = STDPROPID_XOBJ_HEIGHT;


        //    DISPIDs for interface IHTMLInputElement

        public const int DISPID_IHTMLINPUTELEMENT_TYPE = DISPID_INPUT;
        public const int DISPID_IHTMLINPUTELEMENT_VALUE = DISPID_A_VALUE;
        public const int DISPID_IHTMLINPUTELEMENT_NAME = STDPROPID_XOBJ_NAME;
        public const int DISPID_IHTMLINPUTELEMENT_STATUS = DISPID_INPUT + 1;
        public const int DISPID_IHTMLINPUTELEMENT_DISABLED = STDPROPID_XOBJ_DISABLED;
        public const int DISPID_IHTMLINPUTELEMENT_FORM = DISPID_SITE + 4;
        public const int DISPID_IHTMLINPUTELEMENT_SIZE = DISPID_INPUT + 2;
        public const int DISPID_IHTMLINPUTELEMENT_MAXLENGTH = DISPID_INPUT + 3;
        public const int DISPID_IHTMLINPUTELEMENT_SELECT = DISPID_INPUT + 4;
        public const int DISPID_IHTMLINPUTELEMENT_ONCHANGE = DISPID_EVPROP_ONCHANGE;
        public const int DISPID_IHTMLINPUTELEMENT_ONSELECT = DISPID_EVPROP_ONSELECT;
        public const int DISPID_IHTMLINPUTELEMENT_DEFAULTVALUE = DISPID_DEFAULTVALUE;
        public const int DISPID_IHTMLINPUTELEMENT_READONLY = DISPID_INPUT + 5;
        public const int DISPID_IHTMLINPUTELEMENT_CREATETEXTRANGE = DISPID_INPUT + 6;
        public const int DISPID_IHTMLINPUTELEMENT_INDETERMINATE = DISPID_INPUT + 7;
        public const int DISPID_IHTMLINPUTELEMENT_DEFAULTCHECKED = DISPID_INPUT + 8;
        public const int DISPID_IHTMLINPUTELEMENT_CHECKED = DISPID_INPUT + 9;
        public const int DISPID_IHTMLINPUTELEMENT_BORDER = DISPID_INPUT + 12;
        public const int DISPID_IHTMLINPUTELEMENT_VSPACE = DISPID_INPUT + 13;
        public const int DISPID_IHTMLINPUTELEMENT_HSPACE = DISPID_INPUT + 14;
        public const int DISPID_IHTMLINPUTELEMENT_ALT = DISPID_INPUT + 10;
        public const int DISPID_IHTMLINPUTELEMENT_SRC = DISPID_INPUT + 11;
        public const int DISPID_IHTMLINPUTELEMENT_LOWSRC = DISPID_INPUT + 15;
        public const int DISPID_IHTMLINPUTELEMENT_VRML = DISPID_INPUT + 16;
        public const int DISPID_IHTMLINPUTELEMENT_DYNSRC = DISPID_INPUT + 17;
        public const int DISPID_IHTMLINPUTELEMENT_READYSTATE = DISPID_A_READYSTATE;
        public const int DISPID_IHTMLINPUTELEMENT_COMPLETE = DISPID_INPUT + 18;
        public const int DISPID_IHTMLINPUTELEMENT_LOOP = DISPID_INPUT + 19;
        public const int DISPID_IHTMLINPUTELEMENT_ALIGN = STDPROPID_XOBJ_CONTROLALIGN;
        public const int DISPID_IHTMLINPUTELEMENT_ONLOAD = DISPID_EVPROP_ONLOAD;
        public const int DISPID_IHTMLINPUTELEMENT_ONERROR = DISPID_EVPROP_ONERROR;
        public const int DISPID_IHTMLINPUTELEMENT_ONABORT = DISPID_EVPROP_ONABORT;
        public const int DISPID_IHTMLINPUTELEMENT_WIDTH = STDPROPID_XOBJ_WIDTH;
        public const int DISPID_IHTMLINPUTELEMENT_HEIGHT = STDPROPID_XOBJ_HEIGHT;
        public const int DISPID_IHTMLINPUTELEMENT_START = DISPID_INPUT + 20;

        //    DISPIDs for interface IHTMLSelectElement

        public const int DISPID_IHTMLSELECTELEMENT_SIZE = DISPID_SELECT + 2;
        public const int DISPID_IHTMLSELECTELEMENT_MULTIPLE = DISPID_SELECT + 3;
        public const int DISPID_IHTMLSELECTELEMENT_NAME = STDPROPID_XOBJ_NAME;
        public const int DISPID_IHTMLSELECTELEMENT_OPTIONS = DISPID_SELECT + 5;
        public const int DISPID_IHTMLSELECTELEMENT_ONCHANGE = DISPID_EVPROP_ONCHANGE;
        public const int DISPID_IHTMLSELECTELEMENT_SELECTEDINDEX = DISPID_SELECT + 10;
        public const int DISPID_IHTMLSELECTELEMENT_TYPE = DISPID_SELECT + 12;
        public const int DISPID_IHTMLSELECTELEMENT_VALUE = DISPID_SELECT + 11;
        public const int DISPID_IHTMLSELECTELEMENT_DISABLED = STDPROPID_XOBJ_DISABLED;
        public const int DISPID_IHTMLSELECTELEMENT_FORM = DISPID_SITE + 4;
        public const int DISPID_IHTMLSELECTELEMENT_ADD = DISPID_COLLECTION + 3;
        public const int DISPID_IHTMLSELECTELEMENT_REMOVE = DISPID_COLLECTION + 4;
        public const int DISPID_IHTMLSELECTELEMENT_LENGTH = DISPID_COLLECTION;
        public const int DISPID_IHTMLSELECTELEMENT__NEWENUM = DISPID_NEWENUM;
        public const int DISPID_IHTMLSELECTELEMENT_ITEM = DISPID_VALUE;
        public const int DISPID_IHTMLSELECTELEMENT_TAGS = DISPID_COLLECTION + 2;

        //    DISPIDs for interface IHTMLTextAreaElement
        public const int DISPID_TEXTAREA          =  (DISPID_INPUTTEXT + 1000);
        public const int DISPID_MARQUEE           =  (DISPID_TEXTAREA + 1000);
        public const int DISPID_RICHTEXT          =  (DISPID_MARQUEE + 1000);

        public const int DISPID_IHTMLTEXTAREAELEMENT_TYPE = DISPID_INPUT;
        public const int DISPID_IHTMLTEXTAREAELEMENT_VALUE = DISPID_A_VALUE;
        public const int DISPID_IHTMLTEXTAREAELEMENT_NAME = STDPROPID_XOBJ_NAME;
        public const int DISPID_IHTMLTEXTAREAELEMENT_STATUS = DISPID_INPUT + 1;
        public const int DISPID_IHTMLTEXTAREAELEMENT_DISABLED = STDPROPID_XOBJ_DISABLED;
        public const int DISPID_IHTMLTEXTAREAELEMENT_FORM = DISPID_SITE + 4;
        public const int DISPID_IHTMLTEXTAREAELEMENT_DEFAULTVALUE = DISPID_DEFAULTVALUE;
        public const int DISPID_IHTMLTEXTAREAELEMENT_SELECT = DISPID_RICHTEXT + 5;
        public const int DISPID_IHTMLTEXTAREAELEMENT_ONCHANGE = DISPID_EVPROP_ONCHANGE;
        public const int DISPID_IHTMLTEXTAREAELEMENT_ONSELECT = DISPID_EVPROP_ONSELECT;
        public const int DISPID_IHTMLTEXTAREAELEMENT_READONLY = DISPID_RICHTEXT + 4;
        public const int DISPID_IHTMLTEXTAREAELEMENT_ROWS = DISPID_RICHTEXT + 1;
        public const int DISPID_IHTMLTEXTAREAELEMENT_COLS = DISPID_RICHTEXT + 2;
        public const int DISPID_IHTMLTEXTAREAELEMENT_WRAP = DISPID_RICHTEXT + 3;
        public const int DISPID_IHTMLTEXTAREAELEMENT_CREATETEXTRANGE = DISPID_RICHTEXT + 6;

        //    DISPIDs for interface IHTMLFormElement

        public const int DISPID_FORM = DISPID_NORMAL_FIRST;
        public const int DISPID_IHTMLFORMELEMENT_ACTION = DISPID_FORM + 1;
        public const int DISPID_IHTMLFORMELEMENT_DIR = DISPID_A_DIR;
        public const int DISPID_IHTMLFORMELEMENT_ENCODING = DISPID_FORM + 3;
        public const int DISPID_IHTMLFORMELEMENT_METHOD = DISPID_FORM + 4;
        public const int DISPID_IHTMLFORMELEMENT_ELEMENTS = DISPID_FORM + 5;
        public const int DISPID_IHTMLFORMELEMENT_TARGET = DISPID_FORM + 6;
        public const int DISPID_IHTMLFORMELEMENT_NAME = STDPROPID_XOBJ_NAME;
        public const int DISPID_IHTMLFORMELEMENT_ONSUBMIT = DISPID_EVPROP_ONSUBMIT;
        public const int DISPID_IHTMLFORMELEMENT_ONRESET = DISPID_EVPROP_ONRESET;
        public const int DISPID_IHTMLFORMELEMENT_SUBMIT = DISPID_FORM + 9;
        public const int DISPID_IHTMLFORMELEMENT_RESET = DISPID_FORM + 10;
        public const int DISPID_IHTMLFORMELEMENT_LENGTH = DISPID_COLLECTION;
        public const int DISPID_IHTMLFORMELEMENT__NEWENUM = DISPID_NEWENUM;
        public const int DISPID_IHTMLFORMELEMENT_ITEM = DISPID_VALUE;
        public const int DISPID_IHTMLFORMELEMENT_TAGS = DISPID_COLLECTION + 2;

        public const int DISPID_IHTMLCONTROLELEMENT_TABINDEX = STDPROPID_XOBJ_TABINDEX;
        public const int DISPID_IHTMLCONTROLELEMENT_FOCUS = DISPID_SITE + 0;
        public const int DISPID_IHTMLCONTROLELEMENT_ACCESSKEY = DISPID_SITE + 5;
        public const int DISPID_IHTMLCONTROLELEMENT_ONBLUR = DISPID_EVPROP_ONBLUR;
        public const int DISPID_IHTMLCONTROLELEMENT_ONFOCUS = DISPID_EVPROP_ONFOCUS;
        public const int DISPID_IHTMLCONTROLELEMENT_ONRESIZE = DISPID_EVPROP_ONRESIZE;
        public const int DISPID_IHTMLCONTROLELEMENT_BLUR = DISPID_SITE + 2;
        public const int DISPID_IHTMLCONTROLELEMENT_ADDFILTER = DISPID_SITE + 17;
        public const int DISPID_IHTMLCONTROLELEMENT_REMOVEFILTER = DISPID_SITE + 18;
        public const int DISPID_IHTMLCONTROLELEMENT_CLIENTHEIGHT = DISPID_SITE + 19;
        public const int DISPID_IHTMLCONTROLELEMENT_CLIENTWIDTH = DISPID_SITE + 20;
        public const int DISPID_IHTMLCONTROLELEMENT_CLIENTTOP = DISPID_SITE + 21;
        public const int DISPID_IHTMLCONTROLELEMENT_CLIENTLEFT = DISPID_SITE + 22;

        public const int DISPID_IHTMLCONTROLRANGE_SELECT = DISPID_RANGE + 2;
        public const int DISPID_IHTMLCONTROLRANGE_ADD = DISPID_RANGE + 3;
        public const int DISPID_IHTMLCONTROLRANGE_REMOVE = DISPID_RANGE + 4;
        public const int DISPID_IHTMLCONTROLRANGE_ITEM = DISPID_VALUE;
        public const int DISPID_IHTMLCONTROLRANGE_SCROLLINTOVIEW = DISPID_RANGE + 6;
        public const int DISPID_IHTMLCONTROLRANGE_QUERYCOMMANDSUPPORTED = DISPID_RANGE + 7;
        public const int DISPID_IHTMLCONTROLRANGE_QUERYCOMMANDENABLED = DISPID_RANGE + 8;
        public const int DISPID_IHTMLCONTROLRANGE_QUERYCOMMANDSTATE = DISPID_RANGE + 9;
        public const int DISPID_IHTMLCONTROLRANGE_QUERYCOMMANDINDETERM = DISPID_RANGE + 10;
        public const int DISPID_IHTMLCONTROLRANGE_QUERYCOMMANDTEXT = DISPID_RANGE + 11;
        public const int DISPID_IHTMLCONTROLRANGE_QUERYCOMMANDVALUE = DISPID_RANGE + 12;
        public const int DISPID_IHTMLCONTROLRANGE_EXECCOMMAND = DISPID_RANGE + 13;
        public const int DISPID_IHTMLCONTROLRANGE_EXECCOMMANDSHOWHELP = DISPID_RANGE + 14;
        public const int DISPID_IHTMLCONTROLRANGE_COMMONPARENTELEMENT = DISPID_RANGE + 15;
        public const int DISPID_IHTMLCONTROLRANGE_LENGTH = DISPID_RANGE + 5;

    }

    #region cHTMLParser class
    
    public delegate void HtmlParsingDoneEventHandler(object sender, HtmlParsingDoneEventArg e);
    public class HtmlParsingDoneEventArg : System.EventArgs
    {
        public HtmlParsingDoneEventArg(string originalURL, object UniqueID, IHTMLDocument2 DocumentObject)
        {
            this.oriURL = originalURL;
            this.ID = UniqueID;
            this.MSHTMDocument = DocumentObject;

        }
        private IHTMLDocument2 MSHTMDocument = null;
        private string oriURL = string.Empty;
        private object ID = null;
    }

    /// <summary>
    /// Using MSHTML as a UI-less HTML parser
    /// </summary>
    public class cHTMLParser :
        IPropertyNotifySink,
        IOleClientSite
    {

        #region Local Variables
        private string m_Url = string.Empty;
        private object m_ID = null;
        private IHTMLDocument2 m_pMSHTML = null;
        private bool m_Done = false;
        private int m_dwCookie = 0;
        private IOleObject m_WBOleObject = null;
        private IOleControl m_WBOleControl = null;
        private IConnectionPoint m_WBConnectionPoint = null;
        private int m_Flags = (int)(DOCDOWNLOADCTLFLAG.DOWNLOADONLY | DOCDOWNLOADCTLFLAG.NO_BEHAVIORS
            | DOCDOWNLOADCTLFLAG.NO_CLIENTPULL | DOCDOWNLOADCTLFLAG.NO_DLACTIVEXCTLS
            | DOCDOWNLOADCTLFLAG.NO_JAVA | DOCDOWNLOADCTLFLAG.NO_METACHARSET
            | DOCDOWNLOADCTLFLAG.NO_RUNACTIVEXCTLS | DOCDOWNLOADCTLFLAG.NO_SCRIPTS
            | DOCDOWNLOADCTLFLAG.SILENT);
        private const string COMPLETE = "complete"; 
        #endregion

        /// <summary>
        /// The only event fired by this class upon completion of parsing
        /// </summary>
        public event HtmlParsingDoneEventHandler HtmlParsingDoneEvent = null;

        #region Properties
        /// <summary>
        /// Unique ID for this instance
        /// </summary>
        public object U_ID
        {
            get
            {
                return this.m_ID;
            }
            set
            {
                m_ID = value;
            }
        }

        /// <summary>
        /// Original URL used for parsing
        /// </summary>
        public string OriginalURL
        {
            get
            {
                return m_Url;
            }
            set
            {
                this.m_Url = value;
            }
        }

        /// <summary>
        /// Accessor for our document
        /// </summary>
        public IHTMLDocument2 ParserDocument
        {
            get
            {
                return this.m_pMSHTML;
            }
        }

        public bool DoneParsing
        {
            get
            {
                return this.m_Done;
            }
        } 
        #endregion

        cHTMLParser()
        {
            //Create a new MSHTML, throws exception if fails
            Type htmldoctype = Type.GetTypeFromCLSID(Iid_Clsids.CLSID_HTMLDocument, true);
            //Using Activator inplace of CoCreateInstance, returns IUnknown
            //which we cast to a IHtmlDocument2 interface
            m_pMSHTML = (IHTMLDocument2)System.Activator.CreateInstance(htmldoctype);

            //Get the IOleObject
            m_WBOleObject = (IOleObject)m_pMSHTML;
            //Set client site
            int iret = m_WBOleObject.SetClientSite(this);

            //Connect for IPropertyNotifySink
            m_WBOleControl = (IOleControl)m_pMSHTML;
            m_WBOleControl.OnAmbientPropertyChange(HTMLDispIDs.DISPID_AMBIENT_DLCONTROL);

            //Get connectionpointcontainer
            IConnectionPointContainer cpCont = (IConnectionPointContainer)m_pMSHTML;
            cpCont.FindConnectionPoint(ref Iid_Clsids.IID_IPropertyNotifySink, out m_WBConnectionPoint);
            //Advice
            m_WBConnectionPoint.Advise(this, out m_dwCookie);
        }
        
        ~cHTMLParser()
        {
            //UnAdvice and clean up
            if ((m_WBConnectionPoint != null) && (m_dwCookie > 0))
                m_WBConnectionPoint.Unadvise(m_dwCookie);
            if (m_WBOleObject != null)
            {
                m_WBOleObject.Close((uint)OLEDOVERB.OLECLOSE_NOSAVE);
                m_WBOleObject.SetClientSite(null);
            }

            if (m_pMSHTML != null)
            {
                Marshal.ReleaseComObject(m_pMSHTML);
                m_pMSHTML = null;
            }
            if (m_WBConnectionPoint != null)
            {
                Marshal.ReleaseComObject(m_WBConnectionPoint);
                m_WBConnectionPoint = null;
            }
            if (m_WBOleControl != null)
            {
                Marshal.ReleaseComObject(m_WBOleControl);
                m_WBOleControl = null;
            }
            if (m_WBOleObject != null)
            {
                Marshal.ReleaseComObject(m_WBOleObject);
                m_WBOleObject = null;
            }
        }

        /// <summary>
        /// Only public method which starts the parsing process
        /// When parsing is done, we receive a DISPID_READYSTATE dispid
        /// in IPropertyNotifySink.OnChanged implementation
        /// </summary>
        /// <param name="Url"></param>
        public void StartParsing(string Url)
        {
            if (m_pMSHTML == null)
                throw new ApplicationException("HtmlDocument is null.");
            if (string.IsNullOrEmpty(Url))
                throw new ApplicationException("Url must have a valid value!");
            m_Done = false;
            m_Url = Url;
            IPersistMoniker persistMoniker = (IPersistMoniker)m_pMSHTML;
            IMoniker moniker = null;
            WinApis.CreateURLMoniker(null, m_Url, out moniker);
            if (moniker == null)
                return;
            IBindCtx bindContext = null;
            WinApis.CreateBindCtx((uint)0, out bindContext);
            if (bindContext == null)
                return;
            persistMoniker.Load(1, moniker, bindContext, 0);
        }

        [DispId(HTMLDispIDs.DISPID_AMBIENT_DLCONTROL)]
        public int Idispatch_AmbiantDlControl_Invoke_Handler()
        {
            return m_Flags;
        }

        #region IPropertyNotifySink Members

        int IPropertyNotifySink.OnChanged(int dispID)
        {
            if ((dispID == HTMLDispIDs.DISPID_READYSTATE) &&
                (m_pMSHTML != null) &&
                (m_pMSHTML.readyState.ToLower().Equals(COMPLETE)) &&
                (HtmlParsingDoneEvent != null))
            {
                m_Done = true;
                //Firing event to indicate the parsing is done
                HtmlParsingDoneEventArg arg = new HtmlParsingDoneEventArg(this.m_Url, this.m_ID, this.m_pMSHTML);
                HtmlParsingDoneEvent(this, arg);
            }
            return Hresults.NOERROR;
        }

        int IPropertyNotifySink.OnRequestEdit(int dispID)
        {
            // Property changes are OK any time as far as this parser is concerned!
            return Hresults.NOERROR;
        }

        #endregion

        #region IOleClientSite Members

        int IOleClientSite.SaveObject()
        {
            return Hresults.E_NOTIMPL;
        }

        int IOleClientSite.GetMoniker(uint dwAssign, uint dwWhichMoniker, out IMoniker ppmk)
        {
            ppmk = null;
            return Hresults.E_NOTIMPL;
        }

        int IOleClientSite.GetContainer(out IOleContainer ppContainer)
        {
            ppContainer = null;
            return Hresults.E_NOTIMPL;
        }

        int IOleClientSite.ShowObject()
        {
            return Hresults.S_OK;
        }

        int IOleClientSite.OnShowWindow(bool fShow)
        {
            return Hresults.E_NOTIMPL;
        }

        int IOleClientSite.RequestNewObjectLayout()
        {
            return Hresults.E_NOTIMPL;
        }

        #endregion
    }

    #endregion

    #region TreeViewSerializer class
    
    /// <summary>
    /// Summary description for TreeViewSerializer.
    /// Author: Syed Umar Anis
    /// URL: http://www.codeproject.com/csharp/TreeView_Serializer.asp
    /// </summary>
    public class TreeViewSerializer
    {

        // Xml tag for node, e.g. 'node' in case of <node></node>
        private const string XmlNodeTag = "node";

        // Xml attributes for node e.g. <node text="Asia" tag="" imageindex="1"></node>
        private const string XmlNodeTextAtt = "text";
        private const string XmlNodeTagAtt = "tag";
        private const string XmlNodeImageIndexAtt = "imageindex";

        public TreeViewSerializer()
        {
        }

        //System.IO.StringWriter s;
        public void SerializeTreeView(TreeView treeView, string fileName)
        {
            XmlTextWriter textWriter = new XmlTextWriter(fileName, System.Text.Encoding.ASCII);
            // writing the xml declaration tag
            textWriter.WriteStartDocument();
            //textWriter.WriteRaw("\r\n");
            // writing the main tag that encloses all node tags
            textWriter.WriteStartElement("TreeView");

            // save the nodes, recursive method
            SaveNodes(treeView.Nodes, textWriter);

            textWriter.WriteEndElement();

            textWriter.Close();
        }

        private void SaveNodes(TreeNodeCollection nodesCollection,
            XmlTextWriter textWriter)
        {
            for (int i = 0; i < nodesCollection.Count; i++)
            {
                TreeNode node = nodesCollection[i];
                textWriter.WriteStartElement(XmlNodeTag);
                textWriter.WriteAttributeString(XmlNodeTextAtt, node.Text);
                textWriter.WriteAttributeString(XmlNodeImageIndexAtt, node.ImageIndex.ToString());
                if (node.Tag != null)
                    textWriter.WriteAttributeString(XmlNodeTagAtt, node.Tag.ToString());

                // add other node properties to serialize here
                if (node.Nodes.Count > 0)
                {
                    SaveNodes(node.Nodes, textWriter);
                }
                textWriter.WriteEndElement();
            }
        }

        public void DeserializeTreeView(TreeView treeView, string fileName)
        {
            XmlTextReader reader = null;
            try
            {
                // disabling re-drawing of treeview till all nodes are added
                treeView.BeginUpdate();
                reader = new XmlTextReader(fileName);

                TreeNode parentNode = null;

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == XmlNodeTag)
                        {
                            TreeNode newNode = new TreeNode();
                            bool isEmptyElement = reader.IsEmptyElement;

                            // loading node attributes
                            int attributeCount = reader.AttributeCount;
                            if (attributeCount > 0)
                            {
                                for (int i = 0; i < attributeCount; i++)
                                {
                                    reader.MoveToAttribute(i);
                                    SetAttributeValue(newNode, reader.Name, reader.Value);
                                }
                            }

                            // add new node to Parent Node or TreeView
                            if (parentNode != null)
                                parentNode.Nodes.Add(newNode);
                            else
                                treeView.Nodes.Add(newNode);

                            // making current node 'ParentNode' if its not empty
                            if (!isEmptyElement)
                            {
                                parentNode = newNode;
                            }
                        }
                    }
                    // moving up to in TreeView if end tag is encountered
                    else if (reader.NodeType == XmlNodeType.EndElement)
                    {
                        if (reader.Name == XmlNodeTag)
                        {
                            parentNode = parentNode.Parent;
                        }
                    }
                    else if (reader.NodeType == XmlNodeType.XmlDeclaration)
                    { //Ignore Xml Declaration                    
                    }
                    else if (reader.NodeType == XmlNodeType.None)
                    {
                        return;
                    }
                    else if (reader.NodeType == XmlNodeType.Text)
                    {
                        parentNode.Nodes.Add(reader.Value);
                    }
                }
            }
            finally
            {
                // enabling redrawing of treeview after all nodes are added
                treeView.EndUpdate();
                reader.Close();
            }
        }

        /// <summary>
        /// Used by Deserialize method for setting properties of TreeNode from xml node attributes
        /// </summary>
        /// <param name="node"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        private void SetAttributeValue(TreeNode node, string propertyName, string value)
        {
            if (propertyName == XmlNodeTextAtt)
            {
                node.Text = value;
            }
            else if (propertyName == XmlNodeImageIndexAtt)
            {
                node.ImageIndex = int.Parse(value);
            }
            else if (propertyName == XmlNodeTagAtt)
            {
                node.Tag = value;
            }
        }

        public void LoadXmlFileInTreeView(TreeView treeView, string fileName)
        {
            XmlTextReader reader = null;
            try
            {
                treeView.BeginUpdate();
                reader = new XmlTextReader(fileName);

                TreeNode n = new TreeNode(fileName);
                treeView.Nodes.Add(n);
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        bool isEmptyElement = reader.IsEmptyElement;
                        StringBuilder text = new StringBuilder();
                        text.Append(reader.Name);
                        int attributeCount = reader.AttributeCount;
                        if (attributeCount > 0)
                        {
                            text.Append(" ( ");
                            for (int i = 0; i < attributeCount; i++)
                            {
                                if (i != 0) text.Append(", ");
                                reader.MoveToAttribute(i);
                                text.Append(reader.Name);
                                text.Append(" = ");
                                text.Append(reader.Value);
                            }
                            text.Append(" ) ");
                        }

                        if (isEmptyElement)
                        {
                            n.Nodes.Add(text.ToString());
                        }
                        else
                        {
                            n = n.Nodes.Add(text.ToString());
                        }
                    }
                    else if (reader.NodeType == XmlNodeType.EndElement)
                    {
                        n = n.Parent;
                    }
                    else if (reader.NodeType == XmlNodeType.XmlDeclaration)
                    {

                    }
                    else if (reader.NodeType == XmlNodeType.None)
                    {
                        return;
                    }
                    else if (reader.NodeType == XmlNodeType.Text)
                    {
                        n.Nodes.Add(reader.Value);
                    }
                }
            }
            finally
            {
                treeView.EndUpdate();
                reader.Close();
            }
        }
    } 
    
    #endregion

    #region HTMLEditHelper class
    public class HTMLEditHelper
    {
        private IHTMLDocument2 m_pDoc2 = null;

        public enum DocumentColors
        {
            Backcolor = 0,
            Forecolor = 1,
            Linkcolor = 2,
            ALinkcolor = 3,
            VLinkcolor = 4
        }

        public string HtmlSpace = "&nbsp;";  // space
        public string HtmlTagOpen = "&lt;";  // <
        public string HtmlTagClose = "&gt;"; // >
        public string HtmlAmp = "&amp;";     // &

        public HTMLEditHelper()
        {

        }

        public IHTMLDocument2 DOMDocument
        {
            get { return m_pDoc2; }
            set { m_pDoc2 = value; }
        }

        /// <summary>
        /// Searches for a parent (or grandparent) element with the given tag
        /// ParentTagName must be in the form "TD" "TR" "TABLE" (uppercase)
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="ParentTagName"></param>
        /// <returns></returns>
        public IHTMLElement FindParent(IHTMLElement elem, string ParentTagName)
        {
            IHTMLElement retelem = elem.parentElement;
            while ((retelem != null) && (retelem.tagName != ParentTagName))
            {
                retelem = retelem.parentElement;
            }
            return retelem;
        }

        /// <summary>
        /// Returns the right neighbour which is a IHTMLElement in the HTML hierarchy
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public IHTMLElement NextSibiling(IHTMLDOMNode node)
        {
            IHTMLDOMNode pnode = node;
            while (true)
            {
                IHTMLDOMNode pnext = pnode.nextSibling;
                if (pnext == null) //No more
                    break;
                //See if this is an HTMLElement
                IHTMLElement elem = pnext as IHTMLElement;
                if (elem != null)
                    return elem;
                pnode = pnext;
            }
            return null;
        }

        /// <summary>
        /// Returns the left neighbour which is a IHTMLElement in the HTML hierarchy
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public IHTMLElement PreviousSibling(IHTMLDOMNode node)
        {
            IHTMLDOMNode pnode = node;
            while (true)
            {
                IHTMLDOMNode pnext = pnode.previousSibling;
                if (pnext == null) //No more
                    break;
                //See if this is an HTMLElement
                IHTMLElement elem = pnext as IHTMLElement;
                if (elem != null)
                    return elem;
                pnode = pnext;
            }
            return null;
        }

        /// <summary>
        /// Removes node element
        /// If RemoveAllChildren == true, Removes this element and all it's children from the document
        /// else it just strips this element but does not remove its children
        /// E.g.  "<BIG><b>Hello World</b></BIG>"  ---> strip BIG tag --> "<b>Hello World</b>"
        /// </summary>
        /// <param name="node">element to remove</param>
        /// <param name="RemoveAllChildren"></param>
        public IHTMLDOMNode RemoveNode(IHTMLElement elem, bool RemoveAllChildren)
        {
            IHTMLDOMNode node = elem as IHTMLDOMNode;
            if (node != null)
                return node.removeNode(RemoveAllChildren);
            else
                return null;
        }

        /// <summary>
        /// Return TRUE if the element is empty inside (e.g. <a name="#Pos1"></a>)
        /// </summary>
        /// <param name="elem"></param>
        /// <returns></returns>
        public bool IsElementEmpty(IHTMLElement elem)
        {
            string str = elem.innerHTML;
            char[] c = { '\r', '\n', '\t' };
            if (string.IsNullOrEmpty(str))
                return true;
            str.Trim(c);
            return (str.Length > 0);
        }

        /// <summary>
        /// 1) If nothing is selected returns false
        /// 2) If the user has selected text or multiple elements
        /// inserts s_BeginHtml before and s_EndHtml behind the current selection
        /// 3)If the user has selected a control returns false
        /// </summary>
        /// <param name="s_BeginHtml"></param>
        /// <param name="s_EndHtml"></param>
        /// <returns></returns>
        // Example s_BeginHtml = "<SUB>", s_EndHtml = "</SUB>" will subscript the selected text
        // Example s_BeginHtml = "", s_EndHtml = "<BR>" will add a BR to the end of the selected text
        //AddToSelection(string.Empty, "<br>");
        public bool AddToSelection(string s_BeginHtml, string s_EndHtml)
        {
            if (m_pDoc2 == null)
                return false;
            IHTMLSelectionObject sel = m_pDoc2.selection as IHTMLSelectionObject;
            if (sel == null)
                return false;
            IHTMLTxtRange range = sel.createRange() as IHTMLTxtRange;
            if (range == null)
                return false;
            string shtml = string.Empty;
            if (!string.IsNullOrEmpty(s_BeginHtml))
                shtml = s_BeginHtml + range.htmlText;
            if (!string.IsNullOrEmpty(s_EndHtml))
                shtml += s_EndHtml;
            range.pasteHTML(shtml);
            range.collapse(false);
            range.select();
            return true;
        }

        /// <summary>
        /// The currently selected text/controls will be replaced by the given HTML code.
        /// If nothing is selected, the HTML code is inserted at the cursor position
        /// </summary>
        /// <param name="s_Html"></param>
        /// <returns></returns>
        public bool PasteIntoSelection(string s_Html)
        {
            if (m_pDoc2 == null)
                return false;
            IHTMLSelectionObject sel = m_pDoc2.selection as IHTMLSelectionObject;
            if (sel == null)
                return false;
            IHTMLTxtRange range = sel.createRange() as IHTMLTxtRange;
            if (range == null)
                return false;
            //none
            //text
            //control
            if ((!String.IsNullOrEmpty(sel.EventType)) &&
                (sel.EventType == "control"))
            {
                IHTMLControlRange ctlrange = range as IHTMLControlRange;
                if (ctlrange != null) //Control(s) selected
                {
                    IHTMLElement elem = null;
                    int ctls = ctlrange.length;
                    for (int i = 0; i < ctls; i++)
                    {
                        //Remove all selected controls
                        elem = ctlrange.item(i);
                        if (elem != null)
                        {
                            RemoveNode(elem, true);
                        }
                    }
                    // Now get the textrange after deleting all selected controls
                    range = null;
                    range = sel.createRange() as IHTMLTxtRange;
                }
            }

            if (range != null)
            {
                // range will be valid if nothing is selected or if text is selected
                // or if multiple elements are seleted
                range.pasteHTML(s_Html);
                range.collapse(false);
                range.select();
            }
            return true;
        }

        /// <summary>
        /// Inserts the given HTML code inside or outside of this Html element
        /// There are 4 possible insert positions:
        /// Outside-Before<TAG>Inside-Before InnerHTML Inside-After</TAG>Ouside-After
        /// </summary>
        /// <param name="elem"></param>
        /// <param name="s_Html"></param>
        /// <param name="b_AtBegin"></param>
        /// <param name="b_Inside"></param>
        public void InsertHTML(IHTMLElement elem, string s_Html, bool b_AtBegin, bool b_Inside)
        {
            if (elem == null)
                return;
            string bs_Where;
            if (b_Inside)
            {
                if (b_AtBegin) bs_Where = "afterBegin";
                else bs_Where = "beforeEnd";
            }
            else // Outside
            {
                if (b_AtBegin) bs_Where = "beforeBegin";
                else bs_Where = "afterEnd";
            }
            elem.insertAdjacentHTML(bs_Where, s_Html);
        }

        /// <summary>
        /// Creates and appends an HTMLElement to the end of the document DOM
        /// </summary>
        /// <param name="TagName">a, img, table,...</param>
        public IHTMLDOMNode AppendChild(string TagName)
        {
            if (m_pDoc2 == null)
                return null;
            IHTMLElement elem = m_pDoc2.createElement(TagName) as IHTMLElement;
            if (elem == null)
                return null;
            //Append to body DOM collection
            IHTMLDOMNode nd = (IHTMLDOMNode)elem;
            IHTMLDOMNode body = (IHTMLDOMNode)m_pDoc2.body;
            return body.appendChild(nd);
        }

        /// <summary>
        /// Creates and appends an HTMLElement to a parent element
        /// </summary>
        /// <param name="TagName">a, img, table,...</param>
        public IHTMLDOMNode AppendChild(IHTMLElement parent, string TagName)
        {
            if (m_pDoc2 == null)
                return null;
            IHTMLElement elem = m_pDoc2.createElement(TagName) as IHTMLElement;
            if (elem == null)
                return null;
            //Append to body DOM collection
            IHTMLDOMNode nd = (IHTMLDOMNode)elem;
            IHTMLDOMNode body = (IHTMLDOMNode)parent;
            return body.appendChild(nd);
        }

        public System.Drawing.Color GetDocumentColor(DocumentColors whichcolor)
        {
            System.Drawing.Color cret = System.Drawing.Color.Empty;
            if (m_pDoc2 != null)
            {
                if ((whichcolor == DocumentColors.Backcolor) && (m_pDoc2.bgColor != null))
                    cret = System.Drawing.ColorTranslator.FromHtml(m_pDoc2.bgColor.ToString());
                else if ((whichcolor == DocumentColors.Forecolor) && (m_pDoc2.fgColor != null))
                    cret = System.Drawing.ColorTranslator.FromHtml(m_pDoc2.fgColor.ToString());
                else if ((whichcolor == DocumentColors.Linkcolor) && (m_pDoc2.linkColor != null))
                    cret = System.Drawing.ColorTranslator.FromHtml(m_pDoc2.linkColor.ToString());
                else if ((whichcolor == DocumentColors.ALinkcolor) && (m_pDoc2.alinkColor != null))
                    cret = System.Drawing.ColorTranslator.FromHtml(m_pDoc2.alinkColor.ToString());
                else if ((whichcolor == DocumentColors.VLinkcolor) && (m_pDoc2.vlinkColor != null))
                    cret = System.Drawing.ColorTranslator.FromHtml(m_pDoc2.vlinkColor.ToString());
            }
            return cret;
        }

        public bool EmbedBr()
        {
            return AddToSelection(string.Empty, "<br>");
        }

        //<img border="2" src="file:///C:/csEXWB/csEXWB.gif" align="center" hspace="2" vspace="2" alt="hello there" lowsrc="file:///C:/Desktop/blank.gif" width="600" height="463">
        public bool AppendImage(string src, string width, string height, string border, string alignment, string alt, string hspace, string vspace, string lowsrc)
        {
            if (m_pDoc2 == null)
                return false;
            IHTMLElement elem = m_pDoc2.createElement("img") as IHTMLElement;

            if (elem == null)
                return false;

            IHTMLImgElement imgelem = elem as IHTMLImgElement;
            if (imgelem == null)
                return false;

            if (!string.IsNullOrEmpty(src))
                imgelem.src = src;
            if (!string.IsNullOrEmpty(width))
                imgelem.width = int.Parse(width);
            if (!string.IsNullOrEmpty(height))
                imgelem.height = int.Parse(height);
            if (!string.IsNullOrEmpty(border))
                imgelem.border = border;
            if (!string.IsNullOrEmpty(alignment))
                imgelem.align = alignment;
            if (!string.IsNullOrEmpty(hspace))
                imgelem.hspace = int.Parse(hspace);
            if (!string.IsNullOrEmpty(vspace))
                imgelem.vspace = int.Parse(vspace);
            if (!string.IsNullOrEmpty(alt))
                imgelem.alt = alt;
            if (!string.IsNullOrEmpty(lowsrc))
                imgelem.lowsrc = lowsrc;

            //Append to body DOM collection
            IHTMLDOMNode nd = (IHTMLDOMNode)elem;
            IHTMLDOMNode body = (IHTMLDOMNode)m_pDoc2.body;
            return (body.appendChild(nd) != null);
        }

        //<a href="http://www.google.com" target="_blank">google</a>
        //Uses selection text
        public bool AppendAnchor(string href, string target)
        {
            if (m_pDoc2 == null)
                return false;
            IHTMLElement elem = m_pDoc2.createElement("a") as IHTMLElement;

            if (elem == null)
                return false;

            IHTMLAnchorElement aelem = elem as IHTMLAnchorElement;
            if (aelem == null)
                return false;

            if (!string.IsNullOrEmpty(href))
                aelem.href = href;
            if (!string.IsNullOrEmpty(target))
                aelem.target = target;

            //Append to body DOM collection
            IHTMLDOMNode nd = (IHTMLDOMNode)elem;
            IHTMLDOMNode body = (IHTMLDOMNode)m_pDoc2.body;
            return (body.appendChild(nd) != null);
        }

        //editor.AppendHr("center", string.Empty, "300", false);
        //left, center, right, justify
        public bool AppendHr(string align, string hrcolor, string width, bool noshade)
        {
            if (m_pDoc2 == null)
                return false;
            IHTMLElement elem = m_pDoc2.createElement("hr") as IHTMLElement;

            if (elem == null)
                return false;

            IHTMLHRElement hrelem = elem as IHTMLHRElement;
            if (hrelem == null)
                return false;

            if (!string.IsNullOrEmpty(align))
                hrelem.align = align;
            if (!string.IsNullOrEmpty(hrcolor))
                hrelem.color = hrcolor;
            if (!string.IsNullOrEmpty(width))
                hrelem.width = width;
            hrelem.noShade = noshade;

            //Append to body DOM collection
            IHTMLDOMNode nd = (IHTMLDOMNode)elem;
            IHTMLDOMNode body = (IHTMLDOMNode)m_pDoc2.body;
            return (body.appendChild(nd) != null);
        }

        #region Table specific

        //bordersize 2 or "2"
        public bool AppendTable(int colnum, int rownum, int bordersize, string alignment, int cellpadding, int cellspacing, string widthpercentage, int widthpixel, string backcolor, string bordercolor, string lightbordercolor, string darkbordercolor)
        {
            if (m_pDoc2 == null)
                return false;
            IHTMLTable t = (IHTMLTable)m_pDoc2.createElement("table");
            //set the cols
            t.cols = colnum;
            t.border = bordersize;

            if (!string.IsNullOrEmpty(alignment))
                t.align = alignment; //"center"
            t.cellPadding = cellpadding; //1
            t.cellSpacing = cellspacing; //2

            if (!string.IsNullOrEmpty(widthpercentage))
                t.width = widthpercentage; //"50%"; 
            else if (widthpixel > 0)
                t.width = widthpixel; //80;

            if (!string.IsNullOrEmpty(backcolor))
                t.bgColor = backcolor;

            if (!string.IsNullOrEmpty(bordercolor))
                t.borderColor = bordercolor;

            if (!string.IsNullOrEmpty(lightbordercolor))
                t.borderColorLight = lightbordercolor;

            if (!string.IsNullOrEmpty(darkbordercolor))
                t.borderColorDark = darkbordercolor;

            //Insert rows and fill them with space
            int cells = colnum - 1;
            int rows = rownum - 1;

            CalculateCellWidths(colnum);
            for (int i = 0; i <= rows; i++)
            {
                IHTMLTableRow tr = (IHTMLTableRow)t.insertRow(-1);
                for (int j = 0; j <= cells; j++)
                {
                    IHTMLElement c = tr.insertCell(-1) as IHTMLElement;
                    if (c != null)
                    {
                        c.innerHTML = HtmlSpace;
                        IHTMLTableCell tcell = c as IHTMLTableCell;
                        if (tcell != null)
                        {
                            //set width so as user enters text
                            //the cell width would not adjust
                            if (j == cells) //last cell
                                tcell.width = m_lastcellwidth;
                            else
                                tcell.width = m_cellwidth;
                        }
                    }
                }
            }

            //Append to body DOM collection
            IHTMLDOMNode nd = (IHTMLDOMNode)t;
            IHTMLDOMNode body = (IHTMLDOMNode)m_pDoc2.body;
            return (body.appendChild(nd) != null);

        }

        /// <summary>
        /// Returns parent row of passed cell element
        /// </summary>
        /// <param name="cellelem"></param>
        /// <returns></returns>
        public IHTMLTableRow GetParentRow(IHTMLElement cellelem)
        {
            IHTMLElement elem = FindParent(cellelem, "TR");
            if (elem != null)
                return elem as IHTMLTableRow;
            else
                return null;
        }

        /// <summary>
        /// Returns parent table of passed cell element
        /// </summary>
        /// <param name="cellelem"></param>
        /// <returns></returns>
        public IHTMLTable GetParentTable(IHTMLElement cellelem)
        {
            IHTMLElement elem = FindParent(cellelem, "TABLE");
            if (elem != null)
                return elem as IHTMLTable;
            else
                return null;
        }

        /// <summary>
        /// Get the column of the current cell
        /// zero based
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public int GetColIndex(IHTMLTableCell cell)
        {
            if (cell == null)
                return 0;
            int iret = 0;
            IHTMLTableCell tcell = cell;
            IHTMLDOMNode node = null;
            IHTMLElement elem = null;
            while (true)
            {
                node = tcell as IHTMLDOMNode;
                if (node == null)
                    break;
                elem = PreviousSibling(node);
                if (elem == null)
                    break;
                tcell = elem as IHTMLTableCell;
                if (tcell == null)
                    break;
                iret += tcell.colSpan;
            }
            return iret;
        }

        // zero based
        public int GetRowIndex(IHTMLElement cellelem)
        {
            IHTMLTableRow row = GetParentRow(cellelem);
            if (row != null)
                return row.rowIndex;
            return 0;
        }

        /// <summary>
        /// Zero based
        /// </summary>
        /// <param name="table"></param>
        /// <param name="rowindex"></param>
        /// <returns></returns>
        public IHTMLTableRow GetRow(IHTMLTable table, int rowindex)
        {
            IHTMLElementCollection rows = table.rows;
            if (rows == null)
                return null;
            object obj = rowindex;
            return rows.item(obj, obj) as IHTMLTableRow;
        }

        public int GetRowCount(IHTMLTable table)
        {
            IHTMLElementCollection rows = table.rows;
            if (rows != null)
                return rows.length;
            return 0;
        }

        /// <summary>
        /// Gets the column count of row(rowindex)
        /// Accounts for colSpan property
        /// </summary>
        /// <param name="table"></param>
        /// <param name="colindex"></param>
        /// <returns></returns>
        public int GetColCount(IHTMLTable table, int rowindex)
        {
            IHTMLTableRow row = GetRow(table, rowindex);
            if (row == null)
                return 0;
            int counter = 0;
            int cols = 0;
            while (true)
            {
                IHTMLTableCell cell = Row_GetCell(row, counter);
                if (cell == null)
                    break;
                cols += cell.colSpan;
                counter++;
            }
            return cols;
        }

        /// <summary>
        /// Deletes a given rowindex in a given table
        /// zero based
        /// If the table has no rows after deletion anymore
        /// we delete it compeletely
        /// </summary>
        /// <param name="table"></param>
        /// <param name="rowindex"></param>
        public void DeleteRow(IHTMLTable table, int rowindex)
        {
            table.deleteRow(rowindex);
            if (GetRowCount(table) == 0)
                RemoveNode(table as IHTMLElement, true);
        }

        public void DeleteCol(IHTMLTable table, int colindex)
        {
            for (int i = 0; true; i++)
            {
                IHTMLTableRow row = GetRow(table, i);
                if (row == null)
                    break;

                IHTMLTableCell cell = Row_GetCell(row, colindex);
                if (cell == null)
                    continue;
                RemoveNode(cell as IHTMLElement, true);
                if (Row_GetCellCount(row) == 0)
                {
                    RemoveNode(table as IHTMLElement, true);
                    break;
                }

                //Accounts for colspan
                //Row_DeleteCol(row, colindex);

                IHTMLElementCollection cells = row.cells;
                CalculateCellWidths(cells.length);
                for (int j = 0; j < cells.length; j++)
                {
                    object obj = j;
                    IHTMLTableCell cella = cells.item(obj, obj) as IHTMLTableCell;
                    if (cella != null)
                    {
                        if ((j + 1) == cells.length)
                            cella.width = m_lastcellwidth;
                        else
                            cella.width = m_cellwidth;
                    }
                }
            }
        }

        public int Row_GetCellCount(IHTMLTableRow row)
        {
            if (row == null)
                return 0;
            IHTMLElementCollection cells = row.cells;
            if (cells != null)
                return cells.length;
            return 0;
        }

        public void Row_DeleteCol(IHTMLTableRow row, int index)
        {
            int col = 0;
            int span = 0;
            IHTMLTableCell cell = Row_GetCell(row, 0);
            IHTMLElement elem = null;
            while (true)
            {
                if (cell == null)
                    return;
                span = cell.colSpan;
                //cell.cellIndex
                if (span == 1)
                {
                    if (col == index)
                    {
                        RemoveNode(cell as IHTMLElement, true);
                        if (Row_GetCellCount(row) == 0)
                        {
                            IHTMLTable table = GetParentTable(row as IHTMLElement) as IHTMLTable;
                            if (table != null)
                                RemoveNode(table as IHTMLElement, true);
                            break;
                        }
                    }
                }
                else if (span > 1)// cell spans about multiple columns
                {
                    if (index >= col && index < col + span)
                    {
                        cell.colSpan = span - 1; // reduce cellspan
                        break;
                    }
                }
                col += span;
                //Get next sibiling
                elem = NextSibiling(cell as IHTMLDOMNode);
                if (elem != null)
                    cell = elem as IHTMLTableCell;
                else
                    cell = null;
            }
        }

        public IHTMLElement Row_InsertCell(IHTMLTableRow row, int index)
        {
            IHTMLElement elem = row.insertCell(index) as IHTMLElement;
            if (elem != null)
                elem.innerHTML = HtmlSpace;
            return elem;
        }

        public IHTMLElement Row_InsertCell(IHTMLTableRow row, int index, string cellwidth)
        {
            IHTMLElement elem = row.insertCell(index) as IHTMLElement;
            if (elem != null)
            {
                elem.innerHTML = HtmlSpace;
                if (!string.IsNullOrEmpty(cellwidth))
                {
                    IHTMLTableCell tcell = elem as IHTMLTableCell;
                    if (tcell != null)
                    {
                        tcell.width = cellwidth;
                    }
                }
            }
            return elem;
        }

        public IHTMLElement Row_InsertCol(IHTMLTableRow row, int index)
        {
            int col = 0;
            int span = 0;
            object obj = 0;
            IHTMLElementCollection cells = row.cells;
            IHTMLElement retelem = null;

            for (int i = 0; true; i++)
            {
                obj = i;
                IHTMLTableCell cell = cells.item(obj, obj) as IHTMLTableCell;
                if (cell == null) // insert behind the rightmost cell
                {
                    retelem = Row_InsertCell(row, i);
                    break;
                }
                span = cell.colSpan;
                if (span == col) // insert at the left of the specified cell
                {
                    retelem = Row_InsertCell(row, i);
                    break;
                }
                if ((index > col) && (index < (col + span)))
                {
                    cell.colSpan = span + 1; // increase cellspan of multi column cell
                    retelem = cell as IHTMLElement;
                    break;
                }
                col += span;
                retelem = null;
            }

            //Set width as evenly as possible
            CalculateCellWidths(cells.length);
            for (int i = 0; i < cells.length; i++)
            {
                obj = i;
                IHTMLTableCell cell = cells.item(obj, obj) as IHTMLTableCell;
                if (cell != null)
                {
                    if ((i + 1) == cells.length)
                        cell.width = m_lastcellwidth;
                    else
                        cell.width = m_cellwidth;
                }
            }
            return retelem;
        }

        public IHTMLTableCell Row_GetCell(IHTMLTableRow row, int index)
        {
            IHTMLElementCollection cells = row.cells;
            if (cells == null)
                return null;
            object obj = index;
            return cells.item(obj, obj) as IHTMLTableCell;
        }

        private string m_cellwidth = string.Empty;
        private string m_lastcellwidth = string.Empty;
        private void CalculateCellWidths(int numberofcols)
        {
            //Even numbers. for 2 cols; 50%, 50%
            //Odd numbers.  for 3 cols; 33%, 33%, 34%
            int cellwidth = (int)(100 / numberofcols);
            m_cellwidth = cellwidth.ToString() + "%";
            //modulus operator (%).
            //http://msdn2.microsoft.com/en-us/library/0w4e0fzs.aspx
            //http://msdn2.microsoft.com/en-us/library/6a71f45d.aspx
            cellwidth += 100 % numberofcols;
            m_lastcellwidth = cellwidth.ToString() + "%";
        }

        public void InsertRow(IHTMLTable table, int index, int numberofcells)
        {
            IHTMLTableRow row = table.insertRow(index) as IHTMLTableRow;
            if (row == null)
                return;

            CalculateCellWidths(numberofcells);
            for (int j = 0; j < numberofcells; j++)
            {
                if ((j + 1) == numberofcells)
                    Row_InsertCell(row, -1, m_lastcellwidth);
                else
                    Row_InsertCell(row, -1, m_cellwidth);
            }
        }

        public void InsertCol(IHTMLTable table, int index)
        {
            for (int j = 0; true; j++)
            {
                IHTMLTableRow row = GetRow(table, j);
                if (row == null)
                    return;
                if (Row_InsertCol(row, index) == null)
                    return;
            }
        }

        #endregion

    } 
    #endregion

    public sealed class WindowsHookUtil
    {
        public struct HookInfo
        {
            //This is a Unique MsgID which is registered by the DLL
            //and passed to the client when hooking starts, each hook
            //has it's own MsgID. Used in WndProc to capture hook notifications
            public int UniqueMsgID;
            public CSEXWBDLMANLib.WINDOWSHOOK_TYPES HookType;
            public bool IsHooked;
            public HookInfo(CSEXWBDLMANLib.WINDOWSHOOK_TYPES _HookType)
            {
                this.HookType = _HookType;
                UniqueMsgID = 0;
                this.IsHooked = false;
            }
        }

        //
        //LL Keyboard hook
        //
        [StructLayout(LayoutKind.Sequential)]
        public class KBDLLHOOKSTRUCT
        {
            [MarshalAs(UnmanagedType.I4)]
            public int vkCode = 0;
            [MarshalAs(UnmanagedType.I4)]
            public int scanCode = 0;
            [MarshalAs(UnmanagedType.I4)]
            public int flags = 0;
            [MarshalAs(UnmanagedType.I4)]
            public int time = 0;
            public IntPtr dwExtraInfo = IntPtr.Zero;

            public void Reset()
            {
                this.vkCode = 0;
                this.flags = 0;
                this.scanCode = 0;
                this.time = 0;
                this.dwExtraInfo = IntPtr.Zero;
            }
        }

        //
        //CBT hook
        //
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class CREATESTRUCT
        {
            public IntPtr lpCreateParams;
            public IntPtr hInstance;
            public IntPtr hMenu;
            public IntPtr hwndParent;
            public int cy;
            public int cx;
            public int y;
            public int x;
            public int style;
            public IntPtr lpszName;
            public IntPtr lpszClass;
            public int dwExStyle;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class CBT_CREATEWND
        {
            public IntPtr lpcs; //CREATESTRUCT
            public IntPtr hwndInsertAfter;
        }
        //nCode
        public const int HCBT_MOVESIZE = 0;
        public const int HCBT_MINMAX = 1;
        public const int HCBT_QS = 2;
        public const int HCBT_CREATEWND = 3;
        public const int HCBT_DESTROYWND = 4;
        public const int HCBT_ACTIVATE = 5;
        public const int HCBT_CLICKSKIPPED = 6;
        public const int HCBT_KEYSKIPPED = 7;
        public const int HCBT_SYSCOMMAND = 8;
        public const int HCBT_SETFOCUS = 9;
    }
}