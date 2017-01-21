//---------------------------------------------------------------------------

#ifndef mainH
#define mainH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <Buttons.hpp>
#include <Dialogs.hpp>
#include <ExtCtrls.hpp>
#include <stdio.h>
#include <fstream.h>
//---------------------------------------------------------------------------
class TMainForm : public TForm
{
__published:	// IDE-managed Components
        TOpenDialog *OpenFileDialog;
        TGroupBox *GroupBox1;
        TLabel *Label1;
        TStaticText *DataBaseName;
        TBitBtn *OpenBitBtn;
        TGroupBox *GroupBox2;
        TLabel *Label3;
        TStaticText *FieldsValue;
        TBitBtn *ViewFieldBitBtn;
        TLabel *Label4;
        TEdit *NewValue;
        TBitBtn *SetFieldBitBtn;
        TGroupBox *GroupBox3;
        TGroupBox *GroupBox4;
        TLabel *Label2;
        TStaticText *openFileName;
        TBitBtn *LockReadBitBtn;
        TBitBtn *LockWriteBitBtn;
        TBitBtn *UnLockReadBitBtn;
        TBitBtn *UnLockWriteBitBtn;
        TBevel *Bevel1;
        TLabel *Label5;
        TStaticText *Exclusive;
        TStaticText *CanModify;
        TStaticText *ReadOnly;
        TLabel *Label6;
        TLabel *Label7;
        TTimer *Timer1;
        TBitBtn *openFileBitBtn;
        TGroupBox *GroupBox5;
        TLabel *Label8;
        TStaticText *fopenFileName;
        TBitBtn *fopenFileBitBtn;
        TGroupBox *GroupBox6;
        TLabel *Label9;
        TStaticText *fstreamopenFileName;
        TBitBtn *fstreamopenBitBtn;
        TGroupBox *GroupBox7;
        TLabel *Label10;
        TStaticText *AccessFileName;
        TBitBtn *AccessFileNameBitBtn;
        TLabel *Label11;
        TStaticText *AccessToFile;
        TLabel *Label12;
        TStaticText *MyAccess;
        TCheckBox *UseSQLToSet;
        TBitBtn *CloseBitBtn;
        void __fastcall OpenBitBtnClick(TObject *Sender);
        void __fastcall ViewFieldBitBtnClick(TObject *Sender);
        void __fastcall SetFieldBitBtnClick(TObject *Sender);
        void __fastcall LockReadBitBtnClick(TObject *Sender);
        void __fastcall LockWriteBitBtnClick(TObject *Sender);
        void __fastcall UnLockReadBitBtnClick(TObject *Sender);
        void __fastcall UnLockWriteBitBtnClick(TObject *Sender);
        void __fastcall Timer1Timer(TObject *Sender);
        void __fastcall openFileBitBtnClick(TObject *Sender);
        void __fastcall FormClose(TObject *Sender, TCloseAction &Action);
        void __fastcall fopenFileBitBtnClick(TObject *Sender);
        void __fastcall fstreamopenBitBtnClick(TObject *Sender);
        void __fastcall AccessFileNameBitBtnClick(TObject *Sender);
        void __fastcall CloseBitBtnClick(TObject *Sender);
private:	// User declarations
        int handle;
        FILE *f_ptr;
        fstream f_file;
public:		// User declarations
        __fastcall TMainForm(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TMainForm *MainForm;
//---------------------------------------------------------------------------
#endif
