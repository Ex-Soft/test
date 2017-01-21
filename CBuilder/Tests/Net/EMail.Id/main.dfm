object MainForm: TMainForm
  Left = 204
  Top = 33
  Width = 545
  Height = 510
  Caption = 'Test Internet protocols (Indy)'
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
  OnCreate = FormCreate
  PixelsPerInch = 96
  TextHeight = 13
  object EMailPageControl: TPageControl
    Left = 0
    Top = 0
    Width = 537
    Height = 483
    ActivePage = SMTPTabSheet
    Align = alClient
    TabIndex = 1
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
      object Label37: TLabel
        Left = 8
        Top = 144
        Width = 57
        Height = 13
        Caption = 'Message ID'
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
      object Label36: TLabel
        Left = 222
        Top = 309
        Width = 69
        Height = 13
        Caption = 'Status window'
      end
      object FileNamePOP3Label: TLabel
        Left = 8
        Top = 418
        Width = 513
        Height = 13
        Alignment = taCenter
        AutoSize = False
        Visible = False
      end
      object CGaugePOP3: TCGauge
        Left = 8
        Top = 435
        Width = 513
        Height = 18
        Font.Charset = DEFAULT_CHARSET
        Font.Color = clWindowText
        Font.Height = -11
        Font.Name = 'MS Sans Serif'
        Font.Style = [fsBold]
        ForeColor = clBlue
        BackColor = clWindow
        ParentFont = False
        Visible = False
      end
      object POP3MessageBodyMemo: TMemo
        Left = 8
        Top = 199
        Width = 513
        Height = 107
        ScrollBars = ssVertical
        TabOrder = 0
      end
      object POP3StatusWindowMemo: TMemo
        Left = 8
        Top = 323
        Width = 513
        Height = 91
        ScrollBars = ssVertical
        TabOrder = 1
      end
      object POP3HostEdit: TEdit
        Left = 195
        Top = 8
        Width = 121
        Height = 21
        TabOrder = 2
      end
      object POP3UserIDEdit: TEdit
        Left = 195
        Top = 30
        Width = 121
        Height = 21
        TabOrder = 3
      end
      object POP3PasswordEdit: TEdit
        Left = 195
        Top = 52
        Width = 121
        Height = 21
        PasswordChar = '*'
        TabOrder = 4
      end
      object POP3AttachmentPathEdit: TEdit
        Left = 195
        Top = 74
        Width = 121
        Height = 21
        TabOrder = 5
      end
      object POP3FromPersonThatSentTheEMailEdit: TEdit
        Left = 195
        Top = 96
        Width = 121
        Height = 21
        TabOrder = 6
      end
      object POP3SubjectOfTheEMailEdit: TEdit
        Left = 195
        Top = 118
        Width = 121
        Height = 21
        TabOrder = 7
      end
      object POP3MessageIDEdit: TEdit
        Left = 195
        Top = 140
        Width = 121
        Height = 21
        TabOrder = 8
      end
      object POP3DeleteMessageAfterReadingCheckBox: TCheckBox
        Left = 330
        Top = 10
        Width = 180
        Height = 17
        Caption = 'Delete message after reading'
        TabOrder = 9
      end
      object POP3ConnectDisconnectButton: TButton
        Left = 330
        Top = 58
        Width = 180
        Height = 25
        Caption = 'Connect/Disconnect'
        TabOrder = 10
        OnClick = POP3ConnectDisconnectButtonClick
      end
      object POP3GetMailMessageButton: TButton
        Left = 330
        Top = 83
        Width = 180
        Height = 25
        Caption = 'Get Mail Message'
        TabOrder = 11
        OnClick = POP3GetMailMessageButtonClick
      end
      object POP3SummarizeButton: TButton
        Left = 330
        Top = 108
        Width = 180
        Height = 25
        Caption = 'Summarize'
        TabOrder = 12
        OnClick = POP3SummarizeButtonClick
      end
      object POP3DeleteButton: TButton
        Left = 330
        Top = 133
        Width = 180
        Height = 25
        Caption = 'Delete'
        TabOrder = 13
        OnClick = POP3DeleteButtonClick
      end
      object POP3ResetButton: TButton
        Left = 330
        Top = 158
        Width = 180
        Height = 25
        Caption = 'Reset'
        TabOrder = 14
        OnClick = POP3ResetButtonClick
      end
      object POP3IdLogDebugToFileCheckBox: TCheckBox
        Left = 330
        Top = 31
        Width = 180
        Height = 17
        Caption = 'IdLogDebug to file'
        TabOrder = 15
      end
      object IdLogDebugCheckBox: TCheckBox
        Left = 8
        Top = 166
        Width = 200
        Height = 17
        Alignment = taLeftJustify
        Caption = 'IdLogDebug->Active'
        TabOrder = 16
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
      object Label12: TLabel
        Left = 335
        Top = 291
        Width = 91
        Height = 13
        Caption = 'PostMessage.Body'
      end
      object Label11: TLabel
        Left = 311
        Top = 231
        Width = 138
        Height = 13
        Caption = 'PostMessage.ToCarbonCopy'
      end
      object SMTPPostMessageToAddressMemo: TMemo
        Left = 8
        Top = 245
        Width = 245
        Height = 42
        TabOrder = 0
      end
      object SMTPPostMessageToBlindCarbonCopyMemo: TMemo
        Left = 8
        Top = 305
        Width = 245
        Height = 42
        TabOrder = 1
      end
      object SMTPStatusWindowMemo: TMemo
        Left = 8
        Top = 365
        Width = 245
        Height = 70
        TabOrder = 2
      end
      object SMTPPostMessageAttachmentsListBox: TListBox
        Left = 258
        Top = 365
        Width = 245
        Height = 70
        ItemHeight = 13
        TabOrder = 3
      end
      object SMTPPostMessageBodyMemo: TMemo
        Left = 258
        Top = 305
        Width = 245
        Height = 42
        TabOrder = 4
      end
      object SMTPPostMessageToCarbonCopyMemo: TMemo
        Left = 258
        Top = 245
        Width = 245
        Height = 42
        TabOrder = 5
      end
      object SMTPReportLevelComboBox: TComboBox
        Left = 195
        Top = 206
        Width = 121
        Height = 21
        Style = csDropDownList
        ItemHeight = 13
        ItemIndex = 0
        TabOrder = 6
        Text = 'None'
        Items.Strings = (
          'None'
          'Informational'
          'Basic'
          'Routines'
          'Debug'
          'Trace')
      end
      object SMTPNameOfTheMailingListToExpandEdit: TEdit
        Left = 195
        Top = 184
        Width = 121
        Height = 21
        TabOrder = 7
      end
      object SMTPPostMessageSubjectEdit: TEdit
        Left = 195
        Top = 162
        Width = 121
        Height = 21
        TabOrder = 8
      end
      object SMTPPostMessageReplyToEdit: TEdit
        Left = 195
        Top = 140
        Width = 121
        Height = 21
        TabOrder = 9
      end
      object SMTPPostMessageLocalProgramEdit: TEdit
        Left = 195
        Top = 118
        Width = 121
        Height = 21
        TabOrder = 10
      end
      object SMTPPostMessageFromNameEdit: TEdit
        Left = 195
        Top = 96
        Width = 121
        Height = 21
        TabOrder = 11
      end
      object SMTPPostMessageFromAddressEdit: TEdit
        Left = 195
        Top = 74
        Width = 121
        Height = 21
        TabOrder = 12
      end
      object SMTPPostMessageDateEdit: TEdit
        Left = 195
        Top = 52
        Width = 121
        Height = 21
        TabOrder = 13
      end
      object SMTPUserIDEdit: TEdit
        Left = 195
        Top = 30
        Width = 121
        Height = 21
        TabOrder = 14
      end
      object SMTPHostEdit: TEdit
        Left = 195
        Top = 8
        Width = 121
        Height = 21
        TabOrder = 15
      end
      object SMTPClearParamsPropertyCheckBox: TCheckBox
        Left = 330
        Top = 10
        Width = 150
        Height = 17
        Caption = 'ClearParams property'
        TabOrder = 16
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
        TabOrder = 17
      end
      object CharsetComboBox: TComboBox
        Left = 330
        Top = 104
        Width = 180
        Height = 21
        Style = csDropDownList
        ItemHeight = 13
        ItemIndex = 0
        TabOrder = 18
        Text = 'koi-8r'
        Items.Strings = (
          'koi-8r'
          'win1251')
      end
      object SMTPConnectDisconnectButton: TButton
        Left = 330
        Top = 128
        Width = 180
        Height = 25
        Caption = 'Connect/Disconnect'
        TabOrder = 19
        OnClick = SMTPConnectDisconnectButtonClick
      end
      object SMTPSendMailButton: TButton
        Left = 330
        Top = 153
        Width = 180
        Height = 25
        Caption = 'SendMail'
        TabOrder = 20
      end
      object SMTPClearsEditFieldsAndParametersButton: TButton
        Left = 330
        Top = 178
        Width = 180
        Height = 25
        Caption = 'Clears edit fields and parameters'
        TabOrder = 21
      end
      object SMTPExpandListButton: TButton
        Left = 330
        Top = 203
        Width = 180
        Height = 25
        Caption = 'Expand List'
        TabOrder = 22
      end
    end
  end
  object IdPOP3: TIdPOP3
    OnStatus = IdPOP3Status
    Intercept = IdLogDebugPOP3
    InterceptEnabled = True
    OnDisconnected = IdPOP3Disconnected
    OnWork = IdPOP3Work
    OnWorkBegin = IdPOP3WorkBegin
    OnWorkEnd = IdPOP3WorkEnd
    OnConnected = IdPOP3Connected
    Left = 504
  end
  object IdMessagePOP3: TIdMessage
    BccList = <>
    CCList = <>
    Recipients = <>
    ReplyTo = <>
    Left = 472
  end
  object IdLogDebugPOP3: TIdLogDebug
    OnConnect = IdLogDebugPOP3Connect
    OnLogItem = IdLogDebugPOP3LogItem
    Target = ltEvent
    Left = 440
  end
  object IdSMTP: TIdSMTP
    OnStatus = IdSMTPStatus
    Intercept = IdLogDebugPOP3
    OnDisconnected = IdSMTPDisconnected
    OnWork = IdSMTPWork
    OnWorkBegin = IdSMTPWorkBegin
    OnWorkEnd = IdSMTPWorkEnd
    OnConnected = IdSMTPConnected
    Left = 400
  end
end
