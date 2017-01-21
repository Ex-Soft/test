//---------------------------------------------------------------------------

#ifndef FramParH
#define FramParH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
//---------------------------------------------------------------------------

class TFrameWithParam : public TFrame
{
__published:	// IDE-managed Components
        TLabel *LabelParam;
        TButton *ButtonShow;
        void __fastcall ButtonShowClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TFrameWithParam(TComponent* Owner);
        __fastcall TFrameWithParam(TComponent* Owner, AnsiString aAnsiString, int aInt, TDateTime aDateTime);

        AnsiString
          AnsiStringParam;

        int
          IntParam;

        TDateTime
          DateTimeParam;
};
//---------------------------------------------------------------------------
extern PACKAGE TFrameWithParam *FrameWithParam;
//---------------------------------------------------------------------------
#endif
