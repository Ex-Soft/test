#include "BaseObject.h"

BaseObject::BaseObject(int height, int width) : _height(height), _width(width)
{
  _log = new Log();
  _log->Write("BaseObject::BaseObject(int height, int width)");
}

BaseObject::BaseObject(const BaseObject &obj) : _height(obj.height()), _width(obj.width())
{
  _log = new Log();
  _log->Write("BaseObject::BaseObject(const BaseObject &obj)");
}

BaseObject::~BaseObject(void)
{
  if(_log)
    delete _log;
}

inline int BaseObject::height(void) const
{
  return _height;
}

inline int BaseObject::width(void) const
{
  return _width;
}

void BaseObject::ping(void) const
{
  pong();
}

std::string BaseObject::pong(void) const
{
  return "pong";
}