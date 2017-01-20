#include "BaseObjectWrap.h"

v8::Persistent<v8::Function> BaseObjectWrap::constructor;

BaseObjectWrap::BaseObjectWrap(int height, int width) {
  _baseObject = new BaseObject(height, width);
}

BaseObjectWrap::~BaseObjectWrap() {
  if (_baseObject)
    delete _baseObject;
}

void BaseObjectWrap::Init(v8::Local<v8::Object> exports) {
  v8::Isolate* isolate = exports->GetIsolate();

  // Prepare constructor template
  v8::Local<v8::FunctionTemplate> tpl = v8::FunctionTemplate::New(isolate, New);
  tpl->SetClassName(v8::String::NewFromUtf8(isolate, "BaseObjectWrap"));
  tpl->InstanceTemplate()->SetInternalFieldCount(1);

  // Prototype
  NODE_SET_PROTOTYPE_METHOD(tpl, "height", Height);
  NODE_SET_PROTOTYPE_METHOD(tpl, "width", Width);
  NODE_SET_PROTOTYPE_METHOD(tpl, "ping", Ping);
  NODE_SET_PROTOTYPE_METHOD(tpl, "pong", Pong);

  constructor.Reset(isolate, tpl->GetFunction());
  exports->Set(v8::String::NewFromUtf8(isolate, "BaseObjectWrap"), tpl->GetFunction());
}

void BaseObjectWrap::New(const v8::FunctionCallbackInfo<v8::Value>& args) {
  v8::Isolate* isolate = args.GetIsolate();

  if (args.IsConstructCall()) {
    // Invoked as constructor: `new MyObject(...)`
    int height = args[0]->IsUndefined() ? 0 : args[0]->Int32Value();
    int width = args[1]->IsUndefined() ? 0 : args[1]->Int32Value();
    BaseObjectWrap* obj = new BaseObjectWrap(height, width);
    obj->Wrap(args.This());
    args.GetReturnValue().Set(args.This());
  } else {
    // Invoked as plain function `MyObject(...)`, turn into construct call.
    const int argc = 2;
    v8::Local<v8::Value> argv[argc] = { args[0], args[1] };
    v8::Local<v8::Context> context = isolate->GetCurrentContext();
    v8::Local<v8::Function> cons = v8::Local<v8::Function>::New(isolate, constructor);
    v8::Local<v8::Object> result = cons->NewInstance(context, argc, argv).ToLocalChecked();
    args.GetReturnValue().Set(result);
  }
}

void BaseObjectWrap::Height(const v8::FunctionCallbackInfo<v8::Value>& args) {
  v8::Isolate* isolate = args.GetIsolate();
  BaseObjectWrap *w = ObjectWrap::Unwrap<BaseObjectWrap>(args.Holder());
  
  args.GetReturnValue().Set(v8::Integer::New(isolate, w->_baseObject->height()));
}

void BaseObjectWrap::Width(const v8::FunctionCallbackInfo<v8::Value>& args) {
  v8::Isolate* isolate = args.GetIsolate();
  BaseObjectWrap *w = ObjectWrap::Unwrap<BaseObjectWrap>(args.Holder());

  args.GetReturnValue().Set(v8::Integer::New(isolate, w->_baseObject->width()));
}

void BaseObjectWrap::Ping(const v8::FunctionCallbackInfo<v8::Value>& args) {
  v8::Isolate* isolate = args.GetIsolate();
  BaseObjectWrap *w = ObjectWrap::Unwrap<BaseObjectWrap>(args.Holder());
  v8::Local<v8::String> result = v8::String::NewFromUtf8(isolate, w->_baseObject->pong().c_str());

  const unsigned argc = 2;
  v8::Local<v8::Value> argv[argc] = { v8::String::NewFromUtf8(isolate, "ping"), result };

  node::MakeCallback(args.This(), "emit", 2, argv);

  args.GetReturnValue().Set(v8::Undefined(isolate));
}

void BaseObjectWrap::Pong(const v8::FunctionCallbackInfo<v8::Value>& args) {
  v8::Isolate* isolate = args.GetIsolate();
  BaseObjectWrap *w = ObjectWrap::Unwrap<BaseObjectWrap>(args.Holder());

  args.GetReturnValue().Set(v8::String::NewFromUtf8(isolate, w->_baseObject->pong().c_str()));
}
