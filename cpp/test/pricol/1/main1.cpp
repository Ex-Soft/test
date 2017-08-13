#include <stdio.h>
 
__attribute__ ((constructor))
static void fnc(void)
{
    printf("I can do it ;)\n");
}
 
int main(void)
{
    return 0;
}

