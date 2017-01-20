#include "BaseObjectWrap.h"

v8::Persistent<v8::Function> BaseObjectWrap::constructor;

BaseObjectWrap::BaseObjectWrap() {
  _baseObject = new BaseObject();
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
  NODE_SET_PROTOTYPE_METHOD(tpl, "sayHello", SayHello);

  constructor.Reset(isolate, tpl->GetFunction());
  exports->Set(v8::String::NewFromUtf8(isolate, "BaseObjectWrap"), tpl->GetFunction());
}

void BaseObjectWrap::New(const v8::FunctionCallbackInfo<v8::Value>& args) {
  v8::Isolate* isolate = args.GetIsolate();

  if (args.IsConstructCall()) {
    // Invoked as constructor: `new MyObject(...)`
    BaseObjectWrap* obj = new BaseObjectWrap();
    obj->Wrap(args.This());
    args.GetReturnValue().Set(args.This());
  } else {
    // Invoked as plain function `MyObject(...)`, turn into construct call.
    const int argc = 0;
    v8::Local<v8::Value> *argv = NULL;
    v8::Local<v8::Context> context = isolate->GetCurrentContext();
    v8::Local<v8::Function> cons = v8::Local<v8::Function>::New(isolate, constructor);
    v8::Local<v8::Object> result = cons->NewInstance(context, argc, argv).ToLocalChecked();
    args.GetReturnValue().Set(result);
  }
}

void BaseObjectWrap::SayHello(const v8::FunctionCallbackInfo<v8::Value>& args) {
  v8::Isolate* isolate = args.GetIsolate();
  BaseObjectWrap *w = ObjectWrap::Unwrap<BaseObjectWrap>(args.Holder());

  w->_baseObject->SayHello();

  args.GetReturnValue().Set(v8::Undefined(isolate));
}
