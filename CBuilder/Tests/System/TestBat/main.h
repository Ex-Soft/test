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
        TLabeledEdit *BatchFileName;
        TBitBtn *DoItBitBtn;
        TRadioGroup *RunAs;
        TGroupBox *Parameters;
        TLabeledEdit *CountPara;
        TLabeledEdit *LengthPara;
        TRadioGroup *DoubleQuotes;
        TCheckBox *AddAppName;
        TCheckBox *QuoteAppName;
        TGroupBox *CreateProc;
        TCheckBox *UseAppName;
        TCheckBox *UseWorkPath;
        TCheckBox *AddParameters;
        TRadioGroup *TenthChar;
        void __fastcall DoItBitBtnClick(TObject *Sender);
        void __fastcall FormCreate(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TMainForm(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TMainForm *MainForm;
//---------------------------------------------------------------------------
#endif
