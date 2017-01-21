//---------------------------------------------------------------------------

#ifndef mainH
#define mainH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <ComCtrls.hpp>
#include <Controls.hpp>
#include <ExtCtrls.hpp>
#include <StdCtrls.hpp>
#include <Buttons.hpp>
//---------------------------------------------------------------------------
class TMainForm : public TForm
{
__published:	// IDE-managed Components
        TPageControl *PageControl;
        TTabSheet *TabSheetIdCoderMD5;
        TLabeledEdit *LabeledEditInput;
        TLabeledEdit *LabeledEditOutput;
        TBitBtn *BitBtnGenerate;
        TCheckBox *CheckBoxAutoCompleteInput;
        TLabeledEdit *LabeledEditKey;
        void __fastcall BitBtnGenerateClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TMainForm(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TMainForm *MainForm;
//---------------------------------------------------------------------------
#endif
