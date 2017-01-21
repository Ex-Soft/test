//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "MainUnit.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TMainForm *MainForm;
//---------------------------------------------------------------------------
__fastcall TMainForm::TMainForm(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ButtonMouseDown(TObject *Sender, TMouseButton Button, TShiftState Shift, int X, int Y)
{
        TButton *button;

        if (Button != mbLeft || !(button = dynamic_cast<TButton *>(Sender)))
                return;

        button->BeginDrag(true);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ButtonStartDrag(TObject *Sender, TDragObject *&DragObject)
{
        TButton *button;

        if (!(button = dynamic_cast<TButton *>(Sender)))
                return;

}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ButtonDragDrop(TObject *Sender, TObject *Source, int X, int Y)
{
        TButton *button;

        if (!(button = dynamic_cast<TButton *>(Sender)))
                return;

//        button->BeginDrag(true);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormDragDrop(TObject *Sender, TObject *Source, int X, int Y)
{
        TButton *button;

        if (!(button = dynamic_cast<TButton *>(Sender)))
                return;

//        button->BeginDrag(true);

}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormDragOver(TObject *Sender, TObject *Source, int X, int Y, TDragState State, bool &Accept)
{
        TForm *form;
        TButton *button;

        if (!(form = dynamic_cast<TForm *>(Sender)) || !(button = dynamic_cast<TButton *>(Source)))
                return;

        button->Left = X;
        button->Top = Y;
        Accept = true;
}
//---------------------------------------------------------------------------

