/*
 * Copyright 1999 Inprise Corporation, Inc.
 *
 * GENERATED CODE --- DO NOT EDIT
 * 
 */

#ifndef __PostServ_idl___server
#define __PostServ_idl___server
#include "vpre.h"

#include "PostServ_c.hh"

class  POA_PostModule {
  public:


  class  Post : public PostModule::Post_ops ,public virtual PortableServer_ServantBase {
   protected:
    Post() {}

    virtual ~Post() {}

   public:
    static const CORBA::TypeInfo _skel_info;
    virtual const CORBA::TypeInfo *_type_info() const;

    PostModule::Post_ptr _this();


    virtual void *_safe_narrow(const CORBA::TypeInfo& ) const;

    static Post * _narrow(PortableServer_ServantBase *_obj);

    // The following operations need to be implemented
    virtual CORBA::Long GetText(const char* _text, const char* _name) = 0;


    // Skeleton Operations implemented automatically
    virtual void* _safe_downcast_ops(const VISOps_Info& _info) {
      if (_info == *PostModule::Post_ops::_desc())
        return (void*)(PostModule::Post_ops*)this;
      return (void*)NULL;
       }

    static void _GetText(void *_obj, CORBA::MarshalInBuffer &_istrm,
                         const char *_oper, VISReplyHandler& handler);

  };

};

template <class T> class POA_PostModule_Post_tie : public POA_PostModule::Post {
  private:
   CORBA::Boolean _rel;
   PortableServer::POA_ptr _poa;
   T *_ptr;
   POA_PostModule_Post_tie(const POA_PostModule_Post_tie&) {}
   void operator=(const POA_PostModule_Post_tie&) {}

  public:
   POA_PostModule_Post_tie (T& t): _ptr(&t), _poa(NULL), _rel((CORBA::Boolean)0) {}

 POA_PostModule_Post_tie (T& t, PortableServer::POA_ptr poa): _ptr(&t), 
   _poa(PortableServer_POA::_duplicate(poa)), _rel((CORBA::Boolean)0) {}

 POA_PostModule_Post_tie (T *p, CORBA::Boolean release= 1) : _ptr(p), _poa(NULL), _rel(release) {}

 POA_PostModule_Post_tie (T *p, PortableServer::POA_ptr poa, CORBA::Boolean release =1)
   : _ptr(p), _poa(PortableServer_POA::_duplicate(poa)), _rel(release) {}

 virtual ~POA_PostModule_Post_tie() {
   CORBA::release(_poa);
     if (_rel) {
     delete _ptr;
       }
     }

 T* _tied_object() { return _ptr; }
   void _tied_object(T& t) {
   if (_rel) {
     delete _ptr;
       }
     _ptr = &t;
     _rel = 0;
     }
   void _tied_object(T *p, CORBA::Boolean release=1) {
      if (_rel) { 
        delete _ptr;
      }
      _ptr = p;
      _rel = release;
       }

 CORBA::Boolean _is_owner() { return _rel; }
   void _is_owner(CORBA::Boolean b) { _rel = b; }

  CORBA::Long GetText(const char* _text, const char* _name) {
  return _ptr->GetText(_text, _name);
  }
  PortableServer::POA_ptr _default_POA() {
    if ( !CORBA::is_nil(_poa) ) {
      return _poa;
    } else {
      return PortableServer_ServantBase::_default_POA();
    }
  }

};

class  _sk_PostModule {
public:
class  _sk_Post : public POA_PostModule::Post,
                  public PortableServer_RefCountServantBase,
                  public PostModule::Post {
 protected:
  _sk_Post (const char *_obj_name = (const char*)NULL) {
    PortableServer_ServantBase::_object_name(_obj_name);
  }
  _sk_Post (const char *_service_name, const CORBA::ReferenceData& _data) {
    PortableServer_ServantBase::_service(_service_name, _data);
  }

 public:
  virtual ~_sk_Post() {}
  virtual PortableServer_ServantBase *_get_servant() {
    return this;
  }
  virtual CORBA::Object_ptr _backcompat_object() {
    return this;
  }
  PostModule::Post_ptr _this() {
    POA_PostModule::Post *_temp = this;
    return _temp->_this();
  }

  void _release() { _remove_ref(); }
  void _ref() { _add_ref(); }

  const char *_repository_id() const {
    return PortableServer_ServantBase::_repository_id();
  }
};
};
template <class T>
class PostModule_tie_Post : public POA_PostModule_Post_tie<T>, public virtual CORBA_Object {
 private:
PostModule_tie_Post (const PostModule_tie_Post&) : POA_PostModule_Post_tie<T>((T *)NULL, (CORBA::Boolean)0) {}
void operator=(const PostModule_tie_Post&) {}

 public:
PostModule_tie_Post(T& _t, const char *_obj_name = (char *) NULL, CORBA::Boolean _r_f = 0) 
    : POA_PostModule_Post_tie<T>(&_t, _r_f) {
  PortableServer_ServantBase::_object_name(_obj_name);
}

PostModule_tie_Post(T& _t, const char *_serv_name, const CORBA::ReferenceData& _id, CORBA::Boolean _r_f = 0)
    : POA_PostModule_Post_tie<T>(&_t, _r_f) {
  PortableServer_ServantBase::_service(_serv_name, _id);
}

CORBA::Boolean rel_flag() { 
  return _is_owner(); 
}

void rel_flag(CORBA::Boolean flag) { 
  _is_owner(flag); 
}

virtual ~PostModule_tie_Post() {}

virtual PortableServer_ServantBase *_get_servant() {
  return this;
}

const char *repository_id() const {
  return PortableServer_ServantBase::_repository_id();
}
};

#include "vpost.h"
#endif  // __PostServ_idl___server
