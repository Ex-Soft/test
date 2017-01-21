//---------------------------------------------------------------------------

#ifndef mainH
#define mainH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include "FramUnit.h"
#include "FramUni_.h"
#include "FramPar.h"
//---------------------------------------------------------------------------
class TMainForm : public TForm
{
__published:	// IDE-managed Components
        TLabelFrame *LabelFrame11;
        TLabel *Label1;
        TLabelFrame *LabelFrame12;
        TButton *ShowButton;
        TOpenFileFrame *Frame12;
        TFrameWithParam *FrameWithParam1;
        TFrameWithParam *FrameWithParam2;
        void __fastcall ShowButtonClick(TObject *Sender);
        void __fastcall FormClose(TObject *Sender, TCloseAction &Action);
private:	// User declarations
public:		// User declarations
        __fastcall TMainForm(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TMainForm *MainForm;
//---------------------------------------------------------------------------
#endif
