#include <iostream>

#include "BaseObject.h"

int BaseObject::MInt;

BaseObject::BaseObject(int height, int width) : _height(height), _width(width)
{
	std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl;
}

BaseObject::BaseObject(const BaseObject &obj) : _height(obj.height()), _width(obj.width())
{
	std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl;
}

BaseObject::~BaseObject(void)
{
	std::cout << "\"" << __FUNCSIG__ << "\"" << std::endl;
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

BaseObject & BaseObject::operator = (const BaseObject &obj)
{
	if (this != &obj)
	{
		_height = obj._height;
		_width = obj._width;
	}
	return(*this);
}

BaseObject::operator int() const
{
	return _height + _width;
}

std::ostream & operator << (std::ostream & os, const BaseObject &obj)
{
	os << "{ _height: " << obj._height << ", _width: " << obj._width << " }";

	return os;
}
