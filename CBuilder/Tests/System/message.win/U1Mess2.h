//---------------------------------------------------------------------------

#ifndef U1Mess2H
#define U1Mess2H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
//---------------------------------------------------------------------------
class TForm1 : public TForm
{
__published:	// IDE-managed Components
        TLabel *Label1;
        TLabel *Label2;
private:	// User declarations
  void __fastcall OnClose(TWMClose &Message);
  void __fastcall OnKeyDown(TWMKeyDown &Message);
  void __fastcall OnMoving(TMessage &Message);
public:		// User declarations
        __fastcall TForm1(TComponent* Owner);
  BEGIN_MESSAGE_MAP
    MESSAGE_HANDLER(WM_CLOSE, TWMClose, OnClose)
    MESSAGE_HANDLER(WM_KEYDOWN, TWMKeyDown, OnKeyDown)
    MESSAGE_HANDLER(WM_MOVING, TMessage, OnMoving)
  END_MESSAGE_MAP(TComponent)
};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif
