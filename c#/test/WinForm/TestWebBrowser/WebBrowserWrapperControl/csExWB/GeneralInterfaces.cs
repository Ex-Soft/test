using System;
using System.IO;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security;
using System.Collections;
using System.Text;

namespace IfacesEnumsStructsClasses
{

    #region IWebBrowser2 Interface

    [ComImport,
    Guid("D30C1661-CDAF-11D0-8A3E-00C04FC9E26E"),
    InterfaceType(ComInterfaceType.InterfaceIsIDispatch),
    SuppressUnmanagedCodeSecurity]
    public interface IWebBrowser2
    {
        [DispId(100)]
        void GoBack();
        [DispId(0x65)]
        void GoForward();
        [DispId(0x66)]
        void GoHome();
        [DispId(0x67)]
        void GoSearch();
        [DispId(0x68)]
        void Navigate([MarshalAs(UnmanagedType.BStr)] string URL, [In] ref object Flags, [In] ref object TargetFrameName, [In] ref object PostData, [In] ref object Headers);
        [DispId(-550)]
        void Refresh();
        [DispId(0x69)]
        void Refresh2([In] ref object Level);
        [DispId(0x6a)]
        void Stop();
        [DispId(300)]
        void Quit();
        [DispId(0x12d)]
        void ClientToWindow([In, Out] ref int pcx, [In, Out] ref int pcy);
        [DispId(0x12e)]
        void PutProperty([MarshalAs(UnmanagedType.BStr)] string Property, object vtValue);
        [DispId(0x12f)]
        object GetProperty([MarshalAs(UnmanagedType.BStr)] string Property);
        [DispId(500)]
        void Navigate2([In] ref object URL, [In] ref object Flags, [In] ref object TargetFrameName, [In] ref object PostData, [In] ref object Headers);
        [DispId(0x1f5)]
        OLECMDF QueryStatusWB(OLECMDID cmdID);
        [DispId(0x1f6)]
        void ExecWB(OLECMDID cmdID, OLECMDEXECOPT cmdexecopt, [In] ref object pvaIn, [In, Out] ref object pvaOut);
        [DispId(0x1f7)]
        void ShowBrowserBar([In] ref object pvaClsid, [In] ref object pvarShow, [In] ref object pvarSize);
        bool AddressBar { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(0x22b)] get; [DispId(0x22b)] set; }
        object Application { [return: MarshalAs(UnmanagedType.IDispatch)] [DispId(200)] get; }
        bool Busy { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(0xd4)] get; }
        object Container { [return: MarshalAs(UnmanagedType.IDispatch)] [DispId(0xca)] get; }
        object Document { [return: MarshalAs(UnmanagedType.IDispatch)] [DispId(0xcb)] get; }
        string FullName { [return: MarshalAs(UnmanagedType.BStr)] [DispId(400)] get; }
        bool FullScreen { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(0x197)] get; [DispId(0x197)] set; }
        int Height { [DispId(0xd1)] get; [DispId(0xd1)] set; }
        int HWND { [DispId(-515)] get; }
        int Left { [DispId(0xce)] get; [DispId(0xce)] set; }
        string LocationName { [return: MarshalAs(UnmanagedType.BStr)] [DispId(210)] get; }
        string LocationURL { [return: MarshalAs(UnmanagedType.BStr)] [DispId(0xd3)] get; }
        bool MenuBar { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(0x196)] get; [DispId(0x196)] set; }
        string Name { [return: MarshalAs(UnmanagedType.BStr)] [DispId(0)] get; }
        bool Offline { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(550)] get; [DispId(550)] set; }
        object Parent { [return: MarshalAs(UnmanagedType.IDispatch)] [DispId(0xc9)] get; }
        string Path { [return: MarshalAs(UnmanagedType.BStr)] [DispId(0x191)] get; }
        tagREADYSTATE ReadyState { [DispId(-525)] get; }
        bool RegisterAsBrowser { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(0x228)] get; [DispId(0x228)] set; }
        bool RegisterAsDropTarget { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(0x229)] get; [DispId(0x229)] set; }
        bool Resizable { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(0x22c)] get; [DispId(0x22c)] set; }
        bool Silent { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(0x227)] get; [DispId(0x227)] set; }
        bool StatusBar { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(0x193)] get; [DispId(0x193)] set; }
        string StatusText { [return: MarshalAs(UnmanagedType.BStr)] [DispId(0x194)] get; [DispId(0x194)] set; }
        bool TheaterMode { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(0x22a)] get; [DispId(0x22a)] set; }
        int ToolBar { [DispId(0x195)] get; [DispId(0x195)] set; }
        int Top { [DispId(0xcf)] get; [DispId(0xcf)] set; }
        bool TopLevelContainer { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(0xcc)] get; }
        string Type { [return: MarshalAs(UnmanagedType.BStr)] [DispId(0xcd)] get; }
        bool Visible { [return: MarshalAs(UnmanagedType.VariantBool)] [DispId(0x192)] get; [DispId(0x192)] set; }
        int Width { [DispId(0xd0)] get; [DispId(0xd0)] set; }
    }

    #endregion

    #region IHTMLEventCallBack Interface
    /// <summary>
    /// Simple interface used as a callback implemented by the main control
    /// GUID generated using PSDK GUID generator
    /// </summary>
    [ComVisible(true), Guid("9995A2E0-CD26-4f3a-87FD-0E2B9B1F4648")]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IHTMLEventCallBack
    {
        bool HandleHTMLEvent([In] HTMLEventType EventType, [In] HTMLEventDispIds EventDispId, [In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
    } 
    #endregion

    #region IEnumSTATURL Interface
    [ComImport, ComVisible(true)]
    [Guid("3C374A42-BAE4-11CF-BF7D-00AA006946EE")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IEnumSTATURL
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Next(
            [In, MarshalAs(UnmanagedType.U4)] int celt,
            [Out, MarshalAs(UnmanagedType.LPStruct)] out STATURL rgelt,
            [Out, MarshalAs(UnmanagedType.U4)] out int pceltFetched);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Skip([In, MarshalAs(UnmanagedType.U4)] int celt);
        void Reset();
        void Clone(out IEnumSTATURL ppenum);
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int SetFilter([In, MarshalAs(UnmanagedType.LPWStr)] string poszFilter, uint dwFlags);
    } 
    #endregion

    #region IEnumUnknwon Interface

    [ComImport, ComVisible(true)]
    [Guid("00000100-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IEnumUnknown
    {
        [PreserveSig]
        int Next(
            [In, MarshalAs(UnmanagedType.U4)] int celt,
            [Out, MarshalAs(UnmanagedType.IUnknown)] out object rgelt,
            [Out, MarshalAs(UnmanagedType.U4)] out int pceltFetched);
        [PreserveSig]
        int Skip([In, MarshalAs(UnmanagedType.U4)] int celt);
        void Reset();
        void Clone(out IEnumUnknown ppenum);
    }

    #endregion

    #region IUrlHistoryStg Interface
    [ComImport, ComVisible(true)]
    [Guid("3C374A41-BAE4-11CF-BF7D-00AA006946EE")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IUrlHistoryStg
    {
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int AddUrl(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pocsUrl,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pocsTitle,
            uint dwFlags);

        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int DeleteUrl(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pocsUrl,
            uint dwFlags);

        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int QueryUrl(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pocsUrl,
            uint dwFlags,
            [MarshalAs(UnmanagedType.Interface)] out STATURL lpSTATURL);
        /// <summary>
        /// Currently not implemented
        /// </summary>
        /// <param name="pocsUrl"></param>
        /// <param name="riid"></param>
        /// <param name="ppvOut"></param>
        /// <returns></returns>
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int BindToObject(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pocsUrl,
            ref Guid riid,
            object ppvOut);

        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int EnumUrls(out IEnumSTATURL ppEnum);
    } 
    #endregion

    #region IUrlHistoryStg2 Interface
    [ComImport, ComVisible(true)]
    [Guid("AFA0DC11-C313-11d0-831A-00C04FD5AE38")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IUrlHistoryStg2
    {
        //
        //IUrlHistoryStg
        //

        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int AddUrl(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pocsUrl,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pocsTitle,
            uint dwFlags);

        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int DeleteUrl(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pocsUrl,
            uint dwFlags);

        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int QueryUrl(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pocsUrl,
            uint dwFlags,
            [MarshalAs(UnmanagedType.Interface)] out STATURL lpSTATURL);

        //Currently not implemented
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int BindToObject(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pocsUrl,
            ref Guid riid,
            object ppvOut);

        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int EnumUrls(out IEnumSTATURL ppEnum);

        //
        //IUrlHistoryStg2
        //

        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int AddUrlAndNotify(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pocsUrl,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pocsTitle,
            uint dwFlags,
            bool fWriteHistory,
            [In, MarshalAs(UnmanagedType.Interface)] IOleCommandTarget poctNotify,
            [In, MarshalAs(UnmanagedType.IUnknown)] object punkISFolder);

        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int ClearHistory();
    } 
    #endregion

    #region IHttpNegotiate Interface
    //MIDL_INTERFACE("79eac9d2-baf9-11ce-8c82-00aa004ba90b")
    //IHttpNegotiate : public IUnknown
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE BeginningTransaction( 
    //        /* [in] */ LPCWSTR szURL,
    //        /* [unique][in] */ LPCWSTR szHeaders,
    //        /* [in] */ DWORD dwReserved,
    //        /* [out] */ LPWSTR *pszAdditionalHeaders) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE OnResponse( 
    //        /* [in] */ DWORD dwResponseCode,
    //        /* [unique][in] */ LPCWSTR szResponseHeaders,
    //        /* [unique][in] */ LPCWSTR szRequestHeaders,
    //        /* [out] */ LPWSTR *pszAdditionalRequestHeaders) = 0;
    //}
    [ComImport, ComVisible(true)]
    [Guid("79eac9d2-baf9-11ce-8c82-00aa004ba90b")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IHttpNegotiate
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int BeginningTransaction(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szURL,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szHeaders,
            [In, MarshalAs(UnmanagedType.U4)] UInt32 dwReserved,
            [Out] out IntPtr pszAdditionalHeaders);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnResponse(
            [In, MarshalAs(UnmanagedType.U4)] UInt32 dwResponseCode,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szResponseHeaders,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szRequestHeaders,
            [Out] out IntPtr pszAdditionalRequestHeaders);
    }
    #endregion

    #region IDocHostShowUI Interface
    //MIDL_INTERFACE("c4d244b0-d43e-11cf-893b-00aa00bdce1a")
    //IDocHostShowUI : public IUnknown
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE ShowMessage( 
    //        /* [in] */ HWND hwnd,
    //        /* [in] */ LPOLESTR lpstrText,
    //        /* [in] */ LPOLESTR lpstrCaption,
    //        /* [in] */ DWORD dwType,
    //        /* [in] */ LPOLESTR lpstrHelpFile,
    //        /* [in] */ DWORD dwHelpContext,
    //        /* [out] */ LRESULT *plResult) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE ShowHelp( 
    //        /* [in] */ HWND hwnd,
    //        /* [in] */ LPOLESTR pszHelpFile,
    //        /* [in] */ UINT uCommand,
    //        /* [in] */ DWORD dwData,
    //        /* [in] */ POINT ptMouse,
    //        /* [out] */ IDispatch *pDispatchObjectHit) = 0;

    //};
    [ComImport, ComVisible(true)]
    [Guid("C4D244B0-D43E-11CF-893B-00AA00BDCE1A")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDocHostShowUI
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ShowMessage(
            IntPtr hwnd,
            [MarshalAs(UnmanagedType.LPWStr)] string lpstrText,
            [MarshalAs(UnmanagedType.LPWStr)] string lpstrCaption,
            [MarshalAs(UnmanagedType.U4)] uint dwType,
            [MarshalAs(UnmanagedType.LPWStr)] string lpstrHelpFile,
            [MarshalAs(UnmanagedType.U4)] uint dwHelpContext,
            [In, Out] ref int lpResult);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ShowHelp(
            IntPtr hwnd,
            [MarshalAs(UnmanagedType.LPWStr)] string pszHelpFile,
            [MarshalAs(UnmanagedType.U4)] uint uCommand,
            [MarshalAs(UnmanagedType.U4)] uint dwData,
            [In, MarshalAs(UnmanagedType.Struct)] tagPOINT ptMouse,
            [Out, MarshalAs(UnmanagedType.IDispatch)] object pDispatchObjectHit);
    }
    #endregion

    #region IDocHostUIHandler Interface
    //MIDL_INTERFACE("bd3f23c0-d43e-11cf-893b-00aa00bdce1a")
    //IDocHostUIHandler : public IUnknown
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE ShowContextMenu( 
    //        /* [in] */ DWORD dwID,
    //        /* [in] */ POINT *ppt,
    //        /* [in] */ IUnknown *pcmdtReserved,
    //        /* [in] */ IDispatch *pdispReserved) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE GetHostInfo( 
    //        /* [out][in] */ DOCHOSTUIINFO *pInfo) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE ShowUI( 
    //        /* [in] */ DWORD dwID,
    //        /* [in] */ IOleInPlaceActiveObject *pActiveObject,
    //        /* [in] */ IOleCommandTarget *pCommandTarget,
    //        /* [in] */ IOleInPlaceFrame *pFrame,
    //        /* [in] */ IOleInPlaceUIWindow *pDoc) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE HideUI( void) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE UpdateUI( void) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE EnableModeless( 
    //        /* [in] */ BOOL fEnable) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE OnDocWindowActivate( 
    //        /* [in] */ BOOL fActivate) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE OnFrameWindowActivate( 
    //        /* [in] */ BOOL fActivate) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE ResizeBorder( 
    //        /* [in] */ LPCRECT prcBorder,
    //        /* [in] */ IOleInPlaceUIWindow *pUIWindow,
    //        /* [in] */ BOOL fRameWindow) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE TranslateAccelerator( 
    //        /* [in] */ LPMSG lpMsg,
    //        /* [in] */ const GUID *pguidCmdGroup,
    //        /* [in] */ DWORD nCmdID) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE GetOptionKeyPath( 
    //        /* [out] */ LPOLESTR *pchKey,
    //        /* [in] */ DWORD dw) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE GetDropTarget( 
    //        /* [in] */ IDropTarget *pDropTarget,
    //        /* [out] */ IDropTarget **ppDropTarget) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE GetExternal( 
    //        /* [out] */ IDispatch **ppDispatch) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE TranslateUrl( 
    //        /* [in] */ DWORD dwTranslate,
    //        /* [in] */ OLECHAR *pchURLIn,
    //        /* [out] */ OLECHAR **ppchURLOut) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE FilterDataObject( 
    //        /* [in] */ IDataObject *pDO,
    //        /* [out] */ IDataObject **ppDORet) = 0;

    //};
    [ComVisible(true), ComImport()]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [GuidAttribute("bd3f23c0-d43e-11cf-893b-00aa00bdce1a")]
    public interface IDocHostUIHandler
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ShowContextMenu(
            [In, MarshalAs(UnmanagedType.U4)] uint dwID,
            [In, MarshalAs(UnmanagedType.Struct)] ref tagPOINT pt,
            [In, MarshalAs(UnmanagedType.IUnknown)] object pcmdtReserved,
            [In, MarshalAs(UnmanagedType.IDispatch)] object pdispReserved);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetHostInfo([In, Out, MarshalAs(UnmanagedType.Struct)] ref DOCHOSTUIINFO info);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ShowUI(
            [In, MarshalAs(UnmanagedType.I4)] int dwID,
            [In, MarshalAs(UnmanagedType.Interface)] IOleInPlaceActiveObject activeObject,
            [In, MarshalAs(UnmanagedType.Interface)] IOleCommandTarget commandTarget,
            [In, MarshalAs(UnmanagedType.Interface)] IOleInPlaceFrame frame,
            [In, MarshalAs(UnmanagedType.Interface)] IOleInPlaceUIWindow doc);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int HideUI();

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int UpdateUI();

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int EnableModeless(
            [In, MarshalAs(UnmanagedType.Bool)] bool fEnable);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnDocWindowActivate(
            [In, MarshalAs(UnmanagedType.Bool)] bool fActivate);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnFrameWindowActivate(
            [In, MarshalAs(UnmanagedType.Bool)] bool fActivate);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ResizeBorder(
            [In, MarshalAs(UnmanagedType.Struct)] ref tagRECT rect,
            [In, MarshalAs(UnmanagedType.Interface)] IOleInPlaceUIWindow doc,
            [In, MarshalAs(UnmanagedType.Bool)] bool fFrameWindow);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int TranslateAccelerator(
            [In, MarshalAs(UnmanagedType.Struct)] ref tagMSG msg,
            [In] ref Guid group,
            [In, MarshalAs(UnmanagedType.U4)] uint nCmdID);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetOptionKeyPath(
            //out IntPtr pbstrKey,
            [Out, MarshalAs(UnmanagedType.LPWStr)] out String pbstrKey,
            //[Out, MarshalAs(UnmanagedType.LPArray)] String[] pbstrKey,
            [In, MarshalAs(UnmanagedType.U4)] uint dw);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetDropTarget(
            [In, MarshalAs(UnmanagedType.Interface)] IDropTarget pDropTarget,
            [Out, MarshalAs(UnmanagedType.Interface)] out IDropTarget ppDropTarget);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetExternal(
            [Out, MarshalAs(UnmanagedType.IDispatch)] out object ppDispatch);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int TranslateUrl(
            [In, MarshalAs(UnmanagedType.U4)] uint dwTranslate,
            [In, MarshalAs(UnmanagedType.LPWStr)] string strURLIn,
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string pstrURLOut);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int FilterDataObject(
            [In, MarshalAs(UnmanagedType.Interface)] System.Runtime.InteropServices.ComTypes.IDataObject pDO,
            [Out, MarshalAs(UnmanagedType.Interface)] out System.Runtime.InteropServices.ComTypes.IDataObject ppDORet);
    }
    #endregion

    #region IDropTarget Interface
    //MIDL_INTERFACE("00000122-0000-0000-C000-000000000046")
    //IDropTarget : public IUnknown
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE DragEnter( 
    //        /* [unique][in] */ IDataObject *pDataObj,
    //        /* [in] */ DWORD grfKeyState,
    //        /* [in] */ POINTL pt,
    //        /* [out][in] */ DWORD *pdwEffect) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE DragOver( 
    //        /* [in] */ DWORD grfKeyState,
    //        /* [in] */ POINTL pt,
    //        /* [out][in] */ DWORD *pdwEffect) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE DragLeave( void) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE Drop( 
    //        /* [unique][in] */ IDataObject *pDataObj,
    //        /* [in] */ DWORD grfKeyState,
    //        /* [in] */ POINTL pt,
    //        /* [out][in] */ DWORD *pdwEffect) = 0;

    //};
    [ComVisible(true), ComImport(),
    Guid("00000122-0000-0000-C000-000000000046"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDropTarget
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int DragEnter(
            [In, MarshalAs(UnmanagedType.Interface)] System.Runtime.InteropServices.ComTypes.IDataObject pDataObj,
            [In, MarshalAs(UnmanagedType.U4)] uint grfKeyState,
            [In, MarshalAs(UnmanagedType.Struct)] tagPOINT pt,
            [In, Out, MarshalAs(UnmanagedType.U4)] ref uint pdwEffect);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int DragOver(
            [In, MarshalAs(UnmanagedType.U4)] uint grfKeyState,
            [In, MarshalAs(UnmanagedType.Struct)] tagPOINT pt,
            [In, Out, MarshalAs(UnmanagedType.U4)] ref uint pdwEffect);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int DragLeave();

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Drop(
            [In, MarshalAs(UnmanagedType.Interface)] System.Runtime.InteropServices.ComTypes.IDataObject pDataObj,
            [In, MarshalAs(UnmanagedType.U4)] uint grfKeyState,
            [In, MarshalAs(UnmanagedType.Struct)] tagPOINT pt,
            [In, Out, MarshalAs(UnmanagedType.U4)] ref uint pdwEffect);
    }
    #endregion

    #region IOleCommandTarget Interface
    //MIDL_INTERFACE("b722bccb-4e68-101b-a2bc-00aa00404770")
    //IOleCommandTarget : public IUnknown
    //{
    //public:
    //    virtual /* [input_sync] */ HRESULT STDMETHODCALLTYPE QueryStatus( 
    //        /* [unique][in] */ const GUID *pguidCmdGroup,
    //        /* [in] */ ULONG cCmds,
    //        /* [out][in][size_is] */ OLECMD prgCmds[  ],
    //        /* [unique][out][in] */ OLECMDTEXT *pCmdText) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE Exec( 
    //        /* [unique][in] */ const GUID *pguidCmdGroup,
    //        /* [in] */ DWORD nCmdID,
    //        /* [in] */ DWORD nCmdexecopt,
    //        /* [unique][in] */ VARIANT *pvaIn,
    //        /* [unique][out][in] */ VARIANT *pvaOut) = 0;

    //};
    [ComImport(), ComVisible(true),
    Guid("B722BCCB-4E68-101B-A2BC-00AA00404770"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleCommandTarget
    {

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int QueryStatus(
            [In] IntPtr pguidCmdGroup,
            [In, MarshalAs(UnmanagedType.U4)] uint cCmds,
            [In, Out, MarshalAs(UnmanagedType.Struct)] ref tagOLECMD prgCmds,
            //This parameter must be IntPtr, as it can be null
            [In, Out] IntPtr pCmdText);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Exec(
            //[In] ref Guid pguidCmdGroup,
            //have to be IntPtr, since null values are unacceptable
            //and null is used as default group!
            [In] IntPtr pguidCmdGroup,
            [In, MarshalAs(UnmanagedType.U4)] uint nCmdID,
            [In, MarshalAs(UnmanagedType.U4)] uint nCmdexecopt,
            [In] IntPtr pvaIn,
            [In, Out] IntPtr pvaOut);
    }
    #endregion

    #region IServiceProvider Interface
    //MIDL_INTERFACE("6d5140c1-7436-11ce-8034-00aa006009fa")
    //IServiceProvider : public IUnknown
    //{
    //public:
    //    virtual /* [local] */ HRESULT STDMETHODCALLTYPE QueryService( 
    //        /* [in] */ REFGUID guidService,
    //        /* [in] */ REFIID riid,
    //        /* [out] */ void __RPC_FAR *__RPC_FAR *ppvObject) = 0;

    //    template <class Q>
    //    HRESULT STDMETHODCALLTYPE QueryService(REFGUID guidService, Q** pp)
    //    {
    //        return QueryService(guidService, __uuidof(Q), (void **)pp);
    //    }
    //};
    [ComImport, ComVisible(true)]
    [Guid("6d5140c1-7436-11ce-8034-00aa006009fa")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IServiceProvider
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int QueryService(
            [In] ref Guid guidService,
            [In] ref Guid riid,
            [Out] out IntPtr ppvObject);
        //This does not work i.e.-> ppvObject = (INewWindowManager)this
        //[Out, MarshalAs(UnmanagedType.Interface)] out object ppvObject);
    }
    #endregion

    #region IPropertyNotifySink Interface
    //MIDL_INTERFACE("9BFBBC02-EFF1-101A-84ED-00AA00341D07")
    //IPropertyNotifySink : public IUnknown
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE OnChanged( 
    //        /* [in] */ DISPID dispID) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE OnRequestEdit( 
    //        /* [in] */ DISPID dispID) = 0;

    //};
    [ComImport, ComVisible(true),
    Guid("9BFBBC02-EFF1-101A-84ED-00AA00341D07"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPropertyNotifySink
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnChanged([In, MarshalAs(UnmanagedType.I4)] int dispID);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnRequestEdit([In, MarshalAs(UnmanagedType.I4)] int dispID);
    }
    #endregion

    #region IPersistStreamInit Interface
    //MIDL_INTERFACE("7FD52380-4E07-101B-AE2D-08002B2EC713")
    //IPersistStreamInit : public IPersist
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE IsDirty( void) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE Load( 
    //        /* [in] */ LPSTREAM pStm) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE Save( 
    //        /* [in] */ LPSTREAM pStm,
    //        /* [in] */ BOOL fClearDirty) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE GetSizeMax( 
    //        /* [out] */ ULARGE_INTEGER *pCbSize) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE InitNew( void) = 0;

    //};
    [ComVisible(true), ComImport(),
    Guid("7FD52380-4E07-101B-AE2D-08002B2EC713"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPersistStreamInit
    {
        void GetClassID(
            [In, Out] ref Guid pClassID);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int IsDirty();

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Load(
            [In, MarshalAs(UnmanagedType.Interface)] 
            System.Runtime.InteropServices.ComTypes.IStream pstm);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Save(
            [In, MarshalAs(UnmanagedType.Interface)]
            System.Runtime.InteropServices.ComTypes.IStream pstm,
            [In, MarshalAs(UnmanagedType.Bool)] bool fClearDirty);

        void GetSizeMax(
            [Out, MarshalAs(UnmanagedType.LPArray)] long pcbSize);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int InitNew();
    }
    #endregion

    #region IProtectFocus Interface - IE7+Vista
    [ComImport, ComVisible(true)]
    [Guid("D81F90A3-8156-44F7-AD28-5ABB87003274")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IProtectFocus
    {
        void AllowFocusChange([In, Out] ref bool pfAllow);
    } 
    #endregion

    #region DWebBrowserEvents Interface
    [ComImport, SuppressUnmanagedCodeSecurity,
    InterfaceType(ComInterfaceType.InterfaceIsIDispatch),
    Guid("EAB22AC2-30C1-11CF-A7EB-0000C05BAE0B"),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface DWebBrowserEvents
    {
        [DispId(100)]
        void BeforeNavigate(
            [In, MarshalAs(UnmanagedType.BStr)] string URL,
            int Flags, [MarshalAs(UnmanagedType.BStr)] string TargetFrameName,
            [MarshalAs(UnmanagedType.Struct)] ref object PostData,
            [MarshalAs(UnmanagedType.BStr)] string Headers, [In, Out] ref bool Cancel);
        [DispId(0x65)]
        void NavigateComplete([In, MarshalAs(UnmanagedType.BStr)] string URL);
        [DispId(0x66)]
        void StatusTextChange([In, MarshalAs(UnmanagedType.BStr)] string Text);
        [DispId(0x6c)]
        void ProgressChange([In] int Progress, [In] int ProgressMax);
        [DispId(0x68)]
        void DownloadComplete();
        [DispId(0x69)]
        void CommandStateChange([In] int Command, [In] bool Enable);
        [DispId(0x6a)]
        void DownloadBegin();
        [DispId(0x6b)]
        void NewWindow(
            [In, MarshalAs(UnmanagedType.BStr)] string URL,
            [In] int Flags, [In, MarshalAs(UnmanagedType.BStr)] string TargetFrameName,
            [In,MarshalAs(UnmanagedType.Struct)] ref object PostData, 
            [In, MarshalAs(UnmanagedType.BStr)] string Headers, 
            [In, Out] ref bool Processed);
        [DispId(0x71)]
        void TitleChange([In, MarshalAs(UnmanagedType.BStr)] string Text);
        [DispId(200)]
        void FrameBeforeNavigate(
            [In, MarshalAs(UnmanagedType.BStr)] string URL, int Flags, 
            [MarshalAs(UnmanagedType.BStr)] string TargetFrameName,
            [MarshalAs(UnmanagedType.Struct)] ref object PostData,
            [MarshalAs(UnmanagedType.BStr)] string Headers, 
            [In, Out] ref bool Cancel);
        [DispId(0xc9)]
        void FrameNavigateComplete([In, MarshalAs(UnmanagedType.BStr)] string URL);
        [DispId(0xcc)]
        void FrameNewWindow(
            [In, MarshalAs(UnmanagedType.BStr)] string URL, [In] int Flags, 
            [In, MarshalAs(UnmanagedType.BStr)] string TargetFrameName,
            [In, MarshalAs(UnmanagedType.Struct)] ref object PostData, 
            [In, MarshalAs(UnmanagedType.BStr)] string Headers, 
            [In, Out] ref bool Processed);
        [DispId(0x67)]
        void Quit([In, Out] ref bool Cancel);
        [DispId(0x6d)]
        void WindowMove();
        [DispId(110)]
        void WindowResize();
        [DispId(0x6f)]
        void WindowActivate();
        [DispId(0x70)]
        void PropertyChange([In, MarshalAs(UnmanagedType.BStr)] string Property);
    }

    #endregion

    #region DWebBrowserEvents2 Interface

    [ComImport, SuppressUnmanagedCodeSecurity,
    InterfaceType(ComInterfaceType.InterfaceIsIDispatch),
    Guid("34A715A0-6587-11D0-924A-0020AFC7AC4D")]
    public interface DWebBrowserEvents2
    {
        [DispId(0x66)]
        void StatusTextChange([MarshalAs(UnmanagedType.BStr)] string Text);
        [DispId(0x6c)] //108
        void ProgressChange(int Progress, int ProgressMax);
        [DispId(0x69)]
        void CommandStateChange(int Command, [MarshalAs(UnmanagedType.VariantBool)] bool Enable);
        [DispId(0x6a)]
        void DownloadBegin();
        [DispId(0x68)]
        void DownloadComplete();
        [DispId(0x71)]
        void TitleChange([MarshalAs(UnmanagedType.BStr)] string Text);
        [DispId(0x70)]
        void PropertyChange([MarshalAs(UnmanagedType.BStr)] string szProperty);
        [DispId(250)]
        void BeforeNavigate2([MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In] ref object URL, [In] ref object Flags, [In] ref object TargetFrameName, [In] ref object PostData, [In] ref object Headers, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Cancel);
        [DispId(0xfb)]
        void NewWindow2([In, Out, MarshalAs(UnmanagedType.IDispatch)] ref object ppDisp, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Cancel);
        [DispId(0xfc)]
        void NavigateComplete2([MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In] ref object URL);
        [DispId(0x103)]
        void DocumentComplete([MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In] ref object URL);
        [DispId(0xfd)]
        void OnQuit();
        [DispId(0xfe)]
        void OnVisible([MarshalAs(UnmanagedType.VariantBool)] bool Visible);
        [DispId(0xff)]
        void OnToolBar([MarshalAs(UnmanagedType.VariantBool)] bool ToolBar);
        [DispId(0x100)]
        void OnMenuBar([MarshalAs(UnmanagedType.VariantBool)] bool MenuBar);
        [DispId(0x101)]
        void OnStatusBar([MarshalAs(UnmanagedType.VariantBool)] bool StatusBar);
        [DispId(0x102)]
        void OnFullScreen([MarshalAs(UnmanagedType.VariantBool)] bool FullScreen);
        [DispId(260)]
        void OnTheaterMode([MarshalAs(UnmanagedType.VariantBool)] bool TheaterMode);
        [DispId(0x106)]
        void WindowSetResizable([MarshalAs(UnmanagedType.VariantBool)] bool Resizable);
        [DispId(0x108)]
        void WindowSetLeft(int Left);
        [DispId(0x109)]
        void WindowSetTop(int Top);
        [DispId(0x10a)]
        void WindowSetWidth(int Width);
        [DispId(0x10b)]
        void WindowSetHeight(int Height);
        [DispId(263)] //0x107
        void WindowClosing([MarshalAs(UnmanagedType.VariantBool)] bool IsChildWindow, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Cancel);
        [DispId(0x10c)]
        void ClientToHostWindow([In, Out] ref int CX, [In, Out] ref int CY);
        [DispId(0x10d)]
        void SetSecureLockIcon(int SecureLockIcon);
        [DispId(270)]
        void FileDownload([Out, MarshalAs(UnmanagedType.VariantBool)] bool ActiveDocument, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Cancel);
        [DispId(0x10f)]
        void NavigateError([MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In] ref object URL, [In] ref object Frame, [In] ref object StatusCode, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Cancel);
        [DispId(0xe1)]
        void PrintTemplateInstantiation([MarshalAs(UnmanagedType.IDispatch)] object pDisp);
        [DispId(0xe2)]
        void PrintTemplateTeardown([MarshalAs(UnmanagedType.IDispatch)] object pDisp);
        [DispId(0xe3)]
        void UpdatePageStatus([MarshalAs(UnmanagedType.IDispatch)] object pDisp, [In] ref object nPage, [In] ref object fDone);
        [DispId(0x110)]
        void PrivacyImpactedStateChange([MarshalAs(UnmanagedType.VariantBool)] bool bImpacted);
        [DispId(273)]
        void NewWindow3([In, Out, MarshalAs(UnmanagedType.IDispatch)] ref object ppDisp, [In, Out, MarshalAs(UnmanagedType.VariantBool)] ref bool Cancel, uint dwFlags, [MarshalAs(UnmanagedType.BStr)] string bstrUrlContext, [MarshalAs(UnmanagedType.BStr)] string bstrUrl);
    }

    #endregion

    #region IWindowForBindingUI Interface
    //MIDL_INTERFACE("79eac9d5-bafa-11ce-8c82-00aa004ba90b")
    //IWindowForBindingUI : public IUnknown
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE GetWindow( 
    //        /* [in] */ REFGUID rguidReason, [In] ref Guid rguidReason
    //        /* [out] */ HWND *phwnd) = 0;    
    //}
    //requested via IServiceProvider::QueryService
    [ComImport(), ComVisible(true),
    Guid("79eac9d5-bafa-11ce-8c82-00aa004ba90b"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IWindowForBindingUI
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetWindow(
            [In] ref Guid rguidReason,
            ref IntPtr phwnd);
    }
    #endregion

    #region IHttpSecurity Interface
    //MIDL_INTERFACE("79eac9d7-bafa-11ce-8c82-00aa004ba90b")
    //IHttpSecurity : public IWindowForBindingUI
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE OnSecurityProblem( 
    //        /* [in] */ DWORD dwProblem) = 0;
    //}
    //requested via IServiceProvider::QueryService
    [ComImport(), ComVisible(true),
    Guid("79eac9d7-bafa-11ce-8c82-00aa004ba90b"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IHttpSecurity
    {
        //IWindowForBindingUI
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetWindow(
            [In] ref Guid rguidReason,
            [In, Out] ref IntPtr phwnd);

        //IHttpSecurity
        //http://msdn.microsoft.com/library/default.asp?url=/workshop/networking/moniker/reference/ifaces/ihttpsecurity/onsecurityproblem.asp?frame=true
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnSecurityProblem(
            [In, MarshalAs(UnmanagedType.U4)] uint dwProblem);
        //dwProblem one of wininet error Messages
        //http://msdn.microsoft.com/library/default.asp?url=/library/en-us/wininet/wininet/wininet_errors.asp?frame=true
    }
    #endregion

    #region IPersistMoniker Interface
    //MIDL_INTERFACE("79eac9c9-baf9-11ce-8c82-00aa004ba90b")
    //IPersistMoniker : public IUnknown
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE GetClassID( 
    //        /* [out] */ CLSID *pClassID) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE IsDirty( void) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE Load( 
    //        /* [in] */ BOOL fFullyAvailable,
    //        /* [in] */ IMoniker *pimkName,
    //        /* [in] */ LPBC pibc,
    //        /* [in] */ DWORD grfMode) = 0; 
    //    virtual HRESULT STDMETHODCALLTYPE Save( 
    //        /* [in] */ IMoniker *pimkName,
    //        /* [in] */ LPBC pbc,
    //        /* [in] */ BOOL fRemember) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE SaveCompleted( 
    //        /* [in] */ IMoniker *pimkName,
    //        /* [in] */ LPBC pibc) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE GetCurMoniker( 
    //        /* [out] */ IMoniker **ppimkName) = 0;
    //}
    [ComImport, ComVisible(true),
    Guid("79eac9c9-baf9-11ce-8c82-00aa004ba90b"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IPersistMoniker
    {
        void GetClassID(
            [In, Out] ref Guid pClassID);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int IsDirty();

        void Load([In] int fFullyAvailable,
            [In, MarshalAs(UnmanagedType.Interface)] IMoniker pmk,
            [In, MarshalAs(UnmanagedType.Interface)] Object pbc,
            [In, MarshalAs(UnmanagedType.U4)] uint grfMode);

        void SaveCompleted(
            [In, MarshalAs(UnmanagedType.Interface)] IMoniker pmk,
            [In, MarshalAs(UnmanagedType.Interface)] Object pbc);

        [return: MarshalAs(UnmanagedType.Interface)]
        IMoniker GetCurMoniker();
    }
    #endregion

    #region INewWindowManager Interface

    //For popup blocking. Only for XP sp2 or higher
    //http://windowssdk.msdn.microsoft.com/library/default.asp?url=/library/en-us/shellcc/platform/shell/reference/ifaces/inewwindowmanager/evaluatenewwindow.asp
    //requested via IServiceProvider::QueryService
    [ComImport(), ComVisible(true),
    Guid("D2BC4C84-3F72-4a52-A604-7BCBF3982CBB"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface INewWindowManager
    {
        //MSDN documentation is wrong
        //First, this iface is declared in ShObjIdl.h??
        //Second, dwUserActionTime param is missing from MSDN????
        //HRESULT EvaluateNewWindow(
        //    LPCWSTR pszUrl,
        //    LPCWSTR pszName, //can be NULL
        //    LPCWSTR pszUrlContext,
        //    LPCWSTR pszFeatures, //can be NULL
        //    BOOL fReplace,
        //    DWORD dwFlags,
        //    DWORD dwUserActionTime
        //);
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int EvaluateNewWindow(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszUrl,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszName,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszUrlContext,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszFeatures,
            [In, MarshalAs(UnmanagedType.Bool)] bool fReplace,
            [In, MarshalAs(UnmanagedType.U4)] uint dwFlags, //NWMF flags
            [In, MarshalAs(UnmanagedType.U4)] uint dwUserActionTime);
    }

    #endregion

    #region IShellUIHelper Interface

    //MIDL_INTERFACE("729FE2F8-1EA8-11d1-8F85-00C04FC2FBE1")
    //IShellUIHelper : public IDispatch
    //{
    //public:
    //    virtual /* [id][hidden] */ HRESULT STDMETHODCALLTYPE ResetFirstBootMode( void) = 0;
    //    virtual /* [id][hidden] */ HRESULT STDMETHODCALLTYPE ResetSafeMode( void) = 0;
    //    virtual /* [id][hidden] */ HRESULT STDMETHODCALLTYPE RefreshOfflineDesktop( void) = 0;
    //    virtual /* [id] */ HRESULT STDMETHODCALLTYPE AddFavorite( 
    //        /* [in] */ BSTR URL,
    //        /* [in][optional] */ VARIANT *Title) = 0;
    //    virtual /* [id] */ HRESULT STDMETHODCALLTYPE AddChannel( 
    //        /* [in] */ BSTR URL) = 0;
    //    virtual /* [id] */ HRESULT STDMETHODCALLTYPE AddDesktopComponent( 
    //        /* [in] */ BSTR URL,
    //        /* [in] */ BSTR Type,
    //        /* [in][optional] */ VARIANT *Left,
    //        /* [in][optional] */ VARIANT *Top,
    //        /* [in][optional] */ VARIANT *Width,
    //        /* [in][optional] */ VARIANT *Height) = 0;
    //    virtual /* [id] */ HRESULT STDMETHODCALLTYPE IsSubscribed( 
    //        /* [in] */ BSTR URL,
    //        /* [retval][out] */ VARIANT_BOOL *pBool) = 0;
    //    virtual /* [id] */ HRESULT STDMETHODCALLTYPE NavigateAndFind( 
    //        /* [in] */ BSTR URL,
    //        /* [in] */ BSTR strQuery,
    //        /* [in] */ VARIANT *varTargetFrame) = 0;
    //    virtual /* [id] */ HRESULT STDMETHODCALLTYPE ImportExportFavorites( 
    //        /* [in] */ VARIANT_BOOL fImport,
    //        /* [in] */ BSTR strImpExpPath) = 0;
    //    virtual /* [id] */ HRESULT STDMETHODCALLTYPE AutoCompleteSaveForm( 
    //        /* [in][optional] */ VARIANT *Form) = 0;
    //    virtual /* [id] */ HRESULT STDMETHODCALLTYPE AutoScan( 
    //        /* [in] */ BSTR strSearch,
    //        /* [in] */ BSTR strFailureUrl,
    //        /* [in][optional] */ VARIANT *pvarTargetFrame) = 0;
    //    virtual /* [id][hidden] */ HRESULT STDMETHODCALLTYPE AutoCompleteAttach( 
    //        /* [in][optional] */ VARIANT *Reserved) = 0;
    //    virtual /* [id] */ HRESULT STDMETHODCALLTYPE ShowBrowserUI( 
    //        /* [in] */ BSTR bstrName,
    //        /* [in] */ VARIANT *pvarIn,
    //        /* [retval][out] */ VARIANT *pvarOut) = 0;
    //}ComImport, 
    [ComVisible(false),
    Guid("729FE2F8-1EA8-11d1-8F85-00C04FC2FBE1"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IShellUIHelper
    {
        [DispId(1)]
        void ResetFirstBootMode(); //[hidden]
        [DispId(2)]
        void ResetSafeMode(); //[hidden]
        [DispId(3)]
        void RefreshOfflineDesktop(); //[hidden]

        [DispId(4)]
        void AddFavorite(
            [In, MarshalAs(UnmanagedType.BStr)] string URL,
            [In] object Title);

        [DispId(5)]
        void AddChannel(
            [In, MarshalAs(UnmanagedType.BStr)] string URL);

        [DispId(6)]
        void AddDesktopComponent(
            [In, MarshalAs(UnmanagedType.BStr)] string URL,
            [In, MarshalAs(UnmanagedType.BStr)] string Type,
            [In] ref object Left, [In] ref object Top,
            [In] ref object Width, [In] ref object Height);

        [DispId(7)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool IsSubscribed(
            [In, MarshalAs(UnmanagedType.BStr)] string URL);

        [DispId(8)]
        void NavigateAndFind(
            [In, MarshalAs(UnmanagedType.BStr)] string URL,
            [In, MarshalAs(UnmanagedType.BStr)] string strQuery,
            ref object varTargetFrame);

        [DispId(9)]
        void ImportExportFavorites(
            [In, MarshalAs(UnmanagedType.VariantBool)] bool fImport,
            [In, MarshalAs(UnmanagedType.BStr)] string strImpExpPath);

        [DispId(10)]
        void AutoCompleteSaveForm(ref object Form);

        [DispId(11)]
        void AutoScan(
            [In, MarshalAs(UnmanagedType.BStr)] string strSearch,
            [In, MarshalAs(UnmanagedType.BStr)] string strFailureUrl,
            [In, Optional] ref object pvarTargetFrame);

        [DispId(12)]
        void AutoCompleteAttach(ref object Reserved);  //[hidden]

        [DispId(13)]
        object ShowBrowserUI(
            [In, MarshalAs(UnmanagedType.BStr)] string bstrName,
            [In] ref object pvarIn);
    }
    #endregion

    #region IAuthenticate Interface
    //MIDL_INTERFACE("79eac9d0-baf9-11ce-8c82-00aa004ba90b")
    //IAuthenticate : public IUnknown
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE Authenticate( 
    //        /* [out] */ HWND *phwnd,
    //        /* [out] */ LPWSTR *pszUsername,
    //        /* [out] */ LPWSTR *pszPassword) = 0;
    //}
    [ComVisible(true), ComImport()]
    [GuidAttribute("79eac9d0-baf9-11ce-8c82-00aa004ba90b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IAuthenticate
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Authenticate(
            ref IntPtr phwnd,
            //or [Out, MarshalAs(UnmanagedType.LPWStr)] out string
            ref IntPtr pszUsername,
            ref IntPtr pszPassword);
    }
    #endregion

    #region IInternetSecurityManager Interface
    [ComVisible(true), ComImport,
    GuidAttribute("79EAC9EE-BAF9-11CE-8C82-00AA004BA90B"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IInternetSecurityManager
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetSecuritySite(
            [In] IntPtr pSite);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetSecuritySite(
            out IntPtr pSite);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int MapUrlToZone(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszUrl,
            out UInt32 pdwZone,
            [In] UInt32 dwFlags);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetSecurityId(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszUrl,
            [Out] IntPtr pbSecurityId, [In, Out] ref UInt32 pcbSecurityId,
            [In] ref UInt32 dwReserved);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ProcessUrlAction(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszUrl,
            UInt32 dwAction,
            IntPtr pPolicy, UInt32 cbPolicy,
            IntPtr pContext, UInt32 cbContext,
            UInt32 dwFlags,
            UInt32 dwReserved);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int QueryCustomPolicy(
            [In, MarshalAs(UnmanagedType.LPWStr)] string pwszUrl,
            ref Guid guidKey,
            out IntPtr ppPolicy, out UInt32 pcbPolicy,
            IntPtr pContext, UInt32 cbContext,
            UInt32 dwReserved);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetZoneMapping(
            UInt32 dwZone,
            [In, MarshalAs(UnmanagedType.LPWStr)] string lpszPattern,
            UInt32 dwFlags);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetZoneMappings(
            [In] UInt32 dwZone,
            out IEnumString ppenumString,
            [In] UInt32 dwFlags);
    }
    #endregion

    #region IViewObject Interface

    //MIDL_INTERFACE("0000010d-0000-0000-C000-000000000046")
    //IViewObject : public IUnknown
    //{
    //public:
    //    virtual /* [local] */ HRESULT STDMETHODCALLTYPE Draw( 
    //        /* [in] */ DWORD dwDrawAspect,
    //        /* [in] */ LONG lindex,
    //        /* [unique][in] */ void *pvAspect,
    //        /* [unique][in] */ DVTARGETDEVICE *ptd,
    //        /* [in] */ HDC hdcTargetDev,
    //        /* [in] */ HDC hdcDraw,
    //        /* [in] */ LPCRECTL lprcBounds,
    //        /* [unique][in] */ LPCRECTL lprcWBounds,
    //        /* [in] */ BOOL ( STDMETHODCALLTYPE *pfnContinue )( 
    //            ULONG_PTR dwContinue),
    //        /* [in] */ ULONG_PTR dwContinue) = 0;

    //    virtual /* [local] */ HRESULT STDMETHODCALLTYPE GetColorSet( 
    //        /* [in] */ DWORD dwDrawAspect,
    //        /* [in] */ LONG lindex,
    //        /* [unique][in] */ void *pvAspect,
    //        /* [unique][in] */ DVTARGETDEVICE *ptd,
    //        /* [in] */ HDC hicTargetDev,
    //        /* [out] */ LOGPALETTE **ppColorSet) = 0;

    //    virtual /* [local] */ HRESULT STDMETHODCALLTYPE Freeze( 
    //        /* [in] */ DWORD dwDrawAspect,
    //        /* [in] */ LONG lindex,
    //        /* [unique][in] */ void *pvAspect,
    //        /* [out] */ DWORD *pdwFreeze) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE Unfreeze( 
    //        /* [in] */ DWORD dwFreeze) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE SetAdvise( 
    //        /* [in] */ DWORD aspects,
    //        /* [in] */ DWORD advf,
    //        /* [unique][in] */ IAdviseSink *pAdvSink) = 0;

    //    virtual /* [local] */ HRESULT STDMETHODCALLTYPE GetAdvise( 
    //        /* [unique][out] */ DWORD *pAspects,
    //        /* [unique][out] */ DWORD *pAdvf,
    //        /* [out] */ IAdviseSink **ppAdvSink) = 0;

    //}
    [ComVisible(true), ComImport()]
    [GuidAttribute("0000010d-0000-0000-C000-000000000046")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IViewObject
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Draw(
            //tagDVASPECT
            [MarshalAs(UnmanagedType.U4)] UInt32 dwDrawAspect,
            int lindex,
            IntPtr pvAspect,
            [In] IntPtr ptd,
            //[MarshalAs(UnmanagedType.Struct)] ref DVTARGETDEVICE ptd,
            IntPtr hdcTargetDev,
            IntPtr hdcDraw,
            [MarshalAs(UnmanagedType.Struct)] ref tagRECT lprcBounds,
            [MarshalAs(UnmanagedType.Struct)] ref tagRECT lprcWBounds,
            IntPtr pfnContinue,
            [MarshalAs(UnmanagedType.U4)] UInt32 dwContinue);

        void GetColorSet(
            [MarshalAs(UnmanagedType.U4)] UInt32 dwDrawAspect,
            int lindex,
            IntPtr pvAspect,
            [MarshalAs(UnmanagedType.Struct)] DVTARGETDEVICE ptd,
            IntPtr hicTargetDev,
            [Out, MarshalAs(UnmanagedType.Struct)] out tagLOGPALETTE ppColorSet);

        void Freeze(
            [MarshalAs(UnmanagedType.U4)] UInt32 dwDrawAspect,
            int lindex,
            IntPtr pvAspect,
            out IntPtr pdwFreeze);

        void Unfreeze(
            [MarshalAs(UnmanagedType.U4)] int dwFreeze);

        void SetAdvise
            ([MarshalAs(UnmanagedType.U4)] int aspects,
            [MarshalAs(UnmanagedType.U4)] int advf,
            [MarshalAs(UnmanagedType.Interface)] IAdviseSink pAdvSink);

        void GetAdvise(
            IntPtr paspects,
            IntPtr advf,
            [Out, MarshalAs(UnmanagedType.Interface)] out IAdviseSink pAdvSink);
    }
    #endregion

    #region IClassFactory Interface
    [ComVisible(true), ComImport(),
    Guid("00000001-0000-0000-C000-000000000046"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IClassFactory
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int CreateInstance(
            [In, MarshalAs(UnmanagedType.Interface)] object pUnkOuter,
            ref Guid riid,
            [Out, MarshalAs(UnmanagedType.Interface)] out object obj);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int LockServer(
            [In] bool fLock);
    }
    #endregion

    #region IBinding Interface
    //MIDL_INTERFACE("79eac9c0-baf9-11ce-8c82-00aa004ba90b")
    //IBinding : public IUnknown
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE Abort( void) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE Suspend( void) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE Resume( void) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE SetPriority( 
    //        /* [in] */ LONG nPriority) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE GetPriority( 
    //        /* [out] */ LONG *pnPriority) = 0;
    //    virtual /* [local] */ HRESULT STDMETHODCALLTYPE GetBindResult( 
    //        /* [out] */ CLSID *pclsidProtocol,
    //        /* [out] */ DWORD *pdwResult,
    //        /* [out] */ LPOLESTR *pszResult,
    //        /* [out][in] */ DWORD *pdwReserved) = 0;
    //}
    [ComImport(), ComVisible(true),
    Guid("79EAC9C0-BAF9-11CE-8C82-00AA004BA90B"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IBinding
    {
        void Abort();
        void Suspend();
        void Resume();
        void SetPriority([In] int nPriority);
        void GetPriority(out int pnPriority);
        void GetBindResult(out Guid pclsidProtocol,
             out uint pdwResult,
            [MarshalAs(UnmanagedType.LPWStr)] out string pszResult,
            [In, Out] ref uint dwReserved);
    }
    #endregion

    #region IDownloadManager Interface
    //MIDL_INTERFACE("988934A4-064B-11D3-BB80-00104B35E7F9")
    //IDownloadManager : public IUnknown
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE Download( 
    //        /* [in] */ IMoniker *pmk,
    //        /* [in] */ IBindCtx *pbc,
    //        /* [in] */ DWORD dwBindVerb,
    //        /* [in] */ LONG grfBINDF,
    //        /* [in] */ BINDINFO *pBindInfo,
    //        /* [in] */ LPCOLESTR pszHeaders,
    //        /* [in] */ LPCOLESTR pszRedir,
    //        /* [in] */ UINT uiCP) = 0;
    //}
    [ComVisible(true), ComImport]
    [Guid("988934A4-064B-11D3-BB80-00104B35E7F9")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDownloadManager
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Download(
            [In, MarshalAs(UnmanagedType.Interface)] IMoniker pmk,
            [In, MarshalAs(UnmanagedType.Interface)] IBindCtx pbc,
            [In, MarshalAs(UnmanagedType.U4)] UInt32 dwBindVerb,
            [In] int grfBINDF,
            [In, MarshalAs(UnmanagedType.Struct)] ref BINDINFO pBindInfo,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszHeaders,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszRedir,
            [In, MarshalAs(UnmanagedType.U4)] uint uiCP);
    }
    #endregion

    #region IBindStatusCallback Interface
    [ComImport, ComVisible(true),
    Guid("79EAC9C1-BAF9-11CE-8C82-00AA004BA90B"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IBindStatusCallback
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnStartBinding(
            [In] uint dwReserved,
            [In, MarshalAs(UnmanagedType.Interface)] IBinding pib);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetPriority(out int pnPriority);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnLowResource([In] uint reserved);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnProgress(
            [In] uint ulProgress,
            [In] uint ulProgressMax,
            //[In] BINDSTATUS ulStatusCode,
            [In, MarshalAs(UnmanagedType.U4)] uint ulStatusCode,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szStatusText);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnStopBinding(
            [In, MarshalAs(UnmanagedType.Error)] uint hresult,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szError);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetBindInfo(
            //out BINDF grfBINDF,
            [In, Out, MarshalAs(UnmanagedType.U4)] ref uint grfBINDF,
            [In, Out, MarshalAs(UnmanagedType.Struct)] ref BINDINFO pbindinfo);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnDataAvailable(
            [In, MarshalAs(UnmanagedType.U4)] uint grfBSCF,
            [In, MarshalAs(UnmanagedType.U4)] uint dwSize,
            [In, MarshalAs(UnmanagedType.Struct)] ref FORMATETC pFormatetc,
            [In, MarshalAs(UnmanagedType.Struct)] ref STGMEDIUM pStgmed);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnObjectAvailable(
            [In] ref Guid riid,
            [In, MarshalAs(UnmanagedType.IUnknown)] object punk);
    }
    #endregion

    #region IUniformResourceLocatorA Interface
    [ComVisible(true), ComImport()]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("FBF23B80-E3F0-101B-8488-00AA003E56F8")]
    public interface IUniformResourceLocatorA
    {
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int SetURL([In, MarshalAs(UnmanagedType.LPStr)] string pcszURL, [In] uint dwInFlags);

        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int GetURL(out IntPtr ppszURL);

        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int InvokeCommand([In, MarshalAs(UnmanagedType.LPStruct)] ref URLINVOKECOMMANDINFOA purlici);
    }
    #endregion

    #region IUniformResourceLocatorW Interface
    [ComVisible(true), ComImport()]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("CABB0DA0-DA57-11CF-9974-0020AFD79762")]
    public interface IUniformResourceLocatorW
    {
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int SetURL([In, MarshalAs(UnmanagedType.LPWStr)] string pcszURL, [In] uint dwInFlags);

        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int GetURL(out IntPtr ppszURL);

        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int InvokeCommand([In, MarshalAs(UnmanagedType.LPStruct)] ref URLINVOKECOMMANDINFOW purlici);
    }
    #endregion

    #region IShellLinkA Interface
    [ComVisible(true), ComImport(),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
    Guid("000214EE-0000-0000-C000-000000000046")]
    public interface IShellLinkA
    {
        /// <summary>Retrieves the path and file name of a Shell link object</summary>
        int GetPath([Out, MarshalAs(UnmanagedType.LPStr)] StringBuilder pszFile, int cchMaxPath, out WIN32_FIND_DATAA pfd, SLGP_FLAGS fFlags);
        /// <summary>Retrieves the list of item identifiers for a Shell link object</summary>
        int GetIDList(out IntPtr ppidl);
        /// <summary>Sets the pointer to an item identifier list (PIDL) for a Shell link object</summary>
        int SetIDList(IntPtr pidl);
        /// <summary>Retrieves the description string for a Shell link object</summary>
        int GetDescription([Out(), MarshalAs(UnmanagedType.LPStr)] StringBuilder pszName, int cchMaxName);
        /// <summary>Sets the description for a Shell link object. The description can be any application-defined string</summary>
        int SetDescription([MarshalAs(UnmanagedType.LPStr)] string pszName);
        /// <summary>Retrieves the name of the working directory for a Shell link object</summary>
        int GetWorkingDirectory([Out(), MarshalAs(UnmanagedType.LPStr)] StringBuilder pszDir, int cchMaxPath);
        /// <summary>Sets the name of the working directory for a Shell link object</summary>
        int SetWorkingDirectory([MarshalAs(UnmanagedType.LPStr)] string pszDir);
        /// <summary>Retrieves the command-line arguments associated with a Shell link object</summary>
        int GetArguments([Out(), MarshalAs(UnmanagedType.LPStr)] StringBuilder pszArgs, int cchMaxPath);
        /// <summary>Sets the command-line arguments for a Shell link object</summary>
        int SetArguments([MarshalAs(UnmanagedType.LPStr)] string pszArgs);
        /// <summary>Retrieves the hot key for a Shell link object</summary>
        int GetHotkey(out short pwHotkey);
        /// <summary>Sets a hot key for a Shell link object</summary>
        int SetHotkey(short wHotkey);
        /// <summary>Retrieves the show command for a Shell link object</summary>
        int GetShowCmd(out int piShowCmd);
        /// <summary>Sets the show command for a Shell link object. The show command sets the initial show state of the window.</summary>
        int SetShowCmd(int iShowCmd);
        /// <summary>Retrieves the location (path and index) of the icon for a Shell link object</summary>
        int GetIconLocation([Out(), MarshalAs(UnmanagedType.LPStr)] StringBuilder pszIconPath
            , int cchIconPath, out int piIcon);
        /// <summary>Sets the location (path and index) of the icon for a Shell link object</summary>
        int SetIconLocation([MarshalAs(UnmanagedType.LPStr)] string pszIconPath, int iIcon);
        /// <summary>Sets the relative path to the Shell link object</summary>
        int SetRelativePath([MarshalAs(UnmanagedType.LPStr)] string pszPathRel, int dwReserved);
        /// <summary>Attempts to find the target of a Shell link, even if it has been moved or renamed</summary>
        int Resolve(IntPtr hwnd, SLR_FLAGS fFlags);
        /// <summary>Sets the path and file name of a Shell link object</summary>
        int SetPath([MarshalAs(UnmanagedType.LPStr)] string pszFile);
    }
    #endregion

    #region IShellLinkW Interface
    [ComVisible(true), ComImport(),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
    Guid("000214F9-0000-0000-C000-000000000046")]
    public interface IShellLinkW
    {
        /// <summary>Retrieves the path and file name of a Shell link object</summary>
        int GetPath([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile, int cchMaxPath, out WIN32_FIND_DATAW pfd, SLGP_FLAGS fFlags);
        /// <summary>Retrieves the list of item identifiers for a Shell link object</summary>
        int GetIDList(out IntPtr ppidl);
        /// <summary>Sets the pointer to an item identifier list (PIDL) for a Shell link object.</summary>
        int SetIDList(IntPtr pidl);
        /// <summary>Retrieves the description string for a Shell link object</summary>
        int GetDescription([Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszName, int cchMaxName);
        /// <summary>Sets the description for a Shell link object. The description can be any application-defined string</summary>
        int SetDescription([MarshalAs(UnmanagedType.LPWStr)] string pszName);
        /// <summary>Retrieves the name of the working directory for a Shell link object</summary>
        int GetWorkingDirectory([Out(), MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDir, int cchMaxPath);
        /// <summary>Sets the name of the working directory for a Shell link object</summary>
        int SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string pszDir);
        /// <summary>Retrieves the command-line arguments associated with a Shell link object</summary>
        int GetArguments([Out(), MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszArgs, int cchMaxPath);
        /// <summary>Sets the command-line arguments for a Shell link object</summary>
        int SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);
        /// <summary>Retrieves the hot key for a Shell link object</summary>
        int GetHotkey(out short pwHotkey);
        /// <summary>Sets a hot key for a Shell link object</summary>
        int SetHotkey(short wHotkey);
        /// <summary>Retrieves the show command for a Shell link object</summary>
        int GetShowCmd(out int piShowCmd);
        /// <summary>Sets the show command for a Shell link object. The show command sets the initial show state of the window.</summary>
        int SetShowCmd(int iShowCmd);
        /// <summary>Retrieves the location (path and index) of the icon for a Shell link object</summary>
        int GetIconLocation([Out(), MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszIconPath,
            int cchIconPath, out int piIcon);
        /// <summary>Sets the location (path and index) of the icon for a Shell link object</summary>
        int SetIconLocation([MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, int iIcon);
        /// <summary>Sets the relative path to the Shell link object</summary>
        int SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, int dwReserved);
        /// <summary>Attempts to find the target of a Shell link, even if it has been moved or renamed</summary>
        int Resolve(IntPtr hwnd, SLR_FLAGS fFlags);
        /// <summary>Sets the path and file name of a Shell link object</summary>
        int SetPath([MarshalAs(UnmanagedType.LPWStr)] string pszFile);
    }
    #endregion

    #region ShellLink Class
    [ComImport(), Guid("00021401-0000-0000-C000-000000000046")]
    public class ShellLink  // : IPersistFile, IShellLinkA, IShellLinkW 
    {
    } 
    #endregion

    #region IMalloc Interface

    [ComVisible(true), ComImport()]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("00000002-0000-0000-C000-000000000046")]
    public interface IMalloc
    {
        // Allocate a block of memory
        // Return value: a pointer to the allocated memory block.
        [PreserveSig]
        IntPtr Alloc(UInt32 cb); // Size, in bytes, of the memory block to be allocated.

        // Changes the size of a previously allocated memory block.
        // Return value: reallocated memory block
        [PreserveSig]
        IntPtr Realloc(
            IntPtr pv,  // Pointer to the memory block to be reallocated
            UInt32 cb); // Size of the memory block, in bytes, to be 
        // reallocated.

        // Free a previously allocated block of memory.
        [PreserveSig]
        void Free(IntPtr pv); // Pointer to the memory block to be freed.

        // This method returns the size, in bytes, of a memory block 
        // previously
        // allocated with IMalloc::Alloc or IMalloc::Realloc.
        // Return value: The size of the allocated memory block in bytes.
        [PreserveSig]
        UInt32 GetSize(IntPtr pv); // Pointer to the memory block for which the size is  requested.

        // This method determines whether this allocator was used to allocate
        // the specified block of memory.
        // Return value: 1 - allocated 0 - not allocated by this IMalloc Instance.
        [PreserveSig]
        Int16 DidAlloc(IntPtr pv); // Pointer to the memory block

        // Minimizes the heap by releasing unused memory to the operating system.
        [PreserveSig]
        void HeapMinimize();
    }

    #endregion

    #region IHTMLOMWindowServices Interface
    [ComVisible(true), ComImport()]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("3050f5fc-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLOMWindowServices
    {
        void moveTo([In] int x, [In] int y);
        void moveBy([In] int x, [In] int y);
        void resizeTo([In] int x, [In] int y);
        void resizeBy([In] int x, [In] int y);
    } 
    #endregion

    #region Misc Interfaces
    //[ComVisible(true), ComImport()]
    //[GuidAttribute("3050f6d0-98b5-11cf-bb82-00aa00bdce0b")]
    //public interface IDocHostUIHandler2 //: IDocHostUIHandler
    //{
    //    void GetOverrideKeyPath(
    //        [Out, MarshalAs(UnmanagedType.LPWStr)] out String pchKey,
    //        [MarshalAs(UnmanagedType.U4)] uint dw);
    //}

    #endregion
}