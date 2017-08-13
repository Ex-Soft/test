#include <iostream>

#include "classwoperators.h"
#include "container.h"

using namespace std;

ClassWOperators F(void);

int main(int argc, char* argv[])
{
   ClassWOperators
     a(1,1),
     b(2,2),
     c,
     d;

   d=ClassWOperators(99,99);

   c=a+b;
   c=b-a;
   c=a*b;
   c=b/a;

   if(b!=c)
     b=c;

   int
      tmpInt=b;

   double
      tmpDouble=a;

   c=F();

   const int
     max = 10;

   Container
     container(max);

   container[3] = a;

   for(int i=0; i<max; ++i)
      cout<<"["<<i<<"]="<<container[i]<<endl;

   return 0;
}

ClassWOperators F(void)
{
   ClassWOperators
     a(33,33);

   return(a);
}

