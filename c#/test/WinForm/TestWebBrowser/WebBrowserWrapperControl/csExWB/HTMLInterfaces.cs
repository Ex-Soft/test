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
    //A bit of conversion rule
    //BSTR -> string
    //long or LONG -> int
    //[optional][in] or [in] VARIANT -> object
    //[optional][in] or [in] VARIANT* -> [In] ref object
    //Interface (IHTMLElement*) -> either itself (if defined) or object with MarshalAs(UnmanagedType.interface)
    //VARIANT_BOOL -> bool with MarshalAs(UnmanagedType.Variantbool)
    //IUnknown* -> object with MarshalAs(UnmanagedType.IUnknown)
    //IDispatch* -> object with MarshalAs(UnmanagedType.IDispatch)
    //SAFEARRAY(VARIANT) -> object with [MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)]
    //[optional][in][out] VARIANT* -> [In, Out] ref object

    #region IHTMLRect Interface
    /// <summary><para><c>IHTMLRect</c> interface.</para></summary>
    [Guid("3050F4A3-98B5-11CF-BB82-00AA00BDCE0B")]
    [ComImport]
    [TypeLibType((short)4160)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IHTMLRect
    {
        /// <summary><para><c>bottom</c> property of <c>IHTMLRect</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>bottom</c> property was the following:  <c>long bottom</c>;</para></remarks>
        // IDL: long bottom;
        // VB6: bottom As Long
        int bottom
        {
            // IDL: HRESULT bottom ([out, retval] long* ReturnValue);
            // VB6: Function bottom As Long
            [DispId(1004)]
            get;
            // IDL: HRESULT bottom (long value);
            // VB6: Sub bottom (ByVal value As Long)
            [DispId(1004)]
            set;
        }

        /// <summary><para><c>left</c> property of <c>IHTMLRect</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>left</c> property was the following:  <c>long left</c>;</para></remarks>
        // IDL: long left;
        // VB6: left As Long
        int left
        {
            // IDL: HRESULT left ([out, retval] long* ReturnValue);
            // VB6: Function left As Long
            [DispId(1001)]
            get;
            // IDL: HRESULT left (long value);
            // VB6: Sub left (ByVal value As Long)
            [DispId(1001)]
            set;
        }

        /// <summary><para><c>right</c> property of <c>IHTMLRect</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>right</c> property was the following:  <c>long right</c>;</para></remarks>
        // IDL: long right;
        // VB6: right As Long
        int right
        {
            // IDL: HRESULT right ([out, retval] long* ReturnValue);
            // VB6: Function right As Long
            [DispId(1003)]
            get;
            // IDL: HRESULT right (long value);
            // VB6: Sub right (ByVal value As Long)
            [DispId(1003)]
            set;
        }

        /// <summary><para><c>top</c> property of <c>IHTMLRect</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>top</c> property was the following:  <c>long top</c>;</para></remarks>
        // IDL: long top;
        // VB6: top As Long
        int top
        {
            // IDL: HRESULT top ([out, retval] long* ReturnValue);
            // VB6: Function top As Long
            [DispId(1002)]
            get;
            // IDL: HRESULT top (long value);
            // VB6: Sub top (ByVal value As Long)
            [DispId(1002)]
            set;
        }
    }
    #endregion

    #region IHTMLRectCollection Interface
    /// <summary><para><c>IHTMLRectCollection</c> interface.</para></summary>
    [Guid("3050F4A4-98B5-11CF-BB82-00AA00BDCE0B")]
    [ComImport]
    [TypeLibType((short)4160)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IHTMLRectCollection : System.Collections.IEnumerable
    {
        /// <summary><para><c>item</c> method of <c>IHTMLRectCollection</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>item</c> method was the following:  <c>HRESULT item ([in] VARIANT* pvarIndex, [out, retval] VARIANT* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT item ([in] VARIANT* pvarIndex, [out, retval] VARIANT* ReturnValue);
        // VB6: Function item (pvarIndex As Any) As Any
        [DispId(0)]
        object item([In] ref object pvarIndex);

        /// <summary><para><c>_newEnum</c> property of <c>IHTMLRectCollection</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>_newEnum</c> property was the following:  <c>IUnknown* _newEnum</c>;</para></remarks>
        // IDL: IUnknown* _newEnum;
        // VB6: _newEnum As IUnknown
        object _newEnum
        {
            // IDL: HRESULT _newEnum ([out, retval] IUnknown** ReturnValue);
            // VB6: Function _newEnum As IUnknown
            [DispId(-4)]
            [return: MarshalAs(UnmanagedType.IUnknown)]
            get;
        }

        /// <summary><para><c>length</c> property of <c>IHTMLRectCollection</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>length</c> property was the following:  <c>long length</c>;</para></remarks>
        // IDL: long length;
        // VB6: length As Long
        int length
        {
            // IDL: HRESULT length ([out, retval] long* ReturnValue);
            // VB6: Function length As Long
            [DispId(1500)]
            get;
        }
    }
    #endregion

    #region IHTMLElement Interface
    /// <summary><para><c>IHTMLElement</c> interface.</para></summary>
    [Guid("3050F1FF-98B5-11CF-BB82-00AA00BDCE0B")]
    [ComImport]
    [TypeLibType((short)4160)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IHTMLElement
    {
        /// <summary><para><c>setAttribute</c> method of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>setAttribute</c> method was the following:  <c>HRESULT setAttribute (BSTR strAttributeName, VARIANT AttributeValue, [optional, defaultvalue(1)] long lFlags)</c>;</para></remarks>
        // IDL: HRESULT setAttribute (BSTR strAttributeName, VARIANT AttributeValue, [optional, defaultvalue(1)] long lFlags);
        // VB6: Sub setAttribute (ByVal strAttributeName As String, ByVal AttributeValue As Any, [ByVal lFlags As Long = 1])
        [DispId(HTMLDispIDs.DISPID_IHTMLELEMENT_SETATTRIBUTE)] // - 2147417611)]
        void setAttribute([MarshalAs(UnmanagedType.BStr)] string strAttributeName, object AttributeValue, int lFlags);

        /// <summary><para><c>getAttribute</c> method of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>getAttribute</c> method was the following:  <c>HRESULT getAttribute (BSTR strAttributeName, [optional, defaultvalue(0)] long lFlags, [out, retval] VARIANT* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT getAttribute (BSTR strAttributeName, [optional, defaultvalue(0)] long lFlags, [out, retval] VARIANT* ReturnValue);
        // VB6: Function getAttribute (ByVal strAttributeName As String, [ByVal lFlags As Long = 0]) As Any
        [DispId(-2147417610)]
        object getAttribute([MarshalAs(UnmanagedType.BStr)] string strAttributeName, int lFlags);

        /// <summary><para><c>removeAttribute</c> method of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>removeAttribute</c> method was the following:  <c>HRESULT removeAttribute (BSTR strAttributeName, [optional, defaultvalue(1)] long lFlags, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT removeAttribute (BSTR strAttributeName, [optional, defaultvalue(1)] long lFlags, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function removeAttribute (ByVal strAttributeName As String, [ByVal lFlags As Long = 1]) As Boolean
        [DispId(-2147417609)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool removeAttribute([MarshalAs(UnmanagedType.BStr)] string strAttributeName, int lFlags);

        /// <summary><para><c>scrollIntoView</c> method of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>scrollIntoView</c> method was the following:  <c>HRESULT scrollIntoView ([optional] VARIANT varargStart)</c>;</para></remarks>
        // IDL: HRESULT scrollIntoView ([optional] VARIANT varargStart);
        // VB6: Sub scrollIntoView ([ByVal varargStart As Any])
        [DispId(-2147417093)]
        void scrollIntoView(object varargStart);

        /// <summary><para><c>contains</c> method of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>contains</c> method was the following:  <c>HRESULT contains (IHTMLElement* pChild, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT contains (IHTMLElement* pChild, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function contains (ByVal pChild As IHTMLElement) As Boolean
        [DispId(-2147417092)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool contains(IHTMLElement pChild);

        /// <summary><para><c>insertAdjacentHTML</c> method of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>insertAdjacentHTML</c> method was the following:  <c>HRESULT insertAdjacentHTML (BSTR where, BSTR html)</c>;</para></remarks>
        // IDL: HRESULT insertAdjacentHTML (BSTR where, BSTR html);
        // VB6: Sub insertAdjacentHTML (ByVal where As String, ByVal html As String)
        [DispId(-2147417082)]
        void insertAdjacentHTML([MarshalAs(UnmanagedType.BStr)] string where, [MarshalAs(UnmanagedType.BStr)] string html);

        /// <summary><para><c>insertAdjacentText</c> method of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>insertAdjacentText</c> method was the following:  <c>HRESULT insertAdjacentText (BSTR where, BSTR text)</c>;</para></remarks>
        // IDL: HRESULT insertAdjacentText (BSTR where, BSTR text);
        // VB6: Sub insertAdjacentText (ByVal where As String, ByVal text As String)
        [DispId(-2147417081)]
        void insertAdjacentText([MarshalAs(UnmanagedType.BStr)] string where, [MarshalAs(UnmanagedType.BStr)] string text);

        /// <summary><para><c>click</c> method of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>click</c> method was the following:  <c>HRESULT click (void)</c>;</para></remarks>
        // IDL: HRESULT click (void);
        // VB6: Sub click
        [DispId(-2147417079)]
        void click();

        /// <summary><para><c>toString</c> method of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>toString</c> method was the following:  <c>HRESULT toString ([out, retval] BSTR* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT toString ([out, retval] BSTR* ReturnValue);
        // VB6: Function toString As String
        [DispId(-2147417076)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string toString();

        /// <summary><para><c>all</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>all</c> property was the following:  <c>IDispatch* all</c>;</para></remarks>
        // IDL: IDispatch* all;
        // VB6: all As IDispatch
        object all
        {
            // IDL: HRESULT all ([out, retval] IDispatch** ReturnValue);
            // VB6: Function all As IDispatch
            [DispId(-2147417074)]
            [return: MarshalAs(UnmanagedType.IDispatch)]
            get;
        }

        /// <summary><para><c>children</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>children</c> property was the following:  <c>IDispatch* children</c>;</para></remarks>
        // IDL: IDispatch* children;
        // VB6: children As IDispatch
        object children
        {
            // IDL: HRESULT children ([out, retval] IDispatch** ReturnValue);
            // VB6: Function children As IDispatch
            [DispId(-2147417075)]
            [return: MarshalAs(UnmanagedType.IDispatch)]
            get;
        }

        /// <summary><para><c>className</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>className</c> property was the following:  <c>BSTR className</c>;</para></remarks>
        // IDL: BSTR className;
        // VB6: className As String
        string className
        {
            // IDL: HRESULT className ([out, retval] BSTR* ReturnValue);
            // VB6: Function className As String
            [DispId(-2147417111)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT className (BSTR value);
            // VB6: Sub className (ByVal value As String)
            [DispId(-2147417111)]
            set;
        }

        /// <summary><para><c>document</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>document</c> property was the following:  <c>IDispatch* document</c>;</para></remarks>
        // IDL: IDispatch* document;
        // VB6: document As IDispatch
        object document
        {
            // IDL: HRESULT document ([out, retval] IDispatch** ReturnValue);
            // VB6: Function document As IDispatch
            [DispId(-2147417094)]
            [return: MarshalAs(UnmanagedType.IDispatch)]
            get;
        }

        /// <summary><para><c>filters</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>filters</c> property was the following:  <c>IHTMLFiltersCollection* filters</c>;</para></remarks>
        // IDL: IHTMLFiltersCollection* filters;
        // VB6: filters As IHTMLFiltersCollection
        //IHTMLFiltersCollection filters
        object filters
        {
            // IDL: HRESULT filters ([out, retval] IHTMLFiltersCollection** ReturnValue);
            // VB6: Function filters As IHTMLFiltersCollection
            [DispId(-2147417077)]
            [return: MarshalAs(UnmanagedType.Interface)]
            get;
        }

        /// <summary><para><c>id</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>id</c> property was the following:  <c>BSTR id</c>;</para></remarks>
        // IDL: BSTR id;
        // VB6: id As String
        string id
        {
            // IDL: HRESULT id ([out, retval] BSTR* ReturnValue);
            // VB6: Function id As String
            [DispId(-2147417110)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT id (BSTR value);
            // VB6: Sub id (ByVal value As String)
            [DispId(-2147417110)]
            set;
        }

        /// <summary><para><c>innerHTML</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>innerHTML</c> property was the following:  <c>BSTR innerHTML</c>;</para></remarks>
        // IDL: BSTR innerHTML;
        // VB6: innerHTML As String
        string innerHTML
        {
            // IDL: HRESULT innerHTML ([out, retval] BSTR* ReturnValue);
            // VB6: Function innerHTML As String
            [DispId(-2147417086)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT innerHTML (BSTR value);
            // VB6: Sub innerHTML (ByVal value As String)
            [DispId(-2147417086)]
            set;
        }

        /// <summary><para><c>innerText</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>innerText</c> property was the following:  <c>BSTR innerText</c>;</para></remarks>
        // IDL: BSTR innerText;
        // VB6: innerText As String
        string innerText
        {
            // IDL: HRESULT innerText ([out, retval] BSTR* ReturnValue);
            // VB6: Function innerText As String
            [DispId(-2147417085)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT innerText (BSTR value);
            // VB6: Sub innerText (ByVal value As String)
            [DispId(-2147417085)]
            set;
        }

        /// <summary><para><c>isTextEdit</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>isTextEdit</c> property was the following:  <c>VARIANT_BOOL isTextEdit</c>;</para></remarks>
        // IDL: VARIANT_BOOL isTextEdit;
        // VB6: isTextEdit As Boolean
        bool isTextEdit
        {
            // IDL: HRESULT isTextEdit ([out, retval] VARIANT_BOOL* ReturnValue);
            // VB6: Function isTextEdit As Boolean
            [DispId(-2147417078)]
            [return: MarshalAs(UnmanagedType.VariantBool)]
            get;
        }

        /// <summary><para><c>lang</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>lang</c> property was the following:  <c>BSTR lang</c>;</para></remarks>
        // IDL: BSTR lang;
        // VB6: lang As String
        string lang
        {
            // IDL: HRESULT lang ([out, retval] BSTR* ReturnValue);
            // VB6: Function lang As String
            [DispId(-2147413103)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT lang (BSTR value);
            // VB6: Sub lang (ByVal value As String)
            [DispId(-2147413103)]
            set;
        }

        /// <summary><para><c>language</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>language</c> property was the following:  <c>BSTR language</c>;</para></remarks>
        // IDL: BSTR language;
        // VB6: language As String
        string language
        {
            // IDL: HRESULT language ([out, retval] BSTR* ReturnValue);
            // VB6: Function language As String
            [DispId(-2147413012)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT language (BSTR value);
            // VB6: Sub language (ByVal value As String)
            [DispId(-2147413012)]
            set;
        }

        /// <summary><para><c>offsetHeight</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>offsetHeight</c> property was the following:  <c>long offsetHeight</c>;</para></remarks>
        // IDL: long offsetHeight;
        // VB6: offsetHeight As Long
        int offsetHeight
        {
            // IDL: HRESULT offsetHeight ([out, retval] long* ReturnValue);
            // VB6: Function offsetHeight As Long
            [DispId(-2147417101)]
            get;
        }

        /// <summary><para><c>offsetLeft</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>offsetLeft</c> property was the following:  <c>long offsetLeft</c>;</para></remarks>
        // IDL: long offsetLeft;
        // VB6: offsetLeft As Long
        int offsetLeft
        {
            // IDL: HRESULT offsetLeft ([out, retval] long* ReturnValue);
            // VB6: Function offsetLeft As Long
            [DispId(-2147417104)]
            get;
        }

        /// <summary><para><c>offsetParent</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>offsetParent</c> property was the following:  <c>IHTMLElement* offsetParent</c>;</para></remarks>
        // IDL: IHTMLElement* offsetParent;
        // VB6: offsetParent As IHTMLElement
        IHTMLElement offsetParent
        {
            // IDL: HRESULT offsetParent ([out, retval] IHTMLElement** ReturnValue);
            // VB6: Function offsetParent As IHTMLElement
            [DispId(-2147417100)]
            get;
        }

        /// <summary><para><c>offsetTop</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>offsetTop</c> property was the following:  <c>long offsetTop</c>;</para></remarks>
        // IDL: long offsetTop;
        // VB6: offsetTop As Long
        int offsetTop
        {
            // IDL: HRESULT offsetTop ([out, retval] long* ReturnValue);
            // VB6: Function offsetTop As Long
            [DispId(-2147417103)]
            get;
        }

        /// <summary><para><c>offsetWidth</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>offsetWidth</c> property was the following:  <c>long offsetWidth</c>;</para></remarks>
        // IDL: long offsetWidth;
        // VB6: offsetWidth As Long
        int offsetWidth
        {
            // IDL: HRESULT offsetWidth ([out, retval] long* ReturnValue);
            // VB6: Function offsetWidth As Long
            [DispId(-2147417102)]
            get;
        }

        /// <summary><para><c>onafterupdate</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onafterupdate</c> property was the following:  <c>VARIANT onafterupdate</c>;</para></remarks>
        // IDL: VARIANT onafterupdate;
        // VB6: onafterupdate As Any
        object onafterupdate
        {
            // IDL: HRESULT onafterupdate ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onafterupdate As Any
            [DispId(-2147412090)]
            get;
            // IDL: HRESULT onafterupdate (VARIANT value);
            // VB6: Sub onafterupdate (ByVal value As Any)
            [DispId(-2147412090)]
            set;
        }

        /// <summary><para><c>onbeforeupdate</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onbeforeupdate</c> property was the following:  <c>VARIANT onbeforeupdate</c>;</para></remarks>
        // IDL: VARIANT onbeforeupdate;
        // VB6: onbeforeupdate As Any
        object onbeforeupdate
        {
            // IDL: HRESULT onbeforeupdate ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onbeforeupdate As Any
            [DispId(-2147412091)]
            get;
            // IDL: HRESULT onbeforeupdate (VARIANT value);
            // VB6: Sub onbeforeupdate (ByVal value As Any)
            [DispId(-2147412091)]
            set;
        }

        /// <summary><para><c>onclick</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onclick</c> property was the following:  <c>VARIANT onclick</c>;</para></remarks>
        // IDL: VARIANT onclick;
        // VB6: onclick As Any
        object onclick
        {
            // IDL: HRESULT onclick ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onclick As Any
            [DispId(-2147412104)]
            get;
            // IDL: HRESULT onclick (VARIANT value);
            // VB6: Sub onclick (ByVal value As Any)
            [DispId(-2147412104)]
            set;
        }

        /// <summary><para><c>ondataavailable</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>ondataavailable</c> property was the following:  <c>VARIANT ondataavailable</c>;</para></remarks>
        // IDL: VARIANT ondataavailable;
        // VB6: ondataavailable As Any
        object ondataavailable
        {
            // IDL: HRESULT ondataavailable ([out, retval] VARIANT* ReturnValue);
            // VB6: Function ondataavailable As Any
            [DispId(-2147412071)]
            get;
            // IDL: HRESULT ondataavailable (VARIANT value);
            // VB6: Sub ondataavailable (ByVal value As Any)
            [DispId(-2147412071)]
            set;
        }

        /// <summary><para><c>ondatasetchanged</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>ondatasetchanged</c> property was the following:  <c>VARIANT ondatasetchanged</c>;</para></remarks>
        // IDL: VARIANT ondatasetchanged;
        // VB6: ondatasetchanged As Any
        object ondatasetchanged
        {
            // IDL: HRESULT ondatasetchanged ([out, retval] VARIANT* ReturnValue);
            // VB6: Function ondatasetchanged As Any
            [DispId(-2147412072)]
            get;
            // IDL: HRESULT ondatasetchanged (VARIANT value);
            // VB6: Sub ondatasetchanged (ByVal value As Any)
            [DispId(-2147412072)]
            set;
        }

        /// <summary><para><c>ondatasetcomplete</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>ondatasetcomplete</c> property was the following:  <c>VARIANT ondatasetcomplete</c>;</para></remarks>
        // IDL: VARIANT ondatasetcomplete;
        // VB6: ondatasetcomplete As Any
        object ondatasetcomplete
        {
            // IDL: HRESULT ondatasetcomplete ([out, retval] VARIANT* ReturnValue);
            // VB6: Function ondatasetcomplete As Any
            [DispId(-2147412070)]
            get;
            // IDL: HRESULT ondatasetcomplete (VARIANT value);
            // VB6: Sub ondatasetcomplete (ByVal value As Any)
            [DispId(-2147412070)]
            set;
        }

        /// <summary><para><c>ondblclick</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>ondblclick</c> property was the following:  <c>VARIANT ondblclick</c>;</para></remarks>
        // IDL: VARIANT ondblclick;
        // VB6: ondblclick As Any
        object ondblclick
        {
            // IDL: HRESULT ondblclick ([out, retval] VARIANT* ReturnValue);
            // VB6: Function ondblclick As Any
            [DispId(-2147412103)]
            get;
            // IDL: HRESULT ondblclick (VARIANT value);
            // VB6: Sub ondblclick (ByVal value As Any)
            [DispId(-2147412103)]
            set;
        }

        /// <summary><para><c>ondragstart</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>ondragstart</c> property was the following:  <c>VARIANT ondragstart</c>;</para></remarks>
        // IDL: VARIANT ondragstart;
        // VB6: ondragstart As Any
        object ondragstart
        {
            // IDL: HRESULT ondragstart ([out, retval] VARIANT* ReturnValue);
            // VB6: Function ondragstart As Any
            [DispId(-2147412077)]
            get;
            // IDL: HRESULT ondragstart (VARIANT value);
            // VB6: Sub ondragstart (ByVal value As Any)
            [DispId(-2147412077)]
            set;
        }

        /// <summary><para><c>onerrorupdate</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onerrorupdate</c> property was the following:  <c>VARIANT onerrorupdate</c>;</para></remarks>
        // IDL: VARIANT onerrorupdate;
        // VB6: onerrorupdate As Any
        object onerrorupdate
        {
            // IDL: HRESULT onerrorupdate ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onerrorupdate As Any
            [DispId(-2147412074)]
            get;
            // IDL: HRESULT onerrorupdate (VARIANT value);
            // VB6: Sub onerrorupdate (ByVal value As Any)
            [DispId(-2147412074)]
            set;
        }

        /// <summary><para><c>onfilterchange</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onfilterchange</c> property was the following:  <c>VARIANT onfilterchange</c>;</para></remarks>
        // IDL: VARIANT onfilterchange;
        // VB6: onfilterchange As Any
        object onfilterchange
        {
            // IDL: HRESULT onfilterchange ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onfilterchange As Any
            [DispId(-2147412069)]
            get;
            // IDL: HRESULT onfilterchange (VARIANT value);
            // VB6: Sub onfilterchange (ByVal value As Any)
            [DispId(-2147412069)]
            set;
        }

        /// <summary><para><c>onhelp</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onhelp</c> property was the following:  <c>VARIANT onhelp</c>;</para></remarks>
        // IDL: VARIANT onhelp;
        // VB6: onhelp As Any
        object onhelp
        {
            // IDL: HRESULT onhelp ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onhelp As Any
            [DispId(-2147412099)]
            get;
            // IDL: HRESULT onhelp (VARIANT value);
            // VB6: Sub onhelp (ByVal value As Any)
            [DispId(-2147412099)]
            set;
        }

        /// <summary><para><c>onkeydown</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onkeydown</c> property was the following:  <c>VARIANT onkeydown</c>;</para></remarks>
        // IDL: VARIANT onkeydown;
        // VB6: onkeydown As Any
        object onkeydown
        {
            // IDL: HRESULT onkeydown ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onkeydown As Any
            [DispId(-2147412107)]
            get;
            // IDL: HRESULT onkeydown (VARIANT value);
            // VB6: Sub onkeydown (ByVal value As Any)
            [DispId(-2147412107)]
            set;
        }

        /// <summary><para><c>onkeypress</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onkeypress</c> property was the following:  <c>VARIANT onkeypress</c>;</para></remarks>
        // IDL: VARIANT onkeypress;
        // VB6: onkeypress As Any
        object onkeypress
        {
            // IDL: HRESULT onkeypress ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onkeypress As Any
            [DispId(-2147412105)]
            get;
            // IDL: HRESULT onkeypress (VARIANT value);
            // VB6: Sub onkeypress (ByVal value As Any)
            [DispId(-2147412105)]
            set;
        }

        /// <summary><para><c>onkeyup</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onkeyup</c> property was the following:  <c>VARIANT onkeyup</c>;</para></remarks>
        // IDL: VARIANT onkeyup;
        // VB6: onkeyup As Any
        object onkeyup
        {
            // IDL: HRESULT onkeyup ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onkeyup As Any
            [DispId(-2147412106)]
            get;
            // IDL: HRESULT onkeyup (VARIANT value);
            // VB6: Sub onkeyup (ByVal value As Any)
            [DispId(-2147412106)]
            set;
        }

        /// <summary><para><c>onmousedown</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onmousedown</c> property was the following:  <c>VARIANT onmousedown</c>;</para></remarks>
        // IDL: VARIANT onmousedown;
        // VB6: onmousedown As Any
        object onmousedown
        {
            // IDL: HRESULT onmousedown ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onmousedown As Any
            [DispId(-2147412110)]
            get;
            // IDL: HRESULT onmousedown (VARIANT value);
            // VB6: Sub onmousedown (ByVal value As Any)
            [DispId(-2147412110)]
            set;
        }

        /// <summary><para><c>onmousemove</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onmousemove</c> property was the following:  <c>VARIANT onmousemove</c>;</para></remarks>
        // IDL: VARIANT onmousemove;
        // VB6: onmousemove As Any
        object onmousemove
        {
            // IDL: HRESULT onmousemove ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onmousemove As Any
            [DispId(-2147412108)]
            get;
            // IDL: HRESULT onmousemove (VARIANT value);
            // VB6: Sub onmousemove (ByVal value As Any)
            [DispId(-2147412108)]
            set;
        }

        /// <summary><para><c>onmouseout</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onmouseout</c> property was the following:  <c>VARIANT onmouseout</c>;</para></remarks>
        // IDL: VARIANT onmouseout;
        // VB6: onmouseout As Any
        object onmouseout
        {
            // IDL: HRESULT onmouseout ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onmouseout As Any
            [DispId(-2147412111)]
            get;
            // IDL: HRESULT onmouseout (VARIANT value);
            // VB6: Sub onmouseout (ByVal value As Any)
            [DispId(-2147412111)]
            set;
        }

        /// <summary><para><c>onmouseover</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onmouseover</c> property was the following:  <c>VARIANT onmouseover</c>;</para></remarks>
        // IDL: VARIANT onmouseover;
        // VB6: onmouseover As Any
        object onmouseover
        {
            // IDL: HRESULT onmouseover ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onmouseover As Any
            [DispId(-2147412112)]
            get;
            // IDL: HRESULT onmouseover (VARIANT value);
            // VB6: Sub onmouseover (ByVal value As Any)
            [DispId(-2147412112)]
            set;
        }

        /// <summary><para><c>onmouseup</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onmouseup</c> property was the following:  <c>VARIANT onmouseup</c>;</para></remarks>
        // IDL: VARIANT onmouseup;
        // VB6: onmouseup As Any
        object onmouseup
        {
            // IDL: HRESULT onmouseup ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onmouseup As Any
            [DispId(-2147412109)]
            get;
            // IDL: HRESULT onmouseup (VARIANT value);
            // VB6: Sub onmouseup (ByVal value As Any)
            [DispId(-2147412109)]
            set;
        }

        /// <summary><para><c>onrowenter</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onrowenter</c> property was the following:  <c>VARIANT onrowenter</c>;</para></remarks>
        // IDL: VARIANT onrowenter;
        // VB6: onrowenter As Any
        object onrowenter
        {
            // IDL: HRESULT onrowenter ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onrowenter As Any
            [DispId(-2147412093)]
            get;
            // IDL: HRESULT onrowenter (VARIANT value);
            // VB6: Sub onrowenter (ByVal value As Any)
            [DispId(-2147412093)]
            set;
        }

        /// <summary><para><c>onrowexit</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onrowexit</c> property was the following:  <c>VARIANT onrowexit</c>;</para></remarks>
        // IDL: VARIANT onrowexit;
        // VB6: onrowexit As Any
        object onrowexit
        {
            // IDL: HRESULT onrowexit ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onrowexit As Any
            [DispId(-2147412094)]
            get;
            // IDL: HRESULT onrowexit (VARIANT value);
            // VB6: Sub onrowexit (ByVal value As Any)
            [DispId(-2147412094)]
            set;
        }

        /// <summary><para><c>onselectstart</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onselectstart</c> property was the following:  <c>VARIANT onselectstart</c>;</para></remarks>
        // IDL: VARIANT onselectstart;
        // VB6: onselectstart As Any
        object onselectstart
        {
            // IDL: HRESULT onselectstart ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onselectstart As Any
            [DispId(-2147412075)]
            get;
            // IDL: HRESULT onselectstart (VARIANT value);
            // VB6: Sub onselectstart (ByVal value As Any)
            [DispId(-2147412075)]
            set;
        }

        /// <summary><para><c>outerHTML</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>outerHTML</c> property was the following:  <c>BSTR outerHTML</c>;</para></remarks>
        // IDL: BSTR outerHTML;
        // VB6: outerHTML As String
        string outerHTML
        {
            // IDL: HRESULT outerHTML ([out, retval] BSTR* ReturnValue);
            // VB6: Function outerHTML As String
            [DispId(-2147417084)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT outerHTML (BSTR value);
            // VB6: Sub outerHTML (ByVal value As String)
            [DispId(-2147417084)]
            set;
        }

        /// <summary><para><c>outerText</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>outerText</c> property was the following:  <c>BSTR outerText</c>;</para></remarks>
        // IDL: BSTR outerText;
        // VB6: outerText As String
        string outerText
        {
            // IDL: HRESULT outerText ([out, retval] BSTR* ReturnValue);
            // VB6: Function outerText As String
            [DispId(-2147417083)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT outerText (BSTR value);
            // VB6: Sub outerText (ByVal value As String)
            [DispId(-2147417083)]
            set;
        }

        /// <summary><para><c>parentElement</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>parentElement</c> property was the following:  <c>IHTMLElement* parentElement</c>;</para></remarks>
        // IDL: IHTMLElement* parentElement;
        // VB6: parentElement As IHTMLElement
        IHTMLElement parentElement
        {
            // IDL: HRESULT parentElement ([out, retval] IHTMLElement** ReturnValue);
            // VB6: Function parentElement As IHTMLElement
            [DispId(-2147418104)]
            get;
        }

        /// <summary><para><c>parentTextEdit</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>parentTextEdit</c> property was the following:  <c>IHTMLElement* parentTextEdit</c>;</para></remarks>
        // IDL: IHTMLElement* parentTextEdit;
        // VB6: parentTextEdit As IHTMLElement
        IHTMLElement parentTextEdit
        {
            // IDL: HRESULT parentTextEdit ([out, retval] IHTMLElement** ReturnValue);
            // VB6: Function parentTextEdit As IHTMLElement
            [DispId(-2147417080)]
            get;
        }

        /// <summary><para><c>recordNumber</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>recordNumber</c> property was the following:  <c>VARIANT recordNumber</c>;</para></remarks>
        // IDL: VARIANT recordNumber;
        // VB6: recordNumber As Any
        object recordNumber
        {
            // IDL: HRESULT recordNumber ([out, retval] VARIANT* ReturnValue);
            // VB6: Function recordNumber As Any
            [DispId(-2147417087)]
            get;
        }

        /// <summary><para><c>sourceIndex</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>sourceIndex</c> property was the following:  <c>long sourceIndex</c>;</para></remarks>
        // IDL: long sourceIndex;
        // VB6: sourceIndex As Long
        int sourceIndex
        {
            // IDL: HRESULT sourceIndex ([out, retval] long* ReturnValue);
            // VB6: Function sourceIndex As Long
            [DispId(-2147417088)]
            get;
        }

        /// <summary><para><c>style</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>style</c> property was the following:  <c>IHTMLStyle* style</c>;</para></remarks>
        // IDL: IHTMLStyle* style;
        // VB6: style As IHTMLStyle
        IHTMLStyle style
        {
            // IDL: HRESULT style ([out, retval] IHTMLStyle** ReturnValue);
            // VB6: Function style As IHTMLStyle
            [DispId(-2147418038)]
            get;
        }

        /// <summary><para><c>tagName</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>tagName</c> property was the following:  <c>BSTR tagName</c>;</para></remarks>
        // IDL: BSTR tagName;
        // VB6: tagName As String
        string tagName
        {
            // IDL: HRESULT tagName ([out, retval] BSTR* ReturnValue);
            // VB6: Function tagName As String
            [DispId(-2147417108)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }

        /// <summary><para><c>title</c> property of <c>IHTMLElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>title</c> property was the following:  <c>BSTR title</c>;</para></remarks>
        // IDL: BSTR title;
        // VB6: title As String
        string title
        {
            // IDL: HRESULT title ([out, retval] BSTR* ReturnValue);
            // VB6: Function title As String
            [DispId(-2147418043)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT title (BSTR value);
            // VB6: Sub title (ByVal value As String)
            [DispId(-2147418043)]
            set;
        }
    }
    #endregion

    #region IHTMLElement2 Interface
    /// <summary><para><c>IHTMLElement2</c> interface.</para></summary>
    [Guid("3050F434-98B5-11CF-BB82-00AA00BDCE0B")]
    [ComImport]
    [TypeLibType((short)4160)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IHTMLElement2
    {
        /// <summary><para><c>setCapture</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>setCapture</c> method was the following:  <c>HRESULT setCapture ([optional, defaultvalue(-1)] VARIANT_BOOL containerCapture)</c>;</para></remarks>
        // IDL: HRESULT setCapture ([optional, defaultvalue(-1)] VARIANT_BOOL containerCapture);
        // VB6: Sub setCapture ([ByVal containerCapture As Boolean = True])
        [DispId(-2147417072)]
        void setCapture([MarshalAs(UnmanagedType.VariantBool)] bool containerCapture);

        /// <summary><para><c>releaseCapture</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>releaseCapture</c> method was the following:  <c>HRESULT releaseCapture (void)</c>;</para></remarks>
        // IDL: HRESULT releaseCapture (void);
        // VB6: Sub releaseCapture
        [DispId(-2147417071)]
        void releaseCapture();

        /// <summary><para><c>componentFromPoint</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>componentFromPoint</c> method was the following:  <c>HRESULT componentFromPoint (long x, long y, [out, retval] BSTR* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT componentFromPoint (long x, long y, [out, retval] BSTR* ReturnValue);
        // VB6: Function componentFromPoint (ByVal x As Long, ByVal y As Long) As String
        [DispId(-2147417070)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string componentFromPoint(int x, int y);

        /// <summary><para><c>doScroll</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>doScroll</c> method was the following:  <c>HRESULT doScroll ([optional] VARIANT component)</c>;</para></remarks>
        // IDL: HRESULT doScroll ([optional] VARIANT component);
        // VB6: Sub doScroll ([ByVal component As Any])
        [DispId(-2147417069)]
        void doScroll(object component);

        /// <summary><para><c>getClientRects</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>getClientRects</c> method was the following:  <c>HRESULT getClientRects ([out, retval] IHTMLRectCollection** ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT getClientRects ([out, retval] IHTMLRectCollection** ReturnValue);
        // VB6: Function getClientRects As IHTMLRectCollection
        [DispId(-2147417068)]
        IHTMLRectCollection getClientRects();

        /// <summary><para><c>getBoundingClientRect</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>getBoundingClientRect</c> method was the following:  <c>HRESULT getBoundingClientRect ([out, retval] IHTMLRect** ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT getBoundingClientRect ([out, retval] IHTMLRect** ReturnValue);
        // VB6: Function getBoundingClientRect As IHTMLRect
        [DispId(-2147417067)]
        IHTMLRect getBoundingClientRect();

        /// <summary><para><c>setExpression</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>setExpression</c> method was the following:  <c>HRESULT setExpression (BSTR propname, BSTR expression, [optional, defaultvalue("")] BSTR language)</c>;</para></remarks>
        // IDL: HRESULT setExpression (BSTR propname, BSTR expression, [optional, defaultvalue("")] BSTR language);
        // VB6: Sub setExpression (ByVal propname As String, ByVal expression As String, [ByVal language As String = ""])
        [DispId(-2147417608)]
        void setExpression([MarshalAs(UnmanagedType.BStr)] string propname, [MarshalAs(UnmanagedType.BStr)] string expression, [MarshalAs(UnmanagedType.BStr)] string language);

        /// <summary><para><c>getExpression</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>getExpression</c> method was the following:  <c>HRESULT getExpression (BSTR propname, [out, retval] VARIANT* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT getExpression (BSTR propname, [out, retval] VARIANT* ReturnValue);
        // VB6: Function getExpression (ByVal propname As String) As Any
        [DispId(-2147417607)]
        object getExpression([MarshalAs(UnmanagedType.BStr)] string propname);

        /// <summary><para><c>removeExpression</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>removeExpression</c> method was the following:  <c>HRESULT removeExpression (BSTR propname, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT removeExpression (BSTR propname, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function removeExpression (ByVal propname As String) As Boolean
        [DispId(-2147417606)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool removeExpression([MarshalAs(UnmanagedType.BStr)] string propname);

        /// <summary><para><c>focus</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>focus</c> method was the following:  <c>HRESULT focus (void)</c>;</para></remarks>
        // IDL: HRESULT focus (void);
        // VB6: Sub focus
        [DispId(-2147416112)]
        void focus();

        /// <summary><para><c>blur</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>blur</c> method was the following:  <c>HRESULT blur (void)</c>;</para></remarks>
        // IDL: HRESULT blur (void);
        // VB6: Sub blur
        [DispId(-2147416110)]
        void blur();

        /// <summary><para><c>addFilter</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>addFilter</c> method was the following:  <c>HRESULT addFilter (IUnknown* pUnk)</c>;</para></remarks>
        // IDL: HRESULT addFilter (IUnknown* pUnk);
        // VB6: Sub addFilter (ByVal pUnk As IUnknown)
        [DispId(-2147416095)]
        void addFilter([MarshalAs(UnmanagedType.IUnknown)] object pUnk);

        /// <summary><para><c>removeFilter</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>removeFilter</c> method was the following:  <c>HRESULT removeFilter (IUnknown* pUnk)</c>;</para></remarks>
        // IDL: HRESULT removeFilter (IUnknown* pUnk);
        // VB6: Sub removeFilter (ByVal pUnk As IUnknown)
        [DispId(-2147416094)]
        void removeFilter([MarshalAs(UnmanagedType.IUnknown)] object pUnk);

        /// <summary><para><c>attachEvent</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>attachEvent</c> method was the following:  <c>HRESULT attachEvent (BSTR event, IDispatch* pdisp, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT attachEvent (BSTR event, IDispatch* pdisp, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function attachEvent (ByVal event As String, ByVal pdisp As IDispatch) As Boolean
        [DispId(-2147417605)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool attachEvent([MarshalAs(UnmanagedType.BStr)] string _event, [MarshalAs(UnmanagedType.IDispatch)] object pdisp);

        /// <summary><para><c>detachEvent</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>detachEvent</c> method was the following:  <c>HRESULT detachEvent (BSTR event, IDispatch* pdisp)</c>;</para></remarks>
        // IDL: HRESULT detachEvent (BSTR event, IDispatch* pdisp);
        // VB6: Sub detachEvent (ByVal event As String, ByVal pdisp As IDispatch)
        [DispId(-2147417604)]
        void detachEvent([MarshalAs(UnmanagedType.BStr)] string _event, [MarshalAs(UnmanagedType.IDispatch)] object pdisp);

        /// <summary><para><c>createControlRange</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>createControlRange</c> method was the following:  <c>HRESULT createControlRange ([out, retval] IDispatch** ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT createControlRange ([out, retval] IDispatch** ReturnValue);
        // VB6: Function createControlRange As IDispatch
        [DispId(-2147417056)]
        [return: MarshalAs(UnmanagedType.IDispatch)]
        object createControlRange();

        /// <summary><para><c>clearAttributes</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>clearAttributes</c> method was the following:  <c>HRESULT clearAttributes (void)</c>;</para></remarks>
        // IDL: HRESULT clearAttributes (void);
        // VB6: Sub clearAttributes
        [DispId(-2147417050)]
        void clearAttributes();

        /// <summary><para><c>mergeAttributes</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>mergeAttributes</c> method was the following:  <c>HRESULT mergeAttributes (IHTMLElement* mergeThis)</c>;</para></remarks>
        // IDL: HRESULT mergeAttributes (IHTMLElement* mergeThis);
        // VB6: Sub mergeAttributes (ByVal mergeThis As IHTMLElement)
        [DispId(-2147417049)]
        void mergeAttributes(IHTMLElement mergeThis);

        /// <summary><para><c>insertAdjacentElement</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>insertAdjacentElement</c> method was the following:  <c>HRESULT insertAdjacentElement (BSTR where, IHTMLElement* insertedElement, [out, retval] IHTMLElement** ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT insertAdjacentElement (BSTR where, IHTMLElement* insertedElement, [out, retval] IHTMLElement** ReturnValue);
        // VB6: Function insertAdjacentElement (ByVal where As String, ByVal insertedElement As IHTMLElement) As IHTMLElement
        [DispId(-2147417043)]
        IHTMLElement insertAdjacentElement([MarshalAs(UnmanagedType.BStr)] string where, IHTMLElement insertedElement);

        /// <summary><para><c>applyElement</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>applyElement</c> method was the following:  <c>HRESULT applyElement (IHTMLElement* apply, BSTR where, [out, retval] IHTMLElement** ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT applyElement (IHTMLElement* apply, BSTR where, [out, retval] IHTMLElement** ReturnValue);
        // VB6: Function applyElement (ByVal apply As IHTMLElement, ByVal where As String) As IHTMLElement
        [DispId(-2147417047)]
        IHTMLElement applyElement(IHTMLElement apply, [MarshalAs(UnmanagedType.BStr)] string where);

        /// <summary><para><c>getAdjacentText</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>getAdjacentText</c> method was the following:  <c>HRESULT getAdjacentText (BSTR where, [out, retval] BSTR* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT getAdjacentText (BSTR where, [out, retval] BSTR* ReturnValue);
        // VB6: Function getAdjacentText (ByVal where As String) As String
        [DispId(-2147417042)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string getAdjacentText([MarshalAs(UnmanagedType.BStr)] string where);

        /// <summary><para><c>replaceAdjacentText</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>replaceAdjacentText</c> method was the following:  <c>HRESULT replaceAdjacentText (BSTR where, BSTR newText, [out, retval] BSTR* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT replaceAdjacentText (BSTR where, BSTR newText, [out, retval] BSTR* ReturnValue);
        // VB6: Function replaceAdjacentText (ByVal where As String, ByVal newText As String) As String
        [DispId(-2147417041)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string replaceAdjacentText([MarshalAs(UnmanagedType.BStr)] string where, [MarshalAs(UnmanagedType.BStr)] string newText);

        /// <summary><para><c>addBehavior</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>addBehavior</c> method was the following:  <c>HRESULT addBehavior (BSTR bstrUrl, [in, optional] VARIANT* pvarFactory, [out, retval] long* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT addBehavior (BSTR bstrUrl, [in, optional] VARIANT* pvarFactory, [out, retval] long* ReturnValue);
        // VB6: Function addBehavior (ByVal bstrUrl As String, [pvarFactory As Any]) As Long
        [DispId(-2147417032)]
        int addBehavior([MarshalAs(UnmanagedType.BStr)] string bstrUrl, [In] ref object pvarFactory);

        /// <summary><para><c>removeBehavior</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>removeBehavior</c> method was the following:  <c>HRESULT removeBehavior (long cookie, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT removeBehavior (long cookie, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function removeBehavior (ByVal cookie As Long) As Boolean
        [DispId(-2147417031)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool removeBehavior(int cookie);

        /// <summary><para><c>getElementsByTagName</c> method of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>getElementsByTagName</c> method was the following:  <c>HRESULT getElementsByTagName (BSTR v, [out, retval] IHTMLElementCollection** ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT getElementsByTagName (BSTR v, [out, retval] IHTMLElementCollection** ReturnValue);
        // VB6: Function getElementsByTagName (ByVal v As String) As IHTMLElementCollection
        [DispId(-2147417027)]
        [return: MarshalAs(UnmanagedType.Interface)] //IHTMLElementCollection
        object getElementsByTagName([MarshalAs(UnmanagedType.BStr)] string v);

        /// <summary><para><c>accessKey</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>accessKey</c> property was the following:  <c>BSTR accessKey</c>;</para></remarks>
        // IDL: BSTR accessKey;
        // VB6: accessKey As String
        string accessKey
        {
            // IDL: HRESULT accessKey ([out, retval] BSTR* ReturnValue);
            // VB6: Function accessKey As String
            [DispId(-2147416107)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT accessKey (BSTR value);
            // VB6: Sub accessKey (ByVal value As String)
            [DispId(-2147416107)]
            set;
        }

        /// <summary><para><c>behaviorUrns</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>behaviorUrns</c> property was the following:  <c>IDispatch* behaviorUrns</c>;</para></remarks>
        // IDL: IDispatch* behaviorUrns;
        // VB6: behaviorUrns As IDispatch
        object behaviorUrns
        {
            // IDL: HRESULT behaviorUrns ([out, retval] IDispatch** ReturnValue);
            // VB6: Function behaviorUrns As IDispatch
            [DispId(-2147417030)]
            [return: MarshalAs(UnmanagedType.IDispatch)]
            get;
        }

        /// <summary><para><c>canHaveChildren</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>canHaveChildren</c> property was the following:  <c>VARIANT_BOOL canHaveChildren</c>;</para></remarks>
        // IDL: VARIANT_BOOL canHaveChildren;
        // VB6: canHaveChildren As Boolean
        bool canHaveChildren
        {
            // IDL: HRESULT canHaveChildren ([out, retval] VARIANT_BOOL* ReturnValue);
            // VB6: Function canHaveChildren As Boolean
            [DispId(-2147417040)]
            [return: MarshalAs(UnmanagedType.VariantBool)]
            get;
        }

        /// <summary><para><c>clientHeight</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>clientHeight</c> property was the following:  <c>long clientHeight</c>;</para></remarks>
        // IDL: long clientHeight;
        // VB6: clientHeight As Long
        int clientHeight
        {
            // IDL: HRESULT clientHeight ([out, retval] long* ReturnValue);
            // VB6: Function clientHeight As Long
            [DispId(-2147416093)]
            get;
        }

        /// <summary><para><c>clientLeft</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>clientLeft</c> property was the following:  <c>long clientLeft</c>;</para></remarks>
        // IDL: long clientLeft;
        // VB6: clientLeft As Long
        int clientLeft
        {
            // IDL: HRESULT clientLeft ([out, retval] long* ReturnValue);
            // VB6: Function clientLeft As Long
            [DispId(-2147416090)]
            get;
        }

        /// <summary><para><c>clientTop</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>clientTop</c> property was the following:  <c>long clientTop</c>;</para></remarks>
        // IDL: long clientTop;
        // VB6: clientTop As Long
        int clientTop
        {
            // IDL: HRESULT clientTop ([out, retval] long* ReturnValue);
            // VB6: Function clientTop As Long
            [DispId(-2147416091)]
            get;
        }

        /// <summary><para><c>clientWidth</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>clientWidth</c> property was the following:  <c>long clientWidth</c>;</para></remarks>
        // IDL: long clientWidth;
        // VB6: clientWidth As Long
        int clientWidth
        {
            // IDL: HRESULT clientWidth ([out, retval] long* ReturnValue);
            // VB6: Function clientWidth As Long
            [DispId(-2147416092)]
            get;
        }

        /// <summary><para><c>currentStyle</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>currentStyle</c> property was the following:  <c>IHTMLCurrentStyle* currentStyle</c>;</para></remarks>
        // IDL: IHTMLCurrentStyle* currentStyle;
        // VB6: currentStyle As IHTMLCurrentStyle
        object currentStyle
        {
            // IDL: HRESULT currentStyle ([out, retval] IHTMLCurrentStyle** ReturnValue);
            // VB6: Function currentStyle As IHTMLCurrentStyle
            [DispId(-2147417105)]
            [return: MarshalAs(UnmanagedType.Interface)] //IHTMLCurrentStyle
            get;
        }

        /// <summary><para><c>dir</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>dir</c> property was the following:  <c>BSTR dir</c>;</para></remarks>
        // IDL: BSTR dir;
        // VB6: dir As String
        string dir
        {
            // IDL: HRESULT dir ([out, retval] BSTR* ReturnValue);
            // VB6: Function dir As String
            [DispId(-2147412995)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT dir (BSTR value);
            // VB6: Sub dir (ByVal value As String)
            [DispId(-2147412995)]
            set;
        }

        /// <summary><para><c>onbeforecopy</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onbeforecopy</c> property was the following:  <c>VARIANT onbeforecopy</c>;</para></remarks>
        // IDL: VARIANT onbeforecopy;
        // VB6: onbeforecopy As Any
        object onbeforecopy
        {
            // IDL: HRESULT onbeforecopy ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onbeforecopy As Any
            [DispId(-2147412053)]
            get;
            // IDL: HRESULT onbeforecopy (VARIANT value);
            // VB6: Sub onbeforecopy (ByVal value As Any)
            [DispId(-2147412053)]
            set;
        }

        /// <summary><para><c>onbeforecut</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onbeforecut</c> property was the following:  <c>VARIANT onbeforecut</c>;</para></remarks>
        // IDL: VARIANT onbeforecut;
        // VB6: onbeforecut As Any
        object onbeforecut
        {
            // IDL: HRESULT onbeforecut ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onbeforecut As Any
            [DispId(-2147412054)]
            get;
            // IDL: HRESULT onbeforecut (VARIANT value);
            // VB6: Sub onbeforecut (ByVal value As Any)
            [DispId(-2147412054)]
            set;
        }

        /// <summary><para><c>onbeforeeditfocus</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onbeforeeditfocus</c> property was the following:  <c>VARIANT onbeforeeditfocus</c>;</para></remarks>
        // IDL: VARIANT onbeforeeditfocus;
        // VB6: onbeforeeditfocus As Any
        object onbeforeeditfocus
        {
            // IDL: HRESULT onbeforeeditfocus ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onbeforeeditfocus As Any
            [DispId(-2147412043)]
            get;
            // IDL: HRESULT onbeforeeditfocus (VARIANT value);
            // VB6: Sub onbeforeeditfocus (ByVal value As Any)
            [DispId(-2147412043)]
            set;
        }

        /// <summary><para><c>onbeforepaste</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onbeforepaste</c> property was the following:  <c>VARIANT onbeforepaste</c>;</para></remarks>
        // IDL: VARIANT onbeforepaste;
        // VB6: onbeforepaste As Any
        object onbeforepaste
        {
            // IDL: HRESULT onbeforepaste ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onbeforepaste As Any
            [DispId(-2147412052)]
            get;
            // IDL: HRESULT onbeforepaste (VARIANT value);
            // VB6: Sub onbeforepaste (ByVal value As Any)
            [DispId(-2147412052)]
            set;
        }

        /// <summary><para><c>onblur</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onblur</c> property was the following:  <c>VARIANT onblur</c>;</para></remarks>
        // IDL: VARIANT onblur;
        // VB6: onblur As Any
        object onblur
        {
            // IDL: HRESULT onblur ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onblur As Any
            [DispId(-2147412097)]
            get;
            // IDL: HRESULT onblur (VARIANT value);
            // VB6: Sub onblur (ByVal value As Any)
            [DispId(-2147412097)]
            set;
        }

        /// <summary><para><c>oncellchange</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>oncellchange</c> property was the following:  <c>VARIANT oncellchange</c>;</para></remarks>
        // IDL: VARIANT oncellchange;
        // VB6: oncellchange As Any
        object oncellchange
        {
            // IDL: HRESULT oncellchange ([out, retval] VARIANT* ReturnValue);
            // VB6: Function oncellchange As Any
            [DispId(-2147412048)]
            get;
            // IDL: HRESULT oncellchange (VARIANT value);
            // VB6: Sub oncellchange (ByVal value As Any)
            [DispId(-2147412048)]
            set;
        }

        /// <summary><para><c>oncontextmenu</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>oncontextmenu</c> property was the following:  <c>VARIANT oncontextmenu</c>;</para></remarks>
        // IDL: VARIANT oncontextmenu;
        // VB6: oncontextmenu As Any
        object oncontextmenu
        {
            // IDL: HRESULT oncontextmenu ([out, retval] VARIANT* ReturnValue);
            // VB6: Function oncontextmenu As Any
            [DispId(-2147412047)]
            get;
            // IDL: HRESULT oncontextmenu (VARIANT value);
            // VB6: Sub oncontextmenu (ByVal value As Any)
            [DispId(-2147412047)]
            set;
        }

        /// <summary><para><c>oncopy</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>oncopy</c> property was the following:  <c>VARIANT oncopy</c>;</para></remarks>
        // IDL: VARIANT oncopy;
        // VB6: oncopy As Any
        object oncopy
        {
            // IDL: HRESULT oncopy ([out, retval] VARIANT* ReturnValue);
            // VB6: Function oncopy As Any
            [DispId(-2147412056)]
            get;
            // IDL: HRESULT oncopy (VARIANT value);
            // VB6: Sub oncopy (ByVal value As Any)
            [DispId(-2147412056)]
            set;
        }

        /// <summary><para><c>oncut</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>oncut</c> property was the following:  <c>VARIANT oncut</c>;</para></remarks>
        // IDL: VARIANT oncut;
        // VB6: oncut As Any
        object oncut
        {
            // IDL: HRESULT oncut ([out, retval] VARIANT* ReturnValue);
            // VB6: Function oncut As Any
            [DispId(-2147412057)]
            get;
            // IDL: HRESULT oncut (VARIANT value);
            // VB6: Sub oncut (ByVal value As Any)
            [DispId(-2147412057)]
            set;
        }

        /// <summary><para><c>ondrag</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>ondrag</c> property was the following:  <c>VARIANT ondrag</c>;</para></remarks>
        // IDL: VARIANT ondrag;
        // VB6: ondrag As Any
        object ondrag
        {
            // IDL: HRESULT ondrag ([out, retval] VARIANT* ReturnValue);
            // VB6: Function ondrag As Any
            [DispId(-2147412063)]
            get;
            // IDL: HRESULT ondrag (VARIANT value);
            // VB6: Sub ondrag (ByVal value As Any)
            [DispId(-2147412063)]
            set;
        }

        /// <summary><para><c>ondragend</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>ondragend</c> property was the following:  <c>VARIANT ondragend</c>;</para></remarks>
        // IDL: VARIANT ondragend;
        // VB6: ondragend As Any
        object ondragend
        {
            // IDL: HRESULT ondragend ([out, retval] VARIANT* ReturnValue);
            // VB6: Function ondragend As Any
            [DispId(-2147412062)]
            get;
            // IDL: HRESULT ondragend (VARIANT value);
            // VB6: Sub ondragend (ByVal value As Any)
            [DispId(-2147412062)]
            set;
        }

        /// <summary><para><c>ondragenter</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>ondragenter</c> property was the following:  <c>VARIANT ondragenter</c>;</para></remarks>
        // IDL: VARIANT ondragenter;
        // VB6: ondragenter As Any
        object ondragenter
        {
            // IDL: HRESULT ondragenter ([out, retval] VARIANT* ReturnValue);
            // VB6: Function ondragenter As Any
            [DispId(-2147412061)]
            get;
            // IDL: HRESULT ondragenter (VARIANT value);
            // VB6: Sub ondragenter (ByVal value As Any)
            [DispId(-2147412061)]
            set;
        }

        /// <summary><para><c>ondragleave</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>ondragleave</c> property was the following:  <c>VARIANT ondragleave</c>;</para></remarks>
        // IDL: VARIANT ondragleave;
        // VB6: ondragleave As Any
        object ondragleave
        {
            // IDL: HRESULT ondragleave ([out, retval] VARIANT* ReturnValue);
            // VB6: Function ondragleave As Any
            [DispId(-2147412059)]
            get;
            // IDL: HRESULT ondragleave (VARIANT value);
            // VB6: Sub ondragleave (ByVal value As Any)
            [DispId(-2147412059)]
            set;
        }

        /// <summary><para><c>ondragover</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>ondragover</c> property was the following:  <c>VARIANT ondragover</c>;</para></remarks>
        // IDL: VARIANT ondragover;
        // VB6: ondragover As Any
        object ondragover
        {
            // IDL: HRESULT ondragover ([out, retval] VARIANT* ReturnValue);
            // VB6: Function ondragover As Any
            [DispId(-2147412060)]
            get;
            // IDL: HRESULT ondragover (VARIANT value);
            // VB6: Sub ondragover (ByVal value As Any)
            [DispId(-2147412060)]
            set;
        }

        /// <summary><para><c>ondrop</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>ondrop</c> property was the following:  <c>VARIANT ondrop</c>;</para></remarks>
        // IDL: VARIANT ondrop;
        // VB6: ondrop As Any
        object ondrop
        {
            // IDL: HRESULT ondrop ([out, retval] VARIANT* ReturnValue);
            // VB6: Function ondrop As Any
            [DispId(-2147412058)]
            get;
            // IDL: HRESULT ondrop (VARIANT value);
            // VB6: Sub ondrop (ByVal value As Any)
            [DispId(-2147412058)]
            set;
        }

        /// <summary><para><c>onfocus</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onfocus</c> property was the following:  <c>VARIANT onfocus</c>;</para></remarks>
        // IDL: VARIANT onfocus;
        // VB6: onfocus As Any
        object onfocus
        {
            // IDL: HRESULT onfocus ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onfocus As Any
            [DispId(-2147412098)]
            get;
            // IDL: HRESULT onfocus (VARIANT value);
            // VB6: Sub onfocus (ByVal value As Any)
            [DispId(-2147412098)]
            set;
        }

        /// <summary><para><c>onlosecapture</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onlosecapture</c> property was the following:  <c>VARIANT onlosecapture</c>;</para></remarks>
        // IDL: VARIANT onlosecapture;
        // VB6: onlosecapture As Any
        object onlosecapture
        {
            // IDL: HRESULT onlosecapture ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onlosecapture As Any
            [DispId(-2147412066)]
            get;
            // IDL: HRESULT onlosecapture (VARIANT value);
            // VB6: Sub onlosecapture (ByVal value As Any)
            [DispId(-2147412066)]
            set;
        }

        /// <summary><para><c>onpaste</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onpaste</c> property was the following:  <c>VARIANT onpaste</c>;</para></remarks>
        // IDL: VARIANT onpaste;
        // VB6: onpaste As Any
        object onpaste
        {
            // IDL: HRESULT onpaste ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onpaste As Any
            [DispId(-2147412055)]
            get;
            // IDL: HRESULT onpaste (VARIANT value);
            // VB6: Sub onpaste (ByVal value As Any)
            [DispId(-2147412055)]
            set;
        }

        /// <summary><para><c>onpropertychange</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onpropertychange</c> property was the following:  <c>VARIANT onpropertychange</c>;</para></remarks>
        // IDL: VARIANT onpropertychange;
        // VB6: onpropertychange As Any
        object onpropertychange
        {
            // IDL: HRESULT onpropertychange ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onpropertychange As Any
            [DispId(-2147412065)]
            get;
            // IDL: HRESULT onpropertychange (VARIANT value);
            // VB6: Sub onpropertychange (ByVal value As Any)
            [DispId(-2147412065)]
            set;
        }

        /// <summary><para><c>onreadystatechange</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onreadystatechange</c> property was the following:  <c>VARIANT onreadystatechange</c>;</para></remarks>
        // IDL: VARIANT onreadystatechange;
        // VB6: onreadystatechange As Any
        object onreadystatechange
        {
            // IDL: HRESULT onreadystatechange ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onreadystatechange As Any
            [DispId(-2147412087)]
            get;
            // IDL: HRESULT onreadystatechange (VARIANT value);
            // VB6: Sub onreadystatechange (ByVal value As Any)
            [DispId(-2147412087)]
            set;
        }

        /// <summary><para><c>onresize</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onresize</c> property was the following:  <c>VARIANT onresize</c>;</para></remarks>
        // IDL: VARIANT onresize;
        // VB6: onresize As Any
        object onresize
        {
            // IDL: HRESULT onresize ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onresize As Any
            [DispId(-2147412076)]
            get;
            // IDL: HRESULT onresize (VARIANT value);
            // VB6: Sub onresize (ByVal value As Any)
            [DispId(-2147412076)]
            set;
        }

        /// <summary><para><c>onrowsdelete</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onrowsdelete</c> property was the following:  <c>VARIANT onrowsdelete</c>;</para></remarks>
        // IDL: VARIANT onrowsdelete;
        // VB6: onrowsdelete As Any
        object onrowsdelete
        {
            // IDL: HRESULT onrowsdelete ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onrowsdelete As Any
            [DispId(-2147412050)]
            get;
            // IDL: HRESULT onrowsdelete (VARIANT value);
            // VB6: Sub onrowsdelete (ByVal value As Any)
            [DispId(-2147412050)]
            set;
        }

        /// <summary><para><c>onrowsinserted</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onrowsinserted</c> property was the following:  <c>VARIANT onrowsinserted</c>;</para></remarks>
        // IDL: VARIANT onrowsinserted;
        // VB6: onrowsinserted As Any
        object onrowsinserted
        {
            // IDL: HRESULT onrowsinserted ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onrowsinserted As Any
            [DispId(-2147412049)]
            get;
            // IDL: HRESULT onrowsinserted (VARIANT value);
            // VB6: Sub onrowsinserted (ByVal value As Any)
            [DispId(-2147412049)]
            set;
        }

        /// <summary><para><c>onscroll</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onscroll</c> property was the following:  <c>VARIANT onscroll</c>;</para></remarks>
        // IDL: VARIANT onscroll;
        // VB6: onscroll As Any
        object onscroll
        {
            // IDL: HRESULT onscroll ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onscroll As Any
            [DispId(-2147412081)]
            get;
            // IDL: HRESULT onscroll (VARIANT value);
            // VB6: Sub onscroll (ByVal value As Any)
            [DispId(-2147412081)]
            set;
        }

        /// <summary><para><c>readyState</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>readyState</c> property was the following:  <c>VARIANT readyState</c>;</para></remarks>
        // IDL: VARIANT readyState;
        // VB6: readyState As Any
        object readyState
        {
            // IDL: HRESULT readyState ([out, retval] VARIANT* ReturnValue);
            // VB6: Function readyState As Any
            [DispId(-2147412996)]
            get;
        }

        /// <summary><para><c>readyStateValue</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>readyStateValue</c> property was the following:  <c>long readyStateValue</c>;</para></remarks>
        // IDL: long readyStateValue;
        // VB6: readyStateValue As Long
        int readyStateValue
        {
            // IDL: HRESULT readyStateValue ([out, retval] long* ReturnValue);
            // VB6: Function readyStateValue As Long
            [DispId(-2147417028)]
            get;
        }

        /// <summary><para><c>runtimeStyle</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>runtimeStyle</c> property was the following:  <c>IHTMLStyle* runtimeStyle</c>;</para></remarks>
        // IDL: IHTMLStyle* runtimeStyle;
        // VB6: runtimeStyle As IHTMLStyle
        IHTMLStyle runtimeStyle
        {
            // IDL: HRESULT runtimeStyle ([out, retval] IHTMLStyle** ReturnValue);
            // VB6: Function runtimeStyle As IHTMLStyle
            [DispId(-2147417048)]
            get;
        }

        /// <summary><para><c>scopeName</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>scopeName</c> property was the following:  <c>BSTR scopeName</c>;</para></remarks>
        // IDL: BSTR scopeName;
        // VB6: scopeName As String
        string scopeName
        {
            // IDL: HRESULT scopeName ([out, retval] BSTR* ReturnValue);
            // VB6: Function scopeName As String
            [DispId(-2147417073)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }

        /// <summary><para><c>scrollHeight</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>scrollHeight</c> property was the following:  <c>long scrollHeight</c>;</para></remarks>
        // IDL: long scrollHeight;
        // VB6: scrollHeight As Long
        int scrollHeight
        {
            // IDL: HRESULT scrollHeight ([out, retval] long* ReturnValue);
            // VB6: Function scrollHeight As Long
            [DispId(-2147417055)]
            get;
        }

        /// <summary><para><c>scrollLeft</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>scrollLeft</c> property was the following:  <c>long scrollLeft</c>;</para></remarks>
        // IDL: long scrollLeft;
        // VB6: scrollLeft As Long
        int scrollLeft
        {
            // IDL: HRESULT scrollLeft ([out, retval] long* ReturnValue);
            // VB6: Function scrollLeft As Long
            [DispId(-2147417052)]
            get;
            // IDL: HRESULT scrollLeft (long value);
            // VB6: Sub scrollLeft (ByVal value As Long)
            [DispId(-2147417052)]
            set;
        }

        /// <summary><para><c>scrollTop</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>scrollTop</c> property was the following:  <c>long scrollTop</c>;</para></remarks>
        // IDL: long scrollTop;
        // VB6: scrollTop As Long
        int scrollTop
        {
            // IDL: HRESULT scrollTop ([out, retval] long* ReturnValue);
            // VB6: Function scrollTop As Long
            [DispId(-2147417053)]
            get;
            // IDL: HRESULT scrollTop (long value);
            // VB6: Sub scrollTop (ByVal value As Long)
            [DispId(-2147417053)]
            set;
        }

        /// <summary><para><c>scrollWidth</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>scrollWidth</c> property was the following:  <c>long scrollWidth</c>;</para></remarks>
        // IDL: long scrollWidth;
        // VB6: scrollWidth As Long
        int scrollWidth
        {
            // IDL: HRESULT scrollWidth ([out, retval] long* ReturnValue);
            // VB6: Function scrollWidth As Long
            [DispId(-2147417054)]
            get;
        }

        /// <summary><para><c>tabIndex</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>tabIndex</c> property was the following:  <c>short tabIndex</c>;</para></remarks>
        // IDL: short tabIndex;
        // VB6: tabIndex As Integer
        short tabIndex
        {
            // IDL: HRESULT tabIndex ([out, retval] short* ReturnValue);
            // VB6: Function tabIndex As Integer
            [DispId(-2147418097)]
            get;
            // IDL: HRESULT tabIndex (short value);
            // VB6: Sub tabIndex (ByVal value As Integer)
            [DispId(-2147418097)]
            set;
        }

        /// <summary><para><c>tagUrn</c> property of <c>IHTMLElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>tagUrn</c> property was the following:  <c>BSTR tagUrn</c>;</para></remarks>
        // IDL: BSTR tagUrn;
        // VB6: tagUrn As String
        string tagUrn
        {
            // IDL: HRESULT tagUrn ([out, retval] BSTR* ReturnValue);
            // VB6: Function tagUrn As String
            [DispId(-2147417029)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT tagUrn (BSTR value);
            // VB6: Sub tagUrn (ByVal value As String)
            [DispId(-2147417029)]
            set;
        }
    }
    #endregion

    #region IHTMLElement3 Interface
    /// <summary><para><c>IHTMLElement3</c> interface.</para></summary>
    [Guid("3050F673-98B5-11CF-BB82-00AA00BDCE0B")]
    [ComImport]
    [TypeLibType((short)4160)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IHTMLElement3
    {
        /// <summary><para><c>mergeAttributes</c> method of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>mergeAttributes</c> method was the following:  <c>HRESULT mergeAttributes (IHTMLElement* mergeThis, [in, optional] VARIANT* pvarFlags)</c>;</para></remarks>
        // IDL: HRESULT mergeAttributes (IHTMLElement* mergeThis, [in, optional] VARIANT* pvarFlags);
        // VB6: Sub mergeAttributes (ByVal mergeThis As IHTMLElement, [pvarFlags As Any])
        [DispId(-2147417016)]
        void mergeAttributes(IHTMLElement mergeThis, [In] ref object pvarFlags);

        /// <summary><para><c>setActive</c> method of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>setActive</c> method was the following:  <c>HRESULT setActive (void)</c>;</para></remarks>
        // IDL: HRESULT setActive (void);
        // VB6: Sub setActive
        [DispId(-2147417011)]
        void setActive();

        /// <summary><para><c>FireEvent</c> method of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>FireEvent</c> method was the following:  <c>HRESULT FireEvent (BSTR bstrEventName, [in, optional] VARIANT* pvarEventObject, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT FireEvent (BSTR bstrEventName, [in, optional] VARIANT* pvarEventObject, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function FireEvent (ByVal bstrEventName As String, [pvarEventObject As Any]) As Boolean
        [DispId(-2147417006)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool FireEvent([MarshalAs(UnmanagedType.BStr)] string bstrEventName, [In] ref object pvarEventObject);

        /// <summary><para><c>dragDrop</c> method of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>dragDrop</c> method was the following:  <c>HRESULT dragDrop ([out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT dragDrop ([out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function dragDrop As Boolean
        [DispId(-2147417005)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool dragDrop();

        /// <summary><para><c>canHaveHTML</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>canHaveHTML</c> property was the following:  <c>VARIANT_BOOL canHaveHTML</c>;</para></remarks>
        // IDL: VARIANT_BOOL canHaveHTML;
        // VB6: canHaveHTML As Boolean
        bool canHaveHTML
        {
            // IDL: HRESULT canHaveHTML ([out, retval] VARIANT_BOOL* ReturnValue);
            // VB6: Function canHaveHTML As Boolean
            [DispId(-2147417014)]
            [return: MarshalAs(UnmanagedType.VariantBool)]
            get;
        }

        /// <summary><para><c>contentEditable</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>contentEditable</c> property was the following:  <c>BSTR contentEditable</c>;</para></remarks>
        // IDL: BSTR contentEditable;
        // VB6: contentEditable As String
        string contentEditable
        {
            // IDL: HRESULT contentEditable ([out, retval] BSTR* ReturnValue);
            // VB6: Function contentEditable As String
            [DispId(-2147412950)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT contentEditable (BSTR value);
            // VB6: Sub contentEditable (ByVal value As String)
            [DispId(-2147412950)]
            set;
        }

        /// <summary><para><c>disabled</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>disabled</c> property was the following:  <c>VARIANT_BOOL disabled</c>;</para></remarks>
        // IDL: VARIANT_BOOL disabled;
        // VB6: disabled As Boolean
        bool disabled
        {
            // IDL: HRESULT disabled ([out, retval] VARIANT_BOOL* ReturnValue);
            // VB6: Function disabled As Boolean
            [DispId(-2147418036)]
            [return: MarshalAs(UnmanagedType.VariantBool)]
            get;
            // IDL: HRESULT disabled (VARIANT_BOOL value);
            // VB6: Sub disabled (ByVal value As Boolean)
            [DispId(-2147418036)]
            set;
        }

        /// <summary><para><c>glyphMode</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>glyphMode</c> property was the following:  <c>long glyphMode</c>;</para></remarks>
        // IDL: long glyphMode;
        // VB6: glyphMode As Long
        int glyphMode
        {
            // IDL: HRESULT glyphMode ([out, retval] long* ReturnValue);
            // VB6: Function glyphMode As Long
            [DispId(-2147417004)]
            get;
        }

        /// <summary><para><c>hideFocus</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>hideFocus</c> property was the following:  <c>VARIANT_BOOL hideFocus</c>;</para></remarks>
        // IDL: VARIANT_BOOL hideFocus;
        // VB6: hideFocus As Boolean
        bool hideFocus
        {
            // IDL: HRESULT hideFocus ([out, retval] VARIANT_BOOL* ReturnValue);
            // VB6: Function hideFocus As Boolean
            [DispId(-2147412949)]
            [return: MarshalAs(UnmanagedType.VariantBool)]
            get;
            // IDL: HRESULT hideFocus (VARIANT_BOOL value);
            // VB6: Sub hideFocus (ByVal value As Boolean)
            [DispId(-2147412949)]
            set;
        }

        /// <summary><para><c>inflateBlock</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>inflateBlock</c> property was the following:  <c>VARIANT_BOOL inflateBlock</c>;</para></remarks>
        // IDL: VARIANT_BOOL inflateBlock;
        // VB6: inflateBlock As Boolean
        bool inflateBlock
        {
            // IDL: HRESULT inflateBlock ([out, retval] VARIANT_BOOL* ReturnValue);
            // VB6: Function inflateBlock As Boolean
            [DispId(-2147417012)]
            [return: MarshalAs(UnmanagedType.VariantBool)]
            get;
            // IDL: HRESULT inflateBlock (VARIANT_BOOL value);
            // VB6: Sub inflateBlock (ByVal value As Boolean)
            [DispId(-2147417012)]
            set;
        }

        /// <summary><para><c>isContentEditable</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>isContentEditable</c> property was the following:  <c>VARIANT_BOOL isContentEditable</c>;</para></remarks>
        // IDL: VARIANT_BOOL isContentEditable;
        // VB6: isContentEditable As Boolean
        bool isContentEditable
        {
            // IDL: HRESULT isContentEditable ([out, retval] VARIANT_BOOL* ReturnValue);
            // VB6: Function isContentEditable As Boolean
            [DispId(-2147417010)]
            [return: MarshalAs(UnmanagedType.VariantBool)]
            get;
        }

        /// <summary><para><c>isDisabled</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>isDisabled</c> property was the following:  <c>VARIANT_BOOL isDisabled</c>;</para></remarks>
        // IDL: VARIANT_BOOL isDisabled;
        // VB6: isDisabled As Boolean
        bool isDisabled
        {
            // IDL: HRESULT isDisabled ([out, retval] VARIANT_BOOL* ReturnValue);
            // VB6: Function isDisabled As Boolean
            [DispId(-2147417007)]
            [return: MarshalAs(UnmanagedType.VariantBool)]
            get;
        }

        /// <summary><para><c>isMultiLine</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>isMultiLine</c> property was the following:  <c>VARIANT_BOOL isMultiLine</c>;</para></remarks>
        // IDL: VARIANT_BOOL isMultiLine;
        // VB6: isMultiLine As Boolean
        bool isMultiLine
        {
            // IDL: HRESULT isMultiLine ([out, retval] VARIANT_BOOL* ReturnValue);
            // VB6: Function isMultiLine As Boolean
            [DispId(-2147417015)]
            [return: MarshalAs(UnmanagedType.VariantBool)]
            get;
        }

        /// <summary><para><c>onactivate</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onactivate</c> property was the following:  <c>VARIANT onactivate</c>;</para></remarks>
        // IDL: VARIANT onactivate;
        // VB6: onactivate As Any
        object onactivate
        {
            // IDL: HRESULT onactivate ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onactivate As Any
            [DispId(-2147412025)]
            get;
            // IDL: HRESULT onactivate (VARIANT value);
            // VB6: Sub onactivate (ByVal value As Any)
            [DispId(-2147412025)]
            set;
        }

        /// <summary><para><c>onbeforedeactivate</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onbeforedeactivate</c> property was the following:  <c>VARIANT onbeforedeactivate</c>;</para></remarks>
        // IDL: VARIANT onbeforedeactivate;
        // VB6: onbeforedeactivate As Any
        object onbeforedeactivate
        {
            // IDL: HRESULT onbeforedeactivate ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onbeforedeactivate As Any
            [DispId(-2147412035)]
            get;
            // IDL: HRESULT onbeforedeactivate (VARIANT value);
            // VB6: Sub onbeforedeactivate (ByVal value As Any)
            [DispId(-2147412035)]
            set;
        }

        /// <summary><para><c>oncontrolselect</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>oncontrolselect</c> property was the following:  <c>VARIANT oncontrolselect</c>;</para></remarks>
        // IDL: VARIANT oncontrolselect;
        // VB6: oncontrolselect As Any
        object oncontrolselect
        {
            // IDL: HRESULT oncontrolselect ([out, retval] VARIANT* ReturnValue);
            // VB6: Function oncontrolselect As Any
            [DispId(-2147412033)]
            get;
            // IDL: HRESULT oncontrolselect (VARIANT value);
            // VB6: Sub oncontrolselect (ByVal value As Any)
            [DispId(-2147412033)]
            set;
        }

        /// <summary><para><c>ondeactivate</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>ondeactivate</c> property was the following:  <c>VARIANT ondeactivate</c>;</para></remarks>
        // IDL: VARIANT ondeactivate;
        // VB6: ondeactivate As Any
        object ondeactivate
        {
            // IDL: HRESULT ondeactivate ([out, retval] VARIANT* ReturnValue);
            // VB6: Function ondeactivate As Any
            [DispId(-2147412024)]
            get;
            // IDL: HRESULT ondeactivate (VARIANT value);
            // VB6: Sub ondeactivate (ByVal value As Any)
            [DispId(-2147412024)]
            set;
        }

        /// <summary><para><c>onlayoutcomplete</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onlayoutcomplete</c> property was the following:  <c>VARIANT onlayoutcomplete</c>;</para></remarks>
        // IDL: VARIANT onlayoutcomplete;
        // VB6: onlayoutcomplete As Any
        object onlayoutcomplete
        {
            // IDL: HRESULT onlayoutcomplete ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onlayoutcomplete As Any
            [DispId(-2147412039)]
            get;
            // IDL: HRESULT onlayoutcomplete (VARIANT value);
            // VB6: Sub onlayoutcomplete (ByVal value As Any)
            [DispId(-2147412039)]
            set;
        }

        /// <summary><para><c>onmouseenter</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onmouseenter</c> property was the following:  <c>VARIANT onmouseenter</c>;</para></remarks>
        // IDL: VARIANT onmouseenter;
        // VB6: onmouseenter As Any
        object onmouseenter
        {
            // IDL: HRESULT onmouseenter ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onmouseenter As Any
            [DispId(-2147412027)]
            get;
            // IDL: HRESULT onmouseenter (VARIANT value);
            // VB6: Sub onmouseenter (ByVal value As Any)
            [DispId(-2147412027)]
            set;
        }

        /// <summary><para><c>onmouseleave</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onmouseleave</c> property was the following:  <c>VARIANT onmouseleave</c>;</para></remarks>
        // IDL: VARIANT onmouseleave;
        // VB6: onmouseleave As Any
        object onmouseleave
        {
            // IDL: HRESULT onmouseleave ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onmouseleave As Any
            [DispId(-2147412026)]
            get;
            // IDL: HRESULT onmouseleave (VARIANT value);
            // VB6: Sub onmouseleave (ByVal value As Any)
            [DispId(-2147412026)]
            set;
        }

        /// <summary><para><c>onmove</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onmove</c> property was the following:  <c>VARIANT onmove</c>;</para></remarks>
        // IDL: VARIANT onmove;
        // VB6: onmove As Any
        object onmove
        {
            // IDL: HRESULT onmove ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onmove As Any
            [DispId(-2147412034)]
            get;
            // IDL: HRESULT onmove (VARIANT value);
            // VB6: Sub onmove (ByVal value As Any)
            [DispId(-2147412034)]
            set;
        }

        /// <summary><para><c>onmoveend</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onmoveend</c> property was the following:  <c>VARIANT onmoveend</c>;</para></remarks>
        // IDL: VARIANT onmoveend;
        // VB6: onmoveend As Any
        object onmoveend
        {
            // IDL: HRESULT onmoveend ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onmoveend As Any
            [DispId(-2147412030)]
            get;
            // IDL: HRESULT onmoveend (VARIANT value);
            // VB6: Sub onmoveend (ByVal value As Any)
            [DispId(-2147412030)]
            set;
        }

        /// <summary><para><c>onmovestart</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onmovestart</c> property was the following:  <c>VARIANT onmovestart</c>;</para></remarks>
        // IDL: VARIANT onmovestart;
        // VB6: onmovestart As Any
        object onmovestart
        {
            // IDL: HRESULT onmovestart ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onmovestart As Any
            [DispId(-2147412031)]
            get;
            // IDL: HRESULT onmovestart (VARIANT value);
            // VB6: Sub onmovestart (ByVal value As Any)
            [DispId(-2147412031)]
            set;
        }

        /// <summary><para><c>onpage</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onpage</c> property was the following:  <c>VARIANT onpage</c>;</para></remarks>
        // IDL: VARIANT onpage;
        // VB6: onpage As Any
        object onpage
        {
            // IDL: HRESULT onpage ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onpage As Any
            [DispId(-2147412038)]
            get;
            // IDL: HRESULT onpage (VARIANT value);
            // VB6: Sub onpage (ByVal value As Any)
            [DispId(-2147412038)]
            set;
        }

        /// <summary><para><c>onresizeend</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onresizeend</c> property was the following:  <c>VARIANT onresizeend</c>;</para></remarks>
        // IDL: VARIANT onresizeend;
        // VB6: onresizeend As Any
        object onresizeend
        {
            // IDL: HRESULT onresizeend ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onresizeend As Any
            [DispId(-2147412028)]
            get;
            // IDL: HRESULT onresizeend (VARIANT value);
            // VB6: Sub onresizeend (ByVal value As Any)
            [DispId(-2147412028)]
            set;
        }

        /// <summary><para><c>onresizestart</c> property of <c>IHTMLElement3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onresizestart</c> property was the following:  <c>VARIANT onresizestart</c>;</para></remarks>
        // IDL: VARIANT onresizestart;
        // VB6: onresizestart As Any
        object onresizestart
        {
            // IDL: HRESULT onresizestart ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onresizestart As Any
            [DispId(-2147412029)]
            get;
            // IDL: HRESULT onresizestart (VARIANT value);
            // VB6: Sub onresizestart (ByVal value As Any)
            [DispId(-2147412029)]
            set;
        }
    }
    #endregion

    #region IHTMLDocument Interface
    /// <summary><para><c>IHTMLDocument</c> interface.</para></summary>
    [Guid("626FC520-A41E-11CF-A731-00A0C9082637")]
    [ComImport]
    [TypeLibType((short)4160)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IHTMLDocument
    {
        /// <summary><para><c>Script</c> property of <c>IHTMLDocument</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>Script</c> property was the following:  <c>IDispatch* Script</c>;</para></remarks>
        // IDL: IDispatch* Script;
        // VB6: Script As IDispatch
        object Script
        {
            // IDL: HRESULT Script ([out, retval] IDispatch** ReturnValue);
            // VB6: Function Script As IDispatch
            [DispId(1001)]
            [return: MarshalAs(UnmanagedType.IDispatch)]
            get;
        }
    }
    #endregion

    #region IHTMLDocument2 Interface
    /// <summary><para><c>IHTMLDocument2</c> interface.</para></summary>
    [Guid("332C4425-26CB-11D0-B483-00C04FD90119")]
    [ComImport]
    [TypeLibType((short)4160)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IHTMLDocument2
    {
        /// <summary><para><c>write</c> method of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>write</c> method was the following:  <c>HRESULT write (SAFEARRAY() psarray)</c>;</para></remarks>
        // IDL: HRESULT write (SAFEARRAY() psarray);
        // VB6: Sub write (ByVal psarray() As Any)
        [DispId(1054)]
        void write([MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] object psarray);

        /// <summary><para><c>writeln</c> method of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>writeln</c> method was the following:  <c>HRESULT writeln (SAFEARRAY() psarray)</c>;</para></remarks>
        // IDL: HRESULT writeln (SAFEARRAY() psarray);
        // VB6: Sub writeln (ByVal psarray() As Any)
        [DispId(1055)] //VarEnum.VT_VARIANT
        void writeln([MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_VARIANT)] object psarray);

        /// <summary><para><c>open</c> method of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>open</c> method was the following:  <c>HRESULT open ([optional, defaultvalue("text/html")] BSTR url, [optional] VARIANT name, [optional] VARIANT features, [optional] VARIANT replace, [out, retval] IDispatch** ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT open ([optional, defaultvalue("text/html")] BSTR url, [optional] VARIANT name, [optional] VARIANT features, [optional] VARIANT replace, [out, retval] IDispatch** ReturnValue);
        // VB6: Function open ([ByVal url As String = "text/html"], [ByVal name As Any], [ByVal features As Any], [ByVal replace As Any]) As IDispatch
        [DispId(1056)]
        [return: MarshalAs(UnmanagedType.IDispatch)]
        object open([MarshalAs(UnmanagedType.BStr)] string url, object name, object features, object replace);

        /// <summary><para><c>close</c> method of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>close</c> method was the following:  <c>HRESULT close (void)</c>;</para></remarks>
        // IDL: HRESULT close (void);
        // VB6: Sub close
        [DispId(1057)]
        void close();

        /// <summary><para><c>clear</c> method of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>clear</c> method was the following:  <c>HRESULT clear (void)</c>;</para></remarks>
        // IDL: HRESULT clear (void);
        // VB6: Sub clear
        [DispId(1058)]
        void clear();

        /// <summary><para><c>queryCommandSupported</c> method of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>queryCommandSupported</c> method was the following:  <c>HRESULT queryCommandSupported (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT queryCommandSupported (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function queryCommandSupported (ByVal cmdID As String) As Boolean
        [DispId(1059)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool queryCommandSupported([MarshalAs(UnmanagedType.BStr)] string cmdID);

        /// <summary><para><c>queryCommandEnabled</c> method of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>queryCommandEnabled</c> method was the following:  <c>HRESULT queryCommandEnabled (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT queryCommandEnabled (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function queryCommandEnabled (ByVal cmdID As String) As Boolean
        [DispId(1060)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool queryCommandEnabled([MarshalAs(UnmanagedType.BStr)] string cmdID);

        /// <summary><para><c>queryCommandState</c> method of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>queryCommandState</c> method was the following:  <c>HRESULT queryCommandState (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT queryCommandState (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function queryCommandState (ByVal cmdID As String) As Boolean
        [DispId(1061)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool queryCommandState([MarshalAs(UnmanagedType.BStr)] string cmdID);

        /// <summary><para><c>queryCommandIndeterm</c> method of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>queryCommandIndeterm</c> method was the following:  <c>HRESULT queryCommandIndeterm (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT queryCommandIndeterm (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function queryCommandIndeterm (ByVal cmdID As String) As Boolean
        [DispId(1062)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool queryCommandIndeterm([MarshalAs(UnmanagedType.BStr)] string cmdID);

        /// <summary><para><c>queryCommandText</c> method of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>queryCommandText</c> method was the following:  <c>HRESULT queryCommandText (BSTR cmdID, [out, retval] BSTR* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT queryCommandText (BSTR cmdID, [out, retval] BSTR* ReturnValue);
        // VB6: Function queryCommandText (ByVal cmdID As String) As String
        [DispId(1063)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string queryCommandText([MarshalAs(UnmanagedType.BStr)] string cmdID);

        /// <summary><para><c>queryCommandValue</c> method of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>queryCommandValue</c> method was the following:  <c>HRESULT queryCommandValue (BSTR cmdID, [out, retval] VARIANT* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT queryCommandValue (BSTR cmdID, [out, retval] VARIANT* ReturnValue);
        // VB6: Function queryCommandValue (ByVal cmdID As String) As Any
        [DispId(1064)]
        object queryCommandValue([MarshalAs(UnmanagedType.BStr)] string cmdID);

        /// <summary><para><c>execCommand</c> method of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>execCommand</c> method was the following:  <c>HRESULT execCommand (BSTR cmdID, [optional, defaultvalue(0)] VARIANT_BOOL showUI, [optional] VARIANT value, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT execCommand (BSTR cmdID, [optional, defaultvalue(0)] VARIANT_BOOL showUI, [optional] VARIANT value, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function execCommand (ByVal cmdID As String, [ByVal showUI As Boolean = False], [ByVal value As Any]) As Boolean
        [DispId(1065)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool execCommand([MarshalAs(UnmanagedType.BStr)] string cmdID, [MarshalAs(UnmanagedType.VariantBool)] bool showUI, object value);

        /// <summary><para><c>execCommandShowHelp</c> method of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>execCommandShowHelp</c> method was the following:  <c>HRESULT execCommandShowHelp (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT execCommandShowHelp (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function execCommandShowHelp (ByVal cmdID As String) As Boolean
        [DispId(1066)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool execCommandShowHelp([MarshalAs(UnmanagedType.BStr)] string cmdID);

        /// <summary><para><c>createElement</c> method of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>createElement</c> method was the following:  <c>HRESULT createElement (BSTR eTag, [out, retval] IHTMLElement** ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT createElement (BSTR eTag, [out, retval] IHTMLElement** ReturnValue);
        // VB6: Function createElement (ByVal eTag As String) As IHTMLElement
        [DispId(1067)]
        IHTMLElement createElement([MarshalAs(UnmanagedType.BStr)] string eTag);

        /// <summary><para><c>elementFromPoint</c> method of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>elementFromPoint</c> method was the following:  <c>HRESULT elementFromPoint (long x, long y, [out, retval] IHTMLElement** ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT elementFromPoint (long x, long y, [out, retval] IHTMLElement** ReturnValue);
        // VB6: Function elementFromPoint (ByVal x As Long, ByVal y As Long) As IHTMLElement
        [DispId(1068)]
        IHTMLElement elementFromPoint(int x, int y);

        /// <summary><para><c>toString</c> method of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>toString</c> method was the following:  <c>HRESULT toString ([out, retval] BSTR* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT toString ([out, retval] BSTR* ReturnValue);
        // VB6: Function toString As String
        [DispId(1070)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string toString();

        /// <summary><para><c>createStyleSheet</c> method of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>createStyleSheet</c> method was the following:  <c>HRESULT createStyleSheet ([optional, defaultvalue("")] BSTR bstrHref, [optional, defaultvalue(-1)] long lIndex, [out, retval] IHTMLStyleSheet** ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT createStyleSheet ([optional, defaultvalue("")] BSTR bstrHref, [optional, defaultvalue(-1)] long lIndex, [out, retval] IHTMLStyleSheet** ReturnValue);
        // VB6: Function createStyleSheet ([ByVal bstrHref As String = ""], [ByVal lIndex As Long = -1]) As IHTMLStyleSheet
        [DispId(1071)]
        [return: MarshalAs(UnmanagedType.Interface)] //IHTMLStyleSheet
        object createStyleSheet([MarshalAs(UnmanagedType.BStr)] string bstrHref, int lIndex);

        /// <summary><para><c>activeElement</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>activeElement</c> property was the following:  <c>IHTMLElement* activeElement</c>;</para></remarks>
        // IDL: IHTMLElement* activeElement;
        // VB6: activeElement As IHTMLElement
        IHTMLElement activeElement
        {
            // IDL: HRESULT activeElement ([out, retval] IHTMLElement** ReturnValue);
            // VB6: Function activeElement As IHTMLElement
            [DispId(1005)]
            get;
        }

        /// <summary><para><c>alinkColor</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>alinkColor</c> property was the following:  <c>VARIANT alinkColor</c>;</para></remarks>
        // IDL: VARIANT alinkColor;
        // VB6: alinkColor As Any
        object alinkColor
        {
            // IDL: HRESULT alinkColor ([out, retval] VARIANT* ReturnValue);
            // VB6: Function alinkColor As Any
            [DispId(1022)]
            get;
            // IDL: HRESULT alinkColor (VARIANT value);
            // VB6: Sub alinkColor (ByVal value As Any)
            [DispId(1022)]
            set;
        }

        /// <summary><para><c>all</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>all</c> property was the following:  <c>IHTMLElementCollection* all</c>;</para></remarks>
        // IDL: IHTMLElementCollection* all;
        // VB6: all As IHTMLElementCollection
        object all
        {
            // IDL: HRESULT all ([out, retval] IHTMLElementCollection** ReturnValue);
            // VB6: Function all As IHTMLElementCollection
            [DispId(1003)]
            [return: MarshalAs(UnmanagedType.Interface)] //IHTMLElementCollection
            get;
        }

        /// <summary><para><c>anchors</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>anchors</c> property was the following:  <c>IHTMLElementCollection* anchors</c>;</para></remarks>
        // IDL: IHTMLElementCollection* anchors;
        // VB6: anchors As IHTMLElementCollection
        object anchors
        {
            // IDL: HRESULT anchors ([out, retval] IHTMLElementCollection** ReturnValue);
            // VB6: Function anchors As IHTMLElementCollection
            [DispId(1007)]
            [return: MarshalAs(UnmanagedType.Interface)] //IHTMLElementCollection
            get;
        }

        /// <summary><para><c>applets</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>applets</c> property was the following:  <c>IHTMLElementCollection* applets</c>;</para></remarks>
        // IDL: IHTMLElementCollection* applets;
        // VB6: applets As IHTMLElementCollection
        object applets
        {
            // IDL: HRESULT applets ([out, retval] IHTMLElementCollection** ReturnValue);
            // VB6: Function applets As IHTMLElementCollection
            [DispId(1008)]
            [return: MarshalAs(UnmanagedType.Interface)] //IHTMLElementCollection
            get;
        }

        /// <summary><para><c>bgColor</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>bgColor</c> property was the following:  <c>VARIANT bgColor</c>;</para></remarks>
        // IDL: VARIANT bgColor;
        // VB6: bgColor As Any
        object bgColor
        {
            // IDL: HRESULT bgColor ([out, retval] VARIANT* ReturnValue);
            // VB6: Function bgColor As Any
            [DispId(-501)]
            get;
            // IDL: HRESULT bgColor (VARIANT value);
            // VB6: Sub bgColor (ByVal value As Any)
            [DispId(-501)]
            set;
        }

        /// <summary><para><c>body</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>body</c> property was the following:  <c>IHTMLElement* body</c>;</para></remarks>
        // IDL: IHTMLElement* body;
        // VB6: body As IHTMLElement
        IHTMLElement body
        {
            // IDL: HRESULT body ([out, retval] IHTMLElement** ReturnValue);
            // VB6: Function body As IHTMLElement
            [DispId(1004)]
            get;
        }

        /// <summary><para><c>charset</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>charset</c> property was the following:  <c>BSTR charset</c>;</para></remarks>
        // IDL: BSTR charset;
        // VB6: charset As String
        string charset
        {
            // IDL: HRESULT charset ([out, retval] BSTR* ReturnValue);
            // VB6: Function charset As String
            [DispId(1032)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT charset (BSTR value);
            // VB6: Sub charset (ByVal value As String)
            [DispId(1032)]
            set;
        }

        /// <summary><para><c>cookie</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>cookie</c> property was the following:  <c>BSTR cookie</c>;</para></remarks>
        // IDL: BSTR cookie;
        // VB6: cookie As String
        string cookie
        {
            // IDL: HRESULT cookie ([out, retval] BSTR* ReturnValue);
            // VB6: Function cookie As String
            [DispId(1030)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT cookie (BSTR value);
            // VB6: Sub cookie (ByVal value As String)
            [DispId(1030)]
            set;
        }

        /// <summary><para><c>defaultCharset</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>defaultCharset</c> property was the following:  <c>BSTR defaultCharset</c>;</para></remarks>
        // IDL: BSTR defaultCharset;
        // VB6: defaultCharset As String
        string defaultCharset
        {
            // IDL: HRESULT defaultCharset ([out, retval] BSTR* ReturnValue);
            // VB6: Function defaultCharset As String
            [DispId(1033)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT defaultCharset (BSTR value);
            // VB6: Sub defaultCharset (ByVal value As String)
            [DispId(1033)]
            set;
        }

        /// <summary><para><c>designMode</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>designMode</c> property was the following:  <c>BSTR designMode</c>;</para></remarks>
        // IDL: BSTR designMode;
        // VB6: designMode As String
        string designMode
        {
            // IDL: HRESULT designMode ([out, retval] BSTR* ReturnValue);
            // VB6: Function designMode As String
            [DispId(1014)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT designMode (BSTR value);
            // VB6: Sub designMode (ByVal value As String)
            [DispId(1014)]
            set;
        }

        /// <summary><para><c>domain</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>domain</c> property was the following:  <c>BSTR domain</c>;</para></remarks>
        // IDL: BSTR domain;
        // VB6: domain As String
        string domain
        {
            // IDL: HRESULT domain ([out, retval] BSTR* ReturnValue);
            // VB6: Function domain As String
            [DispId(1029)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT domain (BSTR value);
            // VB6: Sub domain (ByVal value As String)
            [DispId(1029)]
            set;
        }

        /// <summary><para><c>embeds</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>embeds</c> property was the following:  <c>IHTMLElementCollection* embeds</c>;</para></remarks>
        // IDL: IHTMLElementCollection* embeds;
        // VB6: embeds As IHTMLElementCollection
        object embeds
        {
            // IDL: HRESULT embeds ([out, retval] IHTMLElementCollection** ReturnValue);
            // VB6: Function embeds As IHTMLElementCollection
            [DispId(1015)]
            [return: MarshalAs(UnmanagedType.Interface)] //IHTMLElementCollection
            get;
        }

        /// <summary><para><c>expando</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>expando</c> property was the following:  <c>VARIANT_BOOL expando</c>;</para></remarks>
        // IDL: VARIANT_BOOL expando;
        // VB6: expando As Boolean
        bool expando
        {
            // IDL: HRESULT expando ([out, retval] VARIANT_BOOL* ReturnValue);
            // VB6: Function expando As Boolean
            [DispId(1031)]
            [return: MarshalAs(UnmanagedType.VariantBool)]
            get;
            // IDL: HRESULT expando (VARIANT_BOOL value);
            // VB6: Sub expando (ByVal value As Boolean)
            [DispId(1031)]
            set;
        }

        /// <summary><para><c>fgColor</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>fgColor</c> property was the following:  <c>VARIANT fgColor</c>;</para></remarks>
        // IDL: VARIANT fgColor;
        // VB6: fgColor As Any
        object fgColor
        {
            // IDL: HRESULT fgColor ([out, retval] VARIANT* ReturnValue);
            // VB6: Function fgColor As Any
            [DispId(-2147413110)]
            get;
            // IDL: HRESULT fgColor (VARIANT value);
            // VB6: Sub fgColor (ByVal value As Any)
            [DispId(-2147413110)]
            set;
        }

        /// <summary><para><c>fileCreatedDate</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>fileCreatedDate</c> property was the following:  <c>BSTR fileCreatedDate</c>;</para></remarks>
        // IDL: BSTR fileCreatedDate;
        // VB6: fileCreatedDate As String
        string fileCreatedDate
        {
            // IDL: HRESULT fileCreatedDate ([out, retval] BSTR* ReturnValue);
            // VB6: Function fileCreatedDate As String
            [DispId(1043)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }

        /// <summary><para><c>fileModifiedDate</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>fileModifiedDate</c> property was the following:  <c>BSTR fileModifiedDate</c>;</para></remarks>
        // IDL: BSTR fileModifiedDate;
        // VB6: fileModifiedDate As String
        string fileModifiedDate
        {
            // IDL: HRESULT fileModifiedDate ([out, retval] BSTR* ReturnValue);
            // VB6: Function fileModifiedDate As String
            [DispId(1044)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }

        /// <summary><para><c>fileSize</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>fileSize</c> property was the following:  <c>BSTR fileSize</c>;</para></remarks>
        // IDL: BSTR fileSize;
        // VB6: fileSize As String
        string fileSize
        {
            // IDL: HRESULT fileSize ([out, retval] BSTR* ReturnValue);
            // VB6: Function fileSize As String
            [DispId(1042)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }

        /// <summary><para><c>fileUpdatedDate</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>fileUpdatedDate</c> property was the following:  <c>BSTR fileUpdatedDate</c>;</para></remarks>
        // IDL: BSTR fileUpdatedDate;
        // VB6: fileUpdatedDate As String
        string fileUpdatedDate
        {
            // IDL: HRESULT fileUpdatedDate ([out, retval] BSTR* ReturnValue);
            // VB6: Function fileUpdatedDate As String
            [DispId(1045)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }

        /// <summary><para><c>forms</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>forms</c> property was the following:  <c>IHTMLElementCollection* forms</c>;</para></remarks>
        // IDL: IHTMLElementCollection* forms;
        // VB6: forms As IHTMLElementCollection
        object forms
        {
            // IDL: HRESULT forms ([out, retval] IHTMLElementCollection** ReturnValue);
            // VB6: Function forms As IHTMLElementCollection
            [DispId(1010)]
            [return: MarshalAs(UnmanagedType.Interface)] //IHTMLElementCollection
            get;
        }

        /// <summary><para><c>frames</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>frames</c> property was the following:  <c>IHTMLFramesCollection2* frames</c>;</para></remarks>
        // IDL: IHTMLFramesCollection2* frames;
        // VB6: frames As IHTMLFramesCollection2
        object frames
        {
            // IDL: HRESULT frames ([out, retval] IHTMLFramesCollection2** ReturnValue);
            // VB6: Function frames As IHTMLFramesCollection2
            [DispId(1019)]
            [return: MarshalAs(UnmanagedType.Interface)] //IHTMLFramesCollection2
            get;
        }

        /// <summary><para><c>images</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>images</c> property was the following:  <c>IHTMLElementCollection* images</c>;</para></remarks>
        // IDL: IHTMLElementCollection* images;
        // VB6: images As IHTMLElementCollection
        object images
        {
            // IDL: HRESULT images ([out, retval] IHTMLElementCollection** ReturnValue);
            // VB6: Function images As IHTMLElementCollection
            [DispId(1011)]
            [return: MarshalAs(UnmanagedType.Interface)] //IHTMLElementCollection
            get;
        }

        /// <summary><para><c>lastModified</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>lastModified</c> property was the following:  <c>BSTR lastModified</c>;</para></remarks>
        // IDL: BSTR lastModified;
        // VB6: lastModified As String
        string lastModified
        {
            // IDL: HRESULT lastModified ([out, retval] BSTR* ReturnValue);
            // VB6: Function lastModified As String
            [DispId(1028)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }

        /// <summary><para><c>linkColor</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>linkColor</c> property was the following:  <c>VARIANT linkColor</c>;</para></remarks>
        // IDL: VARIANT linkColor;
        // VB6: linkColor As Any
        object linkColor
        {
            // IDL: HRESULT linkColor ([out, retval] VARIANT* ReturnValue);
            // VB6: Function linkColor As Any
            [DispId(1024)]
            get;
            // IDL: HRESULT linkColor (VARIANT value);
            // VB6: Sub linkColor (ByVal value As Any)
            [DispId(1024)]
            set;
        }

        /// <summary><para><c>links</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>links</c> property was the following:  <c>IHTMLElementCollection* links</c>;</para></remarks>
        // IDL: IHTMLElementCollection* links;
        // VB6: links As IHTMLElementCollection
        object links
        {
            // IDL: HRESULT links ([out, retval] IHTMLElementCollection** ReturnValue);
            // VB6: Function links As IHTMLElementCollection
            [DispId(1009)]
            [return: MarshalAs(UnmanagedType.Interface)] //IHTMLElementCollection
            get;
        }

        /// <summary><para><c>location</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>location</c> property was the following:  <c>IHTMLLocation* location</c>;</para></remarks>
        // IDL: IHTMLLocation* location;
        // VB6: location As IHTMLLocation
        object location
        {
            // IDL: HRESULT location ([out, retval] IHTMLLocation** ReturnValue);
            // VB6: Function location As IHTMLLocation
            [DispId(1026)]
            [return: MarshalAs(UnmanagedType.Interface)] //IHTMLLocation
            get;
        }

        /// <summary><para><c>mimeType</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>mimeType</c> property was the following:  <c>BSTR mimeType</c>;</para></remarks>
        // IDL: BSTR mimeType;
        // VB6: mimeType As String
        string mimeType
        {
            // IDL: HRESULT mimeType ([out, retval] BSTR* ReturnValue);
            // VB6: Function mimeType As String
            [DispId(1041)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }

        /// <summary><para><c>nameProp</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>nameProp</c> property was the following:  <c>BSTR nameProp</c>;</para></remarks>
        // IDL: BSTR nameProp;
        // VB6: nameProp As String
        string nameProp
        {
            // IDL: HRESULT nameProp ([out, retval] BSTR* ReturnValue);
            // VB6: Function nameProp As String
            [DispId(1048)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }

        /// <summary><para><c>onafterupdate</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onafterupdate</c> property was the following:  <c>VARIANT onafterupdate</c>;</para></remarks>
        // IDL: VARIANT onafterupdate;
        // VB6: onafterupdate As Any
        object onafterupdate
        {
            // IDL: HRESULT onafterupdate ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onafterupdate As Any
            [DispId(-2147412090)]
            get;
            // IDL: HRESULT onafterupdate (VARIANT value);
            // VB6: Sub onafterupdate (ByVal value As Any)
            [DispId(-2147412090)]
            set;
        }

        /// <summary><para><c>onbeforeupdate</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onbeforeupdate</c> property was the following:  <c>VARIANT onbeforeupdate</c>;</para></remarks>
        // IDL: VARIANT onbeforeupdate;
        // VB6: onbeforeupdate As Any
        object onbeforeupdate
        {
            // IDL: HRESULT onbeforeupdate ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onbeforeupdate As Any
            [DispId(-2147412091)]
            get;
            // IDL: HRESULT onbeforeupdate (VARIANT value);
            // VB6: Sub onbeforeupdate (ByVal value As Any)
            [DispId(-2147412091)]
            set;
        }

        /// <summary><para><c>onclick</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onclick</c> property was the following:  <c>VARIANT onclick</c>;</para></remarks>
        // IDL: VARIANT onclick;
        // VB6: onclick As Any
        object onclick
        {
            // IDL: HRESULT onclick ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onclick As Any
            [DispId(-2147412104)]
            get;
            // IDL: HRESULT onclick (VARIANT value);
            // VB6: Sub onclick (ByVal value As Any)
            [DispId(-2147412104)]
            set;
        }

        /// <summary><para><c>ondblclick</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>ondblclick</c> property was the following:  <c>VARIANT ondblclick</c>;</para></remarks>
        // IDL: VARIANT ondblclick;
        // VB6: ondblclick As Any
        object ondblclick
        {
            // IDL: HRESULT ondblclick ([out, retval] VARIANT* ReturnValue);
            // VB6: Function ondblclick As Any
            [DispId(-2147412103)]
            get;
            // IDL: HRESULT ondblclick (VARIANT value);
            // VB6: Sub ondblclick (ByVal value As Any)
            [DispId(-2147412103)]
            set;
        }

        /// <summary><para><c>ondragstart</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>ondragstart</c> property was the following:  <c>VARIANT ondragstart</c>;</para></remarks>
        // IDL: VARIANT ondragstart;
        // VB6: ondragstart As Any
        object ondragstart
        {
            // IDL: HRESULT ondragstart ([out, retval] VARIANT* ReturnValue);
            // VB6: Function ondragstart As Any
            [DispId(-2147412077)]
            get;
            // IDL: HRESULT ondragstart (VARIANT value);
            // VB6: Sub ondragstart (ByVal value As Any)
            [DispId(-2147412077)]
            set;
        }

        /// <summary><para><c>onerrorupdate</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onerrorupdate</c> property was the following:  <c>VARIANT onerrorupdate</c>;</para></remarks>
        // IDL: VARIANT onerrorupdate;
        // VB6: onerrorupdate As Any
        object onerrorupdate
        {
            // IDL: HRESULT onerrorupdate ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onerrorupdate As Any
            [DispId(-2147412074)]
            get;
            // IDL: HRESULT onerrorupdate (VARIANT value);
            // VB6: Sub onerrorupdate (ByVal value As Any)
            [DispId(-2147412074)]
            set;
        }

        /// <summary><para><c>onhelp</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onhelp</c> property was the following:  <c>VARIANT onhelp</c>;</para></remarks>
        // IDL: VARIANT onhelp;
        // VB6: onhelp As Any
        object onhelp
        {
            // IDL: HRESULT onhelp ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onhelp As Any
            [DispId(-2147412099)]
            get;
            // IDL: HRESULT onhelp (VARIANT value);
            // VB6: Sub onhelp (ByVal value As Any)
            [DispId(-2147412099)]
            set;
        }

        /// <summary><para><c>onkeydown</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onkeydown</c> property was the following:  <c>VARIANT onkeydown</c>;</para></remarks>
        // IDL: VARIANT onkeydown;
        // VB6: onkeydown As Any
        object onkeydown
        {
            // IDL: HRESULT onkeydown ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onkeydown As Any
            [DispId(-2147412107)]
            get;
            // IDL: HRESULT onkeydown (VARIANT value);
            // VB6: Sub onkeydown (ByVal value As Any)
            [DispId(-2147412107)]
            set;
        }

        /// <summary><para><c>onkeypress</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onkeypress</c> property was the following:  <c>VARIANT onkeypress</c>;</para></remarks>
        // IDL: VARIANT onkeypress;
        // VB6: onkeypress As Any
        object onkeypress
        {
            // IDL: HRESULT onkeypress ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onkeypress As Any
            [DispId(-2147412105)]
            get;
            // IDL: HRESULT onkeypress (VARIANT value);
            // VB6: Sub onkeypress (ByVal value As Any)
            [DispId(-2147412105)]
            set;
        }

        /// <summary><para><c>onkeyup</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onkeyup</c> property was the following:  <c>VARIANT onkeyup</c>;</para></remarks>
        // IDL: VARIANT onkeyup;
        // VB6: onkeyup As Any
        object onkeyup
        {
            // IDL: HRESULT onkeyup ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onkeyup As Any
            [DispId(-2147412106)]
            get;
            // IDL: HRESULT onkeyup (VARIANT value);
            // VB6: Sub onkeyup (ByVal value As Any)
            [DispId(-2147412106)]
            set;
        }

        /// <summary><para><c>onmousedown</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onmousedown</c> property was the following:  <c>VARIANT onmousedown</c>;</para></remarks>
        // IDL: VARIANT onmousedown;
        // VB6: onmousedown As Any
        object onmousedown
        {
            // IDL: HRESULT onmousedown ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onmousedown As Any
            [DispId(-2147412110)]
            get;
            // IDL: HRESULT onmousedown (VARIANT value);
            // VB6: Sub onmousedown (ByVal value As Any)
            [DispId(-2147412110)]
            set;
        }

        /// <summary><para><c>onmousemove</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onmousemove</c> property was the following:  <c>VARIANT onmousemove</c>;</para></remarks>
        // IDL: VARIANT onmousemove;
        // VB6: onmousemove As Any
        object onmousemove
        {
            // IDL: HRESULT onmousemove ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onmousemove As Any
            [DispId(-2147412108)]
            get;
            // IDL: HRESULT onmousemove (VARIANT value);
            // VB6: Sub onmousemove (ByVal value As Any)
            [DispId(-2147412108)]
            set;
        }

        /// <summary><para><c>onmouseout</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onmouseout</c> property was the following:  <c>VARIANT onmouseout</c>;</para></remarks>
        // IDL: VARIANT onmouseout;
        // VB6: onmouseout As Any
        object onmouseout
        {
            // IDL: HRESULT onmouseout ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onmouseout As Any
            [DispId(-2147412111)]
            get;
            // IDL: HRESULT onmouseout (VARIANT value);
            // VB6: Sub onmouseout (ByVal value As Any)
            [DispId(-2147412111)]
            set;
        }

        /// <summary><para><c>onmouseover</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onmouseover</c> property was the following:  <c>VARIANT onmouseover</c>;</para></remarks>
        // IDL: VARIANT onmouseover;
        // VB6: onmouseover As Any
        object onmouseover
        {
            // IDL: HRESULT onmouseover ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onmouseover As Any
            [DispId(-2147412112)]
            get;
            // IDL: HRESULT onmouseover (VARIANT value);
            // VB6: Sub onmouseover (ByVal value As Any)
            [DispId(-2147412112)]
            set;
        }

        /// <summary><para><c>onmouseup</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onmouseup</c> property was the following:  <c>VARIANT onmouseup</c>;</para></remarks>
        // IDL: VARIANT onmouseup;
        // VB6: onmouseup As Any
        object onmouseup
        {
            // IDL: HRESULT onmouseup ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onmouseup As Any
            [DispId(-2147412109)]
            get;
            // IDL: HRESULT onmouseup (VARIANT value);
            // VB6: Sub onmouseup (ByVal value As Any)
            [DispId(-2147412109)]
            set;
        }

        /// <summary><para><c>onreadystatechange</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onreadystatechange</c> property was the following:  <c>VARIANT onreadystatechange</c>;</para></remarks>
        // IDL: VARIANT onreadystatechange;
        // VB6: onreadystatechange As Any
        object onreadystatechange
        {
            // IDL: HRESULT onreadystatechange ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onreadystatechange As Any
            [DispId(-2147412087)]
            get;
            // IDL: HRESULT onreadystatechange (VARIANT value);
            // VB6: Sub onreadystatechange (ByVal value As Any)
            [DispId(-2147412087)]
            set;
        }

        /// <summary><para><c>onrowenter</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onrowenter</c> property was the following:  <c>VARIANT onrowenter</c>;</para></remarks>
        // IDL: VARIANT onrowenter;
        // VB6: onrowenter As Any
        object onrowenter
        {
            // IDL: HRESULT onrowenter ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onrowenter As Any
            [DispId(-2147412093)]
            get;
            // IDL: HRESULT onrowenter (VARIANT value);
            // VB6: Sub onrowenter (ByVal value As Any)
            [DispId(-2147412093)]
            set;
        }

        /// <summary><para><c>onrowexit</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onrowexit</c> property was the following:  <c>VARIANT onrowexit</c>;</para></remarks>
        // IDL: VARIANT onrowexit;
        // VB6: onrowexit As Any
        object onrowexit
        {
            // IDL: HRESULT onrowexit ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onrowexit As Any
            [DispId(-2147412094)]
            get;
            // IDL: HRESULT onrowexit (VARIANT value);
            // VB6: Sub onrowexit (ByVal value As Any)
            [DispId(-2147412094)]
            set;
        }

        /// <summary><para><c>onselectstart</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onselectstart</c> property was the following:  <c>VARIANT onselectstart</c>;</para></remarks>
        // IDL: VARIANT onselectstart;
        // VB6: onselectstart As Any
        object onselectstart
        {
            // IDL: HRESULT onselectstart ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onselectstart As Any
            [DispId(-2147412075)]
            get;
            // IDL: HRESULT onselectstart (VARIANT value);
            // VB6: Sub onselectstart (ByVal value As Any)
            [DispId(-2147412075)]
            set;
        }

        /// <summary><para><c>parentWindow</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>parentWindow</c> property was the following:  <c>IHTMLWindow2* parentWindow</c>;</para></remarks>
        // IDL: IHTMLWindow2* parentWindow;
        // VB6: parentWindow As IHTMLWindow2
        object parentWindow
        {
            // IDL: HRESULT parentWindow ([out, retval] IHTMLWindow2** ReturnValue);
            // VB6: Function parentWindow As IHTMLWindow2
            [DispId(1034)]
            [return: MarshalAs(UnmanagedType.Interface)] //IHTMLWindow2
            get;
        }

        /// <summary><para><c>plugins</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>plugins</c> property was the following:  <c>IHTMLElementCollection* plugins</c>;</para></remarks>
        // IDL: IHTMLElementCollection* plugins;
        // VB6: plugins As IHTMLElementCollection
        object plugins
        {
            // IDL: HRESULT plugins ([out, retval] IHTMLElementCollection** ReturnValue);
            // VB6: Function plugins As IHTMLElementCollection
            [DispId(1021)]
            [return: MarshalAs(UnmanagedType.Interface)] //IHTMLElementCollection
            get;
        }

        /// <summary><para><c>protocol</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>protocol</c> property was the following:  <c>BSTR protocol</c>;</para></remarks>
        // IDL: BSTR protocol;
        // VB6: protocol As String
        string protocol
        {
            // IDL: HRESULT protocol ([out, retval] BSTR* ReturnValue);
            // VB6: Function protocol As String
            [DispId(1047)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }

        /// <summary><para><c>readyState</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>readyState</c> property was the following:  <c>BSTR readyState</c>;</para></remarks>
        // IDL: BSTR readyState;
        // VB6: readyState As String
        string readyState
        {
            // IDL: HRESULT readyState ([out, retval] BSTR* ReturnValue);
            // VB6: Function readyState As String
            [DispId(1018)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }

        /// <summary><para><c>referrer</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>referrer</c> property was the following:  <c>BSTR referrer</c>;</para></remarks>
        // IDL: BSTR referrer;
        // VB6: referrer As String
        string referrer
        {
            // IDL: HRESULT referrer ([out, retval] BSTR* ReturnValue);
            // VB6: Function referrer As String
            [DispId(1027)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }

        /// <summary><para><c>Script</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>Script</c> property was the following:  <c>IDispatch* Script</c>;</para></remarks>
        // IDL: IDispatch* Script;
        // VB6: Script As IDispatch
        object Script
        {
            // IDL: HRESULT Script ([out, retval] IDispatch** ReturnValue);
            // VB6: Function Script As IDispatch
            [DispId(1001)]
            [return: MarshalAs(UnmanagedType.IDispatch)]
            get;
        }

        /// <summary><para><c>scripts</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>scripts</c> property was the following:  <c>IHTMLElementCollection* scripts</c>;</para></remarks>
        // IDL: IHTMLElementCollection* scripts;
        // VB6: scripts As IHTMLElementCollection
        object scripts
        {
            // IDL: HRESULT scripts ([out, retval] IHTMLElementCollection** ReturnValue);
            // VB6: Function scripts As IHTMLElementCollection
            [DispId(1013)]
            [return: MarshalAs(UnmanagedType.Interface)] //IHTMLElementCollection
            get;
        }

        /// <summary><para><c>security</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>security</c> property was the following:  <c>BSTR security</c>;</para></remarks>
        // IDL: BSTR security;
        // VB6: security As String
        string security
        {
            // IDL: HRESULT security ([out, retval] BSTR* ReturnValue);
            // VB6: Function security As String
            [DispId(1046)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }

        /// <summary><para><c>selection</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>selection</c> property was the following:  <c>IHTMLSelectionObject* selection</c>;</para></remarks>
        // IDL: IHTMLSelectionObject* selection;
        // VB6: selection As IHTMLSelectionObject
        object selection
        {
            // IDL: HRESULT selection ([out, retval] IHTMLSelectionObject** ReturnValue);
            // VB6: Function selection As IHTMLSelectionObject
            [DispId(1017)]
            [return: MarshalAs(UnmanagedType.Interface)] //IHTMLSelectionObject
            get;
        }

        /// <summary><para><c>styleSheets</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>styleSheets</c> property was the following:  <c>IHTMLStyleSheetsCollection* styleSheets</c>;</para></remarks>
        // IDL: IHTMLStyleSheetsCollection* styleSheets;
        // VB6: styleSheets As IHTMLStyleSheetsCollection
        object styleSheets
        {
            // IDL: HRESULT styleSheets ([out, retval] IHTMLStyleSheetsCollection** ReturnValue);
            // VB6: Function styleSheets As IHTMLStyleSheetsCollection
            [DispId(1069)]
            [return: MarshalAs(UnmanagedType.Interface)] //IHTMLStyleSheetsCollection
            get;
        }

        /// <summary><para><c>title</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>title</c> property was the following:  <c>BSTR title</c>;</para></remarks>
        // IDL: BSTR title;
        // VB6: title As String
        string title
        {
            // IDL: HRESULT title ([out, retval] BSTR* ReturnValue);
            // VB6: Function title As String
            [DispId(1012)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT title (BSTR value);
            // VB6: Sub title (ByVal value As String)
            [DispId(1012)]
            set;
        }

        /// <summary><para><c>url</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>url</c> property was the following:  <c>BSTR url</c>;</para></remarks>
        // IDL: BSTR url;
        // VB6: url As String
        string url
        {
            // IDL: HRESULT url ([out, retval] BSTR* ReturnValue);
            // VB6: Function url As String
            [DispId(1025)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT url (BSTR value);
            // VB6: Sub url (ByVal value As String)
            [DispId(1025)]
            set;
        }

        /// <summary><para><c>vlinkColor</c> property of <c>IHTMLDocument2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>vlinkColor</c> property was the following:  <c>VARIANT vlinkColor</c>;</para></remarks>
        // IDL: VARIANT vlinkColor;
        // VB6: vlinkColor As Any
        object vlinkColor
        {
            // IDL: HRESULT vlinkColor ([out, retval] VARIANT* ReturnValue);
            // VB6: Function vlinkColor As Any
            [DispId(1023)]
            get;
            // IDL: HRESULT vlinkColor (VARIANT value);
            // VB6: Sub vlinkColor (ByVal value As Any)
            [DispId(1023)]
            set;
        }
    }
    #endregion

    #region IHTMLDocument3 Interface
    /// <summary><para><c>IHTMLDocument3</c> interface.</para></summary>
    [Guid("3050F485-98B5-11CF-BB82-00AA00BDCE0B")]
    [ComImport]
    [TypeLibType((short)4160)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IHTMLDocument3
    {
        /// <summary><para><c>releaseCapture</c> method of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>releaseCapture</c> method was the following:  <c>HRESULT releaseCapture (void)</c>;</para></remarks>
        // IDL: HRESULT releaseCapture (void);
        // VB6: Sub releaseCapture
        [DispId(1072)]
        void releaseCapture();

        /// <summary><para><c>recalc</c> method of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>recalc</c> method was the following:  <c>HRESULT recalc ([optional, defaultvalue(0)] VARIANT_BOOL fForce)</c>;</para></remarks>
        // IDL: HRESULT recalc ([optional, defaultvalue(0)] VARIANT_BOOL fForce);
        // VB6: Sub recalc ([ByVal fForce As Boolean = False])
        [DispId(1073)]
        void recalc([MarshalAs(UnmanagedType.VariantBool)] bool fForce);

        /// <summary><para><c>createTextNode</c> method of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>createTextNode</c> method was the following:  <c>HRESULT createTextNode (BSTR text, [out, retval] IHTMLDOMNode** ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT createTextNode (BSTR text, [out, retval] IHTMLDOMNode** ReturnValue);
        // VB6: Function createTextNode (ByVal text As String) As IHTMLDOMNode
        [DispId(1074)]
        [return: MarshalAs(UnmanagedType.Interface)] //IHTMLDOMNode
        object createTextNode([MarshalAs(UnmanagedType.BStr)] string text);

        /// <summary><para><c>attachEvent</c> method of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>attachEvent</c> method was the following:  <c>HRESULT attachEvent (BSTR event, IDispatch* pdisp, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT attachEvent (BSTR event, IDispatch* pdisp, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function attachEvent (ByVal event As String, ByVal pdisp As IDispatch) As Boolean
        [DispId(-2147417605)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool attachEvent([MarshalAs(UnmanagedType.BStr)] string _event, [MarshalAs(UnmanagedType.IDispatch)] object pdisp);

        /// <summary><para><c>detachEvent</c> method of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>detachEvent</c> method was the following:  <c>HRESULT detachEvent (BSTR event, IDispatch* pdisp)</c>;</para></remarks>
        // IDL: HRESULT detachEvent (BSTR event, IDispatch* pdisp);
        // VB6: Sub detachEvent (ByVal event As String, ByVal pdisp As IDispatch)
        [DispId(-2147417604)]
        void detachEvent([MarshalAs(UnmanagedType.BStr)] string _event, [MarshalAs(UnmanagedType.IDispatch)] object pdisp);

        /// <summary><para><c>createDocumentFragment</c> method of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>createDocumentFragment</c> method was the following:  <c>HRESULT createDocumentFragment ([out, retval] IHTMLDocument2** ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT createDocumentFragment ([out, retval] IHTMLDocument2** ReturnValue);
        // VB6: Function createDocumentFragment As IHTMLDocument2
        [DispId(1076)]
        IHTMLDocument2 createDocumentFragment();

        /// <summary><para><c>getElementsByName</c> method of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>getElementsByName</c> method was the following:  <c>HRESULT getElementsByName (BSTR v, [out, retval] IHTMLElementCollection** ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT getElementsByName (BSTR v, [out, retval] IHTMLElementCollection** ReturnValue);
        // VB6: Function getElementsByName (ByVal v As String) As IHTMLElementCollection
        [DispId(1086)]
        [return: MarshalAs(UnmanagedType.Interface)] //IHTMLElementCollection
        object getElementsByName([MarshalAs(UnmanagedType.BStr)] string v);

        /// <summary><para><c>getElementById</c> method of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>getElementById</c> method was the following:  <c>HRESULT getElementById (BSTR v, [out, retval] IHTMLElement** ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT getElementById (BSTR v, [out, retval] IHTMLElement** ReturnValue);
        // VB6: Function getElementById (ByVal v As String) As IHTMLElement
        [DispId(1088)]
        IHTMLElement getElementById([MarshalAs(UnmanagedType.BStr)] string v);

        /// <summary><para><c>getElementsByTagName</c> method of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>getElementsByTagName</c> method was the following:  <c>HRESULT getElementsByTagName (BSTR v, [out, retval] IHTMLElementCollection** ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT getElementsByTagName (BSTR v, [out, retval] IHTMLElementCollection** ReturnValue);
        // VB6: Function getElementsByTagName (ByVal v As String) As IHTMLElementCollection
        [DispId(1087)]
        [return: MarshalAs(UnmanagedType.Interface)] //IHTMLElementCollection
        object getElementsByTagName([MarshalAs(UnmanagedType.BStr)] string v);

        /// <summary><para><c>baseUrl</c> property of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>baseUrl</c> property was the following:  <c>BSTR baseUrl</c>;</para></remarks>
        // IDL: BSTR baseUrl;
        // VB6: baseUrl As String
        string baseUrl
        {
            // IDL: HRESULT baseUrl ([out, retval] BSTR* ReturnValue);
            // VB6: Function baseUrl As String
            [DispId(1080)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT baseUrl (BSTR value);
            // VB6: Sub baseUrl (ByVal value As String)
            [DispId(1080)]
            set;
        }

        /// <summary><para><c>childNodes</c> property of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>childNodes</c> property was the following:  <c>IDispatch* childNodes</c>;</para></remarks>
        // IDL: IDispatch* childNodes;
        // VB6: childNodes As IDispatch
        object childNodes
        {
            // IDL: HRESULT childNodes ([out, retval] IDispatch** ReturnValue);
            // VB6: Function childNodes As IDispatch
            [DispId(-2147417063)]
            [return: MarshalAs(UnmanagedType.IDispatch)]
            get;
        }

        /// <summary><para><c>dir</c> property of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>dir</c> property was the following:  <c>BSTR dir</c>;</para></remarks>
        // IDL: BSTR dir;
        // VB6: dir As String
        string dir
        {
            // IDL: HRESULT dir ([out, retval] BSTR* ReturnValue);
            // VB6: Function dir As String
            [DispId(-2147412995)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT dir (BSTR value);
            // VB6: Sub dir (ByVal value As String)
            [DispId(-2147412995)]
            set;
        }

        /// <summary><para><c>documentElement</c> property of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>documentElement</c> property was the following:  <c>IHTMLElement* documentElement</c>;</para></remarks>
        // IDL: IHTMLElement* documentElement;
        // VB6: documentElement As IHTMLElement
        IHTMLElement documentElement
        {
            // IDL: HRESULT documentElement ([out, retval] IHTMLElement** ReturnValue);
            // VB6: Function documentElement As IHTMLElement
            [DispId(1075)]
            get;
        }

        /// <summary><para><c>enableDownload</c> property of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>enableDownload</c> property was the following:  <c>VARIANT_BOOL enableDownload</c>;</para></remarks>
        // IDL: VARIANT_BOOL enableDownload;
        // VB6: enableDownload As Boolean
        bool enableDownload
        {
            // IDL: HRESULT enableDownload ([out, retval] VARIANT_BOOL* ReturnValue);
            // VB6: Function enableDownload As Boolean
            [DispId(1079)]
            [return: MarshalAs(UnmanagedType.VariantBool)]
            get;
            // IDL: HRESULT enableDownload (VARIANT_BOOL value);
            // VB6: Sub enableDownload (ByVal value As Boolean)
            [DispId(1079)]
            set;
        }

        /// <summary><para><c>inheritStyleSheets</c> property of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>inheritStyleSheets</c> property was the following:  <c>VARIANT_BOOL inheritStyleSheets</c>;</para></remarks>
        // IDL: VARIANT_BOOL inheritStyleSheets;
        // VB6: inheritStyleSheets As Boolean
        bool inheritStyleSheets
        {
            // IDL: HRESULT inheritStyleSheets ([out, retval] VARIANT_BOOL* ReturnValue);
            // VB6: Function inheritStyleSheets As Boolean
            [DispId(1082)]
            [return: MarshalAs(UnmanagedType.VariantBool)]
            get;
            // IDL: HRESULT inheritStyleSheets (VARIANT_BOOL value);
            // VB6: Sub inheritStyleSheets (ByVal value As Boolean)
            [DispId(1082)]
            set;
        }

        /// <summary><para><c>onbeforeeditfocus</c> property of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onbeforeeditfocus</c> property was the following:  <c>VARIANT onbeforeeditfocus</c>;</para></remarks>
        // IDL: VARIANT onbeforeeditfocus;
        // VB6: onbeforeeditfocus As Any
        object onbeforeeditfocus
        {
            // IDL: HRESULT onbeforeeditfocus ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onbeforeeditfocus As Any
            [DispId(-2147412043)]
            get;
            // IDL: HRESULT onbeforeeditfocus (VARIANT value);
            // VB6: Sub onbeforeeditfocus (ByVal value As Any)
            [DispId(-2147412043)]
            set;
        }

        /// <summary><para><c>oncellchange</c> property of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>oncellchange</c> property was the following:  <c>VARIANT oncellchange</c>;</para></remarks>
        // IDL: VARIANT oncellchange;
        // VB6: oncellchange As Any
        object oncellchange
        {
            // IDL: HRESULT oncellchange ([out, retval] VARIANT* ReturnValue);
            // VB6: Function oncellchange As Any
            [DispId(-2147412048)]
            get;
            // IDL: HRESULT oncellchange (VARIANT value);
            // VB6: Sub oncellchange (ByVal value As Any)
            [DispId(-2147412048)]
            set;
        }

        /// <summary><para><c>oncontextmenu</c> property of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>oncontextmenu</c> property was the following:  <c>VARIANT oncontextmenu</c>;</para></remarks>
        // IDL: VARIANT oncontextmenu;
        // VB6: oncontextmenu As Any
        object oncontextmenu
        {
            // IDL: HRESULT oncontextmenu ([out, retval] VARIANT* ReturnValue);
            // VB6: Function oncontextmenu As Any
            [DispId(-2147412047)]
            get;
            // IDL: HRESULT oncontextmenu (VARIANT value);
            // VB6: Sub oncontextmenu (ByVal value As Any)
            [DispId(-2147412047)]
            set;
        }

        /// <summary><para><c>ondataavailable</c> property of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>ondataavailable</c> property was the following:  <c>VARIANT ondataavailable</c>;</para></remarks>
        // IDL: VARIANT ondataavailable;
        // VB6: ondataavailable As Any
        object ondataavailable
        {
            // IDL: HRESULT ondataavailable ([out, retval] VARIANT* ReturnValue);
            // VB6: Function ondataavailable As Any
            [DispId(-2147412071)]
            get;
            // IDL: HRESULT ondataavailable (VARIANT value);
            // VB6: Sub ondataavailable (ByVal value As Any)
            [DispId(-2147412071)]
            set;
        }

        /// <summary><para><c>ondatasetchanged</c> property of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>ondatasetchanged</c> property was the following:  <c>VARIANT ondatasetchanged</c>;</para></remarks>
        // IDL: VARIANT ondatasetchanged;
        // VB6: ondatasetchanged As Any
        object ondatasetchanged
        {
            // IDL: HRESULT ondatasetchanged ([out, retval] VARIANT* ReturnValue);
            // VB6: Function ondatasetchanged As Any
            [DispId(-2147412072)]
            get;
            // IDL: HRESULT ondatasetchanged (VARIANT value);
            // VB6: Sub ondatasetchanged (ByVal value As Any)
            [DispId(-2147412072)]
            set;
        }

        /// <summary><para><c>ondatasetcomplete</c> property of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>ondatasetcomplete</c> property was the following:  <c>VARIANT ondatasetcomplete</c>;</para></remarks>
        // IDL: VARIANT ondatasetcomplete;
        // VB6: ondatasetcomplete As Any
        object ondatasetcomplete
        {
            // IDL: HRESULT ondatasetcomplete ([out, retval] VARIANT* ReturnValue);
            // VB6: Function ondatasetcomplete As Any
            [DispId(-2147412070)]
            get;
            // IDL: HRESULT ondatasetcomplete (VARIANT value);
            // VB6: Sub ondatasetcomplete (ByVal value As Any)
            [DispId(-2147412070)]
            set;
        }

        /// <summary><para><c>onpropertychange</c> property of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onpropertychange</c> property was the following:  <c>VARIANT onpropertychange</c>;</para></remarks>
        // IDL: VARIANT onpropertychange;
        // VB6: onpropertychange As Any
        object onpropertychange
        {
            // IDL: HRESULT onpropertychange ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onpropertychange As Any
            [DispId(-2147412065)]
            get;
            // IDL: HRESULT onpropertychange (VARIANT value);
            // VB6: Sub onpropertychange (ByVal value As Any)
            [DispId(-2147412065)]
            set;
        }

        /// <summary><para><c>onrowsdelete</c> property of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onrowsdelete</c> property was the following:  <c>VARIANT onrowsdelete</c>;</para></remarks>
        // IDL: VARIANT onrowsdelete;
        // VB6: onrowsdelete As Any
        object onrowsdelete
        {
            // IDL: HRESULT onrowsdelete ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onrowsdelete As Any
            [DispId(-2147412050)]
            get;
            // IDL: HRESULT onrowsdelete (VARIANT value);
            // VB6: Sub onrowsdelete (ByVal value As Any)
            [DispId(-2147412050)]
            set;
        }

        /// <summary><para><c>onrowsinserted</c> property of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onrowsinserted</c> property was the following:  <c>VARIANT onrowsinserted</c>;</para></remarks>
        // IDL: VARIANT onrowsinserted;
        // VB6: onrowsinserted As Any
        object onrowsinserted
        {
            // IDL: HRESULT onrowsinserted ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onrowsinserted As Any
            [DispId(-2147412049)]
            get;
            // IDL: HRESULT onrowsinserted (VARIANT value);
            // VB6: Sub onrowsinserted (ByVal value As Any)
            [DispId(-2147412049)]
            set;
        }

        /// <summary><para><c>onstop</c> property of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onstop</c> property was the following:  <c>VARIANT onstop</c>;</para></remarks>
        // IDL: VARIANT onstop;
        // VB6: onstop As Any
        object onstop
        {
            // IDL: HRESULT onstop ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onstop As Any
            [DispId(-2147412044)]
            get;
            // IDL: HRESULT onstop (VARIANT value);
            // VB6: Sub onstop (ByVal value As Any)
            [DispId(-2147412044)]
            set;
        }

        /// <summary><para><c>parentDocument</c> property of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>parentDocument</c> property was the following:  <c>IHTMLDocument2* parentDocument</c>;</para></remarks>
        // IDL: IHTMLDocument2* parentDocument;
        // VB6: parentDocument As IHTMLDocument2
        IHTMLDocument2 parentDocument
        {
            // IDL: HRESULT parentDocument ([out, retval] IHTMLDocument2** ReturnValue);
            // VB6: Function parentDocument As IHTMLDocument2
            [DispId(1078)]
            get;
        }

        /// <summary><para><c>uniqueID</c> property of <c>IHTMLDocument3</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>uniqueID</c> property was the following:  <c>BSTR uniqueID</c>;</para></remarks>
        // IDL: BSTR uniqueID;
        // VB6: uniqueID As String
        string uniqueID
        {
            // IDL: HRESULT uniqueID ([out, retval] BSTR* ReturnValue);
            // VB6: Function uniqueID As String
            [DispId(1077)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }
    }
    #endregion

    #region IHTMLDocument4 interface

    [ComVisible(true), Guid("3050f69a-98b5-11cf-bb82-00aa00bdce0b"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)
    ]
    public interface IHTMLDocument4
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLDOCUMENT4_FOCUS)]
        void focus();

        [DispId(HTMLDispIDs.DISPID_IHTMLDOCUMENT4_HASFOCUS)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool hasFocus();

        [DispId(HTMLDispIDs.DISPID_IHTMLDOCUMENT4_ONSELECTIONCHANGE)]
        object onselectionchange { set; get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLDOCUMENT4_NAMESPACES)] //IHTMLNamespaceCollection
        object namespaces { [return: MarshalAs(UnmanagedType.IDispatch)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLDOCUMENT4_CREATEDOCUMENTFROMURL)]
        IHTMLDocument2 createDocumentFromUrl([In, MarshalAs(UnmanagedType.BStr)] String bstrUrl, [In, MarshalAs(UnmanagedType.BStr)] String bstrOptions);

        [DispId(HTMLDispIDs.DISPID_IHTMLDOCUMENT4_MEDIA)]
        String media { set; [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLDOCUMENT4_CREATEEVENTOBJECT)]
        IHTMLEventObj createEventObject();

        [DispId(HTMLDispIDs.DISPID_IHTMLDOCUMENT4_FIREEVENT)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool fireEvent([In, MarshalAs(UnmanagedType.BStr)] String bstrEventName, [In] object pvarEventObject);

        [DispId(HTMLDispIDs.DISPID_IHTMLDOCUMENT4_CREATERENDERSTYLE)]
        [return: MarshalAs(UnmanagedType.Interface)]
        object /*IHTMLRenderStyle*/ createRenderStyle([In, MarshalAs(UnmanagedType.BStr)] String v);

        [DispId(HTMLDispIDs.DISPID_IHTMLDOCUMENT4_ONCONTROLSELECT)]
        object oncontrolselect { set; get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLDOCUMENT4_URLUNENCODED)]
        String URLUnencoded { [return: MarshalAs(UnmanagedType.BStr)] get;}
    }

    #endregion

    #region IHTMLDocument5 Interface

    [ComImport, ComVisible(true), Guid("3050f80c-98b5-11cf-bb82-00aa00bdce0b"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)
    ]
    public interface IHTMLDocument5
    {
        //VARIANT
        [DispId(HTMLDispIDs.DISPID_IHTMLDOCUMENT5_ONMOUSEWHEEL)]
        object onmousewheel { set; get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLDOCUMENT5_DOCTYPE)]
        object getDoctype { [return: MarshalAs(UnmanagedType.IDispatch)] get;} //IHTMLDOMNode

        [DispId(HTMLDispIDs.DISPID_IHTMLDOCUMENT5_IMPLEMENTATION)]
        object getImplementation { [return: MarshalAs(UnmanagedType.IDispatch)] get;} //IHTMLDOMImplementation

        [DispId(HTMLDispIDs.DISPID_IHTMLDOCUMENT5_CREATEATTRIBUTE)]
        [return: MarshalAs(UnmanagedType.IDispatch)]
        object /*IHTMLDOMAttribute*/ createAttribute([In, MarshalAs(UnmanagedType.BStr)] String bstrattrName);

        [DispId(HTMLDispIDs.DISPID_IHTMLDOCUMENT5_CREATECOMMENT)]
        [return: MarshalAs(UnmanagedType.IDispatch)]
        object /*IHTMLDOMNode*/ createComment([In, MarshalAs(UnmanagedType.BStr)] String bstrdata);

        [DispId(HTMLDispIDs.DISPID_IHTMLDOCUMENT5_ONFOCUSIN)]
        object onfocusin { set; get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLDOCUMENT5_ONFOCUSOUT)]
        object onfocusout { set; get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLDOCUMENT5_ONACTIVATE)]
        object onactivate { set; get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLDOCUMENT5_ONDEACTIVATE)]
        object ondeactivate { set; get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLDOCUMENT5_ONBEFOREACTIVATE)]
        object onbeforeactivate { set; get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLDOCUMENT5_ONBEFOREDEACTIVATE)]
        object onbeforedeactivate { set; get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLDOCUMENT5_COMPATMODE)]
        String compatMode { [return: MarshalAs(UnmanagedType.BStr)] get;}
    }

    #endregion

    #region IHTMLStyle Interface
    /// <summary><para><c>IHTMLStyle</c> interface.</para></summary>
    [Guid("3050F25E-98B5-11CF-BB82-00AA00BDCE0B")]
    [ComImport]
    [TypeLibType((short)4160)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IHTMLStyle
    {
        /// <summary><para><c>setAttribute</c> method of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>setAttribute</c> method was the following:  <c>HRESULT setAttribute (BSTR strAttributeName, VARIANT AttributeValue, [optional, defaultvalue(1)] long lFlags)</c>;</para></remarks>
        // IDL: HRESULT setAttribute (BSTR strAttributeName, VARIANT AttributeValue, [optional, defaultvalue(1)] long lFlags);
        // VB6: Sub setAttribute (ByVal strAttributeName As String, ByVal AttributeValue As Any, [ByVal lFlags As Long = 1])
        [DispId(-2147417611)]
        void setAttribute([MarshalAs(UnmanagedType.BStr)] string strAttributeName, object AttributeValue, int lFlags);

        /// <summary><para><c>getAttribute</c> method of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>getAttribute</c> method was the following:  <c>HRESULT getAttribute (BSTR strAttributeName, [optional, defaultvalue(0)] long lFlags, [out, retval] VARIANT* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT getAttribute (BSTR strAttributeName, [optional, defaultvalue(0)] long lFlags, [out, retval] VARIANT* ReturnValue);
        // VB6: Function getAttribute (ByVal strAttributeName As String, [ByVal lFlags As Long = 0]) As Any
        [DispId(-2147417610)]
        object getAttribute([MarshalAs(UnmanagedType.BStr)] string strAttributeName, int lFlags);

        /// <summary><para><c>removeAttribute</c> method of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>removeAttribute</c> method was the following:  <c>HRESULT removeAttribute (BSTR strAttributeName, [optional, defaultvalue(1)] long lFlags, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT removeAttribute (BSTR strAttributeName, [optional, defaultvalue(1)] long lFlags, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function removeAttribute (ByVal strAttributeName As String, [ByVal lFlags As Long = 1]) As Boolean
        [DispId(-2147417609)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool removeAttribute([MarshalAs(UnmanagedType.BStr)] string strAttributeName, int lFlags);

        /// <summary><para><c>toString</c> method of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>toString</c> method was the following:  <c>HRESULT toString ([out, retval] BSTR* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT toString ([out, retval] BSTR* ReturnValue);
        // VB6: Function toString As String
        [DispId(-2147414104)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string toString();

        /// <summary><para><c>background</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>background</c> property was the following:  <c>BSTR background</c>;</para></remarks>
        // IDL: BSTR background;
        // VB6: background As String
        string background
        {
            // IDL: HRESULT background ([out, retval] BSTR* ReturnValue);
            // VB6: Function background As String
            [DispId(-2147413080)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT background (BSTR value);
            // VB6: Sub background (ByVal value As String)
            [DispId(-2147413080)]
            set;
        }

        /// <summary><para><c>backgroundAttachment</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>backgroundAttachment</c> property was the following:  <c>BSTR backgroundAttachment</c>;</para></remarks>
        // IDL: BSTR backgroundAttachment;
        // VB6: backgroundAttachment As String
        string backgroundAttachment
        {
            // IDL: HRESULT backgroundAttachment ([out, retval] BSTR* ReturnValue);
            // VB6: Function backgroundAttachment As String
            [DispId(-2147413067)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT backgroundAttachment (BSTR value);
            // VB6: Sub backgroundAttachment (ByVal value As String)
            [DispId(-2147413067)]
            set;
        }

        /// <summary><para><c>backgroundColor</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>backgroundColor</c> property was the following:  <c>VARIANT backgroundColor</c>;</para></remarks>
        // IDL: VARIANT backgroundColor;
        // VB6: backgroundColor As Any
        object backgroundColor
        {
            // IDL: HRESULT backgroundColor ([out, retval] VARIANT* ReturnValue);
            // VB6: Function backgroundColor As Any
            [DispId(-501)]
            get;
            // IDL: HRESULT backgroundColor (VARIANT value);
            // VB6: Sub backgroundColor (ByVal value As Any)
            [DispId(-501)]
            set;
        }

        /// <summary><para><c>backgroundImage</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>backgroundImage</c> property was the following:  <c>BSTR backgroundImage</c>;</para></remarks>
        // IDL: BSTR backgroundImage;
        // VB6: backgroundImage As String
        string backgroundImage
        {
            // IDL: HRESULT backgroundImage ([out, retval] BSTR* ReturnValue);
            // VB6: Function backgroundImage As String
            [DispId(-2147413111)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT backgroundImage (BSTR value);
            // VB6: Sub backgroundImage (ByVal value As String)
            [DispId(-2147413111)]
            set;
        }

        /// <summary><para><c>backgroundPosition</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>backgroundPosition</c> property was the following:  <c>BSTR backgroundPosition</c>;</para></remarks>
        // IDL: BSTR backgroundPosition;
        // VB6: backgroundPosition As String
        string backgroundPosition
        {
            // IDL: HRESULT backgroundPosition ([out, retval] BSTR* ReturnValue);
            // VB6: Function backgroundPosition As String
            [DispId(-2147413066)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT backgroundPosition (BSTR value);
            // VB6: Sub backgroundPosition (ByVal value As String)
            [DispId(-2147413066)]
            set;
        }

        /// <summary><para><c>backgroundPositionX</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>backgroundPositionX</c> property was the following:  <c>VARIANT backgroundPositionX</c>;</para></remarks>
        // IDL: VARIANT backgroundPositionX;
        // VB6: backgroundPositionX As Any
        object backgroundPositionX
        {
            // IDL: HRESULT backgroundPositionX ([out, retval] VARIANT* ReturnValue);
            // VB6: Function backgroundPositionX As Any
            [DispId(-2147413079)]
            get;
            // IDL: HRESULT backgroundPositionX (VARIANT value);
            // VB6: Sub backgroundPositionX (ByVal value As Any)
            [DispId(-2147413079)]
            set;
        }

        /// <summary><para><c>backgroundPositionY</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>backgroundPositionY</c> property was the following:  <c>VARIANT backgroundPositionY</c>;</para></remarks>
        // IDL: VARIANT backgroundPositionY;
        // VB6: backgroundPositionY As Any
        object backgroundPositionY
        {
            // IDL: HRESULT backgroundPositionY ([out, retval] VARIANT* ReturnValue);
            // VB6: Function backgroundPositionY As Any
            [DispId(-2147413078)]
            get;
            // IDL: HRESULT backgroundPositionY (VARIANT value);
            // VB6: Sub backgroundPositionY (ByVal value As Any)
            [DispId(-2147413078)]
            set;
        }

        /// <summary><para><c>backgroundRepeat</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>backgroundRepeat</c> property was the following:  <c>BSTR backgroundRepeat</c>;</para></remarks>
        // IDL: BSTR backgroundRepeat;
        // VB6: backgroundRepeat As String
        string backgroundRepeat
        {
            // IDL: HRESULT backgroundRepeat ([out, retval] BSTR* ReturnValue);
            // VB6: Function backgroundRepeat As String
            [DispId(-2147413068)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT backgroundRepeat (BSTR value);
            // VB6: Sub backgroundRepeat (ByVal value As String)
            [DispId(-2147413068)]
            set;
        }

        /// <summary><para><c>border</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>border</c> property was the following:  <c>BSTR border</c>;</para></remarks>
        // IDL: BSTR border;
        // VB6: border As String
        string border
        {
            // IDL: HRESULT border ([out, retval] BSTR* ReturnValue);
            // VB6: Function border As String
            [DispId(-2147413063)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT border (BSTR value);
            // VB6: Sub border (ByVal value As String)
            [DispId(-2147413063)]
            set;
        }

        /// <summary><para><c>borderBottom</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>borderBottom</c> property was the following:  <c>BSTR borderBottom</c>;</para></remarks>
        // IDL: BSTR borderBottom;
        // VB6: borderBottom As String
        string borderBottom
        {
            // IDL: HRESULT borderBottom ([out, retval] BSTR* ReturnValue);
            // VB6: Function borderBottom As String
            [DispId(-2147413060)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT borderBottom (BSTR value);
            // VB6: Sub borderBottom (ByVal value As String)
            [DispId(-2147413060)]
            set;
        }

        /// <summary><para><c>borderBottomColor</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>borderBottomColor</c> property was the following:  <c>VARIANT borderBottomColor</c>;</para></remarks>
        // IDL: VARIANT borderBottomColor;
        // VB6: borderBottomColor As Any
        object borderBottomColor
        {
            // IDL: HRESULT borderBottomColor ([out, retval] VARIANT* ReturnValue);
            // VB6: Function borderBottomColor As Any
            [DispId(-2147413055)]
            get;
            // IDL: HRESULT borderBottomColor (VARIANT value);
            // VB6: Sub borderBottomColor (ByVal value As Any)
            [DispId(-2147413055)]
            set;
        }

        /// <summary><para><c>borderBottomStyle</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>borderBottomStyle</c> property was the following:  <c>BSTR borderBottomStyle</c>;</para></remarks>
        // IDL: BSTR borderBottomStyle;
        // VB6: borderBottomStyle As String
        string borderBottomStyle
        {
            // IDL: HRESULT borderBottomStyle ([out, retval] BSTR* ReturnValue);
            // VB6: Function borderBottomStyle As String
            [DispId(-2147413045)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT borderBottomStyle (BSTR value);
            // VB6: Sub borderBottomStyle (ByVal value As String)
            [DispId(-2147413045)]
            set;
        }

        /// <summary><para><c>borderBottomWidth</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>borderBottomWidth</c> property was the following:  <c>VARIANT borderBottomWidth</c>;</para></remarks>
        // IDL: VARIANT borderBottomWidth;
        // VB6: borderBottomWidth As Any
        object borderBottomWidth
        {
            // IDL: HRESULT borderBottomWidth ([out, retval] VARIANT* ReturnValue);
            // VB6: Function borderBottomWidth As Any
            [DispId(-2147413050)]
            get;
            // IDL: HRESULT borderBottomWidth (VARIANT value);
            // VB6: Sub borderBottomWidth (ByVal value As Any)
            [DispId(-2147413050)]
            set;
        }

        /// <summary><para><c>borderColor</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>borderColor</c> property was the following:  <c>BSTR borderColor</c>;</para></remarks>
        // IDL: BSTR borderColor;
        // VB6: borderColor As String
        string borderColor
        {
            // IDL: HRESULT borderColor ([out, retval] BSTR* ReturnValue);
            // VB6: Function borderColor As String
            [DispId(-2147413058)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT borderColor (BSTR value);
            // VB6: Sub borderColor (ByVal value As String)
            [DispId(-2147413058)]
            set;
        }

        /// <summary><para><c>borderLeft</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>borderLeft</c> property was the following:  <c>BSTR borderLeft</c>;</para></remarks>
        // IDL: BSTR borderLeft;
        // VB6: borderLeft As String
        string borderLeft
        {
            // IDL: HRESULT borderLeft ([out, retval] BSTR* ReturnValue);
            // VB6: Function borderLeft As String
            [DispId(-2147413059)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT borderLeft (BSTR value);
            // VB6: Sub borderLeft (ByVal value As String)
            [DispId(-2147413059)]
            set;
        }

        /// <summary><para><c>borderLeftColor</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>borderLeftColor</c> property was the following:  <c>VARIANT borderLeftColor</c>;</para></remarks>
        // IDL: VARIANT borderLeftColor;
        // VB6: borderLeftColor As Any
        object borderLeftColor
        {
            // IDL: HRESULT borderLeftColor ([out, retval] VARIANT* ReturnValue);
            // VB6: Function borderLeftColor As Any
            [DispId(-2147413054)]
            get;
            // IDL: HRESULT borderLeftColor (VARIANT value);
            // VB6: Sub borderLeftColor (ByVal value As Any)
            [DispId(-2147413054)]
            set;
        }

        /// <summary><para><c>borderLeftStyle</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>borderLeftStyle</c> property was the following:  <c>BSTR borderLeftStyle</c>;</para></remarks>
        // IDL: BSTR borderLeftStyle;
        // VB6: borderLeftStyle As String
        string borderLeftStyle
        {
            // IDL: HRESULT borderLeftStyle ([out, retval] BSTR* ReturnValue);
            // VB6: Function borderLeftStyle As String
            [DispId(-2147413044)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT borderLeftStyle (BSTR value);
            // VB6: Sub borderLeftStyle (ByVal value As String)
            [DispId(-2147413044)]
            set;
        }

        /// <summary><para><c>borderLeftWidth</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>borderLeftWidth</c> property was the following:  <c>VARIANT borderLeftWidth</c>;</para></remarks>
        // IDL: VARIANT borderLeftWidth;
        // VB6: borderLeftWidth As Any
        object borderLeftWidth
        {
            // IDL: HRESULT borderLeftWidth ([out, retval] VARIANT* ReturnValue);
            // VB6: Function borderLeftWidth As Any
            [DispId(-2147413049)]
            get;
            // IDL: HRESULT borderLeftWidth (VARIANT value);
            // VB6: Sub borderLeftWidth (ByVal value As Any)
            [DispId(-2147413049)]
            set;
        }

        /// <summary><para><c>borderRight</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>borderRight</c> property was the following:  <c>BSTR borderRight</c>;</para></remarks>
        // IDL: BSTR borderRight;
        // VB6: borderRight As String
        string borderRight
        {
            // IDL: HRESULT borderRight ([out, retval] BSTR* ReturnValue);
            // VB6: Function borderRight As String
            [DispId(-2147413061)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT borderRight (BSTR value);
            // VB6: Sub borderRight (ByVal value As String)
            [DispId(-2147413061)]
            set;
        }

        /// <summary><para><c>borderRightColor</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>borderRightColor</c> property was the following:  <c>VARIANT borderRightColor</c>;</para></remarks>
        // IDL: VARIANT borderRightColor;
        // VB6: borderRightColor As Any
        object borderRightColor
        {
            // IDL: HRESULT borderRightColor ([out, retval] VARIANT* ReturnValue);
            // VB6: Function borderRightColor As Any
            [DispId(-2147413056)]
            get;
            // IDL: HRESULT borderRightColor (VARIANT value);
            // VB6: Sub borderRightColor (ByVal value As Any)
            [DispId(-2147413056)]
            set;
        }

        /// <summary><para><c>borderRightStyle</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>borderRightStyle</c> property was the following:  <c>BSTR borderRightStyle</c>;</para></remarks>
        // IDL: BSTR borderRightStyle;
        // VB6: borderRightStyle As String
        string borderRightStyle
        {
            // IDL: HRESULT borderRightStyle ([out, retval] BSTR* ReturnValue);
            // VB6: Function borderRightStyle As String
            [DispId(-2147413046)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT borderRightStyle (BSTR value);
            // VB6: Sub borderRightStyle (ByVal value As String)
            [DispId(-2147413046)]
            set;
        }

        /// <summary><para><c>borderRightWidth</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>borderRightWidth</c> property was the following:  <c>VARIANT borderRightWidth</c>;</para></remarks>
        // IDL: VARIANT borderRightWidth;
        // VB6: borderRightWidth As Any
        object borderRightWidth
        {
            // IDL: HRESULT borderRightWidth ([out, retval] VARIANT* ReturnValue);
            // VB6: Function borderRightWidth As Any
            [DispId(-2147413051)]
            get;
            // IDL: HRESULT borderRightWidth (VARIANT value);
            // VB6: Sub borderRightWidth (ByVal value As Any)
            [DispId(-2147413051)]
            set;
        }

        /// <summary><para><c>borderStyle</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>borderStyle</c> property was the following:  <c>BSTR borderStyle</c>;</para></remarks>
        // IDL: BSTR borderStyle;
        // VB6: borderStyle As String
        string borderStyle
        {
            // IDL: HRESULT borderStyle ([out, retval] BSTR* ReturnValue);
            // VB6: Function borderStyle As String
            [DispId(-2147413048)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT borderStyle (BSTR value);
            // VB6: Sub borderStyle (ByVal value As String)
            [DispId(-2147413048)]
            set;
        }

        /// <summary><para><c>borderTop</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>borderTop</c> property was the following:  <c>BSTR borderTop</c>;</para></remarks>
        // IDL: BSTR borderTop;
        // VB6: borderTop As String
        string borderTop
        {
            // IDL: HRESULT borderTop ([out, retval] BSTR* ReturnValue);
            // VB6: Function borderTop As String
            [DispId(-2147413062)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT borderTop (BSTR value);
            // VB6: Sub borderTop (ByVal value As String)
            [DispId(-2147413062)]
            set;
        }

        /// <summary><para><c>borderTopColor</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>borderTopColor</c> property was the following:  <c>VARIANT borderTopColor</c>;</para></remarks>
        // IDL: VARIANT borderTopColor;
        // VB6: borderTopColor As Any
        object borderTopColor
        {
            // IDL: HRESULT borderTopColor ([out, retval] VARIANT* ReturnValue);
            // VB6: Function borderTopColor As Any
            [DispId(-2147413057)]
            get;
            // IDL: HRESULT borderTopColor (VARIANT value);
            // VB6: Sub borderTopColor (ByVal value As Any)
            [DispId(-2147413057)]
            set;
        }

        /// <summary><para><c>borderTopStyle</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>borderTopStyle</c> property was the following:  <c>BSTR borderTopStyle</c>;</para></remarks>
        // IDL: BSTR borderTopStyle;
        // VB6: borderTopStyle As String
        string borderTopStyle
        {
            // IDL: HRESULT borderTopStyle ([out, retval] BSTR* ReturnValue);
            // VB6: Function borderTopStyle As String
            [DispId(-2147413047)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT borderTopStyle (BSTR value);
            // VB6: Sub borderTopStyle (ByVal value As String)
            [DispId(-2147413047)]
            set;
        }

        /// <summary><para><c>borderTopWidth</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>borderTopWidth</c> property was the following:  <c>VARIANT borderTopWidth</c>;</para></remarks>
        // IDL: VARIANT borderTopWidth;
        // VB6: borderTopWidth As Any
        object borderTopWidth
        {
            // IDL: HRESULT borderTopWidth ([out, retval] VARIANT* ReturnValue);
            // VB6: Function borderTopWidth As Any
            [DispId(-2147413052)]
            get;
            // IDL: HRESULT borderTopWidth (VARIANT value);
            // VB6: Sub borderTopWidth (ByVal value As Any)
            [DispId(-2147413052)]
            set;
        }

        /// <summary><para><c>borderWidth</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>borderWidth</c> property was the following:  <c>BSTR borderWidth</c>;</para></remarks>
        // IDL: BSTR borderWidth;
        // VB6: borderWidth As String
        string borderWidth
        {
            // IDL: HRESULT borderWidth ([out, retval] BSTR* ReturnValue);
            // VB6: Function borderWidth As String
            [DispId(-2147413053)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT borderWidth (BSTR value);
            // VB6: Sub borderWidth (ByVal value As String)
            [DispId(-2147413053)]
            set;
        }

        /// <summary><para><c>clear</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>clear</c> property was the following:  <c>BSTR clear</c>;</para></remarks>
        // IDL: BSTR clear;
        // VB6: clear As String
        string clear
        {
            // IDL: HRESULT clear ([out, retval] BSTR* ReturnValue);
            // VB6: Function clear As String
            [DispId(-2147413096)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT clear (BSTR value);
            // VB6: Sub clear (ByVal value As String)
            [DispId(-2147413096)]
            set;
        }

        /// <summary><para><c>clip</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>clip</c> property was the following:  <c>BSTR clip</c>;</para></remarks>
        // IDL: BSTR clip;
        // VB6: clip As String
        string clip
        {
            // IDL: HRESULT clip ([out, retval] BSTR* ReturnValue);
            // VB6: Function clip As String
            [DispId(-2147413020)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT clip (BSTR value);
            // VB6: Sub clip (ByVal value As String)
            [DispId(-2147413020)]
            set;
        }

        /// <summary><para><c>color</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>color</c> property was the following:  <c>VARIANT color</c>;</para></remarks>
        // IDL: VARIANT color;
        // VB6: color As Any
        object color
        {
            // IDL: HRESULT color ([out, retval] VARIANT* ReturnValue);
            // VB6: Function color As Any
            [DispId(-2147413110)]
            get;
            // IDL: HRESULT color (VARIANT value);
            // VB6: Sub color (ByVal value As Any)
            [DispId(-2147413110)]
            set;
        }

        /// <summary><para><c>cssText</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>cssText</c> property was the following:  <c>BSTR cssText</c>;</para></remarks>
        // IDL: BSTR cssText;
        // VB6: cssText As String
        string cssText
        {
            // IDL: HRESULT cssText ([out, retval] BSTR* ReturnValue);
            // VB6: Function cssText As String
            [DispId(-2147413013)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT cssText (BSTR value);
            // VB6: Sub cssText (ByVal value As String)
            [DispId(-2147413013)]
            set;
        }

        /// <summary><para><c>cursor</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>cursor</c> property was the following:  <c>BSTR cursor</c>;</para></remarks>
        // IDL: BSTR cursor;
        // VB6: cursor As String
        string cursor
        {
            // IDL: HRESULT cursor ([out, retval] BSTR* ReturnValue);
            // VB6: Function cursor As String
            [DispId(-2147413010)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT cursor (BSTR value);
            // VB6: Sub cursor (ByVal value As String)
            [DispId(-2147413010)]
            set;
        }

        /// <summary><para><c>display</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>display</c> property was the following:  <c>BSTR display</c>;</para></remarks>
        // IDL: BSTR display;
        // VB6: display As String
        string display
        {
            // IDL: HRESULT display ([out, retval] BSTR* ReturnValue);
            // VB6: Function display As String
            [DispId(-2147413041)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT display (BSTR value);
            // VB6: Sub display (ByVal value As String)
            [DispId(-2147413041)]
            set;
        }

        /// <summary><para><c>filter</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>filter</c> property was the following:  <c>BSTR filter</c>;</para></remarks>
        // IDL: BSTR filter;
        // VB6: filter As String
        string filter
        {
            // IDL: HRESULT filter ([out, retval] BSTR* ReturnValue);
            // VB6: Function filter As String
            [DispId(-2147413030)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT filter (BSTR value);
            // VB6: Sub filter (ByVal value As String)
            [DispId(-2147413030)]
            set;
        }

        /// <summary><para><c>font</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>font</c> property was the following:  <c>BSTR font</c>;</para></remarks>
        // IDL: BSTR font;
        // VB6: font As String
        string font
        {
            // IDL: HRESULT font ([out, retval] BSTR* ReturnValue);
            // VB6: Function font As String
            [DispId(-2147413071)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT font (BSTR value);
            // VB6: Sub font (ByVal value As String)
            [DispId(-2147413071)]
            set;
        }

        /// <summary><para><c>fontFamily</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>fontFamily</c> property was the following:  <c>BSTR fontFamily</c>;</para></remarks>
        // IDL: BSTR fontFamily;
        // VB6: fontFamily As String
        string fontFamily
        {
            // IDL: HRESULT fontFamily ([out, retval] BSTR* ReturnValue);
            // VB6: Function fontFamily As String
            [DispId(-2147413094)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT fontFamily (BSTR value);
            // VB6: Sub fontFamily (ByVal value As String)
            [DispId(-2147413094)]
            set;
        }

        /// <summary><para><c>fontSize</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>fontSize</c> property was the following:  <c>VARIANT fontSize</c>;</para></remarks>
        // IDL: VARIANT fontSize;
        // VB6: fontSize As Any
        object fontSize
        {
            // IDL: HRESULT fontSize ([out, retval] VARIANT* ReturnValue);
            // VB6: Function fontSize As Any
            [DispId(-2147413093)]
            get;
            // IDL: HRESULT fontSize (VARIANT value);
            // VB6: Sub fontSize (ByVal value As Any)
            [DispId(-2147413093)]
            set;
        }

        /// <summary><para><c>fontStyle</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>fontStyle</c> property was the following:  <c>BSTR fontStyle</c>;</para></remarks>
        // IDL: BSTR fontStyle;
        // VB6: fontStyle As String
        string fontStyle
        {
            // IDL: HRESULT fontStyle ([out, retval] BSTR* ReturnValue);
            // VB6: Function fontStyle As String
            [DispId(-2147413088)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT fontStyle (BSTR value);
            // VB6: Sub fontStyle (ByVal value As String)
            [DispId(-2147413088)]
            set;
        }

        /// <summary><para><c>fontVariant</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>fontVariant</c> property was the following:  <c>BSTR fontVariant</c>;</para></remarks>
        // IDL: BSTR fontVariant;
        // VB6: fontVariant As String
        string fontVariant
        {
            // IDL: HRESULT fontVariant ([out, retval] BSTR* ReturnValue);
            // VB6: Function fontVariant As String
            [DispId(-2147413087)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT fontVariant (BSTR value);
            // VB6: Sub fontVariant (ByVal value As String)
            [DispId(-2147413087)]
            set;
        }

        /// <summary><para><c>fontWeight</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>fontWeight</c> property was the following:  <c>BSTR fontWeight</c>;</para></remarks>
        // IDL: BSTR fontWeight;
        // VB6: fontWeight As String
        string fontWeight
        {
            // IDL: HRESULT fontWeight ([out, retval] BSTR* ReturnValue);
            // VB6: Function fontWeight As String
            [DispId(-2147413085)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT fontWeight (BSTR value);
            // VB6: Sub fontWeight (ByVal value As String)
            [DispId(-2147413085)]
            set;
        }

        /// <summary><para><c>height</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>height</c> property was the following:  <c>VARIANT height</c>;</para></remarks>
        // IDL: VARIANT height;
        // VB6: height As Any
        object height
        {
            // IDL: HRESULT height ([out, retval] VARIANT* ReturnValue);
            // VB6: Function height As Any
            [DispId(-2147418106)]
            get;
            // IDL: HRESULT height (VARIANT value);
            // VB6: Sub height (ByVal value As Any)
            [DispId(-2147418106)]
            set;
        }

        /// <summary><para><c>left</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>left</c> property was the following:  <c>VARIANT left</c>;</para></remarks>
        // IDL: VARIANT left;
        // VB6: left As Any
        object left
        {
            // IDL: HRESULT left ([out, retval] VARIANT* ReturnValue);
            // VB6: Function left As Any
            [DispId(-2147418109)]
            get;
            // IDL: HRESULT left (VARIANT value);
            // VB6: Sub left (ByVal value As Any)
            [DispId(-2147418109)]
            set;
        }

        /// <summary><para><c>letterSpacing</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>letterSpacing</c> property was the following:  <c>VARIANT letterSpacing</c>;</para></remarks>
        // IDL: VARIANT letterSpacing;
        // VB6: letterSpacing As Any
        object letterSpacing
        {
            // IDL: HRESULT letterSpacing ([out, retval] VARIANT* ReturnValue);
            // VB6: Function letterSpacing As Any
            [DispId(-2147413104)]
            get;
            // IDL: HRESULT letterSpacing (VARIANT value);
            // VB6: Sub letterSpacing (ByVal value As Any)
            [DispId(-2147413104)]
            set;
        }

        /// <summary><para><c>lineHeight</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>lineHeight</c> property was the following:  <c>VARIANT lineHeight</c>;</para></remarks>
        // IDL: VARIANT lineHeight;
        // VB6: lineHeight As Any
        object lineHeight
        {
            // IDL: HRESULT lineHeight ([out, retval] VARIANT* ReturnValue);
            // VB6: Function lineHeight As Any
            [DispId(-2147413106)]
            get;
            // IDL: HRESULT lineHeight (VARIANT value);
            // VB6: Sub lineHeight (ByVal value As Any)
            [DispId(-2147413106)]
            set;
        }

        /// <summary><para><c>listStyle</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>listStyle</c> property was the following:  <c>BSTR listStyle</c>;</para></remarks>
        // IDL: BSTR listStyle;
        // VB6: listStyle As String
        string listStyle
        {
            // IDL: HRESULT listStyle ([out, retval] BSTR* ReturnValue);
            // VB6: Function listStyle As String
            [DispId(-2147413037)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT listStyle (BSTR value);
            // VB6: Sub listStyle (ByVal value As String)
            [DispId(-2147413037)]
            set;
        }

        /// <summary><para><c>listStyleImage</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>listStyleImage</c> property was the following:  <c>BSTR listStyleImage</c>;</para></remarks>
        // IDL: BSTR listStyleImage;
        // VB6: listStyleImage As String
        string listStyleImage
        {
            // IDL: HRESULT listStyleImage ([out, retval] BSTR* ReturnValue);
            // VB6: Function listStyleImage As String
            [DispId(-2147413038)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT listStyleImage (BSTR value);
            // VB6: Sub listStyleImage (ByVal value As String)
            [DispId(-2147413038)]
            set;
        }

        /// <summary><para><c>listStylePosition</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>listStylePosition</c> property was the following:  <c>BSTR listStylePosition</c>;</para></remarks>
        // IDL: BSTR listStylePosition;
        // VB6: listStylePosition As String
        string listStylePosition
        {
            // IDL: HRESULT listStylePosition ([out, retval] BSTR* ReturnValue);
            // VB6: Function listStylePosition As String
            [DispId(-2147413039)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT listStylePosition (BSTR value);
            // VB6: Sub listStylePosition (ByVal value As String)
            [DispId(-2147413039)]
            set;
        }

        /// <summary><para><c>listStyleType</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>listStyleType</c> property was the following:  <c>BSTR listStyleType</c>;</para></remarks>
        // IDL: BSTR listStyleType;
        // VB6: listStyleType As String
        string listStyleType
        {
            // IDL: HRESULT listStyleType ([out, retval] BSTR* ReturnValue);
            // VB6: Function listStyleType As String
            [DispId(-2147413040)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT listStyleType (BSTR value);
            // VB6: Sub listStyleType (ByVal value As String)
            [DispId(-2147413040)]
            set;
        }

        /// <summary><para><c>margin</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>margin</c> property was the following:  <c>BSTR margin</c>;</para></remarks>
        // IDL: BSTR margin;
        // VB6: margin As String
        string margin
        {
            // IDL: HRESULT margin ([out, retval] BSTR* ReturnValue);
            // VB6: Function margin As String
            [DispId(-2147413076)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT margin (BSTR value);
            // VB6: Sub margin (ByVal value As String)
            [DispId(-2147413076)]
            set;
        }

        /// <summary><para><c>marginBottom</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>marginBottom</c> property was the following:  <c>VARIANT marginBottom</c>;</para></remarks>
        // IDL: VARIANT marginBottom;
        // VB6: marginBottom As Any
        object marginBottom
        {
            // IDL: HRESULT marginBottom ([out, retval] VARIANT* ReturnValue);
            // VB6: Function marginBottom As Any
            [DispId(-2147413073)]
            get;
            // IDL: HRESULT marginBottom (VARIANT value);
            // VB6: Sub marginBottom (ByVal value As Any)
            [DispId(-2147413073)]
            set;
        }

        /// <summary><para><c>marginLeft</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>marginLeft</c> property was the following:  <c>VARIANT marginLeft</c>;</para></remarks>
        // IDL: VARIANT marginLeft;
        // VB6: marginLeft As Any
        object marginLeft
        {
            // IDL: HRESULT marginLeft ([out, retval] VARIANT* ReturnValue);
            // VB6: Function marginLeft As Any
            [DispId(-2147413072)]
            get;
            // IDL: HRESULT marginLeft (VARIANT value);
            // VB6: Sub marginLeft (ByVal value As Any)
            [DispId(-2147413072)]
            set;
        }

        /// <summary><para><c>marginRight</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>marginRight</c> property was the following:  <c>VARIANT marginRight</c>;</para></remarks>
        // IDL: VARIANT marginRight;
        // VB6: marginRight As Any
        object marginRight
        {
            // IDL: HRESULT marginRight ([out, retval] VARIANT* ReturnValue);
            // VB6: Function marginRight As Any
            [DispId(-2147413074)]
            get;
            // IDL: HRESULT marginRight (VARIANT value);
            // VB6: Sub marginRight (ByVal value As Any)
            [DispId(-2147413074)]
            set;
        }

        /// <summary><para><c>marginTop</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>marginTop</c> property was the following:  <c>VARIANT marginTop</c>;</para></remarks>
        // IDL: VARIANT marginTop;
        // VB6: marginTop As Any
        object marginTop
        {
            // IDL: HRESULT marginTop ([out, retval] VARIANT* ReturnValue);
            // VB6: Function marginTop As Any
            [DispId(-2147413075)]
            get;
            // IDL: HRESULT marginTop (VARIANT value);
            // VB6: Sub marginTop (ByVal value As Any)
            [DispId(-2147413075)]
            set;
        }

        /// <summary><para><c>overflow</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>overflow</c> property was the following:  <c>BSTR overflow</c>;</para></remarks>
        // IDL: BSTR overflow;
        // VB6: overflow As String
        string overflow
        {
            // IDL: HRESULT overflow ([out, retval] BSTR* ReturnValue);
            // VB6: Function overflow As String
            [DispId(-2147413102)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT overflow (BSTR value);
            // VB6: Sub overflow (ByVal value As String)
            [DispId(-2147413102)]
            set;
        }

        /// <summary><para><c>padding</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>padding</c> property was the following:  <c>BSTR padding</c>;</para></remarks>
        // IDL: BSTR padding;
        // VB6: padding As String
        string padding
        {
            // IDL: HRESULT padding ([out, retval] BSTR* ReturnValue);
            // VB6: Function padding As String
            [DispId(-2147413101)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT padding (BSTR value);
            // VB6: Sub padding (ByVal value As String)
            [DispId(-2147413101)]
            set;
        }

        /// <summary><para><c>paddingBottom</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>paddingBottom</c> property was the following:  <c>VARIANT paddingBottom</c>;</para></remarks>
        // IDL: VARIANT paddingBottom;
        // VB6: paddingBottom As Any
        object paddingBottom
        {
            // IDL: HRESULT paddingBottom ([out, retval] VARIANT* ReturnValue);
            // VB6: Function paddingBottom As Any
            [DispId(-2147413098)]
            get;
            // IDL: HRESULT paddingBottom (VARIANT value);
            // VB6: Sub paddingBottom (ByVal value As Any)
            [DispId(-2147413098)]
            set;
        }

        /// <summary><para><c>paddingLeft</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>paddingLeft</c> property was the following:  <c>VARIANT paddingLeft</c>;</para></remarks>
        // IDL: VARIANT paddingLeft;
        // VB6: paddingLeft As Any
        object paddingLeft
        {
            // IDL: HRESULT paddingLeft ([out, retval] VARIANT* ReturnValue);
            // VB6: Function paddingLeft As Any
            [DispId(-2147413097)]
            get;
            // IDL: HRESULT paddingLeft (VARIANT value);
            // VB6: Sub paddingLeft (ByVal value As Any)
            [DispId(-2147413097)]
            set;
        }

        /// <summary><para><c>paddingRight</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>paddingRight</c> property was the following:  <c>VARIANT paddingRight</c>;</para></remarks>
        // IDL: VARIANT paddingRight;
        // VB6: paddingRight As Any
        object paddingRight
        {
            // IDL: HRESULT paddingRight ([out, retval] VARIANT* ReturnValue);
            // VB6: Function paddingRight As Any
            [DispId(-2147413099)]
            get;
            // IDL: HRESULT paddingRight (VARIANT value);
            // VB6: Sub paddingRight (ByVal value As Any)
            [DispId(-2147413099)]
            set;
        }

        /// <summary><para><c>paddingTop</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>paddingTop</c> property was the following:  <c>VARIANT paddingTop</c>;</para></remarks>
        // IDL: VARIANT paddingTop;
        // VB6: paddingTop As Any
        object paddingTop
        {
            // IDL: HRESULT paddingTop ([out, retval] VARIANT* ReturnValue);
            // VB6: Function paddingTop As Any
            [DispId(-2147413100)]
            get;
            // IDL: HRESULT paddingTop (VARIANT value);
            // VB6: Sub paddingTop (ByVal value As Any)
            [DispId(-2147413100)]
            set;
        }

        /// <summary><para><c>pageBreakAfter</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>pageBreakAfter</c> property was the following:  <c>BSTR pageBreakAfter</c>;</para></remarks>
        // IDL: BSTR pageBreakAfter;
        // VB6: pageBreakAfter As String
        string pageBreakAfter
        {
            // IDL: HRESULT pageBreakAfter ([out, retval] BSTR* ReturnValue);
            // VB6: Function pageBreakAfter As String
            [DispId(-2147413034)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT pageBreakAfter (BSTR value);
            // VB6: Sub pageBreakAfter (ByVal value As String)
            [DispId(-2147413034)]
            set;
        }

        /// <summary><para><c>pageBreakBefore</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>pageBreakBefore</c> property was the following:  <c>BSTR pageBreakBefore</c>;</para></remarks>
        // IDL: BSTR pageBreakBefore;
        // VB6: pageBreakBefore As String
        string pageBreakBefore
        {
            // IDL: HRESULT pageBreakBefore ([out, retval] BSTR* ReturnValue);
            // VB6: Function pageBreakBefore As String
            [DispId(-2147413035)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT pageBreakBefore (BSTR value);
            // VB6: Sub pageBreakBefore (ByVal value As String)
            [DispId(-2147413035)]
            set;
        }

        /// <summary><para><c>pixelHeight</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>pixelHeight</c> property was the following:  <c>long pixelHeight</c>;</para></remarks>
        // IDL: long pixelHeight;
        // VB6: pixelHeight As Long
        int pixelHeight
        {
            // IDL: HRESULT pixelHeight ([out, retval] long* ReturnValue);
            // VB6: Function pixelHeight As Long
            [DispId(-2147414109)]
            get;
            // IDL: HRESULT pixelHeight (long value);
            // VB6: Sub pixelHeight (ByVal value As Long)
            [DispId(-2147414109)]
            set;
        }

        /// <summary><para><c>pixelLeft</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>pixelLeft</c> property was the following:  <c>long pixelLeft</c>;</para></remarks>
        // IDL: long pixelLeft;
        // VB6: pixelLeft As Long
        int pixelLeft
        {
            // IDL: HRESULT pixelLeft ([out, retval] long* ReturnValue);
            // VB6: Function pixelLeft As Long
            [DispId(-2147414111)]
            get;
            // IDL: HRESULT pixelLeft (long value);
            // VB6: Sub pixelLeft (ByVal value As Long)
            [DispId(-2147414111)]
            set;
        }

        /// <summary><para><c>pixelTop</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>pixelTop</c> property was the following:  <c>long pixelTop</c>;</para></remarks>
        // IDL: long pixelTop;
        // VB6: pixelTop As Long
        int pixelTop
        {
            // IDL: HRESULT pixelTop ([out, retval] long* ReturnValue);
            // VB6: Function pixelTop As Long
            [DispId(-2147414112)]
            get;
            // IDL: HRESULT pixelTop (long value);
            // VB6: Sub pixelTop (ByVal value As Long)
            [DispId(-2147414112)]
            set;
        }

        /// <summary><para><c>pixelWidth</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>pixelWidth</c> property was the following:  <c>long pixelWidth</c>;</para></remarks>
        // IDL: long pixelWidth;
        // VB6: pixelWidth As Long
        int pixelWidth
        {
            // IDL: HRESULT pixelWidth ([out, retval] long* ReturnValue);
            // VB6: Function pixelWidth As Long
            [DispId(-2147414110)]
            get;
            // IDL: HRESULT pixelWidth (long value);
            // VB6: Sub pixelWidth (ByVal value As Long)
            [DispId(-2147414110)]
            set;
        }

        /// <summary><para><c>posHeight</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>posHeight</c> property was the following:  <c>float posHeight</c>;</para></remarks>
        // IDL: float posHeight;
        // VB6: posHeight As Single
        float posHeight
        {
            // IDL: HRESULT posHeight ([out, retval] float* ReturnValue);
            // VB6: Function posHeight As Single
            [DispId(-2147414105)]
            get;
            // IDL: HRESULT posHeight (float value);
            // VB6: Sub posHeight (ByVal value As Single)
            [DispId(-2147414105)]
            set;
        }

        /// <summary><para><c>position</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>position</c> property was the following:  <c>BSTR position</c>;</para></remarks>
        // IDL: BSTR position;
        // VB6: position As String
        string position
        {
            // IDL: HRESULT position ([out, retval] BSTR* ReturnValue);
            // VB6: Function position As String
            [DispId(-2147413022)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }

        /// <summary><para><c>posLeft</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>posLeft</c> property was the following:  <c>float posLeft</c>;</para></remarks>
        // IDL: float posLeft;
        // VB6: posLeft As Single
        float posLeft
        {
            // IDL: HRESULT posLeft ([out, retval] float* ReturnValue);
            // VB6: Function posLeft As Single
            [DispId(-2147414107)]
            get;
            // IDL: HRESULT posLeft (float value);
            // VB6: Sub posLeft (ByVal value As Single)
            [DispId(-2147414107)]
            set;
        }

        /// <summary><para><c>posTop</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>posTop</c> property was the following:  <c>float posTop</c>;</para></remarks>
        // IDL: float posTop;
        // VB6: posTop As Single
        float posTop
        {
            // IDL: HRESULT posTop ([out, retval] float* ReturnValue);
            // VB6: Function posTop As Single
            [DispId(-2147414108)]
            get;
            // IDL: HRESULT posTop (float value);
            // VB6: Sub posTop (ByVal value As Single)
            [DispId(-2147414108)]
            set;
        }

        /// <summary><para><c>posWidth</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>posWidth</c> property was the following:  <c>float posWidth</c>;</para></remarks>
        // IDL: float posWidth;
        // VB6: posWidth As Single
        float posWidth
        {
            // IDL: HRESULT posWidth ([out, retval] float* ReturnValue);
            // VB6: Function posWidth As Single
            [DispId(-2147414106)]
            get;
            // IDL: HRESULT posWidth (float value);
            // VB6: Sub posWidth (ByVal value As Single)
            [DispId(-2147414106)]
            set;
        }

        /// <summary><para><c>styleFloat</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>styleFloat</c> property was the following:  <c>BSTR styleFloat</c>;</para></remarks>
        // IDL: BSTR styleFloat;
        // VB6: styleFloat As String
        string styleFloat
        {
            // IDL: HRESULT styleFloat ([out, retval] BSTR* ReturnValue);
            // VB6: Function styleFloat As String
            [DispId(-2147413042)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT styleFloat (BSTR value);
            // VB6: Sub styleFloat (ByVal value As String)
            [DispId(-2147413042)]
            set;
        }

        /// <summary><para><c>textAlign</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>textAlign</c> property was the following:  <c>BSTR textAlign</c>;</para></remarks>
        // IDL: BSTR textAlign;
        // VB6: textAlign As String
        string textAlign
        {
            // IDL: HRESULT textAlign ([out, retval] BSTR* ReturnValue);
            // VB6: Function textAlign As String
            [DispId(-2147418040)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT textAlign (BSTR value);
            // VB6: Sub textAlign (ByVal value As String)
            [DispId(-2147418040)]
            set;
        }

        /// <summary><para><c>textDecoration</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>textDecoration</c> property was the following:  <c>BSTR textDecoration</c>;</para></remarks>
        // IDL: BSTR textDecoration;
        // VB6: textDecoration As String
        string textDecoration
        {
            // IDL: HRESULT textDecoration ([out, retval] BSTR* ReturnValue);
            // VB6: Function textDecoration As String
            [DispId(-2147413077)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT textDecoration (BSTR value);
            // VB6: Sub textDecoration (ByVal value As String)
            [DispId(-2147413077)]
            set;
        }

        /// <summary><para><c>textDecorationBlink</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>textDecorationBlink</c> property was the following:  <c>VARIANT_BOOL textDecorationBlink</c>;</para></remarks>
        // IDL: VARIANT_BOOL textDecorationBlink;
        // VB6: textDecorationBlink As Boolean
        bool textDecorationBlink
        {
            // IDL: HRESULT textDecorationBlink ([out, retval] VARIANT_BOOL* ReturnValue);
            // VB6: Function textDecorationBlink As Boolean
            [DispId(-2147413090)]
            [return: MarshalAs(UnmanagedType.VariantBool)]
            get;
            // IDL: HRESULT textDecorationBlink (VARIANT_BOOL value);
            // VB6: Sub textDecorationBlink (ByVal value As Boolean)
            [DispId(-2147413090)]
            set;
        }

        /// <summary><para><c>textDecorationLineThrough</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>textDecorationLineThrough</c> property was the following:  <c>VARIANT_BOOL textDecorationLineThrough</c>;</para></remarks>
        // IDL: VARIANT_BOOL textDecorationLineThrough;
        // VB6: textDecorationLineThrough As Boolean
        bool textDecorationLineThrough
        {
            // IDL: HRESULT textDecorationLineThrough ([out, retval] VARIANT_BOOL* ReturnValue);
            // VB6: Function textDecorationLineThrough As Boolean
            [DispId(-2147413092)]
            [return: MarshalAs(UnmanagedType.VariantBool)]
            get;
            // IDL: HRESULT textDecorationLineThrough (VARIANT_BOOL value);
            // VB6: Sub textDecorationLineThrough (ByVal value As Boolean)
            [DispId(-2147413092)]
            set;
        }

        /// <summary><para><c>textDecorationNone</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>textDecorationNone</c> property was the following:  <c>VARIANT_BOOL textDecorationNone</c>;</para></remarks>
        // IDL: VARIANT_BOOL textDecorationNone;
        // VB6: textDecorationNone As Boolean
        bool textDecorationNone
        {
            // IDL: HRESULT textDecorationNone ([out, retval] VARIANT_BOOL* ReturnValue);
            // VB6: Function textDecorationNone As Boolean
            [DispId(-2147413089)]
            [return: MarshalAs(UnmanagedType.VariantBool)]
            get;
            // IDL: HRESULT textDecorationNone (VARIANT_BOOL value);
            // VB6: Sub textDecorationNone (ByVal value As Boolean)
            [DispId(-2147413089)]
            set;
        }

        /// <summary><para><c>textDecorationOverline</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>textDecorationOverline</c> property was the following:  <c>VARIANT_BOOL textDecorationOverline</c>;</para></remarks>
        // IDL: VARIANT_BOOL textDecorationOverline;
        // VB6: textDecorationOverline As Boolean
        bool textDecorationOverline
        {
            // IDL: HRESULT textDecorationOverline ([out, retval] VARIANT_BOOL* ReturnValue);
            // VB6: Function textDecorationOverline As Boolean
            [DispId(-2147413043)]
            [return: MarshalAs(UnmanagedType.VariantBool)]
            get;
            // IDL: HRESULT textDecorationOverline (VARIANT_BOOL value);
            // VB6: Sub textDecorationOverline (ByVal value As Boolean)
            [DispId(-2147413043)]
            set;
        }

        /// <summary><para><c>textDecorationUnderline</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>textDecorationUnderline</c> property was the following:  <c>VARIANT_BOOL textDecorationUnderline</c>;</para></remarks>
        // IDL: VARIANT_BOOL textDecorationUnderline;
        // VB6: textDecorationUnderline As Boolean
        bool textDecorationUnderline
        {
            // IDL: HRESULT textDecorationUnderline ([out, retval] VARIANT_BOOL* ReturnValue);
            // VB6: Function textDecorationUnderline As Boolean
            [DispId(-2147413091)]
            [return: MarshalAs(UnmanagedType.VariantBool)]
            get;
            // IDL: HRESULT textDecorationUnderline (VARIANT_BOOL value);
            // VB6: Sub textDecorationUnderline (ByVal value As Boolean)
            [DispId(-2147413091)]
            set;
        }

        /// <summary><para><c>textIndent</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>textIndent</c> property was the following:  <c>VARIANT textIndent</c>;</para></remarks>
        // IDL: VARIANT textIndent;
        // VB6: textIndent As Any
        object textIndent
        {
            // IDL: HRESULT textIndent ([out, retval] VARIANT* ReturnValue);
            // VB6: Function textIndent As Any
            [DispId(-2147413105)]
            get;
            // IDL: HRESULT textIndent (VARIANT value);
            // VB6: Sub textIndent (ByVal value As Any)
            [DispId(-2147413105)]
            set;
        }

        /// <summary><para><c>textTransform</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>textTransform</c> property was the following:  <c>BSTR textTransform</c>;</para></remarks>
        // IDL: BSTR textTransform;
        // VB6: textTransform As String
        string textTransform
        {
            // IDL: HRESULT textTransform ([out, retval] BSTR* ReturnValue);
            // VB6: Function textTransform As String
            [DispId(-2147413108)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT textTransform (BSTR value);
            // VB6: Sub textTransform (ByVal value As String)
            [DispId(-2147413108)]
            set;
        }

        /// <summary><para><c>top</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>top</c> property was the following:  <c>VARIANT top</c>;</para></remarks>
        // IDL: VARIANT top;
        // VB6: top As Any
        object top
        {
            // IDL: HRESULT top ([out, retval] VARIANT* ReturnValue);
            // VB6: Function top As Any
            [DispId(-2147418108)]
            get;
            // IDL: HRESULT top (VARIANT value);
            // VB6: Sub top (ByVal value As Any)
            [DispId(-2147418108)]
            set;
        }

        /// <summary><para><c>verticalAlign</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>verticalAlign</c> property was the following:  <c>VARIANT verticalAlign</c>;</para></remarks>
        // IDL: VARIANT verticalAlign;
        // VB6: verticalAlign As Any
        object verticalAlign
        {
            // IDL: HRESULT verticalAlign ([out, retval] VARIANT* ReturnValue);
            // VB6: Function verticalAlign As Any
            [DispId(-2147413064)]
            get;
            // IDL: HRESULT verticalAlign (VARIANT value);
            // VB6: Sub verticalAlign (ByVal value As Any)
            [DispId(-2147413064)]
            set;
        }

        /// <summary><para><c>visibility</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>visibility</c> property was the following:  <c>BSTR visibility</c>;</para></remarks>
        // IDL: BSTR visibility;
        // VB6: visibility As String
        string visibility
        {
            // IDL: HRESULT visibility ([out, retval] BSTR* ReturnValue);
            // VB6: Function visibility As String
            [DispId(-2147413032)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT visibility (BSTR value);
            // VB6: Sub visibility (ByVal value As String)
            [DispId(-2147413032)]
            set;
        }

        /// <summary><para><c>whiteSpace</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>whiteSpace</c> property was the following:  <c>BSTR whiteSpace</c>;</para></remarks>
        // IDL: BSTR whiteSpace;
        // VB6: whiteSpace As String
        string whiteSpace
        {
            // IDL: HRESULT whiteSpace ([out, retval] BSTR* ReturnValue);
            // VB6: Function whiteSpace As String
            [DispId(-2147413036)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT whiteSpace (BSTR value);
            // VB6: Sub whiteSpace (ByVal value As String)
            [DispId(-2147413036)]
            set;
        }

        /// <summary><para><c>width</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>width</c> property was the following:  <c>VARIANT width</c>;</para></remarks>
        // IDL: VARIANT width;
        // VB6: width As Any
        object width
        {
            // IDL: HRESULT width ([out, retval] VARIANT* ReturnValue);
            // VB6: Function width As Any
            [DispId(-2147418107)]
            get;
            // IDL: HRESULT width (VARIANT value);
            // VB6: Sub width (ByVal value As Any)
            [DispId(-2147418107)]
            set;
        }

        /// <summary><para><c>wordSpacing</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>wordSpacing</c> property was the following:  <c>VARIANT wordSpacing</c>;</para></remarks>
        // IDL: VARIANT wordSpacing;
        // VB6: wordSpacing As Any
        object wordSpacing
        {
            // IDL: HRESULT wordSpacing ([out, retval] VARIANT* ReturnValue);
            // VB6: Function wordSpacing As Any
            [DispId(-2147413065)]
            get;
            // IDL: HRESULT wordSpacing (VARIANT value);
            // VB6: Sub wordSpacing (ByVal value As Any)
            [DispId(-2147413065)]
            set;
        }

        /// <summary><para><c>zIndex</c> property of <c>IHTMLStyle</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>zIndex</c> property was the following:  <c>VARIANT zIndex</c>;</para></remarks>
        // IDL: VARIANT zIndex;
        // VB6: zIndex As Any
        object zIndex
        {
            // IDL: HRESULT zIndex ([out, retval] VARIANT* ReturnValue);
            // VB6: Function zIndex As Any
            [DispId(-2147413021)]
            get;
            // IDL: HRESULT zIndex (VARIANT value);
            // VB6: Sub zIndex (ByVal value As Any)
            [DispId(-2147413021)]
            set;
        }
    }
    #endregion

    #region IHTMLTxtRange Interface
    /// <summary><para><c>IHTMLTxtRange</c> interface.</para></summary>
    [Guid("3050F220-98B5-11CF-BB82-00AA00BDCE0B")]
    [ComImport]
    [TypeLibType((short)4160)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IHTMLTxtRange
    {
        /// <summary><para><c>parentElement</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>parentElement</c> method was the following:  <c>HRESULT parentElement ([out, retval] IHTMLElement** ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT parentElement ([out, retval] IHTMLElement** ReturnValue);
        // VB6: Function parentElement As IHTMLElement
        [DispId(1006)]
        IHTMLElement parentElement();

        /// <summary><para><c>duplicate</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>duplicate</c> method was the following:  <c>HRESULT duplicate ([out, retval] IHTMLTxtRange** ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT duplicate ([out, retval] IHTMLTxtRange** ReturnValue);
        // VB6: Function duplicate As IHTMLTxtRange
        [DispId(1008)]
        IHTMLTxtRange duplicate();

        /// <summary><para><c>inRange</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>inRange</c> method was the following:  <c>HRESULT inRange (IHTMLTxtRange* range, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT inRange (IHTMLTxtRange* range, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function inRange (ByVal range As IHTMLTxtRange) As Boolean
        [DispId(1010)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool inRange(IHTMLTxtRange range);

        /// <summary><para><c>isEqual</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>isEqual</c> method was the following:  <c>HRESULT isEqual (IHTMLTxtRange* range, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT isEqual (IHTMLTxtRange* range, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function isEqual (ByVal range As IHTMLTxtRange) As Boolean
        [DispId(1011)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool isEqual(IHTMLTxtRange range);

        /// <summary><para><c>scrollIntoView</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>scrollIntoView</c> method was the following:  <c>HRESULT scrollIntoView ([optional, defaultvalue(-1)] VARIANT_BOOL fStart)</c>;</para></remarks>
        // IDL: HRESULT scrollIntoView ([optional, defaultvalue(-1)] VARIANT_BOOL fStart);
        // VB6: Sub scrollIntoView ([ByVal fStart As Boolean = True])
        [DispId(1012)]
        void scrollIntoView([MarshalAs(UnmanagedType.VariantBool)] bool fStart);

        /// <summary><para><c>collapse</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>collapse</c> method was the following:  <c>HRESULT collapse ([optional, defaultvalue(-1)] VARIANT_BOOL Start)</c>;</para></remarks>
        // IDL: HRESULT collapse ([optional, defaultvalue(-1)] VARIANT_BOOL Start);
        // VB6: Sub collapse ([ByVal Start As Boolean = True])
        [DispId(1013)]
        void collapse([MarshalAs(UnmanagedType.VariantBool)] bool Start);

        /// <summary><para><c>expand</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>expand</c> method was the following:  <c>HRESULT expand (BSTR Unit, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT expand (BSTR Unit, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function expand (ByVal Unit As String) As Boolean
        [DispId(1014)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool expand([MarshalAs(UnmanagedType.BStr)] string Unit);

        /// <summary><para><c>move</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>move</c> method was the following:  <c>HRESULT move (BSTR Unit, [optional, defaultvalue(1)] long Count, [out, retval] long* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT move (BSTR Unit, [optional, defaultvalue(1)] long Count, [out, retval] long* ReturnValue);
        // VB6: Function move (ByVal Unit As String, [ByVal Count As Long = 1]) As Long
        [DispId(1015)]
        int move([MarshalAs(UnmanagedType.BStr)] string Unit, int Count);

        /// <summary><para><c>moveStart</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>moveStart</c> method was the following:  <c>HRESULT moveStart (BSTR Unit, [optional, defaultvalue(1)] long Count, [out, retval] long* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT moveStart (BSTR Unit, [optional, defaultvalue(1)] long Count, [out, retval] long* ReturnValue);
        // VB6: Function moveStart (ByVal Unit As String, [ByVal Count As Long = 1]) As Long
        [DispId(1016)]
        int moveStart([MarshalAs(UnmanagedType.BStr)] string Unit, int Count);

        /// <summary><para><c>moveEnd</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>moveEnd</c> method was the following:  <c>HRESULT moveEnd (BSTR Unit, [optional, defaultvalue(1)] long Count, [out, retval] long* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT moveEnd (BSTR Unit, [optional, defaultvalue(1)] long Count, [out, retval] long* ReturnValue);
        // VB6: Function moveEnd (ByVal Unit As String, [ByVal Count As Long = 1]) As Long
        [DispId(1017)]
        int moveEnd([MarshalAs(UnmanagedType.BStr)] string Unit, int Count);

        /// <summary><para><c>select</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>select</c> method was the following:  <c>HRESULT select (void)</c>;</para></remarks>
        // IDL: HRESULT select (void);
        // VB6: Sub select
        [DispId(1024)]
        void select();

        /// <summary><para><c>pasteHTML</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>pasteHTML</c> method was the following:  <c>HRESULT pasteHTML (BSTR html)</c>;</para></remarks>
        // IDL: HRESULT pasteHTML (BSTR html);
        // VB6: Sub pasteHTML (ByVal html As String)
        [DispId(1026)]
        void pasteHTML([MarshalAs(UnmanagedType.BStr)] string html);

        /// <summary><para><c>moveToElementText</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>moveToElementText</c> method was the following:  <c>HRESULT moveToElementText (IHTMLElement* element)</c>;</para></remarks>
        // IDL: HRESULT moveToElementText (IHTMLElement* element);
        // VB6: Sub moveToElementText (ByVal element As IHTMLElement)
        [DispId(1001)]
        void moveToElementText(IHTMLElement element);

        /// <summary><para><c>setEndPoint</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>setEndPoint</c> method was the following:  <c>HRESULT setEndPoint (BSTR how, IHTMLTxtRange* SourceRange)</c>;</para></remarks>
        // IDL: HRESULT setEndPoint (BSTR how, IHTMLTxtRange* SourceRange);
        // VB6: Sub setEndPoint (ByVal how As String, ByVal SourceRange As IHTMLTxtRange)
        [DispId(1025)]
        void setEndPoint([MarshalAs(UnmanagedType.BStr)] string how, IHTMLTxtRange SourceRange);

        /// <summary><para><c>compareEndPoints</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>compareEndPoints</c> method was the following:  <c>HRESULT compareEndPoints (BSTR how, IHTMLTxtRange* SourceRange, [out, retval] long* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT compareEndPoints (BSTR how, IHTMLTxtRange* SourceRange, [out, retval] long* ReturnValue);
        // VB6: Function compareEndPoints (ByVal how As String, ByVal SourceRange As IHTMLTxtRange) As Long
        [DispId(1018)]
        int compareEndPoints([MarshalAs(UnmanagedType.BStr)] string how, IHTMLTxtRange SourceRange);

        /// <summary><para><c>findText</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>findText</c> method was the following:  <c>HRESULT findText (BSTR String, [optional, defaultvalue(1073741823)] long Count, [optional, defaultvalue(0)] long Flags, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT findText (BSTR String, [optional, defaultvalue(1073741823)] long Count, [optional, defaultvalue(0)] long Flags, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function findText (ByVal String As String, [ByVal Count As Long = 1073741823], [ByVal Flags As Long = 0]) As Boolean
        [DispId(1019)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool findText([MarshalAs(UnmanagedType.BStr)] string String, int Count, int Flags);

        /// <summary><para><c>moveToPoint</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>moveToPoint</c> method was the following:  <c>HRESULT moveToPoint (long x, long y)</c>;</para></remarks>
        // IDL: HRESULT moveToPoint (long x, long y);
        // VB6: Sub moveToPoint (ByVal x As Long, ByVal y As Long)
        [DispId(1020)]
        void moveToPoint(int x, int y);

        /// <summary><para><c>getBookmark</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>getBookmark</c> method was the following:  <c>HRESULT getBookmark ([out, retval] BSTR* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT getBookmark ([out, retval] BSTR* ReturnValue);
        // VB6: Function getBookmark As String
        [DispId(1021)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string getBookmark();

        /// <summary><para><c>moveToBookmark</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>moveToBookmark</c> method was the following:  <c>HRESULT moveToBookmark (BSTR Bookmark, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT moveToBookmark (BSTR Bookmark, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function moveToBookmark (ByVal Bookmark As String) As Boolean
        [DispId(1009)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool moveToBookmark([MarshalAs(UnmanagedType.BStr)] string Bookmark);

        /// <summary><para><c>queryCommandSupported</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>queryCommandSupported</c> method was the following:  <c>HRESULT queryCommandSupported (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT queryCommandSupported (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function queryCommandSupported (ByVal cmdID As String) As Boolean
        [DispId(1027)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool queryCommandSupported([MarshalAs(UnmanagedType.BStr)] string cmdID);

        /// <summary><para><c>queryCommandEnabled</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>queryCommandEnabled</c> method was the following:  <c>HRESULT queryCommandEnabled (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT queryCommandEnabled (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function queryCommandEnabled (ByVal cmdID As String) As Boolean
        [DispId(1028)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool queryCommandEnabled([MarshalAs(UnmanagedType.BStr)] string cmdID);

        /// <summary><para><c>queryCommandState</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>queryCommandState</c> method was the following:  <c>HRESULT queryCommandState (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT queryCommandState (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function queryCommandState (ByVal cmdID As String) As Boolean
        [DispId(1029)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool queryCommandState([MarshalAs(UnmanagedType.BStr)] string cmdID);

        /// <summary><para><c>queryCommandIndeterm</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>queryCommandIndeterm</c> method was the following:  <c>HRESULT queryCommandIndeterm (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT queryCommandIndeterm (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function queryCommandIndeterm (ByVal cmdID As String) As Boolean
        [DispId(1030)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool queryCommandIndeterm([MarshalAs(UnmanagedType.BStr)] string cmdID);

        /// <summary><para><c>queryCommandText</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>queryCommandText</c> method was the following:  <c>HRESULT queryCommandText (BSTR cmdID, [out, retval] BSTR* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT queryCommandText (BSTR cmdID, [out, retval] BSTR* ReturnValue);
        // VB6: Function queryCommandText (ByVal cmdID As String) As String
        [DispId(1031)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string queryCommandText([MarshalAs(UnmanagedType.BStr)] string cmdID);

        /// <summary><para><c>queryCommandValue</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>queryCommandValue</c> method was the following:  <c>HRESULT queryCommandValue (BSTR cmdID, [out, retval] VARIANT* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT queryCommandValue (BSTR cmdID, [out, retval] VARIANT* ReturnValue);
        // VB6: Function queryCommandValue (ByVal cmdID As String) As Any
        [DispId(1032)]
        object queryCommandValue([MarshalAs(UnmanagedType.BStr)] string cmdID);

        /// <summary><para><c>execCommand</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>execCommand</c> method was the following:  <c>HRESULT execCommand (BSTR cmdID, [optional, defaultvalue(0)] VARIANT_BOOL showUI, [optional] VARIANT value, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT execCommand (BSTR cmdID, [optional, defaultvalue(0)] VARIANT_BOOL showUI, [optional] VARIANT value, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function execCommand (ByVal cmdID As String, [ByVal showUI As Boolean = False], [ByVal value As Any]) As Boolean
        [DispId(1033)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool execCommand([MarshalAs(UnmanagedType.BStr)] string cmdID, [MarshalAs(UnmanagedType.VariantBool)] bool showUI, object value);

        /// <summary><para><c>execCommandShowHelp</c> method of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>execCommandShowHelp</c> method was the following:  <c>HRESULT execCommandShowHelp (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT execCommandShowHelp (BSTR cmdID, [out, retval] VARIANT_BOOL* ReturnValue);
        // VB6: Function execCommandShowHelp (ByVal cmdID As String) As Boolean
        [DispId(1034)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool execCommandShowHelp([MarshalAs(UnmanagedType.BStr)] string cmdID);

        /// <summary><para><c>htmlText</c> property of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>htmlText</c> property was the following:  <c>BSTR htmlText</c>;</para></remarks>
        // IDL: BSTR htmlText;
        // VB6: htmlText As String
        string htmlText
        {
            // IDL: HRESULT htmlText ([out, retval] BSTR* ReturnValue);
            // VB6: Function htmlText As String
            [DispId(1003)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
        }

        /// <summary><para><c>text</c> property of <c>IHTMLTxtRange</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>text</c> property was the following:  <c>BSTR text</c>;</para></remarks>
        // IDL: BSTR text;
        // VB6: text As String
        string text
        {
            // IDL: HRESULT text ([out, retval] BSTR* ReturnValue);
            // VB6: Function text As String
            [DispId(1004)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT text (BSTR value);
            // VB6: Sub text (ByVal value As String)
            [DispId(1004)]
            set;
        }
    }
    #endregion

    #region IHTMLBodyElement Interface
    /// <summary><para><c>IHTMLBodyElement</c> interface.</para></summary>
    [Guid("3050F1D8-98B5-11CF-BB82-00AA00BDCE0B")]
    [ComImport]
    [TypeLibType((short)4160)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IHTMLBodyElement
    {
        /// <summary><para><c>createTextRange</c> method of <c>IHTMLBodyElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>createTextRange</c> method was the following:  <c>HRESULT createTextRange ([out, retval] IHTMLTxtRange** ReturnValue)</c>;</para></remarks>
        // IDL: HRESULT createTextRange ([out, retval] IHTMLTxtRange** ReturnValue);
        // VB6: Function createTextRange As IHTMLTxtRange
        [DispId(2013)]
        IHTMLTxtRange createTextRange();

        /// <summary><para><c>aLink</c> property of <c>IHTMLBodyElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>aLink</c> property was the following:  <c>VARIANT aLink</c>;</para></remarks>
        // IDL: VARIANT aLink;
        // VB6: aLink As Any
        object aLink
        {
            // IDL: HRESULT aLink ([out, retval] VARIANT* ReturnValue);
            // VB6: Function aLink As Any
            [DispId(2011)]
            get;
            // IDL: HRESULT aLink (VARIANT value);
            // VB6: Sub aLink (ByVal value As Any)
            [DispId(2011)]
            set;
        }

        /// <summary><para><c>background</c> property of <c>IHTMLBodyElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>background</c> property was the following:  <c>BSTR background</c>;</para></remarks>
        // IDL: BSTR background;
        // VB6: background As String
        string background
        {
            // IDL: HRESULT background ([out, retval] BSTR* ReturnValue);
            // VB6: Function background As String
            [DispId(-2147413111)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT background (BSTR value);
            // VB6: Sub background (ByVal value As String)
            [DispId(-2147413111)]
            set;
        }

        /// <summary><para><c>bgColor</c> property of <c>IHTMLBodyElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>bgColor</c> property was the following:  <c>VARIANT bgColor</c>;</para></remarks>
        // IDL: VARIANT bgColor;
        // VB6: bgColor As Any
        object bgColor
        {
            // IDL: HRESULT bgColor ([out, retval] VARIANT* ReturnValue);
            // VB6: Function bgColor As Any
            [DispId(-501)]
            get;
            // IDL: HRESULT bgColor (VARIANT value);
            // VB6: Sub bgColor (ByVal value As Any)
            [DispId(-501)]
            set;
        }

        /// <summary><para><c>bgProperties</c> property of <c>IHTMLBodyElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>bgProperties</c> property was the following:  <c>BSTR bgProperties</c>;</para></remarks>
        // IDL: BSTR bgProperties;
        // VB6: bgProperties As String
        string bgProperties
        {
            // IDL: HRESULT bgProperties ([out, retval] BSTR* ReturnValue);
            // VB6: Function bgProperties As String
            [DispId(-2147413067)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT bgProperties (BSTR value);
            // VB6: Sub bgProperties (ByVal value As String)
            [DispId(-2147413067)]
            set;
        }

        /// <summary><para><c>bottomMargin</c> property of <c>IHTMLBodyElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>bottomMargin</c> property was the following:  <c>VARIANT bottomMargin</c>;</para></remarks>
        // IDL: VARIANT bottomMargin;
        // VB6: bottomMargin As Any
        object bottomMargin
        {
            // IDL: HRESULT bottomMargin ([out, retval] VARIANT* ReturnValue);
            // VB6: Function bottomMargin As Any
            [DispId(-2147413073)]
            get;
            // IDL: HRESULT bottomMargin (VARIANT value);
            // VB6: Sub bottomMargin (ByVal value As Any)
            [DispId(-2147413073)]
            set;
        }

        /// <summary><para><c>leftMargin</c> property of <c>IHTMLBodyElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>leftMargin</c> property was the following:  <c>VARIANT leftMargin</c>;</para></remarks>
        // IDL: VARIANT leftMargin;
        // VB6: leftMargin As Any
        object leftMargin
        {
            // IDL: HRESULT leftMargin ([out, retval] VARIANT* ReturnValue);
            // VB6: Function leftMargin As Any
            [DispId(-2147413072)]
            get;
            // IDL: HRESULT leftMargin (VARIANT value);
            // VB6: Sub leftMargin (ByVal value As Any)
            [DispId(-2147413072)]
            set;
        }

        /// <summary><para><c>link</c> property of <c>IHTMLBodyElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>link</c> property was the following:  <c>VARIANT link</c>;</para></remarks>
        // IDL: VARIANT link;
        // VB6: link As Any
        object link
        {
            // IDL: HRESULT link ([out, retval] VARIANT* ReturnValue);
            // VB6: Function link As Any
            [DispId(2010)]
            get;
            // IDL: HRESULT link (VARIANT value);
            // VB6: Sub link (ByVal value As Any)
            [DispId(2010)]
            set;
        }

        /// <summary><para><c>noWrap</c> property of <c>IHTMLBodyElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>noWrap</c> property was the following:  <c>VARIANT_BOOL noWrap</c>;</para></remarks>
        // IDL: VARIANT_BOOL noWrap;
        // VB6: noWrap As Boolean
        bool noWrap
        {
            // IDL: HRESULT noWrap ([out, retval] VARIANT_BOOL* ReturnValue);
            // VB6: Function noWrap As Boolean
            [DispId(-2147413107)]
            [return: MarshalAs(UnmanagedType.VariantBool)]
            get;
            // IDL: HRESULT noWrap (VARIANT_BOOL value);
            // VB6: Sub noWrap (ByVal value As Boolean)
            [DispId(-2147413107)]
            set;
        }

        /// <summary><para><c>onbeforeunload</c> property of <c>IHTMLBodyElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onbeforeunload</c> property was the following:  <c>VARIANT onbeforeunload</c>;</para></remarks>
        // IDL: VARIANT onbeforeunload;
        // VB6: onbeforeunload As Any
        object onbeforeunload
        {
            // IDL: HRESULT onbeforeunload ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onbeforeunload As Any
            [DispId(-2147412073)]
            get;
            // IDL: HRESULT onbeforeunload (VARIANT value);
            // VB6: Sub onbeforeunload (ByVal value As Any)
            [DispId(-2147412073)]
            set;
        }

        /// <summary><para><c>onload</c> property of <c>IHTMLBodyElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onload</c> property was the following:  <c>VARIANT onload</c>;</para></remarks>
        // IDL: VARIANT onload;
        // VB6: onload As Any
        object onload
        {
            // IDL: HRESULT onload ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onload As Any
            [DispId(-2147412080)]
            get;
            // IDL: HRESULT onload (VARIANT value);
            // VB6: Sub onload (ByVal value As Any)
            [DispId(-2147412080)]
            set;
        }

        /// <summary><para><c>onselect</c> property of <c>IHTMLBodyElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onselect</c> property was the following:  <c>VARIANT onselect</c>;</para></remarks>
        // IDL: VARIANT onselect;
        // VB6: onselect As Any
        object onselect
        {
            // IDL: HRESULT onselect ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onselect As Any
            [DispId(-2147412102)]
            get;
            // IDL: HRESULT onselect (VARIANT value);
            // VB6: Sub onselect (ByVal value As Any)
            [DispId(-2147412102)]
            set;
        }

        /// <summary><para><c>onunload</c> property of <c>IHTMLBodyElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onunload</c> property was the following:  <c>VARIANT onunload</c>;</para></remarks>
        // IDL: VARIANT onunload;
        // VB6: onunload As Any
        object onunload
        {
            // IDL: HRESULT onunload ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onunload As Any
            [DispId(-2147412079)]
            get;
            // IDL: HRESULT onunload (VARIANT value);
            // VB6: Sub onunload (ByVal value As Any)
            [DispId(-2147412079)]
            set;
        }

        /// <summary><para><c>rightMargin</c> property of <c>IHTMLBodyElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>rightMargin</c> property was the following:  <c>VARIANT rightMargin</c>;</para></remarks>
        // IDL: VARIANT rightMargin;
        // VB6: rightMargin As Any
        object rightMargin
        {
            // IDL: HRESULT rightMargin ([out, retval] VARIANT* ReturnValue);
            // VB6: Function rightMargin As Any
            [DispId(-2147413074)]
            get;
            // IDL: HRESULT rightMargin (VARIANT value);
            // VB6: Sub rightMargin (ByVal value As Any)
            [DispId(-2147413074)]
            set;
        }

        /// <summary><para><c>scroll</c> property of <c>IHTMLBodyElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>scroll</c> property was the following:  <c>BSTR scroll</c>;</para></remarks>
        // IDL: BSTR scroll;
        // VB6: scroll As String
        string scroll
        {
            // IDL: HRESULT scroll ([out, retval] BSTR* ReturnValue);
            // VB6: Function scroll As String
            [DispId(-2147413033)]
            [return: MarshalAs(UnmanagedType.BStr)]
            get;
            // IDL: HRESULT scroll (BSTR value);
            // VB6: Sub scroll (ByVal value As String)
            [DispId(-2147413033)]
            set;
        }

        /// <summary><para><c>text</c> property of <c>IHTMLBodyElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>text</c> property was the following:  <c>VARIANT text</c>;</para></remarks>
        // IDL: VARIANT text;
        // VB6: text As Any
        object text
        {
            // IDL: HRESULT text ([out, retval] VARIANT* ReturnValue);
            // VB6: Function text As Any
            [DispId(-2147413110)]
            get;
            // IDL: HRESULT text (VARIANT value);
            // VB6: Sub text (ByVal value As Any)
            [DispId(-2147413110)]
            set;
        }

        /// <summary><para><c>topMargin</c> property of <c>IHTMLBodyElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>topMargin</c> property was the following:  <c>VARIANT topMargin</c>;</para></remarks>
        // IDL: VARIANT topMargin;
        // VB6: topMargin As Any
        object topMargin
        {
            // IDL: HRESULT topMargin ([out, retval] VARIANT* ReturnValue);
            // VB6: Function topMargin As Any
            [DispId(-2147413075)]
            get;
            // IDL: HRESULT topMargin (VARIANT value);
            // VB6: Sub topMargin (ByVal value As Any)
            [DispId(-2147413075)]
            set;
        }

        /// <summary><para><c>vLink</c> property of <c>IHTMLBodyElement</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>vLink</c> property was the following:  <c>VARIANT vLink</c>;</para></remarks>
        // IDL: VARIANT vLink;
        // VB6: vLink As Any
        object vLink
        {
            // IDL: HRESULT vLink ([out, retval] VARIANT* ReturnValue);
            // VB6: Function vLink As Any
            [DispId(2012)]
            get;
            // IDL: HRESULT vLink (VARIANT value);
            // VB6: Sub vLink (ByVal value As Any)
            [DispId(2012)]
            set;
        }
    }
    #endregion

    #region IHTMLBodyElement2 Interface
    /// <summary><para><c>IHTMLBodyElement2</c> interface.</para></summary>
    [Guid("3050F5C5-98B5-11CF-BB82-00AA00BDCE0B")]
    [ComImport]
    [TypeLibType((short)4160)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IHTMLBodyElement2
    {
        /// <summary><para><c>onafterprint</c> property of <c>IHTMLBodyElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onafterprint</c> property was the following:  <c>VARIANT onafterprint</c>;</para></remarks>
        // IDL: VARIANT onafterprint;
        // VB6: onafterprint As Any
        object onafterprint
        {
            // IDL: HRESULT onafterprint ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onafterprint As Any
            [DispId(-2147412045)]
            get;
            // IDL: HRESULT onafterprint (VARIANT value);
            // VB6: Sub onafterprint (ByVal value As Any)
            [DispId(-2147412045)]
            set;
        }

        /// <summary><para><c>onbeforeprint</c> property of <c>IHTMLBodyElement2</c> interface.</para></summary>
        /// <remarks><para>An original IDL definition of <c>onbeforeprint</c> property was the following:  <c>VARIANT onbeforeprint</c>;</para></remarks>
        // IDL: VARIANT onbeforeprint;
        // VB6: onbeforeprint As Any
        object onbeforeprint
        {
            // IDL: HRESULT onbeforeprint ([out, retval] VARIANT* ReturnValue);
            // VB6: Function onbeforeprint As Any
            [DispId(-2147412046)]
            get;
            // IDL: HRESULT onbeforeprint (VARIANT value);
            // VB6: Sub onbeforeprint (ByVal value As Any)
            [DispId(-2147412046)]
            set;
        }
    }
    #endregion

    #region IHtmlControlElement Interface

    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f4e9-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLControlElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLELEMENT_TABINDEX)]
        short tabIndex { set; [return: MarshalAs(UnmanagedType.I2)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLELEMENT_FOCUS)]
        void focus();
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLELEMENT_ACCESSKEY)]
        string accessKey { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLELEMENT_ONBLUR)]
        object onblur { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLELEMENT_ONFOCUS)]
        object onfocus { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLELEMENT_ONRESIZE)]
        object onresize { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLELEMENT_BLUR)]
        void blur();
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLELEMENT_ADDFILTER)]
        void addFilter([MarshalAs(UnmanagedType.IUnknown)] object pUnk);
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLELEMENT_REMOVEFILTER)]
        void removeFilter([MarshalAs(UnmanagedType.IUnknown)] object pUnk);
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLELEMENT_CLIENTHEIGHT)]
        int clientHeight { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLELEMENT_CLIENTWIDTH)]
        int clientWidth { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLELEMENT_CLIENTTOP)]
        int clientTop { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLELEMENT_CLIENTLEFT)]
        int clientLeft { get;}
    }

    #endregion

    #region IHTMLControlRange interfaces
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f29c-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLControlRange
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLRANGE_SELECT)]
        void select();
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLRANGE_ADD)]
        void add([MarshalAs(UnmanagedType.Interface)] IHTMLControlElement item);
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLRANGE_REMOVE)]
        void remove(int index);
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLRANGE_ITEM)]
        IHTMLElement item(int index);
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLRANGE_SCROLLINTOVIEW)]
        void scrollIntoView(object varargStart);
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLRANGE_QUERYCOMMANDSUPPORTED)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool queryCommandSupported([MarshalAs(UnmanagedType.BStr)] string cmdID);
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLRANGE_QUERYCOMMANDENABLED)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool queryCommandEnabled([MarshalAs(UnmanagedType.BStr)] string cmdID);
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLRANGE_QUERYCOMMANDSTATE)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool queryCommandState([MarshalAs(UnmanagedType.BStr)] string cmdID);
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLRANGE_QUERYCOMMANDINDETERM)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool queryCommandIndeterm([MarshalAs(UnmanagedType.BStr)] string cmdID);
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLRANGE_QUERYCOMMANDTEXT)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string queryCommandText([MarshalAs(UnmanagedType.BStr)] string cmdID);
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLRANGE_QUERYCOMMANDVALUE)]
        object queryCommandValue([MarshalAs(UnmanagedType.BStr)] string cmdID);
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLRANGE_EXECCOMMAND)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool execCommand([MarshalAs(UnmanagedType.BStr)] string cmdID, [MarshalAs(UnmanagedType.VariantBool)] bool showUI, object value);
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLRANGE_EXECCOMMANDSHOWHELP)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool execCommandShowHelp([MarshalAs(UnmanagedType.BStr)] string cmdID);
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLRANGE_COMMONPARENTELEMENT)]
        IHTMLElement commonParentElement();
        [DispId(HTMLDispIDs.DISPID_IHTMLCONTROLRANGE_LENGTH)]
        int length { get;}
    }
    #endregion

    #region IHtmlControlRange2 Interface

    [ComVisible(true), Guid("3050f65e-98b5-11cf-bb82-00aa00bdce0b"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IHtmlControlRange2
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int addElement([In, MarshalAs(UnmanagedType.Interface)] IHTMLElement element);
    }

    #endregion

    #region IHTMLEventObj2 Interface
    [ComVisible(true), ComImport()]
    [TypeLibType((short)4160)] //TypeLibTypeFlags.FDispatchable
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f48B-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLEventObj2
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ2_SETATTRIBUTE)]
        void setAttribute([MarshalAs(UnmanagedType.BStr)] string strAttributeName, object AttributeValue, int lFlags);

        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ2_GETATTRIBUTE)]
        object getAttribute([MarshalAs(UnmanagedType.BStr)] string strAttributeName, int lFlags);

        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ2_REMOVEATTRIBUTE)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool removeAttribute([MarshalAs(UnmanagedType.BStr)] string strAttributeName, int lFlags);

        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ2_PROPERTYNAME)]
        string propertyName { set; [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ2_BOOKMARKS)]
        object bookmarks { set; [return: MarshalAs(UnmanagedType.Interface)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ2_RECORDSET)]
        object recordset { set; [return: MarshalAs(UnmanagedType.Interface)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ2_DATAFLD)]
        string dataFld { set; [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ2_BOUNDELEMENTS)]
        object boundElements { set; [return: MarshalAs(UnmanagedType.Interface)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ2_REPEAT)]
        bool repeat { set; [return: MarshalAs(UnmanagedType.VariantBool)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ2_SRCURN)]
        string srcUrn { set; [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ2_SRCELEMENT)]
        IHTMLElement SrcElement { set; [return: MarshalAs(UnmanagedType.Interface)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ2_ALTKEY)]
        bool AltKey { set; get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ2_CTRLKEY)]
        bool CtrlKey { set; get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ2_SHIFTKEY)]
        bool ShiftKey { set; get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ2_FROMELEMENT)]
        IHTMLElement FromElement { set;  [return: MarshalAs(UnmanagedType.Interface)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ2_TOELEMENT)]
        IHTMLElement ToElement { set; [return: MarshalAs(UnmanagedType.Interface)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ2_BUTTON)]
        int Button { set; get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ2_TYPE)]
        string EventType { set; [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ2_QUALIFIER)]
        string Qualifier { set; [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ2_REASON)]
        int reason { get; set; }

        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ2_X)]
        int x { get; set; }

        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ2_Y)]
        int y { get; set; }

        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ2_CLIENTX)]
        int ClientX { get; set;}

        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ2_CLIENTY)]
        int clientY { set; get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ2_OFFSETX)]
        int offsetX { get; set;}

        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ2_OFFSETY)]
        int offsetY { get; set;}

        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ2_SCREENX)]
        int screenX { get; set;}

        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ2_SCREENY)]
        int screenY { get; set;}

        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ2_SRCFILTER)]
        object srcFilter { [return: MarshalAs(UnmanagedType.IDispatch)] get; set;}

        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ2_DATATRANSFER)]
        object dataTransfer { [return: MarshalAs(UnmanagedType.IDispatch)] get; }
    }

    #endregion

    #region IHTMLEventObj Interface
    //MIDL_INTERFACE("3050f32d-98b5-11cf-bb82-00aa00bdce0b")
    //IHTMLEventObj : public IDispatch
    //{
    //public:
    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_srcElement( 
    //        /* [out][retval] */ IHTMLElement **p) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_altKey( 
    //        /* [out][retval] */ VARIANT_BOOL *p) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_ctrlKey( 
    //        /* [out][retval] */ VARIANT_BOOL *p) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_shiftKey( 
    //        /* [out][retval] */ VARIANT_BOOL *p) = 0;

    //    virtual /* [id][propput] */ HRESULT STDMETHODCALLTYPE put_returnValue( 
    //        /* [in] */ VARIANT v) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_returnValue( 
    //        /* [out][retval] */ VARIANT *p) = 0;

    //    virtual /* [id][propput] */ HRESULT STDMETHODCALLTYPE put_cancelBubble( 
    //        /* [in] */ VARIANT_BOOL v) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_cancelBubble( 
    //        /* [out][retval] */ VARIANT_BOOL *p) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_fromElement( 
    //        /* [out][retval] */ IHTMLElement **p) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_toElement( 
    //        /* [out][retval] */ IHTMLElement **p) = 0;

    //    virtual /* [id][propput] */ HRESULT STDMETHODCALLTYPE put_keyCode( 
    //        /* [in] */ long v) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_keyCode( 
    //        /* [out][retval] */ long *p) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_button( 
    //        /* [out][retval] */ long *p) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_type( 
    //        /* [out][retval] */ BSTR *p) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_qualifier( 
    //        /* [out][retval] */ BSTR *p) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_reason( 
    //        /* [out][retval] */ long *p) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_x( 
    //        /* [out][retval] */ long *p) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_y( 
    //        /* [out][retval] */ long *p) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_clientX( 
    //        /* [out][retval] */ long *p) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_clientY( 
    //        /* [out][retval] */ long *p) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_offsetX( 
    //        /* [out][retval] */ long *p) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_offsetY( 
    //        /* [out][retval] */ long *p) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_screenX( 
    //        /* [out][retval] */ long *p) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_screenY( 
    //        /* [out][retval] */ long *p) = 0;

    //    virtual /* [id][propget] */ HRESULT STDMETHODCALLTYPE get_srcFilter( 
    //        /* [out][retval] */ IDispatch **p) = 0;
    //};
    [ComVisible(true), ComImport()]
    [TypeLibType((short)4160)] //TypeLibTypeFlags.FDispatchable
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f32d-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLEventObj
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_SRCELEMENT)]
        IHTMLElement SrcElement { [return: MarshalAs(UnmanagedType.Interface)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_ALTKEY)]
        bool AltKey { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_CTRLKEY)]
        bool CtrlKey { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_SHIFTKEY)]
        bool ShiftKey { get;}
        //VARIANT
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_RETURNVALUE)]
        Object ReturnValue { set; get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_CANCELBUBBLE)]
        bool CancelBubble { set; [return: MarshalAs(UnmanagedType.VariantBool)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_FROMELEMENT)]
        IHTMLElement FromElement { [return: MarshalAs(UnmanagedType.Interface)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_TOELEMENT)]
        IHTMLElement ToElement { [return: MarshalAs(UnmanagedType.Interface)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_KEYCODE)]
        int keyCode { set; get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_BUTTON)]
        int Button { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_TYPE)]
        string EventType { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_QUALIFIER)]
        string Qualifier { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_REASON)]
        int Reason { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_X)]
        int X { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_Y)]
        int Y { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_CLIENTX)]
        int ClientX { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_CLIENTY)]
        int ClientY { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_OFFSETX)]
        int OffsetX { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_OFFSETY)]
        int OffsetY { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_SCREENX)]
        int ScreenX { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_SCREENY)]
        int ScreenY { get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ_SRCFILTER)]
        object SrcFilter { [return: MarshalAs(UnmanagedType.IDispatch)] get;}
    }
    #endregion

    #region IHTMLElementCollection Interface

    [ComImport(), ComVisible(true),
    Guid("3050F21F-98B5-11CF-BB82-00AA00BDCE0B"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLElementCollection : IEnumerable
    {

        [DispId(HTMLDispIDs.DISPID_IHTMLELEMENTCOLLECTION_TOSTRING)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string toString();

        [DispId(HTMLDispIDs.DISPID_IHTMLELEMENTCOLLECTION_LENGTH)]
        int length { set; get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLELEMENTCOLLECTION__NEWENUM)]
        new IEnumerator GetEnumerator();

        [DispId(HTMLDispIDs.DISPID_IHTMLELEMENTCOLLECTION_ITEM)]
        [return: MarshalAs(UnmanagedType.IDispatch)]
        object item([In] object name, [In] object index);

        [DispId(HTMLDispIDs.DISPID_IHTMLELEMENTCOLLECTION_TAGS)]
        [return: MarshalAs(UnmanagedType.IDispatch)]
        object tags([In] object tagName);
    }

    #endregion

    #region IHtmlFramesCollection2 Interface

    [ComImport, Guid("332c4426-26cb-11d0-b483-00c04fd90119"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLFramesCollection2
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLFRAMESCOLLECTION2_ITEM)]
        [return: MarshalAs(UnmanagedType.IDispatch)]
        object item([In] object pvarIndex);

        [DispId(HTMLDispIDs.DISPID_IHTMLFRAMESCOLLECTION2_LENGTH)]
        int length { get;}
    }

    #endregion

    #region IHtmlWindow2 Interface

    [ComVisible(true), ComImport()]
    [TypeLibType((short)4160)] //TypeLibTypeFlags.FDispatchable
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("332c4427-26cb-11d0-b483-00c04fd90119")]
    public interface IHTMLWindow2
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLFRAMESCOLLECTION2_ITEM)]
        object item([In] object pvarIndex);

        [DispId(HTMLDispIDs.DISPID_IHTMLFRAMESCOLLECTION2_LENGTH)]
        int length { get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_FRAMES)]
        IHTMLFramesCollection2 frames { [return: MarshalAs(UnmanagedType.Interface)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_DEFAULTSTATUS)]
        string defaultStatus { set;  [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_STATUS)]
        string status { set;  [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_SETTIMEOUT)]
        int setTimeout([In] string expression, [In] int msec, [In] ref object language);

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_CLEARTIMEOUT)]
        void clearTimeout([In] int timerID);

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_ALERT)]
        void alert([In, MarshalAs(UnmanagedType.BStr)] string message); //default value ""

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_CONFIRM)]
        bool confirm([In, MarshalAs(UnmanagedType.BStr)] string message);

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_PROMPT)]
        //default for message = ""
        //default for defstr = "undefined"
        object prompt([In, MarshalAs(UnmanagedType.BStr)] string message, 
            [In, MarshalAs(UnmanagedType.BStr)] string defstr, 
            [In] ref object textdata);

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_IMAGE)]
        object Image { get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_LOCATION)]
        object location { get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_HISTORY)]
        object history { get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_CLOSE)]
        void close();

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_OPENER)]
        object opener { set;get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_NAVIGATOR)]
        object navigator { get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_NAME)]
        string name { set; get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_PARENT)]
        IHTMLWindow2 parent { [return: MarshalAs(UnmanagedType.Interface)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_OPEN)]
        IHTMLWindow2 open([In] string url, [In] string name, [In] string features, [In, MarshalAs(UnmanagedType.VariantBool)] bool replace);

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_SELF)]
        IHTMLWindow2 self { [return: MarshalAs(UnmanagedType.Interface)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_TOP)]
        IHTMLWindow2 top { [return: MarshalAs(UnmanagedType.Interface)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_WINDOW)]
        IHTMLWindow2 window { [return: MarshalAs(UnmanagedType.Interface)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_NAVIGATE)]
        void navigate([In, MarshalAs(UnmanagedType.BStr)] string url);

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_ONFOCUS)]
        object onfocus { set;get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_ONBLUR)]
        object onblur { set;get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_ONLOAD)]
        object onload { set;get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_ONBEFOREUNLOAD)]
        object onbeforeunload { set;get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_ONUNLOAD)]
        object onunload { set;get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_ONHELP)]
        object onhelp { set; get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_ONERROR)]
        object onerror { set; get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_ONRESIZE)]
        object onresize { set; get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_ONSCROLL)]
        object onscroll { set; get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_DOCUMENT)]
        IHTMLDocument2 document { [return: MarshalAs(UnmanagedType.Interface)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_EVENT)]
        IHTMLEventObj eventobj { [return: MarshalAs(UnmanagedType.Interface)] get;} //event

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2__NEWENUM)]
        object _newEnum { [return: MarshalAs(UnmanagedType.IUnknown)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_SHOWMODALDIALOG)]
        object showModalDialog([In, MarshalAs(UnmanagedType.BStr)] string dialog,
            [In] ref object varArgIn, [In] ref object varOptions);

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_SHOWHELP)]
        void showHelp([In, MarshalAs(UnmanagedType.BStr)] string helpURL, 
            [In] object helpArg,
            [In, MarshalAs(UnmanagedType.BStr)] string features);

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_SCREEN)]
        object screen { get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_OPTION)]
        object Option { get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_FOCUS)]
        void focus();

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_CLOSED)]
        bool closed { get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_BLUR)]
        void blur();

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_SCROLL)]
        void scroll([In] int x, [In] int y);

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_CLIENTINFORMATION)]
        object clientInformation { get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_SETINTERVAL)]
        int setInterval([In] string expression, [In] int msec, [In] ref object language);

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_CLEARINTERVAL)]
        void clearInterval([In] int timerID);

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_OFFSCREENBUFFERING)]
        object offscreenBuffering { set; get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_EXECSCRIPT)]
        object execScript([In] string code, [In] string language); //default language JScript

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_TOSTRING)]
        string toString();

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_SCROLLBY)]
        void scrollBy([In] int x, [In] int y);

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_SCROLLTO)]
        void scrollTo([In] int x, [In] int y);

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_MOVETO)]
        void moveTo([In] int x, [In] int y);

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_MOVEBY)]
        void moveBy([In] int x, [In] int y);

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_RESIZETO)]
        void resizeTo([In] int x, [In] int y);

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_RESIZEBY)]
        void resizeBy([In] int x, [In] int y);

        [DispId(HTMLDispIDs.DISPID_IHTMLWINDOW2_EXTERNAL)]
        object external { [return: MarshalAs(UnmanagedType.IDispatch)] get;}

    }
    #endregion

    #region IHTMLAnchorElement Interface

    [ComVisible(true), ComImport()]
    [TypeLibType((short)4160)] //TypeLibTypeFlags.FDispatchable
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f1da-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLAnchorElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_HREF)]
        string href { set; [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_TARGET)]
        string target { set; [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_REL)]
        string rel { set; [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_REV)]
        string rev { set; [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_URN)]
        string urn { set; [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_METHODS)]
        string Methods { set; [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_NAME)]
        string name { set; [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_HOST)]
        string host { set; [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_HOSTNAME)]
        string hostname { set; [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_PATHNAME)]
        string pathname { set; [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_PORT)]
        string port { set; [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_PROTOCOL)]
        string protocol { set; [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_SEARCH)]
        string search { [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_HASH)]
        string hash { [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_ONBLUR)]
        object onblur { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_ONFOCUS)]
        object onfocus { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_ACCESSKEY)]
        string accessKey { set; [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_PROTOCOLLONG)]
        string protocolLong { [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_MIMETYPE)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string mimeType();

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_NAMEPROP)]
        string nameProp { [return: MarshalAs(UnmanagedType.BStr)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_TABINDEX)]
        short tabIndex { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_FOCUS)]
        void focus();

        [DispId(HTMLDispIDs.DISPID_IHTMLANCHORELEMENT_BLUR)]
        void blur();
    }

    #endregion

    #region IHTMLImgElement Interface

    [ComVisible(true), ComImport()]
    [TypeLibType((short)4160)] //TypeLibTypeFlags.FDispatchable
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f240-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLImgElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_ISMAP)]
        bool isMap { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_USEMAP)]
        string useMap { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_MIMETYPE)]
        string mimeType { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_FILESIZE)]
        string fileSize { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_FILECREATEDDATE)]
        string fileCreatedDate { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_FILEMODIFIEDDATE)]
        string fileModifiedDate { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_FILEUPDATEDDATE)]
        string fileUpdatedDate { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_PROTOCOL)]
        string protocol { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_HREF)]
        string href { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_NAMEPROP)]
        string nameProp { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_BORDER)]
        object border { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_VSPACE)]
        int vspace { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_HSPACE)]
        int hspace { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_ALT)]
        string alt { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_SRC)]
        string src { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_LOWSRC)]
        string lowsrc { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_VRML)]
        string vrml { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_DYNSRC)]
        string dynsrc { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_READYSTATE)]
        string readyState { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_COMPLETE)]
        bool complete { [return: MarshalAs(UnmanagedType.VariantBool)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_LOOP)]
        object loop { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_ALIGN)]
        string align { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_ONLOAD)]
        object onload { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_ONERROR)]
        object onerror { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_ONABORT)]
        object onabort { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_NAME)]
        string name { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_WIDTH)]
        int width { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_HEIGHT)]
        int height { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLIMGELEMENT_START)]
        string start { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
    }

    #endregion

    #region IHTMLSelectionObject Interface

    [ComVisible(true), ComImport()]
    [TypeLibType((short)4160)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f25A-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLSelectionObject
    {
        [return: MarshalAs(UnmanagedType.IDispatch)]
        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTIONOBJECT_CREATERANGE)]
        object createRange();
        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTIONOBJECT_EMPTY)]
        void empty();
        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTIONOBJECT_CLEAR)]
        void clear();
        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTIONOBJECT_TYPE)]
        string EventType { [return: MarshalAs(UnmanagedType.BStr)] get;}
    }

    #endregion

    #region HTMLDocumentEvents2 Interface

    [ComVisible(true), ComImport()]
    [TypeLibType((short)4160)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f613-98b5-11cf-bb82-00aa00bdce0b")]
    public interface HTMLDocumentEvents2
    {
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONHELP)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onhelp([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONCLICK)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onclick([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONDBLCLICK)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool ondblclick([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONKEYDOWN)]
        void onkeydown([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONKEYUP)]
        void onkeyup([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONKEYPRESS)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onkeypress([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONMOUSEDOWN)]
        void onmousedown([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONMOUSEMOVE)]
        void onmousemove([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONMOUSEUP)]
        void onmouseup([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONMOUSEOUT)]
        void onmouseout([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONMOUSEOVER)]
        void onmouseover([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONREADYSTATECHANGE)]
        void onreadystatechange([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONBEFOREUPDATE)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onbeforeupdate([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONAFTERUPDATE)]
        void onafterupdate([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONROWEXIT)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onrowexit([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONROWENTER)]
        void onrowenter([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONDRAGSTART)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool ondragstart([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONSELECTSTART)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onselectstart([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONERRORUPDATE)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onerrorupdate([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONCONTEXTMENU)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool oncontextmenu([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONSTOP)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onstop([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONROWSDELETE)]
        void onrowsdelete([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONROWSINSERTED)]
        void onrowsinserted([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONCELLCHANGE)]
        void oncellchange([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONPROPERTYCHANGE)]
        void onpropertychange([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONDATASETCHANGED)]
        void ondatasetchanged([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONDATAAVAILABLE)]
        void ondataavailable([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONDATASETCOMPLETE)]
        void ondatasetcomplete([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONBEFOREEDITFOCUS)]
        void onbeforeeditfocus([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONSELECTIONCHANGE)]
        void onselectionchange([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONCONTROLSELECT)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool oncontrolselect([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONMOUSEWHEEL)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onmousewheel([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONFOCUSIN)]
        void onfocusin([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONFOCUSOUT)]
        void onfocusout([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONACTIVATE)]
        void onactivate([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONDEACTIVATE)]
        void ondeactivate([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONBEFOREACTIVATE)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onbeforeactivate([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLDOCUMENTEVENTS2_ONBEFOREDEACTIVATE)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onbeforedeactivate([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
    }

    #endregion

    #region HTMLWindowEvents2 Interface

    [ComVisible(true), ComImport()]
    [TypeLibType((short)4160)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f625-98b5-11cf-bb82-00aa00bdce0b")]
    public interface HTMLWindowEvents2
    {
        [DispId(HTMLDispIDs.DISPID_HTMLWINDOWEVENTS2_ONLOAD)]
        void onload([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLWINDOWEVENTS2_ONUNLOAD)]
        void onunload([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLWINDOWEVENTS2_ONHELP)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        void onhelp([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLWINDOWEVENTS2_ONFOCUS)]
        void onfocus([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLWINDOWEVENTS2_ONBLUR)]
        void onblur([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLWINDOWEVENTS2_ONERROR)]
        void onerror([In, MarshalAs(UnmanagedType.BStr)] string description, [In, MarshalAs(UnmanagedType.BStr)] string url, [In] long line);
        [DispId(HTMLDispIDs.DISPID_HTMLWINDOWEVENTS2_ONRESIZE)]
        void onresize([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLWINDOWEVENTS2_ONSCROLL)]
        void onscroll([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLWINDOWEVENTS2_ONBEFOREUNLOAD)]
        void onbeforeunload([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLWINDOWEVENTS2_ONBEFOREPRINT)]
        void onbeforeprint([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLWINDOWEVENTS2_ONAFTERPRINT)]
        void onafterprint([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
    }

    #endregion

    #region HTMLElementEvents2 Interface
    
    [ComVisible(true), ComImport()]
    [TypeLibType((short)4160)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f60f-98b5-11cf-bb82-00aa00bdce0b")]
    public interface HTMLElementEvents2
    {
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONHELP)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onhelp([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONCLICK)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onclick([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDBLCLICK)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool ondblclick([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONKEYPRESS)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onkeypress([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONKEYDOWN)]
        void onkeydown([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONKEYUP)]
        void onkeyup([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEOUT)]
        void onmouseout([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEOVER)]
        void onmouseover([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEMOVE)]
        void onmousemove([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEDOWN)]
        void onmousedown([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEUP)]
        void onmouseup([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONSELECTSTART)]
        bool onselectstart([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONFILTERCHANGE)]
        void onfilterchange([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDRAGSTART)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool ondragstart([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBEFOREUPDATE)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onbeforeupdate([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONAFTERUPDATE)]
        void onafterupdate([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONERRORUPDATE)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onerrorupdate([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONROWEXIT)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onrowexit([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONROWENTER)]
        void onrowenter([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDATASETCHANGED)]
        void ondatasetchanged([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDATAAVAILABLE)]
        void ondataavailable([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDATASETCOMPLETE)]
        void ondatasetcomplete([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONLOSECAPTURE)]
        void onlosecapture([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONPROPERTYCHANGE)]
        void onpropertychange([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONSCROLL)]
        void onscroll([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONFOCUS)]
        void onfocus([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBLUR)]
        void onblur([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONRESIZE)]
        void onresize([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDRAG)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool ondrag([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDRAGEND)]
        void ondragend([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDRAGENTER)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool ondragenter([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDRAGOVER)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool ondragover([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDRAGLEAVE)]
        void ondragleave([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDROP)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool ondrop([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBEFORECUT)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onbeforecut([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONCUT)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool oncut([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBEFORECOPY)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onbeforecopy([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONCOPY)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool oncopy([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBEFOREPASTE)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onbeforepaste([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONPASTE)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onpaste([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONCONTEXTMENU)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool oncontextmenu([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONROWSDELETE)]
        void onrowsdelete([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONROWSINSERTED)]
        void onrowsinserted([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONCELLCHANGE)]
        void oncellchange([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONREADYSTATECHANGE)]
        void onreadystatechange([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONLAYOUTCOMPLETE)]
        void onlayoutcomplete([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONPAGE)]
        void onpage([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEENTER)]
        void onmouseenter([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSELEAVE)]
        void onmouseleave([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONACTIVATE)]
        void onactivate([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONDEACTIVATE)]
        void ondeactivate([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBEFOREDEACTIVATE)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onbeforedeactivate([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONBEFOREACTIVATE)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onbeforeactivate([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONFOCUSIN)]
        void onfocusin([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONFOCUSOUT)]
        void onfocusout([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOVE)]
        void onmove([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONCONTROLSELECT)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool oncontrolselect([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOVESTART)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onmovestart([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOVEEND)]
        void onmoveend([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONRESIZESTART)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onresizestart([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONRESIZEEND)]
        void onresizeend([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
        [DispId(HTMLDispIDs.DISPID_HTMLELEMENTEVENTS2_ONMOUSEWHEEL)]
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool onmousewheel([In, MarshalAs(UnmanagedType.Interface)] IHTMLEventObj pEvtObj);
    } 
    #endregion

    #region IHTMLElementRender Interface

    /*
        IHTMLDocument3 doc = (IHTMLDocument3)wb.Document;
        IHTMLElement3 el = (IHTMLElement3)doc.documentElement;
        Graphics g = Graphics.FromImage(bm); // your bitmap
        IntPtr hdc = g.GetHdc();
        IHTMLElementRender render = (IHTMLElementRender)el;
        render.DrawToDC(hdc);
        g.ReleaseHdc(hdc);
        g.Dispose();
        }
        ...
        save bitmap as bitmap, gif, tiff, etc.
     */

    [Guid("3050f669-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    [ComVisible(true), ComImport]
    public interface IHTMLElementRender
    {
        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int DrawToDC([In] int hDC);

        [return: MarshalAs(UnmanagedType.I4)]
        [PreserveSig]
        int SetDocumentPrinter([In, MarshalAs(UnmanagedType.BStr)] string
        bstrPrinterName, [In] IntPtr hDC);
    } 
    #endregion

    #region IHTMLDOMNode Interface
    [ComVisible(true), ComImport()]
    [Guid("3050f5da-98b5-11cf-bb82-00aa00bdce0b")]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IHTMLDOMNode
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_NODETYPE)]
        int nodeType { get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_PARENTNODE)]
        IHTMLDOMNode parentNode { get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_HASCHILDNODES)]
        bool hasChildNodes();

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_CHILDNODES)]
        IHTMLDOMChildrenCollection childNodes { [return: MarshalAs(UnmanagedType.Interface)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_ATTRIBUTES)]
        IHTMLAttributeCollection attributes { [return: MarshalAs(UnmanagedType.Interface)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_INSERTBEFORE)]
        IHTMLDOMNode insertBefore([In, MarshalAs(UnmanagedType.Interface)] IHTMLDOMNode newChild, [In, MarshalAs(UnmanagedType.IDispatch)] object refchild);

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_REMOVECHILD)]
        IHTMLDOMNode removeChild([In, MarshalAs(UnmanagedType.Interface)] IHTMLDOMNode oldChild);

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_REPLACECHILD)]
        IHTMLDOMNode replaceChild([In, MarshalAs(UnmanagedType.Interface)] IHTMLDOMNode newChild, [In, MarshalAs(UnmanagedType.Interface)] IHTMLDOMNode oldChild);

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_CLONENODE)]
        IHTMLDOMNode cloneNode([In] bool fDeep);

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_REMOVENODE)]
        IHTMLDOMNode removeNode([In] bool fDeep);

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_SWAPNODE)]
        IHTMLDOMNode swapNode([In, MarshalAs(UnmanagedType.Interface)] IHTMLDOMNode otherNode);

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_REPLACENODE)]
        IHTMLDOMNode replaceNode([In] IHTMLDOMNode replacement);

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_APPENDCHILD)]
        IHTMLDOMNode appendChild([In, MarshalAs(UnmanagedType.Interface)] IHTMLDOMNode newChild);

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_NODENAME)]
        String nodeName { get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_NODEVALUE)]
        Object nodeValue { set; get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_FIRSTCHILD)]
        IHTMLDOMNode firstChild { get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_LASTCHILD)]
        IHTMLDOMNode lastChild { get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_PREVIOUSSIBLING)]
        IHTMLDOMNode previousSibling { get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMNODE_NEXTSIBLING)]
        IHTMLDOMNode nextSibling { get;}
    } 
    #endregion

    #region IHTMLDOMChildrenCollection Interface
    [ComImport, ComVisible(true), Guid("3050f5ab-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLDOMChildrenCollection : IEnumerable
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLDOMCHILDRENCOLLECTION_LENGTH)]
        int length { get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMCHILDRENCOLLECTION__NEWENUM)]
        new IEnumerator GetEnumerator();

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMCHILDRENCOLLECTION_ITEM)]
        [return: MarshalAs(UnmanagedType.IDispatch)]
        object item([In] int lIndex);

    } 
    #endregion

    #region IHTMLAttributeCollection Interface
    [ComImport, ComVisible(true), Guid("3050f4c3-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLAttributeCollection : IEnumerable
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLATTRIBUTECOLLECTION_LENGTH)]
        int length { get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLATTRIBUTECOLLECTION__NEWENUM)]
        new IEnumerator GetEnumerator();

        [DispId(HTMLDispIDs.DISPID_IHTMLATTRIBUTECOLLECTION_ITEM)]
        [return: MarshalAs(UnmanagedType.IDispatch)]
        object item([In] object name);

    } 
    #endregion

    #region IHTMLDOMAttribute Interface
    [ComImport, ComVisible(true), Guid("3050f4b0-98b5-11cf-bb82-00aa00bdce0b"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLDOMAttribute
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE_NODENAME)]
        string nodeName { [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE_NODEVALUE)]
        object nodeValue { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE_SPECIFIED)]
        bool specified { [return: MarshalAs(UnmanagedType.VariantBool)] get; }
    } 
    #endregion

    #region IHTMLDOMAttribute2 Interface

    [ComImport, ComVisible(true), Guid("3050f810-98b5-11cf-bb82-00aa00bdce0b"),
    InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLDOMAttribute2
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE2_NAME)]
        string name { [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE2_VALUE)]
        string value { set;  [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE2_EXPANDO)]
        bool expando { [return: MarshalAs(UnmanagedType.VariantBool)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE2_NODETYPE)]
        int nodeType { get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE2_PARENTNODE)]
        IHTMLDOMNode parentNode { [return: MarshalAs(UnmanagedType.Interface)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE2_CHILDNODES)]
        object childNodes { [return: MarshalAs(UnmanagedType.IDispatch)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE2_FIRSTCHILD)]
        IHTMLDOMNode firstChild { [return: MarshalAs(UnmanagedType.Interface)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE2_LASTCHILD)]
        IHTMLDOMNode lastChild { [return: MarshalAs(UnmanagedType.Interface)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE2_PREVIOUSSIBLING)]
        IHTMLDOMNode previousSibling { [return: MarshalAs(UnmanagedType.Interface)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE2_NEXTSIBLING)]
        IHTMLDOMNode nextSibling { [return: MarshalAs(UnmanagedType.Interface)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE2_ATTRIBUTES)]
        object attributes { [return: MarshalAs(UnmanagedType.IDispatch)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE2_OWNERDOCUMENT)]
        object ownerDocument { [return: MarshalAs(UnmanagedType.IDispatch)] get; }

        [return: MarshalAs(UnmanagedType.Interface)]
        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE2_INSERTBEFORE)]
        IHTMLDOMNode insertBefore([In] IHTMLDOMNode newChild, [In] object refChild);

        [return: MarshalAs(UnmanagedType.Interface)]
        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE2_REPLACECHILD)]
        IHTMLDOMNode replaceChild([In] IHTMLDOMNode newChild);

        [return: MarshalAs(UnmanagedType.Interface)]
        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE2_REMOVECHILD)]
        IHTMLDOMNode removeChild([In] IHTMLDOMNode oldChild);

        [return: MarshalAs(UnmanagedType.Interface)]
        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE2_APPENDCHILD)]
        IHTMLDOMNode appendChild([In] IHTMLDOMNode newChild);

        [return: MarshalAs(UnmanagedType.VariantBool)]
        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE2_HASCHILDNODES)]
        bool hasChildNodes();

        [return: MarshalAs(UnmanagedType.Interface)]
        [DispId(HTMLDispIDs.DISPID_IHTMLDOMATTRIBUTE2_CLONENODE)]
        IHTMLDOMAttribute cloneNode([In] bool fDeep);
    } 
    #endregion

    #region IHTMLDOMTextNode Interface
    [ComImport, ComVisible(true), Guid("3050f4b1-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLDOMTextNode
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLDOMTEXTNODE_DATA)]
        string data { [return: MarshalAs(UnmanagedType.BStr)] get; set; }

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMTEXTNODE_TOSTRING)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string toString();

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMTEXTNODE_LENGTH)]
        int length { get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMTEXTNODE_SPLITTEXT)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IHTMLDOMNode splitText([In] int offset);
    } 
    #endregion

    #region IHTMLDOMTextNode2 Interface
    [ComImport, ComVisible(true), Guid("3050f809-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLDOMTextNode2
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLDOMTEXTNODE2_SUBSTRINGDATA)]
        [return: MarshalAs(UnmanagedType.BStr)]
        string substringData([In] int offset, [In] int Count);

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMTEXTNODE2_APPENDDATA)]
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int appendData([In] string bstrstring);

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMTEXTNODE2_INSERTDATA)]
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int insertData([In] int offset, [In] string bstrstring);

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMTEXTNODE2_DELETEDATA)]
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int deleteData([In] int offset, [In] int Count);

        [DispId(HTMLDispIDs.DISPID_IHTMLDOMTEXTNODE2_REPLACEDATA)]
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.I4)]
        int replaceData([In] int offset, [In] int Count, [In] string bstrstring);
    } 
    #endregion

    #region IHTMLHeadElement Interface
    [ComImport, ComVisible(true), Guid("3050f81d-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLHeadElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLHEADELEMENT_PROFILE)]
        string text { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
    } 
    #endregion

    #region IHTMLTitleElement Interface
    [ComImport, ComVisible(true), Guid("3050f322-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLTitleElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLTITLEELEMENT_TEXT)]
        string text { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
    } 
    #endregion

    #region IHTMLMetaElement Interface
    [ComImport, ComVisible(true), Guid("3050f203-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLMetaElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLMETAELEMENT_HTTPEQUIV)]
        string httpEquiv { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLMETAELEMENT_CONTENT)]
        string content { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLMETAELEMENT_NAME)]
        string name { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLMETAELEMENT_URL)]
        string url { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLMETAELEMENT_CHARSET)]
        string charset { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
    } 
    #endregion

    #region IHTMLBaseElement Interface
    [ComImport, ComVisible(true), Guid("3050f204-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLBaseElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLBASEELEMENT_HREF)]
        string href { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLBASEELEMENT_TARGET)]
        string target { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
    } 
    #endregion

    #region IHTMLNextIdElement Interface
    [ComImport, ComVisible(true), Guid("3050f207-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLNextIdElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLNEXTIDELEMENT_N)]
        string n { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
    } 
    #endregion

    #region IHTMLBaseFontElement Interface
    [ComImport, ComVisible(true), Guid("3050f202-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLBaseFontElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLBASEFONTELEMENT_COLOR)]
        object color { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLBASEFONTELEMENT_FACE)]
        string face { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLBASEFONTELEMENT_SIZE)]
        int size { set; get; }
    } 
    #endregion

    #region IHTMLScriptElement Interface
    [ComImport, ComVisible(true), Guid("3050f28b-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLScriptElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLSCRIPTELEMENT_SRC)]
        string src
        { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLSCRIPTELEMENT_HTMLFOR)]
        string htmlFor { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLSCRIPTELEMENT_EVENT)]
        string scriptevent { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLSCRIPTELEMENT_TEXT)]
        string text { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLSCRIPTELEMENT_DEFER)]
        bool defer { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLSCRIPTELEMENT_READYSTATE)]
        string readyState { [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLSCRIPTELEMENT_ONERROR)]
        object onerror { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLSCRIPTELEMENT_TYPE)]
        string type { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
    } 
    #endregion

    #region IHTMLCommentElement Interface
    [ComImport, ComVisible(true), Guid("3050f20c-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLCommentElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLCOMMENTELEMENT_TEXT)]
        string text { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLCOMMENTELEMENT_ATOMIC)]
        int atomic { set; get; }
    } 
    #endregion

    #region IHTMLTableCol Interface
    [ComImport, ComVisible(true), Guid("3050f23a-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLTableCol
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLTABLECOL_SPAN)]
        string span { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLECOL_WIDTH)]
        object width { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLECOL_ALIGN)]
        string align { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLECOL_VALIGN)]
        string vAlign { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
    } 
    #endregion

    #region IHTMLTableRow Interface
    [ComImport, ComVisible(true), Guid("3050f23c-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLTableRow
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLTABLEROW_ALIGN)]
        string align { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLEROW_VALIGN)]
        string vAlign { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLEROW_BGCOLOR)]
        object bgColor { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLEROW_BORDERCOLOR)]
        object borderColor { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLEROW_BORDERCOLORLIGHT)]
        object borderColorLight { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLEROW_BORDERCOLORDARK)]
        object borderColorDark { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLEROW_ROWINDEX)]
        int rowIndex { get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLEROW_SECTIONROWINDEX)]
        int sectionRowIndex { get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLEROW_CELLS)]
        IHTMLElementCollection cells { [return: MarshalAs(UnmanagedType.Interface)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLEROW_INSERTCELL)]
        [return: MarshalAs(UnmanagedType.Interface)]
        object insertCell(int index);

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLEROW_DELETECELL)]
        int deleteCell(int index);
    } 
    #endregion

    #region IHTMLTableCell Interface
    [ComImport, ComVisible(true), Guid("3050f23d-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLTableCell
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLTABLECELL_ROWSPAN)]
        int rowSpan { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLECELL_COLSPAN)]
        int colSpan { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLECELL_ALIGN)]
        string align { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLECELL_VALIGN)]
        string vAlign { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLECELL_BGCOLOR)]
        object bgColor { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLECELL_NOWRAP)]
        bool noWrap { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLECELL_BACKGROUND)]
        string background { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLECELL_BORDERCOLOR)]
        object borderColor { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLECELL_BORDERCOLORLIGHT)]
        object borderColorLight { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLECELL_BORDERCOLORDARK)]
        object borderColorDark { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLECELL_WIDTH)]
        object width { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLECELL_HEIGHT)]
        object height { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLECELL_CELLINDEX)]
        int cellIndex { get; }
    } 
    #endregion

    #region IHTMLTable Interface
    [ComImport, ComVisible(true), Guid("3050f21e-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLTable
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_COLS)]
        int cols { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_BORDER)]
        object border { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_FRAME)]
        string frame { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_RULES)]
        string rules { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_CELLSPACING)]
        object cellSpacing { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_CELLPADDING)]
        object cellPadding { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_BACKGROUND)]
        string background { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_BGCOLOR)]
        object bgColor { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_BORDERCOLOR)]
        object borderColor { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_BORDERCOLORLIGHT)]
        object borderColorLight { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_BORDERCOLORDARK)]
        object borderColorDark { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_ALIGN)]
        string align { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_REFRESH)]
        int refresh();

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_ROWS)]
        IHTMLElementCollection rows { get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_WIDTH)]
        object width { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_HEIGHT)]
        object height { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_DATAPAGESIZE)]
        int dataPageSize { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_NEXTPAGE)]
        int nextPage();

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_PREVIOUSPAGE)]
        int previousPage();

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_THEAD)]
        object tHead { [return: MarshalAs(UnmanagedType.Interface)] get; } //IHTMLTableSection

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_TFOOT)]
        object tFoot { [return: MarshalAs(UnmanagedType.Interface)] get; } //IHTMLTableSection

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_TBODIES)]
        IHTMLElementCollection tBodies { [return: MarshalAs(UnmanagedType.Interface)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_CAPTION)]
        object caption { [return: MarshalAs(UnmanagedType.Interface)] get; } //IHTMLTableCaption

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_CREATETHEAD)]
        [return: MarshalAs(UnmanagedType.Interface)]
        object createTHead();

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_DELETETHEAD)]
        void deleteTHead();

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_CREATETFOOT)]
        [return: MarshalAs(UnmanagedType.Interface)]
        object createTFoot();

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_DELETETFOOT)]
        void deleteTFoot();

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_CREATECAPTION)]
        [return: MarshalAs(UnmanagedType.Interface)]
        object createCaption(); //IHTMLTableCaption

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_DELETECAPTION)]
        int deleteCaption();

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_INSERTROW)]
        [return: MarshalAs(UnmanagedType.Interface)]
        object insertRow(int index);

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_DELETEROW)]
        void deleteRow(int index);

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_READYSTATE)]
        string readyState { [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLTABLE_ONREADYSTATECHANGE)]
        object onreadystatechange { set; get; }

    } 
    #endregion

    #region IHTMLDataTransfer interface
    [ComImport, ComVisible(true), Guid("3050f4b3-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLDataTransfer
    {
        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool setData([In, MarshalAs(UnmanagedType.BStr)] string format, [In] object data);

        [return: MarshalAs(UnmanagedType.BStr)]
        string getData([In, MarshalAs(UnmanagedType.BStr)] string format);

        [return: MarshalAs(UnmanagedType.VariantBool)]
        bool clearData([In, MarshalAs(UnmanagedType.BStr)] string format);

        string dropEffect { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        string effectAllowed { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
    } 
    #endregion

    #region IHTMLHRElement interface
		    [ComImport, ComVisible(true), Guid("3050f1f4-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLHRElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLHRELEMENT_ALIGN)] 
        string align{ set; [return: MarshalAs(UnmanagedType.BStr)] get; }
    
        [DispId(HTMLDispIDs.DISPID_IHTMLHRELEMENT_COLOR)] 
        object color{ set; get; }
    
        [DispId(HTMLDispIDs.DISPID_IHTMLHRELEMENT_NOSHADE)] 
        bool noShade{ set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }
    
        [DispId(HTMLDispIDs.DISPID_IHTMLHRELEMENT_WIDTH)] 
        object width { set; get; }
    
        [DispId(HTMLDispIDs.DISPID_IHTMLHRELEMENT_SIZE)] 
        object size { set; get; }
    } 
	#endregion

    #region IHTMLStyleSheetsCollection Interface
    [ComImport, ComVisible(true), Guid("3050f37e-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLStyleSheetsCollection : IEnumerable
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLSTYLESHEETSCOLLECTION_LENGTH)]
        int length { get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLSTYLESHEETSCOLLECTION__NEWENUM)]
        new IEnumerator GetEnumerator();

        [DispId(HTMLDispIDs.DISPID_IHTMLSTYLESHEETSCOLLECTION_ITEM)]
        object item([In] object pvarIndex);
    } 
    #endregion

    #region IHTMLInputElement Interface
    [ComImport, ComVisible(true), Guid("3050f5d2-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLInputElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_TYPE)]
        string type { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_VALUE)]
        string value { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_NAME)]
        string name { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_STATUS)]
        bool status { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_DISABLED)]
        bool disabled { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_FORM)]
        object form { [return: MarshalAs(UnmanagedType.Interface)] get;} //IHTMLFormElement* * p

        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_SIZE)]
        int size { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_MAXLENGTH)]
        int maxLength { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_SELECT)]
        int select();

        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_ONCHANGE)]
        object onchange { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_ONSELECT)]
        object onselect { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_DEFAULTVALUE)]
        string defaultValue { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_READONLY)]
        object readOnly { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_CREATETEXTRANGE)]
        IHTMLTxtRange createTextRange();

        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_INDETERMINATE)]
        bool indeterminate { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_DEFAULTCHECKED)]
        bool defaultChecked { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }

        //checked can not be used
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_CHECKED)]
        bool checkeda { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_BORDER)]
        object border { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_VSPACE)]
        int vspace { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_HSPACE)]
        int hspace { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_ALT)]
        string alt { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_SRC)]
        string src { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_LOWSRC)]
        string lowsrc { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_VRML)]
        string vrml { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_DYNSRC)]
        string dynsrc { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_READYSTATE)]
        string readyState { [return: MarshalAs(UnmanagedType.BStr)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_COMPLETE)]
        bool complete { [return: MarshalAs(UnmanagedType.VariantBool)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_LOOP)]
        object loop { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_ALIGN)]
        string align { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_ONLOAD)]
        object onload { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_ONERROR)]
        object onerror { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_ONABORT)]
        object onabort { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_WIDTH)]
        int width { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_HEIGHT)]
        int height { set; get; }
        [DispId(HTMLDispIDs.DISPID_IHTMLINPUTELEMENT_START)]
        string start { set; [return: MarshalAs(UnmanagedType.BStr)] get; }
    } 
    #endregion

    #region IHTMLSelectElement Interface
    [ComImport, ComVisible(true), Guid("3050f244-98b5-11cf-bb82-00aa00bdce0b")]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch),
    TypeLibType(TypeLibTypeFlags.FDispatchable)]
    public interface IHTMLSelectElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTELEMENT_SIZE)]
        int size { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTELEMENT_MULTIPLE)]
        bool multiple { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTELEMENT_NAME)]
        string name { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTELEMENT_OPTIONS)]
        object options { [return: MarshalAs(UnmanagedType.IDispatch)] get;}

        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTELEMENT_ONCHANGE)]
        object onchange { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTELEMENT_SELECTEDINDEX)]
        int selectedIndex { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTELEMENT_TYPE)]
        string type { [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTELEMENT_VALUE)]
        string value { set; [return: MarshalAs(UnmanagedType.BStr)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTELEMENT_DISABLED)]
        bool disabled { set; [return: MarshalAs(UnmanagedType.VariantBool)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTELEMENT_FORM)]
        object form { [return: MarshalAs(UnmanagedType.Interface)] get;} //([retval, out] IHTMLFormElement* * p);

        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTELEMENT_ADD)]
        int add([In] IHTMLElement element, [In] object before);

        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTELEMENT_REMOVE)]
        int remove([In] int index);

        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTELEMENT_LENGTH)]
        int length { set; get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTELEMENT__NEWENUM)]
        object _newEnum { set; [return: MarshalAs(UnmanagedType.IUnknown)] get; }

        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTELEMENT_ITEM)]
        object item([In] object name, [In] object index);

        [DispId(HTMLDispIDs.DISPID_IHTMLSELECTELEMENT_TAGS)]
        object tags([In] object tagName);
    } 
    #endregion

    #region IHTMLTextAreaElement Interface
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f2aa-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLTextAreaElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTAREAELEMENT_TYPE)]
        string type { [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTAREAELEMENT_VALUE)]
        string value { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTAREAELEMENT_NAME)]
        string name { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTAREAELEMENT_STATUS)]
        object status { set;   get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTAREAELEMENT_DISABLED)]
        object disabled { set;   get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTAREAELEMENT_FORM)]
        IHTMLFormElement form { [return: MarshalAs(UnmanagedType.Interface)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTAREAELEMENT_DEFAULTVALUE)]
        string defaultValue { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTAREAELEMENT_SELECT)]
        void select();
        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTAREAELEMENT_ONCHANGE)]
        object onchange { set;   get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTAREAELEMENT_ONSELECT)]
        object onselect { set;   get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTAREAELEMENT_READONLY)]
        object readOnly { set;   get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTAREAELEMENT_ROWS)]
        int rows { set;   get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTAREAELEMENT_COLS)]
        int cols { set;   get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTAREAELEMENT_WRAP)]
        string wrap { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLTEXTAREAELEMENT_CREATETEXTRANGE)]
        [return: MarshalAs(UnmanagedType.Interface)]
        IHTMLTxtRange createTextRange();
    } 
    #endregion

    #region IHTMLFormElement Interface
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f1f7-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLFormElement
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLFORMELEMENT_ACTION)]
        string action { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFORMELEMENT_DIR)]
        string dir { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFORMELEMENT_ENCODING)]
        string encoding { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFORMELEMENT_METHOD)]
        string method { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFORMELEMENT_ELEMENTS)]
        object elements { [return: MarshalAs(UnmanagedType.IDispatch)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFORMELEMENT_TARGET)]
        string target { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFORMELEMENT_NAME)]
        string name { set; [return: MarshalAs(UnmanagedType.BStr)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFORMELEMENT_ONSUBMIT)]
        object onsubmit { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFORMELEMENT_ONRESET)]
        object onreset { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFORMELEMENT_SUBMIT)]
        void submit();
        [DispId(HTMLDispIDs.DISPID_IHTMLFORMELEMENT_RESET)]
        void reset();
        [DispId(HTMLDispIDs.DISPID_IHTMLFORMELEMENT_LENGTH)]
        int length { set;  get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFORMELEMENT__NEWENUM)]
        object _newEnum { [return: MarshalAs(UnmanagedType.IUnknown)] get;}
        [DispId(HTMLDispIDs.DISPID_IHTMLFORMELEMENT_ITEM)]
        [return: MarshalAs(UnmanagedType.IDispatch)]
        object item([In] object name, [In] object index);
        [DispId(HTMLDispIDs.DISPID_IHTMLFORMELEMENT_TAGS)]
        [return: MarshalAs(UnmanagedType.IDispatch)]
        object tags();
    } 
    #endregion

    #region IHTMLEventObj4 Interface
    [ComVisible(true), ComImport()]
    [TypeLibType(TypeLibTypeFlags.FDispatchable)]
    [InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("3050f814-98b5-11cf-bb82-00aa00bdce0b")]
    public interface IHTMLEventObj4
    {
        [DispId(HTMLDispIDs.DISPID_IHTMLEVENTOBJ4_WHEELDELTA)]
        int wheelDelta { get;}
    } 
    #endregion

}