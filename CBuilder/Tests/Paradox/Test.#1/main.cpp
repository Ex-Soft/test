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

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{

}
//---------------------------------------------------------------------------

void __fastcall TMainForm::Exit1Click(TObject *Sender)
{
   Close();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ButtonSetGetClick(TObject *Sender)
{
   char
     buff[1024];

   int
     Id=StrToIntDef(EditId->Text,0);

   if(RadioButtonSet->Checked)
   {
      DataBases->QuerySetGet->SQL->Text="\
update \
'test#1.db' as t \
set \
t.'Table'=:'Value' \
where \
(Id=:Id) \
";
      if(!DataBases->QuerySetGet->Prepared)
        DataBases->QuerySetGet->Prepare();
      if(CheckBoxASCII->Checked)
        CharToOem(EditValue->Text.c_str(),buff);
      else
        strcpy(buff,EditValue->Text.c_str());
      DataBases->QuerySetGet->ParamByName("Value")->AsString=buff;
      DataBases->QuerySetGet->ParamByName("Id")->AsInteger=Id;
      DataBases->QuerySetGet->ExecSQL();
   }
   else
   {
      DataBases->QuerySetGet->SQL->Text="\
select \
t.'Table' \
from \
'test#1.db' as t \
where \
(t.Id=:Id) \
";
      if(!DataBases->QuerySetGet->Prepared)
        DataBases->QuerySetGet->Prepare();
      DataBases->QuerySetGet->ParamByName("Id")->AsInteger=Id;
      DataBases->QuerySetGet->Open();
      if(CheckBoxASCII->Checked)
        OemToChar(DataBases->QuerySetGet->FieldByName("Table")->AsString.c_str(),buff);
      else
        strcpy(buff,DataBases->QuerySetGet->FieldByName("Table")->AsString.c_str());
      EditValue->Text=buff;
   }
}
//---------------------------------------------------------------------------

