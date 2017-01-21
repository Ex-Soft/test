//---------------------------------------------------------------------------

#ifndef mainH
#define mainH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Menus.hpp>
//---------------------------------------------------------------------------
class TTestForm : public TForm
{
__published:	// IDE-managed Components
        TMainMenu *MainMenu1;
        TMenuItem *Test1;
        TMenuItem *Testprint1;
        TMenuItem *Testmail1;
        TMenuItem *N1;
        TMenuItem *Exit1;
        void __fastcall Testprint1Click(TObject *Sender);
        void __fastcall Exit1Click(TObject *Sender);
        void __fastcall Testmail1Click(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TTestForm(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TTestForm *TestForm;
//---------------------------------------------------------------------------
#endif
