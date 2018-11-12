#ifndef CLASS_W_STRING_H
#define CLASS_W_STRING_H

#include <string>

class ClassWString
{
  std::string str1;

public:
  ClassWString(std::string);
  ClassWString(const ClassWString&);
  ClassWString(const char * = nullptr);
  virtual ~ClassWString(void);

  void display(void);
};

#endif
