//---------------------------------------------------------------------------

#include "Derived.h"
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
// TBase
//---------------------------------------------------------------------------
TBase::TBase(char aTBaseChar, int aTBaseInt, long aTBaseLong, char aChar, int aInt, long aLong)
{
   if(!Log.is_open())
     {
        AnsiString FileName=IntToHex((__int64)this,8)+".log";

        Log.open(FileName.c_str(),std::ios_base::out|std::ios_base::trunc);
        Log<<"Log was opened by "<<IntToHex((__int64)this,8).c_str()<<": TBase::TBase(char aTBaseChar, int aTBaseInt, long aTBaseLong, char aChar, int aInt, long aLong)"<<std::endl;
        Log.flush();
     }

   if(Log.is_open() && Log.good())
     {
        Log<<IntToHex((__int64)this,8).c_str()<<": TBase::TBase(char aTBaseChar, int aTBaseInt, long aTBaseLong, char aChar, int aInt, long aLong)"<<std::endl;
        Log<<"&Char="<<IntToHex((__int64)&Char,8).c_str()<<std::endl;
        Log<<"&Int="<<IntToHex((__int64)&Int,8).c_str()<<std::endl;
        Log<<"&Long="<<IntToHex((__int64)&Long,8).c_str()<<std::endl;
        Log.flush();
     }

   Initialize();

   TBaseChar=aTBaseChar;
   TBaseInt=aTBaseInt;
   TBaseLong=aTBaseLong;

   Char=aChar;
   Int=aInt;
   Long=aLong;
}
//---------------------------------------------------------------------------

TBase::TBase(const TBase &aBase)
{
   if(!Log.is_open())
     {
        AnsiString FileName=IntToHex((__int64)this,8)+".log";

        Log.open(FileName.c_str(),std::ios_base::out|std::ios_base::trunc);
        Log<<"Log was opened by "<<IntToHex((__int64)this,8).c_str()<<": TBase::TBase(const TBase &aBase)"<<std::endl;
        Log.flush();
     }

   if(Log.is_open() && Log.good())
     {
        Log<<IntToHex((__int64)this,8).c_str()<<": TBase::TBase(const TBase &aBase)"<<std::endl;
        Log<<"&Char="<<IntToHex((__int64)&Char,8).c_str()<<std::endl;
        Log<<"&Int="<<IntToHex((__int64)&Int,8).c_str()<<std::endl;
        Log<<"&Long="<<IntToHex((__int64)&Long,8).c_str()<<std::endl;
        Log.flush();
     }

   Initialize();
   CopyData(aBase);
}
//---------------------------------------------------------------------------

TBase::~TBase(void)
{
   if(Log.is_open() && Log.good())
     {
        Log<<IntToHex((__int64)this,8).c_str()<<": TBase::~TBase(void)"<<std::endl;
        Log.flush();
     }
   Clear();

   if(Log.is_open())
     Log.close();
}
//---------------------------------------------------------------------------

void TBase::Initialize(void)
{
   if(Log.is_open() && Log.good())
     {
        Log<<IntToHex((__int64)this,8).c_str()<<": void TBase::Initialize(void)"<<std::endl;
        Log.flush();
     }

   TBaseChar='\x0';
   TBaseInt=0;
   TBaseLong=0l;

   Char='\x0';
   Int=0;
   Long=0l;
}
//---------------------------------------------------------------------------

void TBase::CopyData(const TBase &aBase)
{
   if(Log.is_open() && Log.good())
     {
        Log<<IntToHex((__int64)this,8).c_str()<<": void TBase::CopyData(const TBase &aBase)"<<std::endl;
        Log.flush();
     }

   TBaseChar=aBase.TBaseChar;
   TBaseInt=aBase.TBaseInt;
   TBaseLong=aBase.TBaseLong;

   Char=aBase.Char;
   Int=aBase.Int;
   Long=aBase.Long;
}
//---------------------------------------------------------------------------

void TBase::Test(void)
{
   if(Log.is_open() && Log.good())
     {
        Log<<IntToHex((__int64)this,8).c_str()<<": void TBase::Test(void)"<<std::endl;
        Log.flush();
     }

   Long=0l;
}
//---------------------------------------------------------------------------

void TBase::TestTest(void)
{
   if(Log.is_open() && Log.good())
     {
        Log<<IntToHex((__int64)this,8).c_str()<<": void TBase::TestTest(void)"<<std::endl;
        Log.flush();
     }
   Test();
}
//---------------------------------------------------------------------------

void TBase::TestTestTest(void)
{
   if(Log.is_open() && Log.good())
     {
        Log<<IntToHex((__int64)this,8).c_str()<<": void TBase::TestTestTest(void)"<<std::endl;
        Log.flush();
     }
   TestTest();
}
//---------------------------------------------------------------------------

void TBase::Delete(void)
{
   if(Log.is_open() && Log.good())
     {
        Log<<IntToHex((__int64)this,8).c_str()<<": void TBase::Delete(void)"<<std::endl;
        Log.flush();
     }
}
//---------------------------------------------------------------------------

void TBase::Clear(void)
{
   if(Log.is_open() && Log.good())
     {
        Log<<IntToHex((__int64)this,8).c_str()<<": void TBase::Clear(void)"<<std::endl;
        Log.flush();
     }
   Delete();  
}
//---------------------------------------------------------------------------

TBase & TBase::operator= (const TBase &aBase)
{
   if(Log.is_open() && Log.good())
     {
        Log<<IntToHex((__int64)this,8).c_str()<<": TBase & TBase::operator= (const TBase &aBase)"<<std::endl;
        Log.flush();
     }

   if(this!=&aBase)
     CopyData(aBase);
   return(*this);
}
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
// TDerived1
//---------------------------------------------------------------------------
TDerived1::TDerived1(char aTDerived1Char, int aTDerived1Int, long aTDerived1Long, char aTBaseChar, int aTBaseInt, long aTBaseLong, char aChar, int aInt, long aLong):TBase(aTBaseChar,aTBaseInt,aTBaseLong,aChar,aInt,aLong)
{
   if(!Log.is_open())
     {
        AnsiString FileName=IntToHex((__int64)this,8)+".log";

        Log.open(FileName.c_str(),std::ios_base::out|std::ios_base::trunc);
        Log<<"Log was opened by "<<IntToHex((__int64)this,8).c_str()<<": TDerived1::TDerived1(char aTDerived1Char, int aTDerived1Int, long aTDerived1Long, char aTBaseChar, int aTBaseInt, long aTBaseLong, char aChar, int aInt, long aLong)"<<std::endl;
        Log.flush();
     }

   if(Log.is_open() && Log.good())
     {
        Log<<IntToHex((__int64)this,8).c_str()<<": TDerived1::TDerived1(char aTDerived1Char, int aTDerived1Int, long aTDerived1Long, char aTBaseChar, int aTBaseInt, long aTBaseLong, char aChar, int aInt, long aLong)"<<std::endl;
        Log<<"&Long="<<IntToHex((__int64)&Long,8).c_str()<<std::endl;
        Log.flush();
     }

   Initialize();

   TDerived1Char=aTDerived1Char;
   TDerived1Int=aTDerived1Int;
   TDerived1Long=aTDerived1Long;
}
//---------------------------------------------------------------------------

TDerived1::TDerived1(const TDerived1 &aDerived1):TBase(aDerived1)
{
   if(!Log.is_open())
     {
        AnsiString FileName=IntToHex((__int64)this,8)+".log";

        Log.open(FileName.c_str(),std::ios_base::out|std::ios_base::trunc);
        Log<<"Log was opened by "<<IntToHex((__int64)this,8).c_str()<<": TDerived1::TDerived1(const TDerived1 &aDerived1)"<<std::endl;
        Log.flush();
     }

   if(Log.is_open() && Log.good())
     {
        Log<<IntToHex((__int64)this,8).c_str()<<": TDerived1::TDerived1(const TDerived1 &aDerived1)"<<std::endl;
        Log<<"&Long="<<IntToHex((__int64)&Long,8).c_str()<<std::endl;
        Log.flush();
     }

   Initialize();
   CopyData(aDerived1);
}
//---------------------------------------------------------------------------

TDerived1::~TDerived1(void)
{
   if(Log.is_open() && Log.good())
     {
        Log<<IntToHex((__int64)this,8).c_str()<<": TDerived1::~TDerived1(void)"<<std::endl;
        Log.flush();
     }
   Clear();
}
//---------------------------------------------------------------------------

void TDerived1::Initialize(void)
{
   if(Log.is_open() && Log.good())
     {
        Log<<IntToHex((__int64)this,8).c_str()<<": void TDerived1::Initialize(void)"<<std::endl;
        Log.flush();
     }

   TDerived1Char='\x0';
   TDerived1Int=0l;
   TDerived1Long=0l;
}
//---------------------------------------------------------------------------

void TDerived1::CopyData(const TDerived1 &aDerived1)
{
   if(Log.is_open() && Log.good())
     {
        Log<<IntToHex((__int64)this,8).c_str()<<": void TDerived1::CopyData(const TDerived1 &aDerived1)"<<std::endl;
        Log.flush();
     }

   TDerived1Char=aDerived1.TDerived1Char;
   TDerived1Int=aDerived1.TDerived1Int;
   TDerived1Long=aDerived1.TDerived1Long;
}
//---------------------------------------------------------------------------

void TDerived1::Test(void)
{
   if(Log.is_open() && Log.good())
     {
        Log<<IntToHex((__int64)this,8).c_str()<<": void TDerived1::Test(void)"<<std::endl;
        Log.flush();
     }

   Long=1l;
}
//---------------------------------------------------------------------------

void TDerived1::TestTest(void)
{
   if(Log.is_open() && Log.good())
     {
        Log<<IntToHex((__int64)this,8).c_str()<<": void TDerived1::TestTest(void)"<<std::endl;
        Log.flush();
     }

   Test();
}
//---------------------------------------------------------------------------

void TDerived1::TestTestTest(void)
{
   if(Log.is_open() && Log.good())
     {
        Log<<IntToHex((__int64)this,8).c_str()<<": void TDerived1::TestTestTest(void)"<<std::endl;
        Log.flush();
     }

   TestTest();
}
//---------------------------------------------------------------------------

void TDerived1::TestTestTestTest(void)
{
   if(Log.is_open() && Log.good())
     {
        Log<<IntToHex((__int64)this,8).c_str()<<": void TDerived1::TestTestTestTest(void)"<<std::endl;
        Log.flush();
     }

   TestTestTest();
}
//---------------------------------------------------------------------------

void TDerived1::Delete(void)
{
   if(Log.is_open() && Log.good())
     {
        Log<<IntToHex((__int64)this,8).c_str()<<": void TDerived1::Delete(void)"<<std::endl;
        Log.flush();
     }
}
//---------------------------------------------------------------------------

TDerived1 & TDerived1::operator= (const TDerived1 &aDerived1)
{
   if(Log.is_open() && Log.good())
     {
        Log<<IntToHex((__int64)this,8).c_str()<<": TDerived1 & TDerived1::operator= (const TDerived1 &aDerived1)"<<std::endl;
        Log.flush();
     }

   if(this!=&aDerived1)
     {
        TBase::operator=(aDerived1);
        CopyData(aDerived1);
     }
   return(*this);
}
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
// TDerived2
//---------------------------------------------------------------------------
TDerived2::TDerived2(char aTDerived2Char, int aTDerived2Int, long aTDerived2Long, char aTDerived1Char, int aTDerived1Int, long aTDerived1Long, char aTBaseChar, int aTBaseInt, long aTBaseLong, char aChar, int aInt, long aLong):TDerived1(aTDerived1Char,aTDerived1Int,aTDerived1Long,aTBaseChar,aTBaseInt,aTBaseLong,aChar,aInt,aLong)
{
   if(!Log.is_open())
     {
        AnsiString FileName=IntToHex((__int64)this,8)+".log";

        Log.open(FileName.c_str(),std::ios_base::out|std::ios_base::trunc);
        Log<<"Log was opened by "<<IntToHex((__int64)this,8).c_str()<<": TDerived2::TDerived2(char aTDerived2Char, int aTDerived2Int, long aTDerived2Long, char aTDerived1Char, int aTDerived1Int, long aTDerived1Long, char aTBaseChar, int aTBaseInt, long aTBaseLong, char aChar, int aInt, long aLong)"<<std::endl;
        Log.flush();
     }

   if(Log.is_open() && Log.good())
     {
        Log<<IntToHex((__int64)this,8).c_str()<<": TDerived2::TDerived2(char aTDerived2Char, int aTDerived2Int, long aTDerived2Long, char aTDerived1Char, int aTDerived1Int, long aTDerived1Long, char aTBaseChar, int aTBaseInt, long aTBaseLong, char aChar, int aInt, long aLong)"<<std::endl;
        Log<<"&Long="<<IntToHex((__int64)&Long,8).c_str()<<std::endl;
        Log.flush();
     }

   Initialize();

   TDerived2Char=aTDerived2Char;
   TDerived2Int=aTDerived2Int;
   TDerived2Long=aTDerived2Long;
}
//---------------------------------------------------------------------------

TDerived2::TDerived2(const TDerived2 &aDerived2):TDerived1(aDerived2)
{
   if(!Log.is_open())
     {
        AnsiString FileName=IntToHex((__int64)this,8)+".log";

        Log.open(FileName.c_str(),std::ios_base::out|std::ios_base::trunc);
        Log<<"Log was opened by "<<IntToHex((__int64)this,8).c_str()<<": TDerived2::TDerived2(const TDerived2 &aDerived2)"<<std::endl;
        Log.flush();
     }

   if(Log.is_open() && Log.good())
     {
        Log<<IntToHex((__int64)this,8).c_str()<<": TDerived2::TDerived2(const TDerived2 &aDerived2)"<<std::endl;
        Log<<"&Long="<<IntToHex((__int64)&Long,8).c_str()<<std::endl;
        Log.flush();
     }

   Initialize();
   CopyData(aDerived2);
}
//---------------------------------------------------------------------------

TDerived2::~TDerived2(void)
{
   if(Log.is_open() && Log.good())
     {
        Log<<IntToHex((__int64)this,8).c_str()<<": TDerived2::~TDerived2(void)"<<std::endl;
        Log.flush();
     }
   Clear();  
}
//---------------------------------------------------------------------------

void TDerived2::Initialize(void)
{
   if(Log.is_open() && Log.good())
     {
        Log<<IntToHex((__int64)this,8).c_str()<<": void TDerived2::Initialize(void)"<<std::endl;
        Log.flush();
     }

   TDerived2Char='\x0';
   TDerived2Int=0;
   TDerived2Long=0l;
}
//---------------------------------------------------------------------------

void TDerived2::CopyData(const TDerived2 &aDerived2)
{
   if(Log.is_open() && Log.good())
     {
        Log<<IntToHex((__int64)this,8).c_str()<<": void TDerived2::CopyData(const TDerived2 &aDerived2)"<<std::endl;
        Log.flush();
     }

   TDerived2Char=aDerived2.TDerived2Char;
   TDerived2Int=aDerived2.TDerived2Int;
   TDerived2Long=aDerived2.TDerived2Long;
}
//---------------------------------------------------------------------------

void TDerived2::Test(void)
{
   if(Log.is_open() && Log.good())
     {
        Log<<IntToHex((__int64)this,8).c_str()<<": void TDerived2::Test(void)"<<std::endl;
        Log.flush();
     }

   Long=1l;
}
//---------------------------------------------------------------------------

void TDerived2::TestTest(void)
{
   if(Log.is_open() && Log.good())
     {
        Log<<IntToHex((__int64)this,8).c_str()<<": void TDerived2::TestTest(void)"<<std::endl;
        Log.flush();
     }

   Test();
}
//---------------------------------------------------------------------------

void TDerived2::TestTestTest(void)
{
   if(Log.is_open() && Log.good())
     {
        Log<<IntToHex((__int64)this,8).c_str()<<": void TDerived2::TestTestTest(void)"<<std::endl;
        Log.flush();
     }

   TestTest();
}
//---------------------------------------------------------------------------

void TDerived2::TestTestTestTest(void)
{
   if(Log.is_open() && Log.good())
     {
        Log<<IntToHex((__int64)this,8).c_str()<<": void TDerived2::TestTestTestTest(void)"<<std::endl;
        Log.flush();
     }

   TestTestTest();
}
//---------------------------------------------------------------------------

void TDerived2::Delete(void)
{
   if(Log.is_open() && Log.good())
     {
        Log<<IntToHex((__int64)this,8).c_str()<<": void TDerived2::Delete(void)"<<std::endl;
        Log.flush();
     }
}
//---------------------------------------------------------------------------

TDerived2 & TDerived2::operator= (const TDerived2 &aDerived2)
{
   if(Log.is_open() && Log.good())
     {
        Log<<IntToHex((__int64)this,8).c_str()<<": TDerived2 & TDerived2::operator= (const TDerived2 &aDerived2)"<<std::endl;
        Log.flush();
     }

   if(this!=&aDerived2)
     {
        TDerived1::operator=(aDerived2);
        CopyData(aDerived2);
     }
   return(*this);
}
//---------------------------------------------------------------------------
