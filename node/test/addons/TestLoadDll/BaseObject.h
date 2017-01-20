#ifndef __BASEOBJECT_H__
#define __BASEOBJECT_H__

#include <Windows.h>
#include "Log.h"

typedef void WINAPI tSayHelloFunc(void);

class BaseObject
{
  HINSTANCE dllInstance;
  tSayHelloFunc *ptrSayHelloFunc;

  Log *_log;

 public:
  BaseObject();
  BaseObject(const BaseObject &obj);
  virtual ~BaseObject(void);

  void SayHello(void);
};

#endif
