//---------------------------------------------------------------------------

#include <vcl.h>
#include <fstream>
#pragma hdrstop

#include "main.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormCreate(TObject *Sender)
{
   BatchFileName->Text=ExtractFilePath(Application->ExeName)+"Bat.Bat";
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::DoItBitBtnClick(TObject *Sender)
{
   TLabeledEdit
     *pLabeledEdit;

   int
     i;

   for(i=0; i<ControlCount; i++)
      if(pLabeledEdit=dynamic_cast<TLabeledEdit *>(Controls[i]))
        {
          pLabeledEdit->Text=pLabeledEdit->Text.Trim();
          if(pLabeledEdit->Text.IsEmpty())
            {
               pLabeledEdit->SetFocus();
               return;
            }
        }

   AnsiString
     StrPara="";

   int
     CountParam=StrToIntDef(CountPara->Text,0);

   for(i=1; i<=CountParam; i++)
      {
         if(!StrPara.IsEmpty())
           StrPara+=" ";

         if(DoubleQuotes->ItemIndex)
           StrPara+="\"";

         if(AddParameters->Checked)
           StrPara+="-parameter"+IntToStr(i)+":";

         if(!DoubleQuotes->ItemIndex)
           StrPara+="\"";

         int
           LenParam=StrToIntDef(LengthPara->Text,0);

         for(int l=1,symb=0; l<=LenParam; l++, symb++)
            {
               if(symb!=9)
                 StrPara+=char('1'+symb);
               else
                 {
                    StrPara+=!TenthChar->ItemIndex?" ":"0";
                    symb=-1;
                 }
            }

         StrPara+="\"";
      }

   AnsiString
     MainBatchFileName=ExtractFilePath(Application->ExeName)+"MainBat.Bat";

   if(RunAs->ItemIndex)
     {
        std::fstream
          File;

        File.open(MainBatchFileName.c_str(),std::ios_base::out|std::ios_base::trunc);
        if(!File.good())
          return;

        File<<"@echo off"<<std::endl;
        File<<"call \""<<BatchFileName->Text.c_str()<<"\"";
        if(!StrPara.IsEmpty())
          File<<" "<<StrPara.c_str();

        File.close();
     }

   STARTUPINFO sinfo;
   PROCESS_INFORMATION pinfo;
   memset(&pinfo,0,sizeof(pinfo));
   memset(&sinfo,0,sizeof(sinfo));
   sinfo.cb=sizeof(sinfo);

   AnsiString
     AppName=!RunAs->ItemIndex?BatchFileName->Text:ExtractFilePath(Application->ExeName)+"MainBat.Bat",
     WorkDir=ExcludeTrailingPathDelimiter(ExtractFilePath(AppName)),
     Parameters=!RunAs->ItemIndex?StrPara:AnsiString("");

   if(AddAppName->Checked)
     if(QuoteAppName->Checked)
       Parameters="\""+AppName+"\" "+StrPara;
     else
       Parameters=AppName+" "+StrPara;

   if(!CreateProcess(UseAppName->Checked?AppName.c_str():0,Parameters.c_str(),0,0,false,0,0,UseWorkPath->Checked?WorkDir.c_str():0,&sinfo,&pinfo))
     {
        AppName="Can't run: \""+AppName+"\"\r\nError #"+IntToStr(GetLastError());
        Application->MessageBox(AppName.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }

   AppName=ExtractFilePath(Application->ExeName)+"Params\\Params.exe";
   Parameters="\""+AppName+"\" \""+ExtractFilePath(Application->ExeName)+"Params\\Params.par\" "+StrPara;
   if(!CreateProcess(AppName.c_str(),Parameters.c_str(),0,0,false,0,0,WorkDir.c_str(),&sinfo,&pinfo))
     {
        AppName="Can't run: \""+AppName+"\"\r\nError #"+IntToStr(GetLastError());
        Application->MessageBox(AppName.c_str(),Application->Title.c_str(),MB_ICONERROR|MB_OK);
        return;
     }
}
//---------------------------------------------------------------------------

