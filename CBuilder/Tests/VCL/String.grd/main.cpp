//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "main.h"
//---------------------------------------------------------------------------

//#define WITH_MARK

#pragma package(smart_init)
#pragma resource "*.dfm"

bool __fastcall IsRowEmpty(TStringGrid *StringGrid, int aRow);

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{
   StringGridOns->Cells[1][0]="Phone Number";
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormShow(TObject *Sender)
{
   for(int row=0;row<StringGrid->RowCount;row++)
      for(int col=0;col<StringGrid->ColCount;col++)
         StringGrid->Cells[col][row]=IntToStr(col)+":"+IntToStr(row)+" 1234567890 1234567890";
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::StringGridDrawCell(TObject *Sender, int ACol, int ARow, TRect &Rect, TGridDrawState State)
{
   TRect rcH=Rect;

   if(ARow==0 && ACol!=StringGrid->LeftCol && ACol!=StringGrid->LeftCol+StringGrid->VisibleColCount-1)
     return;

   if(State.Contains(gdFixed))
     {
        for(int jj(0);jj<StringGrid->ColCount;jj++)
           if(jj<ACol)
             Rect.Left-=StringGrid->ColWidths[jj];
           else
             break;
           Rect.Right=StringGrid->ClientWidth;

           StringGrid->Canvas->Brush->Style=bsSolid;
           StringGrid->Canvas->Brush->Color=clBtnFace;
           StringGrid->Canvas->FillRect(Rect);

           DrawText(StringGrid->Canvas->Handle,StringGrid->Cells[ACol][ARow].c_str(),-1,&rcH,DT_WORDBREAK|DT_CENTER|DT_CALCRECT);
           DrawText(StringGrid->Canvas->Handle,StringGrid->Cells[ACol][ARow].c_str(),-1,&rcH,DT_WORDBREAK|DT_CENTER);
     }
   else
     {
        StringGrid->Canvas->Brush->Style=bsSolid;
        StringGrid->Canvas->Brush->Color=clWindow;
        StringGrid->Canvas->FillRect(Rect);

        rcH.Left+=2;
        rcH.Top+=2;
        rcH.Right-=2;
        rcH.Bottom-=2;
        DrawText(StringGrid->Canvas->Handle,StringGrid->Cells[ACol][ARow].c_str(),-1,&rcH,DT_WORDBREAK|DT_CENTER);

        if(State.Contains(gdFocused))
          {
             rcH.left-=1;
             rcH.top-=1;
             rcH.right+=1;
             rcH.bottom+=1;
             StringGrid->Canvas->DrawFocusRect(rcH);
          }

        StringGrid->Canvas->Brush->Style=bsClear;
        StringGrid->Canvas->Pen->Color=clBtnFace;
        StringGrid->Canvas->Rectangle(Rect);
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::StringGridOnsGetEditMask(TObject *Sender, int ACol, int ARow, AnsiString &Value)
{
   WriteToLog("OnGetEditMask ACol="+IntToStr(ACol)+" ARow="+IntToStr(ARow)+" Value=\""+Value+"\"");

   if(StringGridOns->Cells[ACol][0]=="Phone Number")
     Value="!\(999\)000-0000;1";

}
//---------------------------------------------------------------------------

void __fastcall TMainForm::StringGridOnsGetEditText(TObject *Sender, int ACol, int ARow, AnsiString &Value)
{
   WriteToLog("OnGetEditText ACol="+IntToStr(ACol)+" ARow="+IntToStr(ARow)+" Value=\""+Value+"\"",clMaroon);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::StringGridOnsSelectCell(TObject *Sender, int ACol, int ARow, bool &CanSelect)
{
   WriteToLog("OnSelectCell Col="+IntToStr(StringGridOns->Col)+" ACol="+IntToStr(ACol)+" Row="+IntToStr(StringGridOns->Row)+" ARow="+IntToStr(ARow)+" CanSelect="+BoolToStr(CanSelect,true),clGreen);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::StringGridOnsSetEditText(TObject *Sender, int ACol, int ARow, const AnsiString Value)
{
   WriteToLog("OnSetEditText ACol="+IntToStr(ACol)+" ARow="+IntToStr(ARow)+" Value=\""+Value+"\"",clOlive);

/*   AnsiString
     tmpValue=Value;

   int
     Length=Value.Length();

   for(int i=1; i<=Length; i++)
      tmpValue[i]=tmpValue[i]+1;

   StringGridOns->Cells[ACol][ARow]=tmpValue; */
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::WriteToLog(AnsiString aStr, TColor aColor, Graphics::TFontStyles aFontStyle)
{
   int SelStart=RichEdit1->SelStart,SelEnd;

   RichEdit1->Lines->Add(aStr);
   SelEnd=RichEdit1->SelStart;
   RichEdit1->SelStart=SelStart;
   RichEdit1->SelLength=SelEnd-SelStart;
   RichEdit1->SelAttributes->Style=aFontStyle;
   RichEdit1->SelAttributes->Color=aColor;
   RichEdit1->SelStart=SelEnd;
   RichEdit1->SelLength=0;
   RichEdit1->SelAttributes->Assign(RichEdit1->DefAttributes);
}
//---------------------------------------------------------------------------

bool __fastcall IsRowEmpty(TStringGrid *StringGrid, int aRow)
{
   bool IsEmpty=true;

   for(int aCol=0; aCol<StringGrid->ColCount; ++aCol)
      {
         if(!StringGrid->Cells[aCol][aRow].Trim().IsEmpty())
           {
              IsEmpty=false;
              break;
           }
      }

   return(IsEmpty);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::StringGridRunTimeKeyDown(TObject *Sender, WORD &Key, TShiftState Shift)
{
   TStringGrid *StringGrid=0;

   if(!(StringGrid=dynamic_cast<TStringGrid *>(Sender)))
     return;

   int RowCount=StringGrid->RowCount;

   if(Key==VK_DOWN)
     {
        if(StringGrid->Row==RowCount-1 && !IsRowEmpty(StringGrid,StringGrid->Row))
          {
             StringGrid->RowCount=RowCount+1;
             StringGridRunTime->Row=RowCount;
             Key=0;
          }
     }
   if(Key==VK_UP)
     {
        if(StringGrid->Row>1 && StringGrid->Row==RowCount-1 && IsRowEmpty(StringGrid,StringGrid->Row))
          {
             StringGrid->RowCount=RowCount-1;
             Key=0;
          }
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::StringGridRunTimeSelectCell(TObject *Sender, int ACol, int ARow, bool &CanSelect)
{
///
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::StringGridOnsDblClick(TObject *Sender)
{
   WriteToLog("OnDblClick Col="+IntToStr(StringGridOns->Col)+" Row="+IntToStr(StringGridOns->Row),clGreen);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::StringGridIntegrateSelectCell(TObject *Sender, int ACol, int ARow, bool &CanSelect)
{
   const int
     ColComboBox=2,
     ColComboBoxSelfDraw=3;

   TComboBox
     *ComboBox;

   if(ACol==ColComboBox || ACol==ColComboBoxSelfDraw)
     {
        switch(ACol)
          {
             case ColComboBox :
               {
                  ComboBox=ComboBoxIntegrate;

                  break;
               }
             case ColComboBoxSelfDraw :
               {
                  ComboBox=ComboBoxIntegrateSelfDraw;

                  break;
               }
             default :
               {
                  ComboBox=0;
               }
          }

        if(!ComboBox)
          return;

        ComboBox->ItemIndex=ComboBox->Items->IndexOf(StringGridIntegrate->Cells[ACol][ARow]);
        ComboBox->Left=StringGridIntegrate->Left+StringGridIntegrate->CellRect(ACol,ARow).Left+2;
        ComboBox->Top=StringGridIntegrate->Top+StringGridIntegrate->CellRect(ACol,ARow).Top+2;
        ComboBox->Width=StringGridIntegrate->CellRect(ACol,ARow).Right-StringGridIntegrate->CellRect(ACol,ARow).Left+2;
        switch(ACol)
          {
             case ColComboBox :
               {
                  StringGridIntegrate->Cells[ACol-1][ARow]=IntToStr(StringGridIntegrate->CellRect(ACol,ARow).Bottom-StringGridIntegrate->CellRect(ACol,ARow).Top);
                  StringGridIntegrate->Cells[ACol-2][ARow]=FloatToStr(ComboBox->Canvas->TextHeight(ComboBox->Text));
//                  ComboBox->Font->Height=StringGridIntegrate->CellRect(ACol,ARow).Top-StringGridIntegrate->CellRect(ACol,ARow).Bottom;

                  break;
               }
             case ColComboBoxSelfDraw :
               {
                  ComboBox->ItemHeight=StringGridIntegrate->CellRect(ACol,ARow).Bottom-StringGridIntegrate->CellRect(ACol,ARow).Top-6;

                  break;
               }
          }
        ComboBox->Visible=true;
        ComboBox->SetFocus();
        CanSelect=true;
     }
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ComboBoxIntegrateExit(TObject *Sender)
{
   TComboBox
     *ComboBox;

   if(!(ComboBox=dynamic_cast<TComboBox *>(Sender)))
     return;

   StringGridIntegrate->Cells[StringGridIntegrate->Col][StringGridIntegrate->Row]=ComboBox->Text;
   ComboBox->Visible=false;
   StringGridIntegrate->SetFocus();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ComboBoxIntegrateSelfDrawDrawItem(TWinControl *Control, int Index, TRect &Rect, TOwnerDrawState State)
{
   if(!Control->Showing)
     return;

   TComboBox
     *ComboBox=dynamic_cast<TComboBox *>(Control);

   ComboBox->Canvas->Brush->Color=(State.Contains(odSelected) ? clHighlight : clWindow);
   ComboBox->Canvas->FillRect(Rect);

   if(Index==-1)
     return;

   #if defined(WITH_MARK)
     char
       *mark="•";
   #endif

   TRect
     rect(Rect.left+1,Rect.top+1,Rect.right-1,Rect.bottom-1);

   #if defined(WITH_MARK)
     ComboBox->Canvas->TextOut(Rect.left,Rect.Top+2,mark);
     rect.Left+=Canvas->TextWidth(mark);
   #endif
   DrawText(ComboBox->Canvas->Handle,ComboBox->Items->Strings[Index].c_str(),-1,&rect,DT_WORDBREAK);
}
//---------------------------------------------------------------------------

