#ifndef __BASEOBJECTWRAP_H__
#define __BASEOBJECTWRAP_H__

#include <node.h>
#include <node_object_wrap.h>
#include "BaseObject.h"

class BaseObjectWrap : public node::ObjectWrap
{
  public:
    static void Init(v8::Local<v8::Object> exports);

  private:
    explicit BaseObjectWrap();
    ~BaseObjectWrap(void);

  static void New(const v8::FunctionCallbackInfo<v8::Value>& args);
  static v8::Persistent<v8::Function> constructor;

  static void Init(const v8::FunctionCallbackInfo<v8::Value>& args);
  static void SayHello(const v8::FunctionCallbackInfo<v8::Value>& args);
  static void GetNCLButtonDblClk(const v8::FunctionCallbackInfo<v8::Value>& args);
  static void GetNCRButtonDblClk(const v8::FunctionCallbackInfo<v8::Value>& args);
  static void GetRButtonDblClk(const v8::FunctionCallbackInfo<v8::Value>& args);
  static void GetLButtonDblClk(const v8::FunctionCallbackInfo<v8::Value>& args);

  BaseObject *_baseObject;
};

#endif
