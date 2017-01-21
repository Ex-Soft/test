//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#define TEST_CYCLE

#include "main.h"
#include "Derived.h"
//#include "CommData.h"
//#include "Exeption.h"
//#include "Virtual.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormCreate(TObject *Sender)
{
   ForReallyAnyTestBitBtn->Height=ClientHeight;
   ForReallyAnyTestBitBtn->Width=ClientWidth;
   ForReallyAnyTestBitBtn->Caption=AnsiString("For\r\n")+"Really\r\n"+"Any\r\n"+"Test's\r\n"+"Button";
   long btnstyle=GetWindowLong(ForReallyAnyTestBitBtn->Handle,GWL_STYLE);
   btnstyle|=BS_MULTILINE;
   SetWindowLong(ForReallyAnyTestBitBtn->Handle,GWL_STYLE,btnstyle);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ForReallyAnyTestBitBtnClick(TObject *Sender)
{
#if defined(TEST_CYCLE)
   TBase
     tmpTBaseOuter;

   for(int i=0; i<10; ++i)
   {
      TBase
        tmpTBaseInner;//(i,i,i,i,i,i);


      tmpTBaseOuter=tmpTBaseInner;
   }
#endif

#if defined(CommDataH)
/*
   TCommCert CommCert1;
   CommCert1.ContrNo=1;
   CommCert1.CertNo=1;
   CommCert1.Name="CommCert1";
   strcpy(CommCert1.Buff,"CommCert1 Buff");

   TCommCert CommCert2(CommCert1);
   CommCert2.ContrNo=2;
   CommCert2.CertNo=2;
   CommCert2.Name="CommCert2";
   strcpy(CommCert2.Buff,"CommCert2 Buff");

   TCommCert CommCert3(3,3);
   CommCert3=CommCert2;
*/

/*
   TAppCert AppCert1;
   AppCert1.ContrNo=1;
   AppCert1.CertNo=1;
   AppCert1.Name="AppCert1";
   strcpy(AppCert1.Buff,"AppCert1 Buff");
   AppCert1.CertAddNo=1;
   strcpy(AppCert1.BuffAdd,"AppCert1 BuffAdd");

   TAppCert AppCert2(AppCert1);
   AppCert2.ContrNo=2;
   AppCert2.CertNo=2;
   AppCert2.Name="AppCert2";
   strcpy(AppCert2.Buff,"AppCert2 Buff");
   AppCert2.CertAddNo=2;
   strcpy(AppCert2.BuffAdd,"AppCert2 BuffAdd");

   TAppCert AppCert3(3,3,3);
   AppCert3=AppCert2;
*/

   TCommContr CommContr1;
   CommContr1.ContrNo=1;
   CommContr1.Name="CommContr1";
   strcpy(CommContr1.Buff,"CommContr1 Buff");
   CommContr1.AddCert(1);
   CommContr1.Certifs[1]->Name="CommContr1 CommCert1";
   strcpy(CommContr1.Certifs[1]->Buff,"CommContr1 CommCert1 Buff");
   CommContr1.AddCert(2);
   CommContr1.Certifs[2]->Name="CommContr1 CommCert2";
   strcpy(CommContr1.Certifs[2]->Buff,"CommContr1 CommCert2 Buff");

   TCommCert *ptrCommCert;
   for(std::map<int, TCommCert *>::iterator i=CommContr1.Certifs.begin(); i!=CommContr1.Certifs.end(); i++)
      {
         i->second->CertNo++;
         ptrCommCert=i->second;
         ptrCommCert->Test();
      }


/*   TAppContr Contr1(1,1);
   Contr1.Name="Contr1";
   strcpy(Contr1.Buff,"Contr1 Buff");
   Contr1.ContrAddNo=1;
   strcpy(Contr1.BuffAdd,"Contr1 BuffAdd");
   Contr1.AddCert(1);
   Contr1.Certifs[1]->Name="Contr1 Certif11";
   strcpy(Contr1.Certifs[1]->Buff,"Contr1 Certif11 Buff");
   Contr1.Cert(1)->CertAddNo=1;
   strcpy(Contr1.Cert(1)->BuffAdd,"Contr1 Certif11 BuffAdd");

   TAppCert AppCert12;
   AppCert12.ContrNo=1;
   AppCert12.CertNo=2;
   AppCert12.Name="AppCert12";
   strcpy(AppCert12.Buff,"AppCert12 Buff");
   AppCert12.CertAddNo=2;
   strcpy(AppCert12.BuffAdd,"AppCert12 BuffAdd");
   Contr1.AddCert(AppCert12);

   TAppCert AppCert13;
   AppCert13=AppCert12;
   AppCert13.CertNo=3;
   AppCert13.Name="AppCert13";
   strcpy(AppCert13.Buff,"AppCert13 Buff");
   AppCert13.CertAddNo=3;
   strcpy(AppCert13.BuffAdd,"AppCert13 BuffAdd");
   Contr1.AddCert(AppCert13);

   TAppCert *ptrCert;
   for(std::map<int, TCommCert *>::iterator i=Contr1.Certifs.begin(); i!=Contr1.Certifs.end(); i++)
      {
         if(ptrCert=dynamic_cast<TAppCert *>(i->second))
           AppCert13=*ptrCert;
         AppCert13.Test();
      }

   TAppContr Contr2(Contr1);
   for(std::map<int, TCommCert *>::iterator i=Contr2.Certifs.begin(); i!=Contr2.Certifs.end(); i++)
      {
         if(ptrCert=dynamic_cast<TAppCert *>(i->second))
           AppCert13=*ptrCert;
         AppCert13.Test();
      }

   TAppContr Contr3;
   Contr3=Contr2;
   for(std::map<int, TCommCert *>::iterator i=Contr3.Certifs.begin(); i!=Contr3.Certifs.end(); i++)
      {
         if(ptrCert=dynamic_cast<TAppCert *>(i->second))
           AppCert13=*ptrCert;
         AppCert13.Test();
      }
*/
#endif

#if defined(DerivedH)
   TBase b1;
   b1.Log<<"b1"<<std::endl;
   b1.Log.flush();

   b1.TBaseChar='\x1';
   b1.TBaseInt=1;
   b1.TBaseLong=1l;
   b1.Char='\x1';
   b1.Int=1;
   b1.Long=1l;
   b1.Clear();

   TBase b2(b1);
   b2.Log<<"b2"<<std::endl;
   b2.Log.flush();

   b2.TBaseChar='\x2';
   b2.TBaseInt=2;
   b2.TBaseLong=2l;
   b2.Char='\x2';
   b2.Int=2;
   b2.Long=2l;

   TBase b3=b2;
   b3.Log<<"b3"<<std::endl;
   b3.Log.flush();

   b3.TBaseChar='\x3';
   b3.TBaseInt=3;
   b3.TBaseLong=3l;
   b3.Char='\x3';
   b3.Int=3;
   b3.Long=3l;

   TBase b4;
   b4.Log<<"b4"<<std::endl;
   b4.Log.flush();

   b4=b3;

   TDerived1 d11;
   d11.Log<<"d11"<<std::endl;
   d11.Log.flush();

   d11.TDerived1Char='\x11';
   d11.TDerived1Int=11;
   d11.TDerived1Long=11l;
   d11.TBaseChar='\x11';
   d11.TBaseInt=11;
   d11.TBaseLong=11l;
   d11.Char='\x11';
   d11.Int=11;
   d11.Long=11l;
   d11.Clear();
   
   TDerived1 d12(d11);
   d12.Log<<"d12"<<std::endl;
   d12.Log.flush();

   d12.TDerived1Char='\x12';
   d12.TDerived1Int=12;
   d12.TDerived1Long=12l;
   d12.TBaseChar='\x12';
   d12.TBaseInt=12;
   d12.TBaseLong=12l;
   d12.Char='\x12';
   d12.Int=12;
   d12.Long=12l;

   TDerived1 d13=d12;
   d13.Log<<"d13"<<std::endl;
   d13.Log.flush();

   d13.TDerived1Char='\x13';
   d13.TDerived1Int=13;
   d13.TDerived1Long=13l;
   d13.TBaseChar='\x13';
   d13.TBaseInt=13;
   d13.TBaseLong=13l;
   d13.Char='\x13';
   d13.Int=13;
   d13.Long=13l;

   TDerived1 d14;
   d14.Log<<"d14"<<std::endl;
   d14.Log.flush();

   d14=d13;

   TDerived2 d21(100,100,100,110,110,110,120,120,120,130,130,130);
   d21.Log<<"d21"<<std::endl;
   d21.Log.flush();

   d21.TDerived2Char='\x21';
   d21.TDerived2Int=21;
   d21.TDerived2Long=21l;
   d21.TDerived1Char='\x21';
   d21.TDerived1Int=21;
   d21.TDerived1Long=21l;
   d21.TBaseChar='\x21';
   d21.TBaseInt=21;
   d21.TBaseLong=21l;
   d21.Char='\x21';
   d21.Int=21;
   d21.Long=21l;
   d21.Clear();
   
   TDerived2 d22(d21);
   d22.Log<<"d22"<<std::endl;
   d22.Log.flush();

   d22.TDerived2Char='\x22';
   d22.TDerived2Int=22;
   d22.TDerived2Long=22l;
   d22.TDerived1Char='\x22';
   d22.TDerived1Int=22;
   d22.TDerived1Long=22l;
   d22.TBaseChar='\x22';
   d22.TBaseInt=22;
   d22.TBaseLong=22l;
   d22.Char='\x22';
   d22.Int=22;
   d22.Long=22l;

   TDerived2 d23=d22;
   d23.Log<<"d23"<<std::endl;
   d23.Log.flush();

   d23.TDerived2Char='\x23';
   d23.TDerived2Int=23;
   d23.TDerived2Long=23l;
   d23.TDerived1Char='\x23';
   d23.TDerived1Int=23;
   d23.TDerived1Long=23l;
   d23.TBaseChar='\x23';
   d23.TBaseInt=23;
   d23.TBaseLong=23l;
   d23.Char='\x23';
   d23.Int=23;
   d23.Long=23l;

   TDerived2 d24;
   d24.Log<<"d24"<<std::endl;
   d24.Log.flush();

   d24=d23;

   b1.TestTest();
   d11.TestTest();
   d11.TestTestTest();
   d21.TestTest();
   d21.TestTestTest();

   TBase *ptrB;

   ptrB=dynamic_cast<TBase *>(&b1);
   ptrB->Test();
   ptrB->TestTest();
   ptrB->TestTestTest();

   TDerived1 *ptrD1;
   ptrD1=dynamic_cast<TDerived1 *>(&d11);
   ptrD1->Test();
   ptrD1->TestTest();
   ptrD1->TestTestTest();
   ptrD1->TestTestTestTest();
   ptrB=ptrD1;
   ptrB->Test();
   ptrB->TestTest();
   ptrB->TestTestTest();

   TDerived2 *ptrD2;
   ptrD2=dynamic_cast<TDerived2 *>(&d21);
   ptrD2->Test();
   ptrD2->TestTest();
   ptrD2->TestTestTest();
   ptrD2->TestTestTestTest();
   ptrD1=ptrD2;
   ptrD1->Test();
   ptrD1->TestTest();
   ptrD1->TestTestTest();
   ptrD1->TestTestTestTest();
   ptrB=ptrD2;
   ptrB->Test();
   ptrB->TestTest();
   ptrB->TestTestTest();
#endif

#if defined(ExeptionH)

   TExeption object;
   TExeption *ptr=0;

   try
     {
       ptr=new TExeption;
     }
   __finally
     {
       if(ptr)
         delete ptr;
     }
#endif

#if defined(VirtualH)

TBaseBase *BasePtr;
TDerivedDerivedDerived *DerivedPtr=new TDerivedDerivedDerived;
DerivedPtr->f1();
BasePtr=DerivedPtr;
BasePtr->f1();
delete DerivedPtr;

#endif
}
//---------------------------------------------------------------------------

