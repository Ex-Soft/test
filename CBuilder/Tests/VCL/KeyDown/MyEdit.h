//---------------------------------------------------------------------------

#ifndef MyEditH
#define MyEditH
//---------------------------------------------------------------------------

#include <Classes.hpp>
#include <StdCtrls.hpp>
//---------------------------------------------------------------------------

class TMyEdit : public TEdit
{
public:
  __fastcall TMyEdit(TComponent* Owner);
  void __fastcall ToggleSubClass(bool On);
  void __fastcall SubClassWndProc(Messages::TMessage &Message);
};
//---------------------------------------------------------------------------

#endif