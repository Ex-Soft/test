//---------------------------------------------------------------------------

#ifndef mainH
#define mainH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
//---------------------------------------------------------------------------
class TMainForm : public TForm
{
__published:	// IDE-managed Components
        TGroupBox *InterBaseAdminGroupBox;
        TGroupBox *IBServerPropertiesGroupBox;
        TButton *VersionButton;
        TGroupBox *IBSecurityServiceGroupBox;
        TButton *AddUserButton;
        TButton *ModifyUserButton;
        TButton *DeleteUserButton;
        TButton *ListUserButton;
        TLabel *ServerNameLabel;
        TEdit *ServerName;
        TEdit *UserName;
        TEdit *Password;
        TLabel *UserNameLabel;
        TLabel *PasswordLabel;
        TGroupBox *DataGroupBox;
        TGroupBox *IBStoredProcGroupBox;
        TButton *FindContractButton;
        TButton *FindCertifButton;
        TGroupBox *IBSQLGroupBox;
        TButton *DoubleSQLButton;
        TButton *DoubleQueryButton;
        TLabel *BranchLabel;
        TLabel *MinRiskNoLabel;
        TEdit *Branch;
        TEdit *MinRiskNo;
        TEdit *MaxRiskNo;
        TLabel *MaxRiskNoLabel;
        TGroupBox *ResultGroupBox;
        TListBox *ResultMemo;
        TButton *LicenseButton;
        TButton *LicenseMaskButton;
        TCheckBox *IBAPICheckBox;
        TLabel *Label1;
        TComboBox *GDBComboBox;
        void __fastcall FindContractButtonClick(TObject *Sender);
        void __fastcall FindCertifButtonClick(TObject *Sender);
        void __fastcall AddUserButtonClick(TObject *Sender);
        void __fastcall ModifyUserButtonClick(TObject *Sender);
        void __fastcall DeleteUserButtonClick(TObject *Sender);
        void __fastcall ListUserButtonClick(TObject *Sender);
        void __fastcall VersionButtonClick(TObject *Sender);
        void __fastcall DoubleSQLButtonClick(TObject *Sender);
        void __fastcall DoubleQueryButtonClick(TObject *Sender);
        void __fastcall LicenseButtonClick(TObject *Sender);
        void __fastcall LicenseMaskButtonClick(TObject *Sender);
        void __fastcall IBAPICheckBoxClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TMainForm(TComponent* Owner);
        void __fastcall AddUserByIBAPI(void);
        void __fastcall VersionByIBAPI(void);
};
//---------------------------------------------------------------------------
extern PACKAGE TMainForm *MainForm;
//---------------------------------------------------------------------------
#endif
