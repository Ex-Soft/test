//---------------------------------------------------------------------------

#include <vcl.h>
#include <iostream>
#include <iomanip>
#include <conio.h>
#include <stdio.h>
#pragma hdrstop

//#define TEST_STRING_SELF_PTR
//#define TEST_NEW
//#define TEST_VINAIGRETTE
//#define TEST_CIN
//#define TEST_DECODE
//#define TEST_SORT
//---------------------------------------------------------------------------

#if defined(TEST_SORT)
void Sort(int W[], int n)
{
   int
     i,
     j,
     temp;

   for(i=n-1; i>0; i--)
      for(j=0; j<i; j++)
         if(W[j]>W[j+1])
         {
            temp=W[j];
            W[j]=W[j+1];
            W[j+1]=temp;
         }
}
#endif

#pragma argsused
int main(int argc, char* argv[])
{
     AnsiString
        tmpAnsiString = "0123456789",
        _a = "0",
        _b = "1",
        _ab = _a + _b,
        _aInt = _a + 1/*,
        _intA = 1 + _a*/;

     char
        char1 = tmpAnsiString[1],
        char2 = tmpAnsiString[2],
        charSum = char1 + char2;

     AnsiString
        tmpAnsiStringII = char1 + char2;

     char buff[50];

     sprintf(buff, "%hu", charSum);
/*
   char
//     Buff[]="123456789\n123456789";
     Buff[]="123456789";

   std::cout.write(Buff,strlen(Buff));
   std::cout.put('\n');
   std::cout.write(Buff,strlen(Buff));
   std::cout.flush();
*/
   int
     a=5;

   std::cout<<"abcdefgh"+a<<std::endl;

#if defined(TEST_NEW)
   unsigned long
     BuffSize=0x03fffffff;

   char
     *Buff=0;

   while(!Buff)
   {
      std::cout<<std::hex<<BuffSize;
      Buff=new char[BuffSize];
      if(Buff)
      {
         std::cout<<" Ok!"<<std::endl;
         delete []Buff;
         Buff=0;
         BuffSize<<=1;
         BuffSize|=1;
      }
      else
      {
         std::cout<<" !Buff"<<std::endl;
         break;
      }

      if(!BuffSize)
        break;
   }
#endif

#if defined(TEST_VINAIGRETTE)
   std::cout<<std::endl<<">";

   char
     _tmpChar_[1024];

   std::cin>>_tmpChar_;
   std::cout<<_tmpChar_<<std::endl;

   std::cout<<"std::cout (Line #0)"<<std::endl;
   printf("printf (Line #0)\n");
   std::cout<<"std::cout (Line #1)"<<std::endl;
   printf("printf (Line #1)\n");
   std::cout<<"std::cout (Line #2)"<<std::endl;
   printf("printf (Line #2)\n");
   std::cout<<"std::cout (Line #3)"<<std::endl;
   printf("printf (Line #3)\n");
   std::cout<<"std::cout (Line #4)"<<std::endl;
   printf("printf (Line #4)\n");
   getch();
#endif

#if defined(TEST_CIN)
   char
     tmpChar;

   std::cout<<std::endl<<">";
   std::cin.get(tmpChar);
   std::cout<<std::endl<<">";
   std::cin.get(tmpChar);
#endif

#if defined(TEST_SORT)
   int
     a=0,
     b,
     c,
     d,
     n,
     i,
     *A,
     *B,
     *C,
     *D,
     *E;

   bool
     InputOk;

   char
     InputValueStr[80];

   std::cout<<"¬ведите длину 1 массива( от 1 до 10)"<<std::endl;
   InputOk=false;
   while(!InputOk)
   {
      std::cin>>InputValueStr;
      try
      {
         a=StrToInt(InputValueStr);
         InputOk=true;
      }
      catch(EConvertError &eException)
      {
         std::cout<<"ќшибка!!! ѕовторите ввод!!!"<<std::endl;
      }
   }
   A=new int [a];
   std::cout<<"¬ведите его значени€!"<<std::endl;
   for(i=0;i<a;i++)
      std::cin>>A[i];

   std::cout<<"¬ведите длину 2 массива (от 1 до 10)"<<std::endl;
   std::cin>>b;
   B=new int [b];
   std::cout<<"¬ведите его значени€!"<<std::endl;
   for(i=0;i<b;i++)
      std::cin>>B[i];

   std::cout<<"¬ведите длину 3 массива (от 1 до 10)"<<std::endl;
   std::cin>>c;
   C=new int [c];
   std::cout<<"¬ведите его значени€!"<<std::endl;
   for(i=0;i<c;i++)
      std::cin>>C[i];

   std::cout<<"¬ведите длину 4 массива (от 1 до 10)"<<std::endl;
   std::cin>>d;
   D=new int [d];
   std::cout<<"¬ведите его значени€!"<<std::endl;
   for(i=0;i<d;i++)
      std::cin>>D[i];

   n=a+b+c+d;
   E=new int [n];

   for(i=0;i<a;i++)
      E[i]=A[i];
   for(i=0;i<b;i++)
      E[(a+i)]=B[i];
   for(i=0;i<c;i++)
      E[(a+b+i)]=C[i];
   for(i=0;i<d;i++)
      E[(a+b+c+i)]=D[i];

   std::cout<<"«начени€:";
   for(i=0;i<n;i++)
      std::cout<<E[i]<<" ";
   std::cout<<std::endl;

   Sort(E,n);

   for(i=0;i<n;i++)
      std::cout<<E[i]<<" ";
   std::cout<<std::endl;

   getch();
   delete[] A;
   delete[] B;
   delete[] C;
   delete[] D;
   delete[] E;
#endif

#if defined(TEST_DECODE)
   AnsiString
     Out;

   unsigned char
     letter='а',
     out[255];

   for(int l=0; l<32; l++)
      {
         Out="";
         for(unsigned char i=0; i<10; i++)
            Out+=char(letter+l+i);
         OemToChar(Out.c_str(),out);
         std::cout<<Out.c_str()<<"="<<out<<std::endl;
         CharToOem(Out.c_str(),out);
         std::cout<<Out.c_str()<<"="<<out<<std::endl;
      }
#endif

#if defined(TEST_STRING_SELF_PTR)
   char
     *msg;

   msg="";

   printf("%c\n",*"SelfPtr");
#endif

   return 0;
}
//---------------------------------------------------------------------------
