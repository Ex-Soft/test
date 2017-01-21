//---------------------------------------------------------------------------

#ifndef mainH
#define mainH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Buttons.hpp>
#include <ExtCtrls.hpp>
//---------------------------------------------------------------------------
class TMainForm : public TForm
{
__published:	// IDE-managed Components
        TBitBtn *DoItBitBtn;
        TGroupBox *ActionGroupBox;
        TCheckBox *LoadLibraryCheckBox;
        TCheckBox *InitializePointerCheckBox;
        TCheckBox *CallFunctionCheckBox;
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall DoItBitBtnClick(TObject *Sender);
        void __fastcall LoadLibraryCheckBoxClick(TObject *Sender);
        void __fastcall InitializePointerCheckBoxClick(TObject *Sender);
        void __fastcall CallFunctionCheckBoxClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TMainForm(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TMainForm *MainForm;
//---------------------------------------------------------------------------
#endif
