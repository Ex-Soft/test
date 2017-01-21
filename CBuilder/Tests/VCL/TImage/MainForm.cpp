//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "MainForm.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner) : TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ButtonGetInfoClick(TObject *Sender)
{
        MemoLog->Lines->Add("Height: " + IntToStr(TestImage->Height) + " Width: " + IntToStr(TestImage->Width) + " ClientHeight: " + IntToStr(TestImage->ClientHeight) + " ClientWidth: " + IntToStr(TestImage->ClientWidth));
        MemoLog->Lines->Add("BoundsRect.Left: " + IntToStr(TestImage->BoundsRect.Left) + " BoundsRect.Top: " + IntToStr(TestImage->BoundsRect.Top) + " BoundsRect.Right: " + IntToStr(TestImage->BoundsRect.Right) + " BoundsRect.Bottom: " + IntToStr(TestImage->BoundsRect.Bottom));
        MemoLog->Lines->Add("ClientOrigin.x: " + IntToStr(TestImage->ClientOrigin.x) + " ClientOrigin.y: " + IntToStr(TestImage->ClientOrigin.y));
        MemoLog->Lines->Add("ClientRect.Left: " + IntToStr(TestImage->ClientRect.Left) + " ClientRect.Top: " + IntToStr(TestImage->ClientRect.Top) + " ClientRect.Right: " + IntToStr(TestImage->ClientRect.Right) + " ClientRect.Bottom: " + IntToStr(TestImage->ClientRect.Bottom));
        MemoLog->Lines->Add("Picture->Height: " + IntToStr(TestImage->Picture->Height) + " Picture->Width: " + IntToStr(TestImage->Picture->Width) + " Picture->Bitmap->Height: " + IntToStr(TestImage->Picture->Bitmap->Height) + " Picture->Bitmap->Width: " + IntToStr(TestImage->Picture->Bitmap->Width));
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ButtonLoadImageClick(TObject *Sender)
{
        AnsiString imageFileName;

        if(!FileExists(imageFileName = ExtractFilePath(Application->ExeName) + "bmp\\Clubs7.bmp"))
                return;

        TestImage->Picture->LoadFromFile(imageFileName);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::CheckBoxAutoSizeClick(TObject *Sender)
{
        TestImage->AutoSize = CheckBoxAutoSize->Checked;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ButtonDrawGridClick(TObject *Sender)
{
        int
                penWidth = 1,
                padding = 0,
                length = 0;

        if (!TryStrToInt(EditPenWidth->Text, penWidth))
                penWidth = 1;

        if (!TryStrToInt(EditPadding->Text, padding))
                padding = 0;

        if (!TryStrToInt(EditLength->Text, length))
                length = 0;

        TestImage->Canvas->Pen->Color = clRed;
        TestImage->Canvas->Pen->Width = penWidth;
        TestImage->Canvas->Pen->Style = psSolid;

        int pos = 10;
        TestImage->Canvas->PenPos = TPoint(0 + padding, pos);
        TestImage->Canvas->LineTo(length ? length : TestImage->Width - padding, pos);
        TestImage->Canvas->PenPos = TPoint(pos, 0 + padding);
        TestImage->Canvas->LineTo(pos, length ? length : TestImage->Height - padding);

        pos += 10;
        TestImage->Canvas->PenPos = TPoint(0 + padding, pos);
        TestImage->Canvas->LineTo(length ? length : TestImage->Picture->Width - padding, pos);
        TestImage->Canvas->PenPos = TPoint(pos, 0 + padding);
        TestImage->Canvas->LineTo(pos, length ? length : TestImage->Picture->Height - padding);

        pos += 10;
        TestImage->Canvas->PenPos = TPoint(0 + padding, pos);
        TestImage->Canvas->LineTo(length ? length : TestImage->Picture->Bitmap->Width - padding, pos);
        TestImage->Canvas->PenPos = TPoint(pos, 0 + padding);
        TestImage->Canvas->LineTo(pos, length ? length : TestImage->Picture->Bitmap->Height - padding);

        pos += 10;
        TestImage->Canvas->PenPos = TPoint(1, pos);
        TestImage->Canvas->LineTo(9, pos);
        TestImage->Canvas->PenPos = TPoint(pos, 1);
        TestImage->Canvas->LineTo(pos, 9);

        pos += 10;
        TestImage->Canvas->MoveTo(1, pos);
        TestImage->Canvas->LineTo(9, pos);
        TestImage->Canvas->MoveTo(pos, 1);
        TestImage->Canvas->LineTo(pos, 9);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ButtonClearClick(TObject *Sender)
{
        TestImage->Picture = 0;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ButtonDoItClick(TObject *Sender)
{
        TControl *control;
        TImage *image;

        for(int i = 0; i < ControlCount; ++i)
        {
                if(control = dynamic_cast<TControl *>(Controls[i]))
                {
                        if(image = dynamic_cast<TImage *>((Controls[i])))
                                RemoveControl(image);
                }
        }
}
//---------------------------------------------------------------------------

