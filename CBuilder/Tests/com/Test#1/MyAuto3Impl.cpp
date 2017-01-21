// MYAUTO3IMPL : Implementation of TMyAuto3Impl (CoClass: MyAuto3, Interface: IMyAuto3)

#include <vcl.h>
#pragma hdrstop

#include "MYAUTO3IMPL.H"

/////////////////////////////////////////////////////////////////////////////
// TMyAuto3Impl

STDMETHODIMP TMyAuto3Impl::AddLine(BSTR Line)
{ 

}

STDMETHODIMP TMyAuto3Impl::get_Visible(VARIANT_BOOL* Value)
{
  try
  {

  }
  catch(Exception &e)
  {
    return Error(e.Message.c_str(), IID_IMyAuto3);
  }
  return S_OK;
};


STDMETHODIMP TMyAuto3Impl::get_Width(int* Value)
{
  try
  {

  }
  catch(Exception &e)
  {
    return Error(e.Message.c_str(), IID_IMyAuto3);
  }
  return S_OK;
};


STDMETHODIMP TMyAuto3Impl::NewFile()
{
}

STDMETHODIMP TMyAuto3Impl::OpenFile(BSTR FileName)
{ 

}

STDMETHODIMP TMyAuto3Impl::SaveFile(BSTR FileName)
{ 

}

STDMETHODIMP TMyAuto3Impl::set_Visible(VARIANT_BOOL Value)
{
  try
  {

  }
  catch(Exception &e)
  {
    return Error(e.Message.c_str(), IID_IMyAuto3);
  }
  return S_OK;
};


STDMETHODIMP TMyAuto3Impl::set_Width(int Value)
{
  try
  {

  }
  catch(Exception &e)
  {
    return Error(e.Message.c_str(), IID_IMyAuto3);
  }
  return S_OK;
};


 