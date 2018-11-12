#include <iostream>
#include <string>
#include "ClassWString.h"

int main(int argc, char **argv)
{
  const char *char_ptr = nullptr;
  std::string string1;

  //string1 = std::string(char_ptr);  // terminate called after throwing an instance of 'std::logic_error'
                                      // what():  basic_string::_M_construct null not valid
                                      // Aborted (core dumped)
  //std::cout << "\"" << string1 << "\"" << std::endl;
  
  ClassWString c1(char_ptr);
  c1.display();
  std::cout << std::endl;

  char_ptr = "blah-blah-blah";
  ClassWString c2(char_ptr);
  c2.display();
  std::cout << std::endl;

  ClassWString c3(c1);
  c3.display();
  std::cout << std::endl;

  return 0;
}
