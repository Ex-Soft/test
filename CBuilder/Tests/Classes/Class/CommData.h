//---------------------------------------------------------------------------

#ifndef CommDataH
#define CommDataH
//---------------------------------------------------------------------------

#include <vcl.h>
#include <map>
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
// TCommCertif
//---------------------------------------------------------------------------
class TCommCert
{
   void CopyData(const TCommCert &aCommCert);
   void CopyDynamicData(const TCommCert &aCommCert);

public:
   int ContrNo;
   int CertNo;
   AnsiString Name;
   unsigned int BuffSize;
   char *Buff;

   TCommCert(int aContrNo=0, int aCertNo=0);
   TCommCert(const TCommCert &aCommCert);
   virtual ~TCommCert(void);

   virtual AnsiString ClassName(void) {return "TCommCert"; };

   void CopyStaticData(const TCommCert &aCommCert);

   virtual void Test(void);

   TCommCert & operator= (const TCommCert &aCommCert);
};
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
// TCommContr
//---------------------------------------------------------------------------
class TCommContr
{
   void CopyData(const TCommContr &aCommContr);
   void CopyDynamicData(const TCommContr &aCommContr);

public:
   int ContrNo;
   AnsiString Name;
   unsigned int BuffSize;
   char *Buff;
   std::map<int, TCommCert *> Certifs;

   TCommContr(int aContrNo=0);
   TCommContr(const TCommContr &aCommContr);
   virtual ~TCommContr(void);

   virtual AnsiString ClassName(void) {return "TCommContr"; };

   void CopyStaticData(const TCommContr &aCommContr);

   virtual void AddCert(int aCertNo);
   void AddCert(const TCommCert &aCommCert);
   void DelCert(int aCertNo);
   void ClearCert(void);
   bool CertExists(int aCertNo);

   TCommCert * Cert(int aCertNo);

   virtual void Test(void);

   TCommContr & operator= (const TCommContr &aCommContr);
};
//---------------------------------------------------------------------------

//---------------------------------------------------------------------------
// TAppCert
//---------------------------------------------------------------------------
class TAppCert:public TCommCert
{
   void CopyData(const TAppCert &aAppCert);
   void CopyDynamicData(const TAppCert &aAppCert);

public:
   int CertAddNo;
   unsigned int BuffAddSize;
   char *BuffAdd;

   TAppCert(int aContrNo=0, int aCertNo=0, int aCertAddNo=0);
   TAppCert(const TAppCert &aAppCert);
   virtual ~TAppCert(void);

   virtual AnsiString ClassName(void) {return "TAppCert"; };

   void CopyStaticData(const TAppCert &aAppCert);

   virtual void Test(void);

   TAppCert & operator= (const TAppCert &aAppCert);
};
//---------------------------------------------------------------------------

class TAppContr:public TCommContr
{
   void CopyData(const TAppContr &aAppContr);
   void CopyDynamicData(const TAppContr &aAppContr);

public:
   int ContrAddNo;
   unsigned int BuffAddSize;
   char *BuffAdd;

   TAppContr(int aContrNo=0, int aContrAddNo=0);
   TAppContr(const TAppContr &aAppContr);
   virtual ~TAppContr(void);

   virtual AnsiString ClassName(void) {return "TAppContr"; };

   void CopyStaticData(const TAppContr &aAppContr);

   void AddCert(int aCertNo);
   void AddCert(const TAppCert &aAppCert);

   TAppCert * Cert(int aCertNo);

   virtual void Test(void);

   TAppContr & operator= (const TAppContr &aAppContr);
};
//---------------------------------------------------------------------------

#endif
