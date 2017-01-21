//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

//---------------------------------------------------------------------------

void f(void);

#pragma argsused
int main(int argc, char* argv[])
{
   try
     {
        f();
     }
   catch(Exception &eException)
     {
        ShowMessage(eException.Message);
     }

   return 0;
}
//---------------------------------------------------------------------------

void f(void)
{
   throw Exception("f"); 
}
//---------------------------------------------------------------------------
