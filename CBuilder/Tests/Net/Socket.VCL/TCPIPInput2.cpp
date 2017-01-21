//---------------------------------------------------------------------------
#include <vcl.h>
#pragma hdrstop

#include "TCPIPInput2.h"
#include "main.h"
//---------------------------------------------------------------------------

#pragma package(smart_init)
#pragma resource "*.dfm"

TPreference2 *Preference2;
//---------------------------------------------------------------------------

__fastcall TPreference2::TPreference2(TComponent* Owner)
    : TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TPreference2::BitBtn1Click(TObject *Sender)
{
   TMaskEdit *TmpTEdit=0;
   AnsiString tmp;

   EditHost->Text=EditHost->Text.Trim();
   if(!EditHost->Text.IsEmpty())
     {
        MainForm->Host=EditHost->Text;
        MainForm->IPAddress="";
        return;
     }

   for(int i=0;i<ControlCount;i++)
      {
         TmpTEdit=dynamic_cast<TMaskEdit *>(Controls[i]);
         if(TmpTEdit)
           {
              tmp=TmpTEdit->Text.Trim();
              if(tmp.IsEmpty())
                {
                   TmpTEdit->SetFocus();
                   ModalResult=mrNone;
                   return;
                }
           }
      }

    MainForm->IPAddress=IPAddress_1->Text.Trim()+"."+IPAddress_2->Text.Trim()+"."+IPAddress_3->Text.Trim()+"."+IPAddress_4->Text.Trim();
    MainForm->Host="";
}
//---------------------------------------------------------------------------

void __fastcall TPreference2::FormClose(TObject *Sender,
      TCloseAction &Action)
{
   Action=caFree;
}
//---------------------------------------------------------------------------


