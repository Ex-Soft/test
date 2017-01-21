/*
 * Copyright 1999 Inprise Corporation, Inc.
 *
 * GENERATED CODE --- DO NOT EDIT
 * 
 */

#include <corbapch.h>
#pragma hdrstop
#include "PostServ_c.hh"

PostModule::Post_ptr PostModule::Post_var::_duplicate(PostModule::Post_ptr _p) {
  return PostModule::Post::_duplicate(_p);
}

void
PostModule::Post_var::_release(PostModule::Post_ptr _p) {
  CORBA::release((CORBA::Object_ptr)_p);
}

PostModule::Post_var::Post_var()
  : _ptr(PostModule::Post::_nil()) {}

PostModule::Post_var::Post_var(PostModule::Post_ptr _p)
  : _ptr(_p) {}

PostModule::Post_var::Post_var(const PostModule::Post_var& _var)
  : _ptr(PostModule::Post::_duplicate((PostModule::Post_ptr) _var)) {}

PostModule::Post_var::~Post_var() {
  CORBA::release((CORBA::Object_ptr)_ptr);
}

PostModule::Post_var&
PostModule::Post_var::operator=(PostModule::Post_ptr _p) {
  CORBA::release((CORBA::Object_ptr)_ptr);
  _ptr = _p;
  return *this;
}

PostModule::Post_ptr& PostModule::Post_var::out() {
  _release(_ptr);
  _ptr = (PostModule::Post_ptr)NULL;
  return _ptr;
}

PostModule::Post_ptr PostModule::Post_var::_retn() {
  PostModule::Post_ptr _tmp_ptr = _ptr;
  _ptr = (PostModule::Post_ptr)NULL;
  return _tmp_ptr;
}

VISistream& operator>>(VISistream& _strm, PostModule::Post_var& _var) {
  _strm >> _var._ptr;
  return _strm;
}

VISostream& operator<<(VISostream& _strm, const PostModule::Post_var& _var) {
  _strm << _var._ptr;
  return _strm;
}

Istream& operator>>(Istream& _strm, PostModule::Post_var& _var) {
  VISistream _istrm(_strm);
  _istrm >> _var._ptr;
  return _strm;
}

Ostream& operator<<(Ostream& _strm, const PostModule::Post_var& _var) {
  _strm << (CORBA::Object_ptr)_var._ptr;
  return _strm;
}


VISistream& operator>>(VISistream& _strm,
                       PostModule::Post::CapacityExceeded& _e) {
  CORBA::String_var _exp_name;
  _strm >> _exp_name;
  _e._copy(_strm);
  return _strm;
}

const CORBA_Exception::Description PostModule::Post::CapacityExceeded::_description(
        "::PostModule::Post::CapacityExceeded",
"IDL:PostModule/Post/CapacityExceeded:1.0",
PostModule::Post::CapacityExceeded::_factory,
&CORBA::UserException::_description);

#if defined(MSVCNEWDLL_BUG)
void *PostModule::Post::CapacityExceeded::operator new(size_t ts) {
  return ::operator new(ts);
}
void PostModule::Post::CapacityExceeded::operator delete(void *p) {
  ::operator delete(p);
}
#endif // MSVCNEWDLL_BUG

const CORBA_Exception::Description& PostModule::Post::CapacityExceeded::_desc() const {
return _description;
}

PostModule::Post::CapacityExceeded* PostModule::Post::CapacityExceeded::_downcast(CORBA::Exception *_exc) {
  if (_exc && _exc->_desc().can_cast(_description)) {
    return (PostModule::Post::CapacityExceeded *)_exc;
  } else {
    return (PostModule::Post::CapacityExceeded *)NULL;
  }
}

const PostModule::Post::CapacityExceeded* PostModule::Post::CapacityExceeded::_downcast(const CORBA::Exception *_exc) {
  return _downcast((CORBA::Exception *)_exc);
}

void PostModule::Post::CapacityExceeded::_write(VISostream& _strm) const {
     _strm << max;

}

void PostModule::Post::CapacityExceeded::_copy(VISistream& _strm) {
     _strm >> max;

}
void _pretty_print(VISostream& _strm,
                   const PostModule::Post::CapacityExceeded& _s) {
  _strm << "EXCEPTION PostModule::Post::CapacityExceeded {" << endl;
    _strm << "\tmax:" << endl;
  _strm << "\t" << _s.max << endl;

  _strm << "}" << endl;
}
// If dllimport is specified, you might probably want to
// disable these definitions
// disable the const definitions
const VISOps_Info PostModule::Post_ops::_ops_info("PostModule::Post_ops");
const CORBA::TypeInfo
PostModule::Post::_class_info("PostModule::Post", "IDL:PostModule/Post:1.0",
                              NULL, PostModule::Post::_factory, NULL, 0, NULL,
                              0, CORBA::Object::_desc(), 0);

const CORBA::TypeInfo *PostModule::Post::_desc() { return &_class_info; }
const CORBA::TypeInfo *PostModule::Post::_type_info() const {
  return &_class_info;
}

VISistream& operator>>(VISistream& _strm, PostModule::Post_ptr& _obj) {
  CORBA::Object_var _var_obj(_obj);
  _var_obj = CORBA::Object::_read(_strm, PostModule::Post::_desc());
  _obj = PostModule::Post::_narrow(_var_obj);
  return _strm;
}

VISostream& operator<<(VISostream& _strm, const PostModule::Post_ptr _obj) {
  _strm << (CORBA::Object_ptr)_obj;
  return _strm;
}
void* PostModule::Post::_safe_narrow(const CORBA::TypeInfo& _info) const {
  if (_info == _class_info)
    return (void *)this;
  return CORBA_Object::_safe_narrow(_info);
}

CORBA::Object *PostModule::Post::_factory() {
  return new PostModule::Post;
}

PostModule::Post_ptr PostModule::Post::_this() {
  return PostModule::Post::_duplicate(this);
}

PostModule::Post_ptr PostModule::Post::_narrow(CORBA::Object * _obj) {
  if (_obj == PostModule::Post::_nil())
    return PostModule::Post::_nil();
  else
    return PostModule::Post::_duplicate((PostModule::Post_ptr)_obj->_safe_narrow(_class_info));
}



Ostream& operator<<(Ostream& _strm, const PostModule::Post_ptr _obj) {
  _strm << (CORBA::Object_ptr) _obj;
  return _strm;
}
Istream& operator>>(Istream& _strm, PostModule::Post_ptr& _obj) {
  VISistream _istrm(_strm);
  _istrm >> _obj;
  return _strm;
}

PostModule::Post *PostModule::Post::_bind(const char *_object_name,
                                          const char *_host_name,
                                          const CORBA::BindOptions *_opt,
                                          CORBA::ORB_ptr _orb)
{
  VISCLEAR_EXCEP
  CORBA::Object_var _obj = CORBA::Object::_bind_to_object(
          "IDL:PostModule/Post:1.0", _object_name, _host_name, _opt, _orb);
  return Post::_narrow(_obj);
}

PostModule::Post *PostModule::Post::_bind(const char *_poa_name,
                                          const CORBA::OctetSequence& _id,
                                          const char *_host_name,
                                          const CORBA::BindOptions *_opt,
                                          CORBA::ORB_ptr _orb)
{
  VISCLEAR_EXCEP
  CORBA::Object_var _obj = CORBA::Object::_bind_to_object(
   "IDL:PostModule/Post:1.0", _poa_name, _id, _host_name, _opt, _orb);
  return Post::_narrow(_obj);
}
CORBA::Long PostModule::Post::GetText(const char* _arg_text ,
                                      const char* _arg_name ) {
  CORBA::Long _ret = (CORBA::Long) 0;
  CORBA_MarshalInBuffer_var _ibuf;

  while (1) {
    VISCLEAR_EXCEP 
			
    if (_is_local()) {
      PortableServer::ServantBase_ptr _servant;
      VISTRY {
        _servant = _preinvoke("GetText");
      }
      VISCATCH(VISRemarshal, _vis_except) { continue; } 
      VISEND_CATCH
		  
      PostModule::Post_ops*  _post = PostModule::Post_ops::_downcast(_servant);
      if (!_post) {
        if ((PortableServer::ServantBase*)_servant)
          _postinvoke(_servant, "GetText");
        VISTHROW(CORBA::BAD_OPERATION());
        VISRETURN(return _ret;)
      }

      VISTRY {
         _ret = _post->GetText(_arg_text , _arg_name );
      }
      VISCATCH_ALL{
        _postinvoke(_servant, "GetText"); 
        VISTHROW_LAST;
        VISRETURN(return _ret;)
      }
      VISEND_CATCH
      _postinvoke(_servant, "GetText");
      return _ret;
    }

    CORBA::MarshalOutBuffer_var _obuf;
    _obuf = _request("GetText", 1);
    VISIF_EXCEP(return _ret;)
    VISostream& _ostrm = *VISostream::_downcast(_obuf);
    _ostrm << _arg_text;
    _ostrm << _arg_name;

    VISTRY {
      _ibuf = _invoke(_obuf);
      VISIFNOT_EXCEP
      break;
      VISEND_IFNOT_EXCEP
    } VISCATCH(VISRemarshal, _vis_except) { continue; } 
    VISEND_CATCH
    VISRETURN(return _ret;)
  }

  VISistream& _istrm = *VISistream::_downcast(_ibuf);
  _istrm >> _ret;


  return _ret;
}




