/*
 * Copyright 1999 Inprise Corporation, Inc.
 *
 * GENERATED CODE --- DO NOT EDIT
 * 
 */

#include <corbapch.h>
#pragma hdrstop
#include "PostServ_s.hh"
static CORBA::MethodDescription _sk_PostModule_Post_methods[] = {
  {"GetText", POA_PostModule::Post::_GetText}
};


const CORBA::TypeInfo POA_PostModule::Post::_skel_info(
 "PostModule::Post", NULL, (CORBA::ULong) 1,
 _sk_PostModule_Post_methods         , NULL, 0, NULL);
         
const CORBA::TypeInfo *POA_PostModule::Post::_type_info() const {
  return &_skel_info;
}

PostModule::Post_ptr POA_PostModule::Post::_this() {
  return (PostModule::Post *)(PortableServer_ServantBase::_this()->_safe_narrow(*PostModule::Post::_desc()));
}


void *POA_PostModule::Post::_safe_narrow(const CORBA::TypeInfo& _info) const {
  if (_info == _skel_info) {
    return (void *)this;
  }


  if (_info == PortableServer_ServantBase::_skel_info) {
    return (void *)(PortableServer_ServantBase *)this;
  }
  return 0;
}

POA_PostModule::Post * POA_PostModule::Post::_narrow(PortableServer::ServantBase *_obj) {
  if (!_obj) {
    return (POA_PostModule::Post*)NULL;
  } else {
    return (Post*)_obj->_safe_narrow(_skel_info);
  }
}

void POA_PostModule::Post::_GetText (void *_obj,
                                     CORBA::MarshalInBuffer &_istrm,
                                     const char *_oper,
                                     VISReplyHandler& _handler) {
  VISCLEAR_EXCEP
  VISistream& _vistrm = _istrm;
  POA_PostModule::Post *_impl = (POA_PostModule::Post*)_obj;
  CORBA::String_var _local_text;
  CORBA::String_var _local_name;
    _vistrm >> _local_text;

    _vistrm >> _local_name;

  CORBA::MarshalOutBuffer_var _obuf = _handler.create_reply();
  VISostream& _ostrm = *VISostream::_downcast(_obuf);
CORBA::Long _ret = _impl->GetText( _local_text.in(),  _local_name.in());
  VISIF_EXCEP(return;)
  _ostrm << _ret;
}



