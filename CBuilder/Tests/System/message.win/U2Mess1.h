//---------------------------------------------------------------------------

#ifndef U2Mess1H
#define U2Mess1H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
//---------------------------------------------------------------------------
class TForm2 : public TForm
{
__published:	// IDE-managed Components
        TLabel *Label1;
        TLabel *Label2;
private:	// User declarations
  void __fastcall OnClose(TWMClose &Message);
  void __fastcall OnActivate(TWMActivate &Message);
  void __fastcall OnMoving(TMessage &Message);
public:		// User declarations
        __fastcall TForm2(TComponent* Owner);
  BEGIN_MESSAGE_MAP
    MESSAGE_HANDLER(WM_CLOSE, TWMClose, OnClose)
    MESSAGE_HANDLER(WM_ACTIVATE, TWMActivate, OnActivate)
    MESSAGE_HANDLER(WM_MOVING, TMessage, OnMoving)
  END_MESSAGE_MAP(TComponent)
};
//---------------------------------------------------------------------------
extern PACKAGE TForm2 *Form2;
//---------------------------------------------------------------------------
#endif
