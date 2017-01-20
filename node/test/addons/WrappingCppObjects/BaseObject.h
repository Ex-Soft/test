#ifndef __BASEOBJECT_H__
#define __BASEOBJECT_H__

#include <string>
#include "Log.h"

class BaseObject
{
  int
    _height,
    _width;

  Log *_log;

 public:
  BaseObject(int height=0, int width=0);
  BaseObject(const BaseObject &obj);
  virtual ~BaseObject(void);

  int height(void) const;
  int width(void) const;

  void ping(void) const;
  std::string pong(void) const;
};

#endif
