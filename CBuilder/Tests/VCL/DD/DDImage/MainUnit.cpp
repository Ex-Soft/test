//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "MainUnit.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TMainForm *MainForm;
//---------------------------------------------------------------------------
__fastcall TMainForm::TMainForm(TComponent* Owner) : TForm(Owner)
{
        ImageCard->Picture->LoadFromFile("bmp\\Clubs7.bmp");
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::PaintBoxSrcPaint(TObject *Sender)
{
          PaintBoxSrc->Canvas->Brush->Color = clGreen;
          PaintBoxSrc->Canvas->FloodFill(PaintBoxSrc->ClientWidth/2, PaintBoxSrc->ClientHeight/2, clGreen, fsBorder);
}
//---------------------------------------------------------------------------
void __fastcall TMainForm::PaintBoxDestPaint(TObject *Sender)
{
          PaintBoxDest->Canvas->Brush->Color = clBlue;
          PaintBoxDest->Canvas->FloodFill(PaintBoxDest->ClientWidth/2, PaintBoxDest->ClientHeight/2, clBlue, fsBorder);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::PaintBoxDragDrop(TObject *Sender, TObject *Source, int X, int Y)
{
        TPaintBox *paintBox;
        TImage *image;

        if (!(paintBox = dynamic_cast<TPaintBox *>(Sender)) || !(image = dynamic_cast<TImage *>(Source)))
                return;

        image->Left = paintBox->Left + X;
        image->Top = paintBox->Top + Y;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ImageCardMouseDown(TObject *Sender, TMouseButton Button, TShiftState Shift, int X, int Y)
{
        TImage *image;

        if (Button != mbLeft || !(image = dynamic_cast<TImage *>(Sender)))
                return;

        image->BeginDrag(true);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ImageCardEndDrag(TObject *Sender, TObject *Target, int X, int Y)
{
        PaintBoxSrc->Repaint();
        PaintBoxDest->Repaint();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormDragOver(TObject *Sender, TObject *Source, int X, int Y, TDragState State, bool &Accept)
{
        Accept = false;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::PaintBoxDragOver(TObject *Sender, TObject *Source, int X, int Y, TDragState State, bool &Accept)
{
        Accept = true;
}
//---------------------------------------------------------------------------


