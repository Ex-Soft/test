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
    #region IOleContainer Interface
    //MIDL_INTERFACE("0000011b-0000-0000-C000-000000000046")
    //IOleContainer : public IParseDisplayName
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE EnumObjects( 
    //        /* [in] */ DWORD grfFlags,
    //        /* [out] */ IEnumUnknown **ppenum) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE LockContainer( 
    //        /* [in] */ BOOL fLock) = 0;

    //};
    [ComImport(), ComVisible(true),
    Guid("0000011B-0000-0000-C000-000000000046"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleContainer
    {
        //IParseDisplayName
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ParseDisplayName(
            [In, MarshalAs(UnmanagedType.Interface)] object pbc,
            [In, MarshalAs(UnmanagedType.BStr)]      string pszDisplayName,
            [Out, MarshalAs(UnmanagedType.LPArray)] int[] pchEaten,
            [Out, MarshalAs(UnmanagedType.LPArray)] object[] ppmkOut);

        //IOleContainer
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int EnumObjects(
            [In, MarshalAs(UnmanagedType.U4)] tagOLECONTF grfFlags,
            out IEnumUnknown ppenum);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int LockContainer(
            [In, MarshalAs(UnmanagedType.Bool)] Boolean fLock);
    }
    #endregion

    #region IOleWindow Interface
    //MIDL_INTERFACE("00000114-0000-0000-C000-000000000046")
    //IOleWindow : public IUnknown
    //{
    //public:
    //    virtual /* [input_sync] */ HRESULT STDMETHODCALLTYPE GetWindow( 
    //        /* [out] */ HWND *phwnd) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE ContextSensitiveHelp( 
    //        /* [in] */ BOOL fEnterMode) = 0;

    //};

    [ComImport, ComVisible(true)]
    [Guid("00000114-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleWindow
    {
        //IOleWindow
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetWindow([In, Out] ref IntPtr phwnd);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ContextSensitiveHelp([In, MarshalAs(UnmanagedType.Bool)] bool
            fEnterMode);
    }
    #endregion

    #region IOleInPlaceUIWindow Interface
    //MIDL_INTERFACE("00000115-0000-0000-C000-000000000046")
    //IOleInPlaceUIWindow : public IOleWindow
    //{
    //public:
    //    virtual /* [input_sync] */ HRESULT STDMETHODCALLTYPE GetBorder( 
    //        /* [out] */ LPRECT lprectBorder) = 0;

    //    virtual /* [input_sync] */ HRESULT STDMETHODCALLTYPE RequestBorderSpace( 
    //        /* [unique][in] */ LPCBORDERWIDTHS pborderwidths) = 0;

    //    virtual /* [input_sync] */ HRESULT STDMETHODCALLTYPE SetBorderSpace( 
    //        /* [unique][in] */ LPCBORDERWIDTHS pborderwidths) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE SetActiveObject( 
    //        /* [unique][in] */ IOleInPlaceActiveObject *pActiveObject,
    //        /* [unique][string][in] */ LPCOLESTR pszObjName) = 0;

    //};

    [ComVisible(true), ComImport(), Guid("00000115-0000-0000-C000-000000000046"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleInPlaceUIWindow
    {
        //IOleWindow
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetWindow([In, Out] ref IntPtr phwnd);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ContextSensitiveHelp([In, MarshalAs(UnmanagedType.Bool)] bool fEnterMode);

        //IOleInPlaceUIWindow
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetBorder([In, Out, MarshalAs(UnmanagedType.Struct)] ref tagRECT lprectBorder);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int RequestBorderSpace([In, MarshalAs(UnmanagedType.Struct)] ref tagRECT pborderwidths);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetBorderSpace([In, MarshalAs(UnmanagedType.Struct)] ref tagRECT pborderwidths);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetActiveObject(
            [In, MarshalAs(UnmanagedType.Interface)]
                ref IOleInPlaceActiveObject pActiveObject,
            [In, MarshalAs(UnmanagedType.LPWStr)]
                string pszObjName);
    }
    #endregion

    #region IOleInPlaceActiveObject Interface
    //MIDL_INTERFACE("00000117-0000-0000-C000-000000000046")
    //IOleInPlaceActiveObject : public IOleWindow
    //{
    //public:
    //    virtual /* [local] */ HRESULT STDMETHODCALLTYPE TranslateAccelerator( 
    //        /* [in] */ LPMSG lpmsg) = 0;  
    //    virtual /* [input_sync] */ HRESULT STDMETHODCALLTYPE OnFrameWindowActivate( 
    //        /* [in] */ BOOL fActivate) = 0;  
    //    virtual /* [input_sync] */ HRESULT STDMETHODCALLTYPE OnDocWindowActivate( 
    //        /* [in] */ BOOL fActivate) = 0; 
    //    virtual /* [local] */ HRESULT STDMETHODCALLTYPE ResizeBorder( 
    //        /* [in] */ LPCRECT prcBorder,
    //        /* [unique][in] */ IOleInPlaceUIWindow *pUIWindow,
    //        /* [in] */ BOOL fFrameWindow) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE EnableModeless( 
    //        /* [in] */ BOOL fEnable) = 0;
    //};
    [ComVisible(true), ComImport(), Guid("00000117-0000-0000-C000-000000000046"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleInPlaceActiveObject
    {
        //IOleWindow
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetWindow([In, Out] ref IntPtr phwnd);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ContextSensitiveHelp([In, MarshalAs(UnmanagedType.Bool)] bool
            fEnterMode);

        //IOleInPlaceActiveObject
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int TranslateAccelerator(
            [In, MarshalAs(UnmanagedType.Struct)] ref  tagMSG lpmsg);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnFrameWindowActivate(
            [In, MarshalAs(UnmanagedType.Bool)] bool fActivate);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnDocWindowActivate(
            [In, MarshalAs(UnmanagedType.Bool)] bool fActivate);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ResizeBorder(
            [In, MarshalAs(UnmanagedType.Struct)] ref tagRECT prcBorder,
            [In, MarshalAs(UnmanagedType.Interface)] ref IOleInPlaceUIWindow pUIWindow,
            [In, MarshalAs(UnmanagedType.Bool)] bool fFrameWindow);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int EnableModeless(
            [In, MarshalAs(UnmanagedType.Bool)] bool fEnable);
    }
    #endregion

    #region IOleInPlaceFrame Interface

    //MIDL_INTERFACE("00000116-0000-0000-C000-000000000046")
    //IOleInPlaceFrame : public IOleInPlaceUIWindow
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE InsertMenus( 
    //        /* [in] */ HMENU hmenuShared,
    //        /* [out][in] */ LPOLEMENUGROUPWIDTHS lpMenuWidths) = 0;

    //    virtual /* [input_sync] */ HRESULT STDMETHODCALLTYPE SetMenu( 
    //        /* [in] */ HMENU hmenuShared,
    //        /* [in] */ HOLEMENU holemenu,
    //        /* [in] */ HWND hwndActiveObject) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE RemoveMenus( 
    //        /* [in] */ HMENU hmenuShared) = 0;

    //    virtual /* [input_sync] */ HRESULT STDMETHODCALLTYPE SetStatusText( 
    //        /* [unique][in] */ LPCOLESTR pszStatusText) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE EnableModeless( 
    //        /* [in] */ BOOL fEnable) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE TranslateAccelerator( 
    //        /* [in] */ LPMSG lpmsg,
    //        /* [in] */ WORD wID) = 0;

    //};
    [ComVisible(true), ComImport(), Guid("00000116-0000-0000-C000-000000000046"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleInPlaceFrame
    {
        //IOleWindow
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetWindow([In, Out] ref IntPtr phwnd);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ContextSensitiveHelp([In, MarshalAs(UnmanagedType.Bool)] bool fEnterMode);

        //IOleInPlaceUIWindow
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetBorder(
            [Out, MarshalAs(UnmanagedType.LPStruct)] tagRECT lprectBorder);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int RequestBorderSpace([In, MarshalAs(UnmanagedType.Struct)] ref tagRECT pborderwidths);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetBorderSpace([In, MarshalAs(UnmanagedType.Struct)] ref tagRECT pborderwidths);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetActiveObject(
            [In, MarshalAs(UnmanagedType.Interface)] ref IOleInPlaceActiveObject pActiveObject,
            [In, MarshalAs(UnmanagedType.LPWStr)] string pszObjName);

        //IOleInPlaceFrame 
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int InsertMenus([In] IntPtr hmenuShared,
           [In, Out, MarshalAs(UnmanagedType.Struct)] ref object lpMenuWidths);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetMenu(
            [In] IntPtr hmenuShared,
            [In] IntPtr holemenu,
            [In] IntPtr hwndActiveObject);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int RemoveMenus([In] IntPtr hmenuShared);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetStatusText([In, MarshalAs(UnmanagedType.LPWStr)] string pszStatusText);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int EnableModeless([In, MarshalAs(UnmanagedType.Bool)] bool fEnable);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int TranslateAccelerator(
            [In, MarshalAs(UnmanagedType.Struct)] ref tagMSG lpmsg,
            [In, MarshalAs(UnmanagedType.U2)] short wID);
    }
    #endregion

    #region IOleInPlaceSite Interface
    //MIDL_INTERFACE("00000119-0000-0000-C000-000000000046")
    //IOleInPlaceSite : public IOleWindow
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE CanInPlaceActivate( void) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE OnInPlaceActivate( void) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE OnUIActivate( void) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE GetWindowContext( 
    //        /* [out] */ IOleInPlaceFrame **ppFrame,
    //        /* [out] */ IOleInPlaceUIWindow **ppDoc,
    //        /* [out] */ LPRECT lprcPosRect,
    //        /* [out] */ LPRECT lprcClipRect,
    //        /* [out][in] */ LPOLEINPLACEFRAMEINFO lpFrameInfo) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE Scroll( 
    //        /* [in] */ SIZE scrollExtant) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE OnUIDeactivate( 
    //        /* [in] */ BOOL fUndoable) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE OnInPlaceDeactivate( void) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE DiscardUndoState( void) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE DeactivateAndUndo( void) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE OnPosRectChange( 
    //        /* [in] */ LPCRECT lprcPosRect) = 0;
    //};
    [ComVisible(true), ComImport(), Guid("00000119-0000-0000-C000-000000000046"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleInPlaceSite
    {
        //IOleWindow
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetWindow([In, Out] ref IntPtr phwnd);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ContextSensitiveHelp([In, MarshalAs(UnmanagedType.Bool)] bool
            fEnterMode);

        //IOleInPlaceSite
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int CanInPlaceActivate();

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnInPlaceActivate();

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnUIActivate();

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetWindowContext(
           [Out, MarshalAs(UnmanagedType.Interface)]
                out IOleInPlaceFrame ppFrame,
           [Out, MarshalAs(UnmanagedType.Interface)]
                out IOleInPlaceUIWindow ppDoc,
            //[Out, MarshalAs(UnmanagedType.LPStruct)]
            //     object lprcPosRect,
            //[Out, MarshalAs(UnmanagedType.LPStruct)]
            //     object lprcClipRect,
            //[Out, MarshalAs(UnmanagedType.LPStruct)]
            //     object lpFrameInfo);
          [In, Out, MarshalAs(UnmanagedType.Struct)] ref tagRECT lprcPosRect,
          [In, Out, MarshalAs(UnmanagedType.Struct)] ref tagRECT lprcClipRect,
          [In, Out, MarshalAs(UnmanagedType.Struct)] ref tagOIFI lpFrameInfo);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Scroll([In, MarshalAs(UnmanagedType.Struct)] ref tagSIZE scrollExtent);
        //int Scroll([In, MarshalAs(UnmanagedType.U4)] Object scrollExtent);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnUIDeactivate([In, MarshalAs(UnmanagedType.Bool)] bool fUndoable);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnInPlaceDeactivate();

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int DiscardUndoState();

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int DeactivateAndUndo();

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnPosRectChange(
            [In, MarshalAs(UnmanagedType.Struct)] ref tagRECT lprcPosRect);
    }
    #endregion

    #region IOleInPlaceObject Interface
    //MIDL_INTERFACE("00000113-0000-0000-C000-000000000046")
    //IOleInPlaceObject : public IOleWindow
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE InPlaceDeactivate( void) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE UIDeactivate( void) = 0;

    //    virtual /* [input_sync] */ HRESULT STDMETHODCALLTYPE SetObjectRects( 
    //        /* [in] */ LPCRECT lprcPosRect,
    //        /* [in] */ LPCRECT lprcClipRect) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE ReactivateAndUndo( void) = 0;

    //};
    [ComVisible(true), ComImport(),
    Guid("00000113-0000-0000-C000-000000000046"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleInPlaceObject
    {
        //IOleWindow
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetWindow([In, Out] ref IntPtr phwnd);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ContextSensitiveHelp([In, MarshalAs(UnmanagedType.Bool)] bool
            fEnterMode);

        //IOleInPlaceObject
        void InPlaceDeactivate();

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int UIDeactivate();

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetObjectRects(
           [In, MarshalAs(UnmanagedType.Struct)] ref tagRECT lprcPosRect,
           [In, MarshalAs(UnmanagedType.Struct)] ref tagRECT lprcClipRect);

        void ReactivateAndUndo();
    }
    #endregion

    #region IOleObject Interface
    //MIDL_INTERFACE("00000112-0000-0000-C000-000000000046")
    //IOleObject : public IUnknown
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE SetClientSite( 
    //        /* [unique][in] */ IOleClientSite *pClientSite) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE GetClientSite( 
    //        /* [out] */ IOleClientSite **ppClientSite) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE SetHostNames( 
    //        /* [in] */ LPCOLESTR szContainerApp,
    //        /* [unique][in] */ LPCOLESTR szContainerObj) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE Close( 
    //        /* [in] */ DWORD dwSaveOption) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE SetMoniker( 
    //        /* [in] */ DWORD dwWhichMoniker,
    //        /* [unique][in] */ IMoniker *pmk) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE GetMoniker( 
    //        /* [in] */ DWORD dwAssign,
    //        /* [in] */ DWORD dwWhichMoniker,
    //        /* [out] */ IMoniker **ppmk) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE InitFromData( 
    //        /* [unique][in] */ IDataObject *pDataObject,
    //        /* [in] */ BOOL fCreation,
    //        /* [in] */ DWORD dwReserved) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE GetClipboardData( 
    //        /* [in] */ DWORD dwReserved,
    //        /* [out] */ IDataObject **ppDataObject) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE DoVerb( 
    //        /* [in] */ LONG iVerb,
    //        /* [unique][in] */ LPMSG lpmsg,
    //        /* [unique][in] */ IOleClientSite *pActiveSite,
    //        /* [in] */ LONG lindex,
    //        /* [in] */ HWND hwndParent,
    //        /* [unique][in] */ LPCRECT lprcPosRect) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE EnumVerbs( 
    //        /* [out] */ IEnumOLEVERB **ppEnumOleVerb) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE Update( void) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE IsUpToDate( void) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE GetUserClassID( 
    //        /* [out] */ CLSID *pClsid) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE GetUserType( 
    //        /* [in] */ DWORD dwFormOfType,
    //        /* [out] */ LPOLESTR *pszUserType) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE SetExtent( 
    //        /* [in] */ DWORD dwDrawAspect,
    //        /* [in] */ SIZEL *psizel) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE GetExtent( 
    //        /* [in] */ DWORD dwDrawAspect,
    //        /* [out] */ SIZEL *psizel) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE Advise( 
    //        /* [unique][in] */ IAdviseSink *pAdvSink,
    //        /* [out] */ DWORD *pdwConnection) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE Unadvise( 
    //        /* [in] */ DWORD dwConnection) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE EnumAdvise( 
    //        /* [out] */ IEnumSTATDATA **ppenumAdvise) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE GetMiscStatus( 
    //        /* [in] */ DWORD dwAspect,
    //        /* [out] */ DWORD *pdwStatus) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE SetColorScheme( 
    //        /* [in] */ LOGPALETTE *pLogpal) = 0;
    //};
    [ComImport, ComVisible(true)]
    [Guid("00000112-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleObject
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetClientSite(
            [In, MarshalAs(UnmanagedType.Interface)] IOleClientSite pClientSite);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetClientSite(
            [Out, MarshalAs(UnmanagedType.Interface)] out IOleClientSite site);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetHostNames(
            [In, MarshalAs(UnmanagedType.LPWStr)] string szContainerApp,
            [In, MarshalAs(UnmanagedType.LPWStr)] string szContainerObj);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Close([In, MarshalAs(UnmanagedType.U4)] uint dwSaveOption);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetMoniker(
            [In, MarshalAs(UnmanagedType.U4)] int dwWhichMoniker,
            [In, MarshalAs(UnmanagedType.Interface)] IMoniker pmk);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetMoniker(
            [In, MarshalAs(UnmanagedType.U4)] uint dwAssign,
            [In, MarshalAs(UnmanagedType.U4)] uint dwWhichMoniker,
            [Out, MarshalAs(UnmanagedType.Interface)] out IMoniker moniker);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int InitFromData(
            [In, MarshalAs(UnmanagedType.Interface)] System.Runtime.InteropServices.ComTypes.IDataObject pDataObject,
            [In, MarshalAs(UnmanagedType.Bool)] bool fCreation,
            [In, MarshalAs(UnmanagedType.U4)] uint dwReserved);

        int GetClipboardData(
            [In, MarshalAs(UnmanagedType.U4)] uint dwReserved,
            [Out, MarshalAs(UnmanagedType.Interface)] out System.Runtime.InteropServices.ComTypes.IDataObject data);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int DoVerb(
            [In, MarshalAs(UnmanagedType.I4)] int iVerb,
            [In, MarshalAs(UnmanagedType.Struct)] ref tagMSG lpmsg,
            //or [In] IntPtr lpmsg,
            [In, MarshalAs(UnmanagedType.Interface)] IOleClientSite pActiveSite,
            [In, MarshalAs(UnmanagedType.I4)] int lindex,
            [In] IntPtr hwndParent,
            [In, MarshalAs(UnmanagedType.Struct)] ref tagRECT lprcPosRect);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int EnumVerbs([Out, MarshalAs(UnmanagedType.Interface)] out Object e);
        //int EnumVerbs(out IEnumOLEVERB e);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OleUpdate();

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int IsUpToDate();

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetUserClassID([In, Out] ref Guid pClsid);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetUserType(
            [In, MarshalAs(UnmanagedType.U4)] uint dwFormOfType,
            [Out, MarshalAs(UnmanagedType.LPWStr)] out string userType);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetExtent(
            [In, MarshalAs(UnmanagedType.U4)] uint dwDrawAspect,
            [In, MarshalAs(UnmanagedType.Struct)] ref tagSIZEL pSizel);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetExtent(
            [In, MarshalAs(UnmanagedType.U4)] uint dwDrawAspect,
            [In, Out, MarshalAs(UnmanagedType.Struct)] ref tagSIZEL pSizel);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Advise(
            [In, MarshalAs(UnmanagedType.Interface)] IAdviseSink pAdvSink,
            out int cookie);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int Unadvise(
            [In, MarshalAs(UnmanagedType.U4)] uint dwConnection);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int EnumAdvise(out IEnumSTATDATA e);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetMiscStatus(
            [In, MarshalAs(UnmanagedType.U4)] uint dwAspect,
            out int misc);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetColorScheme([In, MarshalAs(UnmanagedType.Struct)] ref object pLogpal);
    }
    #endregion

    #region IOleClientSite Interface
    //MIDL_INTERFACE("00000118-0000-0000-C000-000000000046")
    //IOleClientSite : public IUnknown
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE SaveObject( void) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE GetMoniker( 
    //        /* [in] */ DWORD dwAssign,
    //        /* [in] */ DWORD dwWhichMoniker,
    //        /* [out] */ IMoniker **ppmk) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE GetContainer( 
    //        /* [out] */ IOleContainer **ppContainer) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE ShowObject( void) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE OnShowWindow( 
    //        /* [in] */ BOOL fShow) = 0;

    //    virtual HRESULT STDMETHODCALLTYPE RequestNewObjectLayout( void) = 0;

    //};
    [ComImport, ComVisible(true)]
    [Guid("00000118-0000-0000-C000-000000000046")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleClientSite
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SaveObject();

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetMoniker(
            [In, MarshalAs(UnmanagedType.U4)]         uint dwAssign,
            [In, MarshalAs(UnmanagedType.U4)]         uint dwWhichMoniker,
            [Out, MarshalAs(UnmanagedType.Interface)] out IMoniker ppmk);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int GetContainer(
            [Out, MarshalAs(UnmanagedType.Interface)] out IOleContainer ppContainer);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int ShowObject();

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int OnShowWindow([In, MarshalAs(UnmanagedType.Bool)] bool fShow);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int RequestNewObjectLayout();
    }
    #endregion

    #region IOleControl Interface
    //MIDL_INTERFACE("B196B288-BAB4-101A-B69C-00AA00341D07")
    //IOleControl : public IUnknown
    //{
    //public:
    //    virtual HRESULT STDMETHODCALLTYPE GetControlInfo( 
    //        /* [out] */ CONTROLINFO *pCI) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE OnMnemonic( 
    //        /* [in] */ MSG *pMsg) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE OnAmbientPropertyChange( 
    //        /* [in] */ DISPID dispID) = 0;
    //    virtual HRESULT STDMETHODCALLTYPE FreezeEvents( 
    //        /* [in] */ BOOL bFreeze) = 0;
    //}
    [ComImport, ComVisible(true)]
    [Guid("B196B288-BAB4-101A-B69C-00AA00341D07")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleControl
    {
        //struct tagCONTROLINFO
        //{
        //    ULONG cb; uint32
        //    HACCEL hAccel; intptr
        //    USHORT cAccel; ushort
        //    DWORD dwFlags; uint32
        //}
        void GetControlInfo(out object pCI);
        void OnMnemonic([In, MarshalAs(UnmanagedType.Struct)]ref tagMSG pMsg);
        void OnAmbientPropertyChange([In] int dispID);
        void FreezeEvents([In, MarshalAs(UnmanagedType.Bool)] bool bFreeze);
    }
    #endregion

}