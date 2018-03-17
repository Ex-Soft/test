#ifndef __BASEOBJECT_H__
#define __BASEOBJECT_H__

#include <string>

class BaseObject
{
  int
    _height,
    _width;

 public:
  BaseObject(int height = 0, int width = 0);
  BaseObject(const BaseObject &obj);
  virtual ~BaseObject(void);

  int height(void) const;
  int width(void) const;

  void ping(void) const;
  std::string pong(void) const;

  BaseObject & operator = (const BaseObject &);
  operator int () const;

  friend std::ostream & operator << (std::ostream &, const BaseObject &);

  static int MInt;
};

#endif
