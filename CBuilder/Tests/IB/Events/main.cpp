//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "main.h"
#include "DataUnit.h"
//---------------------------------------------------------------------------

#pragma package(smart_init)
#pragma resource "*.dfm"

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner)
        : TForm(Owner)
{
   IBCount=IBEvent=IBEventCount=0;
   IBCancelAlerts=false;
   IBServerName->Text="localhost";
   IBDatabaseName->Text=ExtractFilePath(Application->ExeName)+"test.gdb";
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormShow(TObject *Sender)
{
   Timer1->Enabled=true;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::OpenBitBtnClick(TObject *Sender)
{
   AnsiString SQLBody;

   DataBases->IBServerName=IBServerName->Text.Trim();
   DataBases->IBDatabaseName=IBDatabaseName->Text.Trim();

   OpenBitBtn->Enabled=!DataBases->OpenDatbase();
   InsertBitBtn->Enabled=!OpenBitBtn->Enabled;
   DeleteBitBtn->Enabled=!OpenBitBtn->Enabled;
   UpdateBitBtn->Enabled=!OpenBitBtn->Enabled;
   RefreshBitBtn->Enabled=!OpenBitBtn->Enabled;
   
   if(!OpenBitBtn->Enabled)
     {
        DBGrid->DataSource=DataBases->DataSource;
        DBGrid->Visible=true;

        SQLBody="select * from \"TestTable\"";
        DataBases->IBViewQuery->Close();
        DataBases->IBViewQuery->SQL->Clear();
        DataBases->IBViewQuery->SQL->Add(SQLBody);

        if(DataBases->IBTransaction->InTransaction)
          DataBases->IBTransaction->Rollback();
        DataBases->IBTransaction->StartTransaction();

        try
          {
             DataBases->IBViewQuery->Open();
          }
        catch(EIBError &eException)
          {
             SQLBody="Помилка роботи з БД "+DataBases->IBDatabaseName.LowerCase()+" на сервері "+DataBases->IBServerName.UpperCase()+"\nN помилки IB: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nЗміст помилки: "+eException.Message;
             Application->MessageBox(SQLBody.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
             return;
          }
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::InsertBitBtnClick(TObject *Sender)
{
   AnsiString SQLBody;

   Events->Text="";
   IBEvent=0;

   SQLBody="insert into \"TestTable\" (\"StrF\", \"UserId\") values (\'insert\',"+IntToStr(++IBCount)+")";
   DataBases->IBQuery->Close();
   DataBases->IBQuery->SQL->Clear();
   DataBases->IBQuery->SQL->Add(SQLBody);

   if(DataBases->IBTransaction->InTransaction)
     DataBases->IBTransaction->Rollback();
   DataBases->IBTransaction->StartTransaction();

   try
     {
        DataBases->IBQuery->ExecSQL();
        DataBases->IBQuery->ExecSQL();
        DataBases->IBQuery->ExecSQL();
        DataBases->IBQuery->ExecSQL();
        DataBases->IBQuery->ExecSQL();
     }
   catch(EIBError &eException)
     {
        SQLBody="Помилка роботи з БД "+DataBases->IBDatabaseName.LowerCase()+" на сервері "+DataBases->IBServerName.UpperCase()+"\nN помилки IB: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nЗміст помилки: "+eException.Message;
        Application->MessageBox(SQLBody.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        DataBases->IBTransaction->Rollback();
        return;
     }

   if(CommitCheckBox->Checked)
     DataBases->IBTransaction->Commit();
   else
     DataBases->IBTransaction->Rollback();

   SQLBody="select * from \"TestTable\"";
   DataBases->IBViewQuery->Close();
   DataBases->IBViewQuery->SQL->Clear();
   DataBases->IBViewQuery->SQL->Add(SQLBody);

   if(DataBases->IBTransaction->InTransaction)
     DataBases->IBTransaction->Rollback();
   DataBases->IBTransaction->StartTransaction();

   try
     {
        DataBases->IBViewQuery->Open();
        DBGrid->Refresh();
     }
   catch(EIBError &eException)
     {
        SQLBody="Помилка роботи з БД "+DataBases->IBDatabaseName.LowerCase()+" на сервері "+DataBases->IBServerName.UpperCase()+"\nN помилки IB: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nЗміст помилки: "+eException.Message;
        Application->MessageBox(SQLBody.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        DataBases->IBTransaction->Rollback();
        return;
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::DeleteBitBtnClick(TObject *Sender)
{
   AnsiString SQLBody;

   Events->Text="";
   IBEvent=0;

   SQLBody="delete from \"TestTable\" where (\"UserId\"="+IntToStr(IBCount)+")";
   DataBases->IBQuery->Close();
   DataBases->IBQuery->SQL->Clear();
   DataBases->IBQuery->SQL->Add(SQLBody);

   if(DataBases->IBTransaction->InTransaction)
     DataBases->IBTransaction->Rollback();
   DataBases->IBTransaction->StartTransaction();

   try
     {
        DataBases->IBQuery->ExecSQL();
     }
   catch(EIBError &eException)
     {
        SQLBody="Помилка роботи з БД "+DataBases->IBDatabaseName.LowerCase()+" на сервері "+DataBases->IBServerName.UpperCase()+"\nN помилки IB: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nЗміст помилки: "+eException.Message;
        Application->MessageBox(SQLBody.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        DataBases->IBTransaction->Rollback();
        return;
     }

   if(CommitCheckBox->Checked)
     DataBases->IBTransaction->Commit();
   else
     DataBases->IBTransaction->Rollback();

   SQLBody="select * from \"TestTable\"";
   DataBases->IBViewQuery->Close();
   DataBases->IBViewQuery->SQL->Clear();
   DataBases->IBViewQuery->SQL->Add(SQLBody);

   if(DataBases->IBTransaction->InTransaction)
     DataBases->IBTransaction->Rollback();
   DataBases->IBTransaction->StartTransaction();

   try
     {
        DataBases->IBViewQuery->Open();
     }
   catch(EIBError &eException)
     {
        SQLBody="Помилка роботи з БД "+DataBases->IBDatabaseName.LowerCase()+" на сервері "+DataBases->IBServerName.UpperCase()+"\nN помилки IB: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nЗміст помилки: "+eException.Message;
        Application->MessageBox(SQLBody.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        DataBases->IBTransaction->Rollback();
        return;
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::UpdateBitBtnClick(TObject *Sender)
{
   AnsiString SQLBody;

   Events->Text="";
   IBEvent=0;

   SQLBody="update \"TestTable\" set \"UserId\"="+IntToStr(IBCount+1)+" where (\"UserId\"="+IntToStr(IBCount)+")";
   DataBases->IBQuery->Close();
   DataBases->IBQuery->SQL->Clear();
   DataBases->IBQuery->SQL->Add(SQLBody);

   if(DataBases->IBTransaction->InTransaction)
     DataBases->IBTransaction->Rollback();
   DataBases->IBTransaction->StartTransaction();

   try
     {
        DataBases->IBQuery->ExecSQL();
     }
   catch(EIBError &eException)
     {
        SQLBody="Помилка роботи з БД "+DataBases->IBDatabaseName.LowerCase()+" на сервері "+DataBases->IBServerName.UpperCase()+"\nN помилки IB: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nЗміст помилки: "+eException.Message;
        Application->MessageBox(SQLBody.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        DataBases->IBTransaction->Rollback();
        return;
     }

   if(CommitCheckBox->Checked)
     DataBases->IBTransaction->Commit();
   else
     DataBases->IBTransaction->Rollback();

   SQLBody="select * from \"TestTable\"";
   DataBases->IBViewQuery->Close();
   DataBases->IBViewQuery->SQL->Clear();
   DataBases->IBViewQuery->SQL->Add(SQLBody);

   if(DataBases->IBTransaction->InTransaction)
     DataBases->IBTransaction->Rollback();
   DataBases->IBTransaction->StartTransaction();

   try
     {
        DataBases->IBViewQuery->Open();
     }
   catch(EIBError &eException)
     {
        SQLBody="Помилка роботи з БД "+DataBases->IBDatabaseName.LowerCase()+" на сервері "+DataBases->IBServerName.UpperCase()+"\nN помилки IB: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nЗміст помилки: "+eException.Message;
        Application->MessageBox(SQLBody.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        DataBases->IBTransaction->Rollback();
        return;
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::Timer1Timer(TObject *Sender)
{
   switch(IBEvent)
     {
        case  1 : {
                     Events->Text="InsertBefore";
                     break;
                  }
        case  2 : {
                     Events->Text="InsertAfter";
                     break;
                  }
        case  3 : {
                     Events->Text="DeleteBefore";
                     break;
                  }
        case  4 : {
                     Events->Text="DeleteAfter";
                     break;
                  }
        case  5 : {
                     Events->Text="UpdateBefore";
                     break;
                  }
        case  6 : {
                     Events->Text="UpdateAfter";
                     break;
                  }
        default : {
                     Events->Text="";
                     break;
                  }
     }
   EventCount->Text=IntToStr(IBEventCount);
   CancelAlerts->Text=IBCancelAlerts?"true":"false";
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::RefreshBitBtnClick(TObject *Sender)
{
   AnsiString SQLBody="select * from \"TestTable\"";

   DataBases->IBViewQuery->Close();
   DataBases->IBViewQuery->SQL->Clear();
   DataBases->IBViewQuery->SQL->Add(SQLBody);

   DataBases->IBQuery->Close();
   DataBases->IBQuery->SQL->Clear();
   DataBases->IBQuery->SQL->Add(SQLBody);

   if(!DataBases->IBTransaction->InTransaction)
     DataBases->IBTransaction->StartTransaction();

   try
     {
        DataBases->IBViewQuery->Open();
        DataBases->IBQuery->Open();
        DataBases->IBQuery->FetchAll();
     }
   catch(EIBError &eException)
     {
        SQLBody="Помилка роботи з БД "+DataBases->IBDatabaseName.LowerCase()+" на сервері "+DataBases->IBServerName.UpperCase()+"\nN помилки IB: "+IntToStr(eException.IBErrorCode)+"\nSQLCode: "+IntToStr(eException.SQLCode)+"\nЗміст помилки: "+eException.Message;
        Application->MessageBox(SQLBody.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::UseEventsCheckBoxClick(TObject *Sender)
{
   if(UseEventsCheckBox->Checked)
     DataBases->IBEvents->OnEventAlert=DataBases->IBEventsEventAlert;
   else
     DataBases->IBEvents->OnEventAlert=0;
}
//---------------------------------------------------------------------------

