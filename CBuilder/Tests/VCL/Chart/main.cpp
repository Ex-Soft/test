//---------------------------------------------------------------------------

#include <vcl.h>
#include <Series.hpp>
#pragma hdrstop

#include "main.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner):TForm(Owner)
{
   Chart1->Foot->Text->Add("Foot");
   Chart1->Title->Text->Add("Title");
   Chart1->LeftAxis->Title->Caption="Chart->LeftAxis->Title->Caption";
   Chart1->BottomAxis->Title->Caption="Chart->BottomAxis->Title->Caption";
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::Button1Click(TObject *Sender)
{
   TColor ColorSeries1=clBlue,ColorSeries2=clRed;

   TBarSeries *Series1=new TBarSeries(0);
   TBarSeries *Series2=new TBarSeries(0);

   ColorSeries1=clGray;
   ColorSeries2=clWhite;
   Series1->SeriesColor=ColorSeries1;
   Series2->SeriesColor=ColorSeries2;

   Chart1->SeriesList->Clear();

   Chart1->AddSeries(Series1);
   Chart1->AddSeries(Series2);
   Series1->ParentChart=Chart1;
   Series2->ParentChart=Chart1;

   //ColorSeries1=Chart1->Series[0]->LegendItemColor(0);
   //ColorSeries2=Chart1->Series[1]->LegendItemColor(0);

   //Series1->BarStyle=bsArrow;
   //Series2->BarStyle=bsArrow;
   //Series1->BarStyle=bsCilinder;
   //Series2->BarStyle=bsCilinder;
   //Series1->BarStyle=bsEllipse;
   //Series2->BarStyle=bsEllipse;
   //Series1->BarStyle=bsInvPyramid;
   //Series2->BarStyle=bsInvPyramid;
   //Series1->BarStyle=bsPyramid;
   //Series2->BarStyle=bsPyramid;
   Series1->BarStyle=bsRectangle;
   Series2->BarStyle=bsRectangle;

   //Series1->MultiBar=Series::mbNone;
   //Series2->MultiBar=Series::mbNone;
   Series1->MultiBar=Series::mbSide;
   Series2->MultiBar=Series::mbSide;
   //Series1->MultiBar=Series::mbStacked;
   //Series2->MultiBar=Series::mbStacked;
   //Series1->MultiBar=Series::mbStacked100;
   //Series2->MultiBar=Series::mbStacked100;

   Series1->AutoMarkPosition=true;
   Series2->AutoMarkPosition=true;

   //Series1->BarBrush->Style=bsFDiagonal;
   //Series1->BarBrush->Color=clWhite;

   Series1->Clear();
   Series1->Title="Legend 4 "+ColorToString(ColorSeries1);
   Series1->Add(10,"Иванов",ColorSeries1);
   Series1->Add(5,"Сидоров",ColorSeries1);
   Series1->Add(20,"Васильев",ColorSeries1);
   Series1->Marks->Visible=false;

   Series2->Clear();
   Series2->Title="Legend 4 "+ColorToString(ColorSeries2);
   Series2->Add(50,"Иванов",ColorSeries2);
   Series2->Add(70,"Сидоров",ColorSeries2);
   Series2->Add(30,"Васильев",ColorSeries2);
   Series2->Marks->Visible=false;

   //Chart1->Legend->LegendStyle=lsAuto;
   Chart1->Legend->LegendStyle=lsSeries;
   //Chart1->Legend->LegendStyle=lsValues;
   //Chart1->Legend->LegendStyle=lsLastValues;


}
//---------------------------------------------------------------------------
