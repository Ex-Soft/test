//---------------------------------------------------------------------------

#include <vcl.h>
#include <io.h>
#include <fcntl.h>
#include <sys\stat.h>
#pragma hdrstop

#include "main.h"
#include "DataUnit.h"
//---------------------------------------------------------------------------

#pragma package(smart_init)
#pragma resource "*.dfm"

extern bool __fastcall Access2File(AnsiString FileName);

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner)
        : TForm(Owner)
{
   handle=-1;
   f_ptr=NULL;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::OpenBitBtnClick(TObject *Sender)
{
   Timer1->Enabled=false;

   if(DataBases->TestTable->Active)
     CloseBitBtnClick(Sender);

   OpenFileDialog->Title="Select DataBase";
   OpenFileDialog->Filter="dBase Files (*.dbf)|*.dbf|Paradox Files (*.db)|*.db|All Files (*.*)|*.*";
   OpenFileDialog->FilterIndex=1;
   OpenFileDialog->DefaultExt="*.dbf";
   OpenFileDialog->InitialDir=ExtractFilePath(Application->ExeName);
   if(OpenFileDialog->Execute())
     {
        DataBaseName->Caption=OpenFileDialog->FileName;
        DataBases->TestTable->DatabaseName=ExtractFilePath(OpenFileDialog->FileName);
        DataBases->TestTable->TableName=ExtractFileName(OpenFileDialog->FileName);
        if(ExtractFileExt(OpenFileDialog->FileName).LowerCase()==".dbf")
          DataBases->TestTable->TableType=ttFoxPro;
        else if(ExtractFileExt(OpenFileDialog->FileName).LowerCase()==".db")
               DataBases->TestTable->TableType=ttParadox;
             else
               DataBases->TestTable->TableType=ttDefault;

        DataBases->TestTable->Open();
        if(!DataBases->TestTable->Active)
          return;

        DataBases->TestTable->First();

        CloseBitBtn->Enabled=true;

        LockReadBitBtn->Enabled=true;
        LockWriteBitBtn->Enabled=true;

        ViewFieldBitBtn->Enabled=true;
        SetFieldBitBtn->Enabled=true;

        Timer1->Enabled=true;
     }
   else
     return;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ViewFieldBitBtnClick(TObject *Sender)
{
   if(UseSQLToSet->Checked)
     {
        AnsiString SQLBody="select a from \'"+DataBases->TestTable->DatabaseName+DataBases->TestTable->TableName+"\'";

        DataBases->Query->SQL->Clear();
        DataBases->Query->SQL->Add(SQLBody);
        try
          {
             DataBases->Query->Open();
             FieldsValue->Caption=DataBases->Query->FieldByName("A")->AsString;
             DataBases->Query->Close();
          }
        catch(EDatabaseError &eException)
          {
             ShowMessage(eException.Message);
          }
     }
   else
     {
        if(!DataBases->TestTable->Active)
          return;

        DataBases->TestTable->Refresh();
        FieldsValue->Caption=DataBases->TestTable->FieldByName("A")->AsString;
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::SetFieldBitBtnClick(TObject *Sender)
{
   if(UseSQLToSet->Checked)
     {
        AnsiString SQLBody="update \'"+DataBases->TestTable->DatabaseName+DataBases->TestTable->TableName+"\' set A= :NewValue";

        DataBases->Query->SQL->Clear();
        DataBases->Query->SQL->Add(SQLBody);

        if(!DataBases->Query->Prepared)
          DataBases->Query->Prepare();
        if(NewValue->Text.LowerCase()=="null")
          {
             DataBases->Query->ParamByName("NewValue")->Bound=true;
             DataBases->Query->ParamByName("NewValue")->Clear();
             DataBases->Query->ParamByName("NewValue")->Bound=true;
             DataBases->Query->ParamByName("NewValue")->Value=NULL;
          }
        else
          DataBases->Query->ParamByName("NewValue")->AsString=NewValue->Text.Trim();

        try
          {
             DataBases->Query->ExecSQL();
          }
        catch(EDatabaseError &eException)
          {
             ShowMessage(eException.Message);
          }
     }
   else
     {
        if(!DataBases->TestTable->Active)
          return;

        DataBases->TestTable->Edit();
        DataBases->TestTable->FieldByName("A")->AsString=NewValue->Text.Trim();
        DataBases->TestTable->Post();
        DataBases->TestTable->FlushBuffers();
     }
   NewValue->Text="";
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::LockReadBitBtnClick(TObject *Sender)
{
   if(!DataBases->TestTable->Active)
     return;

   DataBases->TestTable->LockTable(ltReadLock);
   LockReadBitBtn->Enabled=false;
   UnLockReadBitBtn->Enabled=true;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::UnLockReadBitBtnClick(TObject *Sender)
{
   if(!DataBases->TestTable->Active)
     return;

   DataBases->TestTable->UnlockTable(ltReadLock);
   UnLockReadBitBtn->Enabled=false;
   LockReadBitBtn->Enabled=true;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::LockWriteBitBtnClick(TObject *Sender)
{
   if(!DataBases->TestTable->Active)
     return;

   DataBases->TestTable->LockTable(ltWriteLock);
   LockWriteBitBtn->Enabled=false;
   UnLockWriteBitBtn->Enabled=true;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::UnLockWriteBitBtnClick(TObject *Sender)
{
   if(!DataBases->TestTable->Active)
     return;

   DataBases->TestTable->UnlockTable(ltWriteLock);
   UnLockWriteBitBtn->Enabled=false;
   LockWriteBitBtn->Enabled=true;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::Timer1Timer(TObject *Sender)
{
   static unsigned long i=0;

   if(!DataBases->TestTable->Active)
     return;

   i++;
   DataBases->TestTable->Refresh();

   if(DataBases->TestTable->Exclusive)
     {
        Exclusive->Caption="True - "+IntToStr(i);
        Exclusive->Font->Color=clRed;
     }
   else
     {
        Exclusive->Caption="False - "+IntToStr(i);
        Exclusive->Font->Color=clBlack;
     }

   if(DataBases->TestTable->CanModify)
     {
        CanModify->Caption="True - "+IntToStr(i);
        CanModify->Font->Color=clRed;
     }
   else
     {
        CanModify->Caption="False - "+IntToStr(i);
        CanModify->Font->Color=clBlack;
     }

   if(DataBases->TestTable->ReadOnly)
     {
        ReadOnly->Caption="True - "+IntToStr(i);
        ReadOnly->Font->Color=clRed;
     }
   else
     {
        ReadOnly->Caption="False - "+IntToStr(i);
        ReadOnly->Font->Color=clBlack;
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::openFileBitBtnClick(TObject *Sender)
{
   if(handle!=-1)
     close(handle);

   openFileName->Caption="";
   OpenFileDialog->Title="Select Any File";
   OpenFileDialog->Filter="dBase Files (*.dbf)|*.dbf|Paradox Files (*.db)|*.db|All Files (*.*)|*.*";
   OpenFileDialog->FilterIndex=3;
   OpenFileDialog->DefaultExt="*.*";
   OpenFileDialog->InitialDir=ExtractFilePath(Application->ExeName);
   if(OpenFileDialog->Execute())
     {
        openFileName->Caption=OpenFileDialog->FileName;
        handle=open(openFileName->Caption.c_str(),O_RDWR|O_BINARY,S_IREAD|S_IWRITE);
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::fopenFileBitBtnClick(TObject *Sender)
{
   if(f_ptr)
     fclose(f_ptr);

   fopenFileName->Caption="";
   OpenFileDialog->Title="Select Any File";
   OpenFileDialog->Filter="dBase Files (*.dbf)|*.dbf|Paradox Files (*.db)|*.db|All Files (*.*)|*.*";
   OpenFileDialog->FilterIndex=3;
   OpenFileDialog->DefaultExt="*.*";
   OpenFileDialog->InitialDir=ExtractFilePath(Application->ExeName);
   if(OpenFileDialog->Execute())
     {
        fopenFileName->Caption=OpenFileDialog->FileName;
        f_ptr=fopen(fopenFileName->Caption.c_str(),"r+b");
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::fstreamopenBitBtnClick(TObject *Sender)
{
   if(f_file.is_open())
     f_file.close();

   fstreamopenFileName->Caption="";
   OpenFileDialog->Title="Select Any File";
   OpenFileDialog->Filter="dBase Files (*.dbf)|*.dbf|Paradox Files (*.db)|*.db|All Files (*.*)|*.*";
   OpenFileDialog->FilterIndex=3;
   OpenFileDialog->DefaultExt="*.*";
   OpenFileDialog->InitialDir=ExtractFilePath(Application->ExeName);
   if(OpenFileDialog->Execute())
     {
        fstreamopenFileName->Caption=OpenFileDialog->FileName;
        f_file.open(fopenFileName->Caption.c_str(),ios::binary|ios::in|ios::out);
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::AccessFileNameBitBtnClick(TObject *Sender)
{
   AccessFileName->Caption="";
   OpenFileDialog->Title="Select Any File";
   OpenFileDialog->Filter="dBase Files (*.dbf)|*.dbf|Paradox Files (*.db)|*.db|All Files (*.*)|*.*";
   OpenFileDialog->FilterIndex=3;
   OpenFileDialog->DefaultExt="*.*";
   OpenFileDialog->InitialDir=ExtractFilePath(Application->ExeName);
   if(OpenFileDialog->Execute())
     {
        AccessFileName->Caption=OpenFileDialog->FileName;
        AccessToFile->Caption=IntToStr(access(AccessFileName->Caption.c_str(),6));
        if(Access2File(AccessFileName->Caption))
          MyAccess->Caption="True";
        else
          MyAccess->Caption="False";
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormClose(TObject *Sender, TCloseAction &Action)
{
   if(handle!=-1)
     close(handle);
   if(f_ptr)
     fclose(f_ptr);
   if(f_file.is_open())
     f_file.close();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::CloseBitBtnClick(TObject *Sender)
{
   if(DataBases->TestTable->Active)
     DataBases->TestTable->Close();
   if(DataBases->Query->Active)
     DataBases->Query->Close();

   Exclusive->Caption="";
   CanModify->Caption="";
   ReadOnly->Caption="";

   CloseBitBtn->Enabled=false;

   LockReadBitBtn->Enabled=false;
   UnLockReadBitBtn->Enabled=false;
   LockWriteBitBtn->Enabled=false;
   UnLockWriteBitBtn->Enabled=false;

   FieldsValue->Caption="";
   ViewFieldBitBtn->Enabled=false;
   SetFieldBitBtn->Enabled=false;
}
//---------------------------------------------------------------------------

