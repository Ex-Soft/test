// ZODIACIMPL.H : Declaration of the TZodiacImpl

#ifndef ZodiacImplH
#define ZodiacImplH

#define ATL_FREE_THREADED

#include "ZodiacServer_TLB.H"


/////////////////////////////////////////////////////////////////////////////
// TZodiacImpl     Implements IZodiac, default interface of Zodiac
//                  and IZodiacEvents, the default source interface
// ThreadingModel : Free
// Dual Interface : TRUE
// Event Support  : TRUE
// Default ProgID : ZodiacServer.Zodiac
// Description    : Some description
/////////////////////////////////////////////////////////////////////////////
class ATL_NO_VTABLE TZodiacImpl : 
  public CComObjectRootEx<CComMultiThreadModel>,
  public CComCoClass<TZodiacImpl, &CLSID_Zodiac>,
  public IConnectionPointContainerImpl<TZodiacImpl>,
  public TEvents_Zodiac<TZodiacImpl>, 
  public IDispatchImpl<IZodiac, &IID_IZodiac, &LIBID_ZodiacServer>
{
public:
  TZodiacImpl()
  {
  }

  // Data used when registering Object 
  //
  DECLARE_THREADING_MODEL(otFree);
  DECLARE_PROGID("ZodiacServer.Zodiac");
  DECLARE_DESCRIPTION("Some description");

  // Function invoked to (un)register object
  //
  static HRESULT WINAPI UpdateRegistry(BOOL bRegister)
  {
    TTypedComServerRegistrarT<TZodiacImpl> 
    regObj(GetObjectCLSID(), GetProgID(), GetDescription());
    return regObj.UpdateRegistry(bRegister);
  }


BEGIN_COM_MAP(TZodiacImpl)
  COM_INTERFACE_ENTRY(IZodiac)
  COM_INTERFACE_ENTRY2(IDispatch, IZodiac)
  COM_INTERFACE_ENTRY_IMPL(IConnectionPointContainer)
END_COM_MAP()

BEGIN_CONNECTION_POINT_MAP(TZodiacImpl)
  CONNECTION_POINT_ENTRY(DIID_IZodiacEvents)
END_CONNECTION_POINT_MAP()

// IZodiac
public:
 
  STDMETHOD(GetZodiacSign(long Day, long Month, BSTR* Sign));
  STDMETHOD(GetZodiacSignAsync(long Day, long Month));
};

#endif //ZodiacImplH
