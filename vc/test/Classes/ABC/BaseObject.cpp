#include "stdafx.h"

BaseObject::BaseObject(int height, int width) : _height(height), _width(width)
{}

BaseObject::BaseObject(const BaseObject &obj) : _height(obj.height()), _width(obj.width())
{}

BaseObject::~BaseObject(void)
{}

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
