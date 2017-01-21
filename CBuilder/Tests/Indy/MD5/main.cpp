//---------------------------------------------------------------------------

#include <vcl.h>
#include <new>
#include <IdBaseComponent.hpp>
#include <IdCoder.hpp>
#include <IdCoderMessageDigest.hpp>
#pragma hdrstop

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

void __fastcall TMainForm::BitBtnGenerateClick(TObject *Sender)
{
   TIdCoderMD5 *IdCoderMD51 = 0;

   try
     {
        try
          {
             IdCoderMD51 = new TIdCoderMD5(0);
          }
        catch(std::bad_alloc)
          {
             throw Exception(ExtractFileName(__FILE__)+"("+__LINE__+"): Insufficient memory");
          }

        IdCoderMD51->AutoCompleteInput = CheckBoxAutoCompleteInput->Checked;
        IdCoderMD51->Reset();
        IdCoderMD51->SetKey( FloatToStrF( LabeledEditKey->Text.ToIntDef(0), ffFixed, 18, 0) );
        AnsiString Temp = IdCoderMD51->CodeString(LabeledEditInput->Text);
        AnsiString CodedPass="";

        for(int i = 1; i < Temp.Length(); i++)
           CodedPass = CodedPass + IntToHex( abs( int(Temp[i]) ), 2);

        LabeledEditOutput->Text = CodedPass;
     }
   __finally
     {
        if(IdCoderMD51)
          delete IdCoderMD51;
     }
}
//---------------------------------------------------------------------------

