//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "DataUnit.h"
#include "main.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

TDataBase *DataBase;
//---------------------------------------------------------------------------

__fastcall TDataBase::TDataBase(TComponent* Owner):TDataModule(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::IBSQLMonitorSQL(AnsiString EventText, TDateTime EventTime)
{
   MainForm->MemoIBSQLMonitor->Lines->Add(EventText);
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::DataModuleDestroy(TObject *Sender)
{
   if(IBDatabase->Connected)
     IBDatabase->Close();
}
//---------------------------------------------------------------------------
