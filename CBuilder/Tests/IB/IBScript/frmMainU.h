//---------------------------------------------------------------------------

#ifndef frmMainUH
#define frmMainUH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include "IBScript.hpp"
#include <ActnList.hpp>
#include <Db.hpp>
#include <DBGrids.hpp>
#include <Dialogs.hpp>
#include <Grids.hpp>
#include <IBCustomDataSet.hpp>
#include <IBDatabase.hpp>
#include <DB.hpp>
//---------------------------------------------------------------------------
class TfrmMain : public TForm
{
__published:	// IDE-managed Components
  TMemo *Memo1;
  TMemo *Memo2;
  TButton *Button1;
  TMemo *Memo3;
  TButton *Button2;
  TButton *Button3;
  TCheckBox *chkPause;
  TDBGrid *DBGrid1;
  TButton *Button4;
  TButton *Button5;
  TOpenDialog *OpenDialog1;
  TActionList *ActionList1;
  TAction *Paused;
  TIBDatabase *IBDatabase1;
  TIBDataSet *IBDataSet1;
  TIBTransaction *IBTransaction1;
  TIBScript *IBScript1;
  TDataSource *DataSource1;
  void __fastcall IBScript1Parse(TObject *Sender, TIBParseKind AKind,
          AnsiString SQLText);
  void __fastcall IBScript1ParseError(TObject *Sender, AnsiString Error,
          AnsiString SQLText, int LineIndex);
  void __fastcall Button5Click(TObject *Sender);
  void __fastcall Button4Click(TObject *Sender);
  void __fastcall Button2Click(TObject *Sender);
  void __fastcall Button1Click(TObject *Sender);
  void __fastcall PausedUpdate(TObject *Sender);
  void __fastcall PausedExecute(TObject *Sender);
private:	// User declarations
public:		// User declarations
  __fastcall TfrmMain(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TfrmMain *frmMain;
//---------------------------------------------------------------------------
#endif
