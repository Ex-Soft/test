//---------------------------------------------------------------------------

#ifndef mainH
#define mainH
//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
#include <ComCtrls.hpp>
#include <Dialogs.hpp>
#include <ExtCtrls.hpp>
#include <NMpop3.hpp>
#include <NMsmtp.hpp>
#include <Psock.hpp>
#include <NMHttp.hpp>
#include <NMFtp.hpp>
#include <Grids.hpp>
#include <IdBaseComponent.hpp>
#include <IdCoder.hpp>
#include <IdCoder3To4.hpp>
//---------------------------------------------------------------------------
class TMainForm : public TForm
{
__published:	// IDE-managed Components
        TPageControl *EMailPageControl;
        TTabSheet *POP3TabSheet;
        TTabSheet *SMTPTabSheet;
        TNMSMTP *NMSMTP;
        TNMPOP3 *NMPOP3;
        TLabel *Label1;
        TEdit *SMTPHostEdit;
        TLabel *Label2;
        TEdit *SMTPUserIDEdit;
        TLabel *Label3;
        TEdit *SMTPPostMessageDateEdit;
        TLabel *Label4;
        TEdit *SMTPPostMessageFromAddressEdit;
        TLabel *Label5;
        TEdit *SMTPPostMessageFromNameEdit;
        TLabel *Label6;
        TEdit *SMTPPostMessageLocalProgramEdit;
        TLabel *Label7;
        TEdit *SMTPPostMessageReplyToEdit;
        TLabel *Label8;
        TEdit *SMTPPostMessageSubjectEdit;
        TLabel *Label9;
        TMemo *SMTPPostMessageToAddressMemo;
        TLabel *Label10;
        TMemo *SMTPPostMessageToBlindCarbonCopyMemo;
        TLabel *Label11;
        TMemo *SMTPPostMessageToCarbonCopyMemo;
        TLabel *Label12;
        TMemo *SMTPPostMessageBodyMemo;
        TLabel *Label13;
        TMemo *SMTPStatusWindowMemo;
        TLabel *Label14;
        TListBox *SMTPPostMessageAttachmentsListBox;
        TButton *SMTPConnectDisconnectButton;
        TButton *SMTPSendMailButton;
        TButton *SMTPClearsEditFieldsAndParametersButton;
        TCheckBox *SMTPClearParamsPropertyCheckBox;
        TOpenDialog *OpenDialog1;
        TRadioGroup *SMTPEncodeMethodRadioGroup;
        TLabel *Label15;
        TLabel *Label16;
        TLabel *Label17;
        TLabel *Label18;
        TLabel *Label19;
        TLabel *Label20;
        TEdit *POP3HostEdit;
        TEdit *POP3UserIDEdit;
        TEdit *POP3PasswordEdit;
        TEdit *POP3AttachmentPathEdit;
        TEdit *POP3FromPersonThatSentTheEMailEdit;
        TEdit *POP3SubjectOfTheEMailEdit;
        TLabel *POP3MemoLabelLabel;
        TMemo *POP3MessageBodyMemo;
        TButton *POP3ConnectDisconnectButton;
        TButton *POP3GetMailMessageButton;
        TCheckBox *POP3DeleteMessageAfterReadingCheckBox;
        TTabSheet *HTTPTabSheet;
        TNMHTTP *NMHTTP;
        TNMFTP *NMFTP;
        TTabSheet *FTPTabSheet;
        TLabel *Label22;
        TEdit *FTPHostEdit;
        TLabel *Label23;
        TEdit *FTPUserIDEdit;
        TLabel *Label24;
        TEdit *FTPPasswordEdit;
        TButton *FTPConnectDisconnectButton;
        TButton *FTPListButton;
        TButton *FTPChangeDirButton;
        TButton *FTPDownloadButton;
        TButton *FTPUploadButton;
        TButton *FTPUploadAppendButton;
        TButton *FTPUploadUniqueButton;
        TButton *FTPUploadRestoreButton;
        TButton *FTPAbortButton;
        TLabel *Label25;
        TMemo *FTPStatusWindowMemo;
        TLabel *Label26;
        TMemo *FTPListMemo;
        TRadioGroup *FTPTransferModeRadioGroup;
        TStatusBar *FTPStatusBar;
        TButton *HTTPGetButton;
        TButton *HTTPHeadButton;
        TButton *HTTPOptionsButton;
        TButton *HTTPTraceButton;
        TButton *HTTPPutButton;
        TButton *HTTPPostButton;
        TButton *HTTPDeleteButton;
        TLabel *Label27;
        TLabel *Label28;
        TMemo *HTTPHeaderDisplayMemo;
        TMemo *HTTPBodyDisplayMemo;
        TLabel *Label29;
        TLabel *Label30;
        TMemo *HTTPStatusWindowMemo;
        TLabel *Label31;
        TEdit *HTTPURLInputEdit;
        TMemo *HTTPCookieDisplayMemo;
        TGroupBox *GroupBox32;
        TRadioGroup *FTPTypeListRadioGroup;
        TCheckBox *FTPParseListCheckBox;
        TLabel *Label32;
        TEdit *FTPDoCommandEdit;
        TEdit *SMTPNameOfTheMailingListToExpandEdit;
        TLabel *Label33;
        TButton *SMTPExpandListButton;
        TComboBox *SMTPReportLevelComboBox;
        TLabel *Label34;
        TLabel *Label35;
        TComboBox *POP3ReportLevelComboBox;
        TLabel *Label36;
        TMemo *POP3StatusWindowMemo;
        TButton *POP3SummarizeButton;
        TButton *POP3DeleteButton;
        TButton *POP3ResetButton;
        TEdit *POP3MessageIDEdit;
        TLabel *Label37;
        TButton *FTPDoCommandButton;
        TLabel *Label21;
        TComboBox *FTPReportLevelComboBox;
        TStringGrid *FTPStringGrid;
        TLabel *Label38;
        TComboBox *HTTPReportLevelComboBox;
        TCheckBox *FTPDownloadRestoreCheckBox;
        TComboBox *CharsetComboBox;
        TIdBase64Decoder *IdBase64Decoder;
        TCheckBox *CheckBoxInputFileMode;
        void __fastcall SMTPConnectDisconnectButtonClick(TObject *Sender);
        void __fastcall SMTPSendMailButtonClick(TObject *Sender);
        void __fastcall SMTPClearsEditFieldsAndParametersButtonClick(TObject *Sender);
        void __fastcall SMTPPostMessageAttachmentsListBoxKeyDown(TObject *Sender, WORD &Key,
          TShiftState Shift);
        void __fastcall NMSMTPAttachmentNotFound(AnsiString Filename);
        void __fastcall NMSMTPAuthenticationFailed(bool &Handled);
        void __fastcall NMSMTPConnect(TObject *Sender);
        void __fastcall NMSMTPSendStart(TObject *Sender);
        void __fastcall NMSMTPEncodeStart(AnsiString Filename);
        void __fastcall NMSMTPEncodeEnd(AnsiString Filename);
        void __fastcall NMSMTPFailure(TObject *Sender);
        void __fastcall NMSMTPSuccess(TObject *Sender);
        void __fastcall NMSMTPHeaderIncomplete(bool &handled, int hiType);
        void __fastcall NMSMTPRecipientNotFound(AnsiString Recipient);
        void __fastcall POP3ConnectDisconnectButtonClick(TObject *Sender);
        void __fastcall NMPOP3Connect(TObject *Sender);
        void __fastcall POP3GetMailMessageButtonClick(TObject *Sender);
        void __fastcall NMPOP3RetrieveEnd(TObject *Sender);
        void __fastcall NMPOP3DecodeStart(AnsiString &FileName);
        void __fastcall FTPConnectDisconnectButtonClick(TObject *Sender);
        void __fastcall FTPListButtonClick(TObject *Sender);
        void __fastcall FTPChangeDirButtonClick(TObject *Sender);
        void __fastcall FTPDownloadButtonClick(TObject *Sender);
        void __fastcall NMFTPDisconnect(TObject *Sender);
        void __fastcall NMFTPPacketRecvd(TObject *Sender);
        void __fastcall NMFTPPacketSent(TObject *Sender);
        void __fastcall NMFTPTransactionStart(TObject *Sender);
        void __fastcall NMFTPTransactionStop(TObject *Sender);
        void __fastcall FTPUploadButtonClick(TObject *Sender);
        void __fastcall FTPUploadAppendButtonClick(TObject *Sender);
        void __fastcall FTPUploadUniqueButtonClick(TObject *Sender);
        void __fastcall NMFTPFailure(bool &Handled, TCmdType Trans_Type);
        void __fastcall NMFTPSuccess(TCmdType Trans_Type);
        void __fastcall FTPUploadRestoreButtonClick(TObject *Sender);
        void __fastcall FTPAbortButtonClick(TObject *Sender);
        void __fastcall NMFTPConnect(TObject *Sender);
        void __fastcall NMFTPListItem(AnsiString Listing);
        void __fastcall HTTPGetButtonClick(TObject *Sender);
        void __fastcall HTTPHeadButtonClick(TObject *Sender);
        void __fastcall HTTPOptionsButtonClick(TObject *Sender);
        void __fastcall HTTPTraceButtonClick(TObject *Sender);
        void __fastcall HTTPPutButtonClick(TObject *Sender);
        void __fastcall HTTPPostButtonClick(TObject *Sender);
        void __fastcall HTTPDeleteButtonClick(TObject *Sender);
        void __fastcall NMHTTPAuthenticationNeeded(TObject *Sender);
        void __fastcall NMHTTPFailure(CmdType Cmd);
        void __fastcall NMHTTPRedirect(bool &Handled);
        void __fastcall NMHTTPSuccess(CmdType Cmd);
        void __fastcall NMFTPStatus(TComponent *Sender,
          AnsiString Status);
        void __fastcall NMSMTPDisconnect(TObject *Sender);
        void __fastcall SMTPExpandListButtonClick(TObject *Sender);
        void __fastcall NMSMTPMailListReturn(AnsiString MailAddress);
        void __fastcall FormShow(TObject *Sender);
        void __fastcall NMSMTPConnectionFailed(TObject *Sender);
        void __fastcall NMSMTPStatus(TComponent *Sender,
          AnsiString Status);
        void __fastcall NMSMTPPacketSent(TObject *Sender);
        void __fastcall NMPOP3Status(TComponent *Sender,
          AnsiString Status);
        void __fastcall NMPOP3AuthenticationFailed(bool &Handled);
        void __fastcall NMSMTPConnectionRequired(bool &Handled);
        void __fastcall NMSMTPHostResolved(TComponent *Sender);
        void __fastcall NMSMTPInvalidHost(bool &Handled);
        void __fastcall NMPOP3AuthenticationNeeded(bool &Handled);
        void __fastcall NMPOP3List(int Msg, int Size);
        void __fastcall POP3ResetButtonClick(TObject *Sender);
        void __fastcall NMPOP3Reset(TObject *Sender);
        void __fastcall POP3SummarizeButtonClick(TObject *Sender);
        void __fastcall NMPOP3RetrieveStart(TObject *Sender);
        void __fastcall POP3DeleteButtonClick(TObject *Sender);
        void __fastcall NMPOP3ConnectionFailed(TObject *Sender);
        void __fastcall NMPOP3ConnectionRequired(bool &Handled);
        void __fastcall NMPOP3DecodeEnd(TObject *Sender);
        void __fastcall NMPOP3Disconnect(TObject *Sender);
        void __fastcall NMPOP3Failure(TObject *Sender);
        void __fastcall NMPOP3HostResolved(TComponent *Sender);
        void __fastcall NMPOP3InvalidHost(bool &Handled);
        void __fastcall NMPOP3PacketRecvd(TObject *Sender);
        void __fastcall NMPOP3Success(TObject *Sender);
        void __fastcall FTPDoCommandButtonClick(TObject *Sender);
        void __fastcall NMFTPAuthenticationFailed(bool &Handled);
        void __fastcall NMFTPAuthenticationNeeded(bool &Handled);
        void __fastcall NMFTPConnectionFailed(TObject *Sender);
        void __fastcall NMFTPConnectionRequired(bool &Handled);
        void __fastcall NMFTPError(TComponent *Sender, WORD Errno,
          AnsiString Errmsg);
        void __fastcall NMFTPHostResolved(TComponent *Sender);
        void __fastcall NMFTPInvalidHost(bool &Handled);
        void __fastcall NMFTPUnSupportedFunction(TCmdType Trans_Type);
        void __fastcall NMHTTPAboutToSend(TObject *Sender);
        void __fastcall NMHTTPStatus(TComponent *Sender,
          AnsiString Status);
        void __fastcall NMHTTPConnect(TObject *Sender);
        void __fastcall NMHTTPConnectionFailed(TObject *Sender);
        void __fastcall NMHTTPDisconnect(TObject *Sender);
        void __fastcall NMHTTPHostResolved(TComponent *Sender);
        void __fastcall NMHTTPInvalidHost(bool &Handled);
        void __fastcall NMHTTPPacketRecvd(TObject *Sender);
        void __fastcall NMHTTPPacketSent(TObject *Sender);
        void __fastcall FormClose(TObject *Sender, TCloseAction &Action);
private:	// User declarations
public:		// User declarations
        __fastcall TMainForm(TComponent* Owner);
        bool POP3SummaryWorking;
        bool POP3GetMailMessageWorking;
        AnsiString LastStatus;
        void __fastcall SMTPUpdateButtons(void);
        void __fastcall POP3UpdateButtons(void);
        void __fastcall FTPUpdateButtons(void);
        void __fastcall IdBase64DecoderCodedData(TComponent *aComponent, const AnsiString aString);
        void __fastcall IdBase64DecoderNotification(TComponent *aComponent, int aInt, const AnsiString aString);
};
//---------------------------------------------------------------------------
extern PACKAGE TMainForm *MainForm;
//---------------------------------------------------------------------------
#endif
