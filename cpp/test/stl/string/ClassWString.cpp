#include <iostream>
#include "ClassWString.h"

ClassWString::ClassWString(std::string _str1) : str1(_str1)
{
   std::cout << "ClassWString::ClassWString(std::string)" << std::endl;
}

ClassWString::ClassWString(const ClassWString &other) : str1(other.str1)
{
   std::cout << "ClassWString::ClassWString(const ClassWString&)" << std::endl;
}

ClassWString::ClassWString(const char *_str1) : ClassWString(std::string(_str1 ? _str1 : ""))
{
   std::cout << "ClassWString::ClassWString(const char *)" << std::endl;
}

ClassWString::~ClassWString(void)
{
   std::cout << "ClassWString::~ClassWString(void)" << std::endl;
}

void ClassWString::display(void)
{
    std::cout << "{str1:\"" << str1 << "\"}" << std::endl;
}
