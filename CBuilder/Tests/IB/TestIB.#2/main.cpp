//---------------------------------------------------------------------------

#include <vcl.h>
#include <IBIntf.hpp>
//#include <IBProc32.hpp>
//#include <IBHeader.hpp>
#pragma hdrstop

#include "main.h"
#include "DataUnit.h"
//---------------------------------------------------------------------------

#pragma package(smart_init)
#pragma resource "*.dfm"

void __fastcall ShowResult(AnsiString &Message);

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FindContractButtonClick(TObject *Sender)
{
   TDateTime tmp=0;
   AnsiString Mess;

   DataBases->IBStoredProc->StoredProcName="findcontract";
   DataBases->IBStoredProc->ParamByName("USBNo")->AsInteger=999;
   DataBases->IBStoredProc->ParamByName("Branch")->AsInteger=1;
   DataBases->IBStoredProc->ParamByName("Pledged")->AsInteger=1;
   DataBases->IBStoredProc->ParamByName("ContrYear")->AsInteger=2;
   DataBases->IBStoredProc->ParamByName("ContrNo")->AsInteger=1;
   try
     {
        DataBases->IBStoredProc->Prepare();
        DataBases->IBStoredProc->ExecProc();
        tmp=DataBases->IBStoredProc->ParamByName("DateTimeModi")->AsDateTime;
     }
   catch(EIBError &eException)
     {
        Mess="Помилка роботи з БД "+DataBases->IBDatabaseName.LowerCase()+" на сервері "+DataBases->IBServerName.UpperCase()+"\nN помилки IB: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nЗміст помилки: "+eException.Message;
        Application->MessageBox(Mess.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
     }
   if(DataBases->IBTransaction->InTransaction)
     DataBases->IBTransaction->Rollback();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FindCertifButtonClick(TObject *Sender)
{
   TDateTime tmp=0;
   AnsiString Mess;

   DataBases->IBStoredProc->StoredProcName="findcertif";
   DataBases->IBStoredProc->ParamByName("USBNo")->AsInteger=999;
   DataBases->IBStoredProc->ParamByName("Branch")->AsInteger=1;
   DataBases->IBStoredProc->ParamByName("Pledged")->AsInteger=1;
   DataBases->IBStoredProc->ParamByName("ContrYear")->AsInteger=2;
   DataBases->IBStoredProc->ParamByName("ContrNo")->AsInteger=1;
   DataBases->IBStoredProc->ParamByName("OrdNo")->AsInteger=1;
   try
     {
        DataBases->IBStoredProc->Prepare();
        DataBases->IBStoredProc->ExecProc();
        tmp=DataBases->IBStoredProc->ParamByName("DateTimeModi")->AsDateTime;
     }
   catch(EIBError &eException)
     {
        Mess="Помилка роботи з БД "+DataBases->IBDatabaseName.LowerCase()+" на сервері "+DataBases->IBServerName.UpperCase()+"\nN помилки IB: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nЗміст помилки: "+eException.Message;
        Application->MessageBox(Mess.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
     }
   if(DataBases->IBTransaction->InTransaction)
     DataBases->IBTransaction->Rollback();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::AddUserButtonClick(TObject *Sender)
{
   if(UserName->Text.LowerCase()=="sysdba")
     return;

   if(IBAPICheckBox->Checked)
     {
        AddUserByIBAPI();
        return;
     }

   AnsiString
     Mess=ServerName->Text.Trim();

   DataBases->IBSecurityService->ServerName=Mess;
   DataBases->IBSecurityService->Protocol = Mess.IsEmpty() ? Ibservices::Local : Ibservices::TCP;
   DataBases->IBSecurityService->LoginPrompt=false;

   DataBases->IBSecurityService->Params->Add("user_name=sysdba");
   DataBases->IBSecurityService->Params->Add("password=masterkey");

   if(!DataBases->IBSecurityService->Active)
     DataBases->IBSecurityService->Attach();

   DataBases->IBSecurityService->SecurityAction=ActionAddUser;
   DataBases->IBSecurityService->FirstName="First Name";
   DataBases->IBSecurityService->MiddleName="MiddleName";
   DataBases->IBSecurityService->LastName="Last Name";
   DataBases->IBSecurityService->UserName=UserName->Text;
   DataBases->IBSecurityService->Password=Password->Text;

   try
     {
        DataBases->IBSecurityService->AddUser();
     }
   catch(EIBError &eException)
     {
        Mess="IBSecurityService->AddUser() error!!!\nIB error#: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nMessage: "+eException.Message;
        Application->MessageBox(Mess.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
     }
   if(DataBases->IBSecurityService->Active)
     DataBases->IBSecurityService->Detach();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ModifyUserButtonClick(TObject *Sender)
{
   if(UserName->Text.LowerCase()=="sysdba")
     return;

   AnsiString
     Mess=ServerName->Text.Trim();

   DataBases->IBSecurityService->ServerName=Mess;
   DataBases->IBSecurityService->Protocol = Mess.IsEmpty() ? Ibservices::Local : Ibservices::TCP;
   DataBases->IBSecurityService->LoginPrompt=false;

   DataBases->IBSecurityService->Params->Add("user_name=sysdba");
   DataBases->IBSecurityService->Params->Add("password=masterkey");

   if(!DataBases->IBSecurityService->Active)
     DataBases->IBSecurityService->Attach();

   DataBases->IBSecurityService->SecurityAction=ActionModifyUser;
   DataBases->IBSecurityService->MiddleName="Middle Name";
   DataBases->IBSecurityService->UserName=UserName->Text;

   try
     {
        DataBases->IBSecurityService->ModifyUser();
     }
   catch(EIBError &eException)
     {
        Mess="IBSecurityService->ModifyUser() error!!!\nIB error#: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nMessage: "+eException.Message;
        Application->MessageBox(Mess.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
     }
   if(DataBases->IBSecurityService->Active)
     DataBases->IBSecurityService->Detach();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::DeleteUserButtonClick(TObject *Sender)
{
   if(UserName->Text.LowerCase()=="sysdba")
     return;

   AnsiString
     Mess=ServerName->Text.Trim();

   DataBases->IBSecurityService->ServerName=Mess;
   DataBases->IBSecurityService->Protocol = Mess.IsEmpty() ? Ibservices::Local : Ibservices::TCP;
   DataBases->IBSecurityService->LoginPrompt=false;

   DataBases->IBSecurityService->Params->Add("user_name=sysdba");
   DataBases->IBSecurityService->Params->Add("password=masterkey");

   if(!DataBases->IBSecurityService->Active)
     DataBases->IBSecurityService->Attach();

   DataBases->IBSecurityService->SecurityAction=ActionDeleteUser;
   DataBases->IBSecurityService->UserName=UserName->Text;

   try
     {
        DataBases->IBSecurityService->DeleteUser();
     }
   catch(EIBError &eException)
     {
        Mess="IBSecurityService->DeleteUser() error!!!\nIB error#: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nMessage: "+eException.Message;
        Application->MessageBox(Mess.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
     }
   if(DataBases->IBSecurityService->Active)
     DataBases->IBSecurityService->Detach();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ListUserButtonClick(TObject *Sender)
{
   AnsiString
     Mess=ServerName->Text.Trim();

   DataBases->IBSecurityService->ServerName=Mess;
   DataBases->IBSecurityService->Protocol = Mess.IsEmpty() ? Ibservices::Local : Ibservices::TCP;
   DataBases->IBSecurityService->LoginPrompt=false;

   Mess="user_name="+UserName->Text;
   DataBases->IBSecurityService->Params->Add(Mess);
   Mess="password="+Password->Text;
   DataBases->IBSecurityService->Params->Add(Mess);

   try
     {
        if(!DataBases->IBSecurityService->Active)
          DataBases->IBSecurityService->Attach();
     }
   catch(EIBError &eException)
     {
        Mess="IBSecurityService->Attach() error!!!\nIB error#: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nMessage: "+eException.Message;
        Application->MessageBox(Mess.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }

   DataBases->IBSecurityService->SecurityAction=ActionDisplayUser;

   try
     {
        DataBases->IBSecurityService->DisplayUsers();
        ResultMemo->Clear();
        for(int i=0;i<DataBases->IBSecurityService->UserInfoCount;i++)
           {
              Mess="User Name="+DataBases->IBSecurityService->UserInfo[i]->UserName;
              ResultMemo->Items->Add(Mess);
              Mess="First Name="+DataBases->IBSecurityService->UserInfo[i]->FirstName;
              ResultMemo->Items->Add(Mess);
              Mess="Middle Name="+DataBases->IBSecurityService->UserInfo[i]->MiddleName;
              ResultMemo->Items->Add(Mess);
              Mess="Last Name="+DataBases->IBSecurityService->UserInfo[i]->LastName;
              ResultMemo->Items->Add(Mess);
              Mess="GroupID="+IntToStr(DataBases->IBSecurityService->UserInfo[i]->GroupID);
              ResultMemo->Items->Add(Mess);
              Mess="UserID="+IntToStr(DataBases->IBSecurityService->UserInfo[i]->UserID);
              ResultMemo->Items->Add(Mess);
              Mess=AnsiString::StringOfChar('-',13);
              ResultMemo->Items->Add(Mess);
           }
     }
   catch(EIBError &eException)
     {
        Mess="IBSecurityService->DisplayUser() error!!!\nIB error#: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nMessage: "+eException.Message;
        Application->MessageBox(Mess.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
     }

   if(DataBases->IBSecurityService->Active)
     DataBases->IBSecurityService->Detach();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::VersionButtonClick(TObject *Sender)
{
   if(IBAPICheckBox->Checked)
     {
        VersionByIBAPI();
        return;
     }

   AnsiString
     Mess=ServerName->Text.Trim();

   DataBases->IBServerProperties->ServerName=Mess;
   DataBases->IBServerProperties->Protocol = Mess.IsEmpty() ? Ibservices::Local : Ibservices::TCP;
   DataBases->IBServerProperties->LoginPrompt=false;

   Mess="user_name="+UserName->Text;
   DataBases->IBServerProperties->Params->Add(Mess);
   Mess="password="+Password->Text;
   DataBases->IBServerProperties->Params->Add(Mess);

   try
     {
       if(!DataBases->IBServerProperties->Active)
         DataBases->IBServerProperties->Attach();
     }
   catch(EIBError &eException)
     {
        Mess="IBServerProperties->Attach() error!!!\nIB error#: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nMessage: "+eException.Message;
        Application->MessageBox(Mess.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }

   DataBases->IBServerProperties->Options=TPropertyOptions()<<Version;

   try
     {
        DataBases->IBServerProperties->FetchVersionInfo();
        ResultMemo->Clear();
        Mess="Server Version="+DataBases->IBServerProperties->VersionInfo->ServerVersion;
        ResultMemo->Items->Add(Mess);
        Mess="Server Implementation="+DataBases->IBServerProperties->VersionInfo->ServerImplementation;
        ResultMemo->Items->Add(Mess);
        Mess="Service Version="+IntToStr(DataBases->IBServerProperties->VersionInfo->ServiceVersion);
        ResultMemo->Items->Add(Mess);
     }
   catch(EIBError &eException)
     {
        Mess="IBServerProperties->FetchVersionInfo() error!!!\nIB error#: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nMessage: "+eException.Message;
        Application->MessageBox(Mess.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
     }

   if(DataBases->IBServerProperties->Active)
     DataBases->IBServerProperties->Detach();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::DoubleSQLButtonClick(TObject *Sender)
{
   AnsiString SQLBody;

   SQLBody="select * from risk where (Branch= :Branch)";
   DataBases->IBSQL1->Close();
   DataBases->IBSQL1->SQL->Clear();
   DataBases->IBSQL1->SQL->Add(SQLBody);

   try
     {
       if(!DataBases->IBTransaction->InTransaction)
         DataBases->IBTransaction->StartTransaction();
       if(!DataBases->IBSQL1->Prepared)
         DataBases->IBSQL1->Prepare();
       DataBases->IBSQL1->ParamByName("Branch")->AsInteger=Branch->Text.ToInt();
       DataBases->IBSQL1->ExecQuery();
     }
   catch(EIBError &eException)
     {
        SQLBody="IB error#: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nMessage: "+eException.Message;
        Application->MessageBox(SQLBody.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }

   SQLBody="select * from risk where (Branch= :Branch) and (RiskNo>= :MinRiskNo) and (RiskNo<= :MaxRiskNo)";
   DataBases->IBSQL2->Close();
   DataBases->IBSQL2->SQL->Clear();
   DataBases->IBSQL2->SQL->Add(SQLBody);
   try
     {
       if(!DataBases->IBTransaction->InTransaction)
         DataBases->IBTransaction->StartTransaction();
       if(!DataBases->IBSQL2->Prepared)
         DataBases->IBSQL2->Prepare();
       DataBases->IBSQL2->ParamByName("Branch")->AsInteger=Branch->Text.ToInt();
       DataBases->IBSQL2->ParamByName("MinRiskNo")->AsInteger=MinRiskNo->Text.ToInt();
       DataBases->IBSQL2->ParamByName("MaxRiskNo")->AsInteger=MaxRiskNo->Text.ToInt();
       DataBases->IBSQL2->ExecQuery();
     }
   catch(EIBError &eException)
     {
        SQLBody="IB error#: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nMessage: "+eException.Message;
        Application->MessageBox(SQLBody.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }

   ResultMemo->Clear();

   SQLBody="IBSQL1 ("+DataBases->IBSQL1->SQL->Text;
   SQLBody=SQLBody.Delete(SQLBody.Length()-1,2);
   SQLBody+=")";
   ShowResult(SQLBody);
   SQLBody="RecordCount="+IntToStr(DataBases->IBSQL1->RecordCount);
   ShowResult(SQLBody);
   SQLBody=AnsiString::StringOfChar('-',13);
   ShowResult(SQLBody);
   for(;!DataBases->IBSQL1->Eof;DataBases->IBSQL1->Next())
      {
         SQLBody=IntToStr(DataBases->IBSQL1->FieldByName("Branch")->AsInteger)+" ";
         SQLBody+=IntToStr(DataBases->IBSQL1->FieldByName("RiskNo")->AsInteger)+" ";
         SQLBody+=DataBases->IBSQL1->FieldByName("Name")->AsString;
         ShowResult(SQLBody);
      }
   SQLBody=AnsiString::StringOfChar('-',13);
   ShowResult(SQLBody);
   DataBases->IBSQL1->Close();

   SQLBody="IBSQL2 ("+DataBases->IBSQL2->SQL->Text;
   SQLBody=SQLBody.Delete(SQLBody.Length()-1,2);
   SQLBody+=")";
   ShowResult(SQLBody);
   SQLBody="RecordCount="+IntToStr(DataBases->IBSQL2->RecordCount);
   ShowResult(SQLBody);
   SQLBody=AnsiString::StringOfChar('-',13);
   ShowResult(SQLBody);
   for(;!DataBases->IBSQL2->Eof;DataBases->IBSQL2->Next())
      {
         SQLBody=IntToStr(DataBases->IBSQL2->FieldByName("Branch")->AsInteger)+" ";
         SQLBody+=IntToStr(DataBases->IBSQL2->FieldByName("RiskNo")->AsInteger)+" ";
         SQLBody+=DataBases->IBSQL2->FieldByName("Name")->AsString;
         ShowResult(SQLBody);
      }
   SQLBody=AnsiString::StringOfChar('-',13);
   ShowResult(SQLBody);

   if(DataBases->IBTransaction->InTransaction)
     DataBases->IBTransaction->Rollback();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::DoubleQueryButtonClick(TObject *Sender)
{
   AnsiString SQLBody;

   SQLBody="select * from risk where (Branch= :Branch)";
   DataBases->IBQuery1->Close();
   DataBases->IBQuery1->SQL->Clear();
   DataBases->IBQuery1->SQL->Add(SQLBody);

   try
     {
       if(!DataBases->IBTransaction->InTransaction)
         DataBases->IBTransaction->StartTransaction();
       if(!DataBases->IBQuery1->Prepared)
         DataBases->IBQuery1->Prepare();
       DataBases->IBQuery1->ParamByName("Branch")->AsInteger=Branch->Text.ToInt();
       DataBases->IBQuery1->Open();
     }
   catch(EIBError &eException)
     {
        SQLBody="IB error#: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nMessage: "+eException.Message;
        Application->MessageBox(SQLBody.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }

   SQLBody="select * from risk where (Branch= :Branch) and (RiskNo>= :MinRiskNo) and (RiskNo<= :MaxRiskNo)";
   DataBases->IBQuery2->Close();
   DataBases->IBQuery2->SQL->Clear();
   DataBases->IBQuery2->SQL->Add(SQLBody);
   try
     {
       if(!DataBases->IBTransaction->InTransaction)
         DataBases->IBTransaction->StartTransaction();
       if(!DataBases->IBQuery2->Prepared)
         DataBases->IBQuery2->Prepare();
       DataBases->IBQuery2->ParamByName("Branch")->AsInteger=Branch->Text.ToInt();
       DataBases->IBQuery2->ParamByName("MinRiskNo")->AsInteger=MinRiskNo->Text.ToInt();
       DataBases->IBQuery2->ParamByName("MaxRiskNo")->AsInteger=MaxRiskNo->Text.ToInt();
       DataBases->IBQuery2->Open();
     }
   catch(EIBError &eException)
     {
        SQLBody="IB error#: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nMessage: "+eException.Message;
        Application->MessageBox(SQLBody.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }

   ResultMemo->Clear();

   SQLBody="IBQuery1 ("+DataBases->IBQuery1->SQL->Text;
   SQLBody=SQLBody.Delete(SQLBody.Length()-1,2);
   SQLBody+=")";
   ShowResult(SQLBody);
   SQLBody="RecordCount="+IntToStr(DataBases->IBQuery1->RecordCount);
   ShowResult(SQLBody);
   SQLBody=AnsiString::StringOfChar('-',13);
   ShowResult(SQLBody);
   for(DataBases->IBQuery1->First();!DataBases->IBQuery1->Eof;DataBases->IBQuery1->Next())
      {
         SQLBody=IntToStr(DataBases->IBQuery1->FieldByName("Branch")->AsInteger)+" ";
         SQLBody+=IntToStr(DataBases->IBQuery1->FieldByName("RiskNo")->AsInteger)+" ";
         SQLBody+=DataBases->IBQuery1->FieldByName("Name")->AsString;
         ShowResult(SQLBody);
      }
   SQLBody=AnsiString::StringOfChar('-',13);
   ShowResult(SQLBody);

   SQLBody="IBQuery2 ("+DataBases->IBQuery2->SQL->Text;
   SQLBody=SQLBody.Delete(SQLBody.Length()-1,2);
   SQLBody+=")";
   ShowResult(SQLBody);
   SQLBody="RecordCount="+IntToStr(DataBases->IBQuery2->RecordCount);
   ShowResult(SQLBody);
   SQLBody=AnsiString::StringOfChar('-',13);
   ShowResult(SQLBody);
   for(DataBases->IBQuery2->First();!DataBases->IBQuery2->Eof;DataBases->IBQuery2->Next())
      {
         SQLBody=IntToStr(DataBases->IBQuery2->FieldByName("Branch")->AsInteger)+" ";
         SQLBody+=IntToStr(DataBases->IBQuery2->FieldByName("RiskNo")->AsInteger)+" ";
         SQLBody+=DataBases->IBQuery2->FieldByName("Name")->AsString;
         ShowResult(SQLBody);
      }
   SQLBody=AnsiString::StringOfChar('-',13);
   ShowResult(SQLBody);

   if(DataBases->IBTransaction->InTransaction)
     DataBases->IBTransaction->Rollback();
}
//---------------------------------------------------------------------------

void __fastcall ShowResult(AnsiString &Message)
{
    static int maxWidth=0;
    MainForm->ResultMemo->Items->Append(Message);
    int width=MainForm->ResultMemo->Canvas->TextWidth(MainForm->ResultMemo->Items->Strings[MainForm->ResultMemo->Items->Count-1])+0x020;
    maxWidth=width>=maxWidth?width:maxWidth;
    MainForm->ResultMemo->Perform(LB_SETHORIZONTALEXTENT,maxWidth,0);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::LicenseButtonClick(TObject *Sender)
{
   AnsiString
     Mess=ServerName->Text.Trim();

   DataBases->IBServerProperties->ServerName=Mess;
   DataBases->IBServerProperties->Protocol = Mess.IsEmpty() ? Ibservices::Local : Ibservices::TCP;
   DataBases->IBServerProperties->LoginPrompt=false;

   Mess="user_name="+UserName->Text;
   DataBases->IBServerProperties->Params->Add(Mess);
   Mess="password="+Password->Text;
   DataBases->IBServerProperties->Params->Add(Mess);

   try
     {
       if(!DataBases->IBServerProperties->Active)
         DataBases->IBServerProperties->Attach();
     }
   catch(EIBError &eException)
     {
        Mess="IBServerProperties->Attach() error!!!\nIB error#: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nMessage: "+eException.Message;
        Application->MessageBox(Mess.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }

   DataBases->IBServerProperties->Options=TPropertyOptions()<<License;

   try
     {
        DataBases->IBServerProperties->FetchLicenseInfo();
        ResultMemo->Clear();
        Mess="Licensed Users = "+IntToStr(DataBases->IBServerProperties->LicenseInfo->LicensedUsers);
        ResultMemo->Items->Add(Mess);
        for(int i=0;i<DataBases->IBServerProperties->LicenseInfo->Key.High;i++)
           ResultMemo->Items->Add(DataBases->IBServerProperties->LicenseInfo->Key[i]+":"+DataBases->IBServerProperties->LicenseInfo->Id[i]+":"+DataBases->IBServerProperties->LicenseInfo->Desc[i]);
     }
   catch(EIBError &eException)
     {
        Mess="IBServerProperties->FetchLicenseInfo() error!!!\nIB error#: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nMessage: "+eException.Message;
        Application->MessageBox(Mess.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
     }

   if(DataBases->IBServerProperties->Active)
     DataBases->IBServerProperties->Detach();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::LicenseMaskButtonClick(TObject *Sender)
{
   AnsiString
     Mess=ServerName->Text.Trim();

   DataBases->IBServerProperties->ServerName=Mess;
   DataBases->IBServerProperties->Protocol = Mess.IsEmpty() ? Ibservices::Local : Ibservices::TCP;
   DataBases->IBServerProperties->LoginPrompt=false;

   Mess="user_name="+UserName->Text;
   DataBases->IBServerProperties->Params->Add(Mess);
   Mess="password="+Password->Text;
   DataBases->IBServerProperties->Params->Add(Mess);

   try
     {
       if(!DataBases->IBServerProperties->Active)
         DataBases->IBServerProperties->Attach();
     }
   catch(EIBError &eException)
     {
        Mess="IBServerProperties->Attach() error!!!\nIB error#: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nMessage: "+eException.Message;
        Application->MessageBox(Mess.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }

   DataBases->IBServerProperties->Options=TPropertyOptions()<<LicenseMask;

   try
     {
        DataBases->IBServerProperties->FetchLicenseMaskInfo();
        ResultMemo->Clear();
        Mess="License Mask = "+IntToStr(DataBases->IBServerProperties->LicenseMaskInfo->LicenseMask);
        ResultMemo->Items->Add(Mess);
        Mess="Capability Mask = "+IntToStr(DataBases->IBServerProperties->LicenseMaskInfo->CapabilityMask);
        ResultMemo->Items->Add(Mess);
     }
   catch(EIBError &eException)
     {
        Mess="IBServerProperties->FetchLicenseMaskInfo() error!!!\nIB error#: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nMessage: "+eException.Message;
        Application->MessageBox(Mess.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
     }

   if(DataBases->IBServerProperties->Active)
     DataBases->IBServerProperties->Detach();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::AddUserByIBAPI(void)
{
   ISC_STATUS status[20];
   TUserSecData sec;

   sec.sec_flags = //sec_uid_spec |
                   //sec_gid_spec |
                   sec_server_spec |
                   sec_password_spec |
                   //sec_group_name_spec |
                   sec_first_name_spec |
                   sec_middle_name_spec |
                   sec_last_name_spec |
                   sec_dba_user_name_spec |
                   sec_dba_password_spec;

   //sec.uid
   //sec.gid
   sec.protocol=sec_protocol_tcpip;
   sec.server="localhost";
   sec.user_name="UserName";
   sec.password="Password";
   //sec.group_name
   sec.first_name="FirstName";
   sec.middle_name="MiddleMame";
   sec.last_name="LastName";
   sec.dba_user_name="sysdba";
   sec.dba_password="masterkey";

   _di_IGDSLibrary
     gdsInterface=GetGDSLibrary();

   long Result=gdsInterface->isc_add_user(status, &sec);
   AnsiString Mess;
   if(/*status[0]==1 && status[1]*/Result)
     {
        switch(/*status[1]*/Result)
          {
             case isc_usrname_too_long           : {
                                                      Mess="The user name passed in is greater than 31 bytes";
                                                      break;
                                                   }
             case isc_password_too_long          : {
                                                      Mess="The password passed in is longer than 8 bytes";
                                                      break;
                                                   }
             case isc_usrname_required           : {
                                                      Mess="The operation requires a user name";
                                                      break;
                                                   }
             case isc_password_required          : {
                                                      Mess="The operation requires a password";
                                                      break;
                                                   }
             case isc_bad_protocol               : {
                                                      Mess="The protocol specified is invalid";
                                                      break;
                                                   }
             case isc_dup_usrname_found          : {
                                                      Mess="The user name being added already exists in the security database";
                                                      break;
                                                   }
             case isc_usrname_not_found          : {
                                                      Mess="The user name was not found in the security database";
                                                      break;
                                                   }
             case isc_error_adding_sec_record    : {
                                                      Mess="An unknown error occurred while adding a user";
                                                      break;
                                                   }
             case isc_error_deleting_sec_record  : {
                                                      Mess="An unknown error occurred while deleting a user";
                                                      break;
                                                   }
             case isc_error_modifying_sec_record : {
                                                      Mess="An unknown error occurred while modifying a user";
                                                      break;
                                                   }
             case isc_error_updating_sec_db      : {
                                                      Mess=" An unknown error occurred while updating the security database";
                                                      break;
                                                   }
          }
        throw Exception(Mess);
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::VersionByIBAPI(void)
{
   TISC_DB_HANDLE db=0L;
   char GDBName[8000];
   ISC_STATUS status_vector[20];
   char dpb_buffer[256], *dpb, *p;
   short dpb_length;
   char user_name[8000];
   char user_password[8000];

   ResultMemo->Clear();

   strcpy(GDBName,GDBComboBox->Text.c_str());
   strcpy(user_name,UserName->Text.c_str());
   strcpy(user_password,Password->Text.c_str());
   setmem(status_vector,sizeof(status_vector),0);
   setmem(dpb_buffer,sizeof(dpb_buffer),0);
   dpb = dpb_buffer;

   *dpb++ = Ibheader::isc_dpb_version1;
   *dpb++ = Ibheader::isc_dpb_user_name;
   *dpb++ = strlen(user_name);
   for (p = user_name; *p;)
       *dpb++ = *p++;
   *dpb++ = Ibheader::isc_dpb_password;
   *dpb++ = strlen(user_password);
   for (p = user_password; *p;)
       *dpb++ = *p++;
   dpb_length = dpb - dpb_buffer;

   _di_IGDSLibrary
     gdsInterface=GetGDSLibrary();

//   isc_expand_dpb(&dpb, &dpb_length, Ibheader::isc_dpb_user_name, user_name, Ibheader::isc_dpb_password, user_password, 0);
   gdsInterface->isc_attach_database(status_vector, strlen(GDBName), GDBName, &db, dpb_length, dpb_buffer);
   if (status_vector[0] == 1 && status_vector[1])
     {
     return;
    }
   char db_items[] = {isc_info_access_path, isc_info_implementation/*,isc_info_db_SQL_dialect, isc_info_page_size, isc_info_num_buffers, */,isc_info_end};
   char res_buffer[8000], item;
   __int64 length;
   long page_size = 0L, num_buffers = 0L, Dialect=0l;
   gdsInterface->isc_database_info(
                     status_vector,
                     &db,
                     sizeof(db_items),
                     db_items,
                     sizeof(res_buffer),
                     res_buffer);
   if(status_vector[0]==1 && status_vector[1])
   {
      gdsInterface->isc_detach_database(status_vector, &db);
      return;
   }

   HMODULE
     h=GetModuleHandle("gds32.dll");

   Tisc_portable_integer
     isc_portable_integer=(Tisc_portable_integer)GetProcAddress(h,"isc_portable_integer");

   for(p=res_buffer; *p!=isc_info_end ;)
   {
      item=*p++;
      length=isc_portable_integer(p,2);
      p+=2;
      switch (item)
      {
         case isc_info_page_size :
         {
            page_size=isc_portable_integer(p,length);
            break;
         }
         case isc_info_num_buffers :
         {
            num_buffers=isc_portable_integer(p,length);
            break;
         }
         case isc_info_db_SQL_dialect :
         {
            Dialect=isc_portable_integer(p,length);
            break;
         }
         case isc_info_implementation :
         {
            int
              l,
              i=1;

            l=*(p+i++);
            setmem(user_name,sizeof(user_name),0x0ff);
            strncpy(user_name,p+i,l);
            *(user_name+l)=0;

            break;
         }
         case isc_info_version :
         {
            int
              l,
              i=1;

            l=*(p+i++);
            setmem(user_name,sizeof(user_name),0x0ff);
            strncpy(user_name,p+i,l);
            *(user_name+l)=0;
            ResultMemo->Items->Add("Server Version="+AnsiString(user_name));

            break;
         }
         default :
         {
            break;
         }
      }
      p+=length;
   }

   gdsInterface->isc_detach_database(status_vector, &db);
   if(status_vector[0] == 1 && status_vector[1])
   {
      return;
   }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::IBAPICheckBoxClick(TObject *Sender)
{
   GDBComboBox->Enabled=IBAPICheckBox->Checked;
}
//---------------------------------------------------------------------------

