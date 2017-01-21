//---------------------------------------------------------------------------

#include <vcl.h>
#include <iostream>
#include <IBDatabase.hpp>
#include <IBSQL.hpp>
#pragma hdrstop

//---------------------------------------------------------------------------

using namespace std;

#pragma argsused
int main(int argc, char* argv[])
{
   if(argc<4)
   {
      cout<<"Usage: TestBlob <database> <user> <password>"<<endl;
      return(0);
   }

   auto_ptr<TIBDatabase> GDB(new TIBDatabase(0));
   auto_ptr<TIBTransaction> Tr(new TIBTransaction(0));
   auto_ptr<TIBSQL> IBSQL(new TIBSQL(0));

   GDB->DatabaseName=*(argv+1);
   GDB->LoginPrompt=false;
   GDB->DefaultTransaction=Tr.get();
   GDB->Params->Clear();
   GDB->Params->Add("user_name="+AnsiString(*(argv+2)));
   GDB->Params->Add("password="+AnsiString(*(argv+3)));
   GDB->Params->Add("lc_ctype=WIN1251");

   Tr->DefaultDatabase=GDB.get();
   Tr->Params->Clear();
   Tr->Params->Add("nowait");
   Tr->Params->Add("read_committed");
   Tr->Params->Add("rec_version");

   IBSQL->Database=GDB.get();
   IBSQL->Transaction=Tr.get();

   try
   {
      GDB->Open();
   }
   catch(EIBError &eException)
   {
      cout<<"Can\'t open database \""<<GDB->DatabaseName.c_str()<<"\"\nInterBase error #: "<<eException.IBErrorCode<<"\nSQLCode: "<<eException.SQLCode<<"\nMessage: "<<eException.Message.c_str()<<endl;
      return(-1);
   }

   AnsiString
     FileName;

   if(FileExists(FileName=ExtractFilePath(*argv)+"FromBLOB.bmp"))
     DeleteFile(FileName);

   IBSQL->SQL->Text="select * from \"TestDataTypes\"";
   Tr->StartTransaction();
   IBSQL->ExecQuery();
   if(!IBSQL->FieldByName("CBlob")->IsNull)
     IBSQL->FieldByName("CBlob")->SaveToFile(FileName);
   IBSQL->Close();
   Tr->Rollback();

   GDB->Close();
   return 0;
}
//---------------------------------------------------------------------------
 