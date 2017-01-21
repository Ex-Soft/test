//---------------------------------------------------------------------------
#include <iostream>
#pragma hdrstop
//---------------------------------------------------------------------------
/*
asm
{
SmthProc proc far
         mov ax,0
         ret
SmthProc endp
}
*/
#pragma argsused
int main(int argc, char* argv[])
{
   asm
   {
SmthProc proc far
         mov ax,0
         ret
SmthProc endp

      call SmthProc
   }
   return 0;
}
//---------------------------------------------------------------------------
 