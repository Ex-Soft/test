//---------------------------------------------------------------------------

#ifndef FrameTstH
#define FrameTstH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
//---------------------------------------------------------------------------
class TTestFrame : public TFrame
{
__published:	// IDE-managed Components
        TLabel *LabelFrame;
private:	// User declarations
public:		// User declarations
        __fastcall TTestFrame(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TTestFrame *TestFrame;
//---------------------------------------------------------------------------
#endif
