//---------------------------------------------------------------------------

#include <vcl.h>
#include <DBTables.hpp>
#pragma hdrstop

//---------------------------------------------------------------------------

#pragma argsused
int main(int argc, char* argv[])
{
   TTable
     *Table=new TTable(0);

   Table->DatabaseName=ExtractFilePath(*argv)+"db\\";
   Table->TableType=ttParadox;
   Table->TableName="Test.db";
   Table->Open();
   Table->Close();
   delete Table;
   
   return 0;
}
//---------------------------------------------------------------------------
 