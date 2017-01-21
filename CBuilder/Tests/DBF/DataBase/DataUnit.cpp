//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "DataUnit.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

#define TEST_RECNO
//#define FILL_IMPORT_BILL

TDataBases *DataBases;
//---------------------------------------------------------------------------

__fastcall TDataBases::TDataBases(TComponent* Owner):TDataModule(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TDataBases::DataModuleCreate(TObject *Sender)
{
   #if defined(TEST_RECNO)
      AnsiString
        tmpAnsiString;

      TTable
        *DbfTable=new TTable(0);

      DbfTable->DatabaseName="e:\\fpd26\\dbf\\";
      DbfTable->TableName="TestRN.dbf";
      DbfTable->TableType=ttFoxPro;

      tmpAnsiString="";
      DbfTable->Open();
      for(DbfTable->First(); !DbfTable->Eof; DbfTable->Next())
      {
         if(!tmpAnsiString.IsEmpty())
           tmpAnsiString+="\r\n";
         tmpAnsiString+="Rec# "+IntToStr(DbfTable->RecNo)+" "+IntToStr(DbfTable->FieldByName("FInt")->AsInteger);
      }
      DbfTable->Close();
      ShowMessage(tmpAnsiString);

      DbfTable->Open();
      DbfTable->RecNo=2;
      tmpAnsiString="Rec# "+IntToStr(DbfTable->RecNo)+" "+IntToStr(DbfTable->FieldByName("FInt")->AsInteger);
      DbfTable->Close();
      ShowMessage(tmpAnsiString);

      tmpAnsiString="";
      DbfTable->IndexName="FInt";
      DbfTable->Open();
      for(DbfTable->First(); !DbfTable->Eof; DbfTable->Next())
      {
         if(!tmpAnsiString.IsEmpty())
           tmpAnsiString+="\r\n";
         tmpAnsiString+="Rec# "+IntToStr(DbfTable->RecNo)+" "+IntToStr(DbfTable->FieldByName("FInt")->AsInteger);
      }
      DbfTable->Close();
      ShowMessage(tmpAnsiString);

      DbfTable->Open();
      DbfTable->RecNo=2;
      tmpAnsiString="Rec# "+IntToStr(DbfTable->RecNo)+" "+IntToStr(DbfTable->FieldByName("FInt")->AsInteger);
      DbfTable->Close();
      ShowMessage(tmpAnsiString);

      delete DbfTable;
   #endif

   DataSource1->DataSet=Query1;

   Query1->DatabaseName="e:\\fpd26\\dbf\\";

   #if defined(FILL_IMPORT_BILL)
       char
         buff[1024];

   Query1->DatabaseName="E:\\Soft.src\\ASP.NET\\bill\\import\\Payments\\src\\";

       Query1->SQL->Text="\
update \
  \"500000000000011_20070706_085438.dbf\" \
set \
  KL_NM_K = :NAME_A, \
  TEXT1 = :PAYMENT_PURPOSE, \
  MFO_NM = :NAME_BANK_B, \
  MFO_NM_K = :NAME_BANK_A \
";
       if(!Query1->Prepared)
         Query1->Prepare();
       CharToOem("Рекламне агенство \"Об'ява\"",buff);
       Query1->ParamByName("NAME_A")->AsString=buff;
       CharToOem("за бумагу, за чорнило",buff);
       Query1->ParamByName("PAYMENT_PURPOSE")->AsString=buff;
       CharToOem("Коростишівське ТВБВ банку \"Україна\"",buff);
       // Є F2 242
       // є F3 243
       // І F6 246
       // і F7 247
       // Ї F8 248
       // ї F9 249
       buff[8]='\xf7';
       buff[31]='\xf9';
       Query1->ParamByName("NAME_BANK_B")->AsString=buff;
       Query1->ParamByName("NAME_BANK_A")->AsString=buff;
       Query1->ExecSQL();
   #endif

   Query1->SQL->Text="\
select \
m.*, \
d_l_I.*, \
d_l_II.* \
from \
master.dbf m \
left outer join det_l_I.dbf d_l_I on (d_l_I.Master_ID=m.ID) \
left outer join det_l_II.dbf d_l_II on (d_l_II.Master_ID=d_l_I.Master_ID) and (d_l_II.det_l_I_ID=d_l_I.ID) \
order by m.ID, d_l_I.ID, d_l_II.ID";

/*
   Query1->SQL->Text="\
select \
m.*, \
d_l_I.*, \
d_l_II.* \
from \
master.dbf m \
left outer join det_l_I.dbf d_l_I on (d_l_I.Master_ID=m.ID) \
left outer join det_l_II.dbf d_l_II on (d_l_II.Master_ID=m.ID) and (d_l_II.det_l_I_ID=d_l_I.ID) \
order by m.ID, d_l_I.ID, d_l_II.ID";
*/

   Query1->Open();
}
//---------------------------------------------------------------------------

void __fastcall TDataBases::DataModuleDestroy(TObject *Sender)
{
   if(Query1->Active)
     Query1->Close();
}
//---------------------------------------------------------------------------
