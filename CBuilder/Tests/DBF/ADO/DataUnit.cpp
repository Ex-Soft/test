//---------------------------------------------------------------------------

#include <vcl.h>
#include <ComObj.hpp>
#pragma hdrstop

#include "DataUnit.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

//#define TEST_VFP

TDataBase *DataBase;
//---------------------------------------------------------------------------

__fastcall TDataBase::TDataBase(TComponent* Owner):TDataModule(Owner)
{
   #if defined(TEST_VFP)
     Provider="vfpoledb.1";
     PathToDbf=ExcludeTrailingPathDelimiter(ExtractFilePath(Application->ExeName));
     ConnectionString="Data Source="+PathToDbf;
   #else
     Provider="Microsoft.Jet.OLEDB.4.0";
     PathToDbf=ExcludeTrailingPathDelimiter(ExtractFilePath(Application->ExeName));
     ConnectionString="Data Source="+PathToDbf+";Extended Properties=dBASE IV;User ID=;Password=";
   #endif
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::DataModuleCreate(TObject *Sender)
{
   try
   {
      ADOConnectionDbf->Provider=WideString(Provider);
      ADOConnectionDbf->ConnectionString=WideString(ConnectionString);
      ADOConnectionDbf->LoginPrompt=false;

      static_cast<TCustomConnection*>(ADOConnectionDbf)->Open();
      if(ADOConnectionDbf->Connected)
      {
         ADOQueryDbf->Connection=ADOConnectionDbf;
         ADOTableDbf->Connection=ADOConnectionDbf;

         ADOQueryDbf->SQL->Text=
         #if defined(TEST_VFP)
"\
select \
  t.*, \
  t1.*, \
  t2.* \
from \
  master t \
  join det_l_I t1 on (t1.Master_ID=t.ID) \
  join det_l_II t2 on (t2.Master_ID=t.ID) \
"
         #else
"\
select \
  t.*, \
  t1.*, \
  t2.* \
from \
  (master t inner join det_l_I t1 on t1.Master_ID=t.ID) \
  inner join det_l_II t2 on t2.Master_ID=t.ID \
"
         #endif
         ;

         ADOQueryDbf->Open();
         ADOQueryDbf->Close();

         AnsiString
           TableName="TestDbf.dbf";

         if(FileExists(IncludeTrailingPathDelimiter(PathToDbf)+TableName))
           DeleteFile(IncludeTrailingPathDelimiter(PathToDbf)+TableName);

         ADOQueryDbf->SQL->Text="\
create table "+(TableName=ChangeFileExt(TableName,""))+" \
( \
   FChar varchar(254), \
   FDate date, \
   FNum_20_0 numeric(20,0), \
   FNum_18_0 numeric(18,0), \
   FNum_10_6 numeric(10,6), \
   FDec_20_0 decimal(20,0), \
   FDec_18_0 decimal(18,0), \
   FDec_10_6 decimal(10,6), \
   FLogical logical \
)";
         ADOQueryDbf->ExecSQL();

         ADOTableDbf->TableName=WideString(TableName);

         #if defined(TEST_VFP)
            ADOQueryDbf->SQL->Text="insert into "+TableName+" (FChar) values ('Line# 1 ËÈÍÈß#1 ëèíèÿ#1')";
            ADOQueryDbf->ExecSQL();
            DataSourceDbGrid->DataSet=ADOTableDbf;
            ADOTableDbf->Open();
            return;
         #endif

         ADOQueryDbf->Parameters->CreateParameter(WideString("FChar"),ftFixedChar,pdInput,254,0);
         ADOQueryDbf->Parameters->CreateParameter(WideString("FDate"),ftDate,pdInput,0,0);
         ADOQueryDbf->SQL->Text="\
insert into "+TableName+" \
(FChar, FDate, FNum_20_0, FNum_18_0, FNum_10_6, FDec_20_0, FDec_18_0, FDec_10_6) \
values \
(:FChar, :FDate, :FNum_20_0, :FNum_18_0, :FNum_10_6, :FDec_20_0, :FDec_18_0, :FDec_10_6)";

         AnsiString
           ParamName="FChar";

         TFieldType
           ft;

         if((ft=ADOQueryDbf->Parameters->ParamByName(WideString(ParamName))->DataType)!=ftFixedChar)
           ADOQueryDbf->Parameters->ParamByName(WideString(ParamName))->DataType=ftFixedChar;

         TParameterDirection
           pd;

         if((pd=ADOQueryDbf->Parameters->ParamByName(WideString(ParamName))->Direction)!=pdInput)
           ADOQueryDbf->Parameters->ParamByName(WideString(ParamName))->Direction=pdInput;

         unsigned char
           ns,
           p;

         if((ns=ADOQueryDbf->Parameters->ParamByName(WideString(ParamName))->NumericScale)!=0)
           ADOQueryDbf->Parameters->ParamByName(WideString(ParamName))->NumericScale=0;
         if((p=ADOQueryDbf->Parameters->ParamByName(WideString(ParamName))->Precision)!=0)
           ADOQueryDbf->Parameters->ParamByName(WideString(ParamName))->Precision=0;

         int
           s;

         if((s=ADOQueryDbf->Parameters->ParamByName(WideString(ParamName))->Size)!=254)
           ADOQueryDbf->Parameters->ParamByName(WideString(ParamName))->Size=254;
         ADOQueryDbf->Parameters->ParamByName(WideString(ParamName))->Value=WideString("Line# 1 ËÈÍÈß#1 ëèíèÿ#1");

         ParamName="FDate";
         if((ft=ADOQueryDbf->Parameters->ParamByName(WideString(ParamName))->DataType)!=ftDate)
           ADOQueryDbf->Parameters->ParamByName(WideString(ParamName))->DataType=ftDate;
         if((pd=ADOQueryDbf->Parameters->ParamByName(WideString(ParamName))->Direction)!=pdInput)
           ADOQueryDbf->Parameters->ParamByName(WideString(ParamName))->Direction=pdInput;
         if((ns=ADOQueryDbf->Parameters->ParamByName(WideString(ParamName))->NumericScale)!=0)
           ADOQueryDbf->Parameters->ParamByName(WideString(ParamName))->NumericScale=0;
         if((p=ADOQueryDbf->Parameters->ParamByName(WideString(ParamName))->Precision)!=0)
           ADOQueryDbf->Parameters->ParamByName(WideString(ParamName))->Precision=0;
         if((s=ADOQueryDbf->Parameters->ParamByName(WideString(ParamName))->Size)!=0)
           ADOQueryDbf->Parameters->ParamByName(WideString(ParamName))->Size=0;
         ADOQueryDbf->Parameters->ParamByName(WideString(ParamName))->Value=TDateTime().CurrentDate();

         ParamName="FNum_18_0";
         if((ft=ADOQueryDbf->Parameters->ParamByName(WideString(ParamName))->DataType)!=ftFloat)
           ADOQueryDbf->Parameters->ParamByName(WideString(ParamName))->DataType=ftFloat;
         if((pd=ADOQueryDbf->Parameters->ParamByName(WideString(ParamName))->Direction)!=pdInput)
           ADOQueryDbf->Parameters->ParamByName(WideString(ParamName))->Direction=pdInput;
         if((ns=ADOQueryDbf->Parameters->ParamByName(WideString(ParamName))->NumericScale)!=18)
           ADOQueryDbf->Parameters->ParamByName(WideString(ParamName))->NumericScale=18;
         if((p=ADOQueryDbf->Parameters->ParamByName(WideString(ParamName))->Precision)!=0)
           ADOQueryDbf->Parameters->ParamByName(WideString(ParamName))->Precision=0;
         if((s=ADOQueryDbf->Parameters->ParamByName(WideString(ParamName))->Size)!=0)
           ADOQueryDbf->Parameters->ParamByName(WideString(ParamName))->Size=0;
         ADOQueryDbf->Parameters->ParamByName(WideString(ParamName))->Value=999;

         ADOQueryDbf->ExecSQL();

         ADOQueryDbf->SQL->Text="\
select * from "+TableName;
         ADOQueryDbf->Open();

         int
           i;

         TFieldDef
           *fdp;

         AnsiString
           tmpString;

         for(i=0; i<ADOQueryDbf->FieldDefList->Count; ++i)
         {
            fdp=ADOQueryDbf->FieldDefList->FieldDefs[i];
            tmpString=fdp->Name;
         }

         ADOQueryDbf->Close();

         TableName="testt_1";
         ADOQueryDbf->SQL->Text="select * from "+TableName;
         ADOQueryDbf->Open();
         for(i=0; i<ADOQueryDbf->FieldDefList->Count; ++i)
         {
            fdp=ADOQueryDbf->FieldDefList->FieldDefs[i];
            tmpString=fdp->Name;
         }
         ADOQueryDbf->Close();

         #if !defined(TEST_VFP)
            DataSourceDbGrid->DataSet=ADOTableDbf;
            ADOTableDbf->Open();
         #endif
      }
   }
   catch(EOleException &eException)
   {
      AnsiString
        Str="EOleException: Source=\""+eException.Source+"\" ErrorCode="+IntToStr(eException.ErrorCode)+" Message=\""+eException.Message+"\"";

      ShowMessage(Str);
   }
   catch(EOleSysError &eException)
   {
      AnsiString
        Str="EOleSysError: ErrorCode="+IntToStr(eException.ErrorCode)+" Message=\""+eException.Message+"\"";

      ShowMessage(Str);
   }
   catch(EOleError &eException)
   {
      AnsiString
        Str="EOleError: Message=\""+eException.Message+"\"";

      ShowMessage(Str);
   }
   catch(EDatabaseError &eException)
   {
      AnsiString
        Str="EDatabaseError: Message=\""+eException.Message+"\"";

      ShowMessage(Str);
   }
   catch(Exception &eException)
   {
      AnsiString
        Str="Exception: Message=\""+eException.Message+"\"";

      ShowMessage(Str);
   }
}
//---------------------------------------------------------------------------

void __fastcall TDataBase::DataModuleDestroy(TObject *Sender)
{
   try
   {
      if(ADOTableDbf->Active)
        ADOTableDbf->Close();

      if(ADOQueryDbf->Active)
        ADOQueryDbf->Close();

      if(ADOConnectionDbf->Connected)
        ADOConnectionDbf->Close();
   }
   catch(EOleException &eException)
   {
      AnsiString
        Str="Source=\""+eException.Source+"\" ErrorCode="+IntToStr(eException.ErrorCode)+" Message=\""+eException.Message+"\"";

      ShowMessage(Str);
   }
}
//---------------------------------------------------------------------------
