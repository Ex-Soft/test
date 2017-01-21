//---------------------------------------------------------------------------

#include "CommData.h"
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
// TCommCert
//---------------------------------------------------------------------------
TCommCert::TCommCert(int aContrNo, int aCertNo)
{
   BuffSize=0x0ffff;
   Buff=0;

   while(!Buff&&BuffSize)
     {
        Buff=new char [BuffSize];
        if(!Buff)
          BuffSize>>=1;
     }
   if(!Buff&&!BuffSize)
     throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::TCommCert() Insufficient memory");

   setmem(Buff,BuffSize,0);
   ContrNo=aContrNo;
   CertNo=aCertNo;
   Name="";
}
//---------------------------------------------------------------------------

TCommCert::TCommCert(const TCommCert &aCommCert)
{
   Buff=0;

   try
     {
        CopyData(aCommCert);
     }
   catch(Exception &eException)
     {
        throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::TCommCert() "+eException.Message);
     }
}
//---------------------------------------------------------------------------

TCommCert::~TCommCert(void)
{
   if(Buff)
     delete []Buff;
}
//---------------------------------------------------------------------------

void TCommCert::CopyData(const TCommCert &aCommCert)
{
   try
     {
        CopyDynamicData(aCommCert);
     }
   catch(Exception &eException)
     {
        throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::CopyData() "+eException.Message);
     }

   CopyStaticData(aCommCert);
}
//---------------------------------------------------------------------------

void TCommCert::CopyDynamicData(const TCommCert &aCommCert)
{
   char *tmpBuff=0;

   try
     {
        tmpBuff=new char [aCommCert.BuffSize];
     }
   catch(std::bad_alloc)
     {
        throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::CopyDynamicData() Insufficient memory");
     }

   if(Buff)
     delete []Buff;
   memcpy(Buff=tmpBuff,aCommCert.Buff,aCommCert.BuffSize);
}
//---------------------------------------------------------------------------

void TCommCert::CopyStaticData(const TCommCert &aCommCert)
{
   ContrNo=aCommCert.ContrNo;
   CertNo=aCommCert.CertNo;
   Name=aCommCert.Name;
   BuffSize=aCommCert.BuffSize;
}
//---------------------------------------------------------------------------

void TCommCert::Test(void)
{
   if(!Name.IsEmpty())
     Name+=" ";
   Name+="TCommCert::Test()";
}
//---------------------------------------------------------------------------

TCommCert & TCommCert::operator= (const TCommCert &aCommCert)
{
   if(this!=&aCommCert)
     {
        try
          {
             CopyData(aCommCert);
          }
        catch(Exception &eException)
          {
             throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::operator= () "+eException.Message);
          }
     }
   return(*this);
}
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
// TCommContr
//---------------------------------------------------------------------------
TCommContr::TCommContr(int aContrNo)
{
   BuffSize=0x0ffff;
   Buff=0;

   while(!Buff&&BuffSize)
     {
        Buff=new char [BuffSize];
        if(!Buff)
          BuffSize>>=1;
     }
   if(!Buff&&!BuffSize)
     throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::TCommContr() Insufficient memory");

   setmem(Buff,BuffSize,0);
   ContrNo=aContrNo;
   Name="";
}
//---------------------------------------------------------------------------

TCommContr::TCommContr(const TCommContr &aCommContr)
{
   Buff=0;

   try
     {
        CopyData(aCommContr);
     }
   catch(Exception &eException)
     {
        throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::TCommContr() "+eException.Message);
     }
}
//---------------------------------------------------------------------------

TCommContr::~TCommContr(void)
{
   if(Buff)
     delete []Buff;
   ClearCert();
}
//---------------------------------------------------------------------------

void TCommContr::CopyData(const TCommContr &aCommContr)
{
   try
     {
        CopyDynamicData(aCommContr);
     }
   catch(Exception &eException)
     {
        throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::CopyData() "+eException.Message);
     }

   CopyStaticData(aCommContr);
}
//---------------------------------------------------------------------------

void TCommContr::CopyDynamicData(const TCommContr &aCommContr)
{
   char *tmpBuff=0;

   try
     {
        tmpBuff=new char [aCommContr.BuffSize];
     }
   catch(std::bad_alloc)
     {
        throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::CopyDynamicData() Insufficient memory");
     }
   if(Buff)
     delete []Buff;
   memcpy(Buff=tmpBuff,aCommContr.Buff,aCommContr.BuffSize);

   ClearCert();
   try
     {
        for(std::map<int, TCommCert *>::const_iterator i=aCommContr.Certifs.begin(); i!=aCommContr.Certifs.end(); i++)
           AddCert(*i->second);
        //   {
        //      AddCert(i->first);
        //      *Certifs[i->first]=*i->second;
        //      // *Certifs[i->first]=*aCommContr.Certifs[i->first]; ???
        //   }
     }
   catch(Exception &eException)
     {
        throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::CopyDynamicData() "+eException.Message);
     }
}
//---------------------------------------------------------------------------

void TCommContr::CopyStaticData(const TCommContr &aCommContr)
{
   ContrNo=aCommContr.ContrNo;
   Name=aCommContr.Name;
   BuffSize=aCommContr.BuffSize;
}
//---------------------------------------------------------------------------

void TCommContr::AddCert(int aCertNo)
{
   if(CertExists(aCertNo))
     throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::AddCert() CertNo "+IntToStr(aCertNo)+" already exists");

   try
     {
        TCommCert *tmp=0;

        tmp=new TCommCert(ContrNo,aCertNo);
        Certifs.insert(std::map<int, TCommCert *>::value_type(tmp->CertNo,tmp));
     }
   catch(std::bad_alloc)
     {
        throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::AddCert() Insufficient memory");
     }
   catch(Exception &eException)
     {
        throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::AddCert() "+eException.Message);
     }
}
//---------------------------------------------------------------------------

void TCommContr::AddCert(const TCommCert &aCommCert)
{
   if(CertExists(aCommCert.CertNo))
     throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::AddCert() CertNo "+IntToStr(aCommCert.CertNo)+" already exists");

   try
     {
        TCommCert *tmp=0;

        tmp=new TCommCert(aCommCert);
        Certifs.insert(std::map<int, TCommCert *>::value_type(tmp->CertNo,tmp));
     }
   catch(std::bad_alloc)
     {
        throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::AddCert() Insufficient memory");
     }
   catch(Exception &eException)
     {
        throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::AddCert() "+eException.Message);
     }
}
//---------------------------------------------------------------------------

void TCommContr::DelCert(int aCertNo)
{
   std::map<int, TCommCert *>::iterator i=Certifs.find(aCertNo);

   if(i==Certifs.end())
     throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::DelCert() CertNo "+IntToStr(aCertNo)+" doesn't exist");

   delete i->second;
   Certifs.erase(i);
}
//---------------------------------------------------------------------------

void TCommContr::ClearCert(void)
{
   for(std::map<int, TCommCert *>::iterator i=Certifs.begin(); i!=Certifs.end(); i++)
      delete i->second;
   Certifs.clear();
}
//---------------------------------------------------------------------------

bool TCommContr::CertExists(int aCertNo)
{
   return(Certifs.find(aCertNo)!=Certifs.end());
}
//---------------------------------------------------------------------------

TCommCert * TCommContr::Cert(int aCertNo)
{
   if(!CertExists(aCertNo))
     throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::Cert() CertNo "+IntToStr(aCertNo)+" doesn't exist");

   return Certifs[aCertNo];
}
//---------------------------------------------------------------------------

void TCommContr::Test(void)
{
   if(!Name.IsEmpty())
     Name+=" ";
   Name+="TCommContr::Test()";
}
//---------------------------------------------------------------------------

TCommContr & TCommContr::operator= (const TCommContr &aCommContr)
{
   if(this!=&aCommContr)
     {
        try
          {
             CopyData(aCommContr);
          }
        catch(Exception &eException)
          {
             throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::operator= () "+eException.Message);
          }
     }
   return(*this);
}
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
// TAppCert
//---------------------------------------------------------------------------
TAppCert::TAppCert(int aContrNo, int aCertNo, int aCertAddNo):TCommCert(aContrNo,aCertNo)
{
   BuffAddSize=0x0ffff;
   BuffAdd=0;

   while(!BuffAdd&&BuffAddSize)
     {
        BuffAdd=new char [BuffAddSize];
        if(!BuffAdd)
          BuffAddSize>>=1;
     }
   if(!BuffAdd&&!BuffAddSize)
     throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::TAppCert() Insufficient memory");

   CertAddNo=aCertAddNo;
}
//---------------------------------------------------------------------------

TAppCert::TAppCert(const TAppCert &aAppCert)
{
   BuffAdd=0;

   try
     {
        CopyData(aAppCert);
     }
   catch(Exception &eException)
     {
        throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::TAppCert() "+eException.Message);
     }
}
//---------------------------------------------------------------------------

TAppCert::~TAppCert(void)
{
   if(BuffAdd)
     delete []BuffAdd;
}
//---------------------------------------------------------------------------

void TAppCert::CopyData(const TAppCert &aAppCert)
{
   try
     {
        CopyDynamicData(aAppCert);
     }
   catch(Exception &eException)
     {
        throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::CopyData() "+eException.Message);
     }

   CopyStaticData(aAppCert);
}
//---------------------------------------------------------------------------

void TAppCert::CopyDynamicData(const TAppCert &aAppCert)
{
   char *tmpBuff=0;

   try
     {
        tmpBuff=new char [aAppCert.BuffSize];
        if(Buff)
          delete []Buff;
        memcpy(Buff=tmpBuff,aAppCert.Buff,aAppCert.BuffSize);

        tmpBuff=new char [aAppCert.BuffAddSize];
        if(BuffAdd)
          delete []BuffAdd;
        memcpy(BuffAdd=tmpBuff,aAppCert.BuffAdd,aAppCert.BuffAddSize);
     }
   catch(std::bad_alloc)
     {
        throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::CopyDynamicData() Insufficient memory");
     }
}
//---------------------------------------------------------------------------

void TAppCert::CopyStaticData(const TAppCert &aAppCert)
{
   TCommCert::CopyStaticData(aAppCert);

   CertAddNo=aAppCert.CertAddNo;
   BuffAddSize=aAppCert.BuffAddSize;
}
//---------------------------------------------------------------------------

void TAppCert::Test(void)
{
   if(!Name.IsEmpty())
     Name+=" ";
   Name+="TAppCert::Test()";
}
//---------------------------------------------------------------------------

TAppCert & TAppCert::operator= (const TAppCert &aAppCert)
{
   if(this!=&aAppCert)
     {
        try
          {
             CopyData(aAppCert);
          }
        catch(Exception &eException)
          {
             throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::operator= () "+eException.Message);
          }
     }
   return(*this);
}
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
// TAppContr
//---------------------------------------------------------------------------
TAppContr::TAppContr(int aContrNo, int aContrAddNo):TCommContr(aContrNo)
{
   BuffAddSize=0x0ffff;
   BuffAdd=0;

   while(!BuffAdd&&BuffAddSize)
     {
        BuffAdd=new char [BuffAddSize];
        if(!BuffAdd)
          BuffAddSize>>=1;
     }
   if(!BuffAdd&&!BuffAddSize)
     throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::TAppContr() Insufficient memory");

   ContrAddNo=aContrAddNo;
}
//---------------------------------------------------------------------------

TAppContr::TAppContr(const TAppContr &aAppContr)
{
   BuffAdd=0;

   try
     {
        CopyData(aAppContr);
     }
   catch(Exception &eException)
     {
        throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::TAppContr() "+eException.Message);
     }
}
//---------------------------------------------------------------------------

TAppContr::~TAppContr(void)
{
   if(BuffAdd)
     delete []BuffAdd;
}
//---------------------------------------------------------------------------

void TAppContr::CopyData(const TAppContr &aAppContr)
{
   try
     {
        CopyDynamicData(aAppContr);
     }
   catch(Exception &eException)
     {
        throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::CopyData() "+eException.Message);
     }

   CopyStaticData(aAppContr);
}
//---------------------------------------------------------------------------

void TAppContr::CopyDynamicData(const TAppContr &aAppContr)
{
   char *tmpBuff=0;

   try
     {
        tmpBuff=new char [aAppContr.BuffSize];
        if(Buff)
          delete []Buff;
        memcpy(Buff=tmpBuff,aAppContr.Buff,aAppContr.BuffSize);

        tmpBuff=new char [aAppContr.BuffAddSize];
        if(BuffAdd)
          delete []BuffAdd;
        memcpy(BuffAdd=tmpBuff,aAppContr.BuffAdd,aAppContr.BuffAddSize);
     }
   catch(std::bad_alloc)
     {
        throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::CopyDynamicData() Insufficient memory");
     }

   ClearCert();
   try
     {
        for(std::map<int, TCommCert *>::const_iterator i=aAppContr.Certifs.begin(); i!=aAppContr.Certifs.end(); i++)
           AddCert(*aAppContr.Cert(i->first));
     }
   catch(Exception &eException)
     {
        throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::CopyDynamicData() "+eException.Message);
     }
}
//---------------------------------------------------------------------------

void TAppContr::CopyStaticData(const TAppContr &aAppContr)
{
   TCommContr::CopyStaticData(aAppContr);

   ContrAddNo=aAppContr.ContrAddNo;
   BuffAddSize=aAppContr.BuffAddSize;
}
//---------------------------------------------------------------------------

void TAppContr::AddCert(int aCertNo)
{
   if(CertExists(aCertNo))
     throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::AddCert() CertNo "+IntToStr(aCertNo)+" already exists");

   try
     {
        TAppCert *tmp;

        tmp=new TAppCert(ContrNo,aCertNo);
        Certifs.insert(std::map<int, TCommCert *>::value_type(tmp->CertNo,tmp));
     }
   catch(std::bad_alloc)
     {
        throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::AddCert() Insufficient memory");
     }
   catch(Exception &eException)
     {
        throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::AddCert() "+eException.Message);
     }
}
//---------------------------------------------------------------------------

void TAppContr::AddCert(const TAppCert &aAppCert)
{
   if(CertExists(aAppCert.CertNo))
     throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::AddCert() CertNo "+IntToStr(aAppCert.CertNo)+" already exists");

   try
     {
        TAppCert *tmp;

        tmp=new TAppCert(aAppCert);
        Certifs.insert(std::map<int, TCommCert *>::value_type(tmp->CertNo,tmp));
     }
   catch(std::bad_alloc)
     {
        throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::AddCert() Insufficient memory");
     }
   catch(Exception &eException)
     {
        throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::AddCert() "+eException.Message);
     }
}
//---------------------------------------------------------------------------

TAppCert * TAppContr::Cert(int aCertNo)
{
   if(!CertExists(aCertNo))
     throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::Cert() CertNo "+IntToStr(aCertNo)+" doesn't exist");

   return dynamic_cast<TAppCert *>(Certifs[aCertNo]);
}
//---------------------------------------------------------------------------

void TAppContr::Test(void)
{
   if(!Name.IsEmpty())
     Name+=" ";
   Name+="TAppContr::Test()";
}
//---------------------------------------------------------------------------

TAppContr & TAppContr::operator= (const TAppContr &aAppContr)
{
   if(this!=&aAppContr)
     {
        try
          {
             CopyData(aAppContr);
          }
        catch(Exception &eException)
          {
             throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): "+ClassName()+"::operator= () "+eException.Message);
          }
     }
   return(*this);
}
//---------------------------------------------------------------------------
