//---------------------------------------------------------------------------

#ifndef MainUnitH
#define MainUnitH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Menus.hpp>
//---------------------------------------------------------------------------
class TTestDllForm : public TForm
{
__published:	// IDE-managed Components
        TMainMenu *MainMenu1;
        TMenuItem *TestDll;
        TMenuItem *TestPrint;
        TMenuItem *TestMail;
        TMenuItem *N1;
        TMenuItem *Exit1;
        void __fastcall Exit1Click(TObject *Sender);
        void __fastcall TestPrintClick(TObject *Sender);
        void __fastcall TestMailClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TTestDllForm(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TTestDllForm *TestDllForm;
//---------------------------------------------------------------------------
#endif
