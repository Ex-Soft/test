//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "main.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{
   //MediaPlayer1->DeviceType=dtAutoSelect;
   //MediaPlayer1->AutoOpen=true;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormCreate(TObject *Sender)
{
   ListBox1->Items->Add(ExtractFilePath(Application->ExeName)+"Dr.Aleksandrov-StopNarcotics.mp3");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ListBox1Click(TObject *Sender)
{
   if(ListBox1->ItemIndex>=0)
   {
      MediaPlayer1->FileName=ListBox1->Items->Strings[ListBox1->ItemIndex];
      MediaPlayer1->Open();
      try
      {
         MediaPlayer1->Play();
      }
      catch(EMCIDeviceError &eException)
      {
         ShowMessage(eException.Message);
      }
   }
}
//---------------------------------------------------------------------------

