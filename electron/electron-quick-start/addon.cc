// https://nodejs.org/api/addons.html
// addon.cc
#include <node.h>
#include "BaseObjectWrap.h"

namespace demo {

using v8::Local;
using v8::Object;

void InitAll(Local<Object> exports) {
  BaseObjectWrap::Init(exports);
}

NODE_MODULE(addon, InitAll)

}  // namespace demo
