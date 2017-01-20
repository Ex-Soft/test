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
    explicit BaseObjectWrap(int height=0, int width=0);
    ~BaseObjectWrap(void);

  static void New(const v8::FunctionCallbackInfo<v8::Value>& args);
  static v8::Persistent<v8::Function> constructor;

  static void Height(const v8::FunctionCallbackInfo<v8::Value>& args);
  static void Width(const v8::FunctionCallbackInfo<v8::Value>& args);

  static void Ping(const v8::FunctionCallbackInfo<v8::Value>& args);
  static void Pong(const v8::FunctionCallbackInfo<v8::Value>& args);

  BaseObject *_baseObject;
};

#endif
