//---------------------------------------------------------------------------

#include <vcl.h>
#include <new>
#include <StrUtils.hpp>
#pragma hdrstop

#include "DataUnit.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

void Clone(TTable *aTableSrc, AnsiString aTableName);

TDataBases *DataBases;
//---------------------------------------------------------------------------

__fastcall TDataBases::TDataBases(TComponent* Owner):TDataModule(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TDataBases::DataModuleCreate(TObject *Sender)
{
   if(FileExists("test.dbf"))
     DeleteFile("test.dbf");

   Table1->CreateTable();
   Table1->Open();
   Table1->Append();
   Table1->FieldByName("ftInteger")->AsFloat=99999999999;
   Table1->FieldByName("ftSmallint")->AsInteger=999999;
   Table1->FieldByName("ftFloat")->AsFloat=999999999999.9999;
   Table1->FieldByName("ftBCD_0")->AsFloat=999999999999999;
   Table1->FieldByName("ftBCD_4")->AsFloat=999999999999.9999;
   Table1->FieldByName("ftBCD_9")->AsFloat=999999999999.9999;
   Table1->FieldByName("ftDate")->AsDateTime=Now();
   Table1->FieldByName("ftTime")->AsDateTime=Now();
   Table1->FieldByName("ftDateTime")->AsDateTime=Now();
   Table1->FieldByName("ftString")->AsString=AnsiString::StringOfChar('A',1024);
   Table1->Post();
   Table1->Close();
   Table1->Open();
   Table1->First();

   Table1->Close();
   Table1->TableName="polis.dbf";
   Table1->Open();
   Table1->FieldDefs->Update();
   Table1->IndexDefs->Update();
   Clone(Table1,ExtractFilePath(Application->ExeName)+"clone.dbf");

   AnsiString
     SQLBody="\
insert into \"Polis.dbf\" \
(Polis_Id, Seria, Polis_No) \
values \
(6, 'Á', 3007320)\
";

   Query1->DatabaseName=ExtractFilePath(Application->ExeName);
   Query1->SQL->Clear();
   Query1->SQL->Add(SQLBody);
   Query1->ExecSQL();

/*   SQLBody="\
insert into \"test.dbf\" \
(ftDate, ftFloat) \
values \
('05/01/1974', 13,13)\
";
   Query1->SQL->Clear();
   Query1->SQL->Add(SQLBody);
   Query1->ExecSQL();*/
}
//---------------------------------------------------------------------------

void __fastcall TDataBases::DataModuleDestroy(TObject *Sender)
{
   if(Query1->Active)
     Query1->Close();
   if(Table1->Active)
     Table1->Close();
}
//---------------------------------------------------------------------------

void Clone(TTable *aTableSrc, AnsiString aTableName)
{
   TTable
     *TableDest=0;

   try
     {
        try
          {
             TableDest=new TTable(0);

             TableDest->SessionName="Default";
             TableDest->TableType=aTableSrc->TableType;
             TableDest->DatabaseName=IncludeTrailingPathDelimiter(ExtractFilePath(aTableName));
             TableDest->TableName=ExtractFileName(aTableName);
             if(!aTableSrc->IndexName.IsEmpty())
               {
                  TableDest->IndexName=TableDest->TableName;
                  AnsiReplaceText(TableDest->IndexName,ExtractFileExt(TableDest->IndexName),ExtractFileExt(aTableSrc->IndexName));
               }

             TableDest->FieldDefs->Clear();
             TableDest->IndexDefs->Clear();

             TFieldDef
               *pNewDef;

             int
               i;

             for(i=0; i<aTableSrc->FieldDefs->Count; ++i)
                {
                   pNewDef=TableDest->FieldDefs->AddFieldDef();

                   pNewDef->Name=aTableSrc->FieldDefs->Items[i]->Name;
                   pNewDef->DataType=aTableSrc->FieldDefs->Items[i]->DataType;
                   pNewDef->Size=aTableSrc->FieldDefs->Items[i]->Size;
                   pNewDef->Required=aTableSrc->FieldDefs->Items[i]->Required;
                   pNewDef->Attributes=aTableSrc->FieldDefs->Items[i]->Attributes;
                   pNewDef->Precision=aTableSrc->FieldDefs->Items[i]->Precision;
                }

             TIndexDef
               *pNewIndexDef;

             for(i=0; i<aTableSrc->IndexDefs->Count; ++i)
                {
                   pNewIndexDef=TableDest->IndexDefs->AddIndexDef();

                   pNewIndexDef->Name=aTableSrc->IndexDefs->Items[i]->Name;
                   pNewIndexDef->Options=aTableSrc->IndexDefs->Items[i]->Options;
                   pNewIndexDef->Expression=aTableSrc->IndexDefs->Items[i]->Expression;
                   if(!aTableSrc->IndexDefs->Items[i]->Fields.IsEmpty())
                     pNewIndexDef->Fields=aTableSrc->IndexDefs->Items[i]->Fields;
                   pNewIndexDef->CaseInsFields=aTableSrc->IndexDefs->Items[i]->CaseInsFields;
                   pNewIndexDef->DescFields=aTableSrc->IndexDefs->Items[i]->DescFields;
                   pNewIndexDef->GroupingLevel=aTableSrc->IndexDefs->Items[i]->GroupingLevel;
                }

             TableDest->CreateTable();
          }
        catch(std::bad_alloc)
          {
             throw Exception("Insufficient memory");
          }
        catch(EDatabaseError &eException)
          {
             throw Exception("EDatabaseError \""+eException.Message+"\"");
          }
        catch(Exception &eException)
          {
             throw Exception("\""+eException.Message+"\"");
          }
     }
   __finally
     {
        if(TableDest)
          {
             if(TableDest->Active)
               TableDest->Close();
             delete TableDest;
          }
     }
}
//---------------------------------------------------------------------------
