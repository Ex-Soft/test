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
// File generated on 01.10.2004 5:12:59 pm from Type Library described below.

// ************************************************************************  //
// Type Lib: D:\My_Doc\CBuilder\Tests\com\Test#1\Prser.tlb (1)
// LIBID: {DC06E76D-7412-4812-A1AF-A3C0390D0093}
// LCID: 0
// Helpfile: 
// HelpString: AutoSrv Library
// DepndLst: 
//   (1) v2.0 stdole, (C:\WINNT\System32\stdole2.tlb)
// ************************************************************************ //
#ifndef   Prser_TLBH
#define   Prser_TLBH

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

namespace Prser_tlb
{

// *********************************************************************//
// HelpString: AutoSrv Library
// Version:    1.0
// *********************************************************************//


// *********************************************************************//
// GUIDS declared in the TypeLibrary. Following prefixes are used:        
//   Type Libraries     : LIBID_xxxx                                      
//   CoClasses          : CLSID_xxxx                                      
//   DISPInterfaces     : DIID_xxxx                                       
//   Non-DISP interfaces: IID_xxxx                                        
// *********************************************************************//
extern "C" const __declspec(selectany) GUID LIBID_Prser = {0xDC06E76D, 0x7412, 0x4812,{ 0xA1, 0xAF, 0xA3,0xC0, 0x39, 0x0D,0x00, 0x93} };
extern "C" const __declspec(selectany) GUID IID_IMyAuto3 = {0x170582E7, 0x8D0B, 0x4D32,{ 0xB0, 0x61, 0x87,0x58, 0xF7, 0x6A,0xE3, 0xC5} };
extern "C" const __declspec(selectany) GUID CLSID_MyAuto3 = {0x41C49792, 0x169E, 0x4F7C,{ 0xB0, 0x4D, 0x6F,0xDA, 0x6F, 0x99,0x8E, 0xD2} };

// *********************************************************************//
// Forward declaration of types defined in TypeLibrary                    
// *********************************************************************//
interface DECLSPEC_UUID("{170582E7-8D0B-4D32-B061-8758F76AE3C5}") IMyAuto3;
typedef TComInterface<IMyAuto3, &IID_IMyAuto3> IMyAuto3Ptr;


// *********************************************************************//
// Declaration of CoClasses defined in Type Library                       
// (NOTE: Here we map each CoClass to its Default Interface)              
//                                                                        
// The LIBID_OF_ macro(s) map a LIBID_OF_CoClassName to the GUID of this  
// TypeLibrary. It simplifies the updating of macros when CoClass name    
// change.                                                                
// *********************************************************************//
typedef IMyAuto3 MyAuto3;
typedef IMyAuto3Ptr MyAuto3Ptr;

#define LIBID_OF_MyAuto3 (&LIBID_Prser)
// *********************************************************************//
// Interface: IMyAuto3
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {170582E7-8D0B-4D32-B061-8758F76AE3C5}
// *********************************************************************//
interface IMyAuto3  : public IDispatch
{
public:
  virtual HRESULT STDMETHODCALLTYPE get_Width(int* Value/*[out,retval]*/) = 0; // [1]
  virtual HRESULT STDMETHODCALLTYPE set_Width(int Value/*[in]*/) = 0; // [1]
  virtual HRESULT STDMETHODCALLTYPE get_Visible(VARIANT_BOOL* Value/*[out,retval]*/) = 0; // [2]
  virtual HRESULT STDMETHODCALLTYPE set_Visible(VARIANT_BOOL Value/*[in]*/) = 0; // [2]
  virtual HRESULT STDMETHODCALLTYPE NewFile(void) = 0; // [3]
  virtual HRESULT STDMETHODCALLTYPE SaveFile(BSTR FileName/*[in]*/) = 0; // [4]
  virtual HRESULT STDMETHODCALLTYPE AddLine(BSTR Line/*[in]*/) = 0; // [5]
  virtual HRESULT STDMETHODCALLTYPE OpenFile(BSTR FileName/*[in]*/) = 0; // [6]

#if !defined(__TLB_NO_INTERFACE_WRAPPERS)

  int __fastcall get_Width(void)
  {
    int Value;
    OLECHECK(this->get_Width((int*)&Value));
    return Value;
  }

  VARIANT_BOOL __fastcall get_Visible(void)
  {
    VARIANT_BOOL Value;
    OLECHECK(this->get_Visible((VARIANT_BOOL*)&Value));
    return Value;
  }


  __property   int             Width = {read = get_Width, write = set_Width};
  __property   VARIANT_BOOL    Visible = {read = get_Visible, write = set_Visible};

#endif //   __TLB_NO_INTERFACE_WRAPPERS

};

#if !defined(__TLB_NO_INTERFACE_WRAPPERS)
// *********************************************************************//
// SmartIntf: TCOMIMyAuto3
// Interface: IMyAuto3
// *********************************************************************//
template <class T /* IMyAuto3 */ >
class TCOMIMyAuto3T : public TComInterface<IMyAuto3>, public TComInterfaceBase<IUnknown>
{
public:
  TCOMIMyAuto3T() {}
  TCOMIMyAuto3T(IMyAuto3 *intf, bool addRef = false) : TComInterface<IMyAuto3>(intf, addRef) {}
  TCOMIMyAuto3T(const TCOMIMyAuto3T& src) : TComInterface<IMyAuto3>(src) {}
  TCOMIMyAuto3T& operator=(const TCOMIMyAuto3T& src) { Bind(src, true); return *this;}

  HRESULT         __fastcall get_Width(int* Value/*[out,retval]*/);
  int             __fastcall get_Width(void);
  HRESULT         __fastcall set_Width(int Value/*[in]*/);
  HRESULT         __fastcall get_Visible(VARIANT_BOOL* Value/*[out,retval]*/);
  HRESULT         __fastcall get_Visible(TOLEBOOL* Value/*[out,retval]*/);
  TOLEBOOL        __fastcall get_Visible(void);
  HRESULT         __fastcall set_Visible(VARIANT_BOOL Value/*[in]*/);
  HRESULT         __fastcall set_Visible(TOLEBOOL Value/*[in]*/);
  HRESULT         __fastcall NewFile(void);
  HRESULT         __fastcall SaveFile(BSTR FileName/*[in]*/);
  HRESULT         __fastcall AddLine(BSTR Line/*[in]*/);
  HRESULT         __fastcall OpenFile(BSTR FileName/*[in]*/);

  __property   int             Width = {read = get_Width, write = set_Width};
  __property   TOLEBOOL        Visible = {read = get_Visible, write = set_Visible};
};
typedef TCOMIMyAuto3T<IMyAuto3> TCOMIMyAuto3;

// *********************************************************************//
// DispIntf:  IMyAuto3
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {170582E7-8D0B-4D32-B061-8758F76AE3C5}
// *********************************************************************//
template<class T>
class IMyAuto3DispT : public TAutoDriver<IMyAuto3>
{
public:
  IMyAuto3DispT(){}

  IMyAuto3DispT(IMyAuto3 *pintf)
  {
    TAutoDriver<IMyAuto3>::Bind(pintf, false);
  }

  IMyAuto3DispT(IMyAuto3Ptr pintf)
  {
    TAutoDriver<IMyAuto3>::Bind(pintf, true);
  }

  IMyAuto3DispT& operator=(IMyAuto3 *pintf)
  {
    TAutoDriver<IMyAuto3>::Bind(pintf, false);
    return *this;
  }

  IMyAuto3DispT& operator=(IMyAuto3Ptr pintf)
  {
    TAutoDriver<IMyAuto3>::Bind(pintf, true);
    return *this;
  }

  HRESULT BindDefault()
  {
    return OLECHECK(Bind(CLSID_MyAuto3));
  }

  HRESULT BindRunning()
  {
    return BindToActive(CLSID_MyAuto3);
  }

  HRESULT         __fastcall get_Width(int* Value/*[out,retval]*/);
  int             __fastcall get_Width(void);
  HRESULT         __fastcall set_Width(int Value/*[in]*/);
  HRESULT         __fastcall get_Visible(VARIANT_BOOL* Value/*[out,retval]*/);
  VARIANT_BOOL    __fastcall get_Visible(void);
  HRESULT         __fastcall set_Visible(VARIANT_BOOL Value/*[in]*/);
  HRESULT         __fastcall NewFile();
  HRESULT         __fastcall SaveFile(BSTR FileName/*[in]*/);
  HRESULT         __fastcall AddLine(BSTR Line/*[in]*/);
  HRESULT         __fastcall OpenFile(BSTR FileName/*[in]*/);

  __property   int             Width = {read = get_Width, write = set_Width};
  __property   VARIANT_BOOL    Visible = {read = get_Visible, write = set_Visible};
};
typedef IMyAuto3DispT<IMyAuto3> IMyAuto3Disp;

// *********************************************************************//
// SmartIntf: TCOMIMyAuto3
// Interface: IMyAuto3
// *********************************************************************//
template <class T> HRESULT __fastcall
TCOMIMyAuto3T<T>::get_Width(int* Value/*[out,retval]*/)
{
  return (*this)->get_Width(Value);
}

template <class T> int __fastcall
TCOMIMyAuto3T<T>::get_Width(void)
{
  int Value;
  OLECHECK(this->get_Width((int*)&Value));
  return Value;
}

template <class T> HRESULT __fastcall
TCOMIMyAuto3T<T>::set_Width(int Value/*[in]*/)
{
  return (*this)->set_Width(Value);
}

template <class T> HRESULT __fastcall
TCOMIMyAuto3T<T>::get_Visible(VARIANT_BOOL* Value/*[out,retval]*/)
{
  return (*this)->get_Visible(Value);
}

template <class T> HRESULT __fastcall
TCOMIMyAuto3T<T>::get_Visible(TOLEBOOL* Value/*[out,retval]*/)
{
  return (*this)->get_Visible(VARIANT_BOOL*)Value);
}

template <class T> TOLEBOOL __fastcall
TCOMIMyAuto3T<T>::get_Visible(void)
{
  VARIANT_BOOL Value;
  OLECHECK(this->get_Visible((VARIANT_BOOL*)&Value));
  return (TOLEBOOL)Value;
}

template <class T> HRESULT __fastcall
TCOMIMyAuto3T<T>::set_Visible(VARIANT_BOOL Value/*[in]*/)
{
  return (*this)->set_Visible(Value);
}

template <class T> HRESULT __fastcall
TCOMIMyAuto3T<T>::set_Visible(TOLEBOOL Value/*[in]*/)
{
  return (*this)->set_Visible(VARIANT_BOOL)Value);
}

template <class T> HRESULT __fastcall
TCOMIMyAuto3T<T>::NewFile(void)
{
  return (*this)->NewFile();
}

template <class T> HRESULT __fastcall
TCOMIMyAuto3T<T>::SaveFile(BSTR FileName/*[in]*/)
{
  return (*this)->SaveFile(FileName);
}

template <class T> HRESULT __fastcall
TCOMIMyAuto3T<T>::AddLine(BSTR Line/*[in]*/)
{
  return (*this)->AddLine(Line);
}

template <class T> HRESULT __fastcall
TCOMIMyAuto3T<T>::OpenFile(BSTR FileName/*[in]*/)
{
  return (*this)->OpenFile(FileName);
}

// *********************************************************************//
// DispIntf:  IMyAuto3
// Flags:     (4416) Dual OleAutomation Dispatchable
// GUID:      {170582E7-8D0B-4D32-B061-8758F76AE3C5}
// *********************************************************************//
template <class T> HRESULT __fastcall
IMyAuto3DispT<T>::get_Width(int* Value/*[out,retval]*/)
{
  _TDispID _dispid(*this, OLETEXT("Width"), DISPID(1));
  TAutoArgs<0> _args;
  return OutRetValSetterPtr(Value /*[VT_INT:1]*/, _args, OlePropertyGet(_dispid, _args));
}

template <class T> int __fastcall
IMyAuto3DispT<T>::get_Width(void)
{
  int Value;
  this->get_Width((int*)&Value);
  return Value;
}

template <class T> HRESULT __fastcall
IMyAuto3DispT<T>::set_Width(int Value/*[in]*/)
{
  _TDispID _dispid(*this, OLETEXT("Width"), DISPID(1));
  TAutoArgs<1> _args;
  _args[1] = Value /*[VT_INT:0]*/;
  return OlePropertyPut(_dispid, _args);
}

template <class T> HRESULT __fastcall
IMyAuto3DispT<T>::get_Visible(VARIANT_BOOL* Value/*[out,retval]*/)
{
  _TDispID _dispid(*this, OLETEXT("Visible"), DISPID(2));
  TAutoArgs<0> _args;
  return OutRetValSetterPtr(Value /*[VT_BOOL:1]*/, _args, OlePropertyGet(_dispid, _args));
}

template <class T> VARIANT_BOOL __fastcall
IMyAuto3DispT<T>::get_Visible(void)
{
  VARIANT_BOOL Value;
  this->get_Visible((VARIANT_BOOL*)&Value);
  return Value;
}

template <class T> HRESULT __fastcall
IMyAuto3DispT<T>::set_Visible(VARIANT_BOOL Value/*[in]*/)
{
  _TDispID _dispid(*this, OLETEXT("Visible"), DISPID(2));
  TAutoArgs<1> _args;
  _args[1] = Value /*[VT_BOOL:0]*/;
  return OlePropertyPut(_dispid, _args);
}

template <class T> HRESULT __fastcall
IMyAuto3DispT<T>::NewFile()
{
  _TDispID _dispid(*this, OLETEXT("NewFile"), DISPID(3));
  return OleFunction(_dispid);
}

template <class T> HRESULT __fastcall
IMyAuto3DispT<T>::SaveFile(BSTR FileName/*[in]*/)
{
  _TDispID _dispid(*this, OLETEXT("SaveFile"), DISPID(4));
  TAutoArgs<1> _args;
  _args[1] = FileName /*[VT_BSTR:0]*/;
  return OleFunction(_dispid, _args);
}

template <class T> HRESULT __fastcall
IMyAuto3DispT<T>::AddLine(BSTR Line/*[in]*/)
{
  _TDispID _dispid(*this, OLETEXT("AddLine"), DISPID(5));
  TAutoArgs<1> _args;
  _args[1] = Line /*[VT_BSTR:0]*/;
  return OleFunction(_dispid, _args);
}

template <class T> HRESULT __fastcall
IMyAuto3DispT<T>::OpenFile(BSTR FileName/*[in]*/)
{
  _TDispID _dispid(*this, OLETEXT("OpenFile"), DISPID(6));
  TAutoArgs<1> _args;
  _args[1] = FileName /*[VT_BSTR:0]*/;
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
// CoClass  : MyAuto3
// Interface: TCOMIMyAuto3
// *********************************************************************//
typedef TCoClassCreatorT<TCOMIMyAuto3, IMyAuto3, &CLSID_MyAuto3, &IID_IMyAuto3> CoMyAuto3;
#endif  //   __TLB_NO_INTERFACE_WRAPPERS


};     // namespace Prser_tlb

#if !defined(NO_IMPLICIT_NAMESPACE_USE)
using  namespace Prser_tlb;
#endif

#pragma option pop

#endif // Prser_TLBH
