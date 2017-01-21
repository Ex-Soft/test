//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "main.h"
#include "DataUnit.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

extern void __fastcall WriteToLogFile(AnsiString aStr);

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{
   MainFormColor=clBlack;
   DataUnitColor=clMaroon;
   IBDatabaseColor=clGreen;
   IBSQLMonitorColor=clOlive;
   IBTransactionColor=clNavy;
   IBTableColor=clPurple;
   IBDataSetColor=clTeal;
   DataSourceColor=clGray;
   DBEditColor=clSilver;
   
   AnsiString
     ToLog="TMainForm::TMainForm()";

   WriteToLogFile(ToLog);
   WriteToLog(ToLog,MainFormColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);

   Align=alClient;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormCreate(TObject *Sender)
{
   AnsiString
     ToLog="TMainForm::FormCreate()";

   WriteToLogFile(ToLog);
   WriteToLog(ToLog,MainFormColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormShow(TObject *Sender)
{
   AnsiString
     ToLog="TMainForm::FormShow()";

   WriteToLogFile(ToLog);
   WriteToLog(ToLog,MainFormColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);

   DBGridInsurant->DataSource=DataBase->DataSourceInsurant;
   DBText1->DataSource=DataBase->DataSourceInsurant;
   DBText1->DataField="NameN";
   DBEdit1->DataSource=DataBase->DataSourceInsurant;
   DBEdit1->DataField="NameN";
   DBMemo1->DataSource=DataBase->DataSourceInsurant;
   DBMemo1->DataField="NameN";

}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormCloseQuery(TObject *Sender, bool &CanClose)
{
   AnsiString
     ToLog="TMainForm::FormCloseQuery()";

   WriteToLogFile(ToLog);
   WriteToLog(ToLog,MainFormColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormClose(TObject *Sender, TCloseAction &Action)
{
   AnsiString
     ToLog="TMainForm::FormClose()";

   WriteToLogFile(ToLog);
   WriteToLog(ToLog,MainFormColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::WriteToLog(AnsiString aStr, TColor aColor, Graphics::TFontStyles aFontStyle)
{
   int
     SelStart=RichEditLog->SelStart,
     SelEnd;

   RichEditLog->Lines->Add(Now().DateTimeString()+" "+aStr);
   SelEnd=RichEditLog->SelStart;
   RichEditLog->SelStart=SelStart;
   RichEditLog->SelLength=SelEnd-SelStart;
   RichEditLog->SelAttributes->Style=aFontStyle;
   RichEditLog->SelAttributes->Color=aColor;
   RichEditLog->SelStart=SelEnd;
   RichEditLog->SelLength=0;
   RichEditLog->SelAttributes->Assign(RichEditLog->DefAttributes);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::DBEdit1Change(TObject *Sender)
{
   AnsiString
     ToLog="TDBEidt OnChange";

   WriteToLogFile(ToLog);
   WriteToLog(ToLog,DBEditColor,Graphics::TFontStyles()<<fsBold<<fsUnderline);
}
//---------------------------------------------------------------------------

