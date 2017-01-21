//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop
//---------------------------------------------------------------------------
#define TEST_ASSERT
//#define TEST_STRLEN
//#define TEST_MACRO
//#define TEST_INITIALIZATION
//#define TEST_FIND_FIRST
//#define TEST_SSCANF
//#define TEST_

#if defined(TEST_INITIALIZATION) || defined(TEST_STRLEN)
   #include <iostream>

   using namespace std;
#endif

#if defined(TEST_ASSERT)
   #include <assert.h>
#endif

#if defined(TEST_STRLEN)
   #include <string.h>
#endif

#if defined(TEST_INITIALIZATION)
   #include "a.h"
   #include "container.h"
#endif

#if defined(TEST_SSCANF) || defined(TEST_FIND_FIRST) || defined(TEST_MACRO)
   #include <stdio.h>
#endif

#if defined(TEST_FIND_FIRST)
   #include <dir.h>
#endif

#if defined(TEST_INITIALIZATION)
int foo(int param)
{
   cout<<"foo("<<param<<")"<<endl;

   return param;
}
int fooL(int param)
{
   cout<<"fooL("<<param<<")"<<endl;

   return param;
}

int fooR(int param)
{
   cout<<"fooR("<<param<<")"<<endl;

   return param;
}
#endif

#if defined(TEST_MACRO)
   #define PRINT_TOKEN1(token) printf(#token "_size = %d", token ## _size)
   #define PRINT_TOKEN2(token) printf(#token " = %d", token)
#endif

#pragma argsused
int main(int argc, char* argv[])
{
   #if defined(TEST_ASSERT)
     char
       *buff = 0;

     //assert(buff); // fire

     buff = new char[10];

     assert(buff); // doesn't fire

     if(buff)
       delete []buff;
   #endif

   #if defined(TEST_STRLEN)
     const int
       max = 10;

     char
       *buff;

     if(buff=new char[max])
     {
        cout<<strlen(buff)<<endl;

        for(int i=0; i<max; ++i)
           cout<<"*(buff+"<<i<<")="<<(int)*(buff+i)<<endl;

        delete []buff;
     }
   #endif

   #if defined(TEST_MACRO)
     int
       i = 5,
       max_size = 10;

     PRINT_TOKEN1(max);
     printf("\n");
     PRINT_TOKEN2(i);
   #endif

   #if defined(TEST_INITIALIZATION)
     const int
       max = 10;

     int
       arr[max],
       idx;

     //arr[idx=3] = foo(idx); // foo(256) [3]=256
     //arr[fooL(idx=3)] = fooR(idx); // fooR(256) fooL(3) [3]=256
     //arr[idx] = foo(idx=3); // foo(3) [3]=3
     //arr[fooL(idx)] = fooR(idx=3); // fooR(3) fooL(3) [3]=3

     for(int i=0; i<max; ++i)
     	cout<<"["<<i<<"]="<<arr[i]<<endl;

     Container
       c(max);

     //c[idx=3] = foo(idx); // foo(1074153692) [3] = { 1074153692, 0}
     //c[fooL(idx=3)] = fooR(idx); // fooR(1074153692) fooL(3) [3] = { 1074153692, 0}
     //c[idx] = foo(idx=3); // foo(3) [3] = { 3, 0}
     c[fooL(idx)] = fooR(idx=3); // fooR(3) fooL(3) [3] = { 3, 0}
     cout<<c[3]<<endl;
   #endif

   #if defined(TEST_)
     const int
       Max=2;

     char
       **d;

     unsigned long
       a;

     d=new char* [Max];
     a=(unsigned long)d;

     d[0]=new char [Max];
     a=(unsigned long)d[0];
     d[1]=new char [Max];
     a=(unsigned long)d[1];

     *(d[0])=1;
     *(d[0]+1)=2;
     *(d[1])=3;
     *(d[1]+1)=4;

     int
       x;

     x=*(d[0]);
     x=*(d[0]+1);
     x=*(d[1]);
     x=*(d[1]+1);

     AnsiString
       tmpAnsiString;

     tmpAnsiString=*(d[0]);
     tmpAnsiString=*(d[0]+1);
     tmpAnsiString=*(d[1]);
     tmpAnsiString=*(d[1]+1);

     for(int i=0; i<Max; ++i)
        delete []d[i];

     delete []d;
   #endif

   #if defined(TEST_SSCANF)
      char
        *c="0x059";

      int
        i;

      sscanf(c,"%x",&i);
   #endif

   #if defined(TEST_FIND_FIRST)
      ffblk
        ffblk;

      int
        done=findfirst("*.*",&ffblk,0 /* FA_DIREC */);

      while(!done)
      {
         printf("%s\n",ffblk.ff_name);
         done=findnext(&ffblk);
      }
   #endif

   return 0;
}
//---------------------------------------------------------------------------

