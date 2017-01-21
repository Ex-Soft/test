//---------------------------------------------------------------------------

#include "TCPInfo.h"
#include <new>
//---------------------------------------------------------------------------

__fastcall TConnectionInfo::TConnectionInfo(void)
{
   Initialize();

   while(!Buff&&BuffSize)
     {
        Buff=new char [BuffSize];
        if(!Buff)
          BuffSize>>=1;
     }
   if(!Buff&&!BuffSize)
     throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::TConnectionInfo() Insufficient memory");
}
//---------------------------------------------------------------------------

__fastcall TConnectionInfo::TConnectionInfo(const TConnectionInfo &aConnectionInfo)
{
   Initialize();
   CopyData(aConnectionInfo);
}
//---------------------------------------------------------------------------

__fastcall TConnectionInfo::~TConnectionInfo(void)
{
   if(Buff)
     {
        delete []Buff;
        Buff=0;
     }
}
//---------------------------------------------------------------------------

void __fastcall TConnectionInfo::Initialize()
{
   State=0;
   BuffSize=0x0ffff;
   Count=0;
   Buff=0;
}
//---------------------------------------------------------------------------

void __fastcall TConnectionInfo::CopyData(const TConnectionInfo &aConnectionInfo)
{
   if(Buff)
     {
        delete []Buff;
        Buff=0;
     }

   State=aConnectionInfo.State;
   BuffSize=aConnectionInfo.BuffSize;
   Count=aConnectionInfo.Count;
   try
     {
        Buff=new char [BuffSize];
     }
   catch(std::bad_alloc)
     {
        throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::CopyData() Insufficient memory");
     }
   memcpy(Buff,aConnectionInfo.Buff,BuffSize);
}
//---------------------------------------------------------------------------

