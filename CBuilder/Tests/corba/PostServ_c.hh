/*
 * Copyright 1999 Inprise Corporation, Inc.
 *
 * GENERATED CODE --- DO NOT EDIT
 * 
 */

#ifndef __PostServ_idl___client
#define __PostServ_idl___client
#include "vpre.h"

#ifndef _corba_h_
# include "corba.h"
#endif   // _corba_h_


class  PostModule {
  public:
  #ifndef PostModule_Post_var_
  #define PostModule_Post_var_

  class  Post;

  typedef Post* Post_ptr;
  typedef Post_ptr PostRef;
  friend VISistream& operator>>(VISistream&, Post_ptr&);
  friend VISostream& operator<<(VISostream&, const Post_ptr);
  class  Post_out;

  class  Post_var : public CORBA::_var {
  friend class Post_out;
   private:
    Post_ptr _ptr;

   public:
    Post_var();
    Post_var(Post_ptr);
    Post_var(const Post_var &);
    virtual ~Post_var();

    static Post_ptr _duplicate(Post_ptr);
    static void _release(Post_ptr);

    Post_var& operator=(const Post_var& _var) {
      _release(_ptr);
      _ptr = _duplicate(_var._ptr);
      return *this;
    }
    Post_var& operator=(Post_ptr);

    operator Post*() const { return _ptr; }
    Post* operator->() const { return _ptr; }

    Post_ptr in() const { return _ptr; }
    Post_ptr& inout() { return _ptr; }
    Post_ptr& out();
    Post_ptr _retn();

    friend VISostream& operator<<(VISostream&, const Post_var&);
    friend VISistream& operator>>(VISistream&, Post_var&);

    friend Istream& operator>>(Istream&, Post_var&);
    friend Ostream& operator<<(Ostream&, const Post_var&);
  };
  class  Post_out {
   private:
    Post_ptr& _ptr;
    static Post* _nil() { return (Post*)NULL; }

    void operator=(const Post_out&);
    void operator=(const Post_var&);
     public:
    Post_out(const Post_out& _o) : _ptr(_o._ptr) {}
    Post_out(Post_ptr& _p) : _ptr(_p) {
      _ptr = _nil();
    }
    Post_out(Post_var& _v) : _ptr(_v._ptr) {
      _v = _nil();
    }
    Post_out& operator=(Post* _p) {
      _ptr = _p;
      return *this;
    }
    operator Post_ptr&() { return _ptr; }
    Post_ptr& ptr() { return _ptr; }
    Post* operator->() { return _ptr; }
  };

  #endif // PostModule_Post_var_


  // idl interface: PostModule::Post
  class  Post : public virtual CORBA_Object {
   private:
    static const CORBA::TypeInfo _class_info;
    void operator=(const Post&) {}

    protected:
    Post() {}
    Post(const Post&) {}

   public:
    virtual ~Post() {}
    class  CapacityExceeded : public CORBA_UserException {
     public:

      #if defined(MSVCNEWDLL_BUG)
        void *operator new(size_t ts);
        void *operator new(size_t ts, char*, int) {return operator new(ts);}
        void operator delete(void *p);
      #endif // MSVCNEWDLL_BUG

      CapacityExceeded() {}
      CapacityExceeded( CORBA::Long _max ) {
             max = _max;

      }
      virtual ~CapacityExceeded() {}

      CORBA::Long max;
      static CORBA::Exception *_factory() { return new CapacityExceeded(); }
      virtual const CORBA_Exception::Description& _desc() const;
      static CapacityExceeded* _downcast(CORBA::Exception *_exc);
      static const CapacityExceeded* _downcast(const CORBA::Exception *_exc);
      CORBA::Exception *_deep_copy() { return new CapacityExceeded(*this); }
      void _raise() const { VISTHROW_INST(this) }

      friend void _pretty_print(VISostream&, const CapacityExceeded&);
      void _write(VISostream&) const;
      void _copy(VISistream&);

      friend VISistream& operator>>(VISistream& _strm, CapacityExceeded& _e);
      static const CORBA_Exception::Description _description;
    };

    static  const CORBA::TypeInfo *_desc();
    virtual const CORBA::TypeInfo *_type_info() const;
    virtual void *_safe_narrow(const CORBA::TypeInfo& ) const;
    static CORBA::Object*_factory();
    Post_ptr _this();
    static Post_ptr _duplicate(Post_ptr _obj) {
      if (_obj) _obj->_ref();
      return _obj;
    }
    static Post_ptr _nil() { return (Post_ptr)NULL; }
    static Post_ptr _narrow(CORBA::Object* _obj);
    static Post_ptr _clone(Post_ptr _obj) {
      CORBA::Object_var _obj_var(CORBA_Object::_clone(_obj));
      #if defined(_HPCC_BUG)
        return _narrow(_obj_var.operator CORBA::Object_ptr());
      #else
        return _narrow(_obj_var);
      #endif  // _HPCC_BUG
    }
    static Post_ptr _bind(const char *_object_name = (const char*)NULL,
                          const char *_host_name = (const char*)NULL,
                          const CORBA::BindOptions* _opt = (CORBA::BindOptions*)NULL,
                          CORBA::ORB_ptr _orb = (CORBA::ORB_ptr)NULL);

    static Post_ptr _bind(const char *_poa_name,
                          const CORBA::OctetSequence& _id,
                          const char *_host_name = (const char*)NULL,
                          const CORBA::BindOptions* _opt = (CORBA::BindOptions*)NULL,
                          CORBA::ORB_ptr _orb = (CORBA::ORB_ptr)NULL);

    virtual CORBA::Long GetText(const char* _text, const char* _name);

    friend VISostream& operator<<(VISostream& _strm, const Post_ptr _obj);
    friend VISistream& operator>>(VISistream& _strm, Post_ptr& _obj);
    friend Ostream& operator<<(Ostream& _strm, const Post_ptr _obj);
    friend Istream& operator>>(Istream& _strm, Post_ptr& _obj);
    friend void _pretty_print(VISostream& _strm, const Post_ptr _obj) {
      _strm << _obj;
    }
  };


  class Post_ops;
  typedef Post_ops* Post_ops_ptr;

  class  Post_ops  {
   public:
    Post_ops() {}
    virtual ~Post_ops () {}

    virtual CORBA::Long GetText(const char* _text, const char* _name) = 0;

    static const VISOps_Info *_desc() { return &_ops_info; }
    static Post_ops_ptr _nil() { return (Post_ops_ptr)NULL; }
    static Post_ops_ptr _downcast(PortableServer::ServantBase* _servant) {
      if (_servant == (PortableServer::ServantBase*)NULL)
        return Post_ops::_nil();
      return (Post_ops_ptr)_servant->_safe_downcast_ops(_ops_info);
    }
  protected:
    static const VISOps_Info _ops_info;
  };

};

#include "vpost.h"
#endif // __PostServ_idl___client
