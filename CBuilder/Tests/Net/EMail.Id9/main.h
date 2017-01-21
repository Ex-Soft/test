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
#include <IdBaseComponent.hpp>
#include <IdComponent.hpp>
#include <IdMessageClient.hpp>
#include <IdPOP3.hpp>
#include <IdTCPClient.hpp>
#include <IdTCPConnection.hpp>
#include <IdMessage.hpp>
#include <IdIntercept.hpp>
#include <IdLogBase.hpp>
#include <IdLogDebug.hpp>
#include "CGAUGES.h"
//---------------------------------------------------------------------------
class TMainForm : public TForm
{
__published:	// IDE-managed Components
        TPageControl *EMailPageControl;
        TTabSheet *POP3TabSheet;
        TIdPOP3 *IdPOP3;
        TLabel *Label15;
        TLabel *Label16;
        TLabel *Label17;
        TLabel *Label18;
        TLabel *Label19;
        TLabel *Label20;
        TLabel *Label37;
        TLabel *POP3MemoLabelLabel;
        TMemo *POP3MessageBodyMemo;
        TLabel *Label36;
        TMemo *POP3StatusWindowMemo;
        TEdit *POP3HostEdit;
        TEdit *POP3UserIDEdit;
        TEdit *POP3PasswordEdit;
        TEdit *POP3AttachmentPathEdit;
        TEdit *POP3FromPersonThatSentTheEMailEdit;
        TEdit *POP3SubjectOfTheEMailEdit;
        TEdit *POP3MessageIDEdit;
        TCheckBox *POP3DeleteMessageAfterReadingCheckBox;
        TButton *POP3ConnectDisconnectButton;
        TButton *POP3GetMailMessageButton;
        TButton *POP3SummarizeButton;
        TButton *POP3DeleteButton;
        TButton *POP3ResetButton;
        TIdMessage *IdMessagePOP3;
        TIdLogDebug *IdLogDebugPOP3;
        TCheckBox *POP3IdLogDebugToFileCheckBox;
        TCheckBox *IdLogDebugCheckBox;
        TLabel *FileNamePOP3Label;
        TCGauge *CGaugePOP3;
        TTabSheet *SMTPTabSheet;
        TLabel *Label1;
        TLabel *Label2;
        TLabel *Label3;
        TLabel *Label4;
        TLabel *Label5;
        TLabel *Label6;
        TLabel *Label7;
        TLabel *Label8;
        TLabel *Label33;
        TLabel *Label34;
        TLabel *Label9;
        TMemo *SMTPPostMessageToAddressMemo;
        TLabel *Label10;
        TMemo *SMTPPostMessageToBlindCarbonCopyMemo;
        TLabel *Label13;
        TMemo *SMTPStatusWindowMemo;
        TListBox *SMTPPostMessageAttachmentsListBox;
        TLabel *Label14;
        TMemo *SMTPPostMessageBodyMemo;
        TLabel *Label12;
        TMemo *SMTPPostMessageToCarbonCopyMemo;
        TLabel *Label11;
        TComboBox *SMTPReportLevelComboBox;
        TEdit *SMTPNameOfTheMailingListToExpandEdit;
        TEdit *SMTPPostMessageSubjectEdit;
        TEdit *SMTPPostMessageReplyToEdit;
        TEdit *SMTPPostMessageLocalProgramEdit;
        TEdit *SMTPPostMessageFromNameEdit;
        TEdit *SMTPPostMessageFromAddressEdit;
        TEdit *SMTPPostMessageDateEdit;
        TEdit *SMTPUserIDEdit;
        TEdit *SMTPHostEdit;
        TCheckBox *SMTPClearParamsPropertyCheckBox;
        TRadioGroup *SMTPEncodeMethodRadioGroup;
        TComboBox *CharsetComboBox;
        TButton *SMTPConnectDisconnectButton;
        TButton *SMTPSendMailButton;
        TButton *SMTPClearsEditFieldsAndParametersButton;
        TButton *SMTPExpandListButton;
        void __fastcall FormCreate(TObject *Sender);
        void __fastcall POP3ConnectDisconnectButtonClick(TObject *Sender);
        void __fastcall IdPOP3Connected(TObject *Sender);
        void __fastcall IdPOP3Disconnected(TObject *Sender);
        void __fastcall IdPOP3Status(TObject *axSender, const TIdStatus axStatus, const AnsiString asStatusText);
        void __fastcall IdPOP3Work(TObject *Sender, TWorkMode AWorkMode, const int AWorkCount);
        void __fastcall IdPOP3WorkBegin(TObject *Sender, TWorkMode AWorkMode, const int AWorkCountMax);
        void __fastcall IdPOP3WorkEnd(TObject *Sender, TWorkMode AWorkMode);
        void __fastcall POP3GetMailMessageButtonClick(TObject *Sender);
        void __fastcall FormClose(TObject *Sender, TCloseAction &Action);
        void __fastcall POP3SummarizeButtonClick(TObject *Sender);
        void __fastcall POP3DeleteButtonClick(TObject *Sender);
        void __fastcall POP3ResetButtonClick(TObject *Sender);

        /*void __fastcall IdLogDebugPOP3Connect(TObject *Sender); // Indy 8 */
        void __fastcall IdLogDebugPOP3Connect(TIdConnectionIntercept *ASender);
        void __fastcall IdLogDebugPOP3Disconnect(TIdConnectionIntercept *ASender);
        void __fastcall IdLogDebugPOP3Receive(TIdConnectionIntercept *ASender, TStream *AStream);
        void __fastcall IdLogDebugPOP3Send(TIdConnectionIntercept *ASender,TStream *AStream);
        /*void __fastcall IdLogDebugPOP3LogItem(TComponent *ASender, AnsiString &AText); // Indy 8 */
private:	// User declarations
public:		// User declarations
        long int
          MailCount,
          CurrMsg;

        bool
          RetrieveHeaderStart,
          RetrieveHeaderStop,
          RetrieveRawStart,
          RetrieveRawStop;

        unsigned long int
          HeaderSize,
          MsgSize,
          OldPartsCount;

        unsigned int
          BuffSize;

        char
          *Buff;  

        TFileStream
          *LogFile;

        __fastcall TMainForm(TComponent* Owner);
        void __fastcall POP3UpdateButtons(void);
};
//---------------------------------------------------------------------------
extern PACKAGE TMainForm *MainForm;
//---------------------------------------------------------------------------
#endif
