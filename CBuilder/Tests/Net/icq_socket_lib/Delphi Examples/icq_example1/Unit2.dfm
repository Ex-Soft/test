object ICQFrame: TICQFrame
  Left = 0
  Top = 0
  Width = 353
  Height = 429
  TabOrder = 0
  object LogLabel: TLabel
    Left = 8
    Top = 304
    Width = 68
    Height = 13
    Caption = 'Log messages'
  end
  object TopPanel: TPanel
    Left = 0
    Top = 0
    Width = 353
    Height = 321
    Align = alTop
    BevelOuter = bvNone
    TabOrder = 1
    object Label1: TLabel
      Left = 8
      Top = 8
      Width = 19
      Height = 13
      Caption = 'UIN'
    end
    object Label2: TLabel
      Left = 88
      Top = 8
      Width = 46
      Height = 13
      Caption = 'Password'
    end
    object Label3: TLabel
      Left = 152
      Top = 8
      Width = 30
      Height = 13
      Caption = 'Status'
    end
    object Label4: TLabel
      Left = 8
      Top = 56
      Width = 52
      Height = 13
      Caption = 'Contact list'
    end
    object Bevel1: TBevel
      Left = 0
      Top = 200
      Width = 345
      Height = 9
      Shape = bsTopLine
    end
    object UrlLabel: TLabel
      Left = 8
      Top = 208
      Width = 13
      Height = 13
      Caption = 'Url'
    end
    object Label7: TLabel
      Left = 8
      Top = 256
      Width = 53
      Height = 13
      Caption = 'Description'
    end
    object Shape: TShape
      Left = 248
      Top = 8
      Width = 97
      Height = 9
      Brush.Color = clRed
      Pen.Color = clWhite
      Shape = stRoundRect
    end
    object UINEdit: TEdit
      Left = 8
      Top = 24
      Width = 81
      Height = 21
      TabOrder = 0
      Text = '123456789'
      OnChange = UINEditChange
      OnEnter = UINEditEnter
      OnExit = UINEditExit
    end
    object PassEdit: TEdit
      Left = 88
      Top = 24
      Width = 65
      Height = 21
      TabOrder = 1
      Text = '12345678'
      OnChange = PassEditChange
      OnEnter = UINEditEnter
      OnExit = UINEditExit
    end
    object StatusCombo: TComboBox
      Left = 152
      Top = 24
      Width = 89
      Height = 21
      Style = csDropDownList
      ItemHeight = 13
      TabOrder = 2
      OnChange = StatusComboChange
      OnEnter = UINEditEnter
      OnExit = UINEditExit
      Items.Strings = (
        'Offline'
        'Online'
        'Away'
        'DND'
        'NA'
        'Occupied'
        'FreeChat'
        'Invisible ')
    end
    object ConnectBtn: TBitBtn
      Left = 248
      Top = 24
      Width = 96
      Height = 21
      Caption = 'Connect'
      TabOrder = 3
      OnClick = ConnectBtnClick
    end
    object ContactList: TListBox
      Left = 8
      Top = 72
      Width = 233
      Height = 89
      ItemHeight = 13
      TabOrder = 4
      OnClick = ContactListClick
      OnDblClick = ContactListClick
      OnEnter = ContactListEnter
      OnExit = ContactListExit
      OnKeyDown = ContactListKeyDown
      OnMouseDown = ContactListMouseDown
    end
    object RemoveContactBtn: TBitBtn
      Left = 248
      Top = 136
      Width = 96
      Height = 21
      Caption = 'Remove'
      TabOrder = 7
      OnClick = RemoveContactBtnClick
    end
    object ContactUINEdit: TEdit
      Left = 8
      Top = 168
      Width = 81
      Height = 21
      TabOrder = 8
      Text = '123456789'
      OnEnter = ContactListEnter
      OnExit = ContactListExit
    end
    object ContactVisCombo: TComboBox
      Left = 96
      Top = 168
      Width = 145
      Height = 21
      Style = csDropDownList
      ItemHeight = 13
      TabOrder = 9
      OnEnter = ContactListEnter
      OnExit = ContactListExit
      Items.Strings = (
        'Normal'
        'In visible list'
        'In invisible list')
    end
    object SetContactBtn: TBitBtn
      Left = 248
      Top = 168
      Width = 96
      Height = 21
      Caption = 'Set contact'
      TabOrder = 10
      OnClick = SetContactBtnClick
    end
    object UrlEdit: TEdit
      Left = 8
      Top = 224
      Width = 233
      Height = 21
      TabOrder = 11
      Text = 'UrlEdit'
      OnEnter = UrlEditEnter
      OnExit = UrlEditExit
    end
    object DescEdit: TEdit
      Left = 8
      Top = 272
      Width = 233
      Height = 21
      TabOrder = 13
      Text = 'DescEdit'
      OnEnter = UrlEditEnter
      OnExit = UrlEditExit
    end
    object SendRadio: TRadioGroup
      Left = 248
      Top = 216
      Width = 96
      Height = 49
      Caption = ' Send '
      ItemIndex = 0
      Items.Strings = (
        'url'
        'message')
      TabOrder = 12
      OnClick = SendRadioClick
      OnEnter = UrlEditEnter
      OnExit = UrlEditExit
    end
    object SendBtn: TBitBtn
      Left = 248
      Top = 272
      Width = 96
      Height = 21
      Caption = 'Send'
      TabOrder = 14
      OnClick = SendBtnClick
    end
    object Trace: TCheckBox
      Left = 248
      Top = 48
      Width = 96
      Height = 17
      Caption = 'Trace net'
      Checked = True
      State = cbChecked
      TabOrder = 15
    end
    object GetInfoBtn: TBitBtn
      Left = 248
      Top = 72
      Width = 97
      Height = 21
      Caption = 'Get full Info'
      TabOrder = 5
      OnClick = GetInfoBtnClick
    end
    object SearchBtn: TBitBtn
      Left = 248
      Top = 104
      Width = 97
      Height = 21
      Caption = 'Search contact'
      Enabled = False
      TabOrder = 6
    end
  end
  object LogMemo: TMemo
    Left = 8
    Top = 328
    Width = 337
    Height = 97
    Lines.Strings = (
      'LogMemo')
    TabOrder = 0
    WordWrap = False
  end
  object ICQSocket: TICQSocket
    ProtocolVersion = 8
    AutoConnect = False
    Host = 'login.icq.com'
    HostPort = 5190
    MaxPassLen = 8
    ProxyUsed = False
    ProxyPort = -1
    ProxyLoginUsed = False
    LogLevel = ICQ_Log_Message
    OnError = ICQSocketError
    OnConnecting = ICQSocketConnecting
    OnConnected = ICQSocketConnected
    OnDisconnecting = ICQSocketDisconnecting
    OnDisconnected = ICQSocketDisconnected
    OnInvalidLogin = ICQSocketInvalidLogin
    OnContactOnline = ICQSocketContactOnline
    OnContactOffline = ICQSocketContactOnline
    OnContactStatusUpdate = ICQSocketContactOnline
    OnEndFound = ICQSocketEndFound
    OnProcessMessage = ICQSocketProcessMessage
    OnProcessUrl = ICQSocketProcessUrl
    OnProcessWebPager = ICQSocketProcessWebPager
    OnProcessAdded = ICQSocketProcessAdded
    OnProcessMailExpress = ICQSocketProcessMailExpress
    OnProcessChatRequest = ICQSocketProcessChatRequest
    OnProcessFileRequest = ICQSocketProcessFileRequest
    OnProcessAuthRequest = ICQSocketProcessAuthRequest
    OnLog = ICQSocketLog
    OnTimeout = ICQSocketTimeout
    OnSrvUDPAck = ICQSocketSrvUDPAck
    OnBeginWait = ICQSocketBeginWait
    OnWait = ICQSocketWait
    OnWaitConnect = ICQSocketWaitConnect
    OnEndWait = ICQSocketEndWait
    OnWriteUDPPacket = ICQSocketWriteUDPPacket
    OnReadUDPPacket = ICQSocketReadUDPPacket
    OnWriteOscarPacket = ICQSocketWriteOscarPacket
    OnReadOscarPacket = ICQSocketReadOscarPacket
    Left = 16
    Top = 80
  end
end
