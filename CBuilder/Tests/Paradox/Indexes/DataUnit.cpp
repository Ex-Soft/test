//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "DataUnit.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

TDataBase *DataBase;
//---------------------------------------------------------------------------

__fastcall TDataBase::TDataBase(TComponent* Owner):TDataModule(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::DataModuleCreate(TObject *Sender)
{
   AnsiString
     BCB=ExtractFileDrive(getenv("BCB"));

   Table1->DatabaseName=BCB+"\\Progra~1\\Common~1\\Borlan~1\\Data\\";
   Table1->TableName="reservat.db";
   Table1->TableType=ttParadox;
   Table1->Open();

   Table1->IndexDefs->Update();
/*
   Table1->MoveBy(10);
   Table1->Delete();

   Table1->MoveBy(5);
   Table1->Edit();
   Table1->FieldByName("Card_Exp")->AsDateTime=Now();
   Table1->Post();

   Table1->MoveBy(3);
   Table1->Insert();
   Table1->FieldByName("Card_Exp")->AsDateTime=Now();
   Table1->Post();

   Table1->Append();
   Table1->FieldByName("Card_Exp")->AsDateTime=Now();
   Table1->Post();
*/
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::DataModuleDestroy(TObject *Sender)
{
   if(Table1->Active)
     Table1->Close();
}
//---------------------------------------------------------------------------

