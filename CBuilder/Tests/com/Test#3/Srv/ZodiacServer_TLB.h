// ************************************************************************ //
// WARNING                                                                    
// -------                                                                    
// The types declared in this file were generated from data read from a       
// Type Library. If this type library is explicitly or indirectly (via        
// another type library referring to this type library) re-imported, or the   
// 'Refresh' command of the Type Library Editor activated while editing the   
// Type Library, the contents of this file will be regenerated and all        
// manual modifications will be lost.                                         
// ************************************************************************ //

// C++ TLBWRTR : $Revision:   1.151.1.0.1.27  $
// File generated on 01.10.2004 5:27:49 pm from Type Library described below.

// ************************************************************************  //
// Type Lib: D:\My_Doc\CBuilder\Tests\com\Test#3\Srv\ZodiacServer.tlb (1)
// LIBID: {F120FFEB-B4CC-4A5B-8356-B7F54EB35087}
// LCID: 0
// Helpfile: 
// HelpString: ZodiacServer Library
// DepndLst: 
//   (1) v2.0 stdole, (C:\WINNT\System32\stdole2.tlb)
// ************************************************************************ //
#ifndef   ZodiacServer_TLBH
#define   ZodiacServer_TLBH

#pragma option push -b -w-inl

#include <utilcls.h>
#if !defined(__UTILCLS_H_VERSION) || (__UTILCLS_H_VERSION < 0x0600)
//
// The code generated by the TLIBIMP utility or the Import|TypeLibrary 
// and Import|ActiveX feature of C++Builder rely on specific versions of
// the header file UTILCLS.H found in the INCLUDE\VCL directory. If an 
// older version of the file is detected, you probably need an update/patch.
//
#error "This file requires a newer version of the header UTILCLS.H" \
       "You need to apply an update/patch to your copy of C++Builder"
#endif
#include <olectl.h>
#include <ocidl.h>
#if defined(USING_ATLVCL) || defined(USING_ATL)
#if !defined(__TLB_NO_EVENT_WRAPPERS)
#include <atl/atlmod.h>
#endif
#endif


// *********************************************************************//
// Forward reference of some VCL types (to avoid including STDVCL.HPP)    
// *********************************************************************//
namespace Stdvcl {class IStrings; class IStringsDisp;}
using namespace Stdvcl;
typedef TComInterface<IStrings> IStringsPtr;
typedef TComInterface<IStringsDisp> IStringsDispPtr;

namespace Zodiacserver_tlb
{

// *********************************************************************//
// HelpString: ZodiacServer Library
// Version:    1.0
// *********************************************************************//


// *********************************************************************//
// GUIDS declared in the TypeLibrary. Following prefixes are used:        
//   Type Libraries     : LIBID_xxxx                                      
//   CoClasses          : CLSID_xxxx                                      
//   DISPInterfaces     : DIID_xxxx                                       
//   Non-DISP interfaces: IID_xxxx                                        
// *********************************************************************//
extern "C" const __declspec(selectany) GUID LIBID_ZodiacServer = {0xF120FFEB, 0xB4CC, 0x4A5B,{ 0x83, 0x56, 0xB7,0xF5, 0x4E, 0xB3,0x50, 0x87} };
extern "C" const __declspec(selectany) GUID IID_IZodiac = {0x657C7B54, 0xB096, 0x4A2D,{ 0xA8, 0x62, 0xBC,0x70, 0x29, 0xF1,0x0F, 0x0B} };
extern "C" const __declspec(selectany) GUID DIID_IZodiacEvents = {0x84D0C9FD, 0x3765, 0x455B,{ 0xB0, 0x9D, 0xE2,0xE5, 0x04, 0xE5,0x15, 0x1F} };
extern "C" const __declspec(selectany) GUID CLSID_Zodiac = {0x066953ED, 0x27A6, 0x46C3,{ 0x82, 0x48, 0x18,0xF3, 0xDD, 0x71,0xF1, 0xB8} };

// *********************************************************************//
// Forward declaration of types defined in TypeLibrary                    
// *********************************************************************//
interface DECLSPEC_UUID("{657C7B54-B096-4A2D-A862-BC7029F10F0B}") IZodiac;
typedef TComInterface<IZodiac, &IID_IZodiac> IZodiacPtr;

interface DECLSPEC_UUID("{84D0C9FD-3765-455B-B09D-E2E504E5151F}") IZodiacEvents;
typedef TComInterface<IZodiacEvents, &DIID_IZodiacEvents> IZodiacEventsPtr;


// *********************************************************************//
// Declaration of CoClasses defined in Type Library                       
// (NOTE: Here we map each CoClass to its Default Interface)              
//                                                                        
// The LIBID_OF_ macro(s) map a LIBID_OF_CoClassName to the GUID of this  
// TypeLibrary. It simplifies the updating of macros when CoClass name    
// change.                                                                
// *********************************************************************//
typedef IZodiac Zodiac;
typedef IZodiacPtr ZodiacPtr;

#define LIBID_OF_Zodiac (&LIBID_ZodiacServer)
// *********************************************************************//
// Interface: IZodiac
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {657C7B54-B096-4A2D-A862-BC7029F10F0B}
// *********************************************************************//
interface IZodiac  : public IDispatch
{
public:
  virtual HRESULT STDMETHODCALLTYPE GetZodiacSign(long Day/*[in]*/, long Month/*[in]*/, 
                                                  BSTR* Sign/*[out,retval]*/) = 0; // [1]
  virtual HRESULT STDMETHODCALLTYPE GetZodiacSignAsync(long Day/*[in]*/, long Month/*[in]*/) = 0; // [2]

#if !defined(__TLB_NO_INTERFACE_WRAPPERS)

  BSTR __fastcall GetZodiacSign(long Day/*[in]*/, long Month/*[in]*/)
  {
    BSTR Sign = 0;
    OLECHECK(this->GetZodiacSign(Day, Month, (BSTR*)&Sign));
    return Sign;
  }



#endif //   __TLB_NO_INTERFACE_WRAPPERS

};

// *********************************************************************//
// Interface: IZodiacEvents
// Flags:     (0)
// GUID:      {84D0C9FD-3765-455B-B09D-E2E504E5151F}
// *********************************************************************//
interface IZodiacEvents : public TDispWrapper<IDispatch>
{
  HRESULT __fastcall OnZodiacReady(BSTR Sign/*[in]*/)
  {
    _TDispID _dispid(/* OnZodiacReady */ DISPID(1));
    TAutoArgs<1> _args;
    _args[1] = Sign /*[VT_BSTR:0]*/;
    return OleFunction(_dispid, _args);
  }


};
#if !defined(__TLB_NO_INTERFACE_WRAPPERS)
// *********************************************************************//
// SmartIntf: TCOMIZodiac
// Interface: IZodiac
// *********************************************************************//
template <class T /* IZodiac */ >
class TCOMIZodiacT : public TComInterface<IZodiac>, public TComInterfaceBase<IUnknown>
{
public:
  TCOMIZodiacT() {}
  TCOMIZodiacT(IZodiac *intf, bool addRef = false) : TComInterface<IZodiac>(intf, addRef) {}
  TCOMIZodiacT(const TCOMIZodiacT& src) : TComInterface<IZodiac>(src) {}
  TCOMIZodiacT& operator=(const TCOMIZodiacT& src) { Bind(src, true); return *this;}

  HRESULT         __fastcall GetZodiacSign(long Day/*[in]*/, long Month/*[in]*/, 
                                           BSTR* Sign/*[out,retval]*/);
  BSTR            __fastcall GetZodiacSign(long Day/*[in]*/, long Month/*[in]*/);
  HRESULT         __fastcall GetZodiacSignAsync(long Day/*[in]*/, long Month/*[in]*/);

};
typedef TCOMIZodiacT<IZodiac> TCOMIZodiac;

// *********************************************************************//
// DispIntf:  IZodiac
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {657C7B54-B096-4A2D-A862-BC7029F10F0B}
// *********************************************************************//
template<class T>
class IZodiacDispT : public TAutoDriver<IZodiac>
{
public:
  IZodiacDispT(){}

  IZodiacDispT(IZodiac *pintf)
  {
    TAutoDriver<IZodiac>::Bind(pintf, false);
  }

  IZodiacDispT(IZodiacPtr pintf)
  {
    TAutoDriver<IZodiac>::Bind(pintf, true);
  }

  IZodiacDispT& operator=(IZodiac *pintf)
  {
    TAutoDriver<IZodiac>::Bind(pintf, false);
    return *this;
  }

  IZodiacDispT& operator=(IZodiacPtr pintf)
  {
    TAutoDriver<IZodiac>::Bind(pintf, true);
    return *this;
  }

  HRESULT BindDefault()
  {
    return OLECHECK(Bind(CLSID_Zodiac));
  }

  HRESULT BindRunning()
  {
    return BindToActive(CLSID_Zodiac);
  }

  HRESULT         __fastcall GetZodiacSign(long Day/*[in]*/, long Month/*[in]*/, 
                                           BSTR* Sign/*[out,retval]*/);
  BSTR            __fastcall GetZodiacSign(long Day/*[in]*/, long Month/*[in]*/);
  HRESULT         __fastcall GetZodiacSignAsync(long Day/*[in]*/, long Month/*[in]*/);

};
typedef IZodiacDispT<IZodiac> IZodiacDisp;

// *********************************************************************//
// DispIntf:  IZodiacEvents
// Flags:     (0)
// GUID:      {84D0C9FD-3765-455B-B09D-E2E504E5151F}
// *********************************************************************//
template <class T>
class IZodiacEventsDispT : public TAutoDriver<IZodiacEvents>
{
public:
  IZodiacEventsDispT(){}

  void Attach(LPUNKNOWN punk)
  { m_Dispatch = static_cast<T*>(punk); }

  HRESULT         __fastcall OnZodiacReady(BSTR Sign/*[in]*/);

};
typedef IZodiacEventsDispT<IZodiacEvents> IZodiacEventsDisp;

// *********************************************************************//
// SmartIntf: TCOMIZodiac
// Interface: IZodiac
// *********************************************************************//
template <class T> HRESULT __fastcall
TCOMIZodiacT<T>::GetZodiacSign(long Day/*[in]*/, long Month/*[in]*/, BSTR* Sign/*[out,retval]*/)
{
  return (*this)->GetZodiacSign(Day, Month, Sign);
}

template <class T> BSTR __fastcall
TCOMIZodiacT<T>::GetZodiacSign(long Day/*[in]*/, long Month/*[in]*/)
{
  BSTR Sign = 0;
  OLECHECK(this->GetZodiacSign(, (BSTR*)&Sign));
  return Sign;
}

template <class T> HRESULT __fastcall
TCOMIZodiacT<T>::GetZodiacSignAsync(long Day/*[in]*/, long Month/*[in]*/)
{
  return (*this)->GetZodiacSignAsync(Day, Month);
}

// *********************************************************************//
// DispIntf:  IZodiac
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {657C7B54-B096-4A2D-A862-BC7029F10F0B}
// *********************************************************************//
template <class T> HRESULT __fastcall
IZodiacDispT<T>::GetZodiacSign(long Day/*[in]*/, long Month/*[in]*/, BSTR* Sign/*[out,retval]*/)
{
  _TDispID _dispid(*this, OLETEXT("GetZodiacSign"), DISPID(1));
  TAutoArgs<2> _args;
  _args[1] = Day /*[VT_I4:0]*/;
  _args[2] = Month /*[VT_I4:0]*/;
  return OutRetValSetterPtr(Sign /*[VT_BSTR:1]*/, _args, OleFunction(_dispid, _args));
}

template <class T> BSTR __fastcall
IZodiacDispT<T>::GetZodiacSign(long Day/*[in]*/, long Month/*[in]*/)
{
  BSTR Sign;
  this->GetZodiacSign(Day, Month, (BSTR*)&Sign);
  return Sign;
}

template <class T> HRESULT __fastcall
IZodiacDispT<T>::GetZodiacSignAsync(long Day/*[in]*/, long Month/*[in]*/)
{
  _TDispID _dispid(*this, OLETEXT("GetZodiacSignAsync"), DISPID(2));
  TAutoArgs<2> _args;
  _args[1] = Day /*[VT_I4:0]*/;
  _args[2] = Month /*[VT_I4:0]*/;
  return OleFunction(_dispid, _args);
}

// *********************************************************************//
// DispIntf:  IZodiacEvents
// Flags:     (0)
// GUID:      {84D0C9FD-3765-455B-B09D-E2E504E5151F}
// *********************************************************************//
template <class T> HRESULT __fastcall
IZodiacEventsDispT<T>::OnZodiacReady(BSTR Sign/*[in]*/)
{
  _TDispID _dispid(/* OnZodiacReady */ DISPID(1));
  TAutoArgs<1> _args;
  _args[1] = Sign /*[VT_BSTR:0]*/;
  return OleFunction(_dispid, _args);
}

// *********************************************************************//
// The following typedefs expose classes (named CoCoClassName) that       
// provide static Create() and CreateRemote(LPWSTR machineName) methods   
// for creating an instance of an exposed object. These functions can     
// be used by client wishing to automate CoClasses exposed by this        
// typelibrary.                                                           
// *********************************************************************//

// *********************************************************************//
// COCLASS DEFAULT INTERFACE CREATOR
// CoClass  : Zodiac
// Interface: TCOMIZodiac
// *********************************************************************//
typedef TCoClassCreatorT<TCOMIZodiac, IZodiac, &CLSID_Zodiac, &IID_IZodiac> CoZodiac;
#endif  //   __TLB_NO_INTERFACE_WRAPPERS


#if !defined(__TLB_NO_EVENT_WRAPPERS) && defined(USING_ATLVCL)
// *********************************************************************//
// CONNECTIONPOINT/EVENT PROXY
// CoClass         : Zodiac
// Event Interface : IZodiacEvents
// *********************************************************************//
template <class T>
class TEvents_Zodiac : public IConnectionPointImpl<T,
                                                 &DIID_IZodiacEvents,
                                                 CComUnkArray<CONNECTIONPOINT_ARRAY_SIZE> >
 /* Note: if encountering problems with events, please change CComUnkArray to CComDynamicUnkArray in the line above. */
{
public:
  HRESULT         Fire_OnZodiacReady(BSTR Sign);
protected:
  IZodiacEventsDisp m_EventIntfObj;
};

template <class T> HRESULT
TEvents_Zodiac<T>::Fire_OnZodiacReady(BSTR Sign)
{
  T * pT = (T*)this;
  pT->Lock();
  IUnknown ** pp = m_vec.begin();
  while (pp < m_vec.end())
  {
    if (*pp != NULL)
    {
      m_EventIntfObj.Attach(*pp);
      m_EventIntfObj.OnZodiacReady(Sign);
      m_EventIntfObj.Attach(0);
    }
    pp++;
  }
  pT->Unlock();
}

#endif  //   __TLB_NO_EVENT_WRAPPERS

};     // namespace Zodiacserver_tlb

#if !defined(NO_IMPLICIT_NAMESPACE_USE)
using  namespace Zodiacserver_tlb;
#endif

#pragma option pop

#endif // ZodiacServer_TLBH
