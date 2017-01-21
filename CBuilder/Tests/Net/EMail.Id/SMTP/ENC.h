//---------------------------------------------------------------------------

#ifndef ENCH
#define ENCH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <IdBaseComponent.hpp>
#include <IdCoder.hpp>
#include <IdCoderIMF.hpp>
#include <IdCoderText.hpp>
#include <IdCoder3To4.hpp>
#include <IdMessage.hpp>
#include "CyrCoder.hpp"
#include "PROPERTYTREELib_OCX.h"
#include <OleCtrls.hpp>
#include "vsFlexLib_OCX.h"
#include "ASSETBROWSERLib_OCX.h"
#include "CTVLib_OCX.h"
#include "LEADThumbLib_OCX.h"
#include "CICLib_OCX.h"
#include "RefEdit_OCX.h"
#include <DBOleCtl.hpp>
#include <ComCtrls.hpp>
#include <ExtCtrls.hpp>
#include <ImgList.hpp>
#include <Buttons.hpp>
#include <Mask.hpp>
//---------------------------------------------------------------------------
class TForm7 : public TForm
{
__published:	// IDE-managed Components
        TEdit *Edit1;
        TEdit *Edit2;
        TEdit *Edit3;
        TButton *Button1;
        TButton *Button2;
        TIdIMFDecoder *IdIMFDecoder1;
        TIdMessage *IdMessage1;
        TIdBase64Encoder *IdBase64Encoder1;
        TIdBase64Decoder *IdBase64Decoder1;
        TCyrCoder *CyrCoder1;
        TButton *Button3;
        TPanel *Panel1;
        TTreeView *TreeView1;
        TPageControl *PageControl1;
        TTabSheet *TabSheet1;
        TTabSheet *TabSheet2;
        TTabSheet *TabSheet3;
        TImageList *ImageList2;
        TTabSheet *TabSheet5;
        TEdit *From;
        TLabel *Label9;
        TLabel *Label10;
        TEdit *To;
        TEdit *POP3Host;
        TMaskEdit *POP3Port;
        TEdit *POP3Userid;
        TEdit *POP3Password;
        TLabel *Label4;
        TLabel *Label3;
        TLabel *Label2;
        TLabel *Label1;
        TBitBtn *BitBtn3;
        TCheckBox *CheckBox1;
        TMaskEdit *SMTPPort;
        TEdit *SMTPHost;
        TLabel *Label5;
        TLabel *Label6;
        TCheckBox *CheckBox2;
        TLabel *Label7;
        TEdit *SMTPUserid;
        TLabel *Label8;
        TEdit *SMTPPassword;
        TBitBtn *BitBtn4;
        void __fastcall Button2Click(TObject *Sender);
        void __fastcall Button1Click(TObject *Sender);
        void __fastcall TreeView1Change(TObject *Sender, TTreeNode *Node);
private:	// User declarations
public:		// User declarations
        __fastcall TForm7(TComponent* Owner);
        AnsiString __fastcall CodeString(AnsiString InStr, AnsiString K,char KType);
        AnsiString __fastcall DecodeString(AnsiString Str);
        AnsiString __fastcall DecodeStrings(AnsiString Str);
        int __fastcall FindNChar(AnsiString Str,char ch, int cou);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm7 *Form7;
//---------------------------------------------------------------------------
#endif
