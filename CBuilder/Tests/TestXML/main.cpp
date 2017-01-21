//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "main.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"

void __fastcall PrintNode(_di_IXMLNode Node);

TMainForm *MainForm;
//---------------------------------------------------------------------------

__fastcall TMainForm::TMainForm(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::FormCreate(TObject *Sender)
{
   ForReallyAnyTestBitBtn->Height=ClientHeight;
   ForReallyAnyTestBitBtn->Width=ClientWidth;
   ForReallyAnyTestBitBtn->Caption=AnsiString("For\r\n")+"Really\r\n"+"Any\r\n"+"Test's\r\n"+"Button";
   long btnstyle=GetWindowLong(ForReallyAnyTestBitBtn->Handle,GWL_STYLE);
   btnstyle|=BS_MULTILINE;
   SetWindowLong(ForReallyAnyTestBitBtn->Handle,GWL_STYLE,btnstyle);
}
//---------------------------------------------------------------------------

void __fastcall TMainForm::ForReallyAnyTestBitBtnClick(TObject *Sender)
{
   if(XMLDocument->IsEmptyDoc())
     return;

   if(!XMLDocument->DocumentElement->HasChildNodes)
     return;

   int Count = XMLDocument->DocumentElement->ChildNodes->Count;
   _di_IXMLNode BorlandStock;
   AnsiString Price;

   PrintNode(XMLDocument->DocumentElement);

/*   for(int i = 0; i < Count ; i++)
      {
         BorlandStock = XMLDocument->DocumentElement->ChildNodes->GetNode(i);
         if(BorlandStock-> HasChildNodes)
           Price = BorlandStock->ChildNodes->Nodes[WideString("price")]->Text;
      }
*/
}
//---------------------------------------------------------------------------

void __fastcall PrintNode(_di_IXMLNode Node)
{
/*   if(Node->IsTextElement)
     {
        AnsiString tmp=Node->NodeName;
        ShowMessage(tmp);
        return;
     }
*/           Node->
   if(Node->HasChildNodes)
     {
        int Count = Node->ChildNodes->Count;
        _di_IXMLNode BorlandStock;
        for(int i = 0; i<Count; i++)
           {
              BorlandStock = Node->ChildNodes->GetNode(i);
              if(BorlandStock->IsTextElement)
                {
                   AnsiString tmp=BorlandStock->NodeName+"="+BorlandStock->NodeValue;
                   ShowMessage(tmp);
                   continue;
                }
              else
                PrintNode(BorlandStock);
           }
     }
   else
     {
        AnsiString tmp=Node->NodeName;
        ShowMessage(tmp);
     }
}
//---------------------------------------------------------------------------
