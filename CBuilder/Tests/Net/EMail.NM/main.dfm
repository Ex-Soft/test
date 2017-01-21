object MainForm: TMainForm
  Left = 254
  Top = 60
  Width = 545
  Height = 510
  Caption = 'Test Internet protocols (FastNet)'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  Position = poScreenCenter
  Scaled = False
  OnClose = FormClose
  OnShow = FormShow
  PixelsPerInch = 96
  TextHeight = 13
  object EMailPageControl: TPageControl
    Left = 8
    Top = 8
    Width = 520
    Height = 468
    ActivePage = HTTPTabSheet
    TabIndex = 3
    TabOrder = 0
    object POP3TabSheet: TTabSheet
      Caption = 'POP3'
      object Label15: TLabel
        Left = 8
        Top = 12
        Width = 22
        Height = 13
        Caption = 'Host'
      end
      object Label16: TLabel
        Left = 8
        Top = 34
        Width = 36
        Height = 13
        Caption = 'User ID'
      end
      object Label17: TLabel
        Left = 8
        Top = 56
        Width = 46
        Height = 13
        Caption = 'Password'
      end
      object Label18: TLabel
        Left = 8
        Top = 78
        Width = 79
        Height = 13
        Caption = 'Attachment Path'
      end
      object Label19: TLabel
        Left = 8
        Top = 100
        Width = 159
        Height = 13
        Caption = 'From (Person that sent the E-Mail)'
      end
      object Label20: TLabel
        Left = 8
        Top = 122
        Width = 98
        Height = 13
        Caption = 'Subject of the E-Mail'
      end
      object POP3MemoLabelLabel: TLabel
        Left = 156
        Top = 185
        Width = 200
        Height = 13
        Alignment = taCenter
        AutoSize = False
        Caption = 'Message Body'
      end
      object Label35: TLabel
        Left = 8
        Top = 144
        Width = 61
        Height = 13
        Caption = 'Report Level'
      end
      object Label36: TLabel
        Left = 222
        Top = 330
        Width = 69
        Height = 13
        Caption = 'Status window'
      end
      object Label37: TLabel
        Left = 8
        Top = 166
        Width = 57
        Height = 13
        Caption = 'Message ID'
      end
      object POP3HostEdit: TEdit
        Left = 195
        Top = 8
        Width = 121
        Height = 21
        TabOrder = 0
      end
      object POP3UserIDEdit: TEdit
        Left = 195
        Top = 30
        Width = 121
        Height = 21
        TabOrder = 1
      end
      object POP3PasswordEdit: TEdit
        Left = 195
        Top = 52
        Width = 121
        Height = 21
        PasswordChar = '*'
        TabOrder = 2
      end
      object POP3AttachmentPathEdit: TEdit
        Left = 195
        Top = 74
        Width = 121
        Height = 21
        TabOrder = 3
      end
      object POP3FromPersonThatSentTheEMailEdit: TEdit
        Left = 195
        Top = 96
        Width = 121
        Height = 21
        TabOrder = 4
      end
      object POP3SubjectOfTheEMailEdit: TEdit
        Left = 195
        Top = 118
        Width = 121
        Height = 21
        TabOrder = 5
      end
      object POP3MessageBodyMemo: TMemo
        Left = 8
        Top = 199
        Width = 497
        Height = 129
        ScrollBars = ssVertical
        TabOrder = 6
      end
      object POP3ConnectDisconnectButton: TButton
        Left = 330
        Top = 35
        Width = 180
        Height = 25
        Caption = 'Connect/Disconnect'
        TabOrder = 8
        OnClick = POP3ConnectDisconnectButtonClick
      end
      object POP3GetMailMessageButton: TButton
        Left = 330
        Top = 60
        Width = 180
        Height = 25
        Caption = 'Get Mail Message'
        TabOrder = 9
        OnClick = POP3GetMailMessageButtonClick
      end
      object POP3DeleteMessageAfterReadingCheckBox: TCheckBox
        Left = 330
        Top = 10
        Width = 180
        Height = 17
        Caption = 'Delete message after reading'
        TabOrder = 7
      end
      object POP3ReportLevelComboBox: TComboBox
        Left = 195
        Top = 140
        Width = 121
        Height = 21
        Style = csDropDownList
        ItemHeight = 13
        ItemIndex = 0
        TabOrder = 10
        Text = 'None'
        Items.Strings = (
          'None'
          'Informational'
          'Basic'
          'Routines'
          'Debug'
          'Trace')
      end
      object POP3StatusWindowMemo: TMemo
        Left = 8
        Top = 344
        Width = 497
        Height = 91
        ScrollBars = ssVertical
        TabOrder = 11
      end
      object POP3SummarizeButton: TButton
        Left = 330
        Top = 85
        Width = 180
        Height = 25
        Caption = 'Summarize'
        TabOrder = 12
        OnClick = POP3SummarizeButtonClick
      end
      object POP3DeleteButton: TButton
        Left = 330
        Top = 110
        Width = 180
        Height = 25
        Caption = 'Delete'
        TabOrder = 13
        OnClick = POP3DeleteButtonClick
      end
      object POP3ResetButton: TButton
        Left = 330
        Top = 135
        Width = 180
        Height = 25
        Caption = 'Reset'
        TabOrder = 14
        OnClick = POP3ResetButtonClick
      end
      object POP3MessageIDEdit: TEdit
        Left = 195
        Top = 162
        Width = 121
        Height = 21
        TabOrder = 15
      end
    end
    object SMTPTabSheet: TTabSheet
      Caption = 'SMTP'
      ImageIndex = 1
      object Label1: TLabel
        Left = 8
        Top = 12
        Width = 22
        Height = 13
        Caption = 'Host'
      end
      object Label2: TLabel
        Left = 8
        Top = 34
        Width = 36
        Height = 13
        Caption = 'User ID'
      end
      object Label3: TLabel
        Left = 8
        Top = 56
        Width = 90
        Height = 13
        Caption = 'PostMessage.Date'
      end
      object Label4: TLabel
        Left = 8
        Top = 78
        Width = 128
        Height = 13
        Caption = 'PostMessage.FromAddress'
      end
      object Label5: TLabel
        Left = 8
        Top = 100
        Width = 118
        Height = 13
        Caption = 'PostMessage.FromName'
      end
      object Label6: TLabel
        Left = 8
        Top = 122
        Width = 132
        Height = 13
        Caption = 'PostMessage.LocalProgram'
      end
      object Label7: TLabel
        Left = 8
        Top = 144
        Width = 107
        Height = 13
        Caption = 'PostMessage.ReplyTo'
      end
      object Label8: TLabel
        Left = 8
        Top = 166
        Width = 103
        Height = 13
        Caption = 'PostMessage.Subject'
      end
      object Label9: TLabel
        Left = 71
        Top = 231
        Width = 118
        Height = 13
        Caption = 'PostMessage.ToAddress'
      end
      object Label10: TLabel
        Left = 50
        Top = 291
        Width = 161
        Height = 13
        Caption = 'PostMessage.ToBlindCarbonCopy'
      end
      object Label11: TLabel
        Left = 311
        Top = 231
        Width = 138
        Height = 13
        Caption = 'PostMessage.ToCarbonCopy'
      end
      object Label12: TLabel
        Left = 335
        Top = 291
        Width = 91
        Height = 13
        Caption = 'PostMessage.Body'
      end
      object Label13: TLabel
        Left = 96
        Top = 351
        Width = 69
        Height = 13
        Caption = 'Status window'
      end
      object Label14: TLabel
        Left = 317
        Top = 351
        Width = 126
        Height = 13
        Caption = 'PostMessage.Attachments'
      end
      object Label33: TLabel
        Left = 8
        Top = 188
        Width = 159
        Height = 13
        Caption = 'Name of the mailing list to Expand'
      end
      object Label34: TLabel
        Left = 8
        Top = 210
        Width = 61
        Height = 13
        Caption = 'Report Level'
      end
      object SMTPHostEdit: TEdit
        Left = 195
        Top = 8
        Width = 121
        Height = 21
        TabOrder = 0
      end
      object SMTPUserIDEdit: TEdit
        Left = 195
        Top = 30
        Width = 121
        Height = 21
        TabOrder = 1
      end
      object SMTPPostMessageDateEdit: TEdit
        Left = 195
        Top = 52
        Width = 121
        Height = 21
        TabOrder = 2
      end
      object SMTPPostMessageFromAddressEdit: TEdit
        Left = 195
        Top = 74
        Width = 121
        Height = 21
        TabOrder = 3
      end
      object SMTPPostMessageFromNameEdit: TEdit
        Left = 195
        Top = 96
        Width = 121
        Height = 21
        TabOrder = 4
      end
      object SMTPPostMessageLocalProgramEdit: TEdit
        Left = 195
        Top = 118
        Width = 121
        Height = 21
        TabOrder = 5
      end
      object SMTPPostMessageReplyToEdit: TEdit
        Left = 195
        Top = 140
        Width = 121
        Height = 21
        TabOrder = 6
      end
      object SMTPPostMessageSubjectEdit: TEdit
        Left = 195
        Top = 162
        Width = 121
        Height = 21
        TabOrder = 7
      end
      object SMTPPostMessageToAddressMemo: TMemo
        Left = 8
        Top = 245
        Width = 245
        Height = 42
        TabOrder = 8
      end
      object SMTPPostMessageToBlindCarbonCopyMemo: TMemo
        Left = 8
        Top = 305
        Width = 245
        Height = 42
        TabOrder = 9
      end
      object SMTPPostMessageToCarbonCopyMemo: TMemo
        Left = 258
        Top = 245
        Width = 245
        Height = 42
        TabOrder = 10
      end
      object SMTPPostMessageBodyMemo: TMemo
        Left = 258
        Top = 305
        Width = 245
        Height = 42
        TabOrder = 11
      end
      object SMTPStatusWindowMemo: TMemo
        Left = 8
        Top = 365
        Width = 245
        Height = 70
        TabOrder = 12
      end
      object SMTPPostMessageAttachmentsListBox: TListBox
        Left = 258
        Top = 365
        Width = 245
        Height = 70
        ItemHeight = 13
        TabOrder = 13
        OnKeyDown = SMTPPostMessageAttachmentsListBoxKeyDown
      end
      object SMTPConnectDisconnectButton: TButton
        Left = 330
        Top = 128
        Width = 180
        Height = 25
        Caption = 'Connect/Disconnect'
        TabOrder = 16
        OnClick = SMTPConnectDisconnectButtonClick
      end
      object SMTPSendMailButton: TButton
        Left = 330
        Top = 153
        Width = 180
        Height = 25
        Caption = 'SendMail'
        TabOrder = 17
        OnClick = SMTPSendMailButtonClick
      end
      object SMTPClearsEditFieldsAndParametersButton: TButton
        Left = 330
        Top = 178
        Width = 180
        Height = 25
        Caption = 'Clears edit fields and parameters'
        TabOrder = 18
        OnClick = SMTPClearsEditFieldsAndParametersButtonClick
      end
      object SMTPClearParamsPropertyCheckBox: TCheckBox
        Left = 330
        Top = 10
        Width = 150
        Height = 17
        Caption = 'ClearParams property'
        TabOrder = 14
      end
      object SMTPEncodeMethodRadioGroup: TRadioGroup
        Left = 330
        Top = 32
        Width = 100
        Height = 65
        Caption = 'Encode method'
        ItemIndex = 0
        Items.Strings = (
          'MIME'
          'UUEncode')
        TabOrder = 15
      end
      object SMTPNameOfTheMailingListToExpandEdit: TEdit
        Left = 195
        Top = 184
        Width = 121
        Height = 21
        TabOrder = 19
      end
      object SMTPExpandListButton: TButton
        Left = 330
        Top = 203
        Width = 180
        Height = 25
        Caption = 'Expand List'
        TabOrder = 20
        OnClick = SMTPExpandListButtonClick
      end
      object SMTPReportLevelComboBox: TComboBox
        Left = 195
        Top = 206
        Width = 121
        Height = 21
        Style = csDropDownList
        ItemHeight = 13
        ItemIndex = 0
        TabOrder = 21
        Text = 'None'
        Items.Strings = (
          'None'
          'Informational'
          'Basic'
          'Routines'
          'Debug'
          'Trace')
      end
      object CharsetComboBox: TComboBox
        Left = 330
        Top = 104
        Width = 180
        Height = 21
        Style = csDropDownList
        ItemHeight = 13
        ItemIndex = 0
        TabOrder = 22
        Text = 'koi-8r'
        Items.Strings = (
          'koi-8r'
          'win1251')
      end
    end
    object FTPTabSheet: TTabSheet
      Caption = 'FTP'
      ImageIndex = 3
      object Label22: TLabel
        Left = 8
        Top = 12
        Width = 22
        Height = 13
        Caption = 'Host'
      end
      object Label23: TLabel
        Left = 8
        Top = 34
        Width = 36
        Height = 13
        Caption = 'User ID'
      end
      object Label24: TLabel
        Left = 8
        Top = 56
        Width = 46
        Height = 13
        Caption = 'Password'
      end
      object Label25: TLabel
        Left = 384
        Top = 268
        Width = 72
        Height = 13
        Caption = 'Status Window'
      end
      object Label26: TLabel
        Left = 115
        Top = 216
        Width = 96
        Height = 13
        Caption = 'Directory List display'
      end
      object Label32: TLabel
        Left = 8
        Top = 78
        Width = 61
        Height = 13
        Caption = 'DoCommand'
      end
      object Label21: TLabel
        Left = 8
        Top = 100
        Width = 61
        Height = 13
        Caption = 'Report Level'
      end
      object FTPHostEdit: TEdit
        Left = 195
        Top = 8
        Width = 121
        Height = 21
        TabOrder = 0
      end
      object FTPUserIDEdit: TEdit
        Left = 195
        Top = 30
        Width = 121
        Height = 21
        TabOrder = 1
      end
      object FTPPasswordEdit: TEdit
        Left = 195
        Top = 52
        Width = 121
        Height = 21
        PasswordChar = '*'
        TabOrder = 2
      end
      object FTPConnectDisconnectButton: TButton
        Left = 330
        Top = 8
        Width = 180
        Height = 25
        Caption = 'Connect/Disconnect'
        TabOrder = 3
        OnClick = FTPConnectDisconnectButtonClick
      end
      object FTPListButton: TButton
        Left = 330
        Top = 33
        Width = 180
        Height = 25
        Caption = 'List'
        TabOrder = 4
        OnClick = FTPListButtonClick
      end
      object FTPChangeDirButton: TButton
        Left = 330
        Top = 58
        Width = 180
        Height = 25
        Caption = 'ChangeDir'
        TabOrder = 5
        OnClick = FTPChangeDirButtonClick
      end
      object FTPDownloadButton: TButton
        Left = 330
        Top = 83
        Width = 180
        Height = 25
        Caption = 'Download'
        TabOrder = 6
        OnClick = FTPDownloadButtonClick
      end
      object FTPUploadButton: TButton
        Left = 330
        Top = 108
        Width = 180
        Height = 25
        Caption = 'Upload'
        TabOrder = 7
        OnClick = FTPUploadButtonClick
      end
      object FTPUploadAppendButton: TButton
        Left = 330
        Top = 133
        Width = 180
        Height = 25
        Caption = 'UploadAppend'
        TabOrder = 8
        OnClick = FTPUploadAppendButtonClick
      end
      object FTPUploadUniqueButton: TButton
        Left = 330
        Top = 158
        Width = 180
        Height = 25
        Caption = 'UploadUnique'
        TabOrder = 9
        OnClick = FTPUploadUniqueButtonClick
      end
      object FTPUploadRestoreButton: TButton
        Left = 330
        Top = 183
        Width = 180
        Height = 25
        Caption = 'Upload Restore'
        TabOrder = 10
        OnClick = FTPUploadRestoreButtonClick
      end
      object FTPAbortButton: TButton
        Left = 330
        Top = 208
        Width = 180
        Height = 25
        Caption = 'Abort'
        TabOrder = 11
        OnClick = FTPAbortButtonClick
      end
      object FTPStatusWindowMemo: TMemo
        Left = 330
        Top = 285
        Width = 180
        Height = 130
        TabOrder = 12
      end
      object FTPListMemo: TMemo
        Left = 8
        Top = 231
        Width = 310
        Height = 90
        TabOrder = 13
      end
      object FTPTransferModeRadioGroup: TRadioGroup
        Left = 8
        Top = 118
        Width = 310
        Height = 36
        Caption = ' Transfer Mode '
        Columns = 3
        ItemIndex = 0
        Items.Strings = (
          'MODE_ASCII'
          'MODE_IMAGE'
          'MODE_BYTE')
        TabOrder = 14
      end
      object FTPStatusBar: TStatusBar
        Left = 0
        Top = 421
        Width = 512
        Height = 19
        Panels = <>
        SimplePanel = False
      end
      object GroupBox32: TGroupBox
        Left = 8
        Top = 160
        Width = 220
        Height = 56
        Caption = ' List Settings '
        TabOrder = 16
        object FTPTypeListRadioGroup: TRadioGroup
          Left = 6
          Top = 13
          Width = 137
          Height = 34
          Caption = ' Type list '
          Columns = 2
          ItemIndex = 0
          Items.Strings = (
            'List'
            'NList')
          TabOrder = 0
        end
        object FTPParseListCheckBox: TCheckBox
          Left = 148
          Top = 22
          Width = 69
          Height = 17
          Caption = 'Parse List'
          TabOrder = 1
        end
      end
      object FTPDoCommandEdit: TEdit
        Left = 195
        Top = 74
        Width = 121
        Height = 21
        TabOrder = 17
      end
      object FTPDoCommandButton: TButton
        Left = 330
        Top = 233
        Width = 180
        Height = 25
        Caption = 'DoCommand'
        TabOrder = 18
        OnClick = FTPDoCommandButtonClick
      end
      object FTPReportLevelComboBox: TComboBox
        Left = 195
        Top = 96
        Width = 121
        Height = 21
        Style = csDropDownList
        ItemHeight = 13
        ItemIndex = 0
        TabOrder = 19
        Text = 'None'
        Items.Strings = (
          'None'
          'Informational'
          'Basic'
          'Routines'
          'Debug'
          'Trace')
      end
      object FTPStringGrid: TStringGrid
        Left = 8
        Top = 322
        Width = 310
        Height = 95
        ColCount = 4
        DefaultColWidth = 75
        DefaultRowHeight = 13
        FixedCols = 0
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -5
        Font.Name = 'MS Sans Serif'
        Font.Style = []
        ParentFont = False
        TabOrder = 20
      end
      object FTPDownloadRestoreCheckBox: TCheckBox
        Left = 232
        Top = 168
        Width = 89
        Height = 41
        Caption = 'Download Restote'
        TabOrder = 21
      end
    end
    object HTTPTabSheet: TTabSheet
      Caption = 'HTTP'
      ImageIndex = 2
      object Label27: TLabel
        Left = 94
        Top = 190
        Width = 72
        Height = 13
        Caption = 'Header Display'
      end
      object Label28: TLabel
        Left = 350
        Top = 190
        Width = 61
        Height = 13
        Caption = 'Body Display'
      end
      object Label29: TLabel
        Left = 97
        Top = 310
        Width = 67
        Height = 13
        Caption = 'Status Display'
      end
      object Label30: TLabel
        Left = 345
        Top = 310
        Width = 70
        Height = 13
        Caption = 'Cookie Display'
      end
      object Label31: TLabel
        Left = 8
        Top = 12
        Width = 48
        Height = 13
        Caption = 'URL input'
      end
      object Label38: TLabel
        Left = 8
        Top = 100
        Width = 61
        Height = 13
        Caption = 'Report Level'
      end
      object HTTPGetButton: TButton
        Left = 330
        Top = 8
        Width = 180
        Height = 25
        Caption = 'HTTP Get'
        TabOrder = 0
        OnClick = HTTPGetButtonClick
      end
      object HTTPHeadButton: TButton
        Left = 330
        Top = 33
        Width = 180
        Height = 25
        Caption = 'HTTP Head'
        TabOrder = 1
        OnClick = HTTPHeadButtonClick
      end
      object HTTPOptionsButton: TButton
        Left = 330
        Top = 58
        Width = 180
        Height = 25
        Caption = 'HTTP Options'
        TabOrder = 2
        OnClick = HTTPOptionsButtonClick
      end
      object HTTPTraceButton: TButton
        Left = 330
        Top = 83
        Width = 180
        Height = 25
        Caption = 'HTTP Trace'
        TabOrder = 3
        OnClick = HTTPTraceButtonClick
      end
      object HTTPPutButton: TButton
        Left = 330
        Top = 108
        Width = 180
        Height = 25
        Caption = 'HTTP Put'
        TabOrder = 4
        OnClick = HTTPPutButtonClick
      end
      object HTTPPostButton: TButton
        Left = 330
        Top = 133
        Width = 180
        Height = 25
        Caption = 'HTTP Post'
        TabOrder = 5
        OnClick = HTTPPostButtonClick
      end
      object HTTPDeleteButton: TButton
        Left = 330
        Top = 158
        Width = 180
        Height = 25
        Caption = 'HTTP Delete'
        TabOrder = 6
        OnClick = HTTPDeleteButtonClick
      end
      object HTTPHeaderDisplayMemo: TMemo
        Left = 8
        Top = 204
        Width = 245
        Height = 101
        TabOrder = 7
      end
      object HTTPBodyDisplayMemo: TMemo
        Left = 258
        Top = 204
        Width = 245
        Height = 101
        TabOrder = 8
      end
      object HTTPStatusWindowMemo: TMemo
        Left = 8
        Top = 324
        Width = 245
        Height = 70
        TabOrder = 9
      end
      object HTTPURLInputEdit: TEdit
        Left = 195
        Top = 8
        Width = 121
        Height = 21
        TabOrder = 10
      end
      object HTTPCookieDisplayMemo: TMemo
        Left = 258
        Top = 324
        Width = 245
        Height = 70
        TabOrder = 11
      end
      object HTTPReportLevelComboBox: TComboBox
        Left = 195
        Top = 96
        Width = 121
        Height = 21
        Style = csDropDownList
        ItemHeight = 13
        ItemIndex = 0
        TabOrder = 12
        Text = 'None'
        Items.Strings = (
          'None'
          'Informational'
          'Basic'
          'Routines'
          'Debug'
          'Trace')
      end
      object CheckBoxInputFileMode: TCheckBox
        Left = 8
        Top = 30
        Width = 200
        Height = 17
        Alignment = taLeftJustify
        Caption = 'InputFileMode'
        TabOrder = 13
      end
    end
  end
  object NMSMTP: TNMSMTP
    Port = 25
    ReportLevel = 0
    OnDisconnect = NMSMTPDisconnect
    OnConnect = NMSMTPConnect
    OnInvalidHost = NMSMTPInvalidHost
    OnHostResolved = NMSMTPHostResolved
    OnStatus = NMSMTPStatus
    OnConnectionFailed = NMSMTPConnectionFailed
    OnPacketSent = NMSMTPPacketSent
    OnConnectionRequired = NMSMTPConnectionRequired
    EncodeType = uuMime
    ClearParams = True
    SubType = mtPlain
    Charset = 'us-ascii'
    OnRecipientNotFound = NMSMTPRecipientNotFound
    OnHeaderIncomplete = NMSMTPHeaderIncomplete
    OnSendStart = NMSMTPSendStart
    OnSuccess = NMSMTPSuccess
    OnFailure = NMSMTPFailure
    OnEncodeStart = NMSMTPEncodeStart
    OnEncodeEnd = NMSMTPEncodeEnd
    OnMailListReturn = NMSMTPMailListReturn
    OnAttachmentNotFound = NMSMTPAttachmentNotFound
    OnAuthenticationFailed = NMSMTPAuthenticationFailed
    Left = 224
  end
  object NMPOP3: TNMPOP3
    Port = 110
    ReportLevel = 0
    OnDisconnect = NMPOP3Disconnect
    OnConnect = NMPOP3Connect
    OnInvalidHost = NMPOP3InvalidHost
    OnHostResolved = NMPOP3HostResolved
    OnStatus = NMPOP3Status
    OnConnectionFailed = NMPOP3ConnectionFailed
    OnConnectionRequired = NMPOP3ConnectionRequired
    OnPacketRecvd = NMPOP3PacketRecvd
    Parse = True
    DeleteOnRead = False
    OnAuthenticationNeeded = NMPOP3AuthenticationNeeded
    OnAuthenticationFailed = NMPOP3AuthenticationFailed
    OnReset = NMPOP3Reset
    OnList = NMPOP3List
    OnRetrieveStart = NMPOP3RetrieveStart
    OnRetrieveEnd = NMPOP3RetrieveEnd
    OnSuccess = NMPOP3Success
    OnFailure = NMPOP3Failure
    OnDecodeStart = NMPOP3DecodeStart
    OnDecodeEnd = NMPOP3DecodeEnd
    Left = 192
  end
  object OpenDialog1: TOpenDialog
    Left = 472
  end
  object NMHTTP: TNMHTTP
    Port = 0
    ReportLevel = 0
    OnDisconnect = NMHTTPDisconnect
    OnConnect = NMHTTPConnect
    OnInvalidHost = NMHTTPInvalidHost
    OnHostResolved = NMHTTPHostResolved
    OnStatus = NMHTTPStatus
    OnConnectionFailed = NMHTTPConnectionFailed
    OnPacketRecvd = NMHTTPPacketRecvd
    OnPacketSent = NMHTTPPacketSent
    Body = 'Default.htm'
    Header = 'Head.txt'
    InputFileMode = True
    OutputFileMode = False
    OnAboutToSend = NMHTTPAboutToSend
    OnSuccess = NMHTTPSuccess
    OnFailure = NMHTTPFailure
    OnRedirect = NMHTTPRedirect
    OnAuthenticationNeeded = NMHTTPAuthenticationNeeded
    ProxyPort = 3128
    Left = 288
  end
  object NMFTP: TNMFTP
    Port = 21
    ReportLevel = 0
    OnDisconnect = NMFTPDisconnect
    OnConnect = NMFTPConnect
    OnInvalidHost = NMFTPInvalidHost
    OnHostResolved = NMFTPHostResolved
    OnStatus = NMFTPStatus
    OnConnectionFailed = NMFTPConnectionFailed
    OnPacketRecvd = NMFTPPacketRecvd
    OnPacketSent = NMFTPPacketSent
    OnError = NMFTPError
    OnConnectionRequired = NMFTPConnectionRequired
    OnTransactionStart = NMFTPTransactionStart
    OnTransactionStop = NMFTPTransactionStop
    OnAuthenticationNeeded = NMFTPAuthenticationNeeded
    OnAuthenticationFailed = NMFTPAuthenticationFailed
    OnFailure = NMFTPFailure
    OnSuccess = NMFTPSuccess
    OnListItem = NMFTPListItem
    OnUnSupportedFunction = NMFTPUnSupportedFunction
    Vendor = 2411
    ParseList = False
    ProxyPort = 3128
    Passive = True
    FirewallType = FTUser
    FWAuthenticate = False
    Left = 256
  end
  object IdBase64Decoder: TIdBase64Decoder
    Left = 330
  end
end
