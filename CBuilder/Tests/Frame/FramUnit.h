//---------------------------------------------------------------------------

#ifndef FramUnitH
#define FramUnitH
//---------------------------------------------------------------------------

#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
//---------------------------------------------------------------------------

class TLabelFrame : public TFrame
{
__published:	// IDE-managed Components
        TGroupBox *GroupBox1;
        TLabel *Label1;
        TButton *SetupButton;
        TButton *IncButton;
        TButton *ShowButton;
        void __fastcall SetupButtonClick(TObject *Sender);
        void __fastcall IncButtonClick(TObject *Sender);
        void __fastcall ShowButtonClick(TObject *Sender);
private:	// User declarations

        int
          A;

public:		// User declarations
        __fastcall TLabelFrame(TComponent* Owner);

        int
          B;

        static int
          C;
};
//---------------------------------------------------------------------------
extern PACKAGE TLabelFrame *LabelFrame;
//---------------------------------------------------------------------------
#endif


