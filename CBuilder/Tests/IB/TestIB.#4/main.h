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
        TLabel *ServerNameLabel;
        TLabel *UserNameLabel;
        TLabel *UserPasswordLabel;
        TEdit *ServerName;
        TEdit *UserName;
        TEdit *UserPassword;
        TButton *ServerExistsButton;
        TButton *TestServerVersionButton;
        TButton *TestUserExistButton;
        TButton *TestAddUserButton;
        TButton *TestSplitIBDatabaseNameButton;
        TButton *TestTCPIP2DNSButton;
        TButton *TestDNS2TCPIPButton;
        TButton *TestIsLocalPathButton;
        TButton *TestIsDNSPathButton;
        TEdit *DataBaseName;
        TEdit *FullDataBaseName;
        TLabel *DataBaseNameLabel;
        TLabel *FullDataBaseNameLabel;
        TLabel *ResultLabel;
        TEdit *Result;
        void __fastcall UserExistsButtonClick(TObject *Sender);
        void __fastcall ServerExistsButtonClick(TObject *Sender);
        void __fastcall TestServerVersionButtonClick(TObject *Sender);
        void __fastcall TestAddUserButtonClick(TObject *Sender);
        void __fastcall TestSplitIBDatabaseNameButtonClick(
          TObject *Sender);
        void __fastcall TestTCPIP2DNSButtonClick(TObject *Sender);
        void __fastcall TestDNS2TCPIPButtonClick(TObject *Sender);
        void __fastcall TestIsLocalPathButtonClick(TObject *Sender);
        void __fastcall TestIsDNSPathButtonClick(TObject *Sender);
private:	// User declarations
public:		// User declarations
        __fastcall TMainForm(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TMainForm *MainForm;
//---------------------------------------------------------------------------
#endif
