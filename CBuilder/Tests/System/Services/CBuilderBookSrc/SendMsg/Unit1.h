//---------------------------------------------------------------------------
#ifndef Unit1H
#define Unit1H
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Buttons.hpp>
#include <ScktComp.hpp>
//---------------------------------------------------------------------------
class TForm1 : public TForm
{
__published:	// IDE-managed Components
   TClientSocket *ClientSocket1;
   TEdit *Edit1;
   TLabel *Label1;
   TMemo *Memo1;
        TBitBtn *SendButton;
   void __fastcall SendButtonClick(TObject *Sender);
   void __fastcall ClientSocket1Write(TObject *Sender,
          TCustomWinSocket *Socket);
private:	// User declarations
public:		// User declarations
   __fastcall TForm1(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif
 