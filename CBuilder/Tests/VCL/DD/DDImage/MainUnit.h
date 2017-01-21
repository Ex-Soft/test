//---------------------------------------------------------------------------

#ifndef MainUnitH
#define MainUnitH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ExtCtrls.hpp>
//---------------------------------------------------------------------------
class TMainForm : public TForm
{
__published:	// IDE-managed Components
        TPaintBox *PaintBoxSrc;
        TPaintBox *PaintBoxDest;
        TImage *ImageCard;
        void __fastcall PaintBoxSrcPaint(TObject *Sender);
        void __fastcall ImageCardMouseDown(TObject *Sender, TMouseButton Button, TShiftState Shift, int X, int Y);
        void __fastcall FormDragOver(TObject *Sender, TObject *Source, int X, int Y, TDragState State, bool &Accept);
        void __fastcall PaintBoxDragOver(TObject *Sender, TObject *Source, int X, int Y, TDragState State, bool &Accept);
        void __fastcall PaintBoxDragDrop(TObject *Sender, TObject *Source, int X, int Y);
        void __fastcall PaintBoxDestPaint(TObject *Sender);
        void __fastcall ImageCardEndDrag(TObject *Sender, TObject *Target,
          int X, int Y);
private:	// User declarations
public:		// User declarations
        __fastcall TMainForm(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TMainForm *MainForm;
//---------------------------------------------------------------------------
#endif
