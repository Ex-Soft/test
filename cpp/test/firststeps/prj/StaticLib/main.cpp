#include <stdio.h>

extern int f1(void);
extern int f2(void);

int main(void)
{
   int
      n1,
      n2;

   n1=f1();
   n2=f2();

   printf("f1() = %d\n",n1);
   printf("f2() = %d\n",n2);

   return 0;
}
