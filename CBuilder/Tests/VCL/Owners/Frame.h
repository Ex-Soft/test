//---------------------------------------------------------------------------

#ifndef FrameH
#define FrameH
//---------------------------------------------------------------------------

#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
//---------------------------------------------------------------------------

class TFrameTest : public TFrame
{
__published:	// IDE-managed Components
        TEdit *EditFrameTest;
        TComboBox *ComboBoxFrameTest;
private:	// User declarations
public:		// User declarations
        __fastcall TFrameTest(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TFrameTest *FrameTest;
//---------------------------------------------------------------------------
#endif
