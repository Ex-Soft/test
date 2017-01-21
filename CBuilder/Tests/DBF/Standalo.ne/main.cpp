//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "main.h"
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
   AnsiString
     SQLBody;

   Table->Filtered=false;
   Table->SessionName="Default";
   Table->TableType=ttFoxPro;
   Table->DatabaseName=ExtractFilePath(Application->ExeName);
   Table->TableName="test_dbf.dbf";
   Table->IndexName="";
   Table->Open();
   for(Table->First(); !Table->Eof; Table->Next())
      SQLBody=Table->FieldByName("A")->AsString;
   Table->Append();
   Table->FieldByName("A")->AsString=Now().DateTimeString();
   Table->Post();
   Table->Close();

   SQLBody="\
select * \
from \"test_dbf.dbf\"\
";

   Query->SQL->Clear();
   Query->SQL->Add(SQLBody);
   Query->DatabaseName=ExtractFilePath(Application->ExeName);
   Query->SessionName="Default";

   Query->Open();

   if(Query->Active)
   {
      Query->SQL->Text="select * from \"test_dbf.dbf\" where A is null";
      Query->Open();
   }

   for(Query->First(); !Query->Eof; Query->Next())
      SQLBody=Query->FieldByName("A")->AsString;

   Query->Filtered=true;

   Query->Filter="(A='2345678')";
   for(Query->First(); !Query->Eof; Query->Next())
      SQLBody=Query->FieldByName("A")->AsString;

   Query->Filter=Query->Filter+" or (A='8765432')";
   //Query->Filter+=" or (A='8765432')"; // wrong
   SQLBody="";
   for(Query->First(); !Query->Eof; Query->Next())
   {
      if(!SQLBody.IsEmpty())
        SQLBody+=" ";
      SQLBody+=Query->FieldByName("A")->AsString;
   }

   Query->Close();
}
//---------------------------------------------------------------------------

