//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "frmMainU.h"
#include "typinfo.hpp"
#include "typeinfo.h"
#include "IBScript.hpp"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma link "IBScript"
#pragma resource "*.dfm"
TfrmMain *frmMain;
//---------------------------------------------------------------------------
__fastcall TfrmMain::TfrmMain(TComponent* Owner)
  : TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TfrmMain::IBScript1Parse(TObject *Sender, TIBParseKind AKind,
      AnsiString SQLText)
{
  AnsiString s;
  switch (AKind)
  {
    case Ibscript::stmtDDL : s = "stmtDDL"; break;
    case Ibscript::stmtDML : s = "stmtDML"; break;
    case Ibscript::stmtSET : s = "stmtSET"; break;
    case Ibscript::stmtCONNECT : s = "stmtCONNECT"; break;
    case Ibscript::stmtDrop : s = "stmtDrop"; break;
    case Ibscript::stmtCREATE : s = "stmtCREATE"; break;
    case Ibscript::stmtINPUT : s = "stmtINPUT"; break;
    case Ibscript::stmtUNK : s = "stmtUNK"; break;
	  case Ibscript::stmtEMPTY : s = "stmtEMPTY"; break;
    case Ibscript::stmtTERM : s = "stmtTERM"; break;
    case Ibscript::stmtERR : s = "stmtERR"; break;
    case Ibscript::stmtCOMMIT : s = "stmtCOMMIT"; break;
    case Ibscript::stmtROLLBACK : s = "stmtROLLBACK"; break;
  }
  Memo2->Lines->Add("Processed Statement " + s);
  Memo2->Lines->Add(SQLText);
  Memo2->Lines->Add("");
  IBScript1->Paused = chkPause->Checked;
}
//---------------------------------------------------------------------------
void __fastcall TfrmMain::IBScript1ParseError(TObject *Sender,
      AnsiString Error, AnsiString SQLText, int LineIndex)
{
  Memo3->Lines->Add("Error Line # " + IntToStr(LineIndex));
  Memo3->Lines->Add(SQLText);
  Memo3->Lines->Add("");
  IBScript1->Paused = chkPause->Checked;
}
//---------------------------------------------------------------------------
void __fastcall TfrmMain::Button5Click(TObject *Sender)
{
  IBScript1->Script = Memo1->Lines;
  if (IBScript1->ValidateScript())
    ShowMessage("Valid");
  else
    ShowMessage("Invalid");
}
//---------------------------------------------------------------------------
void __fastcall TfrmMain::Button4Click(TObject *Sender)
{
  IBScript1->Script = Memo1->Lines;
  IBScript1->ExecuteScript();

}
//---------------------------------------------------------------------------
void __fastcall TfrmMain::Button2Click(TObject *Sender)
{
  if (OpenDialog1->Execute())
    Memo1->Lines->LoadFromFile(OpenDialog1->FileName);
}
//---------------------------------------------------------------------------
void __fastcall TfrmMain::Button1Click(TObject *Sender)
{
  Memo2->Clear();
  Memo3->Clear();
  IBScript1->Script = Memo1->Lines;
  IBScript1->ValidateScript();
}
//---------------------------------------------------------------------------
void __fastcall TfrmMain::PausedUpdate(TObject *Sender)
{
  (dynamic_cast<TAction *> (Sender))->Enabled = IBScript1->Paused;
}
//---------------------------------------------------------------------------
void __fastcall TfrmMain::PausedExecute(TObject *Sender)
{
  IBScript1->Paused = false;
}
//---------------------------------------------------------------------------
