//---------------------------------------------------------------------------

#ifndef mainH
#define mainH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ComCtrls.hpp>
#include <ExtCtrls.hpp>
#include <ActnList.hpp>
//---------------------------------------------------------------------------
class TMainForm : public TForm
{
__published:	// IDE-managed Components
        TPageControl *PageControl;
        TTabSheet *DatabaseTabSheet;
        TTabSheet *Transaction1TabSheet;
        TTabSheet *Transaction2TabSheet;
        TGroupBox *GroupBox1;
        TLabel *Label5;
        TLabel *Label6;
        TButton *StartButton1;
        TButton *CommitButton1;
        TButton *RollbackButton1;
        TButton *ExecButton1;
        TComboBox *SQLComboBox1;
        TEdit *ResultEdit1;
        TGroupBox *Transaction1GroupBox;
        TLabel *Label4;
        TMemo *TransactionMemo1;
        TListBox *TPBListBox1;
        TButton *ShowTPBButton1;
        TGroupBox *GroupBox2;
        TLabel *Label8;
        TLabel *Label9;
        TButton *StartButton2;
        TButton *CommitButton2;
        TButton *RollbackButton2;
        TButton *ExecButton2;
        TComboBox *SQLComboBox2;
        TEdit *ResultEdit2;
        TGroupBox *Transaction2GroupBox;
        TLabel *Label7;
        TMemo *TransactionMemo2;
        TListBox *TPBListBox2;
        TButton *ShowTPBButton2;
        TGroupBox *DatabaseGroupBox;
        TLabel *Label1;
        TLabel *Label2;
        TLabel *Label3;
        TEdit *ServerEdit;
        TEdit *DataBaseEdit;
        TMemo *DataBaseMemo;
        TButton *OpenButton;
        TButton *CloseButton;
        TTabSheet *IBDatabaseInfoTabSheet;
        TGroupBox *DatabaseInfoGroupBox;
        TLabeledEdit *DBFileName;
        TLabeledEdit *DBSQLDialect;
        TButton *GetIBDatabaseInfoButton;
        TMemo *IBExtractMemo;
        TComboBox *ExtractObjectTypesComboBox;
        TComboBox *ExtractTypeComboBox;
        TLabel *Label10;
        TLabel *Label11;
        TLabeledEdit *ObjectNameLabeledEdit;
        TTabSheet *StoredProcTabSheet;
        TGroupBox *GroupBox3;
        TGroupBox *GroupBox4;
        TLabeledEdit *SP1Arg1;
        TLabeledEdit *SP1Arg2;
        TButton *ExecSP1Button;
        TLabeledEdit *SP1Result;
        TGroupBox *GroupBox5;
        TLabeledEdit *SP2Arg1;
        TButton *ExecSP2Button;
        TLabeledEdit *SP2Result;
        TTabSheet *PrimaryKeyTabSheet;
        TGroupBox *GroupBox6;
        TLabeledEdit *Centre;
        TLabeledEdit *Institution;
        TLabeledEdit *Node;
        TLabeledEdit *Year;
        TLabeledEdit *Kind;
        TLabeledEdit *Branch;
        TLabeledEdit *ContrNo;
        TLabeledEdit *CertNo;
        TLabeledEdit *Diff;
        TButton *FillTableCertifErsatz;
        TButton *FillTableCertifHash;
        TButton *SelectFromCertifErsatz;
        TButton *SelectFromCertifHash;
        TTabSheet *DatatypesTabSheet;
        TGroupBox *GroupBox7;
        TRadioGroup *ReadDatatypes;
        TButton *DoReadDatatypesButton;
        TListView *ListView;
        TGroupBox *GroupBox8;
        TComboBox *ColumnNameComboBox;
        TLabel *Label13;
        TComboBox *AsTypeComboBox;
        TEdit *ValueEdit;
        TButton *GetValueButton;
        TButton *SetValueButton;
        TLabeledEdit *ServerVersion;
        TTabSheet *TabSheetAdditional;
        TGroupBox *GroupBoxIBDatabaseINI;
        TButton *IBDatabaseINIButton;
        TRadioGroup *RadioGroupIBDatabaseINIAction;
        TGroupBox *GroupBoxIBScript;
        TButton *IBScriptButton;
        TGroupBox *IBSQLParserGroupBox;
        TButton *IBSQLParserButton;
        TMemo *MemoPlan1;
        TMemo *MemoPlan2;
        TCheckBox *CheckBoxFetchAll1;
        TCheckBox *CheckBoxFetchAll2;
        void __fastcall OpenButtonClick(TObject *Sender);
        void __fastcall StartButton1Click(TObject *Sender);
        void __fastcall CommitButton1Click(TObject *Sender);
        void __fastcall RollbackButton1Click(TObject *Sender);
        void __fastcall ExecButton1Click(TObject *Sender);
        void __fastcall CloseButtonClick(TObject *Sender);
        void __fastcall ShowTPBButton1Click(TObject *Sender);
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall GetIBDatabaseInfoButtonClick(TObject *Sender);
        void __fastcall ExecSP1ButtonClick(TObject *Sender);
        void __fastcall ExecSP2ButtonClick(TObject *Sender);
        void __fastcall FillTableCertifErsatzClick(TObject *Sender);
        void __fastcall FillTableCertifHashClick(TObject *Sender);
        void __fastcall SelectFromCertifErsatzClick(TObject *Sender);
        void __fastcall SelectFromCertifHashClick(TObject *Sender);
        void __fastcall GetValueButtonClick(TObject *Sender);
        void __fastcall SetValueButtonClick(TObject *Sender);
        void __fastcall ReadDatatypesClick(TObject *Sender);
        void __fastcall DoReadDatatypesButtonClick(TObject *Sender);
        void __fastcall IBDatabaseINIButtonClick(TObject *Sender);
        void __fastcall IBScriptButtonClick(TObject *Sender);
        void __fastcall IBSQLParserButtonClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TMainForm(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TMainForm *MainForm;
//---------------------------------------------------------------------------
#endif
