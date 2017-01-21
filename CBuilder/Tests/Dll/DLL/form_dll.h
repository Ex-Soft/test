//---------------------------------------------------------------------------

#ifndef form_dllH
#define form_dllH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
//---------------------------------------------------------------------------
class TDFMForm : public TForm
{
__published:	// IDE-managed Components
        TLabel *ShowLabel;
        void __fastcall FormClose(TObject *Sender, TCloseAction &Action);
private:	// User declarations
public:		// User declarations
        __fastcall TDFMForm(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TDFMForm *DFMForm;
//---------------------------------------------------------------------------
#endif
