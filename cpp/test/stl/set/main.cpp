#include <iostream>
#include <set>
#include "ClassWOperators.h"

int main(void)
{
   std::set<ClassWOperators>
     a;

   ClassWOperators
     c(0);

   a.insert(c);


   // a.insert(ClassWOperators(0));

   return 0;
}
