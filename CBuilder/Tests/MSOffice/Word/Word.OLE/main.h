//---------------------------------------------------------------------------

#ifndef mainH
#define mainH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
//---------------------------------------------------------------------------
class TMainForm : public TForm
{
__published:	// IDE-managed Components
        TGroupBox *MSWordGroupBox;
        TButton *TWordApplicationButton;
        TGroupBox *OLEObjectGroupBox;
        TButton *WordBasicButton;
        TButton *WordApplicationButton;
        TEdit *Edit1;
        void __fastcall WordBasicButtonClick(TObject *Sender);
        void __fastcall TWordApplicationButtonClick(TObject *Sender);
        void __fastcall WordApplicationButtonClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TMainForm(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TMainForm *MainForm;
//---------------------------------------------------------------------------
#endif
