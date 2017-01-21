//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "hash_map.h"
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

struct AnsiHash
{
  unsigned operator()(const AnsiString& rstr) const
  {
    return  __stl_hash_string(rstr.c_str());
  }
};
//---------------------------------------------------------------------------

void __fastcall TMainForm::Button1Click(TObject *Sender)
{
  hash_map<const AnsiString, FieldHandler, AnsiHash> cases;

  cases["A"] = A;
  cases["BBB"] = B;
  cases["C"] = C;

  cases["C"]();
  cases["A"]();
  cases["BBB"]();
}
//---------------------------------------------------------------------------

void TMainForm::A()
{
    ShowMessage("TMainForm::A()");
}
//---------------------------------------------------------------------------

void TMainForm::B()
{
    ShowMessage("TMainForm::B()");
}
//---------------------------------------------------------------------------

void TMainForm::C()
{
    ShowMessage("TMainForm::C()");
}
//---------------------------------------------------------------------------
