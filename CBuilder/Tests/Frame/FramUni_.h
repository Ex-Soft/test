//---------------------------------------------------------------------------

#ifndef FramUni_H
#define FramUni_H
//---------------------------------------------------------------------------

#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <AppEvnts.hpp>
#include <Dialogs.hpp>
//---------------------------------------------------------------------------

class TOpenFileFrame : public TFrame
{
__published:	// IDE-managed Components
        TGroupBox *GroupBox1;
        TLabel *Label1;
        TEdit *Edit1;
        TButton *ViewButton;
        TApplicationEvents *ApplicationEvents1;
        TOpenDialog *OpenDialog1;
        void __fastcall ApplicationEvents1ShowHint(AnsiString &HintStr, bool &CanShow, THintInfo &HintInfo);
        void __fastcall ViewButtonClick(TObject *Sender);
        void __fastcall Edit1Exit(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TOpenFileFrame(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TOpenFileFrame *OpenFileFrame;
//---------------------------------------------------------------------------
#endif
