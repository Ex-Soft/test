//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "main.h"
#include "DataUnit.h"
//---------------------------------------------------------------------------

#pragma package(smart_init)
#pragma resource "*.dfm"
TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormShow(TObject *Sender)
{
   int DocNo;
   AnsiString Seria;

   Table1->TableName="blank.dbf";
   try
     {
        Table1->Open();
     }
   catch(EDBEngineError &eException)
     {
        bool
          Result=false;

        for(int i=0; i<eException.ErrorCount; ++i)
           if(eException.Errors[i]->ErrorCode==DBIERR_NOSUCHINDEX)
             {
                //Result=DeleteIndex(Table1->DatabaseName+Table1->TableName);

                break;
             }
        if(Result)
          Table1->Open();
        else ;
          //KARAUL();
     }
   Table1->IndexName="Doc_No";

   //Table1->Filter="Type_Doc=\'P\'";

   Table1->Filtered=true;
   Table1->SetKey();
   Table1->FieldByName("Seria")->AsString="B";
   Table1->FieldByName("Doc_No")->AsInteger=2;
   if(Table1->GotoKey())
     {
        Seria=Table1->FieldByName("Seria")->AsString;
        DocNo=Table1->FieldByName("Doc_No")->AsInteger;
     }
   //Table1->Filter="";
   Table1->IndexName="N_Request";
   Seria=Table1->FieldByName("Seria")->AsString;
   DocNo=Table1->FieldByName("Doc_No")->AsInteger;
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormClose(TObject *Sender, TCloseAction &Action)
{
   if(Table1->Active)
     Table1->Close();
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::DBGrid1MouseMove(TObject *Sender, TShiftState Shift, int X, int Y)
{
   static TGridCoord
     Coord={-1,-1};

   TGridCoord
     tmpCoord=DBGrid1->MouseCoord(X,Y);

   bool        // X == Col            Y==Row
     Changed = Coord.X!=tmpCoord.X || Coord.Y!=tmpCoord.Y;

   if(Changed)
     {
        Coord=tmpCoord;

        if(Coord.X<=0 || Coord.Y<=0)
          return;

        Application->CancelHint();

        AnsiString
          tmpAnsiString;

        TDataSet
          *pDS=DBGrid1->DataSource->DataSet;

        int
          DeltaMove=0;

        if(pDS->RecNo!=Coord.Y-1)
          {
             DeltaMove=Coord.Y-1-pDS->RecNo;
             pDS->MoveBy(DeltaMove);
          }
        tmpAnsiString=DBGrid1->Columns->Items[Coord.X-1]->Field->DisplayText;
        if(DeltaMove)
          pDS->MoveBy(-DeltaMove);

        DBGrid1->Hint="X="+IntToStr(Coord.X)+", Y="+IntToStr(Coord.Y)+" Value=\""+tmpAnsiString+"\"";
     }
}
//---------------------------------------------------------------------------

