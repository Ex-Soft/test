// MYAUTO3IMPL.H : Declaration of the TMyAuto3Impl

#ifndef MyAuto3ImplH
#define MyAuto3ImplH

#define ATL_FREE_THREADED

#include "Prser_TLB.h"


/////////////////////////////////////////////////////////////////////////////
// TMyAuto3Impl     Implements IMyAuto3, default interface of MyAuto3
// ThreadingModel : Both
// Dual Interface : TRUE
// Event Support  : FALSE
// Default ProgID : AutoSrv.MyAuto3
// Description    : 
/////////////////////////////////////////////////////////////////////////////
class ATL_NO_VTABLE TMyAuto3Impl : 
  public CComObjectRootEx<CComMultiThreadModel>,
  public CComCoClass<TMyAuto3Impl, &CLSID_MyAuto3>,
  public IDispatchImpl<IMyAuto3, &IID_IMyAuto3, &LIBID_Prser>
{
public:
  TMyAuto3Impl()
  {
  }

  // Data used when registering Object 
  //
  DECLARE_THREADING_MODEL(otBoth);
  DECLARE_PROGID("Prser.MyAuto3");
  DECLARE_DESCRIPTION("");

  // Function invoked to (un)register object
  //
  static HRESULT WINAPI UpdateRegistry(BOOL bRegister)
  {
    TTypedComServerRegistrarT<TMyAuto3Impl> 
    regObj(GetObjectCLSID(), GetProgID(), GetDescription());
    return regObj.UpdateRegistry(bRegister);
  }


BEGIN_COM_MAP(TMyAuto3Impl)
  COM_INTERFACE_ENTRY(IMyAuto3)
  COM_INTERFACE_ENTRY2(IDispatch, IMyAuto3)
END_COM_MAP()

// IMyAuto3
public:
 
  STDMETHOD(AddLine(BSTR Line));
  STDMETHOD(get_Visible(VARIANT_BOOL* Value));
  STDMETHOD(get_Width(int* Value));
  STDMETHOD(NewFile());
  STDMETHOD(OpenFile(BSTR FileName));
  STDMETHOD(SaveFile(BSTR FileName));
  STDMETHOD(set_Visible(VARIANT_BOOL Value));
  STDMETHOD(set_Width(int Value));
};

#endif //MyAuto3ImplH
