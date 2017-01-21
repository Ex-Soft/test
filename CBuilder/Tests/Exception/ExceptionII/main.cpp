//---------------------------------------------------------------------------

#include <vcl.h>
#include <iostream>
#pragma hdrstop
//---------------------------------------------------------------------------

using namespace std;

#pragma argsused
int main(int argc, char* argv[])
{
   //throw Exception("Exception");

   try
   {
      throw Exception("Exception");
   }
   __finally
   {
      cout<<"__finally"<<endl;
   }

   int
     a=0,
     b=0,
     c;

   try
   {
      try
      {
         c=a/b;
      }
      catch(EDivByZero &eException)
      {
         cout<<"EDivByZero: "<<eException.Message.c_str()<<endl;
      }
   }
   __finally
   {
      cout<<"__finally"<<endl;
   }

   try
   {
      try
      {
         try
         {
            c=a/b;
         }
         catch(EDivByZero &eException)
         {
            throw Exception("EDivByZero: "+eException.Message);
         }
      }
      catch(Exception &eException)
      {
         cout<<"Exception: "<<eException.Message.c_str()<<endl;
      }
   }
   __finally
   {
      cout<<"__finally"<<endl;
   }

   try
   {
      try
      {
         c=a/b;
      }
      catch(EDivByZero &eException)
      {
         throw Exception("EDivByZero: "+eException.Message);
      }
   }
   __finally
   {
      cout<<"__finally"<<endl;
   }

   return 0;
}
//---------------------------------------------------------------------------
 