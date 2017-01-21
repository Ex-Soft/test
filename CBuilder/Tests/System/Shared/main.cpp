//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include <lmshare.h>
#include <dir.h>
#include <lmapibuf.h>
//#include <svrapi.h>
#include "main.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner)
        : TForm(Owner)
{
}

//---------------------------------------------------------------------------

void __fastcall TMainForm::Button1Click(TObject *Sender)
{
   SHARE_INFO_0 *si0;
   wchar_t ServerName[MAXPATH];
   wchar_t NetName[MAXPATH];

   StringToWideChar(Edit1->Text.c_str(),ServerName,MAXPATH);
   StringToWideChar(Edit2->Text.c_str(),NetName,MAXPATH);

   int z=NetShareGetInfo(ServerName,NetName,0,(LPBYTE *)&si0);
   if(z==0)
     {
        StaticText1->Caption=si0->shi0_netname;
        NetApiBufferFree(&si0);
        Edit1->SelectAll();
     }
   else
     StaticText1->Caption = "?";
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::Button2Click(TObject *Sender)
{
   SHARE_INFO_1 *si1;
   wchar_t ServerName[MAXPATH];
   wchar_t NetName[MAXPATH];

   StringToWideChar(Edit1->Text.c_str(),ServerName,MAXPATH);
   StringToWideChar(Edit2->Text.c_str(),NetName,MAXPATH);

   int z=NetShareGetInfo(ServerName,NetName,1,(LPBYTE *)&si1);
   if(z==0)
     {
        StaticText1->Caption=si1->shi1_netname;
        switch(si1->shi1_type)
          {
             case STYPE_DISKTREE: {
                                     StaticText1->Caption=StaticText1->Caption+" Disk drive";
                                     break;
                                  }
             case STYPE_PRINTQ:   {
                                     StaticText1->Caption=StaticText1->Caption+" Print queue";
                                     break;
                                  }
             case STYPE_DEVICE:   {
                                     StaticText1->Caption=StaticText1->Caption+" Communication device";
                                     break;
                                  }
             case STYPE_IPC:      {
                                     StaticText1->Caption=StaticText1->Caption+" Interprocess Communication (IPC)";
                                     break;
                                  }
             default:             {
                                     StaticText1->Caption=StaticText1->Caption+" ?";
                                     break;
                                  }
          }
        StaticText1->Caption=StaticText1->Caption+" ";
        StaticText1->Caption=StaticText1->Caption+si1->shi1_remark;
        NetApiBufferFree(&si1);
        Edit1->SelectAll();
     }
   else
     StaticText1->Caption = "?";
}
//---------------------------------------------------------------------------

