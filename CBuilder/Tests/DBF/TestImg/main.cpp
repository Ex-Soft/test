//---------------------------------------------------------------------------

#include <vcl.h>
//#include <DB.hpp>
#include <DBTables.hpp>
#pragma hdrstop

//---------------------------------------------------------------------------

#pragma argsused
int main(int argc, char* argv[])
{
   TTable
     *DbfTable=new TTable(0);

   DbfTable->DatabaseName="e:\\fpd26\\dbf\\";
   DbfTable->TableName="TestImg.dbf";
   DbfTable->TableType=ttFoxPro;
   //DbfTable->TableType=ttDBase;

   DbfTable->Open();

   AnsiString
     tmpAnsiString;

   for(int i=0; i<DbfTable->FieldCount; ++i)
   {
      if(!tmpAnsiString.IsEmpty())
        tmpAnsiString+="\r\n";

      tmpAnsiString+=DbfTable->Fields->Fields[i]->FieldName+" "+IntToStr(DbfTable->Fields->Fields[i]->DataType);
   }
   ShowMessage(tmpAnsiString);

   DbfTable->Append();
   DbfTable->FieldByName("ID")->AsInteger=1;

   TBlobField
     *BlobField;

   if(BlobField=dynamic_cast<TBlobField *>(DbfTable->FieldByName("IMG")))
   {
      BlobField->LoadFromFile(ExtractFilePath(Application->ExeName)+"xpfirewall.bmp");
   }

   TBinaryField
     *BinaryField;

   if(BinaryField=dynamic_cast<TBinaryField *>(DbfTable->FieldByName("IMG")))
   {
   }

   TGraphicField
     *GraphicField;

   if(GraphicField=dynamic_cast<TGraphicField *>(DbfTable->FieldByName("IMG")))
   {
   }

   DbfTable->Post();

   DbfTable->First();
   if(BlobField=dynamic_cast<TBlobField *>(DbfTable->FieldByName("IMG")))
   {
      BlobField->SaveToFile(ExtractFilePath(Application->ExeName)+"xpfirewall_out.bmp");
   }

   DbfTable->Close();

   delete DbfTable;

   return(0);
}
//---------------------------------------------------------------------------
