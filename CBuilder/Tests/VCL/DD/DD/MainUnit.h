//---------------------------------------------------------------------------

#ifndef MainUnitH
#define MainUnitH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
//---------------------------------------------------------------------------
class TMainForm : public TForm
{
__published:	// IDE-managed Components
        TButton *Button;
        void __fastcall ButtonMouseDown(TObject *Sender,
          TMouseButton Button, TShiftState Shift, int X, int Y);
        void __fastcall ButtonDragDrop(TObject *Sender, TObject *Source,
          int X, int Y);
        void __fastcall FormDragDrop(TObject *Sender, TObject *Source,
          int X, int Y);
        void __fastcall ButtonStartDrag(TObject *Sender,
          TDragObject *&DragObject);
        void __fastcall FormDragOver(TObject *Sender, TObject *Source,
          int X, int Y, TDragState State, bool &Accept);
private:	// User declarations
public:		// User declarations
        __fastcall TMainForm(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TMainForm *MainForm;
//---------------------------------------------------------------------------
#endif
