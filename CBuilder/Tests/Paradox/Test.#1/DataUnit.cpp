//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "DataUnit.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

#define TEST_TQUERY
//#define TEST_FILTER
//#define BLOB_SAVE
//#define BLOB_LOAD

TDataBases *DataBases;
//---------------------------------------------------------------------------

__fastcall TDataBases::TDataBases(TComponent* Owner):TDataModule(Owner)
{
   #if defined(TEST_TQUERY)
     TQuery
       *tmpQuery=new TQuery(0);

     tmpQuery->DatabaseName=ExtractFilePath(Application->ExeName)+"db\\";
     tmpQuery->SQL->Text="select * from Filial";
     tmpQuery->Open();
     tmpQuery->Close();
     delete tmpQuery;
   #endif

   Query1->DatabaseName=ExtractFilePath(Application->ExeName)+"db\\";
   QuerySetGet->DatabaseName=Query1->DatabaseName;

   Table1->DatabaseName=ExtractFilePath(Application->ExeName)+"db\\";
   Table1->TableType=ttParadox;

   #if defined(TEST_FILTER)
      Table1->TableName="Filial.db";
      Table1->Open();
      Table1->Filter="FilialNameN like 'A%'";
      Table1->Close();
   #endif

   TGraphicField
     *GraphicField;

   #if defined(BLOB_SAVE)
      Query1->SQL->Text="insert into TestTypes (Id, FGraphic) values (:Id, :FGraphic)";
      Query1->ParamByName("Id")->AsFloat=1;
      Query1->ParamByName("FGraphic")->LoadFromFile("xpfirewall.bmp",ftGraphic);
      Query1->ExecSQL();

      Table1->TableName="TestTypes.db";
      Table1->Open();
      Table1->Append();
      Table1->FieldByName("Id")->AsFloat=2;
      if(GraphicField=dynamic_cast<TGraphicField *>(Table1->FieldByName("FGraphic")))
        GraphicField->LoadFromFile("xpfirewall.bmp");
      Table1->Post();
      Table1->Close();
   #endif

   #if defined(BLOB_LOAD)
      Query1->SQL->Text="select * from TestTypes";
      Query1->Open();

      TField
        *tmpTField;

      AnsiString
        tmpAnsiString;

      for(int i=0; i<Query1->Fields->Count; ++i)
      {
         tmpTField=Query1->Fields->Fields[i];
         tmpAnsiString=tmpTField->FieldName;
      }

      for(Query1->First(); !Query1->Eof; Query1->Next())
      {
         if(GraphicField=dynamic_cast<TGraphicField *>(Query1->FieldByName("FGraphic")))
           GraphicField->SaveToFile("xpfirewall_out.bmp");
      }
      Query1->Close();

      Table1->TableName="TestTypes.db";
      Table1->Open();
      for(Table1->First(); !Table1->Eof; Table1->Next())
      {
         if(GraphicField=dynamic_cast<TGraphicField *>(Table1->FieldByName("FGraphic")))
           GraphicField->SaveToFile("xpfirewall_out.bmp");
      }
      Table1->Close();
   #endif

   // Query1->SQL->Text="select * from 'money.db'";
   Query1->SQL->Text="\
SELECT DISTINCT \
ACHECK.Unit, \
'Money.db'.'Name', \
Sum(APCHECK.OriginalSum) AS APSUM \
FROM \
(ACHECK INNER JOIN APCHECK ON ACHECK.Sys_Num=APCHECK.Sys_Num) \
INNER JOIN 'Money.db' ON APCHECK.Curency='Money.db'.'Sifr' \
WHERE \
((ACHECK.LogicDate)='20.05.2007') \
GROUP BY ACHECK.Unit, 'Money.db'.'Name'\
";

   //Query1->SQL->Text="select * from 'test#1.db'";

   //Query1->SQL->Text="select * from 'test#1.db' as t where t.'Table'='Table#1'";
   //Query1->SQL->Text="select * from 'test#1.db' as t where t.\"Table\"='Table#1'";
   //Query1->SQL->Text="select * from 'test#1.db' where 'test#1.db'.'Table'='Table#1'";
   //Query1->SQL->Text="select * from 'test#1.db' where 'test#1.db'.\"Table\"='Table#1'";
   //Query1->SQL->Text="select * from 'test#1.db' where \"test#1.db\".'Table'='Table#1'";
   //Query1->SQL->Text="select * from 'test#1.db' where \"test#1.db\".\"Table\"='Table#1'";
   //Query1->SQL->Text="select * from 'Filial.db' as t where t.'FilialNameN'='ÀÊÁ \"Óêðñîöáàíê\"'";
   //Query1->SQL->Text="select * from 'Filial.db' as t where t.'USBNo'=10";

   //Query1->SQL->Text="select * from 'test#1.db' as t where t.'Table'=:'Table'";
   //Query1->ParamByName("Table")->AsString="Table#1";

   //Query1->SQL->Text="select * from 'Filial.db' as t where t.'FilialNameN'=:'FilialNameN'";
   //Query1->ParamByName("FilialNameN")->AsString="ÀÊÁ \"Óêðñîöáàíê\"";

   //Query1->SQL->Text="select * from 'Filial.db' as t where t.'USBNo'=:'USBNo'";
   //Query1->ParamByName("USBNo")->AsSmallInt=10;

   Query1->Open();

   AnsiString
     tmpString;

   char
     buff[1024];

   for(Query1->First(); !Query1->Eof; Query1->Next())
   {
      tmpString=Query1->FieldByName("NAME")->AsString;
      OemToChar(tmpString.c_str(),buff);
   }

   DataSource1->DataSet=Query1;
}
//---------------------------------------------------------------------------

void __fastcall TDataBases::DataModuleDestroy(TObject *Sender)
{
   if(Query1->Active)
     Query1->Close();

   if(QuerySetGet->Active)
     QuerySetGet->Close();
}
//---------------------------------------------------------------------------
