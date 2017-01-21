//---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop

#include "ENC.h"
//---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma link "CyrCoder"
#pragma link "PROPERTYTREELib_OCX"
#pragma link "vsFlexLib_OCX"
#pragma link "ASSETBROWSERLib_OCX"
#pragma link "CTVLib_OCX"
#pragma link "LEADThumbLib_OCX"
#pragma link "CICLib_OCX"
#pragma link "RefEdit_OCX"
#pragma resource "*.dfm"
TForm7 *Form7;
//---------------------------------------------------------------------------
__fastcall TForm7::TForm7(TComponent* Owner)
        : TForm(Owner)
{
}
//---------------------------------------------------------------------------


void __fastcall TForm7::Button2Click(TObject *Sender)
{
         //IdIMFDecoder1->Reset();
         //IdIMFDecoder1->CodeString(Edit2->Text);
         //Edit3->Text=IdIMFDecoder1->CompletedInput();
         
         //IdBase64Decoder1->Reset();
         //IdBase64Decoder1->CodeString(Edit2->Text);
         //Edit3->Text=IdBase64Decoder1->CompletedInput();
         Edit3->Text=DecodeStrings(Edit2->Text);
}
//---------------------------------------------------------------------------
void __fastcall TForm7::Button1Click(TObject *Sender)
{
         Edit2->Text=CodeString(Edit1->Text,"Windows-1251",'B');
}
//---------------------------------------------------------------------------


AnsiString __fastcall TForm7::CodeString(AnsiString InStr, AnsiString K,char KType)
{
        TIdCoder * Coder = NULL;
        if (KType=='Q')
           {Coder = new TIdQuotedPrintableEncoder(NULL);}
        if (KType=='B')
           {Coder = new TIdBase64Encoder(NULL);}
        if (Coder==NULL){return "";}
         Coder->Reset();
         Coder->CodeString(InStr);
         AnsiString Temp = AnsiString("=?"+K+"?"+KType+"?"+Coder->CompletedInput().Delete(1,2)+"?=");
         delete Coder;
         return Temp;
}

AnsiString __fastcall TForm7::DecodeString(AnsiString Str)
{
        TStrings * TempSL;
        TempSL = new TStringList;
        TempSL->Delimiter='?';
        TempSL->DelimitedText=Str.Trim();
        if (TempSL->Count==1 || TempSL->Count==0)
           {delete TempSL;return "";}
        if (TempSL->Strings[TempSL->Count-1]!="=" || TempSL->Strings[0]!="=")
           {delete TempSL;return "";}
        TIdCoder * Coder = NULL;
        if (TempSL->Strings[2]=="Q")
           {Coder = new TIdQuotedPrintableDecoder(NULL);}
        if (TempSL->Strings[2]=="B")
           {Coder = new TIdBase64Decoder(NULL);}
        if (Coder==NULL){delete TempSL;return "";}
        AnsiString Temp = TempSL->Strings[3];
        AnsiString TempE= TempSL->Strings[1];
        for (int p=4;p<TempSL->Count-1;p++)
            {Temp =Temp+" "+TempSL->Strings[p];}
        delete TempSL;
        Coder->Reset();
        Coder->CodeString(Temp);
        Temp=Coder->CompletedInput();
        delete Coder;
        if (Temp.Length()>=2){Temp=Temp.Delete(1,2);}
        TCyrCoder * CyrCoder1 = NULL;
        CyrCoder1 = new TCyrCoder(NULL);
        CyrCoder1->Source = CP1251;
        CyrCoder1->Target = CP1251;
        if (TempE.LowerCase().Pos("koi8-r")!=0)
           {CyrCoder1->Source = KOI8R;}
        if (TempE.LowerCase().Pos("866")!=0 && (TempE.LowerCase().Pos("cp")!=0 ||TempE.LowerCase().Pos("dos")!=0 ))
           {CyrCoder1->Source = CP866;}
        if (TempE.LowerCase().Pos("8859")!=0 && TempE.LowerCase().Pos("iso")!=0 )
           {CyrCoder1->Source = ISO8859;}
        if (CyrCoder1->Source!=CyrCoder1->Target)
           {CyrCoder1->Text = Temp;CyrCoder1->Execute();Temp=CyrCoder1->Text;}
        delete CyrCoder1;
        return Temp;
}

AnsiString __fastcall TForm7::DecodeStrings(AnsiString Str)
{
        AnsiString Temp    = "";
        AnsiString TempOld = Str;
        if (TempOld.Pos("=?")==0){Temp=TempOld;return Temp;}
        while (TempOld.Pos("=?")!=0)
              {
                 int i   = TempOld.Pos("=?");
                 Temp    = Temp+TempOld.SubString(1,i-1);
                 TempOld = TempOld.Delete(1,i-1);
                 i       = FindNChar(TempOld,'?',4);
                 Temp    = Temp+DecodeString(TempOld.SubString(1,i+1));
                 TempOld = TempOld.Delete(1,i+1);
              }
         Temp = Temp+TempOld;
         return Temp;
}

int __fastcall TForm7::FindNChar(AnsiString Str,char ch, int cou)
{
        int len =Str.Length();
        int i = 0;
        while (Str.Pos(ch)!=0)
              {i++;Str = Str.Delete(1,Str.Pos(ch));if (cou==i){break;}}
        return len-Str.Length();
        
}


void __fastcall TForm7::TreeView1Change(TObject *Sender, TTreeNode *Node)
{
        PageControl1->TabIndex=Node->AbsoluteIndex;
        PageControl1->ActivePage=PageControl1->Pages[Node->AbsoluteIndex];
}
//---------------------------------------------------------------------------

