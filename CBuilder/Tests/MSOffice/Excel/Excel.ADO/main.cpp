//---------------------------------------------------------------------------

#include <vcl.h>
#include <ComObj.hpp>
#include <ADODB.hpp>
#include <OleCtrls.hpp>
#pragma hdrstop
//---------------------------------------------------------------------------

#pragma alias "@System@@CheckAutoResult$qqrv"="@System@@CheckAutoResult$qqrl"

#pragma argsused
int main(int argc, char* argv[])
{
   HRESULT
     hRes=CoInitialize(0);

   int
     tmpInt;

   AnsiString
     tmpAnsiString;

   if(hRes!=S_OK && hRes!=S_FALSE)
   {
      tmpInt=GetLastError();
      ShowMessage("Can\'t initialize the OLE library (ErrorNo: "+IntToStr(tmpInt)+" Message: \""+SysErrorMessage(tmpInt)+"\"");
      return(-1);
   }

   TADOConnection
     *ADOConnection=new TADOConnection(0);

   TADOQuery
     *ADOQuery=new TADOQuery(0);

   ADOConnection->Provider=WideString("Microsoft.Jet.OLEDB.4.0");
   ADOConnection->ConnectionString=WideString("Data Source="+ExtractFilePath(Application->ExeName)+"test.xls;Extended Properties='Excel 8.0;HDR=No;IMEX=1'");
   ADOConnection->LoginPrompt=false;

   static_cast<TCustomConnection*>(ADOConnection)->Open();
   if(ADOConnection->Connected)
   {
      TADODataSet
        *ADODataSet=new TADODataSet(0);

      ADOConnection->OpenSchema(siTables, EmptyParam, EmptyParam, ADODataSet);

      TFieldDef
        *FieldDef;

      for(int i=0; i<ADODataSet->FieldDefList->Count; ++i)
         FieldDef=ADODataSet->FieldDefList->FieldDefs[i];

      for(ADODataSet->First();!ADODataSet->Eof; ADODataSet->Next())
         tmpAnsiString=ADODataSet->FieldByName("TABLE_NAME")->AsString;

      ADODataSet->Close();
      delete ADODataSet;

      TStrings
        *SL=new TStringList;

      ADOConnection->GetTableNames(SL,false);
      for(int i=0; i<SL->Count; ++i)
         tmpAnsiString=SL->Strings[i];
         
      ADOQuery->Connection=ADOConnection;

      ADOQuery->SQL->Text="select * from [Ëèñò1$]";
      //ADOQuery->SQL->Text="select * from [Ëèñò1$A1]";
      //ADOQuery->SQL->Text="select * from [Ëèñò1$A1:B10]";

      try
      {
         ADOQuery->Open();

         int
           i;

         TFieldDef
           *FieldDef;

         for(i=0; i<ADOQuery->FieldDefList->Count; ++i)
            FieldDef=ADOQuery->FieldDefList->FieldDefs[i];

         //for(i=0; i<ADOQuery->FieldDefs->Count; ++i)
         //   FieldDef=ADOQuery->FieldDefs->Items[i];

         TField
           *Field;

         for(i=0; i<ADOQuery->FieldList->Count; ++i)
            Field=ADOQuery->FieldList->Fields[i];

         for(i=0; i<ADOQuery->Fields->Count; ++i)
            Field=ADOQuery->Fields->Fields[i];

         for(ADOQuery->First(); !ADOQuery->Eof; ADOQuery->Next())
            tmpAnsiString="F1="+FloatToStr(ADOQuery->FieldByName("F1")->AsFloat)+" F2="+FloatToStr(ADOQuery->FieldByName("F2")->AsFloat);

         ADOQuery->Close();

         ADOQuery->SQL->Text="insert into [Ëèñò1$] (F3,F4) values (11,121)";
         ADOQuery->ExecSQL();
      }
      catch(EOleException &eException)
      {
         ShowMessage("Error code "+IntToStr(eException.ErrorCode)+" == \""+eException.Message+"\"");
      }

      if(ADOQuery->Active)
        ADOQuery->Close();

      ADOConnection->Close();
   }

   if(ADOQuery)
     delete ADOQuery;

   if(ADOConnection)
     delete ADOConnection;

   CoUninitialize();

   return(0);
}
//---------------------------------------------------------------------------
